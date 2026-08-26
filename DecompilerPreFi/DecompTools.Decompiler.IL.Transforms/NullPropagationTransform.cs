#define DEBUG
#define STEP
using System;
using System.Diagnostics;
using DecompTools.Decompiler.CSharp.Transforms;
using DecompTools.Decompiler.CSharp.TypeSystem;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL.Transforms;

internal struct NullPropagationTransform
{
	private enum Mode
	{
		ReferenceType,
		NullableByValue,
		NullableByReference
	}

	private readonly ILTransformContext context;

	internal static bool IsProtectedIfInst(IfInstruction ifInst)
	{
		ILInstruction lhs;
		ILInstruction rhs;
		return ifInst != null && (ifInst.MatchLogicAnd(out lhs, out rhs) || ifInst.MatchLogicOr(out rhs, out lhs)) && IfInstruction.IsInConditionSlot(ifInst);
	}

	public NullPropagationTransform(ILTransformContext context)
	{
		this.context = context;
	}

	internal ILInstruction Run(ILInstruction condition, ILInstruction trueInst, ILInstruction falseInst)
	{
		Debug.Assert(context.Settings.NullPropagation);
		Debug.Assert(!condition.MatchLogicNot(out var _), "Caller should pass in positive condition");
		ILInstruction arg2;
		if (condition is Comp comp && comp.Left.MatchLdLoc(out var variable) && comp.Right.MatchLdNull())
		{
			if (comp.LiftingKind != ComparisonLiftingKind.None)
			{
				return null;
			}
			if (comp.Kind == ComparisonKind.Equality)
			{
				return TryNullPropagation(variable, falseInst, trueInst, Mode.ReferenceType);
			}
			if (comp.Kind == ComparisonKind.Inequality)
			{
				return TryNullPropagation(variable, trueInst, falseInst, Mode.ReferenceType);
			}
		}
		else if (NullableLiftingTransform.MatchHasValueCall(condition, out arg2))
		{
			if (arg2.MatchLdLoca(out variable))
			{
				return TryNullPropagation(variable, trueInst, falseInst, Mode.NullableByValue);
			}
			if (arg2.MatchLdLoc(out variable))
			{
				return TryNullPropagation(variable, trueInst, falseInst, Mode.NullableByReference);
			}
		}
		return null;
	}

	private ILInstruction TryNullPropagation(ILVariable testedVar, ILInstruction nonNullInst, ILInstruction nullInst, Mode mode)
	{
		bool flag = false;
		if (NullableLiftingTransform.MatchNullableCtor(nonNullInst, out var _, out var arg))
		{
			nonNullInst = arg;
			flag = true;
		}
		else if (nonNullInst.MatchNullableRewrap(out arg))
		{
			nonNullInst = arg;
			flag = true;
		}
		if (!IsValidAccessChain(testedVar, mode, nonNullInst, out var finalLoad))
		{
			return null;
		}
		IType type = nonNullInst.InferType(context.TypeSystem);
		if (nullInst.MatchLdNull())
		{
			context.Step($"Null propagation (mode={mode}, output=reference type)", nonNullInst);
			IntroduceUnwrap(testedVar, finalLoad, mode);
			return new NullableRewrap(nonNullInst);
		}
		if (nullInst.MatchDefaultValue(out var type2) && type2.IsKnownType(KnownTypeCode.NullableOfT))
		{
			context.Step($"Null propagation (mode={mode}, output=value type)", nonNullInst);
			IntroduceUnwrap(testedVar, finalLoad, mode);
			return new NullableRewrap(nonNullInst);
		}
		if (!flag && NullableType.IsNonNullableValueType(type))
		{
			context.Step($"Null propagation (mode={mode}, output=null coalescing)", nonNullInst);
			IntroduceUnwrap(testedVar, finalLoad, mode);
			return new NullCoalescingInstruction(NullCoalescingKind.NullableWithValueFallback, new NullableRewrap(nonNullInst), nullInst)
			{
				UnderlyingResultType = nullInst.ResultType
			};
		}
		return null;
	}

	internal void RunStatements(Block block, int pos)
	{
		if (!(block.Instructions[pos] is IfInstruction ifInstruction) || !ifInstruction.FalseInst.MatchNop())
		{
			return;
		}
		ILInstruction arg;
		if (ifInstruction.Condition is Comp { Kind: ComparisonKind.Inequality } comp && comp.Left.MatchLdLoc(out var variable) && comp.Right.MatchLdNull())
		{
			TryNullPropForVoidCall(variable, Mode.ReferenceType, ifInstruction.TrueInst as Block, ifInstruction);
		}
		else if (NullableLiftingTransform.MatchHasValueCall(ifInstruction.Condition, out arg))
		{
			if (arg.MatchLdLoca(out variable))
			{
				TryNullPropForVoidCall(variable, Mode.NullableByValue, ifInstruction.TrueInst as Block, ifInstruction);
			}
			else if (arg.MatchLdLoc(out variable))
			{
				TryNullPropForVoidCall(variable, Mode.NullableByReference, ifInstruction.TrueInst as Block, ifInstruction);
			}
		}
	}

	private void TryNullPropForVoidCall(ILVariable testedVar, Mode mode, Block body, IfInstruction ifInst)
	{
		if (body != null && body.Instructions.Count == 1)
		{
			ILInstruction iLInstruction = body.Instructions[0];
			if (iLInstruction.MatchNullableRewrap(out var argument))
			{
				iLInstruction = argument;
			}
			if (IsValidAccessChain(testedVar, mode, iLInstruction, out var finalLoad))
			{
				context.Step($"Null-propagation (mode={mode}, output=void call)", body);
				IntroduceUnwrap(testedVar, finalLoad, mode);
				ifInst.ReplaceWith(new NullableRewrap(iLInstruction).WithILRange(ifInst));
			}
		}
	}

	private bool IsValidAccessChain(ILVariable testedVar, Mode mode, ILInstruction inst, out ILInstruction finalLoad)
	{
		finalLoad = null;
		int num = 0;
		while (true)
		{
			if (IsValidEndOfChain())
			{
				finalLoad = inst;
				return num >= 1;
			}
			if (inst.MatchLdFld(out var target, out var _))
			{
				inst = target;
			}
			else if (inst is CallInstruction { OpCode: not OpCode.NewObj } callInstruction)
			{
				if (callInstruction.Arguments.Count == 0)
				{
					return false;
				}
				if (callInstruction.Method.IsStatic && (!callInstruction.Method.IsExtensionMethod || !CanTransformToExtensionMethodCall(callInstruction, context)))
				{
					return false;
				}
				if (callInstruction.Method.IsAccessor && !IsGetter(callInstruction.Method))
				{
					return false;
				}
				inst = callInstruction.Arguments[0];
				if ((callInstruction.ConstrainedTo ?? callInstruction.Method.DeclaringType).IsReferenceType == false && inst.MatchAddressOf(out var value))
				{
					inst = value;
				}
				if (ArgumentsAfterFirstMayUnwrapNull(callInstruction.Arguments))
				{
					return false;
				}
			}
			else if (inst is LdLen ldLen)
			{
				inst = ldLen.Array;
			}
			else if (inst is NullableUnwrap nullableUnwrap)
			{
				inst = nullableUnwrap.Argument;
			}
			else if (inst is DynamicGetMemberInstruction dynamicGetMemberInstruction)
			{
				inst = dynamicGetMemberInstruction.Target;
			}
			else if (inst is DynamicInvokeMemberInstruction dynamicInvokeMemberInstruction)
			{
				inst = dynamicInvokeMemberInstruction.Arguments[0];
				if (ArgumentsAfterFirstMayUnwrapNull(dynamicInvokeMemberInstruction.Arguments))
				{
					return false;
				}
			}
			else
			{
				if (!(inst is DynamicGetIndexInstruction dynamicGetIndexInstruction))
				{
					break;
				}
				inst = dynamicGetIndexInstruction.Arguments[0];
				if (ArgumentsAfterFirstMayUnwrapNull(dynamicGetIndexInstruction.Arguments))
				{
					return false;
				}
			}
			num = checked(num + 1);
		}
		return false;
		static bool ArgumentsAfterFirstMayUnwrapNull(InstructionCollection<ILInstruction> arguments)
		{
			for (int i = 1; i < arguments.Count; i = checked(i + 1))
			{
				if (arguments[i].HasFlag(InstructionFlags.MayUnwrapNull))
				{
					return true;
				}
			}
			return false;
		}
		static bool CanTransformToExtensionMethodCall(CallInstruction call, ILTransformContext context)
		{
			return IntroduceExtensionMethods.CanTransformToExtensionMethodCall(call.Method, new CSharpTypeResolveContext(context.TypeSystem.MainModule, context.UsingScope));
		}
		bool IsValidEndOfChain()
		{
			ILInstruction arg;
			return mode switch
			{
				Mode.ReferenceType => inst.MatchLdLocRef(testedVar), 
				Mode.NullableByValue => NullableLiftingTransform.MatchGetValueOrDefault(inst, testedVar), 
				Mode.NullableByReference => NullableLiftingTransform.MatchGetValueOrDefault(inst, out arg) && arg.MatchLdLoc(testedVar), 
				_ => throw new ArgumentOutOfRangeException("mode"), 
			};
		}
	}

	private static bool IsGetter(IMethod method)
	{
		return method.AccessorOwner is IProperty property && property.Getter == method;
	}

	private void IntroduceUnwrap(ILVariable testedVar, ILInstruction varLoad, Mode mode)
	{
		ILInstruction.ChildrenCollection children = varLoad.Parent.Children;
		int childIndex = varLoad.ChildIndex;
		ILInstruction value;
		switch (mode)
		{
		case Mode.ReferenceType:
			value = new NullableUnwrap(varLoad.ResultType, varLoad, varLoad.ResultType == StackType.Ref);
			break;
		case Mode.NullableByValue:
			Debug.Assert(NullableLiftingTransform.MatchGetValueOrDefault(varLoad, testedVar));
			value = new NullableUnwrap(varLoad.ResultType, new LdLoc(testedVar).WithILRange(varLoad.Children[0])).WithILRange(varLoad);
			break;
		case Mode.NullableByReference:
			value = new NullableUnwrap(varLoad.ResultType, new LdLoc(testedVar).WithILRange(varLoad.Children[0]), refInput: true).WithILRange(varLoad);
			break;
		default:
			throw new ArgumentOutOfRangeException("mode");
		}
		children[childIndex] = value;
	}
}
