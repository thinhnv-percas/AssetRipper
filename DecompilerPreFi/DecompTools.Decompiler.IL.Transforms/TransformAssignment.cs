#define STEP
#define DEBUG
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DecompTools.Decompiler.CSharp;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.IL.Transforms;

public class TransformAssignment : IStatementTransform
{
	private StatementTransformContext context;

	void IStatementTransform.Run(Block block, int pos, StatementTransformContext context)
	{
		this.context = context;
		if (context.Settings.MakeAssignmentExpressions && (TransformInlineAssignmentStObjOrCall(block, pos) || TransformInlineAssignmentLocal(block, pos)))
		{
			context.RequestRerun();
		}
		else if (context.Settings.IntroduceIncrementAndDecrement && (TransformPostIncDecOperatorWithInlineStore(block, pos) || TransformPostIncDecOperator(block, pos) || TransformPostIncDecOperatorLocal(block, pos)))
		{
			context.RequestRerun();
		}
	}

	private bool TransformInlineAssignmentStObjOrCall(Block block, int pos)
	{
		if (!(block.Instructions[pos] is StLoc stLoc) || (stLoc.Variable.Kind != VariableKind.StackSlot && stLoc.Variable.Kind != VariableKind.Local))
		{
			return false;
		}
		if (IsImplicitTruncation(stLoc.Value, stLoc.Variable.Type, context.TypeSystem))
		{
			return false;
		}
		checked
		{
			StLoc stLoc2;
			ILVariable variable;
			int index;
			if ((stLoc2 = block.Instructions[pos + 1] as StLoc) != null)
			{
				if (stLoc2.Variable.Kind != VariableKind.Local || !stLoc2.Value.MatchLdLoc(stLoc.Variable))
				{
					return false;
				}
				if (!stLoc.Variable.IsSingleDefinition || stLoc.Variable.LoadCount != 2)
				{
					return false;
				}
				variable = stLoc2.Variable;
				index = pos + 2;
			}
			else
			{
				variable = stLoc.Variable;
				stLoc2 = null;
				index = pos + 1;
			}
			if (block.Instructions[index] is StObj stObj)
			{
				if (!stObj.Value.MatchLdLoc(stLoc.Variable))
				{
					return false;
				}
				if (!SemanticHelper.IsPure(stObj.Target.Flags) || stLoc.Variable.IsUsedWithin(stObj.Target))
				{
					return false;
				}
				IType type = stObj.Target.InferType(context.TypeSystem);
				IType type2 = stObj.Type;
				if (TypeUtils.IsCompatiblePointerTypeForMemoryAccess(type, stObj.Type))
				{
					if (type is ByReferenceType byReferenceType)
					{
						type2 = byReferenceType.ElementType;
					}
					else if (type is PointerType pointerType)
					{
						type2 = pointerType.ElementType;
					}
				}
				if (IsImplicitTruncation(stLoc.Value, type2, context.TypeSystem))
				{
					return false;
				}
				context.Step("Inline assignment stobj", stObj);
				stObj.Type = type2;
				block.Instructions.Remove(stLoc2);
				block.Instructions.Remove(stObj);
				stObj.Value = stLoc.Value;
				stLoc.ReplaceWith(new StLoc(variable, stObj));
				return true;
			}
			if (block.Instructions[index] is CallInstruction callInstruction)
			{
				if (callInstruction.OpCode != OpCode.Call && callInstruction.OpCode != OpCode.CallVirt)
				{
					return false;
				}
				if (callInstruction.ResultType != StackType.Void || callInstruction.Arguments.Count == 0)
				{
					return false;
				}
				if (!(callInstruction.Method.AccessorOwner is IProperty property))
				{
					return false;
				}
				if (!callInstruction.Method.Equals(property.Setter))
				{
					return false;
				}
				if (!property.IsIndexer && property.Setter.Parameters.Count != 1)
				{
					return false;
				}
				if (!callInstruction.Arguments.Last().MatchLdLoc(stLoc.Variable))
				{
					return false;
				}
				foreach (ILInstruction item in callInstruction.Arguments.SkipLast(1))
				{
					if (!SemanticHelper.IsPure(item.Flags) || stLoc.Variable.IsUsedWithin(item))
					{
						return false;
					}
				}
				if (IsImplicitTruncation(stLoc.Value, Enumerable.Last<IParameter>((IEnumerable<IParameter>)callInstruction.Method.Parameters).Type, context.TypeSystem))
				{
					return false;
				}
				context.Step("Inline assignment call", callInstruction);
				block.Instructions.Remove(stLoc2);
				block.Instructions.Remove(callInstruction);
				ILVariable iLVariable = context.Function.RegisterVariable(VariableKind.StackSlot, Enumerable.Last<IParameter>((IEnumerable<IParameter>)callInstruction.Method.Parameters).Type);
				callInstruction.Arguments[callInstruction.Arguments.Count - 1] = new StLoc(iLVariable, stLoc.Value);
				Block block2 = new Block(BlockKind.CallInlineAssign)
				{
					Instructions = { (ILInstruction)callInstruction },
					FinalInstruction = new LdLoc(iLVariable)
				};
				stLoc.ReplaceWith(new StLoc(variable, block2));
				if (HandleCompoundAssign(callInstruction, context) && Enumerable.Single<ILInstruction>((IEnumerable<ILInstruction>)block2.Instructions).MatchStLoc(iLVariable, out var value))
				{
					Debug.Assert(iLVariable.IsSingleDefinition && iLVariable.LoadCount == 1);
					block2.ReplaceWith(value);
				}
				return true;
			}
			return false;
		}
	}

	private static ILInstruction UnwrapSmallIntegerConv(ILInstruction inst, out Conv conv)
	{
		conv = inst as Conv;
		if (conv != null && conv.Kind == ConversionKind.Truncate && conv.TargetType.IsSmallIntegerType())
		{
			return conv.Argument;
		}
		return inst;
	}

	private static bool ValidateCompoundAssign(BinaryNumericInstruction binary, Conv conv, IType targetType)
	{
		if (!NumericCompoundAssign.IsBinaryCompatibleWithType(binary, targetType))
		{
			return false;
		}
		if (conv != null && (conv.TargetType != targetType.ToPrimitiveType() || conv.CheckForOverflow != binary.CheckForOverflow))
		{
			return false;
		}
		return true;
	}

	private static bool MatchingGetterAndSetterCalls(CallInstruction getterCall, CallInstruction setterCall)
	{
		if (getterCall == null || setterCall == null || !IsSameMember(getterCall.Method.AccessorOwner, setterCall.Method.AccessorOwner))
		{
			return false;
		}
		if (setterCall.OpCode != getterCall.OpCode)
		{
			return false;
		}
		if (!(getterCall.Method.AccessorOwner is IProperty property) || !IsSameMember(getterCall.Method, property.Getter) || !IsSameMember(setterCall.Method, property.Setter))
		{
			return false;
		}
		checked
		{
			if (setterCall.Arguments.Count != getterCall.Arguments.Count + 1)
			{
				return false;
			}
			for (int i = 0; i < getterCall.Arguments.Count; i++)
			{
				if (!SemanticHelper.IsPure(getterCall.Arguments[i].Flags))
				{
					return false;
				}
				if (!getterCall.Arguments[i].Match(setterCall.Arguments[i]).Success)
				{
					return false;
				}
			}
			return true;
		}
	}

	internal static bool HandleCompoundAssign(ILInstruction compoundStore, StatementTransformContext context)
	{
		//IL_0347: Unknown result type (might be due to invalid IL or missing references)
		if (!context.Settings.MakeAssignmentExpressions || !context.Settings.IntroduceIncrementAndDecrement)
		{
			return false;
		}
		if (compoundStore is CallInstruction && compoundStore.SlotInfo != Block.InstructionSlot)
		{
			return false;
		}
		if (!IsCompoundStore(compoundStore, out var storeType, out var value, context.TypeSystem))
		{
			return false;
		}
		StLoc stLoc = value as StLoc;
		if (stLoc != null)
		{
			value = stLoc.Value;
			if (stLoc.Variable.Type.IsSmallIntegerType())
			{
				if (stLoc.Variable.Type.GetSize() != storeType.GetSize())
				{
					return false;
				}
				if (stLoc.Variable.Type.GetSign() != storeType.GetSign())
				{
					return false;
				}
			}
		}
		ILInstruction iLInstruction;
		if (UnwrapSmallIntegerConv(value, out var conv) is BinaryNumericInstruction binaryNumericInstruction)
		{
			if (!IsMatchingCompoundLoad(binaryNumericInstruction.Left, compoundStore, stLoc?.Variable))
			{
				return false;
			}
			if (!ValidateCompoundAssign(binaryNumericInstruction, conv, storeType))
			{
				return false;
			}
			context.Step("Compound assignment (binary.numeric)", compoundStore);
			iLInstruction = new NumericCompoundAssign(binaryNumericInstruction, binaryNumericInstruction.Left, binaryNumericInstruction.Right, storeType, CompoundAssignmentType.EvaluatesToNewValue);
		}
		else if (value is Call call && call.Method.IsOperator)
		{
			if (call.Arguments.Count == 0)
			{
				return false;
			}
			if (!IsMatchingCompoundLoad(call.Arguments[0], compoundStore, stLoc?.Variable))
			{
				return false;
			}
			ILInstruction value2;
			if (call.Arguments.Count == 2)
			{
				if (!ExpressionBuilder.GetAssignmentOperatorTypeFromMetadataName(call.Method.Name).HasValue)
				{
					return false;
				}
				value2 = call.Arguments[1];
			}
			else
			{
				if (call.Arguments.Count != 1)
				{
					return false;
				}
				if (!(call.Method.Name == "op_Increment") && !(call.Method.Name == "op_Decrement"))
				{
					return false;
				}
				value2 = new LdcI4(1);
			}
			if (call.IsLifted)
			{
				return false;
			}
			context.Step("Compound assignment (user-defined binary)", compoundStore);
			iLInstruction = new UserDefinedCompoundAssign(call.Method, CompoundAssignmentType.EvaluatesToNewValue, call.Arguments[0], value2);
		}
		else if (value is DynamicBinaryOperatorInstruction dynamicBinaryOperatorInstruction)
		{
			if (!IsMatchingCompoundLoad(dynamicBinaryOperatorInstruction.Left, compoundStore, stLoc?.Variable))
			{
				return false;
			}
			context.Step("Compound assignment (dynamic binary)", compoundStore);
			iLInstruction = new DynamicCompoundAssign(dynamicBinaryOperatorInstruction.Operation, dynamicBinaryOperatorInstruction.BinderFlags, dynamicBinaryOperatorInstruction.Left, dynamicBinaryOperatorInstruction.LeftArgumentInfo, dynamicBinaryOperatorInstruction.Right, dynamicBinaryOperatorInstruction.RightArgumentInfo);
		}
		else
		{
			if (!(value is Call call2) || !UserDefinedCompoundAssign.IsStringConcat(call2.Method))
			{
				return false;
			}
			if (call2.Arguments.Count != 2)
			{
				return false;
			}
			if (!storeType.IsKnownType(KnownTypeCode.String))
			{
				return false;
			}
			if (!IsMatchingCompoundLoad(call2.Arguments[0], compoundStore, stLoc?.Variable))
			{
				return false;
			}
			context.Step("Compound assignment (string concatenation)", compoundStore);
			iLInstruction = new UserDefinedCompoundAssign(call2.Method, CompoundAssignmentType.EvaluatesToNewValue, call2.Arguments[0], call2.Arguments[1]);
		}
		iLInstruction.AddILRange(value);
		if (stLoc != null)
		{
			stLoc.Value = iLInstruction;
			iLInstruction = stLoc;
			context.RequestRerun();
		}
		compoundStore.ReplaceWith(iLInstruction);
		return true;
	}

	private bool TransformInlineAssignmentLocal(Block block, int pos)
	{
		StLoc stLoc = block.Instructions[pos] as StLoc;
		StLoc stLoc2 = block.Instructions.ElementAtOrDefault(checked(pos + 1)) as StLoc;
		if (stLoc == null || stLoc2 == null)
		{
			return false;
		}
		if (stLoc.Variable.Kind != VariableKind.StackSlot)
		{
			return false;
		}
		if (stLoc2.Variable.Kind != VariableKind.Local && stLoc2.Variable.Kind != VariableKind.Parameter)
		{
			return false;
		}
		if (!stLoc2.Value.MatchLdLoc(stLoc.Variable))
		{
			return false;
		}
		if (IsImplicitTruncation(stLoc.Value, stLoc.Variable.Type, context.TypeSystem))
		{
			return false;
		}
		if (IsImplicitTruncation(stLoc.Value, stLoc2.Variable.Type, context.TypeSystem))
		{
			return false;
		}
		if (stLoc2.Variable.StackType == StackType.Ref)
		{
			return false;
		}
		context.Step("Inline assignment to local variable", stLoc);
		ILInstruction value = stLoc.Value;
		ILVariable variable = stLoc2.Variable;
		ILVariable variable2 = stLoc.Variable;
		block.Instructions.RemoveAt(pos);
		stLoc2.ReplaceWith(new StLoc(variable2, new StLoc(variable, value)));
		return true;
	}

	internal static bool IsImplicitTruncation(ILInstruction value, IType type, ICompilation compilation, bool allowNullableValue = false)
	{
		if (!type.IsSmallIntegerType())
		{
			return false;
		}
		if (value.MatchLdcI4(out var value2))
		{
			switch (type.GetEnumUnderlyingType().GetDefinition()?.KnownTypeCode)
			{
			case KnownTypeCode.Boolean:
				return value2 != 0 && value2 != 1;
			case KnownTypeCode.Byte:
				return value2 < 0 || value2 > 255;
			case KnownTypeCode.SByte:
				return value2 < -128 || value2 > 127;
			case KnownTypeCode.Int16:
				return value2 < -32768 || value2 > 32767;
			case KnownTypeCode.Char:
			case KnownTypeCode.UInt16:
				return value2 < 0 || value2 > 65535;
			}
		}
		else
		{
			if (value is Conv conv)
			{
				return conv.TargetType != type.ToPrimitiveType();
			}
			if (value is Comp)
			{
				return false;
			}
			if (value is IfInstruction ifInstruction)
			{
				return IsImplicitTruncation(ifInstruction.TrueInst, type, compilation, allowNullableValue) || IsImplicitTruncation(ifInstruction.FalseInst, type, compilation, allowNullableValue);
			}
			IType type2 = value.InferType(compilation);
			if (allowNullableValue)
			{
				type2 = NullableType.GetUnderlyingType(type2);
			}
			if (type2.Kind != TypeKind.Unknown)
			{
				return type2.GetSize() > type.GetSize() || type2.GetSign() != type.GetSign();
			}
		}
		return true;
	}

	private bool TransformPostIncDecOperatorLocal(Block block, int pos)
	{
		StLoc stLoc = block.Instructions[pos] as StLoc;
		checked
		{
			StLoc stLoc2 = block.Instructions.ElementAtOrDefault(pos + 1) as StLoc;
			if (stLoc == null || stLoc2 == null || !stLoc.Value.MatchLdLoc(out var variable) || !ILVariableEqualityComparer.Instance.Equals(variable, stLoc2.Variable))
			{
				return false;
			}
			BinaryNumericInstruction binaryNumericInstruction = stLoc2.Value as BinaryNumericInstruction;
			if (stLoc.Variable.Kind != VariableKind.StackSlot || stLoc2.Variable.Kind == VariableKind.StackSlot || binaryNumericInstruction == null)
			{
				return false;
			}
			if (binaryNumericInstruction.IsLifted)
			{
				return false;
			}
			if ((binaryNumericInstruction.Operator != BinaryNumericOperator.Add && binaryNumericInstruction.Operator != BinaryNumericOperator.Sub) || !binaryNumericInstruction.Left.MatchLdLoc(stLoc.Variable) || !binaryNumericInstruction.Right.MatchLdcI4(1))
			{
				return false;
			}
			context.Step("TransformPostIncDecOperatorLocal", stLoc);
			if (variable != stLoc2.Variable)
			{
				context.Function.RecombineVariables(variable, stLoc2.Variable);
			}
			ILVariable variable2 = context.Function.RegisterVariable(VariableKind.StackSlot, stLoc.Variable.Type);
			Block block2 = new Block(BlockKind.PostfixOperator);
			block2.Instructions.Add(new StLoc(variable2, new LdLoc(variable)));
			block2.Instructions.Add(new StLoc(variable, new BinaryNumericInstruction(binaryNumericInstruction.Operator, new LdLoc(variable2), new LdcI4(1), binaryNumericInstruction.CheckForOverflow, binaryNumericInstruction.Sign)));
			block2.FinalInstruction = new LdLoc(variable2);
			stLoc.Value = block2;
			block.Instructions.RemoveAt(pos + 1);
			return true;
		}
	}

	private static bool IsCompoundStore(ILInstruction inst, out IType storeType, out ILInstruction value, ICompilation compilation)
	{
		value = null;
		storeType = null;
		if (inst is StObj stObj)
		{
			storeType = stObj.Target.InferType(compilation);
			if (storeType is ByReferenceType byReferenceType)
			{
				storeType = byReferenceType.ElementType;
			}
			else if (storeType is PointerType pointerType)
			{
				storeType = pointerType.ElementType;
			}
			else
			{
				storeType = stObj.Type;
			}
			value = stObj.Value;
			return SemanticHelper.IsPure(stObj.Target.Flags);
		}
		if (inst is CallInstruction callInstruction && (callInstruction.OpCode == OpCode.Call || callInstruction.OpCode == OpCode.CallVirt))
		{
			if (callInstruction.Method.Parameters.Count == 0)
			{
				return false;
			}
			foreach (ILInstruction item in callInstruction.Arguments.SkipLast(1))
			{
				if (!SemanticHelper.IsPure(item.Flags))
				{
					return false;
				}
			}
			storeType = Enumerable.Last<IParameter>((IEnumerable<IParameter>)callInstruction.Method.Parameters).Type;
			value = callInstruction.Arguments.Last();
			return IsSameMember(callInstruction.Method, (callInstruction.Method.AccessorOwner as IProperty)?.Setter);
		}
		return false;
	}

	private static bool IsMatchingCompoundLoad(ILInstruction load, ILInstruction store, ILVariable forbiddenVariable)
	{
		if (load is LdObj ldObj && store is StObj stObj)
		{
			Debug.Assert(SemanticHelper.IsPure(stObj.Target.Flags));
			if (!SemanticHelper.IsPure(ldObj.Target.Flags))
			{
				return false;
			}
			if (forbiddenVariable != null && forbiddenVariable.IsUsedWithin(ldObj.Target))
			{
				return false;
			}
			return ldObj.Target.Match(stObj.Target).Success;
		}
		if (MatchingGetterAndSetterCalls(load as CallInstruction, store as CallInstruction))
		{
			if (forbiddenVariable != null && forbiddenVariable.IsUsedWithin(load))
			{
				return false;
			}
			return true;
		}
		return false;
	}

	private bool TransformPostIncDecOperatorWithInlineStore(Block block, int pos)
	{
		ILInstruction iLInstruction = block.Instructions[pos];
		if (!IsCompoundStore(iLInstruction, out var storeType, out var value, context.TypeSystem))
		{
			return false;
		}
		BinaryNumericInstruction binaryNumericInstruction = UnwrapSmallIntegerConv(value, out var conv) as BinaryNumericInstruction;
		StLoc stLoc;
		if (binaryNumericInstruction != null && binaryNumericInstruction.Right.MatchLdcI(1L))
		{
			if (binaryNumericInstruction.Operator != BinaryNumericOperator.Add && binaryNumericInstruction.Operator != BinaryNumericOperator.Sub)
			{
				return false;
			}
			if (!ValidateCompoundAssign(binaryNumericInstruction, conv, storeType))
			{
				return false;
			}
			stLoc = binaryNumericInstruction.Left as StLoc;
		}
		else
		{
			if (!(value is Call call) || !call.Method.IsOperator || call.Arguments.Count != 1)
			{
				return false;
			}
			if (!(call.Method.Name == "op_Increment") && !(call.Method.Name == "op_Decrement"))
			{
				return false;
			}
			if (call.IsLifted)
			{
				return false;
			}
			stLoc = call.Arguments[0] as StLoc;
		}
		if (stLoc == null)
		{
			return false;
		}
		if (stLoc.Variable.Kind != VariableKind.Local && stLoc.Variable.Kind != VariableKind.StackSlot)
		{
			return false;
		}
		if (!IsMatchingCompoundLoad(stLoc.Value, iLInstruction, stLoc.Variable))
		{
			return false;
		}
		if (IsImplicitTruncation(stLoc.Value, stLoc.Variable.Type, context.TypeSystem))
		{
			return false;
		}
		context.Step("TransformPostIncDecOperatorWithInlineStore", iLInstruction);
		if (binaryNumericInstruction != null)
		{
			block.Instructions[pos] = new StLoc(stLoc.Variable, new NumericCompoundAssign(binaryNumericInstruction, stLoc.Value, binaryNumericInstruction.Right, storeType, CompoundAssignmentType.EvaluatesToOldValue));
		}
		else
		{
			Call call2 = (Call)value;
			block.Instructions[pos] = new StLoc(stLoc.Variable, new UserDefinedCompoundAssign(call2.Method, CompoundAssignmentType.EvaluatesToOldValue, stLoc.Value, new LdcI4(1)));
		}
		return true;
	}

	private bool TransformPostIncDecOperator(Block block, int i)
	{
		StLoc stLoc = block.Instructions[i] as StLoc;
		checked
		{
			ILInstruction iLInstruction = block.Instructions.ElementAtOrDefault(i + 1);
			if (stLoc == null || iLInstruction == null)
			{
				return false;
			}
			if (!IsCompoundStore(iLInstruction, out var storeType, out var value, context.TypeSystem))
			{
				return false;
			}
			if (IsImplicitTruncation(stLoc.Value, storeType, context.TypeSystem))
			{
				return false;
			}
			if (!IsMatchingCompoundLoad(stLoc.Value, iLInstruction, stLoc.Variable))
			{
				return false;
			}
			if (UnwrapSmallIntegerConv(value, out var conv) is BinaryNumericInstruction binaryNumericInstruction)
			{
				if (!binaryNumericInstruction.Left.MatchLdLoc(stLoc.Variable) || !binaryNumericInstruction.Right.MatchLdcI(1L))
				{
					return false;
				}
				if (binaryNumericInstruction.Operator != BinaryNumericOperator.Add && binaryNumericInstruction.Operator != BinaryNumericOperator.Sub)
				{
					return false;
				}
				if (!ValidateCompoundAssign(binaryNumericInstruction, conv, storeType))
				{
					return false;
				}
				context.Step("TransformPostIncDecOperator (builtin)", stLoc);
				stLoc.Value = new NumericCompoundAssign(binaryNumericInstruction, stLoc.Value, binaryNumericInstruction.Right, storeType, CompoundAssignmentType.EvaluatesToOldValue);
			}
			else
			{
				if (!(value is Call call) || !call.Method.IsOperator || call.Arguments.Count != 1)
				{
					return false;
				}
				if (!call.Arguments[0].MatchLdLoc(stLoc.Variable))
				{
					return false;
				}
				if (!(call.Method.Name == "op_Increment") && !(call.Method.Name == "op_Decrement"))
				{
					return false;
				}
				if (call.IsLifted)
				{
					return false;
				}
				context.Step("TransformPostIncDecOperator (user-defined)", stLoc);
				stLoc.Value = new UserDefinedCompoundAssign(call.Method, CompoundAssignmentType.EvaluatesToOldValue, stLoc.Value, new LdcI4(1));
			}
			block.Instructions.RemoveAt(i + 1);
			if (stLoc.Variable.IsSingleDefinition && stLoc.Variable.LoadCount == 0)
			{
				stLoc.ReplaceWith(stLoc.Value);
			}
			return true;
		}
	}

	private static bool IsSameMember(IMember a, IMember b)
	{
		if (a == null || b == null)
		{
			return false;
		}
		a = a.MemberDefinition;
		b = b.MemberDefinition;
		return a.Equals(b);
	}
}
