#define STEP
#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using DecompTools.Decompiler.CSharp;
using DecompTools.Decompiler.IL.Transforms;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.IL.ControlFlow;

internal class YieldReturnDecompiler : IILTransform
{
	private ILTransformContext context;

	private MetadataReader metadata;

	private TypeDefinitionHandle currentType;

	private TypeDefinitionHandle enumeratorType;

	private MethodDefinitionHandle enumeratorCtor;

	private bool isCompiledWithMono;

	private MethodDefinitionHandle disposeMethod;

	private IField stateField;

	private IField currentField;

	private IField disposingField;

	private readonly Dictionary<IField, ILVariable> fieldToParameterMap = new Dictionary<IField, ILVariable>();

	private Dictionary<IMethod, LongSet> finallyMethodToStateRange;

	private readonly Dictionary<IMethod, (int? outerState, ILFunction function)> decompiledFinallyMethods = new Dictionary<IMethod, (int?, ILFunction)>();

	private readonly List<StLoc> returnStores = new List<StLoc>();

	private ILVariable skipFinallyBodies;

	private HashSet<ILVariable> cachedStateVars;

	public void Run(ILFunction function, ILTransformContext context)
	{
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
		if (!context.Settings.YieldReturn)
		{
			return;
		}
		this.context = context;
		metadata = context.PEFile.Metadata;
		currentType = metadata.GetMethodDefinition((MethodDefinitionHandle)context.Function.Method.MetadataToken).GetDeclaringType();
		enumeratorType = default(TypeDefinitionHandle);
		enumeratorCtor = default(MethodDefinitionHandle);
		stateField = null;
		currentField = null;
		disposingField = null;
		fieldToParameterMap.Clear();
		finallyMethodToStateRange = null;
		decompiledFinallyMethods.Clear();
		returnStores.Clear();
		skipFinallyBodies = null;
		cachedStateVars = null;
		if (!MatchEnumeratorCreationPattern(function))
		{
			return;
		}
		BlockContainer blockContainer;
		try
		{
			AnalyzeCtor();
			AnalyzeCurrentProperty();
			ResolveIEnumerableIEnumeratorFieldMapping();
			ConstructExceptionTable();
			blockContainer = AnalyzeMoveNext();
		}
		catch (SymbolicAnalysisFailedException)
		{
			return;
		}
		context.Step("Replacing body with MoveNext() body", function);
		function.IsIterator = true;
		function.StateMachineCompiledWithMono = isCompiledWithMono;
		function.Body = blockContainer;
		function.Variables.AddRange(Enumerable.Distinct<ILVariable>(Enumerable.Select<IInstructionWithVariableOperand, ILVariable>(Enumerable.OfType<IInstructionWithVariableOperand>((IEnumerable)blockContainer.Descendants), (Func<IInstructionWithVariableOperand, ILVariable>)((IInstructionWithVariableOperand inst) => inst.Variable))));
		function.CheckInvariant(ILPhase.Normal);
		PrintFinallyMethodStateRanges(blockContainer);
		foreach (var (stateMachineField, iLVariable2) in fieldToParameterMap)
		{
			iLVariable2.StateMachineField = stateMachineField;
		}
		context.Step("Delete unreachable blocks", function);
		if (isCompiledWithMono)
		{
			foreach (BlockContainer item in Enumerable.OfType<BlockContainer>((IEnumerable)Enumerable.SelectMany<Block, ILInstruction>((IEnumerable<Block>)blockContainer.Blocks, (Func<Block, IEnumerable<ILInstruction>>)((Block c) => c.Descendants))))
			{
				item.SortBlocks(deleteUnreachableBlocks: true);
			}
		}
		blockContainer.SortBlocks(deleteUnreachableBlocks: true);
		if (!isCompiledWithMono)
		{
			DecompileFinallyBlocks();
			ReconstructTryFinallyBlocks(function);
		}
		context.Step("Translate fields to local accesses", function);
		TranslateFieldsToLocalAccess(function, function, fieldToParameterMap, isCompiledWithMono);
		CleanSkipFinallyBodies(function);
		if (isCompiledWithMono)
		{
			if (fieldToParameterMap.TryGetValue(stateField, out var value))
			{
				returnStores.AddRange(Enumerable.OfType<StLoc>((IEnumerable)value.StoreInstructions));
			}
			var enumerator3 = cachedStateVars.GetEnumerator();
			try
			{
				while (enumerator3.MoveNext())
				{
					ILVariable current2 = enumerator3.Current;
					returnStores.AddRange(Enumerable.OfType<StLoc>((IEnumerable)current2.StoreInstructions));
				}
			}
			finally
			{
				((IDisposable)enumerator3/*cast due to constrained. prefix*/).Dispose();
			}
		}
		if (returnStores.Count > 0)
		{
			context.Step("Remove temporaries", function);
			foreach (StLoc returnStore in returnStores)
			{
				if (returnStore.Variable.LoadCount == 0 && returnStore.Variable.AddressCount == 0 && returnStore.Parent is Block block)
				{
					Debug.Assert(SemanticHelper.IsPure(returnStore.Value.Flags));
					block.Instructions.Remove(returnStore);
				}
			}
		}
		function.RunTransforms(CSharpDecompiler.EarlyILTransforms(), context);
	}

	private bool MatchEnumeratorCreationPattern(ILFunction function)
	{
		Block block = SingleBlock(function.Body);
		if (block == null || block.Instructions.Count == 0)
		{
			return false;
		}
		ILInstruction value;
		if (block.Instructions.Count == 1)
		{
			if (!block.Instructions[0].MatchReturn(out value))
			{
				return false;
			}
			if (MatchEnumeratorCreationNewObj(value))
			{
				return true;
			}
			if (MatchMonoEnumeratorCreationNewObj(value))
			{
				isCompiledWithMono = true;
				return true;
			}
			return false;
		}
		int num = 0;
		if (!block.Instructions[num].MatchStLoc(out var variable, out value))
		{
			return false;
		}
		checked
		{
			if (MatchEnumeratorCreationNewObj(value))
			{
				num++;
				isCompiledWithMono = false;
			}
			else
			{
				if (!MatchMonoEnumeratorCreationNewObj(value))
				{
					return false;
				}
				num++;
				isCompiledWithMono = true;
			}
			ILInstruction target;
			IField field;
			ILInstruction value2;
			for (; num < block.Instructions.Count && block.Instructions[num].MatchStFld(out target, out field, out value2); num++)
			{
				if (!target.MatchLdLoc(variable))
				{
					return false;
				}
				if (value2.MatchLdLoc(out var variable2) && variable2.Kind == VariableKind.Parameter)
				{
					fieldToParameterMap[(IField)field.MemberDefinition] = variable2;
					continue;
				}
				if (value2 is LdObj ldObj && ldObj.Target.MatchLdThis())
				{
					fieldToParameterMap[(IField)field.MemberDefinition] = ((LdLoc)ldObj.Target).Variable;
					continue;
				}
				return false;
			}
			if (block.Instructions[num].MatchStLoc(out var variable3, out var value3) && value3.MatchLdLoc(variable))
			{
				num++;
			}
			if (isCompiledWithMono && block.Instructions[num].MatchStFld(out var target2, out var field2, out var value4) && target2.MatchLdLoc(variable3 ?? variable) && (value4.MatchLdcI4(-2) || value4.MatchLdcI4(0)))
			{
				stateField = (IField)field2.MemberDefinition;
				isCompiledWithMono = true;
				num++;
			}
			if (block.Instructions[num].MatchReturn(out var value5) && value5.MatchLdLoc(variable3 ?? variable))
			{
				return true;
			}
			return false;
		}
	}

	internal static Block SingleBlock(ILInstruction body)
	{
		Block result = body as Block;
		if (body is BlockContainer blockContainer && blockContainer.Blocks.Count == 1)
		{
			result = Enumerable.Single<Block>((IEnumerable<Block>)blockContainer.Blocks);
		}
		return result;
	}

	private bool MatchEnumeratorCreationNewObj(ILInstruction inst)
	{
		if (!(inst is NewObj newObj))
		{
			return false;
		}
		if (newObj.Arguments.Count != 1)
		{
			return false;
		}
		if (!newObj.Arguments[0].MatchLdcI4(out var value))
		{
			return false;
		}
		if (value != -2 && value != 0)
		{
			return false;
		}
		EntityHandle metadataToken = newObj.Method.MetadataToken;
		enumeratorCtor = ((metadataToken.IsNil || metadataToken.Kind != HandleKind.MethodDefinition) ? default(MethodDefinitionHandle) : ((MethodDefinitionHandle)metadataToken));
		enumeratorType = (enumeratorCtor.IsNil ? default(TypeDefinitionHandle) : metadata.GetMethodDefinition(enumeratorCtor).GetDeclaringType());
		return (enumeratorType.IsNil ? default(TypeDefinitionHandle) : metadata.GetTypeDefinition(enumeratorType).GetDeclaringType()) == currentType && IsCompilerGeneratorEnumerator(enumeratorType, metadata);
	}

	private bool MatchMonoEnumeratorCreationNewObj(ILInstruction inst)
	{
		if (!(inst is NewObj newObj))
		{
			return false;
		}
		if (newObj.Arguments.Count != 0)
		{
			return false;
		}
		EntityHandle metadataToken = newObj.Method.MetadataToken;
		enumeratorCtor = ((metadataToken.IsNil || metadataToken.Kind != HandleKind.MethodDefinition) ? default(MethodDefinitionHandle) : ((MethodDefinitionHandle)metadataToken));
		enumeratorType = (enumeratorCtor.IsNil ? default(TypeDefinitionHandle) : metadata.GetMethodDefinition(enumeratorCtor).GetDeclaringType());
		return (enumeratorType.IsNil ? default(TypeDefinitionHandle) : metadata.GetTypeDefinition(enumeratorType).GetDeclaringType()) == currentType && IsCompilerGeneratorEnumerator(enumeratorType, metadata);
	}

	public static bool IsCompilerGeneratorEnumerator(TypeDefinitionHandle type, MetadataReader metadata)
	{
		if (!type.IsNil && type.IsCompilerGenerated(metadata))
		{
			TypeDefinition typeDefinition2;
			TypeDefinition typeDefinition = (typeDefinition2 = metadata.GetTypeDefinition(type));
			if (!typeDefinition.GetDeclaringType().IsNil)
			{
				foreach (InterfaceImplementationHandle interfaceImplementation in typeDefinition2.GetInterfaceImplementations())
				{
					FullTypeName fullTypeName = metadata.GetInterfaceImplementation(interfaceImplementation).Interface.GetFullTypeName(metadata);
					if (!fullTypeName.IsNested && fullTypeName.TopLevelTypeName.Namespace == "System.Collections" && fullTypeName.TopLevelTypeName.Name == "IEnumerator")
					{
						return true;
					}
				}
				return false;
			}
		}
		return false;
	}

	private void AnalyzeCtor()
	{
		Block block = SingleBlock(CreateILAst(enumeratorCtor, context).Body);
		if (block == null)
		{
			throw new SymbolicAnalysisFailedException("Missing enumeratorCtor.Body");
		}
		foreach (ILInstruction instruction in block.Instructions)
		{
			if (instruction.MatchStFld(out var target, out var field, out var value) && target.MatchLdThis() && value.MatchLdLoc(out var variable) && variable.Kind == VariableKind.Parameter && variable.Index == 0)
			{
				stateField = (IField)field.MemberDefinition;
			}
		}
		if (stateField == null && !isCompiledWithMono)
		{
			throw new SymbolicAnalysisFailedException("Could not find stateField");
		}
	}

	internal static ILFunction CreateILAst(MethodDefinitionHandle method, ILTransformContext context)
	{
		MetadataReader metadataReader = context.PEFile.Metadata;
		if (method.IsNil)
		{
			throw new SymbolicAnalysisFailedException();
		}
		MethodDefinition methodDefinition = metadataReader.GetMethodDefinition(method);
		if (!methodDefinition.HasBody())
		{
			throw new SymbolicAnalysisFailedException();
		}
		GenericContext genericContext = context.Function.GenericContext;
		genericContext = new GenericContext(Enumerable.ToArray<ITypeParameter>(Enumerable.Concat<ITypeParameter>((IEnumerable<ITypeParameter>)(genericContext.ClassTypeParameters ?? EmptyList<ITypeParameter>.Instance), (IEnumerable<ITypeParameter>)(genericContext.MethodTypeParameters ?? EmptyList<ITypeParameter>.Instance))), null);
		MethodBodyBlock methodBody = context.TypeSystem.MainModule.PEFile.Reader.GetMethodBody(methodDefinition.RelativeVirtualAddress);
		ILFunction iLFunction = context.CreateILReader().ReadIL(method, methodBody, genericContext, context.CancellationToken);
		iLFunction.RunTransforms(CSharpDecompiler.EarlyILTransforms(aggressivelyDuplicateReturnBlocks: true), new ILTransformContext(iLFunction, context.TypeSystem, context.DebugInfo, context.Settings)
		{
			CancellationToken = context.CancellationToken,
			DecompileRun = context.DecompileRun
		});
		return iLFunction;
	}

	private void AnalyzeCurrentProperty()
	{
		MethodDefinitionHandle method = Enumerable.FirstOrDefault<MethodDefinitionHandle>((IEnumerable<MethodDefinitionHandle>)metadata.GetTypeDefinition(enumeratorType).GetMethods(), (Func<MethodDefinitionHandle, bool>)((MethodDefinitionHandle m) => metadata.GetString(metadata.GetMethodDefinition(m).Name).StartsWith("System.Collections.Generic.IEnumerator", StringComparison.Ordinal) && metadata.GetString(metadata.GetMethodDefinition(m).Name).EndsWith(".get_Current", StringComparison.Ordinal)));
		Block block = SingleBlock(CreateILAst(method, context).Body);
		if (block == null)
		{
			throw new SymbolicAnalysisFailedException();
		}
		ILVariable variable;
		ILInstruction value2;
		ILInstruction target2;
		IField field2;
		ILInstruction value3;
		if (block.Instructions.Count == 1)
		{
			if (block.Instructions[0].MatchReturn(out var value) && value.MatchLdFld(out var target, out var field) && target.MatchLdThis())
			{
				currentField = (IField)field.MemberDefinition;
			}
		}
		else if (block.Instructions.Count == 2 && block.Instructions[0].MatchStLoc(out variable, out value2) && value2.MatchLdFld(out target2, out field2) && target2.MatchLdThis() && block.Instructions[1].MatchReturn(out value3) && value3.MatchLdLoc(variable))
		{
			currentField = (IField)field2.MemberDefinition;
		}
		if (currentField == null)
		{
			throw new SymbolicAnalysisFailedException("Could not find currentField");
		}
	}

	private void ResolveIEnumerableIEnumeratorFieldMapping()
	{
		MethodDefinitionHandle method = Enumerable.FirstOrDefault<MethodDefinitionHandle>((IEnumerable<MethodDefinitionHandle>)metadata.GetTypeDefinition(enumeratorType).GetMethods(), (Func<MethodDefinitionHandle, bool>)((MethodDefinitionHandle m) => metadata.GetString(metadata.GetMethodDefinition(m).Name).StartsWith("System.Collections.Generic.IEnumerable", StringComparison.Ordinal) && metadata.GetString(metadata.GetMethodDefinition(m).Name).EndsWith(".GetEnumerator", StringComparison.Ordinal)));
		if (method.IsNil)
		{
			return;
		}
		ILFunction iLFunction = CreateILAst(method, context);
		foreach (Block item in Enumerable.OfType<Block>((IEnumerable)iLFunction.Descendants))
		{
			foreach (ILInstruction instruction in item.Instructions)
			{
				if (instruction.MatchStFld(out var _, out var field, out var value) && value.MatchLdFld(out var target2, out var field2) && target2.MatchLdThis())
				{
					field = (IField)field.MemberDefinition;
					field2 = (IField)field2.MemberDefinition;
					if (fieldToParameterMap.TryGetValue(field2, out var value2))
					{
						fieldToParameterMap[field] = value2;
					}
				}
			}
		}
	}

	private void ConstructExceptionTable()
	{
		if (isCompiledWithMono)
		{
			disposeMethod = Enumerable.FirstOrDefault<MethodDefinitionHandle>((IEnumerable<MethodDefinitionHandle>)metadata.GetTypeDefinition(enumeratorType).GetMethods(), (Func<MethodDefinitionHandle, bool>)((MethodDefinitionHandle m) => metadata.GetString(metadata.GetMethodDefinition(m).Name) == "Dispose"));
			ILFunction iLFunction = CreateILAst(disposeMethod, context);
			BlockContainer blockContainer = (BlockContainer)iLFunction.Body;
			for (int num = 0; num < blockContainer.EntryPoint.Instructions.Count && !(blockContainer.EntryPoint.Instructions[num] is Branch); num = checked(num + 1))
			{
				if (blockContainer.EntryPoint.Instructions[num] is StObj stObj && stObj.MatchStFld(out var target, out var field, out var value) && target.MatchLdThis() && field.Type.IsKnownType(KnownTypeCode.Boolean) && value.MatchLdcI4(1))
				{
					disposingField = (IField)field.MemberDefinition;
					break;
				}
			}
			finallyMethodToStateRange = null;
		}
		else
		{
			disposeMethod = Enumerable.FirstOrDefault<MethodDefinitionHandle>((IEnumerable<MethodDefinitionHandle>)metadata.GetTypeDefinition(enumeratorType).GetMethods(), (Func<MethodDefinitionHandle, bool>)((MethodDefinitionHandle m) => metadata.GetString(metadata.GetMethodDefinition(m).Name) == "System.IDisposable.Dispose"));
			ILFunction iLFunction2 = CreateILAst(disposeMethod, context);
			StateRangeAnalysis stateRangeAnalysis = new StateRangeAnalysis(StateRangeAnalysisMode.IteratorDispose, stateField);
			stateRangeAnalysis.AssignStateRanges(iLFunction2.Body, LongSet.Universe);
			finallyMethodToStateRange = stateRangeAnalysis.finallyMethodToStateRange;
		}
	}

	[Conditional("DEBUG")]
	private void PrintFinallyMethodStateRanges(BlockContainer bc)
	{
		if (finallyMethodToStateRange == null)
		{
			return;
		}
		foreach (var (method2, longSet2) in finallyMethodToStateRange)
		{
			bc.Blocks[0].Instructions.Insert(0, new Nop
			{
				Comment = method2.Name + " in " + longSet2
			});
		}
	}

	private BlockContainer AnalyzeMoveNext()
	{
		context.StepStartGroup("AnalyzeMoveNext");
		MethodDefinitionHandle method = Enumerable.FirstOrDefault<MethodDefinitionHandle>((IEnumerable<MethodDefinitionHandle>)metadata.GetTypeDefinition(enumeratorType).GetMethods(), (Func<MethodDefinitionHandle, bool>)((MethodDefinitionHandle m) => metadata.GetString(metadata.GetMethodDefinition(m).Name) == "MoveNext"));
		ILFunction iLFunction = CreateILAst(method, context);
		foreach (StLoc item in Enumerable.ToList<StLoc>(Enumerable.Where<StLoc>(Enumerable.OfType<StLoc>((IEnumerable)iLFunction.Descendants), (Func<StLoc, bool>)((StLoc s) => s.Variable.IsSingleDefinition && s.Value.MatchLdThis()))))
		{
			CopyPropagation.Propagate(item, context);
		}
		BlockContainer blockContainer = (BlockContainer)iLFunction.Body;
		if (blockContainer.Blocks.Count == 1 && blockContainer.Blocks[0].Instructions.Count == 1 && blockContainer.Blocks[0].Instructions[0] is TryFault tryFault)
		{
			blockContainer = (BlockContainer)tryFault.TryBlock;
			if (!(tryFault.FaultBlock is BlockContainer blockContainer2) || blockContainer2.Blocks.Count != 1)
			{
				throw new SymbolicAnalysisFailedException("Unexpected number of blocks in MoveNext() fault block");
			}
			Block block = Enumerable.Single<Block>((IEnumerable<Block>)blockContainer2.Blocks);
			if (block.Instructions.Count != 2 || !(block.Instructions[0] is Call call) || !(call.Method.MetadataToken == disposeMethod) || call.Arguments.Count != 1 || !call.Arguments[0].MatchLdThis() || !block.Instructions[1].MatchLeave(blockContainer2))
			{
				throw new SymbolicAnalysisFailedException("Unexpected fault block contents in MoveNext()");
			}
		}
		if (stateField == null)
		{
			if (!(blockContainer.EntryPoint.Instructions[0] is StLoc stLoc) || !stLoc.Value.MatchLdFld(out var target, out var field) || !target.MatchLdThis() || !field.Type.IsKnownType(KnownTypeCode.Int32))
			{
				throw new SymbolicAnalysisFailedException("Could not find state field.");
			}
			stateField = (IField)field.MemberDefinition;
		}
		skipFinallyBodies = null;
		if (isCompiledWithMono)
		{
			foreach (TryFinally item2 in Enumerable.OfType<TryFinally>((IEnumerable)blockContainer.Descendants))
			{
				if (!((item2.FinallyBlock as BlockContainer)?.EntryPoint.Instructions[0] is IfInstruction ifInstruction) || !ifInstruction.Condition.MatchLogicNot(out var arg) || !arg.MatchLdLoc(out var variable) || !variable.Type.IsKnownType(KnownTypeCode.Boolean))
				{
					continue;
				}
				bool flag = false;
				for (int num = 0; num < 3; num = checked(num + 1))
				{
					if (blockContainer.EntryPoint.Instructions.ElementAtOrDefault(num) is StLoc stLoc2 && stLoc2.Variable == variable && stLoc2.Value.MatchLdcI4(0))
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					skipFinallyBodies = variable;
					break;
				}
			}
		}
		PropagateCopiesOfFields(blockContainer);
		StateRangeAnalysis stateRangeAnalysis = new StateRangeAnalysis(StateRangeAnalysisMode.IteratorMoveNext, stateField);
		stateRangeAnalysis.skipFinallyBodies = skipFinallyBodies;
		stateRangeAnalysis.CancellationToken = context.CancellationToken;
		stateRangeAnalysis.AssignStateRanges(blockContainer, LongSet.Universe);
		cachedStateVars = stateRangeAnalysis.CachedStateVars.ToHashSet();
		BlockContainer result = ConvertBody(blockContainer, stateRangeAnalysis);
		iLFunction.Variables.Clear();
		iLFunction.ReleaseRef();
		context.StepEndGroup();
		return result;
	}

	private void PropagateCopiesOfFields(BlockContainer body)
	{
		context.StepStartGroup("PropagateCopiesOfFields");
		HashSet<IField> val = Enumerable.Select<LdFlda, IField>(Enumerable.Where<LdFlda>(Enumerable.OfType<LdFlda>((IEnumerable)body.Descendants), (Func<LdFlda, bool>)((LdFlda ldflda) => ldflda.Parent.OpCode != OpCode.LdObj)), (Func<LdFlda, IField>)((LdFlda ldflda) => ldflda.Field)).ToHashSet();
		checked
		{
			for (int num = 0; num < body.EntryPoint.Instructions.Count && body.EntryPoint.Instructions[num] is StLoc stLoc; num++)
			{
				if (!stLoc.Variable.IsSingleDefinition)
				{
					break;
				}
				if (!(stLoc.Value is LdObj { Target: LdFlda target }))
				{
					break;
				}
				if (!target.Target.MatchLdThis())
				{
					break;
				}
				if (!val.Contains(target.Field))
				{
					LdLoc[] array = Enumerable.ToArray<LdLoc>((IEnumerable<LdLoc>)stLoc.Variable.LoadInstructions);
					foreach (LdLoc ldLoc in array)
					{
						ldLoc.ReplaceWith(stLoc.Value.Clone());
					}
					body.EntryPoint.Instructions.RemoveAt(num--);
				}
				else if (target.Field.MemberDefinition != stateField.MemberDefinition)
				{
					break;
				}
			}
			context.StepEndGroup();
		}
	}

	private BlockContainer ConvertBody(BlockContainer oldBody, StateRangeAnalysis rangeAnalysis)
	{
		LongDict<Block> blockStateMap = rangeAnalysis.GetBlockStateSetMapping(oldBody);
		BlockContainer newBody = new BlockContainer().WithILRange(oldBody);
		checked
		{
			for (int i = 0; i < oldBody.Blocks.Count; i++)
			{
				newBody.Blocks.Add(new Block().WithILRange(oldBody.Blocks[i]));
			}
			for (int j = 0; j < oldBody.Blocks.Count; j++)
			{
				Block block = oldBody.Blocks[j];
				Block block2 = newBody.Blocks[j];
				foreach (ILInstruction instruction in block.Instructions)
				{
					context.CancellationToken.ThrowIfCancellationRequested();
					if (instruction.MatchStFld(out var target, out var field, out var value) && target.MatchLdThis())
					{
						if (field.MemberDefinition.Equals(stateField))
						{
							if (!value.MatchLdcI4(out var _))
							{
								block2.Instructions.Add(new InvalidExpression("Assigned non-constant to iterator.state field").WithILRange(instruction));
								continue;
							}
							block2 = SplitBlock(block2, instruction);
						}
						else if (field.MemberDefinition.Equals(currentField))
						{
							block2.Instructions.Add(new YieldReturn(value).WithILRange(instruction));
							ConvertBranchAfterYieldReturn(block2, block, instruction.ChildIndex + 1);
							break;
						}
					}
					else if (instruction is Call call && call.Arguments.Count == 1 && call.Arguments[0].MatchLdThis() && finallyMethodToStateRange.ContainsKey((IMethod)call.Method.MemberDefinition))
					{
						block2 = SplitBlock(block2, instruction);
					}
					else if (instruction is TryFinally tryFinally && isCompiledWithMono)
					{
						BlockContainer blockContainer = (BlockContainer)tryFinally.TryBlock;
						StateRangeAnalysis stateRangeAnalysis = rangeAnalysis.CreateNestedAnalysis();
						stateRangeAnalysis.AssignStateRanges(blockContainer, LongSet.Universe);
						tryFinally.TryBlock = ConvertBody(blockContainer, stateRangeAnalysis);
					}
					block2.Instructions.Add(instruction);
					block2.AddILRange(instruction);
					UpdateBranchTargets(instruction);
				}
			}
			newBody.Blocks.Insert(0, new Block
			{
				Instructions = { MakeGoTo(0) }
			});
			return newBody;
		}
		void ConvertBranchAfterYieldReturn(Block newBlock, Block oldBlock, int pos)
		{
			checked
			{
				if (isCompiledWithMono && disposingField != null && oldBlock.Instructions[pos].MatchIfInstruction(out var condition, out var _) && condition.MatchLdFld(out var target2, out var field2) && target2.MatchLdThis() && field2.MemberDefinition.Equals(disposingField) && oldBlock.Instructions[pos + 1].MatchBranch(out var targetBlock) && targetBlock.Parent == oldBlock.Parent)
				{
					oldBlock = targetBlock;
					pos = 0;
				}
				if (oldBlock.Instructions[pos].MatchStFld(out var target3, out var field3, out var value3) && target3.MatchLdThis() && field3.MemberDefinition == stateField && value3.MatchLdcI4(out var value4))
				{
					pos++;
					if (oldBlock.Instructions[pos].MatchBranch(out targetBlock) && targetBlock.Parent == oldBlock.Parent)
					{
						oldBlock = targetBlock;
						pos = 0;
					}
					if (oldBlock.Instructions[pos].MatchStLoc(skipFinallyBodies, out value3))
					{
						if (!value3.MatchLdcI4(1))
						{
							newBlock.Instructions.Add(new InvalidExpression
							{
								ExpectedResultType = StackType.Void,
								Message = "Unexpected assignment to skipFinallyBodies"
							});
						}
						pos++;
					}
					if ((!oldBlock.Instructions[pos].MatchReturn(out var value5) || !value5.MatchLdcI4(1)) && (!oldBlock.Instructions[pos].MatchBranch(out targetBlock) || !targetBlock.Instructions[0].MatchReturn(out value5) || !value5.MatchLdcI4(1)))
					{
						newBlock.Instructions.Add(new InvalidBranch("Unable to find 'return true' for yield return"));
					}
					else
					{
						newBlock.Instructions.Add(MakeGoTo(value4));
					}
				}
				else
				{
					newBlock.Instructions.Add(new InvalidBranch("Unable to find new state assignment for yield return"));
				}
			}
		}
		ILInstruction MakeGoTo(int v)
		{
			Block orDefault = blockStateMap.GetOrDefault(v);
			if (orDefault != null)
			{
				if (orDefault.Parent == oldBody)
				{
					return new Branch(newBody.Blocks[orDefault.ChildIndex]);
				}
				return new Branch(orDefault);
			}
			return new InvalidBranch("Could not find block for state " + v);
		}
		Block SplitBlock(Block newBlock, ILInstruction oldInst)
		{
			if (newBlock.Instructions.Count > 0)
			{
				Block block3 = new Block();
				block3.AddILRange(new Interval(oldInst.StartILOffset, oldInst.StartILOffset));
				newBody.Blocks.Add(block3);
				newBlock.Instructions.Add(new Branch(block3));
				newBlock = block3;
			}
			return newBlock;
		}
		void UpdateBranchTargets(ILInstruction inst)
		{
			if (inst != null)
			{
				if (!(inst is Branch branch))
				{
					if (inst is Leave leave)
					{
						Leave leave2 = leave;
						if (leave2.MatchReturn(out var value3))
						{
							if (value3.MatchLdLoc(out var variable) && (variable.Kind == VariableKind.Local || variable.Kind == VariableKind.StackSlot) && variable.StoreInstructions.Count == 1 && variable.StoreInstructions[0] is StLoc stLoc)
							{
								returnStores.Add(stLoc);
								value3 = stLoc.Value;
							}
							if (value3.MatchLdcI4(0))
							{
								leave2.ReplaceWith(new Leave(newBody).WithILRange(leave2));
							}
							else
							{
								leave2.ReplaceWith(new InvalidBranch("Unexpected return in MoveNext()").WithILRange(leave2));
							}
						}
						else if (leave2.TargetContainer == oldBody)
						{
							leave2.TargetContainer = newBody;
						}
					}
				}
				else
				{
					Branch branch2 = branch;
					if (branch2.TargetContainer == oldBody)
					{
						branch2.TargetBlock = newBody.Blocks[branch2.TargetBlock.ChildIndex];
					}
				}
			}
			foreach (ILInstruction child in inst.Children)
			{
				UpdateBranchTargets(child);
			}
		}
	}

	internal static void TranslateFieldsToLocalAccess(ILFunction function, ILInstruction inst, Dictionary<IField, ILVariable> fieldToVariableMap, bool isCompiledWithMono = false)
	{
		if (inst is LdFlda ldFlda && ldFlda.Target.MatchLdThis())
		{
			IField field = (IField)ldFlda.Field.MemberDefinition;
			if (!fieldToVariableMap.TryGetValue(field, out var value))
			{
				string name = null;
				if (!string.IsNullOrEmpty(field.Name) && field.Name[0] == '<')
				{
					int num = field.Name.IndexOf('>');
					if (num > 1)
					{
						name = field.Name.Substring(1, checked(num - 1));
					}
				}
				value = function.RegisterVariable(VariableKind.Local, ldFlda.Field.ReturnType, name);
				value.HasInitialValue = true;
				value.StateMachineField = ldFlda.Field;
				fieldToVariableMap.Add(field, value);
			}
			if (value.StackType == StackType.Ref)
			{
				Debug.Assert(value.Kind == VariableKind.Parameter && value.Index < 0);
				inst.ReplaceWith(new LdLoc(value).WithILRange(inst));
			}
			else
			{
				inst.ReplaceWith(new LdLoca(value).WithILRange(inst));
			}
			return;
		}
		if (!isCompiledWithMono && inst.MatchLdThis())
		{
			inst.ReplaceWith(new InvalidExpression("stateMachine")
			{
				ExpectedResultType = inst.ResultType
			}.WithILRange(inst));
			return;
		}
		foreach (ILInstruction child in inst.Children)
		{
			TranslateFieldsToLocalAccess(function, child, fieldToVariableMap, isCompiledWithMono);
		}
		if (inst is LdObj { Target: LdLoca target } ldObj && target.Variable.StateMachineField != null)
		{
			LdLoc ldLoc = new LdLoc(target.Variable);
			ldLoc.AddILRange(ldObj);
			ldLoc.AddILRange(target);
			inst.ReplaceWith(ldLoc);
		}
		else if (inst is StObj { Target: LdLoca target2 } stObj && target2.Variable.StateMachineField != null)
		{
			StLoc stLoc = new StLoc(target2.Variable, stObj.Value);
			stLoc.AddILRange(stObj);
			stLoc.AddILRange(target2);
			inst.ReplaceWith(stLoc);
		}
	}

	private void DecompileFinallyBlocks()
	{
		foreach (IMethod key in finallyMethodToStateRange.Keys)
		{
			ILFunction iLFunction = CreateILAst((MethodDefinitionHandle)key.MetadataToken, context);
			BlockContainer blockContainer = (BlockContainer)iLFunction.Body;
			int? newState = GetNewState(blockContainer.EntryPoint);
			if (newState.HasValue)
			{
				blockContainer.EntryPoint.Instructions.RemoveAt(0);
			}
			iLFunction.ReleaseRef();
			decompiledFinallyMethods.Add(key, (newState, iLFunction));
		}
	}

	private void ReconstructTryFinallyBlocks(ILFunction iteratorFunction)
	{
		BlockContainer newBody = (BlockContainer)iteratorFunction.Body;
		context.Step("Reconstuct try-finally blocks", newBody);
		int[] array = new int[newBody.Blocks.Count];
		array[0] = -1;
		Dictionary<int, BlockContainer> stateToContainer = new Dictionary<int, BlockContainer>();
		stateToContainer.Add(-1, newBody);
		foreach (Block block3 in newBody.Blocks)
		{
			context.CancellationToken.ThrowIfCancellationRequested();
			int num = array[block3.ChildIndex];
			int? newState = GetNewState(block3);
			int num2 = newState.GetValueOrDefault();
			BlockContainer value;
			if (newState.HasValue)
			{
				block3.Instructions.RemoveAt(0);
				if (!stateToContainer.TryGetValue(num2, out value))
				{
					CreateTryBlock(block3, num2);
					value = stateToContainer[num];
				}
			}
			else
			{
				num2 = num;
				value = stateToContainer[num];
			}
			if (value != newBody)
			{
				value.Blocks.Add(block3);
			}
			block3.Instructions.Insert(0, new Nop
			{
				Comment = "state == " + num2
			});
			foreach (Branch item in Enumerable.OfType<Branch>((IEnumerable)block3.Descendants))
			{
				if (item.TargetBlock.Parent == newBody)
				{
					int num3 = num2;
					if (Block.GetPredecessor(item) is Call call && call.Arguments.Count == 1 && call.Arguments[0].MatchLdThis() && call.Method.Name == "System.IDisposable.Dispose")
					{
						num3 = -1;
						call.ReplaceWith(new Nop
						{
							Comment = "Dispose call"
						});
					}
					Debug.Assert(array[item.TargetBlock.ChildIndex] == num3 || array[item.TargetBlock.ChildIndex] == 0);
					array[item.TargetBlock.ChildIndex] = num3;
				}
			}
		}
		newBody.Blocks.RemoveAll((Block b) => b.Parent != newBody);
		void CreateTryBlock(Block block, int state)
		{
			IMethod method = FindFinallyMethod(state);
			Debug.Assert(method != null);
			finallyMethodToStateRange.Remove(method);
			Block block2 = new Block();
			block2.AddILRange(block);
			block2.Instructions.AddRange(block.Instructions);
			BlockContainer blockContainer = new BlockContainer();
			blockContainer.Blocks.Add(block2);
			blockContainer.AddILRange(block2);
			stateToContainer.Add(state, blockContainer);
			ILInstruction finallyBlock;
			if (decompiledFinallyMethods.TryGetValue(method, out (int?, ILFunction) value2))
			{
				finallyBlock = value2.Item2.Body;
				ILVariable[] input = Enumerable.ToArray<ILVariable>((IEnumerable<ILVariable>)value2.Item2.Variables);
				value2.Item2.Variables.Clear();
				iteratorFunction.Variables.AddRange(input);
			}
			else
			{
				finallyBlock = new InvalidBranch("Missing decompiledFinallyMethod");
			}
			block.Instructions.Clear();
			block.Instructions.Add(new TryFinally(blockContainer, finallyBlock).WithILRange(blockContainer));
		}
		IMethod FindFinallyMethod(int state)
		{
			IMethod method = null;
			foreach (var (method3, longSet2) in finallyMethodToStateRange)
			{
				if (longSet2.Contains(state))
				{
					if (method == null)
					{
						method = method3;
					}
					else
					{
						Debug.Fail("Ambiguous finally method for state " + state);
					}
				}
			}
			return method;
		}
	}

	private int? GetNewState(Block block)
	{
		if (block.Instructions[0].MatchStFld(out var target, out var field, out var value) && target.MatchLdThis() && field.MemberDefinition.Equals(stateField) && value.MatchLdcI4(out var value2))
		{
			return value2;
		}
		if (block.Instructions[0] is Call call && call.Arguments.Count == 1 && call.Arguments[0].MatchLdThis() && decompiledFinallyMethods.TryGetValue((IMethod)call.Method.MemberDefinition, out (int?, ILFunction) value3))
		{
			return value3.Item1;
		}
		return null;
	}

	private void CleanSkipFinallyBodies(ILFunction function)
	{
		if (skipFinallyBodies == null)
		{
			return;
		}
		context.StepStartGroup("CleanSkipFinallyBodies", function);
		Block bodyEntryPoint = AsyncAwaitDecompiler.GetBodyEntryPoint(function.Body as BlockContainer);
		if (skipFinallyBodies.StoreInstructions.Count != 0 || skipFinallyBodies.AddressCount != 0)
		{
			return;
		}
		foreach (TryFinally item in Enumerable.OfType<TryFinally>((IEnumerable)function.Descendants))
		{
			bodyEntryPoint = AsyncAwaitDecompiler.GetBodyEntryPoint(item.FinallyBlock as BlockContainer);
			if (bodyEntryPoint?.Instructions[0] is IfInstruction ifInstruction && ifInstruction.Condition.MatchLogicNot(out var arg) && arg.MatchLdLoc(skipFinallyBodies))
			{
				context.Step("Remove if (skipFinallyBodies) from try-finally", item);
				bodyEntryPoint.Instructions[0] = ifInstruction.TrueInst;
				bodyEntryPoint.Instructions.RemoveRange(1, checked(bodyEntryPoint.Instructions.Count - 1));
			}
		}
		context.StepEndGroup(keepIfEmpty: true);
	}
}
