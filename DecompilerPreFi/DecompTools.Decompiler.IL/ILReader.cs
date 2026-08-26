#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using DecompTools.Decompiler.DebugInfo;
using DecompTools.Decompiler.Disassembler;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.TypeSystem.Implementation;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.IL;

public class ILReader
{
	private class CollectStackVariablesVisitor : ILVisitor<ILInstruction>
	{
		private readonly UnionFind<ILVariable> unionFind;

		internal readonly HashSet<ILVariable> variables = new HashSet<ILVariable>();

		public CollectStackVariablesVisitor(UnionFind<ILVariable> unionFind)
		{
			Debug.Assert(unionFind != null);
			this.unionFind = unionFind;
		}

		protected override ILInstruction Default(ILInstruction inst)
		{
			foreach (ILInstruction child in inst.Children)
			{
				ILInstruction iLInstruction = child.AcceptVisitor(this);
				if (iLInstruction != child)
				{
					child.ReplaceWith(iLInstruction);
				}
			}
			return inst;
		}

		protected internal override ILInstruction VisitLdLoc(LdLoc inst)
		{
			base.VisitLdLoc(inst);
			if (inst.Variable.Kind == VariableKind.StackSlot)
			{
				ILVariable iLVariable = unionFind.Find(inst.Variable);
				if (variables.Add(iLVariable))
				{
					iLVariable.Name = "S_" + checked(variables.Count - 1);
				}
				return new LdLoc(iLVariable).WithILRange(inst);
			}
			return inst;
		}

		protected internal override ILInstruction VisitStLoc(StLoc inst)
		{
			base.VisitStLoc(inst);
			if (inst.Variable.Kind == VariableKind.StackSlot)
			{
				ILVariable iLVariable = unionFind.Find(inst.Variable);
				if (variables.Add(iLVariable))
				{
					iLVariable.Name = "S_" + checked(variables.Count - 1);
				}
				return new StLoc(iLVariable, inst.Value).WithILRange(inst);
			}
			return inst;
		}
	}

	private readonly ICompilation compilation;

	private readonly MetadataModule module;

	private readonly MetadataReader metadata;

	private GenericContext genericContext;

	private IMethod method;

	private MethodBodyBlock body;

	private StackType methodReturnStackType;

	private BlobReader reader;

	private ImmutableStack<ILVariable> currentStack;

	private ILVariable[] parameterVariables;

	private ILVariable[] localVariables;

	private BitArray isBranchTarget;

	private BlockContainer mainContainer;

	private List<ILInstruction> instructionBuilder;

	private int currentInstructionStart;

	private Dictionary<int, ImmutableStack<ILVariable>> stackByOffset;

	private Dictionary<ExceptionRegion, ILVariable> variableByExceptionHandler;

	private UnionFind<ILVariable> unionFind;

	private List<(ILVariable, ILVariable)> stackMismatchPairs;

	private IEnumerable<ILVariable> stackVariables;

	private IType constrainedPrefix;

	public bool UseDebugSymbols { get; set; }

	public IDebugInfoProvider DebugInfo { get; set; }

	public List<string> Warnings { get; } = new List<string>();

	public ILReader(MetadataModule module)
	{
		if (module == null)
		{
			throw new ArgumentNullException("module");
		}
		this.module = module;
		compilation = module.Compilation;
		metadata = module.metadata;
	}

	private void Init(MethodDefinitionHandle methodDefinitionHandle, MethodBodyBlock body, GenericContext genericContext)
	{
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		if (body == null)
		{
			throw new ArgumentNullException("body");
		}
		if (methodDefinitionHandle.IsNil)
		{
			throw new ArgumentException("methodDefinitionHandle.IsNil");
		}
		method = module.GetDefinition(methodDefinitionHandle);
		if (genericContext.ClassTypeParameters == null && genericContext.MethodTypeParameters == null)
		{
			genericContext = new GenericContext(method);
		}
		else
		{
			method = method.Specialize(genericContext.ToSubstitution());
		}
		this.genericContext = genericContext;
		MethodDefinition methodDefinition = metadata.GetMethodDefinition(methodDefinitionHandle);
		this.body = body;
		reader = body.GetILReader();
		currentStack = ImmutableStack<ILVariable>.Empty;
		unionFind = new UnionFind<ILVariable>();
		stackMismatchPairs = new List<(ILVariable, ILVariable)>();
		methodReturnStackType = method.ReturnType.GetStackType();
		InitParameterVariables();
		localVariables = InitLocalVariables();
		if (body.LocalVariablesInitialized)
		{
			ILVariable[] array = localVariables;
			foreach (ILVariable iLVariable in array)
			{
				iLVariable.HasInitialValue = true;
			}
		}
		mainContainer = new BlockContainer(ContainerKind.Normal, methodReturnStackType);
		instructionBuilder = new List<ILInstruction>();
		isBranchTarget = new BitArray(reader.Length);
		stackByOffset = new Dictionary<int, ImmutableStack<ILVariable>>();
		variableByExceptionHandler = new Dictionary<ExceptionRegion, ILVariable>();
	}

	private EntityHandle ReadAndDecodeMetadataToken()
	{
		int num = reader.ReadInt32();
		if (num < 0)
		{
			throw new BadImageFormatException("Invalid metadata token");
		}
		return MetadataTokens.EntityHandle(num);
	}

	private IType ReadAndDecodeTypeReference()
	{
		EntityHandle typeRefDefSpec = ReadAndDecodeMetadataToken();
		return module.ResolveType(typeRefDefSpec, genericContext);
	}

	private IMethod ReadAndDecodeMethodReference()
	{
		EntityHandle methodReference = ReadAndDecodeMetadataToken();
		return module.ResolveMethod(methodReference, genericContext);
	}

	private IField ReadAndDecodeFieldReference()
	{
		EntityHandle entityHandle = ReadAndDecodeMetadataToken();
		if (!(module.ResolveEntity(entityHandle, genericContext) is IField result))
		{
			throw new BadImageFormatException("Invalid field token");
		}
		return result;
	}

	private ILVariable[] InitLocalVariables()
	{
		if (body.LocalSignature.IsNil)
		{
			return Empty<ILVariable>.Array;
		}
		ImmutableArray<IType> immutableArray;
		try
		{
			immutableArray = module.DecodeLocalSignature(body.LocalSignature, genericContext);
		}
		catch (BadImageFormatException ex)
		{
			Warnings.Add("Error decoding local variables: " + ex.Message);
			immutableArray = ImmutableArray<IType>.Empty;
		}
		ILVariable[] array = new ILVariable[immutableArray.Length];
		foreach (var (num, type) in immutableArray.WithIndex())
		{
			array[num] = CreateILVariable(num, type);
		}
		return array;
	}

	private void InitParameterVariables()
	{
		int num = method.Parameters.Count;
		checked
		{
			if (!method.IsStatic)
			{
				num++;
			}
			if (Enumerable.LastOrDefault<IParameter>((IEnumerable<IParameter>)method.Parameters)?.Type == SpecialType.ArgList)
			{
				num--;
			}
			parameterVariables = new ILVariable[num];
			int i = 0;
			int num2 = 0;
			if (!method.IsStatic)
			{
				num2 = 1;
				IType type = method.DeclaringType;
				if (type.IsUnbound())
				{
					type = new ParameterizedType(type, type.TypeParameters);
				}
				parameterVariables[i++] = CreateILVariable(-1, type, "this");
			}
			for (; i < parameterVariables.Length; i++)
			{
				IType type2 = method.Parameters[i - num2].Type;
				string name = method.Parameters[i - num2].Name;
				parameterVariables[i] = CreateILVariable(i - num2, type2, name);
			}
			Debug.Assert(i == parameterVariables.Length);
		}
	}

	private ILVariable CreateILVariable(int index, IType type)
	{
		VariableKind kind;
		if (type.SkipModifiers() is PinnedType pinnedType)
		{
			kind = VariableKind.PinnedLocal;
			type = pinnedType.ElementType;
		}
		else
		{
			kind = VariableKind.Local;
		}
		ILVariable iLVariable = new ILVariable(kind, type, index);
		if (!UseDebugSymbols || DebugInfo == null || !DebugInfo.TryGetName((MethodDefinitionHandle)method.MetadataToken, index, out var name))
		{
			iLVariable.Name = "V_" + index;
			iLVariable.HasGeneratedName = true;
		}
		else if (string.IsNullOrWhiteSpace(name))
		{
			iLVariable.Name = "V_" + index;
			iLVariable.HasGeneratedName = true;
		}
		else
		{
			iLVariable.Name = name;
		}
		return iLVariable;
	}

	private ILVariable CreateILVariable(int index, IType parameterType, string name)
	{
		Debug.Assert(!parameterType.IsUnbound());
		ITypeDefinition definition = parameterType.GetDefinition();
		if (definition != null && index < 0 && definition.IsReferenceType == false)
		{
			parameterType = new ByReferenceType(parameterType);
		}
		ILVariable iLVariable = new ILVariable(VariableKind.Parameter, parameterType, index);
		Debug.Assert(iLVariable.StoreCount == 1);
		if (index < 0)
		{
			iLVariable.Name = "this";
		}
		else if (string.IsNullOrEmpty(name))
		{
			iLVariable.Name = "P_" + index;
		}
		else
		{
			iLVariable.Name = name;
		}
		return iLVariable;
	}

	private void Warn(string message)
	{
		Warnings.Add($"IL_{currentInstructionStart:x4}: {message}");
	}

	private ImmutableStack<ILVariable> MergeStacks(ImmutableStack<ILVariable> a, ImmutableStack<ILVariable> b)
	{
		if (CheckStackCompatibleWithoutAdjustments(a, b))
		{
			ImmutableStack<ILVariable> result = a;
			while (!a.IsEmpty && !b.IsEmpty)
			{
				Debug.Assert(a.Peek().StackType == b.Peek().StackType);
				unionFind.Merge(a.Peek(), b.Peek());
				a = a.Pop();
				b = b.Pop();
			}
			return result;
		}
		if (Enumerable.Count<ILVariable>((IEnumerable<ILVariable>)a) != Enumerable.Count<ILVariable>((IEnumerable<ILVariable>)b))
		{
			Warn("Incompatible stack heights: " + Enumerable.Count<ILVariable>((IEnumerable<ILVariable>)a) + " vs " + Enumerable.Count<ILVariable>((IEnumerable<ILVariable>)b));
			return a;
		}
		List<ILVariable> list = new List<ILVariable>();
		while (!a.IsEmpty && !b.IsEmpty)
		{
			ILVariable iLVariable = a.Peek();
			ILVariable iLVariable2 = b.Peek();
			if (iLVariable.StackType == iLVariable2.StackType)
			{
				unionFind.Merge(iLVariable, iLVariable2);
				list.Add(iLVariable);
			}
			else
			{
				if (!IsValidTypeStackTypeMerge(iLVariable.StackType, iLVariable2.StackType))
				{
					Warn(string.Concat("Incompatible stack types: ", iLVariable.StackType, " vs ", iLVariable2.StackType));
				}
				if ((int)iLVariable.StackType > (int)iLVariable2.StackType)
				{
					list.Add(iLVariable);
					stackMismatchPairs.Add((iLVariable2, iLVariable));
				}
				else
				{
					list.Add(iLVariable2);
					stackMismatchPairs.Add((iLVariable, iLVariable2));
				}
			}
			a = a.Pop();
			b = b.Pop();
		}
		list.Reverse();
		return ImmutableStack.CreateRange(list);
	}

	private static bool CheckStackCompatibleWithoutAdjustments(ImmutableStack<ILVariable> a, ImmutableStack<ILVariable> b)
	{
		while (!a.IsEmpty && !b.IsEmpty)
		{
			if (a.Peek().StackType != b.Peek().StackType)
			{
				return false;
			}
			a = a.Pop();
			b = b.Pop();
		}
		return a.IsEmpty && b.IsEmpty;
	}

	private bool IsValidTypeStackTypeMerge(StackType stackType1, StackType stackType2)
	{
		if (stackType1 == StackType.I && stackType2 == StackType.I4)
		{
			return true;
		}
		if (stackType1 == StackType.I4 && stackType2 == StackType.I)
		{
			return true;
		}
		if (stackType1 == StackType.F4 && stackType2 == StackType.F8)
		{
			return true;
		}
		if (stackType1 == StackType.F8 && stackType2 == StackType.F4)
		{
			return true;
		}
		return stackType1 == StackType.Unknown || stackType2 == StackType.Unknown;
	}

	private void StoreStackForOffset(int offset, ref ImmutableStack<ILVariable> stack)
	{
		if (stackByOffset.TryGetValue(offset, out var value))
		{
			stack = MergeStacks(value, stack);
			if (stack != value)
			{
				stackByOffset[offset] = stack;
			}
		}
		else
		{
			stackByOffset.Add(offset, stack);
		}
	}

	private void ReadInstructions(CancellationToken cancellationToken)
	{
		foreach (ExceptionRegion exceptionRegion in body.ExceptionRegions)
		{
			ImmutableStack<ILVariable> immutableStack = null;
			if (exceptionRegion.Kind == ExceptionRegionKind.Catch)
			{
				IType type = module.ResolveType(exceptionRegion.CatchType, genericContext);
				ILVariable iLVariable = new ILVariable(VariableKind.ExceptionStackSlot, type, exceptionRegion.HandlerOffset)
				{
					Name = "E_" + exceptionRegion.HandlerOffset,
					HasGeneratedName = true
				};
				variableByExceptionHandler.Add(exceptionRegion, iLVariable);
				immutableStack = ImmutableStack.Create(iLVariable);
			}
			else if (exceptionRegion.Kind == ExceptionRegionKind.Filter)
			{
				ILVariable iLVariable2 = new ILVariable(VariableKind.ExceptionStackSlot, compilation.FindType(KnownTypeCode.Object), exceptionRegion.HandlerOffset)
				{
					Name = "E_" + exceptionRegion.HandlerOffset,
					HasGeneratedName = true
				};
				variableByExceptionHandler.Add(exceptionRegion, iLVariable2);
				immutableStack = ImmutableStack.Create(iLVariable2);
			}
			else
			{
				immutableStack = ImmutableStack<ILVariable>.Empty;
			}
			if (exceptionRegion.FilterOffset != -1)
			{
				isBranchTarget[exceptionRegion.FilterOffset] = true;
				StoreStackForOffset(exceptionRegion.FilterOffset, ref immutableStack);
			}
			if (exceptionRegion.HandlerOffset != -1)
			{
				isBranchTarget[exceptionRegion.HandlerOffset] = true;
				StoreStackForOffset(exceptionRegion.HandlerOffset, ref immutableStack);
			}
		}
		reader.Reset();
		while (reader.RemainingBytes > 0)
		{
			cancellationToken.ThrowIfCancellationRequested();
			int offset = reader.Offset;
			StoreStackForOffset(offset, ref currentStack);
			currentInstructionStart = offset;
			ILInstruction iLInstruction;
			try
			{
				iLInstruction = DecodeInstruction();
			}
			catch (BadImageFormatException ex)
			{
				iLInstruction = new InvalidBranch(ex.Message);
			}
			if (iLInstruction.ResultType == StackType.Unknown && iLInstruction.OpCode != OpCode.InvalidBranch && UnpackPush(iLInstruction).OpCode != OpCode.InvalidExpression)
			{
				Warn("Unknown result type (might be due to invalid IL or missing references)");
			}
			iLInstruction.CheckInvariant(ILPhase.InILReader);
			int offset2 = reader.Offset;
			iLInstruction.AddILRange(new Interval(offset, offset2));
			UnpackPush(iLInstruction).AddILRange(iLInstruction);
			instructionBuilder.Add(iLInstruction);
			if (iLInstruction.HasDirectFlag(InstructionFlags.EndPointUnreachable) && !stackByOffset.TryGetValue(offset2, out currentStack))
			{
				currentStack = ImmutableStack<ILVariable>.Empty;
			}
		}
		CollectStackVariablesVisitor collectStackVariablesVisitor = new CollectStackVariablesVisitor(unionFind);
		for (int i = 0; i < instructionBuilder.Count; i = checked(i + 1))
		{
			instructionBuilder[i] = instructionBuilder[i].AcceptVisitor(collectStackVariablesVisitor);
		}
		stackVariables = (IEnumerable<ILVariable>)collectStackVariablesVisitor.variables;
		InsertStackAdjustments();
	}

	private void InsertStackAdjustments()
	{
		if (stackMismatchPairs.Count == 0)
		{
			return;
		}
		MultiDictionary<ILVariable, ILVariable> multiDictionary = new MultiDictionary<ILVariable, ILVariable>();
		foreach (var stackMismatchPair in stackMismatchPairs)
		{
			ILVariable item = stackMismatchPair.Item1;
			ILVariable item2 = stackMismatchPair.Item2;
			ILVariable iLVariable = unionFind.Find(item);
			ILVariable iLVariable2 = unionFind.Find(item2);
			Debug.Assert((int)iLVariable.StackType < (int)iLVariable2.StackType);
			if (!Enumerable.Contains<ILVariable>((IEnumerable<ILVariable>)multiDictionary[iLVariable], iLVariable2))
			{
				multiDictionary.Add(iLVariable, iLVariable2);
			}
		}
		List<ILInstruction> list = new List<ILInstruction>();
		foreach (ILInstruction item3 in instructionBuilder)
		{
			list.Add(item3);
			if (!(item3 is StLoc stLoc))
			{
				continue;
			}
			foreach (ILVariable item4 in multiDictionary[stLoc.Variable])
			{
				ILInstruction argument = new LdLoc(stLoc.Variable);
				argument = new Conv(argument, item4.StackType.ToPrimitiveType(), checkForOverflow: false, Sign.Signed);
				list.Add(new StLoc(item4, argument)
				{
					IsStackAdjustment = true
				}.WithILRange(item3));
			}
		}
		instructionBuilder = list;
	}

	public void WriteTypedIL(MethodDefinitionHandle method, MethodBodyBlock body, ITextOutput output, GenericContext genericContext = default(GenericContext), CancellationToken cancellationToken = default(CancellationToken))
	{
		Init(method, body, genericContext);
		ReadInstructions(cancellationToken);
		foreach (ILInstruction item in instructionBuilder)
		{
			if (item is StLoc { IsStackAdjustment: not false })
			{
				output.Write("          ");
				item.WriteTo(output, new ILAstWritingOptions());
				output.WriteLine();
				continue;
			}
			output.Write("   [");
			bool flag = true;
			foreach (ILVariable item2 in stackByOffset[item.StartILOffset])
			{
				if (flag)
				{
					flag = false;
				}
				else
				{
					output.Write(", ");
				}
				output.WriteLocalReference(item2.Name, item2);
				output.Write(":");
				output.Write(item2.StackType);
			}
			output.Write(']');
			output.WriteLine();
			if (isBranchTarget[item.StartILOffset])
			{
				output.Write('*');
			}
			else
			{
				output.Write(' ');
			}
			output.WriteLocalReference("IL_" + item.StartILOffset.ToString("x4"), item.StartILOffset, isDefinition: true);
			output.Write(": ");
			item.WriteTo(output, new ILAstWritingOptions());
			output.WriteLine();
		}
		MethodBodyDisassembler methodBodyDisassembler = new MethodBodyDisassembler(output, cancellationToken);
		methodBodyDisassembler.DetectControlStructure = false;
		methodBodyDisassembler.WriteExceptionHandlers(module.PEFile, method, body);
	}

	public ILFunction ReadIL(MethodDefinitionHandle method, MethodBodyBlock body, GenericContext genericContext = default(GenericContext), CancellationToken cancellationToken = default(CancellationToken))
	{
		cancellationToken.ThrowIfCancellationRequested();
		Init(method, body, genericContext);
		ReadInstructions(cancellationToken);
		BlockBuilder blockBuilder = new BlockBuilder(body, variableByExceptionHandler);
		blockBuilder.CreateBlocks(mainContainer, instructionBuilder, isBranchTarget, cancellationToken);
		ILFunction iLFunction = new ILFunction(this.method, body.GetCodeSize(), this.genericContext, mainContainer);
		iLFunction.Variables.AddRange(parameterVariables);
		iLFunction.Variables.AddRange(localVariables);
		iLFunction.Variables.AddRange(stackVariables);
		iLFunction.Variables.AddRange(variableByExceptionHandler.Values);
		iLFunction.AddRef();
		foreach (BlockContainer item in Enumerable.OfType<BlockContainer>((IEnumerable)iLFunction.Descendants))
		{
			item.SortBlocks();
		}
		iLFunction.Warnings.AddRange(Warnings);
		return iLFunction;
	}

	private static ILInstruction UnpackPush(ILInstruction inst)
	{
		if (inst.MatchStLoc(out var variable, out var value) && variable.Kind == VariableKind.StackSlot)
		{
			return value;
		}
		return inst;
	}

	private ILInstruction Neg()
	{
		switch (PeekStackType())
		{
		case StackType.I4:
			return Push(new BinaryNumericInstruction(BinaryNumericOperator.Sub, new LdcI4(0), Pop(), checkForOverflow: false, Sign.None));
		case StackType.I:
			return Push(new BinaryNumericInstruction(BinaryNumericOperator.Sub, new Conv(new LdcI4(0), PrimitiveType.I, checkForOverflow: false, Sign.None), Pop(), checkForOverflow: false, Sign.None));
		case StackType.I8:
			return Push(new BinaryNumericInstruction(BinaryNumericOperator.Sub, new LdcI8(0L), Pop(), checkForOverflow: false, Sign.None));
		case StackType.F4:
			return Push(new BinaryNumericInstruction(BinaryNumericOperator.Sub, new LdcF4(0f), Pop(), checkForOverflow: false, Sign.None));
		case StackType.F8:
			return Push(new BinaryNumericInstruction(BinaryNumericOperator.Sub, new LdcF8(0.0), Pop(), checkForOverflow: false, Sign.None));
		default:
			Warn("Unsupported input type for neg.");
			goto case StackType.I4;
		}
	}

	private ILInstruction DecodeInstruction()
	{
		if (reader.RemainingBytes == 0)
		{
			return new InvalidBranch("Unexpected end of body");
		}
		ILOpCode iLOpCode = reader.DecodeOpCode();
		switch (iLOpCode)
		{
		case ILOpCode.Constrained:
			return DecodeConstrainedCall();
		case ILOpCode.Readonly:
			return DecodeReadonly();
		case ILOpCode.Tail:
			return DecodeTailCall();
		case ILOpCode.Unaligned:
			return DecodeUnaligned();
		case ILOpCode.Volatile:
			return DecodeVolatile();
		case ILOpCode.Add:
			return BinaryNumeric(BinaryNumericOperator.Add);
		case ILOpCode.Add_ovf:
			return BinaryNumeric(BinaryNumericOperator.Add, checkForOverflow: true, Sign.Signed);
		case ILOpCode.Add_ovf_un:
			return BinaryNumeric(BinaryNumericOperator.Add, checkForOverflow: true, Sign.Unsigned);
		case ILOpCode.And:
			return BinaryNumeric(BinaryNumericOperator.BitAnd);
		case ILOpCode.Arglist:
			return Push(new Arglist());
		case ILOpCode.Beq:
			return DecodeComparisonBranch(iLOpCode, ComparisonKind.Equality);
		case ILOpCode.Beq_s:
			return DecodeComparisonBranch(iLOpCode, ComparisonKind.Equality);
		case ILOpCode.Bge:
			return DecodeComparisonBranch(iLOpCode, ComparisonKind.GreaterThanOrEqual);
		case ILOpCode.Bge_s:
			return DecodeComparisonBranch(iLOpCode, ComparisonKind.GreaterThanOrEqual);
		case ILOpCode.Bge_un:
			return DecodeComparisonBranch(iLOpCode, ComparisonKind.GreaterThanOrEqual, un: true);
		case ILOpCode.Bge_un_s:
			return DecodeComparisonBranch(iLOpCode, ComparisonKind.GreaterThanOrEqual, un: true);
		case ILOpCode.Bgt:
			return DecodeComparisonBranch(iLOpCode, ComparisonKind.GreaterThan);
		case ILOpCode.Bgt_s:
			return DecodeComparisonBranch(iLOpCode, ComparisonKind.GreaterThan);
		case ILOpCode.Bgt_un:
			return DecodeComparisonBranch(iLOpCode, ComparisonKind.GreaterThan, un: true);
		case ILOpCode.Bgt_un_s:
			return DecodeComparisonBranch(iLOpCode, ComparisonKind.GreaterThan, un: true);
		case ILOpCode.Ble:
			return DecodeComparisonBranch(iLOpCode, ComparisonKind.LessThanOrEqual);
		case ILOpCode.Ble_s:
			return DecodeComparisonBranch(iLOpCode, ComparisonKind.LessThanOrEqual);
		case ILOpCode.Ble_un:
			return DecodeComparisonBranch(iLOpCode, ComparisonKind.LessThanOrEqual, un: true);
		case ILOpCode.Ble_un_s:
			return DecodeComparisonBranch(iLOpCode, ComparisonKind.LessThanOrEqual, un: true);
		case ILOpCode.Blt:
			return DecodeComparisonBranch(iLOpCode, ComparisonKind.LessThan);
		case ILOpCode.Blt_s:
			return DecodeComparisonBranch(iLOpCode, ComparisonKind.LessThan);
		case ILOpCode.Blt_un:
			return DecodeComparisonBranch(iLOpCode, ComparisonKind.LessThan, un: true);
		case ILOpCode.Blt_un_s:
			return DecodeComparisonBranch(iLOpCode, ComparisonKind.LessThan, un: true);
		case ILOpCode.Bne_un:
			return DecodeComparisonBranch(iLOpCode, ComparisonKind.Inequality, un: true);
		case ILOpCode.Bne_un_s:
			return DecodeComparisonBranch(iLOpCode, ComparisonKind.Inequality, un: true);
		case ILOpCode.Br:
			return DecodeUnconditionalBranch(iLOpCode);
		case ILOpCode.Br_s:
			return DecodeUnconditionalBranch(iLOpCode);
		case ILOpCode.Break:
			return new DebugBreak();
		case ILOpCode.Brfalse:
			return DecodeConditionalBranch(iLOpCode, negate: true);
		case ILOpCode.Brfalse_s:
			return DecodeConditionalBranch(iLOpCode, negate: true);
		case ILOpCode.Brtrue:
			return DecodeConditionalBranch(iLOpCode, negate: false);
		case ILOpCode.Brtrue_s:
			return DecodeConditionalBranch(iLOpCode, negate: false);
		case ILOpCode.Call:
			return DecodeCall(OpCode.Call);
		case ILOpCode.Callvirt:
			return DecodeCall(OpCode.CallVirt);
		case ILOpCode.Calli:
			return DecodeCallIndirect();
		case ILOpCode.Ceq:
			return Push(Comparison(ComparisonKind.Equality));
		case ILOpCode.Cgt:
			return Push(Comparison(ComparisonKind.GreaterThan));
		case ILOpCode.Cgt_un:
			return Push(Comparison(ComparisonKind.GreaterThan, un: true));
		case ILOpCode.Clt:
			return Push(Comparison(ComparisonKind.LessThan));
		case ILOpCode.Clt_un:
			return Push(Comparison(ComparisonKind.LessThan, un: true));
		case ILOpCode.Ckfinite:
			return new Ckfinite(Peek());
		case ILOpCode.Conv_i1:
			return Push(new Conv(Pop(), PrimitiveType.I1, checkForOverflow: false, Sign.None));
		case ILOpCode.Conv_i2:
			return Push(new Conv(Pop(), PrimitiveType.I2, checkForOverflow: false, Sign.None));
		case ILOpCode.Conv_i4:
			return Push(new Conv(Pop(), PrimitiveType.I4, checkForOverflow: false, Sign.None));
		case ILOpCode.Conv_i8:
			return Push(new Conv(Pop(), PrimitiveType.I8, checkForOverflow: false, Sign.None));
		case ILOpCode.Conv_r4:
			return Push(new Conv(Pop(), PrimitiveType.R4, checkForOverflow: false, Sign.Signed));
		case ILOpCode.Conv_r8:
			return Push(new Conv(Pop(), PrimitiveType.R8, checkForOverflow: false, Sign.Signed));
		case ILOpCode.Conv_u1:
			return Push(new Conv(Pop(), PrimitiveType.U1, checkForOverflow: false, Sign.None));
		case ILOpCode.Conv_u2:
			return Push(new Conv(Pop(), PrimitiveType.U2, checkForOverflow: false, Sign.None));
		case ILOpCode.Conv_u4:
			return Push(new Conv(Pop(), PrimitiveType.U4, checkForOverflow: false, Sign.None));
		case ILOpCode.Conv_u8:
			return Push(new Conv(Pop(), PrimitiveType.U8, checkForOverflow: false, Sign.None));
		case ILOpCode.Conv_i:
			return Push(new Conv(Pop(), PrimitiveType.I, checkForOverflow: false, Sign.None));
		case ILOpCode.Conv_u:
			return Push(new Conv(Pop(), PrimitiveType.U, checkForOverflow: false, Sign.None));
		case ILOpCode.Conv_r_un:
			return Push(new Conv(Pop(), PrimitiveType.R8, checkForOverflow: false, Sign.Unsigned));
		case ILOpCode.Conv_ovf_i1:
			return Push(new Conv(Pop(), PrimitiveType.I1, checkForOverflow: true, Sign.Signed));
		case ILOpCode.Conv_ovf_i2:
			return Push(new Conv(Pop(), PrimitiveType.I2, checkForOverflow: true, Sign.Signed));
		case ILOpCode.Conv_ovf_i4:
			return Push(new Conv(Pop(), PrimitiveType.I4, checkForOverflow: true, Sign.Signed));
		case ILOpCode.Conv_ovf_i8:
			return Push(new Conv(Pop(), PrimitiveType.I8, checkForOverflow: true, Sign.Signed));
		case ILOpCode.Conv_ovf_u1:
			return Push(new Conv(Pop(), PrimitiveType.U1, checkForOverflow: true, Sign.Signed));
		case ILOpCode.Conv_ovf_u2:
			return Push(new Conv(Pop(), PrimitiveType.U2, checkForOverflow: true, Sign.Signed));
		case ILOpCode.Conv_ovf_u4:
			return Push(new Conv(Pop(), PrimitiveType.U4, checkForOverflow: true, Sign.Signed));
		case ILOpCode.Conv_ovf_u8:
			return Push(new Conv(Pop(), PrimitiveType.U8, checkForOverflow: true, Sign.Signed));
		case ILOpCode.Conv_ovf_i:
			return Push(new Conv(Pop(), PrimitiveType.I, checkForOverflow: true, Sign.Signed));
		case ILOpCode.Conv_ovf_u:
			return Push(new Conv(Pop(), PrimitiveType.U, checkForOverflow: true, Sign.Signed));
		case ILOpCode.Conv_ovf_i1_un:
			return Push(new Conv(Pop(), PrimitiveType.I1, checkForOverflow: true, Sign.Unsigned));
		case ILOpCode.Conv_ovf_i2_un:
			return Push(new Conv(Pop(), PrimitiveType.I2, checkForOverflow: true, Sign.Unsigned));
		case ILOpCode.Conv_ovf_i4_un:
			return Push(new Conv(Pop(), PrimitiveType.I4, checkForOverflow: true, Sign.Unsigned));
		case ILOpCode.Conv_ovf_i8_un:
			return Push(new Conv(Pop(), PrimitiveType.I8, checkForOverflow: true, Sign.Unsigned));
		case ILOpCode.Conv_ovf_u1_un:
			return Push(new Conv(Pop(), PrimitiveType.U1, checkForOverflow: true, Sign.Unsigned));
		case ILOpCode.Conv_ovf_u2_un:
			return Push(new Conv(Pop(), PrimitiveType.U2, checkForOverflow: true, Sign.Unsigned));
		case ILOpCode.Conv_ovf_u4_un:
			return Push(new Conv(Pop(), PrimitiveType.U4, checkForOverflow: true, Sign.Unsigned));
		case ILOpCode.Conv_ovf_u8_un:
			return Push(new Conv(Pop(), PrimitiveType.U8, checkForOverflow: true, Sign.Unsigned));
		case ILOpCode.Conv_ovf_i_un:
			return Push(new Conv(Pop(), PrimitiveType.I, checkForOverflow: true, Sign.Unsigned));
		case ILOpCode.Conv_ovf_u_un:
			return Push(new Conv(Pop(), PrimitiveType.U, checkForOverflow: true, Sign.Unsigned));
		case ILOpCode.Cpblk:
		{
			ILInstruction iLInstruction = Pop(StackType.I4);
			ILInstruction value = PopPointer();
			return new Cpblk(PopPointer(), value, iLInstruction);
		}
		case ILOpCode.Div:
			return BinaryNumeric(BinaryNumericOperator.Div, checkForOverflow: false, Sign.Signed);
		case ILOpCode.Div_un:
			return BinaryNumeric(BinaryNumericOperator.Div, checkForOverflow: false, Sign.Unsigned);
		case ILOpCode.Dup:
			return Push(Peek());
		case ILOpCode.Endfilter:
			return new Leave(null, Pop());
		case ILOpCode.Endfinally:
			return new Leave(null);
		case ILOpCode.Initblk:
		{
			ILInstruction value = Pop(StackType.I4);
			ILInstruction iLInstruction = Pop(StackType.I4);
			return new Initblk(PopPointer(), iLInstruction, value);
		}
		case ILOpCode.Jmp:
			return DecodeJmp();
		case ILOpCode.Ldarg_s:
		case ILOpCode.Ldarg:
			return Push(Ldarg(reader.DecodeIndex(iLOpCode)));
		case ILOpCode.Ldarg_0:
			return Push(Ldarg(0));
		case ILOpCode.Ldarg_1:
			return Push(Ldarg(1));
		case ILOpCode.Ldarg_2:
			return Push(Ldarg(2));
		case ILOpCode.Ldarg_3:
			return Push(Ldarg(3));
		case ILOpCode.Ldarga_s:
		case ILOpCode.Ldarga:
			return Push(Ldarga(reader.DecodeIndex(iLOpCode)));
		case ILOpCode.Ldc_i4:
			return Push(new LdcI4(reader.ReadInt32()));
		case ILOpCode.Ldc_i8:
			return Push(new LdcI8(reader.ReadInt64()));
		case ILOpCode.Ldc_r4:
			return Push(new LdcF4(reader.ReadSingle()));
		case ILOpCode.Ldc_r8:
			return Push(new LdcF8(reader.ReadDouble()));
		case ILOpCode.Ldc_i4_m1:
			return Push(new LdcI4(-1));
		case ILOpCode.Ldc_i4_0:
			return Push(new LdcI4(0));
		case ILOpCode.Ldc_i4_1:
			return Push(new LdcI4(1));
		case ILOpCode.Ldc_i4_2:
			return Push(new LdcI4(2));
		case ILOpCode.Ldc_i4_3:
			return Push(new LdcI4(3));
		case ILOpCode.Ldc_i4_4:
			return Push(new LdcI4(4));
		case ILOpCode.Ldc_i4_5:
			return Push(new LdcI4(5));
		case ILOpCode.Ldc_i4_6:
			return Push(new LdcI4(6));
		case ILOpCode.Ldc_i4_7:
			return Push(new LdcI4(7));
		case ILOpCode.Ldc_i4_8:
			return Push(new LdcI4(8));
		case ILOpCode.Ldc_i4_s:
			return Push(new LdcI4(reader.ReadSByte()));
		case ILOpCode.Ldnull:
			return Push(new LdNull());
		case ILOpCode.Ldstr:
			return Push(DecodeLdstr());
		case ILOpCode.Ldftn:
			return Push(new LdFtn(ReadAndDecodeMethodReference()));
		case ILOpCode.Ldind_i1:
			return Push(new LdObj(PopPointer(), compilation.FindType(KnownTypeCode.SByte)));
		case ILOpCode.Ldind_i2:
			return Push(new LdObj(PopPointer(), compilation.FindType(KnownTypeCode.Int16)));
		case ILOpCode.Ldind_i4:
			return Push(new LdObj(PopPointer(), compilation.FindType(KnownTypeCode.Int32)));
		case ILOpCode.Ldind_i8:
			return Push(new LdObj(PopPointer(), compilation.FindType(KnownTypeCode.Int64)));
		case ILOpCode.Ldind_u1:
			return Push(new LdObj(PopPointer(), compilation.FindType(KnownTypeCode.Byte)));
		case ILOpCode.Ldind_u2:
			return Push(new LdObj(PopPointer(), compilation.FindType(KnownTypeCode.UInt16)));
		case ILOpCode.Ldind_u4:
			return Push(new LdObj(PopPointer(), compilation.FindType(KnownTypeCode.UInt32)));
		case ILOpCode.Ldind_r4:
			return Push(new LdObj(PopPointer(), compilation.FindType(KnownTypeCode.Single)));
		case ILOpCode.Ldind_r8:
			return Push(new LdObj(PopPointer(), compilation.FindType(KnownTypeCode.Double)));
		case ILOpCode.Ldind_i:
			return Push(new LdObj(PopPointer(), compilation.FindType(KnownTypeCode.IntPtr)));
		case ILOpCode.Ldind_ref:
			return Push(new LdObj(PopPointer(), compilation.FindType(KnownTypeCode.Object)));
		case ILOpCode.Ldloc_s:
		case ILOpCode.Ldloc:
			return Push(Ldloc(reader.DecodeIndex(iLOpCode)));
		case ILOpCode.Ldloc_0:
			return Push(Ldloc(0));
		case ILOpCode.Ldloc_1:
			return Push(Ldloc(1));
		case ILOpCode.Ldloc_2:
			return Push(Ldloc(2));
		case ILOpCode.Ldloc_3:
			return Push(Ldloc(3));
		case ILOpCode.Ldloca_s:
		case ILOpCode.Ldloca:
			return Push(Ldloca(reader.DecodeIndex(iLOpCode)));
		case ILOpCode.Leave:
			return DecodeUnconditionalBranch(iLOpCode, isLeave: true);
		case ILOpCode.Leave_s:
			return DecodeUnconditionalBranch(iLOpCode, isLeave: true);
		case ILOpCode.Localloc:
			return Push(new LocAlloc(Pop()));
		case ILOpCode.Mul:
			return BinaryNumeric(BinaryNumericOperator.Mul);
		case ILOpCode.Mul_ovf:
			return BinaryNumeric(BinaryNumericOperator.Mul, checkForOverflow: true, Sign.Signed);
		case ILOpCode.Mul_ovf_un:
			return BinaryNumeric(BinaryNumericOperator.Mul, checkForOverflow: true, Sign.Unsigned);
		case ILOpCode.Neg:
			return Neg();
		case ILOpCode.Newobj:
			return DecodeCall(OpCode.NewObj);
		case ILOpCode.Nop:
			return new Nop();
		case ILOpCode.Not:
			return Push(new BitNot(Pop()));
		case ILOpCode.Or:
			return BinaryNumeric(BinaryNumericOperator.BitOr);
		case ILOpCode.Pop:
			Pop();
			return new Nop
			{
				Kind = NopKind.Pop
			};
		case ILOpCode.Rem:
			return BinaryNumeric(BinaryNumericOperator.Rem, checkForOverflow: false, Sign.Signed);
		case ILOpCode.Rem_un:
			return BinaryNumeric(BinaryNumericOperator.Rem, checkForOverflow: false, Sign.Unsigned);
		case ILOpCode.Ret:
			return Return();
		case ILOpCode.Shl:
			return BinaryNumeric(BinaryNumericOperator.ShiftLeft);
		case ILOpCode.Shr:
			return BinaryNumeric(BinaryNumericOperator.ShiftRight, checkForOverflow: false, Sign.Signed);
		case ILOpCode.Shr_un:
			return BinaryNumeric(BinaryNumericOperator.ShiftRight, checkForOverflow: false, Sign.Unsigned);
		case ILOpCode.Starg_s:
		case ILOpCode.Starg:
			return Starg(reader.DecodeIndex(iLOpCode));
		case ILOpCode.Stind_i1:
		{
			ILInstruction iLInstruction = Pop(StackType.I4);
			return new StObj(PopPointer(), iLInstruction, compilation.FindType(KnownTypeCode.SByte));
		}
		case ILOpCode.Stind_i2:
		{
			ILInstruction iLInstruction = Pop(StackType.I4);
			return new StObj(PopPointer(), iLInstruction, compilation.FindType(KnownTypeCode.Int16));
		}
		case ILOpCode.Stind_i4:
		{
			ILInstruction iLInstruction = Pop(StackType.I4);
			return new StObj(PopPointer(), iLInstruction, compilation.FindType(KnownTypeCode.Int32));
		}
		case ILOpCode.Stind_i8:
		{
			ILInstruction iLInstruction = Pop(StackType.I8);
			return new StObj(PopPointer(), iLInstruction, compilation.FindType(KnownTypeCode.Int64));
		}
		case ILOpCode.Stind_r4:
		{
			ILInstruction iLInstruction = Pop(StackType.F4);
			return new StObj(PopPointer(), iLInstruction, compilation.FindType(KnownTypeCode.Single));
		}
		case ILOpCode.Stind_r8:
		{
			ILInstruction iLInstruction = Pop(StackType.F8);
			return new StObj(PopPointer(), iLInstruction, compilation.FindType(KnownTypeCode.Double));
		}
		case ILOpCode.Stind_i:
		{
			ILInstruction iLInstruction = Pop(StackType.I);
			return new StObj(PopPointer(), iLInstruction, compilation.FindType(KnownTypeCode.IntPtr));
		}
		case ILOpCode.Stind_ref:
		{
			ILInstruction iLInstruction = Pop(StackType.O);
			return new StObj(PopPointer(), iLInstruction, compilation.FindType(KnownTypeCode.Object));
		}
		case ILOpCode.Stloc_s:
		case ILOpCode.Stloc:
			return Stloc(reader.DecodeIndex(iLOpCode));
		case ILOpCode.Stloc_0:
			return Stloc(0);
		case ILOpCode.Stloc_1:
			return Stloc(1);
		case ILOpCode.Stloc_2:
			return Stloc(2);
		case ILOpCode.Stloc_3:
			return Stloc(3);
		case ILOpCode.Sub:
			return BinaryNumeric(BinaryNumericOperator.Sub);
		case ILOpCode.Sub_ovf:
			return BinaryNumeric(BinaryNumericOperator.Sub, checkForOverflow: true, Sign.Signed);
		case ILOpCode.Sub_ovf_un:
			return BinaryNumeric(BinaryNumericOperator.Sub, checkForOverflow: true, Sign.Unsigned);
		case ILOpCode.Switch:
			return DecodeSwitch();
		case ILOpCode.Xor:
			return BinaryNumeric(BinaryNumericOperator.BitXor);
		case ILOpCode.Box:
		{
			IType type3 = ReadAndDecodeTypeReference();
			return Push(new Box(Pop(type3.GetStackType()), type3));
		}
		case ILOpCode.Castclass:
			return Push(new CastClass(Pop(StackType.O), ReadAndDecodeTypeReference()));
		case ILOpCode.Cpobj:
		{
			IType type2 = ReadAndDecodeTypeReference();
			LdObj value2 = new LdObj(PopPointer(), type2);
			return new StObj(PopPointer(), value2, type2);
		}
		case ILOpCode.Initobj:
			return InitObj(PopPointer(), ReadAndDecodeTypeReference());
		case ILOpCode.Isinst:
			return Push(new IsInst(Pop(StackType.O), ReadAndDecodeTypeReference()));
		case ILOpCode.Ldelem:
			return LdElem(ReadAndDecodeTypeReference());
		case ILOpCode.Ldelem_i1:
			return LdElem(compilation.FindType(KnownTypeCode.SByte));
		case ILOpCode.Ldelem_i2:
			return LdElem(compilation.FindType(KnownTypeCode.Int16));
		case ILOpCode.Ldelem_i4:
			return LdElem(compilation.FindType(KnownTypeCode.Int32));
		case ILOpCode.Ldelem_i8:
			return LdElem(compilation.FindType(KnownTypeCode.Int64));
		case ILOpCode.Ldelem_u1:
			return LdElem(compilation.FindType(KnownTypeCode.Byte));
		case ILOpCode.Ldelem_u2:
			return LdElem(compilation.FindType(KnownTypeCode.UInt16));
		case ILOpCode.Ldelem_u4:
			return LdElem(compilation.FindType(KnownTypeCode.UInt32));
		case ILOpCode.Ldelem_r4:
			return LdElem(compilation.FindType(KnownTypeCode.Single));
		case ILOpCode.Ldelem_r8:
			return LdElem(compilation.FindType(KnownTypeCode.Double));
		case ILOpCode.Ldelem_i:
			return LdElem(compilation.FindType(KnownTypeCode.IntPtr));
		case ILOpCode.Ldelem_ref:
			return LdElem(compilation.FindType(KnownTypeCode.Object));
		case ILOpCode.Ldelema:
		{
			ILInstruction iLInstruction = Pop();
			return Push(new LdElema(array: Pop(), type: ReadAndDecodeTypeReference(), indices: new ILInstruction[1] { iLInstruction }));
		}
		case ILOpCode.Ldfld:
		{
			IField field5 = ReadAndDecodeFieldReference();
			return Push(new LdObj(new LdFlda(PopLdFldTarget(field5), field5)
			{
				DelayExceptions = true
			}, field5.Type));
		}
		case ILOpCode.Ldflda:
		{
			IField field4 = ReadAndDecodeFieldReference();
			return Push(new LdFlda(PopFieldTarget(field4), field4));
		}
		case ILOpCode.Stfld:
		{
			IField field3 = ReadAndDecodeFieldReference();
			ILInstruction value = Pop(field3.Type.GetStackType());
			return new StObj(new LdFlda(PopFieldTarget(field3), field3)
			{
				DelayExceptions = true
			}, value, field3.Type);
		}
		case ILOpCode.Ldlen:
			return Push(new LdLen(StackType.I, Pop(StackType.O)));
		case ILOpCode.Ldobj:
			return Push(new LdObj(PopPointer(), ReadAndDecodeTypeReference()));
		case ILOpCode.Ldsfld:
		{
			IField field2 = ReadAndDecodeFieldReference();
			return Push(new LdObj(new LdsFlda(field2), field2.Type));
		}
		case ILOpCode.Ldsflda:
			return Push(new LdsFlda(ReadAndDecodeFieldReference()));
		case ILOpCode.Stsfld:
		{
			IField field = ReadAndDecodeFieldReference();
			ILInstruction value = Pop(field.Type.GetStackType());
			return new StObj(new LdsFlda(field), value, field.Type);
		}
		case ILOpCode.Ldtoken:
			return Push(LdToken(ReadAndDecodeMetadataToken()));
		case ILOpCode.Ldvirtftn:
			return Push(new LdVirtFtn(Pop(), ReadAndDecodeMethodReference()));
		case ILOpCode.Mkrefany:
			return Push(new MakeRefAny(PopPointer(), ReadAndDecodeTypeReference()));
		case ILOpCode.Newarr:
			return Push(new NewArr(ReadAndDecodeTypeReference(), Pop()));
		case ILOpCode.Refanytype:
			return Push(new RefAnyType(Pop()));
		case ILOpCode.Refanyval:
			return Push(new RefAnyValue(Pop(), ReadAndDecodeTypeReference()));
		case ILOpCode.Rethrow:
			return new Rethrow();
		case ILOpCode.Sizeof:
			return Push(new SizeOf(ReadAndDecodeTypeReference()));
		case ILOpCode.Stelem:
			return StElem(ReadAndDecodeTypeReference());
		case ILOpCode.Stelem_i1:
			return StElem(compilation.FindType(KnownTypeCode.SByte));
		case ILOpCode.Stelem_i2:
			return StElem(compilation.FindType(KnownTypeCode.Int16));
		case ILOpCode.Stelem_i4:
			return StElem(compilation.FindType(KnownTypeCode.Int32));
		case ILOpCode.Stelem_i8:
			return StElem(compilation.FindType(KnownTypeCode.Int64));
		case ILOpCode.Stelem_r4:
			return StElem(compilation.FindType(KnownTypeCode.Single));
		case ILOpCode.Stelem_r8:
			return StElem(compilation.FindType(KnownTypeCode.Double));
		case ILOpCode.Stelem_i:
			return StElem(compilation.FindType(KnownTypeCode.IntPtr));
		case ILOpCode.Stelem_ref:
			return StElem(compilation.FindType(KnownTypeCode.Object));
		case ILOpCode.Stobj:
		{
			IType type = ReadAndDecodeTypeReference();
			ILInstruction value = Pop(type.GetStackType());
			return new StObj(PopPointer(), value, type);
		}
		case ILOpCode.Throw:
			return new Throw(Pop());
		case ILOpCode.Unbox:
			return Push(new Unbox(Pop(), ReadAndDecodeTypeReference()));
		case ILOpCode.Unbox_any:
			return Push(new UnboxAny(Pop(), ReadAndDecodeTypeReference()));
		default:
			return new InvalidBranch($"Unknown opcode: 0x{(int)iLOpCode:X2}");
		}
	}

	private StackType PeekStackType()
	{
		if (currentStack.IsEmpty)
		{
			return StackType.Unknown;
		}
		return currentStack.Peek().StackType;
	}

	private ILInstruction Push(ILInstruction inst)
	{
		Debug.Assert(inst.ResultType != StackType.Void);
		IType type = compilation.FindType(inst.ResultType.ToKnownTypeCode());
		ILVariable iLVariable = new ILVariable(VariableKind.StackSlot, type, inst.ResultType);
		iLVariable.HasGeneratedName = true;
		currentStack = currentStack.Push(iLVariable);
		return new StLoc(iLVariable, inst);
	}

	private ILInstruction Peek()
	{
		if (currentStack.IsEmpty)
		{
			return new InvalidExpression("Stack underflow").WithILRange(new Interval(reader.Offset, reader.Offset));
		}
		return new LdLoc(currentStack.Peek());
	}

	private ILInstruction Pop()
	{
		if (currentStack.IsEmpty)
		{
			return new InvalidExpression("Stack underflow").WithILRange(new Interval(reader.Offset, reader.Offset));
		}
		currentStack = currentStack.Pop(out var value);
		return new LdLoc(value);
	}

	private ILInstruction Pop(StackType expectedType)
	{
		ILInstruction inst = Pop();
		return Cast(inst, expectedType, Warnings, reader.Offset);
	}

	internal static ILInstruction Cast(ILInstruction inst, StackType expectedType, List<string> warnings, int ilOffset)
	{
		if (expectedType != inst.ResultType)
		{
			if (inst is InvalidExpression)
			{
				((InvalidExpression)inst).ExpectedResultType = expectedType;
			}
			else if (expectedType == StackType.I && inst.ResultType == StackType.I4)
			{
				inst = new Conv(inst, PrimitiveType.I, checkForOverflow: false, Sign.None);
			}
			else if (expectedType == StackType.I4 && inst.ResultType == StackType.I)
			{
				inst = new Conv(inst, PrimitiveType.I4, checkForOverflow: false, Sign.None);
			}
			else if (expectedType == StackType.Unknown)
			{
				inst = new Conv(inst, PrimitiveType.Unknown, checkForOverflow: false, Sign.None);
			}
			else if (inst.ResultType == StackType.Ref)
			{
				inst = new Conv(inst, PrimitiveType.I, checkForOverflow: false, Sign.None);
				switch (expectedType)
				{
				case StackType.I4:
					inst = new Conv(inst, PrimitiveType.I4, checkForOverflow: false, Sign.None);
					break;
				case StackType.I8:
					inst = new Conv(inst, PrimitiveType.I8, checkForOverflow: false, Sign.None);
					break;
				default:
					Warn($"Expected {expectedType}, but got {StackType.Ref}");
					inst = new Conv(inst, expectedType.ToPrimitiveType(), checkForOverflow: false, Sign.None);
					break;
				case StackType.I:
					break;
				}
			}
			else if (expectedType == StackType.Ref)
			{
				if (!inst.ResultType.IsIntegerType() && inst.ResultType != StackType.O)
				{
					Warn($"Expected {expectedType}, but got {inst.ResultType}");
				}
				inst = new Conv(inst, PrimitiveType.Ref, checkForOverflow: false, Sign.None);
			}
			else if (expectedType == StackType.F8 && inst.ResultType == StackType.F4)
			{
				inst = new Conv(inst, PrimitiveType.R8, checkForOverflow: false, Sign.Signed);
			}
			else if (expectedType == StackType.F4 && inst.ResultType == StackType.F8)
			{
				inst = new Conv(inst, PrimitiveType.R4, checkForOverflow: false, Sign.Signed);
			}
			else
			{
				Warn($"Expected {expectedType}, but got {inst.ResultType}");
				inst = new Conv(inst, expectedType.ToPrimitiveType(), checkForOverflow: false, Sign.Signed);
			}
		}
		return inst;
		void Warn(string message)
		{
			if (warnings != null)
			{
				warnings.Add($"IL_{ilOffset:x4}: {message}");
			}
		}
	}

	private ILInstruction PopPointer()
	{
		ILInstruction iLInstruction = Pop();
		switch (iLInstruction.ResultType)
		{
		case StackType.Unknown:
		case StackType.I4:
		case StackType.I8:
			return new Conv(iLInstruction, PrimitiveType.I, checkForOverflow: false, Sign.None);
		case StackType.I:
		case StackType.Ref:
			return iLInstruction;
		default:
			Warn("Expected native int or pointer, but got " + iLInstruction.ResultType);
			return new Conv(iLInstruction, PrimitiveType.I, checkForOverflow: false, Sign.None);
		}
	}

	private ILInstruction PopFieldTarget(IField field)
	{
		switch (field.DeclaringType.IsReferenceType)
		{
		case true:
			return Pop(StackType.O);
		case false:
			return PopPointer();
		default:
			if (PeekStackType() == StackType.O)
			{
				return Pop();
			}
			return PopPointer();
		}
	}

	private ILInstruction PopLdFldTarget(IField field)
	{
		switch (field.DeclaringType.IsReferenceType)
		{
		case true:
			return Pop(StackType.O);
		case false:
			if (PeekStackType() == StackType.O)
			{
				return new AddressOf(Pop());
			}
			return PopPointer();
		default:
			if (PeekStackType() == StackType.O)
			{
				return Pop(StackType.O);
			}
			return PopPointer();
		}
	}

	private ILInstruction Return()
	{
		if (methodReturnStackType == StackType.Void)
		{
			return new Leave(mainContainer);
		}
		return new Leave(mainContainer, Pop(methodReturnStackType));
	}

	private ILInstruction DecodeLdstr()
	{
		return new LdStr(reader.DecodeUserString(metadata));
	}

	private ILInstruction Ldarg(int v)
	{
		if (v >= 0 && v < parameterVariables.Length)
		{
			return new LdLoc(parameterVariables[v]);
		}
		return new InvalidExpression($"ldarg {v} (out-of-bounds)");
	}

	private ILInstruction Ldarga(int v)
	{
		if (v >= 0 && v < parameterVariables.Length)
		{
			return new LdLoca(parameterVariables[v]);
		}
		return new InvalidExpression($"ldarga {v} (out-of-bounds)");
	}

	private ILInstruction Starg(int v)
	{
		if (v >= 0 && v < parameterVariables.Length)
		{
			return new StLoc(parameterVariables[v], Pop(parameterVariables[v].StackType));
		}
		Pop();
		return new InvalidExpression($"starg {v} (out-of-bounds)");
	}

	private ILInstruction Ldloc(int v)
	{
		if (v >= 0 && v < localVariables.Length)
		{
			return new LdLoc(localVariables[v]);
		}
		return new InvalidExpression($"ldloc {v} (out-of-bounds)");
	}

	private ILInstruction Ldloca(int v)
	{
		if (v >= 0 && v < localVariables.Length)
		{
			return new LdLoca(localVariables[v]);
		}
		return new InvalidExpression($"ldloca {v} (out-of-bounds)");
	}

	private ILInstruction Stloc(int v)
	{
		if (v >= 0 && v < localVariables.Length)
		{
			return new StLoc(localVariables[v], Pop(localVariables[v].StackType))
			{
				ILStackWasEmpty = currentStack.IsEmpty
			};
		}
		Pop();
		return new InvalidExpression($"stloc {v} (out-of-bounds)");
	}

	private ILInstruction LdElem(IType type)
	{
		ILInstruction iLInstruction = Pop();
		ILInstruction array = Pop();
		return Push(new LdObj(new LdElema(type, array, iLInstruction)
		{
			DelayExceptions = true
		}, type));
	}

	private ILInstruction StElem(IType type)
	{
		ILInstruction value = Pop(type.GetStackType());
		ILInstruction iLInstruction = Pop();
		ILInstruction array = Pop();
		return new StObj(new LdElema(type, array, iLInstruction)
		{
			DelayExceptions = true
		}, value, type);
	}

	private ILInstruction InitObj(ILInstruction target, IType type)
	{
		DefaultValue defaultValue = new DefaultValue(type);
		defaultValue.ILStackWasEmpty = currentStack.IsEmpty;
		return new StObj(target, defaultValue, type);
	}

	private ILInstruction DecodeConstrainedCall()
	{
		constrainedPrefix = ReadAndDecodeTypeReference();
		ILInstruction iLInstruction = DecodeInstruction();
		if (UnpackPush(iLInstruction) is CallInstruction callInstruction)
		{
			Debug.Assert(callInstruction.ConstrainedTo == constrainedPrefix);
		}
		else
		{
			Warn("Ignored invalid 'constrained' prefix");
		}
		constrainedPrefix = null;
		return iLInstruction;
	}

	private ILInstruction DecodeTailCall()
	{
		ILInstruction iLInstruction = DecodeInstruction();
		if (UnpackPush(iLInstruction) is CallInstruction callInstruction)
		{
			callInstruction.IsTail = true;
		}
		else
		{
			Warn("Ignored invalid 'tail' prefix");
		}
		return iLInstruction;
	}

	private ILInstruction DecodeUnaligned()
	{
		byte unalignedPrefix = reader.ReadByte();
		ILInstruction iLInstruction = DecodeInstruction();
		if (UnpackPush(iLInstruction) is ISupportsUnalignedPrefix supportsUnalignedPrefix)
		{
			supportsUnalignedPrefix.UnalignedPrefix = unalignedPrefix;
		}
		else
		{
			Warn("Ignored invalid 'unaligned' prefix");
		}
		return iLInstruction;
	}

	private ILInstruction DecodeVolatile()
	{
		ILInstruction iLInstruction = DecodeInstruction();
		if (UnpackPush(iLInstruction) is ISupportsVolatilePrefix supportsVolatilePrefix)
		{
			supportsVolatilePrefix.IsVolatile = true;
		}
		else
		{
			Warn("Ignored invalid 'volatile' prefix");
		}
		return iLInstruction;
	}

	private ILInstruction DecodeReadonly()
	{
		ILInstruction iLInstruction = DecodeInstruction();
		if (UnpackPush(iLInstruction) is LdElema ldElema)
		{
			ldElema.IsReadOnly = true;
		}
		else
		{
			Warn("Ignored invalid 'readonly' prefix");
		}
		return iLInstruction;
	}

	private ILInstruction DecodeCall(OpCode opCode)
	{
		IMethod method = ReadAndDecodeMethodReference();
		int num = ((opCode != OpCode.NewObj && !method.IsStatic) ? 1 : 0);
		checked
		{
			ILInstruction[] array = new ILInstruction[num + method.Parameters.Count];
			for (int num2 = method.Parameters.Count - 1; num2 >= 0; num2--)
			{
				array[num + num2] = Pop(method.Parameters[num2].Type.GetStackType());
			}
			if (num == 1)
			{
				array[0] = Pop(CallInstruction.ExpectedTypeForThisPointer(constrainedPrefix ?? method.DeclaringType));
			}
			TypeKind kind = method.DeclaringType.Kind;
			if (kind == TypeKind.Array)
			{
				IType elementType = ((ArrayType)method.DeclaringType).ElementType;
				if (opCode == OpCode.NewObj)
				{
					return Push(new NewArr(elementType, array));
				}
				if (method.Name == "Set")
				{
					ILInstruction array2 = array[0];
					ILInstruction value = array.Last();
					ILInstruction[] indices = Enumerable.ToArray<ILInstruction>(Enumerable.Take<ILInstruction>(Enumerable.Skip<ILInstruction>((IEnumerable<ILInstruction>)array, 1), array.Length - 2));
					return new StObj(new LdElema(elementType, array2, indices)
					{
						DelayExceptions = true
					}, value, elementType);
				}
				if (method.Name == "Get")
				{
					ILInstruction array3 = array[0];
					ILInstruction[] indices2 = Enumerable.ToArray<ILInstruction>(Enumerable.Skip<ILInstruction>((IEnumerable<ILInstruction>)array, 1));
					return Push(new LdObj(new LdElema(elementType, array3, indices2)
					{
						DelayExceptions = true
					}, elementType));
				}
				if (method.Name == "Address")
				{
					ILInstruction array4 = array[0];
					ILInstruction[] indices3 = Enumerable.ToArray<ILInstruction>(Enumerable.Skip<ILInstruction>((IEnumerable<ILInstruction>)array, 1));
					return Push(new LdElema(elementType, array4, indices3));
				}
				Warn("Unknown method called on array type: " + method.Name);
			}
			CallInstruction callInstruction = CallInstruction.Create(opCode, method);
			callInstruction.ILStackWasEmpty = currentStack.IsEmpty;
			callInstruction.ConstrainedTo = constrainedPrefix;
			callInstruction.Arguments.AddRange(array);
			if (callInstruction.ResultType != StackType.Void)
			{
				return Push(callInstruction);
			}
			return callInstruction;
		}
	}

	private ILInstruction DecodeCallIndirect()
	{
		StandaloneSignatureHandle handle = (StandaloneSignatureHandle)ReadAndDecodeMetadataToken();
		MethodSignature<IType> methodSignature = module.DecodeMethodSignature(handle, genericContext);
		ILInstruction functionPointer = Pop(StackType.I);
		Debug.Assert(!methodSignature.Header.IsInstance);
		ILInstruction[] array = new ILInstruction[methodSignature.ParameterTypes.Length];
		checked
		{
			for (int num = methodSignature.ParameterTypes.Length - 1; num >= 0; num--)
			{
				array[num] = Pop(methodSignature.ParameterTypes[num].GetStackType());
			}
			CallIndirect callIndirect = new CallIndirect(methodSignature.Header.CallingConvention, methodSignature.ReturnType, methodSignature.ParameterTypes, array, functionPointer);
			if (callIndirect.ResultType != StackType.Void)
			{
				return Push(callIndirect);
			}
			return callIndirect;
		}
	}

	private ILInstruction Comparison(ComparisonKind kind, bool un = false)
	{
		ILInstruction right = Pop();
		ILInstruction left = Pop();
		if (left.ResultType == StackType.O && right.ResultType.IsIntegerType())
		{
			if (right.ResultType == StackType.I4)
			{
				right = new Conv(right, PrimitiveType.I, checkForOverflow: false, Sign.None);
			}
			left = new Conv(left, right.ResultType.ToPrimitiveType(), checkForOverflow: false, Sign.None);
		}
		else if (right.ResultType == StackType.O && left.ResultType.IsIntegerType())
		{
			if (left.ResultType == StackType.I4)
			{
				left = new Conv(left, PrimitiveType.I, checkForOverflow: false, Sign.None);
			}
			right = new Conv(right, left.ResultType.ToPrimitiveType(), checkForOverflow: false, Sign.None);
		}
		MakeExplicitConversion(StackType.I4, StackType.I, PrimitiveType.I);
		MakeExplicitConversion(StackType.I4, StackType.I8, PrimitiveType.I8);
		MakeExplicitConversion(StackType.I, StackType.I8, PrimitiveType.I8);
		if (left.ResultType.IsFloatType() && right.ResultType.IsFloatType())
		{
			if (left.ResultType != right.ResultType)
			{
				MakeExplicitConversion(StackType.F4, StackType.F8, PrimitiveType.R8);
			}
			if (un)
			{
				return Comp.LogicNot(new Comp(kind.Negate(), Sign.None, left, right));
			}
			return new Comp(kind, Sign.None, left, right);
		}
		if (left.ResultType.IsIntegerType() && right.ResultType.IsIntegerType() && !kind.IsEqualityOrInequality())
		{
			Debug.Assert(right.ResultType.IsIntegerType());
			return new Comp(kind, (!un) ? Sign.Signed : Sign.Unsigned, left, right);
		}
		if (left.ResultType == right.ResultType)
		{
			return new Comp(kind, Sign.None, left, right);
		}
		Warn($"Invalid comparison between {left.ResultType} and {right.ResultType}");
		if ((int)left.ResultType < (int)right.ResultType)
		{
			left = new Conv(left, right.ResultType.ToPrimitiveType(), checkForOverflow: false, Sign.Signed);
		}
		else
		{
			right = new Conv(right, left.ResultType.ToPrimitiveType(), checkForOverflow: false, Sign.Signed);
		}
		return new Comp(kind, Sign.None, left, right);
		void MakeExplicitConversion(StackType sourceType, StackType targetType, PrimitiveType conversionType)
		{
			if (left.ResultType == sourceType && right.ResultType == targetType)
			{
				left = new Conv(left, conversionType, checkForOverflow: false, Sign.None);
			}
			else if (left.ResultType == targetType && right.ResultType == sourceType)
			{
				right = new Conv(right, conversionType, checkForOverflow: false, Sign.None);
			}
		}
	}

	private bool IsInvalidBranch(int target)
	{
		return target < 0 || target >= reader.Length;
	}

	private ILInstruction DecodeComparisonBranch(ILOpCode opCode, ComparisonKind kind, bool un = false)
	{
		int start = checked(reader.Offset - 1);
		int num = reader.DecodeBranchTarget(opCode);
		ILInstruction iLInstruction = Comparison(kind, un);
		iLInstruction.AddILRange(new Interval(start, reader.Offset));
		if (!IsInvalidBranch(num))
		{
			MarkBranchTarget(num);
			return new IfInstruction(iLInstruction, new Branch(num));
		}
		return new IfInstruction(iLInstruction, new InvalidBranch("Invalid branch target"));
	}

	private ILInstruction DecodeConditionalBranch(ILOpCode opCode, bool negate)
	{
		int num = reader.DecodeBranchTarget(opCode);
		ILInstruction iLInstruction = Pop();
		switch (iLInstruction.ResultType)
		{
		case StackType.O:
			iLInstruction = new Comp((!negate) ? ComparisonKind.Inequality : ComparisonKind.Equality, Sign.None, iLInstruction, new LdNull());
			break;
		case StackType.I:
			iLInstruction = new Comp((!negate) ? ComparisonKind.Inequality : ComparisonKind.Equality, Sign.None, iLInstruction, new Conv(new LdcI4(0), PrimitiveType.I, checkForOverflow: false, Sign.None));
			break;
		case StackType.I8:
			iLInstruction = new Comp((!negate) ? ComparisonKind.Inequality : ComparisonKind.Equality, Sign.None, iLInstruction, new LdcI8(0L));
			break;
		case StackType.Ref:
			iLInstruction = new Comp((!negate) ? ComparisonKind.Inequality : ComparisonKind.Equality, Sign.None, new Conv(iLInstruction, PrimitiveType.I, checkForOverflow: false, Sign.None), new Conv(new LdcI4(0), PrimitiveType.I, checkForOverflow: false, Sign.None));
			break;
		case StackType.I4:
			if (negate)
			{
				iLInstruction = Comp.LogicNot(iLInstruction);
			}
			break;
		default:
			iLInstruction = new Conv(iLInstruction, PrimitiveType.I4, checkForOverflow: false, Sign.None);
			if (negate)
			{
				iLInstruction = Comp.LogicNot(iLInstruction);
			}
			break;
		}
		if (!IsInvalidBranch(num))
		{
			MarkBranchTarget(num);
			return new IfInstruction(iLInstruction, new Branch(num));
		}
		return new IfInstruction(iLInstruction, new InvalidBranch("Invalid branch target"));
	}

	private ILInstruction DecodeUnconditionalBranch(ILOpCode opCode, bool isLeave = false)
	{
		int num = reader.DecodeBranchTarget(opCode);
		if (isLeave)
		{
			currentStack = currentStack.Clear();
		}
		if (!IsInvalidBranch(num))
		{
			MarkBranchTarget(num);
			return new Branch(num);
		}
		return new InvalidBranch("Invalid branch target");
	}

	private void MarkBranchTarget(int targetILOffset)
	{
		isBranchTarget[targetILOffset] = true;
		StoreStackForOffset(targetILOffset, ref currentStack);
	}

	private ILInstruction DecodeSwitch()
	{
		int[] array = reader.DecodeSwitchTargets();
		SwitchInstruction switchInstruction = new SwitchInstruction(Pop(StackType.I4));
		for (int i = 0; i < array.Length; i = checked(i + 1))
		{
			SwitchSection switchSection = new SwitchSection();
			switchSection.Labels = new LongSet(i);
			int num = array[i];
			if (!IsInvalidBranch(num))
			{
				MarkBranchTarget(num);
				switchSection.Body = new Branch(num);
			}
			else
			{
				switchSection.Body = new InvalidBranch("Invalid branch target");
			}
			switchInstruction.Sections.Add(switchSection);
		}
		SwitchSection switchSection2 = new SwitchSection();
		switchSection2.Labels = new LongSet(new LongInterval(0L, array.Length)).Invert();
		switchSection2.Body = new Nop();
		switchInstruction.Sections.Add(switchSection2);
		return switchInstruction;
	}

	private ILInstruction BinaryNumeric(BinaryNumericOperator @operator, bool checkForOverflow = false, Sign sign = Sign.None)
	{
		ILInstruction right = Pop();
		ILInstruction left = Pop();
		if (@operator != BinaryNumericOperator.Add && @operator != BinaryNumericOperator.Sub)
		{
			if (left.ResultType == StackType.Ref)
			{
				left = new Conv(left, PrimitiveType.I, checkForOverflow: false, Sign.None);
			}
			if (right.ResultType == StackType.Ref)
			{
				right = new Conv(right, PrimitiveType.I, checkForOverflow: false, Sign.None);
			}
		}
		if (@operator != BinaryNumericOperator.ShiftLeft && @operator != BinaryNumericOperator.ShiftRight)
		{
			MakeExplicitConversion(StackType.I4, StackType.I, PrimitiveType.I);
			MakeExplicitConversion(StackType.I4, StackType.I8, PrimitiveType.I8);
			MakeExplicitConversion(StackType.I, StackType.I8, PrimitiveType.I8);
			MakeExplicitConversion(StackType.F4, StackType.F8, PrimitiveType.R8);
		}
		return Push(new BinaryNumericInstruction(@operator, left, right, checkForOverflow, sign));
		void MakeExplicitConversion(StackType sourceType, StackType targetType, PrimitiveType conversionType)
		{
			if (left.ResultType == sourceType && right.ResultType == targetType)
			{
				left = new Conv(left, conversionType, checkForOverflow: false, Sign.None);
			}
			else if (left.ResultType == targetType && right.ResultType == sourceType)
			{
				right = new Conv(right, conversionType, checkForOverflow: false, Sign.None);
			}
		}
	}

	private ILInstruction DecodeJmp()
	{
		IMethod method = ReadAndDecodeMethodReference();
		Call call = new Call(method);
		call.IsTail = true;
		call.ILStackWasEmpty = true;
		if (!method.IsStatic)
		{
			call.Arguments.Add(Ldarg(0));
		}
		foreach (IParameter parameter in method.Parameters)
		{
			call.Arguments.Add(Ldarg(call.Arguments.Count));
		}
		return new Leave(mainContainer, call);
	}

	private ILInstruction LdToken(EntityHandle token)
	{
		if (token.Kind.IsTypeKind())
		{
			return new LdTypeToken(module.ResolveType(token, genericContext));
		}
		if (token.Kind.IsMemberKind())
		{
			IEntity entity = module.ResolveEntity(token, genericContext);
			if (entity is IMember member)
			{
				return new LdMemberToken(member);
			}
		}
		throw new BadImageFormatException("Invalid metadata token for ldtoken instruction.");
	}
}
