#define DEBUG
#define STEP
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using DecompTools.Decompiler.CSharp;
using DecompTools.Decompiler.DebugInfo;
using DecompTools.Decompiler.IL.Transforms;
using DecompTools.Decompiler.Metadata;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.IL.ControlFlow;

internal class AsyncAwaitDecompiler : IILTransform
{
	private enum AsyncMethodType
	{
		Void,
		Task,
		TaskOfT
	}

	private ILTransformContext context;

	private IType taskType;

	private IType underlyingReturnType;

	private AsyncMethodType methodType;

	private ITypeDefinition stateMachineType;

	private ITypeDefinition builderType;

	private IField builderField;

	private IField stateField;

	private int initialState;

	private Dictionary<IField, ILVariable> fieldToParameterMap = new Dictionary<IField, ILVariable>();

	private Dictionary<ILVariable, ILVariable> cachedFieldToParameterMap = new Dictionary<ILVariable, ILVariable>();

	private ILFunction moveNextFunction;

	private ILVariable cachedStateVar;

	private TryCatch mainTryCatch;

	private Block setResultAndExitBlock;

	private int finalState;

	private ILVariable resultVar;

	private ILVariable doFinallyBodies;

	private int smallestAwaiterVarIndex;

	private HashSet<Leave> moveNextLeaves = new HashSet<Leave>();

	private Dictionary<Block, (ILVariable awaiterVar, IField awaiterField)> awaitBlocks = new Dictionary<Block, (ILVariable, IField)>();

	private int catchHandlerOffset;

	private List<AsyncDebugInfo.Await> awaitDebugInfos = new List<AsyncDebugInfo.Await>();

	public static bool IsCompilerGeneratedStateMachine(TypeDefinitionHandle type, MetadataReader metadata)
	{
		if (!type.IsNil)
		{
			TypeDefinition typeDefinition2;
			TypeDefinition typeDefinition = (typeDefinition2 = metadata.GetTypeDefinition(type));
			if (!typeDefinition.GetDeclaringType().IsNil)
			{
				if (!type.IsCompilerGenerated(metadata) && !typeDefinition2.GetDeclaringType().IsCompilerGenerated(metadata))
				{
					return false;
				}
				foreach (InterfaceImplementationHandle interfaceImplementation in typeDefinition2.GetInterfaceImplementations())
				{
					FullTypeName fullTypeName = metadata.GetInterfaceImplementation(interfaceImplementation).Interface.GetFullTypeName(metadata);
					if (!fullTypeName.IsNested && fullTypeName.TopLevelTypeName.Namespace == "System.Runtime.CompilerServices" && fullTypeName.TopLevelTypeName.Name == "IAsyncStateMachine")
					{
						return true;
					}
				}
				return false;
			}
		}
		return false;
	}

	public static bool IsCompilerGeneratedMainMethod(PEFile module, MethodDefinitionHandle method)
	{
		MetadataReader metadata = module.Metadata;
		MethodDefinition methodDefinition = metadata.GetMethodDefinition(method);
		MethodDefinitionHandle methodDefinitionHandle = MetadataTokens.MethodDefinitionHandle(module.Reader.PEHeaders.CorHeader.EntryPointTokenOrRelativeVirtualAddress);
		return method == methodDefinitionHandle && metadata.GetString(methodDefinition.Name).Equals("<Main>", StringComparison.Ordinal);
	}

	public void Run(ILFunction function, ILTransformContext context)
	{
		if (!context.Settings.AsyncAwait)
		{
			return;
		}
		this.context = context;
		fieldToParameterMap.Clear();
		cachedFieldToParameterMap.Clear();
		awaitBlocks.Clear();
		awaitDebugInfos.Clear();
		moveNextLeaves.Clear();
		if (MatchTaskCreationPattern(function))
		{
			try
			{
				AnalyzeMoveNext();
				ValidateCatchBlock();
			}
			catch (SymbolicAnalysisFailedException)
			{
				return;
			}
			InlineBodyOfMoveNext(function);
			function.CheckInvariant(ILPhase.InAsyncAwait);
			CleanUpBodyOfMoveNext(function);
			function.CheckInvariant(ILPhase.InAsyncAwait);
			AnalyzeStateMachine(function);
			DetectAwaitPattern(function);
			CleanDoFinallyBodies(function);
			context.Step("Translate fields to local accesses", function);
			MarkGeneratedVariables(function);
			YieldReturnDecompiler.TranslateFieldsToLocalAccess(function, function, fieldToParameterMap);
			TranslateCachedFieldsToLocals();
			FinalizeInlineMoveNext(function);
			((BlockContainer)function.Body).ExpectedResultType = underlyingReturnType.GetStackType();
			function.RunTransforms(CSharpDecompiler.EarlyILTransforms(), context);
			AwaitInCatchTransform.Run(function, context);
			AwaitInFinallyTransform.Run(function, context);
			awaitDebugInfos.SortBy((AsyncDebugInfo.Await row) => row.YieldOffset);
			function.AsyncDebugInfo = new AsyncDebugInfo(catchHandlerOffset, awaitDebugInfos.ToImmutableArray());
		}
	}

	private void CleanUpBodyOfMoveNext(ILFunction function)
	{
		context.StepStartGroup("CleanUpBodyOfMoveNext", function);
		foreach (StLoc item in Enumerable.ToList<StLoc>(Enumerable.Where<StLoc>(Enumerable.OfType<StLoc>((IEnumerable)function.Descendants), (Func<StLoc, bool>)((StLoc s) => s.Variable.Kind == VariableKind.StackSlot && s.Variable.IsSingleDefinition && s.Value is LdLoca))))
		{
			CopyPropagation.Propagate(item, context);
		}
		foreach (StObj item2 in Enumerable.OfType<StObj>((IEnumerable)function.Descendants))
		{
			EarlyExpressionTransforms.StObjToStLoc(item2, context);
		}
		foreach (StLoc item3 in Enumerable.ToList<StLoc>(Enumerable.Where<StLoc>(Enumerable.OfType<StLoc>((IEnumerable)function.Descendants), (Func<StLoc, bool>)((StLoc s) => s.Variable.IsSingleDefinition && s.Value.MatchLdThis()))))
		{
			CopyPropagation.Propagate(item3, context);
		}
		new RemoveDeadVariableInit().Run(function, context);
		foreach (Block item4 in Enumerable.OfType<Block>((IEnumerable)function.Descendants))
		{
			ILInlining.InlineAllInBlock(function, item4, context);
		}
		context.StepEndGroup();
	}

	private bool MatchTaskCreationPattern(ILFunction function)
	{
		if (!(function.Body is BlockContainer blockContainer))
		{
			return false;
		}
		if (blockContainer.Blocks.Count != 1)
		{
			return false;
		}
		InstructionCollection<ILInstruction> instructions = blockContainer.EntryPoint.Instructions;
		if (instructions.Count < 5)
		{
			return false;
		}
		checked
		{
			if (!(instructions[instructions.Count - 2] is Call call))
			{
				return false;
			}
			if (call.Method.Name != "Start")
			{
				return false;
			}
			taskType = function.Method.ReturnType;
			builderType = call.Method.DeclaringTypeDefinition;
			if (taskType.IsKnownType(KnownTypeCode.Void))
			{
				methodType = AsyncMethodType.Void;
				underlyingReturnType = taskType;
				if (builderType?.FullTypeName != new TopLevelTypeName("System.Runtime.CompilerServices", "AsyncVoidMethodBuilder"))
				{
					return false;
				}
			}
			else if (taskType.IsKnownType(KnownTypeCode.Task))
			{
				methodType = AsyncMethodType.Task;
				underlyingReturnType = context.TypeSystem.FindType(KnownTypeCode.Void);
				if (builderType?.FullTypeName != new TopLevelTypeName("System.Runtime.CompilerServices", "AsyncTaskMethodBuilder"))
				{
					return false;
				}
			}
			else
			{
				if (!taskType.IsKnownType(KnownTypeCode.TaskOfT))
				{
					return false;
				}
				methodType = AsyncMethodType.TaskOfT;
				underlyingReturnType = TaskType.UnpackTask(context.TypeSystem, taskType);
				if (builderType?.FullTypeName != new TopLevelTypeName("System.Runtime.CompilerServices", "AsyncTaskMethodBuilder", 1))
				{
					return false;
				}
			}
			if (call.Arguments.Count != 2)
			{
				return false;
			}
			if (!call.Arguments[0].MatchLdLocRef(out var variable))
			{
				return false;
			}
			if (!call.Arguments[1].MatchLdLoca(out var variable2))
			{
				return false;
			}
			stateMachineType = variable2.Type.GetDefinition();
			if (stateMachineType == null)
			{
				return false;
			}
			if (!instructions[instructions.Count - 3].MatchStLoc(variable, out var value))
			{
				return false;
			}
			if (!value.MatchLdFld(out var target, out builderField))
			{
				return false;
			}
			builderField = (IField)builderField.MemberDefinition;
			if (!target.MatchLdLocRef(variable2) && !target.MatchLdLoc(variable2))
			{
				return false;
			}
			if (methodType == AsyncMethodType.Void)
			{
				if (!instructions.Last().MatchLeave(blockContainer))
				{
					return false;
				}
			}
			else
			{
				if (!instructions.Last().MatchReturn(out var value2))
				{
					return false;
				}
				if (!MatchCall(value2, "get_Task", out var args) || args.Count != 1)
				{
					return false;
				}
				ILInstruction target2;
				IField field;
				if (builderType.IsReferenceType == true)
				{
					if (!args[0].MatchLdFld(out target2, out field))
					{
						return false;
					}
				}
				else if (!args[0].MatchLdFlda(out target2, out field))
				{
					return false;
				}
				if (field.MemberDefinition != builderField)
				{
					return false;
				}
				if (!target2.MatchLdLocRef(variable2))
				{
					return false;
				}
			}
			if (!MatchStFld(instructions[instructions.Count - 4], variable2, out stateField, out var value3))
			{
				return false;
			}
			if (!value3.MatchLdcI4(out initialState))
			{
				return false;
			}
			if (initialState != -1)
			{
				return false;
			}
			if (!MatchStFld(instructions[instructions.Count - 5], variable2, out var field2, out var value4))
			{
				return false;
			}
			if (field2 != builderField)
			{
				return false;
			}
			if (!(value4 is Call call2))
			{
				return false;
			}
			if (call2.Method.Name != "Create" || call2.Arguments.Count != 0)
			{
				return false;
			}
			int i = 0;
			if (stateMachineType.Kind == TypeKind.Class)
			{
				if (!instructions[i].MatchStLoc(variable2, out var value5))
				{
					return false;
				}
				if (!(value5 is NewObj newObj) || newObj.Arguments.Count != 0 || newObj.Method.DeclaringTypeDefinition != stateMachineType)
				{
					return false;
				}
				i++;
			}
			for (; i < instructions.Count - 5; i++)
			{
				if (!MatchStFld(instructions[i], variable2, out var field3, out var value6))
				{
					return false;
				}
				if (!value6.MatchLdLoc(out var variable3))
				{
					return false;
				}
				if (variable3.Kind != VariableKind.Parameter)
				{
					return false;
				}
				fieldToParameterMap[field3] = variable3;
			}
			return true;
		}
	}

	private static bool MatchCall(ILInstruction inst, string name, out InstructionCollection<ILInstruction> args)
	{
		if (inst is CallInstruction callInstruction && (callInstruction.OpCode == OpCode.Call || callInstruction.OpCode == OpCode.CallVirt) && callInstruction.Method.Name == name && !callInstruction.Method.IsStatic)
		{
			args = callInstruction.Arguments;
			return args.Count > 0;
		}
		args = null;
		return false;
	}

	private static bool MatchStFld(ILInstruction stfld, ILVariable stateMachineVar, out IField field, out ILInstruction value)
	{
		if (!stfld.MatchStFld(out var target, out field, out value))
		{
			return false;
		}
		field = field.MemberDefinition as IField;
		return field != null && target.MatchLdLocRef(stateMachineVar);
	}

	private void AnalyzeMoveNext()
	{
		if (stateMachineType.MetadataToken.IsNil)
		{
			throw new SymbolicAnalysisFailedException();
		}
		MetadataReader metadata = context.PEFile.Metadata;
		MethodDefinitionHandle method = Enumerable.FirstOrDefault<MethodDefinitionHandle>((IEnumerable<MethodDefinitionHandle>)metadata.GetTypeDefinition((TypeDefinitionHandle)stateMachineType.MetadataToken).GetMethods(), (Func<MethodDefinitionHandle, bool>)((MethodDefinitionHandle f) => metadata.GetString(metadata.GetMethodDefinition(f).Name) == "MoveNext"));
		bool flag = false;
		moveNextFunction = YieldReturnDecompiler.CreateILAst(method, context);
		if (!(moveNextFunction.Body is BlockContainer blockContainer))
		{
			throw new SymbolicAnalysisFailedException();
		}
		if (blockContainer.Blocks.Count != 2)
		{
			throw new SymbolicAnalysisFailedException();
		}
		if (blockContainer.EntryPoint.IncomingEdgeCount != 1)
		{
			throw new SymbolicAnalysisFailedException();
		}
		int num = 0;
		checked
		{
			if (blockContainer.EntryPoint.Instructions[0].MatchStLoc(out cachedStateVar, out var value))
			{
				if (!value.MatchLdFld(out var target, out var field))
				{
					throw new SymbolicAnalysisFailedException();
				}
				if (!target.MatchLdThis())
				{
					throw new SymbolicAnalysisFailedException();
				}
				if (field.MemberDefinition != stateField)
				{
					throw new SymbolicAnalysisFailedException();
				}
				num++;
			}
			for (; blockContainer.EntryPoint.Instructions[num] is StLoc stLoc; num++)
			{
				if (!stLoc.Variable.IsSingleDefinition)
				{
					throw new SymbolicAnalysisFailedException();
				}
				if (!stLoc.Value.MatchLdFld(out var target2, out var field2))
				{
					throw new SymbolicAnalysisFailedException();
				}
				if (!target2.MatchLdThis())
				{
					throw new SymbolicAnalysisFailedException();
				}
				if (!fieldToParameterMap.TryGetValue((IField)field2.MemberDefinition, out var value2))
				{
					throw new SymbolicAnalysisFailedException();
				}
				cachedFieldToParameterMap[stLoc.Variable] = value2;
			}
			mainTryCatch = blockContainer.EntryPoint.Instructions[num] as TryCatch;
			if (mainTryCatch == null)
			{
				throw new SymbolicAnalysisFailedException();
			}
			if (((BlockContainer)mainTryCatch.TryBlock).EntryPoint.Instructions[0] is StLoc stLoc2 && stLoc2.Variable.Kind == VariableKind.Local && stLoc2.Variable.Type.IsKnownType(KnownTypeCode.Boolean) && stLoc2.Value.MatchLdcI4(1))
			{
				doFinallyBodies = stLoc2.Variable;
			}
			setResultAndExitBlock = blockContainer.Blocks[1];
			if (setResultAndExitBlock.Instructions.Count != 3)
			{
				throw new SymbolicAnalysisFailedException();
			}
			if (!MatchStateAssignment(setResultAndExitBlock.Instructions[0], out finalState))
			{
				throw new SymbolicAnalysisFailedException();
			}
			if (!MatchCall(setResultAndExitBlock.Instructions[1], "SetResult", out var args))
			{
				throw new SymbolicAnalysisFailedException();
			}
			if (!IsBuilderFieldOnThis(args[0]))
			{
				throw new SymbolicAnalysisFailedException();
			}
			if (methodType == AsyncMethodType.TaskOfT)
			{
				if (args.Count != 2)
				{
					throw new SymbolicAnalysisFailedException();
				}
				if (!args[1].MatchLdLoc(out resultVar))
				{
					throw new SymbolicAnalysisFailedException();
				}
			}
			else
			{
				resultVar = null;
				if (args.Count != 1)
				{
					throw new SymbolicAnalysisFailedException();
				}
			}
			if (!setResultAndExitBlock.Instructions[2].MatchLeave(blockContainer))
			{
				throw new SymbolicAnalysisFailedException();
			}
		}
	}

	private void ValidateCatchBlock()
	{
		TryCatch tryCatch = mainTryCatch;
		if (tryCatch == null || tryCatch.Handlers.Count != 1)
		{
			throw new SymbolicAnalysisFailedException();
		}
		TryCatchHandler tryCatchHandler = mainTryCatch.Handlers[0];
		if (!tryCatchHandler.Variable.Type.IsKnownType(KnownTypeCode.Exception))
		{
			throw new SymbolicAnalysisFailedException();
		}
		if (!tryCatchHandler.Filter.MatchLdcI4(1))
		{
			throw new SymbolicAnalysisFailedException();
		}
		Block block = YieldReturnDecompiler.SingleBlock(tryCatchHandler.Body);
		catchHandlerOffset = block.StartILOffset;
		if (block == null || block.Instructions.Count != 4)
		{
			throw new SymbolicAnalysisFailedException();
		}
		if (!(block.Instructions[0] is StLoc stLoc))
		{
			throw new SymbolicAnalysisFailedException();
		}
		if (!stLoc.Value.MatchLdLoc(tryCatchHandler.Variable))
		{
			throw new SymbolicAnalysisFailedException();
		}
		if (!MatchStateAssignment(block.Instructions[1], out var newState) || newState != finalState)
		{
			throw new SymbolicAnalysisFailedException();
		}
		if (!MatchCall(block.Instructions[2], "SetException", out var args))
		{
			throw new SymbolicAnalysisFailedException();
		}
		if (args.Count != 2)
		{
			throw new SymbolicAnalysisFailedException();
		}
		if (!IsBuilderFieldOnThis(args[0]))
		{
			throw new SymbolicAnalysisFailedException();
		}
		if (!args[1].MatchLdLoc(stLoc.Variable))
		{
			throw new SymbolicAnalysisFailedException();
		}
		if (!block.Instructions[3].MatchLeave((BlockContainer)moveNextFunction.Body))
		{
			throw new SymbolicAnalysisFailedException();
		}
	}

	private bool IsBuilderFieldOnThis(ILInstruction inst)
	{
		ILInstruction target;
		IField field;
		if (builderType.IsReferenceType == true)
		{
			if (!inst.MatchLdFld(out target, out field))
			{
				return false;
			}
		}
		else if (!inst.MatchLdFlda(out target, out field))
		{
			return false;
		}
		return target.MatchLdThis() && field.MemberDefinition == builderField;
	}

	private bool MatchStateAssignment(ILInstruction inst, out int newState)
	{
		if (inst.MatchStFld(out var target, out var field, out var value) && target.MatchLdThis() && field.MemberDefinition == stateField && value.MatchLdcI4(out newState))
		{
			return true;
		}
		newState = 0;
		return false;
	}

	private void InlineBodyOfMoveNext(ILFunction function)
	{
		context.Step("Inline body of MoveNext()", function);
		function.Body = mainTryCatch.TryBlock;
		function.AsyncReturnType = underlyingReturnType;
		function.MoveNextMethod = moveNextFunction.Method;
		function.CodeSize = moveNextFunction.CodeSize;
		moveNextFunction.Variables.Clear();
		moveNextFunction.ReleaseRef();
		foreach (Branch item in Enumerable.OfType<Branch>((IEnumerable)function.Descendants))
		{
			if (item.TargetBlock == setResultAndExitBlock)
			{
				item.ReplaceWith(new Leave((BlockContainer)function.Body, (resultVar == null) ? null : new LdLoc(resultVar)).WithILRange(item));
			}
		}
		foreach (Leave item2 in Enumerable.OfType<Leave>((IEnumerable)function.Descendants))
		{
			if (item2.TargetContainer == moveNextFunction.Body)
			{
				item2.TargetContainer = (BlockContainer)function.Body;
				moveNextLeaves.Add(item2);
			}
		}
		function.Variables.AddRange(Enumerable.Distinct<ILVariable>(Enumerable.Select<IInstructionWithVariableOperand, ILVariable>(Enumerable.OfType<IInstructionWithVariableOperand>((IEnumerable)function.Descendants), (Func<IInstructionWithVariableOperand, ILVariable>)((IInstructionWithVariableOperand inst) => inst.Variable))));
		function.Variables.RemoveDead();
		function.Variables.AddRange(fieldToParameterMap.Values);
	}

	private void FinalizeInlineMoveNext(ILFunction function)
	{
		context.Step("FinalizeInlineMoveNext()", function);
		foreach (Leave item in Enumerable.OfType<Leave>((IEnumerable)function.Descendants))
		{
			if (moveNextLeaves.Contains(item))
			{
				item.ReplaceWith(new InvalidBranch
				{
					Message = "leave MoveNext - await not detected correctly"
				}.WithILRange(item));
			}
		}
		checked
		{
			foreach (Block item2 in Enumerable.OfType<Block>((IEnumerable)function.Descendants))
			{
				for (int num = item2.Instructions.Count - 1; num >= 0; num--)
				{
					if (item2.Instructions[num].MatchStLoc(out var variable, out var value) && variable.IsSingleDefinition && variable.LoadCount == 0 && value.MatchLdLoc(cachedStateVar))
					{
						item2.Instructions.RemoveAt(num);
					}
				}
			}
		}
	}

	private void AnalyzeStateMachine(ILFunction function)
	{
		context.Step("AnalyzeStateMachine()", function);
		smallestAwaiterVarIndex = int.MaxValue;
		foreach (BlockContainer item in Enumerable.OfType<BlockContainer>((IEnumerable)function.Descendants))
		{
			StateRangeAnalysis stateRangeAnalysis = new StateRangeAnalysis(StateRangeAnalysisMode.AsyncMoveNext, stateField, cachedStateVar);
			stateRangeAnalysis.CancellationToken = context.CancellationToken;
			stateRangeAnalysis.doFinallyBodies = doFinallyBodies;
			stateRangeAnalysis.AssignStateRanges(item, LongSet.Universe);
			LongDict<Block> blockStateSetMapping = stateRangeAnalysis.GetBlockStateSetMapping(item);
			foreach (Block block in item.Blocks)
			{
				context.CancellationToken.ThrowIfCancellationRequested();
				if (block.Instructions.Last() is Leave leave && moveNextLeaves.Contains(leave) && AnalyzeAwaitBlock(block, out var awaiter, out var awaiterField, out var state, out var yieldOffset))
				{
					block.Instructions.Add(new Await(new LdLoca(awaiter)));
					Block orDefault = blockStateSetMapping.GetOrDefault(state);
					if (orDefault != null)
					{
						awaitDebugInfos.Add(new AsyncDebugInfo.Await(yieldOffset, orDefault.StartILOffset));
						block.Instructions.Add(new Branch(orDefault));
					}
					else
					{
						block.Instructions.Add(new InvalidBranch("Could not find block for state " + state));
					}
					awaitBlocks.Add(block, (awaiter, awaiterField));
					if (awaiter.Index < smallestAwaiterVarIndex)
					{
						smallestAwaiterVarIndex = awaiter.Index.Value;
					}
				}
			}
			Block orDefault2 = blockStateSetMapping.GetOrDefault(initialState);
			if (orDefault2 != null)
			{
				item.Blocks.Insert(0, new Block
				{
					Instructions = { (ILInstruction)new Branch(orDefault2) }
				});
			}
			item.SortBlocks(deleteUnreachableBlocks: true);
		}
	}

	private bool AnalyzeAwaitBlock(Block block, out ILVariable awaiter, out IField awaiterField, out int state, out int yieldOffset)
	{
		awaiter = null;
		awaiterField = null;
		state = 0;
		yieldOffset = -1;
		checked
		{
			int num = block.Instructions.Count - 2;
			if (num >= 0 && doFinallyBodies != null && block.Instructions[num] is StLoc stLoc)
			{
				if (stLoc.Variable.Kind != VariableKind.Local || !stLoc.Variable.Type.IsKnownType(KnownTypeCode.Boolean) || stLoc.Variable.Index != doFinallyBodies.Index)
				{
					return false;
				}
				if (!stLoc.Value.MatchLdcI4(0))
				{
					return false;
				}
				num--;
			}
			if ((num < 0 || !MatchCall(block.Instructions[num], "AwaitUnsafeOnCompleted", out var args)) && (num < 0 || !MatchCall(block.Instructions[num], "AwaitOnCompleted", out args)))
			{
				return false;
			}
			if (args.Count != 3)
			{
				return false;
			}
			if (!IsBuilderFieldOnThis(args[0]))
			{
				return false;
			}
			if (!args[1].MatchLdLoca(out awaiter))
			{
				return false;
			}
			if (args[2].MatchLdThis())
			{
				num--;
			}
			else
			{
				if (!args[2].MatchLdLoca(out var variable))
				{
					return false;
				}
				if (num <= 0 || !block.Instructions[num - 1].MatchStLoc(variable, out var value))
				{
					return false;
				}
				if (!value.MatchLdThis())
				{
					return false;
				}
				num -= 2;
			}
			if (!block.Instructions[num].MatchStFld(out var target, out awaiterField, out var value2))
			{
				return false;
			}
			if (!target.MatchLdThis())
			{
				return false;
			}
			if (!value2.MatchLdLoc(awaiter))
			{
				return false;
			}
			num--;
			yieldOffset = block.Instructions[num].EndILOffset;
			if (!block.Instructions[num].MatchStFld(out target, out var field, out value2))
			{
				return false;
			}
			if (!StackSlotValue(target).MatchLdThis())
			{
				return false;
			}
			if (field.MemberDefinition != stateField)
			{
				return false;
			}
			if (!StackSlotValue(value2).MatchLdcI4(out state))
			{
				return false;
			}
			if (num > 0 && block.Instructions[num - 1] is StLoc stLoc2 && stLoc2.Variable.Kind == VariableKind.Local && stLoc2.Variable.Index == cachedStateVar.Index && StackSlotValue(stLoc2.Value).MatchLdcI4(state))
			{
				num--;
			}
			block.Instructions.RemoveRange(num, block.Instructions.Count - num);
			while (num > 0 && block.Instructions[num - 1] is StLoc stLoc3 && stLoc3.Variable.IsSingleDefinition && stLoc3.Variable.LoadCount == 0 && stLoc3.Variable.Kind == VariableKind.StackSlot && SemanticHelper.IsPure(stLoc3.Value.Flags))
			{
				num--;
			}
			block.Instructions.RemoveRange(num, block.Instructions.Count - num);
			return true;
		}
	}

	private static ILInstruction StackSlotValue(ILInstruction inst)
	{
		if (!inst.MatchLdLoc(out var variable) || variable.Kind != VariableKind.StackSlot || !variable.IsSingleDefinition || !(variable.StoreInstructions[0] is StLoc { Value: var value }))
		{
			return inst;
		}
		return value;
	}

	private void DetectAwaitPattern(ILFunction function)
	{
		context.StepStartGroup("DetectAwaitPattern", function);
		foreach (BlockContainer item in Enumerable.OfType<BlockContainer>((IEnumerable)function.Descendants))
		{
			foreach (Block block in item.Blocks)
			{
				context.CancellationToken.ThrowIfCancellationRequested();
				DetectAwaitPattern(block);
			}
			item.SortBlocks(deleteUnreachableBlocks: true);
		}
		context.StepEndGroup(keepIfEmpty: true);
	}

	private void DetectAwaitPattern(Block block)
	{
		checked
		{
			if (block.Instructions.Count < 3 || !(block.Instructions[block.Instructions.Count - 3] is StLoc { Variable: var variable, Value: CallInstruction value }) || !(value.Method.Name == "GetAwaiter") || (value.Method.IsStatic && !value.Method.IsExtensionMethod) || value.Arguments.Count != 1 || !block.Instructions[block.Instructions.Count - 2].MatchIfInstruction(out var condition, out var trueInst) || !MatchCall(condition, "get_IsCompleted", out var args) || args.Count != 1 || !args[0].MatchLdLocRef(variable) || !trueInst.MatchBranch(out var targetBlock) || !block.Instructions.Last().MatchBranch(out var targetBlock2) || !awaitBlocks.TryGetValue(targetBlock2, out (ILVariable, IField) value2) || value2.Item1 != variable || !CheckAwaitBlock(targetBlock2, out var resumeBlock, out var stackField) || !CheckResumeBlock(resumeBlock, variable, value2.Item2, targetBlock, stackField))
			{
				return;
			}
			CallInstruction callInstruction = ILInlining.FindFirstInlinedCall(targetBlock.Instructions[0]);
			if (callInstruction != null && MatchCall(callInstruction, "GetResult", out var args2) && args2.Count == 1 && args2[0].MatchLdLocRef(variable))
			{
				context.Step("Transform await pattern", block);
				block.Instructions.RemoveAt(block.Instructions.Count - 3);
				block.Instructions.RemoveAt(block.Instructions.Count - 2);
				((Branch)block.Instructions.Last()).TargetBlock = targetBlock;
				Await obj = new Await(Enumerable.Single<ILInstruction>((IEnumerable<ILInstruction>)value.Arguments));
				obj.GetResultMethod = callInstruction.Method;
				obj.GetAwaiterMethod = value.Method;
				callInstruction.ReplaceWith(obj);
				if (targetBlock.Instructions.ElementAtOrDefault(1) is StObj stObj && stObj.Target.MatchLdLoca(variable) && stObj.Value.OpCode == OpCode.DefaultValue)
				{
					targetBlock.Instructions.RemoveAt(1);
				}
			}
		}
	}

	private bool CheckAwaitBlock(Block block, out Block resumeBlock, out IField stackField)
	{
		resumeBlock = null;
		stackField = null;
		if (block.Instructions.Count < 2)
		{
			return false;
		}
		int num = 0;
		checked
		{
			if (block.Instructions[num] is StLoc stLoc && stLoc.Variable.IsSingleDefinition)
			{
				if (!block.Instructions[num + 1].MatchStFld(out var target, out stackField, out var _))
				{
					return false;
				}
				if (!target.MatchLdThis())
				{
					return false;
				}
				num += 2;
			}
			if (block.Instructions[num].OpCode != OpCode.Await)
			{
				return false;
			}
			return block.Instructions[num + 1].MatchBranch(out resumeBlock);
		}
	}

	private bool CheckResumeBlock(Block block, ILVariable awaiterVar, IField awaiterField, Block completedBlock, IField stackField)
	{
		int pos = 0;
		if (!RestoreStack(block, ref pos, stackField))
		{
			return false;
		}
		if (!block.Instructions[pos].MatchStLoc(awaiterVar, out var value))
		{
			return false;
		}
		if (!value.MatchLdFld(out var target, out var field))
		{
			return false;
		}
		if (!target.MatchLdThis())
		{
			return false;
		}
		if (!field.Equals(awaiterField))
		{
			return false;
		}
		checked
		{
			pos++;
			ILVariable variable;
			if (block.Instructions[pos].MatchStFld(out target, out field, out value) && target.MatchLdThis() && field.Equals(awaiterField) && value.OpCode == OpCode.DefaultValue)
			{
				pos++;
			}
			else if (block.Instructions[pos].MatchStLoc(out variable, out value) && value.OpCode == OpCode.DefaultValue && block.Instructions[pos + 1].MatchStFld(out target, out field, out value) && field.Equals(awaiterField) && value.MatchLdLoc(variable))
			{
				pos += 2;
			}
			ILVariable variable2 = null;
			if (block.Instructions[pos] is StLoc stLoc && stLoc.Value.MatchLdcI4(initialState) && stLoc.Variable.Kind == VariableKind.StackSlot)
			{
				variable2 = stLoc.Variable;
				pos++;
			}
			if (block.Instructions[pos] is StLoc stLoc2 && stLoc2.Variable.Kind == VariableKind.Local && stLoc2.Variable.Index == cachedStateVar?.Index && (stLoc2.Value.MatchLdLoc(variable2) || stLoc2.Value.MatchLdcI4(initialState)))
			{
				pos++;
			}
			if (block.Instructions[pos].MatchStFld(out target, out field, out value))
			{
				if (!target.MatchLdThis())
				{
					return false;
				}
				if (!field.MemberDefinition.Equals(stateField.MemberDefinition))
				{
					return false;
				}
				if (!value.MatchLdcI4(initialState) && !value.MatchLdLoc(variable2))
				{
					return false;
				}
				pos++;
				return block.Instructions[pos].MatchBranch(completedBlock);
			}
			return false;
		}
	}

	private bool RestoreStack(Block block, ref int pos, IField stackField)
	{
		if (stackField == null)
		{
			return true;
		}
		if (!(block.Instructions[pos] is StLoc stLoc))
		{
			return false;
		}
		if (!stLoc.Variable.IsSingleDefinition)
		{
			return false;
		}
		if (!(stLoc.Value is UnboxAny unboxAny))
		{
			return false;
		}
		if (!unboxAny.Argument.MatchLdFld(out var target, out var field))
		{
			return false;
		}
		if (!target.MatchLdThis())
		{
			return false;
		}
		if (!field.Equals(stackField))
		{
			return false;
		}
		checked
		{
			pos++;
			ILVariable variable;
			while (block.Instructions[pos].MatchStLoc(out variable) && variable.Kind == VariableKind.StackSlot)
			{
				pos++;
			}
			if (block.Instructions[pos].MatchStFld(out target, out field, out var value) && target.MatchLdThis() && field.Equals(stackField) && value.MatchLdNull())
			{
				pos++;
			}
			return true;
		}
	}

	private void MarkGeneratedVariables(ILFunction function)
	{
		foreach (ILVariable variable in function.Variables)
		{
			if (variable.Kind == VariableKind.Local && variable.Index >= smallestAwaiterVarIndex)
			{
				variable.Kind = VariableKind.StackSlot;
			}
		}
	}

	private void CleanDoFinallyBodies(ILFunction function)
	{
		if (doFinallyBodies == null)
		{
			return;
		}
		context.StepStartGroup("CleanDoFinallyBodies", function);
		Block bodyEntryPoint = GetBodyEntryPoint(function.Body as BlockContainer);
		if (bodyEntryPoint != null && bodyEntryPoint.Instructions[0].MatchStLoc(doFinallyBodies, out var value) && value.MatchLdcI4(1))
		{
			bodyEntryPoint.Instructions.RemoveAt(0);
		}
		if (doFinallyBodies.StoreInstructions.Count != 0 || doFinallyBodies.AddressCount != 0)
		{
			context.Step("Re-introduce misdetected doFinallyBodies", function);
			((BlockContainer)function.Body).EntryPoint.Instructions.Insert(0, new StLoc(doFinallyBodies, new LdcI4(1)));
			return;
		}
		foreach (TryFinally item in Enumerable.OfType<TryFinally>((IEnumerable)function.Descendants))
		{
			bodyEntryPoint = GetBodyEntryPoint(item.FinallyBlock as BlockContainer);
			if (bodyEntryPoint?.Instructions[0] is IfInstruction ifInstruction && ifInstruction.Condition.MatchLogicNot(out var arg) && arg.MatchLdLoc(doFinallyBodies))
			{
				context.Step("Remove if(doFinallyBodies) from try-finally", item);
				bodyEntryPoint.Instructions.RemoveAt(0);
			}
		}
		LdLoc[] array = Enumerable.ToArray<LdLoc>((IEnumerable<LdLoc>)doFinallyBodies.LoadInstructions);
		foreach (LdLoc ldLoc in array)
		{
			ldLoc.ReplaceWith(new LdcI4(1).WithILRange(ldLoc));
		}
		context.StepEndGroup(keepIfEmpty: true);
	}

	internal static Block GetBodyEntryPoint(BlockContainer body)
	{
		if (body == null)
		{
			return null;
		}
		Block block = body.EntryPoint;
		Block targetBlock;
		while (block.Instructions[0].MatchBranch(out targetBlock) && targetBlock.IncomingEdgeCount == 1 && targetBlock.Parent == body)
		{
			block = targetBlock;
		}
		return block;
	}

	private void TranslateCachedFieldsToLocals()
	{
		foreach (var (iLVariable3, variable) in cachedFieldToParameterMap)
		{
			Debug.Assert(iLVariable3.StoreCount <= 1);
			LdLoc[] array = Enumerable.ToArray<LdLoc>((IEnumerable<LdLoc>)iLVariable3.LoadInstructions);
			foreach (LdLoc ldLoc in array)
			{
				ldLoc.Variable = variable;
			}
			LdLoca[] array2 = Enumerable.ToArray<LdLoca>((IEnumerable<LdLoca>)iLVariable3.AddressInstructions);
			foreach (LdLoca ldLoca in array2)
			{
				ldLoca.Variable = variable;
			}
		}
	}
}
