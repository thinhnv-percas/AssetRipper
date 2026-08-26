#define STEP
#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL.Transforms;

public class ExpressionTransforms : ILVisitor, IStatementTransform
{
	internal StatementTransformContext context;

	public static void RunOnSingleStatement(ILInstruction statement, ILTransformContext context)
	{
		if (statement == null)
		{
			throw new ArgumentNullException("statement");
		}
		if (!(statement.Parent is Block block))
		{
			throw new ArgumentException("ILInstruction must be a statement, i.e., direct child of a block.");
		}
		new ExpressionTransforms().Run(block, statement.ChildIndex, new StatementTransformContext(new BlockTransformContext(context)));
	}

	public void Run(Block block, int pos, StatementTransformContext context)
	{
		this.context = context;
		context.StepStartGroup($"ExpressionTransforms ({block.Label}:{pos})", block.Instructions[pos]);
		block.Instructions[pos].AcceptVisitor(this);
		context.StepEndGroup(keepIfEmpty: true);
	}

	protected override void Default(ILInstruction inst)
	{
		foreach (ILInstruction child in inst.Children)
		{
			child.AcceptVisitor(this);
		}
	}

	protected internal override void VisitBlock(Block block)
	{
	}

	protected internal override void VisitComp(Comp inst)
	{
		if (inst.MatchLogicNot(out var arg))
		{
			VisitLogicNot(inst, arg);
			return;
		}
		if (inst.Kind == ComparisonKind.Inequality && inst.LiftingKind == ComparisonLiftingKind.None && inst.Right.MatchLdcI4(0) && (IfInstruction.IsInConditionSlot(inst) || inst.Left is Comp))
		{
			context.Step("Remove redundant comp(... != 0)", inst);
			inst.Left.AddILRange(inst);
			inst.ReplaceWith(inst.Left);
			inst.Left.AcceptVisitor(this);
			return;
		}
		base.VisitComp(inst);
		if (inst.IsLifted)
		{
			return;
		}
		if (inst.Right.MatchLdNull())
		{
			if (inst.Kind == ComparisonKind.GreaterThan)
			{
				context.Step("comp(left > ldnull)  => comp(left != ldnull)", inst);
				inst.Kind = ComparisonKind.Inequality;
			}
			else if (inst.Kind == ComparisonKind.LessThanOrEqual)
			{
				context.Step("comp(left <= ldnull) => comp(left == ldnull)", inst);
				inst.Kind = ComparisonKind.Equality;
			}
		}
		else if (inst.Left.MatchLdNull())
		{
			if (inst.Kind == ComparisonKind.LessThan)
			{
				context.Step("comp(ldnull < right)  => comp(ldnull != right)", inst);
				inst.Kind = ComparisonKind.Inequality;
			}
			else if (inst.Kind == ComparisonKind.GreaterThanOrEqual)
			{
				context.Step("comp(ldnull >= right) => comp(ldnull == right)", inst);
				inst.Kind = ComparisonKind.Equality;
			}
		}
		ILInstruction iLInstruction = inst.Right.UnwrapConv(ConversionKind.SignExtend).UnwrapConv(ConversionKind.ZeroExtend);
		if (iLInstruction.MatchLdcI4(0) && inst.Sign == Sign.Unsigned && (inst.Kind == ComparisonKind.GreaterThan || inst.Kind == ComparisonKind.LessThanOrEqual))
		{
			if (inst.Kind == ComparisonKind.GreaterThan)
			{
				context.Step("comp.unsigned(left > ldc.i4 0) => comp(left != ldc.i4 0)", inst);
				inst.Kind = ComparisonKind.Inequality;
				VisitComp(inst);
				return;
			}
			if (inst.Kind == ComparisonKind.LessThanOrEqual)
			{
				context.Step("comp.unsigned(left <= ldc.i4 0) => comp(left == ldc.i4 0)", inst);
				inst.Kind = ComparisonKind.Equality;
				VisitComp(inst);
				return;
			}
		}
		else if (iLInstruction.MatchLdcI4(0) && inst.Kind.IsEqualityOrInequality())
		{
			if (inst.Left.MatchLdLen(StackType.I, out var array))
			{
				context.Step("comp(ldlen.i4 array == ldc.i4 0)", inst);
				inst.InputType = StackType.I4;
				inst.Left.ReplaceWith(new LdLen(StackType.I4, array).WithILRange(inst.Left));
				inst.Right = iLInstruction;
			}
			else if (inst.Left is Conv { TargetType: PrimitiveType.I } conv && conv.Argument.ResultType == StackType.O)
			{
				context.Step("comp(conv o->i (ldloc obj) == conv i4->i <sign extend>(ldc.i4 0))", inst);
				inst.InputType = StackType.O;
				inst.Left = conv.Argument;
				inst.Right = new LdNull().WithILRange(inst.Right);
				inst.Right.AddILRange(iLInstruction);
			}
		}
		if (inst.Right.MatchLdNull() && inst.Left.MatchBox(out arg, out var type) && type.Kind == TypeKind.TypeParameter)
		{
			if (inst.Kind == ComparisonKind.Equality)
			{
				context.Step("comp(box T(..) == ldnull) -> comp(.. == ldnull)", inst);
				inst.Left = arg;
			}
			if (inst.Kind == ComparisonKind.Inequality)
			{
				context.Step("comp(box T(..) != ldnull) -> comp(.. != ldnull)", inst);
				inst.Left = arg;
			}
		}
	}

	protected internal override void VisitConv(Conv inst)
	{
		inst.Argument.AcceptVisitor(this);
		if (inst.Argument.MatchLdLen(StackType.I, out var array) && inst.TargetType.IsIntegerType() && (!inst.CheckForOverflow || context.Settings.AssumeArrayLengthFitsIntoInt32))
		{
			context.Step("conv.i4(ldlen array) => ldlen.i4(array)", inst);
			inst.AddILRange(inst.Argument);
			inst.ReplaceWith(new LdLen(inst.TargetType.GetStackType(), array).WithILRange(inst));
		}
	}

	protected internal override void VisitBox(Box inst)
	{
		inst.Argument.AcceptVisitor(this);
		if (inst.Type.IsReferenceType == true && inst.Argument.ResultType == inst.ResultType)
		{
			context.Step("box ref-type(arg) => arg", inst);
			inst.Argument.AddILRange(inst);
			inst.ReplaceWith(inst.Argument);
		}
	}

	protected internal override void VisitLdElema(LdElema inst)
	{
		base.VisitLdElema(inst);
		CleanUpArrayIndices(inst.Indices);
	}

	protected internal override void VisitNewArr(NewArr inst)
	{
		base.VisitNewArr(inst);
		CleanUpArrayIndices(inst.Indices);
	}

	private void CleanUpArrayIndices(InstructionCollection<ILInstruction> indices)
	{
		foreach (ILInstruction index in indices)
		{
			if (index is Conv { ResultType: StackType.I } conv && ((conv.Kind == ConversionKind.Truncate && conv.CheckForOverflow) || conv.Kind == ConversionKind.ZeroExtend || conv.Kind == ConversionKind.SignExtend))
			{
				context.Step("Remove conv.i from array index", index);
				index.ReplaceWith(conv.Argument);
			}
		}
	}

	private void VisitLogicNot(Comp inst, ILInstruction arg)
	{
		ILInstruction lhs;
		ILInstruction rhs;
		if (arg is Comp comp)
		{
			if ((!comp.InputType.IsFloatType() && !comp.IsLifted) || comp.Kind.IsEqualityOrInequality())
			{
				context.Step("push negation into comparison", inst);
				comp.Kind = comp.Kind.Negate();
				comp.AddILRange(inst);
				inst.ReplaceWith(comp);
			}
			comp.AcceptVisitor(this);
		}
		else if (arg.MatchLogicAnd(out lhs, out rhs))
		{
			context.Step("push negation into logic.and", inst);
			IfInstruction ifInstruction = (IfInstruction)arg;
			ILInstruction falseInst = ifInstruction.FalseInst;
			Debug.Assert(falseInst.MatchLdcI4(0));
			ifInstruction.Condition = Comp.LogicNot(lhs).WithILRange(inst);
			ifInstruction.TrueInst = new LdcI4(1).WithILRange(falseInst);
			ifInstruction.FalseInst = Comp.LogicNot(rhs).WithILRange(inst);
			inst.ReplaceWith(ifInstruction);
			ifInstruction.AcceptVisitor(this);
		}
		else if (arg.MatchLogicOr(out lhs, out rhs))
		{
			context.Step("push negation into logic.or", inst);
			IfInstruction ifInstruction2 = (IfInstruction)arg;
			ILInstruction trueInst = ifInstruction2.TrueInst;
			Debug.Assert(trueInst.MatchLdcI4(1));
			ifInstruction2.Condition = Comp.LogicNot(lhs).WithILRange(inst);
			ifInstruction2.TrueInst = Comp.LogicNot(rhs).WithILRange(inst);
			ifInstruction2.FalseInst = new LdcI4(0).WithILRange(trueInst);
			inst.ReplaceWith(ifInstruction2);
			ifInstruction2.AcceptVisitor(this);
		}
		else
		{
			arg.AcceptVisitor(this);
		}
	}

	protected internal override void VisitCall(Call inst)
	{
		ILInstruction iLInstruction = EarlyExpressionTransforms.HandleCall(inst, context);
		if (iLInstruction != null)
		{
			iLInstruction.AcceptVisitor(this);
			return;
		}
		base.VisitCall(inst);
		TransformAssignment.HandleCompoundAssign(inst, context);
	}

	protected internal override void VisitCallVirt(CallVirt inst)
	{
		base.VisitCallVirt(inst);
		TransformAssignment.HandleCompoundAssign(inst, context);
	}

	protected internal override void VisitNewObj(NewObj inst)
	{
		ILInstruction locallocSpan;
		Block block;
		if (TransformDecimalCtorToConstant(inst, out var result))
		{
			context.Step("TransformDecimalCtorToConstant", inst);
			inst.ReplaceWith(result);
		}
		else if (TransformSpanTCtorContainingStackAlloc(inst, out locallocSpan))
		{
			inst.ReplaceWith(locallocSpan);
			block = null;
			ILInstruction iLInstruction = locallocSpan;
			while (iLInstruction.Parent != null)
			{
				if (iLInstruction.Parent is Block block2)
				{
					block = block2;
					break;
				}
				iLInstruction = iLInstruction.Parent;
			}
		}
		else if (TransformArrayInitializers.TransformSpanTArrayInitialization(inst, context, out block))
		{
			context.Step("TransformSpanTArrayInitialization: single-dim", inst);
			inst.ReplaceWith(block);
		}
		else
		{
			base.VisitNewObj(inst);
		}
	}

	private bool TransformSpanTCtorContainingStackAlloc(NewObj newObj, out ILInstruction locallocSpan)
	{
		locallocSpan = null;
		IType declaringType = newObj.Method.DeclaringType;
		if (!declaringType.IsKnownType(KnownTypeCode.SpanOfT) && !declaringType.IsKnownType(KnownTypeCode.ReadOnlySpanOfT))
		{
			return false;
		}
		if (newObj.Arguments.Count != 2 || declaringType.TypeArguments.Count != 1)
		{
			return false;
		}
		IType elementType = declaringType.TypeArguments[0];
		if (newObj.Arguments[0].MatchLocAlloc(out var argument) && MatchesElementCount(argument, elementType, newObj.Arguments[1]))
		{
			locallocSpan = new LocAllocSpan(newObj.Arguments[1], declaringType);
			return true;
		}
		if (newObj.Arguments[0] is Block { Kind: BlockKind.StackAllocInitializer } block)
		{
			if (!block.Instructions[0].MatchStLoc(out var variable, out var value))
			{
				return false;
			}
			if (!value.MatchLocAlloc(out argument) || !MatchesElementCount(argument, elementType, newObj.Arguments[1]))
			{
				return false;
			}
			ILVariable variable2 = variable.Function.RegisterVariable(VariableKind.InitializerTarget, declaringType);
			LdLoc[] array = Enumerable.ToArray<LdLoc>((IEnumerable<LdLoc>)variable.LoadInstructions);
			foreach (LdLoc ldLoc in array)
			{
				ILInstruction iLInstruction = new LdLoc(variable2);
				iLInstruction.AddILRange(ldLoc);
				if (ldLoc.Parent != block)
				{
					iLInstruction = new Conv(iLInstruction, PrimitiveType.I, checkForOverflow: false, Sign.None);
				}
				ldLoc.ReplaceWith(iLInstruction);
			}
			IStoreInstruction[] array2 = Enumerable.ToArray<IStoreInstruction>((IEnumerable<IStoreInstruction>)variable.StoreInstructions);
			foreach (IStoreInstruction storeInstruction in array2)
			{
				storeInstruction.Variable = variable2;
			}
			value.ReplaceWith(new LocAllocSpan(newObj.Arguments[1], declaringType));
			locallocSpan = block;
			return true;
		}
		return false;
	}

	private bool MatchesElementCount(ILInstruction sizeInBytesInstr, IType elementType, ILInstruction elementCountInstr2)
	{
		PointerType pointerType = new PointerType(elementType);
		ILInstruction iLInstruction = PointerArithmeticOffset.Detect(sizeInBytesInstr, pointerType, checkForOverflow: true, unwrapZeroExtension: true);
		if (!iLInstruction.Match(elementCountInstr2).Success)
		{
			return false;
		}
		return true;
	}

	private bool TransformDecimalCtorToConstant(NewObj inst, out LdcDecimal result)
	{
		IType declaringType = inst.Method.DeclaringType;
		result = null;
		if (!declaringType.IsKnownType(KnownTypeCode.Decimal))
		{
			return false;
		}
		InstructionCollection<ILInstruction> arguments = inst.Arguments;
		int value2;
		int value3;
		int value4;
		int value5;
		int value6;
		if (arguments.Count == 1)
		{
			if (arguments[0].MatchLdcI4(out var value))
			{
				result = new LdcDecimal(value);
				return true;
			}
		}
		else if (arguments.Count == 5 && arguments[0].MatchLdcI4(out value2) && arguments[1].MatchLdcI4(out value3) && arguments[2].MatchLdcI4(out value4) && arguments[3].MatchLdcI4(out value5) && arguments[4].MatchLdcI4(out value6))
		{
			result = new LdcDecimal(new decimal(value2, value3, value4, value5 != 0, checked((byte)value6)));
			return true;
		}
		return false;
	}

	protected internal override void VisitLdObj(LdObj inst)
	{
		base.VisitLdObj(inst);
		EarlyExpressionTransforms.LdObjToLdLoc(inst, context);
	}

	protected internal override void VisitStObj(StObj inst)
	{
		base.VisitStObj(inst);
		if (EarlyExpressionTransforms.StObjToStLoc(inst, context))
		{
			context.RequestRerun();
		}
		else
		{
			TransformAssignment.HandleCompoundAssign(inst, context);
		}
	}

	protected internal override void VisitIfInstruction(IfInstruction inst)
	{
		inst.TrueInst.AcceptVisitor(this);
		inst.FalseInst.AcceptVisitor(this);
		inst = HandleConditionalOperator(inst);
		if ((inst.TrueInst.MatchLdcI4(0) && !inst.FalseInst.MatchLdcI4(0)) || (inst.FalseInst.MatchLdcI4(1) && !inst.TrueInst.MatchLdcI4(1)))
		{
			context.Step("canonicalize logic and/or", inst);
			ILInstruction trueInst = inst.TrueInst;
			inst.TrueInst = inst.FalseInst;
			inst.FalseInst = trueInst;
			inst.Condition = Comp.LogicNot(inst.Condition);
		}
		inst.Condition.AcceptVisitor(this);
		if (!new NullableLiftingTransform(context).Run(inst) && !TransformDynamicAddAssignOrRemoveAssign(inst) && inst.MatchIfInstructionPositiveCondition(out var condition, out var trueInst2, out var falseInst))
		{
			ILInstruction iLInstruction = UserDefinedLogicTransform.Transform(condition, trueInst2, falseInst);
			if (iLInstruction == null)
			{
				iLInstruction = UserDefinedLogicTransform.TransformDynamic(condition, trueInst2, falseInst);
			}
			if (iLInstruction != null)
			{
				context.Step("User-defined short-circuiting logic operator (roslyn pattern)", condition);
				iLInstruction.AddILRange(inst);
				inst.ReplaceWith(iLInstruction);
			}
		}
	}

	private bool TransformDynamicAddAssignOrRemoveAssign(IfInstruction inst)
	{
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Invalid comparison between Unknown and I4
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Invalid comparison between Unknown and I4
		if (!inst.MatchIfInstructionPositiveCondition(out var condition, out var trueInst, out var falseInst))
		{
			return false;
		}
		if (!(condition is DynamicIsEventInstruction dynamicIsEventInstruction))
		{
			return false;
		}
		trueInst = Block.Unwrap(trueInst);
		falseInst = Block.Unwrap(falseInst);
		if (!(falseInst is DynamicCompoundAssign dynamicCompoundAssign))
		{
			return false;
		}
		if (!(dynamicCompoundAssign.Target is DynamicGetMemberInstruction dynamicGetMemberInstruction))
		{
			return false;
		}
		if (!dynamicIsEventInstruction.Argument.Match(dynamicGetMemberInstruction.Target).Success)
		{
			return false;
		}
		if (!SemanticHelper.IsPure(dynamicIsEventInstruction.Argument.Flags))
		{
			return false;
		}
		if (!(trueInst is DynamicInvokeMemberInstruction dynamicInvokeMemberInstruction))
		{
			return false;
		}
		if (!dynamicInvokeMemberInstruction.BinderFlags.HasFlag(CSharpBinderFlags.InvokeSpecialName) || !dynamicInvokeMemberInstruction.BinderFlags.HasFlag(CSharpBinderFlags.ResultDiscarded))
		{
			return false;
		}
		ExpressionType operation = dynamicCompoundAssign.Operation;
		if ((int)operation != 63)
		{
			if ((int)operation != 73)
			{
				return false;
			}
			if (dynamicInvokeMemberInstruction.Name != "remove_" + dynamicGetMemberInstruction.Name)
			{
				return false;
			}
		}
		else if (dynamicInvokeMemberInstruction.Name != "add_" + dynamicGetMemberInstruction.Name)
		{
			return false;
		}
		if (!dynamicCompoundAssign.Value.Match(dynamicInvokeMemberInstruction.Arguments[1]).Success)
		{
			return false;
		}
		if (!dynamicInvokeMemberInstruction.Arguments[0].Match(dynamicGetMemberInstruction.Target).Success)
		{
			return false;
		}
		context.Step("+= / -= dynamic.isevent pattern -> dynamic.compound.op", inst);
		inst.ReplaceWith(dynamicCompoundAssign);
		return true;
	}

	protected internal override void VisitDynamicSetMemberInstruction(DynamicSetMemberInstruction inst)
	{
		base.VisitDynamicSetMemberInstruction(inst);
		TransformDynamicSetMemberInstruction(inst, context);
	}

	internal static void TransformDynamicSetMemberInstruction(DynamicSetMemberInstruction inst, StatementTransformContext context)
	{
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		if (inst.BinderFlags.HasFlag(CSharpBinderFlags.ValueFromCompoundAssignment) && inst.Value is DynamicBinaryOperatorInstruction { Left: DynamicGetMemberInstruction left } dynamicBinaryOperatorInstruction && left.Target.Match(inst.Target).Success && SemanticHelper.IsPure(left.Target.Flags) && !(inst.Name != left.Name) && DynamicCompoundAssign.IsExpressionTypeSupported(dynamicBinaryOperatorInstruction.Operation))
		{
			context.Step("dynamic.setmember.compound -> dynamic.compound.op", inst);
			inst.ReplaceWith(new DynamicCompoundAssign(dynamicBinaryOperatorInstruction.Operation, dynamicBinaryOperatorInstruction.BinderFlags, dynamicBinaryOperatorInstruction.Left, dynamicBinaryOperatorInstruction.LeftArgumentInfo, dynamicBinaryOperatorInstruction.Right, dynamicBinaryOperatorInstruction.RightArgumentInfo));
		}
	}

	protected internal override void VisitDynamicSetIndexInstruction(DynamicSetIndexInstruction inst)
	{
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		base.VisitDynamicSetIndexInstruction(inst);
		checked
		{
			if (!inst.BinderFlags.HasFlag(CSharpBinderFlags.ValueFromCompoundAssignment) || !(inst.Arguments.LastOrDefault() is DynamicBinaryOperatorInstruction { Left: DynamicGetIndexInstruction left } dynamicBinaryOperatorInstruction) || inst.Arguments.Count != left.Arguments.Count + 1)
			{
				return;
			}
			for (int i = 0; i < left.Arguments.Count; i++)
			{
				if (!SemanticHelper.IsPure(left.Arguments[i].Flags) || !left.Arguments[i].Match(left.Arguments[i]).Success)
				{
					return;
				}
			}
			if (DynamicCompoundAssign.IsExpressionTypeSupported(dynamicBinaryOperatorInstruction.Operation))
			{
				context.Step("dynamic.setindex.compound -> dynamic.compound.op", inst);
				inst.ReplaceWith(new DynamicCompoundAssign(dynamicBinaryOperatorInstruction.Operation, dynamicBinaryOperatorInstruction.BinderFlags, dynamicBinaryOperatorInstruction.Left, dynamicBinaryOperatorInstruction.LeftArgumentInfo, dynamicBinaryOperatorInstruction.Right, dynamicBinaryOperatorInstruction.RightArgumentInfo));
			}
		}
	}

	private IfInstruction HandleConditionalOperator(IfInstruction inst)
	{
		if (!(inst.TrueInst is Block block) || block.Instructions.Count != 1)
		{
			return inst;
		}
		if (!(inst.FalseInst is Block block2) || block2.Instructions.Count != 1)
		{
			return inst;
		}
		if (block.Instructions[0].MatchStLoc(out var variable, out var value) && block2.Instructions[0].MatchStLoc(variable, out var value2))
		{
			context.Step("conditional operator", inst);
			IfInstruction ifInstruction = new IfInstruction(Comp.LogicNot(inst.Condition), value2, value);
			ifInstruction.AddILRange(inst);
			inst.ReplaceWith(new StLoc(variable, ifInstruction));
			context.RequestRerun();
			return ifInstruction;
		}
		return inst;
	}

	protected internal override void VisitBinaryNumericInstruction(BinaryNumericInstruction inst)
	{
		base.VisitBinaryNumericInstruction(inst);
		switch (inst.Operator)
		{
		case BinaryNumericOperator.ShiftLeft:
		case BinaryNumericOperator.ShiftRight:
		{
			if (inst.Right.MatchBinaryNumericInstruction(BinaryNumericOperator.BitAnd, out var left, out var right) && right.MatchLdcI4((inst.ResultType == StackType.I8) ? 63 : 31))
			{
				context.Step("Combine bit.and into shift", inst);
				inst.Right = left;
			}
			break;
		}
		case BinaryNumericOperator.BitAnd:
			if (inst.Left.InferType(context.TypeSystem).IsKnownType(KnownTypeCode.Boolean) && inst.Right.InferType(context.TypeSystem).IsKnownType(KnownTypeCode.Boolean) && !new NullableLiftingTransform(context).Run(inst) && SemanticHelper.IsPure(inst.Right.Flags))
			{
				context.Step("Replace bit.and with logic.and", inst);
				IfInstruction ifInstruction = IfInstruction.LogicAnd(inst.Left, inst.Right);
				inst.ReplaceWith(ifInstruction);
				ifInstruction.AcceptVisitor(this);
			}
			break;
		}
	}

	protected internal override void VisitTryCatchHandler(TryCatchHandler inst)
	{
		base.VisitTryCatchHandler(inst);
		if (inst.Filter is BlockContainer blockContainer && blockContainer.Blocks.Count == 1)
		{
			TransformCatchWhen(inst, blockContainer.EntryPoint);
		}
		if (inst.Body is BlockContainer blockContainer2)
		{
			TransformCatchVariable(inst, blockContainer2.EntryPoint);
		}
	}

	private void TransformCatchVariable(TryCatchHandler handler, Block entryPoint)
	{
		if (entryPoint.Instructions[0].MatchStLoc(out var variable, out var value) && variable.IsSingleDefinition && variable.Kind == VariableKind.Local && value.MatchLdLoc(handler.Variable) && handler.Variable.IsSingleDefinition && handler.Variable.LoadCount == 1)
		{
			handler.Variable = variable;
			variable.Kind = VariableKind.ExceptionLocal;
			entryPoint.Instructions.RemoveAt(0);
		}
	}

	private void TransformCatchWhen(TryCatchHandler handler, Block entryPoint)
	{
		TransformCatchVariable(handler, entryPoint);
		if (entryPoint.Instructions.Count == 1 && entryPoint.Instructions[0].MatchLeave(out var _, out var value))
		{
			handler.Filter = value;
		}
	}
}
