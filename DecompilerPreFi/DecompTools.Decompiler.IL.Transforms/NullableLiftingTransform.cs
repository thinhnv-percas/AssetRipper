#define DEBUG
#define STEP
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DecompTools.Decompiler.CSharp.Resolver;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.IL.Transforms;

internal struct NullableLiftingTransform
{
	private struct CompOrDecimal
	{
		public ILInstruction Instruction;

		public ComparisonKind Kind;

		public ILInstruction Left;

		public ILInstruction Right;

		public IType LeftExpectedType
		{
			get
			{
				if (Instruction is Call call)
				{
					return call.Method.Parameters[0].Type;
				}
				return SpecialType.UnknownType;
			}
		}

		public IType RightExpectedType
		{
			get
			{
				if (Instruction is Call call)
				{
					return call.Method.Parameters[1].Type;
				}
				return SpecialType.UnknownType;
			}
		}

		internal ILInstruction MakeLifted(ComparisonKind newComparisonKind, ILInstruction left, ILInstruction right)
		{
			if (Instruction is Comp comp)
			{
				return new Comp(newComparisonKind, ComparisonLiftingKind.CSharp, comp.InputType, comp.Sign, left, right).WithILRange(Instruction);
			}
			Call call;
			if ((call = Instruction as Call) != null)
			{
				IMethod method;
				if (newComparisonKind == Kind)
				{
					method = call.Method;
				}
				else
				{
					if (newComparisonKind != ComparisonKind.Inequality || !(call.Method.Name == "op_Equality"))
					{
						return null;
					}
					method = Enumerable.FirstOrDefault<IMethod>(call.Method.DeclaringType.GetMethods((IMethod m) => m.Name == "op_Inequality"), (Func<IMethod, bool>)((IMethod m) => ParameterListComparer.Instance.Equals(m.Parameters, call.Method.Parameters)));
					if (method == null)
					{
						return null;
					}
				}
				return new Call(CSharpOperators.LiftUserDefinedOperator(method))
				{
					Arguments = { left, right },
					ConstrainedTo = call.ConstrainedTo,
					ILStackWasEmpty = call.ILStackWasEmpty,
					IsTail = call.IsTail
				}.WithILRange(call);
			}
			return null;
		}
	}

	private readonly ILTransformContext context;

	private List<ILVariable> nullableVars;

	public NullableLiftingTransform(ILTransformContext context)
	{
		this.context = context;
		nullableVars = null;
	}

	public bool Run(IfInstruction ifInst)
	{
		ILInstruction iLInstruction = Lift(ifInst, ifInst.Condition, ifInst.TrueInst, ifInst.FalseInst);
		if (iLInstruction != null)
		{
			ifInst.ReplaceWith(iLInstruction);
			return true;
		}
		return false;
	}

	public bool Run(BinaryNumericInstruction bni)
	{
		Debug.Assert(!bni.IsLifted && bni.Operator == BinaryNumericOperator.BitAnd);
		ILInstruction iLInstruction = Lift(bni, bni.Left, bni.Right, new LdcI4(0));
		if (iLInstruction != null)
		{
			bni.ReplaceWith(iLInstruction);
			return true;
		}
		return false;
	}

	public bool RunStatements(Block block, int pos)
	{
		checked
		{
			if (pos != block.Instructions.Count - 2)
			{
				return false;
			}
			if (!(block.Instructions[pos] is IfInstruction ifInstruction))
			{
				return false;
			}
			if (!(Block.Unwrap(ifInstruction.TrueInst) is Leave leave))
			{
				return false;
			}
			if (!ifInstruction.FalseInst.MatchNop())
			{
				return false;
			}
			if (!(block.Instructions[pos + 1] is Leave leave2))
			{
				return false;
			}
			if (leave2.TargetContainer != leave.TargetContainer)
			{
				return false;
			}
			ILInstruction iLInstruction = Lift(ifInstruction, ifInstruction.Condition, leave.Value, leave2.Value);
			if (iLInstruction != null)
			{
				leave.Value = iLInstruction;
				ifInstruction.ReplaceWith(leave);
				block.Instructions.Remove(leave2);
				return true;
			}
			return false;
		}
	}

	private bool AnalyzeCondition(ILInstruction condition)
	{
		if (MatchHasValueCall(condition, out ILVariable v))
		{
			if (nullableVars == null)
			{
				nullableVars = new List<ILVariable>();
			}
			nullableVars.Add(v);
			return true;
		}
		if (condition is BinaryNumericInstruction binaryNumericInstruction)
		{
			if (binaryNumericInstruction.Operator != BinaryNumericOperator.BitAnd || binaryNumericInstruction.ResultType != StackType.I4)
			{
				return false;
			}
			return AnalyzeCondition(binaryNumericInstruction.Left) && AnalyzeCondition(binaryNumericInstruction.Right);
		}
		return false;
	}

	private ILInstruction Lift(ILInstruction ifInst, ILInstruction condition, ILInstruction trueInst, ILInstruction falseInst)
	{
		ILInstruction arg;
		while (condition.MatchLogicNot(out arg))
		{
			condition = arg;
			ExtensionMethods.Swap(ref trueInst, ref falseInst);
		}
		if (context.Settings.NullPropagation && !NullPropagationTransform.IsProtectedIfInst(ifInst as IfInstruction))
		{
			ILInstruction iLInstruction = new NullPropagationTransform(context).Run(condition, trueInst, falseInst)?.WithILRange(ifInst);
			if (iLInstruction != null)
			{
				return iLInstruction;
			}
		}
		if (!context.Settings.LiftNullables)
		{
			return null;
		}
		if (AnalyzeCondition(condition))
		{
			return LiftNormal(trueInst, falseInst)?.WithILRange(ifInst);
		}
		if (MatchCompOrDecimal(condition, out var result))
		{
			if (result.Kind.IsEqualityOrInequality())
			{
				if (result.Kind == ComparisonKind.Inequality)
				{
					ExtensionMethods.Swap(ref trueInst, ref falseInst);
				}
				if (falseInst.MatchLdcI4(0))
				{
					return LiftCSharpEqualityComparison(result, ComparisonKind.Equality, trueInst) ?? LiftCSharpUserEqualityComparison(result, ComparisonKind.Equality, trueInst);
				}
				if (falseInst.MatchLdcI4(1))
				{
					return LiftCSharpEqualityComparison(result, ComparisonKind.Inequality, trueInst) ?? LiftCSharpUserEqualityComparison(result, ComparisonKind.Inequality, trueInst);
				}
				if (IsGenericNewPattern(result.Left, result.Right, trueInst, falseInst))
				{
					return trueInst;
				}
			}
			else
			{
				if (falseInst.MatchLdcI4(0) && AnalyzeCondition(trueInst))
				{
					return LiftCSharpComparison(result, result.Kind);
				}
				if (trueInst.MatchLdcI4(0) && AnalyzeCondition(falseInst))
				{
					return LiftCSharpComparison(result, result.Kind.Negate());
				}
			}
		}
		if (MatchGetValueOrDefault(condition, out ILVariable v) && NullableType.GetUnderlyingType(v.Type).IsKnownType(KnownTypeCode.Boolean))
		{
			if (MatchHasValueCall(trueInst, v) && falseInst.MatchLdcI4(0))
			{
				context.Step("NullableLiftingTransform: v == true", ifInst);
				return new Comp(ComparisonKind.Equality, ComparisonLiftingKind.CSharp, StackType.I4, Sign.None, new LdLoc(v).WithILRange(trueInst), new LdcI4(1).WithILRange(falseInst)).WithILRange(ifInst);
			}
			if (trueInst.MatchLdcI4(0) && MatchHasValueCall(falseInst, v))
			{
				context.Step("NullableLiftingTransform: v == false", ifInst);
				return new Comp(ComparisonKind.Equality, ComparisonLiftingKind.CSharp, StackType.I4, Sign.None, new LdLoc(v).WithILRange(falseInst), trueInst).WithILRange(ifInst);
			}
			if (MatchNegatedHasValueCall(trueInst, v) && falseInst.MatchLdcI4(1))
			{
				context.Step("NullableLiftingTransform: v != true", ifInst);
				return new Comp(ComparisonKind.Inequality, ComparisonLiftingKind.CSharp, StackType.I4, Sign.None, new LdLoc(v).WithILRange(trueInst), falseInst).WithILRange(ifInst);
			}
			if (trueInst.MatchLdcI4(1) && MatchNegatedHasValueCall(falseInst, v))
			{
				context.Step("NullableLiftingTransform: v != false", ifInst);
				return new Comp(ComparisonKind.Inequality, ComparisonLiftingKind.CSharp, StackType.I4, Sign.None, new LdLoc(v).WithILRange(falseInst), new LdcI4(0).WithILRange(trueInst)).WithILRange(ifInst);
			}
		}
		IType underlyingType2;
		ILInstruction arg3;
		if (trueInst.MatchLdLoc(out v))
		{
			if (MatchNullableCtor(falseInst, out var underlyingType, out var arg2) && underlyingType.IsKnownType(KnownTypeCode.Boolean) && arg2.MatchLdcI4(0))
			{
				context.Step("NullableLiftingTransform: 3vl.bool.and(bool, bool?)", ifInst);
				return new ThreeValuedBoolAnd(condition, trueInst).WithILRange(ifInst);
			}
			if (falseInst.MatchLdLoc(out var variable) && MatchThreeValuedLogicConditionPattern(condition, out var nullable, out var nullable2))
			{
				if (v == nullable && variable == nullable2)
				{
					context.Step("NullableLiftingTransform: 3vl.bool.or(bool?, bool?)", ifInst);
					return new ThreeValuedBoolOr(trueInst, falseInst).WithILRange(ifInst);
				}
				if (v == nullable2 && variable == nullable)
				{
					context.Step("NullableLiftingTransform: 3vl.bool.and(bool?, bool?)", ifInst);
					return new ThreeValuedBoolAnd(falseInst, trueInst).WithILRange(ifInst);
				}
			}
		}
		else if (falseInst.MatchLdLoc(out v) && MatchNullableCtor(trueInst, out underlyingType2, out arg3) && underlyingType2.IsKnownType(KnownTypeCode.Boolean) && arg3.MatchLdcI4(1))
		{
			context.Step("NullableLiftingTransform: 3vl.logic.or(bool, bool?)", ifInst);
			return new ThreeValuedBoolOr(condition, falseInst).WithILRange(ifInst);
		}
		return null;
	}

	private bool IsGenericNewPattern(ILInstruction compLeft, ILInstruction compRight, ILInstruction trueInst, ILInstruction falseInst)
	{
		IType type;
		IType type2;
		return falseInst.MatchDefaultValue(out type) && trueInst is Call call && call.Method.FullName == "System.Activator.CreateInstance" && call.Method.TypeArguments.Count == 1 && type.Kind == TypeKind.TypeParameter && compLeft.MatchDefaultValue(out type2) && type.Equals(type2) && compRight.MatchLdNull();
	}

	private bool MatchThreeValuedLogicConditionPattern(ILInstruction condition, out ILVariable nullable1, out ILVariable nullable2)
	{
		nullable1 = null;
		nullable2 = null;
		if (!condition.MatchLogicOr(out var lhs, out var rhs))
		{
			return false;
		}
		if (!MatchGetValueOrDefault(lhs, out nullable1))
		{
			return false;
		}
		if (!NullableType.GetUnderlyingType(nullable1.Type).IsKnownType(KnownTypeCode.Boolean))
		{
			return false;
		}
		if (!rhs.MatchLogicAnd(out lhs, out rhs))
		{
			return false;
		}
		if (!lhs.MatchLogicNot(out var arg))
		{
			return false;
		}
		if (!MatchGetValueOrDefault(arg, out nullable2))
		{
			return false;
		}
		if (!NullableType.GetUnderlyingType(nullable2.Type).IsKnownType(KnownTypeCode.Boolean))
		{
			return false;
		}
		if (!rhs.MatchLogicNot(out arg))
		{
			return false;
		}
		return MatchHasValueCall(arg, nullable1);
	}

	private static bool MatchCompOrDecimal(ILInstruction inst, out CompOrDecimal result)
	{
		result = default(CompOrDecimal);
		result.Instruction = inst;
		if (inst is Comp { IsLifted: false } comp)
		{
			result.Kind = comp.Kind;
			result.Left = comp.Left;
			result.Right = comp.Right;
			return true;
		}
		if (inst is Call call && call.Method.IsOperator && call.Arguments.Count == 2 && !call.IsLifted)
		{
			switch (call.Method.Name)
			{
			case "op_Equality":
				result.Kind = ComparisonKind.Equality;
				break;
			case "op_Inequality":
				result.Kind = ComparisonKind.Inequality;
				break;
			case "op_LessThan":
				result.Kind = ComparisonKind.LessThan;
				break;
			case "op_LessThanOrEqual":
				result.Kind = ComparisonKind.LessThanOrEqual;
				break;
			case "op_GreaterThan":
				result.Kind = ComparisonKind.GreaterThan;
				break;
			case "op_GreaterThanOrEqual":
				result.Kind = ComparisonKind.GreaterThanOrEqual;
				break;
			default:
				return false;
			}
			result.Left = call.Arguments[0];
			result.Right = call.Arguments[1];
			return call.Method.DeclaringType.IsKnownType(KnownTypeCode.Decimal);
		}
		return false;
	}

	private ILInstruction LiftCSharpEqualityComparison(CompOrDecimal valueComp, ComparisonKind newComparisonKind, ILInstruction hasValueTest)
	{
		Debug.Assert(newComparisonKind.IsEqualityOrInequality());
		bool flag = false;
		ILInstruction arg;
		while (hasValueTest.MatchLogicNot(out arg))
		{
			hasValueTest = arg;
			flag = !flag;
		}
		if (hasValueTest is Comp comp)
		{
			if ((flag ? comp.Kind.Negate() : comp.Kind) != newComparisonKind)
			{
				return null;
			}
			if (!MatchHasValueCall(comp.Left, out ILVariable v))
			{
				return null;
			}
			if (!MatchHasValueCall(comp.Right, out ILVariable v2))
			{
				return null;
			}
			nullableVars = new List<ILVariable> { v };
			var (iLInstruction, bitSet) = DoLift(valueComp.Left);
			nullableVars[0] = v2;
			var (iLInstruction2, bitSet2) = DoLift(valueComp.Right);
			if (iLInstruction != null && iLInstruction2 != null && bitSet[0] && bitSet2[0] && SemanticHelper.IsPure(iLInstruction.Flags) && SemanticHelper.IsPure(iLInstruction2.Flags))
			{
				context.Step("NullableLiftingTransform: C# (in)equality comparison", valueComp.Instruction);
				return valueComp.MakeLifted(newComparisonKind, iLInstruction, iLInstruction2);
			}
		}
		else
		{
			if (newComparisonKind == ComparisonKind.Equality && !flag && MatchHasValueCall(hasValueTest, out ILVariable v3))
			{
				nullableVars = new List<ILVariable> { v3 };
				return LiftCSharpComparison(valueComp, newComparisonKind);
			}
			if (((newComparisonKind == ComparisonKind.Inequality) & flag) && MatchHasValueCall(hasValueTest, out v3))
			{
				nullableVars = new List<ILVariable> { v3 };
				return LiftCSharpComparison(valueComp, newComparisonKind);
			}
		}
		return null;
	}

	private ILInstruction LiftCSharpComparison(CompOrDecimal comp, ComparisonKind newComparisonKind)
	{
		var (iLInstruction, iLInstruction2, bitSet) = DoLiftBinary(comp.Left, comp.Right, comp.LeftExpectedType, comp.RightExpectedType);
		if (iLInstruction != null && iLInstruction2 != null && SemanticHelper.IsPure(iLInstruction.Flags) && SemanticHelper.IsPure(iLInstruction2.Flags))
		{
			if (!bitSet.All(0, nullableVars.Count))
			{
				return null;
			}
			context.Step("NullableLiftingTransform: C# comparison", comp.Instruction);
			return comp.MakeLifted(newComparisonKind, iLInstruction, iLInstruction2);
		}
		return null;
	}

	private Call LiftCSharpUserEqualityComparison(CompOrDecimal hasValueComp, ComparisonKind newComparisonKind, ILInstruction nestedIfInst)
	{
		if (!MatchHasValueCall(hasValueComp.Left, out ILVariable v))
		{
			return null;
		}
		if (!MatchHasValueCall(hasValueComp.Right, out ILVariable v2))
		{
			return null;
		}
		if (!nestedIfInst.MatchIfInstructionPositiveCondition(out var condition, out var trueInst, out var falseInst))
		{
			return null;
		}
		if (!MatchHasValueCall(condition, out ILVariable v3))
		{
			return null;
		}
		if (v3 != v && v3 != v2)
		{
			return null;
		}
		if (!falseInst.MatchLdcI4((newComparisonKind == ComparisonKind.Equality) ? 1 : 0))
		{
			return null;
		}
		if (!(trueInst is Call call))
		{
			return null;
		}
		if (!call.Method.IsOperator || call.Arguments.Count != 2)
		{
			return null;
		}
		if (call.Method.Name != ((newComparisonKind == ComparisonKind.Equality) ? "op_Equality" : "op_Inequality"))
		{
			return null;
		}
		IMethod method = CSharpOperators.LiftUserDefinedOperator(call.Method);
		if (method == null)
		{
			return null;
		}
		nullableVars = new List<ILVariable> { v };
		var (iLInstruction, bitSet) = DoLift(call.Arguments[0]);
		nullableVars[0] = v2;
		var (iLInstruction2, bitSet2) = DoLift(call.Arguments[1]);
		if (iLInstruction != null && iLInstruction2 != null && bitSet[0] && bitSet2[0] && SemanticHelper.IsPure(iLInstruction.Flags) && SemanticHelper.IsPure(iLInstruction2.Flags))
		{
			context.Step("NullableLiftingTransform: C# user-defined (in)equality comparison", nestedIfInst);
			return new Call(method)
			{
				Arguments = { iLInstruction, iLInstruction2 },
				ConstrainedTo = call.ConstrainedTo,
				ILStackWasEmpty = call.ILStackWasEmpty,
				IsTail = call.IsTail
			}.WithILRange(call);
		}
		return null;
	}

	private ILInstruction LiftNormal(ILInstruction trueInst, ILInstruction falseInst)
	{
		if (trueInst.MatchIfInstructionPositiveCondition(out var condition, out var trueInst2, out var _) && MatchHasValueCall(condition, out ILVariable v) && nullableVars.Contains(v))
		{
			trueInst = trueInst2;
		}
		bool flag = false;
		if (!MatchNullableCtor(trueInst, out var underlyingType, out var arg))
		{
			flag = true;
			underlyingType = context.TypeSystem.FindType(trueInst.ResultType.ToKnownTypeCode());
			arg = trueInst;
			if (nullableVars.Count == 1 && arg.MatchLdLoc(nullableVars[0]))
			{
				context.Step("v.HasValue ? v : fallback => v ?? fallback", trueInst);
				return new NullCoalescingInstruction(NullCoalescingKind.Nullable, trueInst, falseInst)
				{
					UnderlyingResultType = NullableType.GetUnderlyingType(nullableVars[0].Type).GetStackType()
				};
			}
			if (trueInst is Call { IsLifted: false } call && CSharpOperators.IsComparisonOperator(call.Method) && falseInst.MatchLdcI4((call.Method.Name == "op_Inequality") ? 1 : 0))
			{
				IMethod method = CSharpOperators.LiftUserDefinedOperator(call.Method);
				if ((call.Method.Name == "op_Equality" || call.Method.Name == "op_Inequality") && nullableVars.Count != 1)
				{
					method = null;
				}
				if (method != null)
				{
					context.Step("Lift user-defined comparison operator", trueInst);
					var (iLInstruction, iLInstruction2, bitSet) = DoLiftBinary(call.Arguments[0], call.Arguments[1], call.Method.Parameters[0].Type, call.Method.Parameters[1].Type);
					if (iLInstruction != null && iLInstruction2 != null && bitSet.All(0, nullableVars.Count))
					{
						return new Call(method)
						{
							Arguments = { iLInstruction, iLInstruction2 },
							ConstrainedTo = call.ConstrainedTo,
							ILStackWasEmpty = call.ILStackWasEmpty,
							IsTail = call.IsTail
						}.WithILRange(call);
					}
				}
			}
		}
		ILInstruction iLInstruction3;
		if (nullableVars.Count == 1 && MatchGetValueOrDefault(arg, nullableVars[0]))
		{
			context.Step("v.HasValue ? v.GetValueOrDefault() : fallback => v ?? fallback", trueInst);
			IType underlyingType2 = NullableType.GetUnderlyingType(nullableVars[0].Type);
			iLInstruction3 = new LdLoc(nullableVars[0]);
			if (!underlyingType2.Equals(underlyingType) && underlyingType.ToPrimitiveType() != PrimitiveType.None)
			{
				iLInstruction3 = new Conv(iLInstruction3, underlyingType2.GetStackType(), underlyingType2.GetSign(), underlyingType.ToPrimitiveType(), checkForOverflow: false, isLifted: true);
			}
		}
		else
		{
			context.Step("NullableLiftingTransform.DoLift", trueInst);
			BitSet bitSet2;
			(iLInstruction3, bitSet2) = DoLift(arg);
			if (iLInstruction3 == null)
			{
				return null;
			}
			if (!bitSet2.All(0, nullableVars.Count))
			{
				return null;
			}
			Debug.Assert(iLInstruction3 is ILiftableInstruction { IsLifted: not false } liftableInstruction && liftableInstruction.UnderlyingResultType == arg.ResultType);
		}
		if (flag)
		{
			iLInstruction3 = new NullCoalescingInstruction(NullCoalescingKind.NullableWithValueFallback, iLInstruction3, falseInst)
			{
				UnderlyingResultType = arg.ResultType
			};
		}
		else if (!MatchNull(falseInst, underlyingType))
		{
			iLInstruction3 = new NullCoalescingInstruction(NullCoalescingKind.Nullable, iLInstruction3, falseInst)
			{
				UnderlyingResultType = arg.ResultType
			};
		}
		return iLInstruction3;
	}

	private (ILInstruction, BitSet) DoLift(ILInstruction inst)
	{
		if (MatchGetValueOrDefault(inst, out ILVariable v))
		{
			BitSet bitSet = new BitSet(nullableVars.Count);
			for (int i = 0; i < nullableVars.Count; i = checked(i + 1))
			{
				if (nullableVars[i] == v)
				{
					bitSet[i] = true;
				}
			}
			if (bitSet.Any())
			{
				return (new LdLoc(v).WithILRange(inst), bitSet);
			}
			return (null, null);
		}
		if (inst is Conv conv)
		{
			var (iLInstruction, bitSet2) = DoLift(conv.Argument);
			if (iLInstruction != null)
			{
				if (conv.HasDirectFlag(InstructionFlags.MayThrow) && !bitSet2.All(0, nullableVars.Count))
				{
					return (null, null);
				}
				Conv item = new Conv(iLInstruction, conv.InputType, conv.InputSign, conv.TargetType, conv.CheckForOverflow, isLifted: true).WithILRange(conv);
				return (item, bitSet2);
			}
		}
		else if (inst is BitNot bitNot)
		{
			var (iLInstruction2, item2) = DoLift(bitNot.Argument);
			if (iLInstruction2 != null)
			{
				BitNot item3 = new BitNot(iLInstruction2, isLifted: true, bitNot.ResultType).WithILRange(bitNot);
				return (item3, item2);
			}
		}
		else if (inst is BinaryNumericInstruction binaryNumericInstruction)
		{
			var (iLInstruction3, iLInstruction4, bitSet3) = DoLiftBinary(binaryNumericInstruction.Left, binaryNumericInstruction.Right, SpecialType.UnknownType, SpecialType.UnknownType);
			if (iLInstruction3 != null && iLInstruction4 != null)
			{
				if (binaryNumericInstruction.HasDirectFlag(InstructionFlags.MayThrow) && !bitSet3.All(0, nullableVars.Count))
				{
					return (null, null);
				}
				BinaryNumericInstruction item4 = new BinaryNumericInstruction(binaryNumericInstruction.Operator, iLInstruction3, iLInstruction4, binaryNumericInstruction.LeftInputType, binaryNumericInstruction.RightInputType, binaryNumericInstruction.CheckForOverflow, binaryNumericInstruction.Sign, isLifted: true).WithILRange(binaryNumericInstruction);
				return (item4, bitSet3);
			}
		}
		else
		{
			if (inst is Comp { IsLifted: false, Kind: ComparisonKind.Equality } comp && MatchGetValueOrDefault(comp.Left, out ILVariable v2) && NullableType.GetUnderlyingType(v2.Type).IsKnownType(KnownTypeCode.Boolean) && comp.Right.MatchLdcI4(0))
			{
				var (iLInstruction5, item5) = DoLift(comp.Left);
				Debug.Assert(iLInstruction5 != null);
				Comp item6 = new Comp(comp.Kind, ComparisonLiftingKind.ThreeValuedLogic, comp.InputType, comp.Sign, iLInstruction5, comp.Right.Clone()).WithILRange(comp);
				return (item6, item5);
			}
			if (inst is Call call && call.Method.IsOperator)
			{
				IMethod method = CSharpOperators.LiftUserDefinedOperator(call.Method);
				if (method == null || !NullableType.IsNullable(method.ReturnType))
				{
					return (null, null);
				}
				ILInstruction[] values;
				BitSet bitSet4;
				if (call.Arguments.Count == 1)
				{
					(ILInstruction, BitSet) tuple5 = DoLift(call.Arguments[0]);
					ILInstruction item7 = tuple5.Item1;
					BitSet item8 = tuple5.Item2;
					values = new ILInstruction[1] { item7 };
					bitSet4 = item8;
				}
				else
				{
					if (call.Arguments.Count != 2)
					{
						return (null, null);
					}
					(ILInstruction, ILInstruction, BitSet) tuple6 = DoLiftBinary(call.Arguments[0], call.Arguments[1], call.Method.Parameters[0].Type, call.Method.Parameters[1].Type);
					ILInstruction item9 = tuple6.Item1;
					ILInstruction item10 = tuple6.Item2;
					BitSet item11 = tuple6.Item3;
					values = new ILInstruction[2] { item9, item10 };
					bitSet4 = item11;
				}
				if (bitSet4 == null || !bitSet4.All(0, nullableVars.Count))
				{
					return (null, null);
				}
				Call call2 = new Call(method)
				{
					ConstrainedTo = call.ConstrainedTo,
					IsTail = call.IsTail,
					ILStackWasEmpty = call.ILStackWasEmpty
				}.WithILRange(call);
				call2.Arguments.AddRange(values);
				return (call2, bitSet4);
			}
		}
		return (null, null);
	}

	private (ILInstruction, ILInstruction, BitSet) DoLiftBinary(ILInstruction lhs, ILInstruction rhs, IType leftExpectedType, IType rightExpectedType)
	{
		var (iLInstruction, bitSet) = DoLift(lhs);
		var (iLInstruction2, bitSet2) = DoLift(rhs);
		if (iLInstruction != null && iLInstruction2 == null && SemanticHelper.IsPure(rhs.Flags))
		{
			iLInstruction2 = NewNullable(rhs.Clone(), rightExpectedType);
		}
		if (iLInstruction == null && iLInstruction2 != null && SemanticHelper.IsPure(lhs.Flags))
		{
			iLInstruction = NewNullable(lhs.Clone(), leftExpectedType);
		}
		if (iLInstruction != null && iLInstruction2 != null)
		{
			BitSet bitSet3 = bitSet ?? bitSet2;
			if (bitSet2 != null)
			{
				bitSet3.UnionWith(bitSet2);
			}
			return (iLInstruction, iLInstruction2, bitSet3);
		}
		return (null, null, null);
	}

	private ILInstruction NewNullable(ILInstruction inst, IType underlyingType)
	{
		if (underlyingType == SpecialType.UnknownType)
		{
			return inst;
		}
		ITypeDefinition definition = context.TypeSystem.FindType(KnownTypeCode.NullableOfT).GetDefinition();
		IMethod method = ((definition != null) ? Enumerable.FirstOrDefault<IMethod>(definition.Methods, (Func<IMethod, bool>)((IMethod m) => m.IsConstructor && m.Parameters.Count == 1)) : null);
		if (method != null)
		{
			method = method.Specialize(new TypeParameterSubstitution(new IType[1] { underlyingType }, null));
			return new NewObj(method)
			{
				Arguments = { inst }
			};
		}
		return inst;
	}

	internal static bool MatchHasValueCall(ILInstruction inst, out ILInstruction arg)
	{
		arg = null;
		if (!(inst is Call call))
		{
			return false;
		}
		if (call.Arguments.Count != 1)
		{
			return false;
		}
		if (call.Method.Name != "get_HasValue")
		{
			return false;
		}
		ITypeDefinition declaringTypeDefinition = call.Method.DeclaringTypeDefinition;
		if (declaringTypeDefinition == null || declaringTypeDefinition.KnownTypeCode != KnownTypeCode.NullableOfT)
		{
			return false;
		}
		arg = call.Arguments[0];
		return true;
	}

	internal static bool MatchHasValueCall(ILInstruction inst, out ILVariable v)
	{
		if (MatchHasValueCall(inst, out ILInstruction arg))
		{
			return arg.MatchLdLoca(out v);
		}
		v = null;
		return false;
	}

	internal static bool MatchHasValueCall(ILInstruction inst, ILVariable v)
	{
		ILVariable v2;
		return MatchHasValueCall(inst, out v2) && v == v2;
	}

	private static bool MatchNegatedHasValueCall(ILInstruction inst, ILVariable v)
	{
		ILInstruction arg;
		return inst.MatchLogicNot(out arg) && MatchHasValueCall(arg, v);
	}

	internal static bool MatchNullableCtor(ILInstruction inst, out IType underlyingType, out ILInstruction arg)
	{
		underlyingType = null;
		arg = null;
		if (!(inst is NewObj newObj))
		{
			return false;
		}
		if (!newObj.Method.IsConstructor || newObj.Arguments.Count != 1)
		{
			return false;
		}
		ITypeDefinition declaringTypeDefinition = newObj.Method.DeclaringTypeDefinition;
		if (declaringTypeDefinition == null || declaringTypeDefinition.KnownTypeCode != KnownTypeCode.NullableOfT)
		{
			return false;
		}
		arg = newObj.Arguments[0];
		underlyingType = NullableType.GetUnderlyingType(newObj.Method.DeclaringType);
		return true;
	}

	internal static bool MatchGetValueOrDefault(ILInstruction inst, out ILInstruction arg)
	{
		arg = null;
		if (!(inst is Call call))
		{
			return false;
		}
		if (call.Method.Name != "GetValueOrDefault" || call.Arguments.Count != 1)
		{
			return false;
		}
		ITypeDefinition declaringTypeDefinition = call.Method.DeclaringTypeDefinition;
		if (declaringTypeDefinition == null || declaringTypeDefinition.KnownTypeCode != KnownTypeCode.NullableOfT)
		{
			return false;
		}
		arg = call.Arguments[0];
		return true;
	}

	internal static bool MatchGetValueOrDefault(ILInstruction inst, out ILVariable v)
	{
		v = null;
		ILInstruction arg;
		return MatchGetValueOrDefault(inst, out arg) && arg.MatchLdLoca(out v);
	}

	internal static bool MatchGetValueOrDefault(ILInstruction inst, ILVariable v)
	{
		ILVariable v2;
		return MatchGetValueOrDefault(inst, out v2) && v == v2;
	}

	private static bool MatchNull(ILInstruction inst, out IType underlyingType)
	{
		underlyingType = null;
		if (inst.MatchDefaultValue(out var type))
		{
			underlyingType = NullableType.GetUnderlyingType(type);
			return NullableType.IsNullable(type);
		}
		underlyingType = null;
		return false;
	}

	private static bool MatchNull(ILInstruction inst, IType underlyingType)
	{
		IType underlyingType2;
		return MatchNull(inst, out underlyingType2) && underlyingType2.Equals(underlyingType);
	}
}
