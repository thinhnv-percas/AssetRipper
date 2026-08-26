#define STEP
#define DEBUG
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL.Transforms;

internal class UserDefinedLogicTransform : IStatementTransform
{
	void IStatementTransform.Run(Block block, int pos, StatementTransformContext context)
	{
		if (!LegacyPattern(block, pos, context) && !RoslynOptimized(block, pos, context))
		{
		}
	}

	private bool RoslynOptimized(Block block, int pos, StatementTransformContext context)
	{
		if (!block.Instructions[pos].MatchIfInstructionPositiveCondition(out var condition, out var trueInst, out var falseInst))
		{
			return false;
		}
		checked
		{
			if (trueInst.OpCode == OpCode.Nop)
			{
				trueInst = block.Instructions[pos + 1];
			}
			else
			{
				if (falseInst.OpCode != OpCode.Nop)
				{
					return false;
				}
				falseInst = block.Instructions[pos + 1];
			}
			if (trueInst.MatchReturn(out var value) && falseInst.MatchReturn(out var value2))
			{
				ILInstruction iLInstruction = Transform(condition, value, value2);
				if (iLInstruction == null)
				{
					iLInstruction = TransformDynamic(condition, value, value2);
				}
				if (iLInstruction != null)
				{
					context.Step("User-defined short-circuiting logic operator (optimized return)", condition);
					((Leave)block.Instructions[pos + 1]).Value = iLInstruction;
					block.Instructions.RemoveAt(pos);
					return true;
				}
			}
			return false;
		}
	}

	private bool LegacyPattern(Block block, int pos, StatementTransformContext context)
	{
		if (!block.Instructions[pos].MatchStLoc(out var variable, out var value))
		{
			return false;
		}
		if (variable.Kind != VariableKind.StackSlot)
		{
			return false;
		}
		checked
		{
			if (!(block.Instructions[pos + 1] is IfInstruction ifInstruction))
			{
				return false;
			}
			if (!ifInstruction.Condition.MatchLogicNot(out var arg))
			{
				return false;
			}
			if (!MatchCondition(arg, out var v, out var name) || v != variable)
			{
				return false;
			}
			if (ifInstruction.FalseInst.OpCode != OpCode.Nop)
			{
				return false;
			}
			ILInstruction iLInstruction = Block.Unwrap(ifInstruction.TrueInst);
			if (!iLInstruction.MatchStLoc(variable, out var value2))
			{
				return false;
			}
			if (value2 is Call call)
			{
				if (!MatchBitwiseCall(call, variable, name))
				{
					return false;
				}
				if (variable.IsUsedWithin(call.Arguments[1]))
				{
					return false;
				}
				context.Step("User-defined short-circuiting logic operator (legacy pattern)", arg);
				((StLoc)block.Instructions[pos]).Value = new UserDefinedLogicOperator(call.Method, value, call.Arguments[1]).WithILRange(call);
				block.Instructions.RemoveAt(pos + 1);
				context.RequestRerun();
				return true;
			}
			return false;
		}
	}

	private static bool MatchCondition(ILInstruction condition, out ILVariable v, out string name)
	{
		v = null;
		name = null;
		if (!(condition is Call call) || !call.Method.IsOperator || call.Arguments.Count != 1 || call.IsLifted)
		{
			return false;
		}
		name = call.Method.Name;
		if (!(name == "op_True") && !(name == "op_False"))
		{
			return false;
		}
		return call.Arguments[0].MatchLdLoc(out v);
	}

	private static bool MatchBitwiseCall(Call call, ILVariable v, string conditionMethodName)
	{
		if (call == null || !call.Method.IsOperator || call.Arguments.Count != 2 || call.IsLifted)
		{
			return false;
		}
		if (!call.Arguments[0].MatchLdLoc(v))
		{
			return false;
		}
		return (conditionMethodName == "op_False" && call.Method.Name == "op_BitwiseAnd") || (conditionMethodName == "op_True" && call.Method.Name == "op_BitwiseOr");
	}

	public static ILInstruction Transform(ILInstruction condition, ILInstruction trueInst, ILInstruction falseInst)
	{
		if (!MatchCondition(condition, out var v, out var name))
		{
			return null;
		}
		if (!trueInst.MatchLdLoc(v))
		{
			return null;
		}
		Call call = falseInst as Call;
		if (!MatchBitwiseCall(call, v, name))
		{
			return null;
		}
		UserDefinedLogicOperator userDefinedLogicOperator = new UserDefinedLogicOperator(call.Method, call.Arguments[0], call.Arguments[1]);
		userDefinedLogicOperator.AddILRange(condition);
		userDefinedLogicOperator.AddILRange(trueInst);
		userDefinedLogicOperator.AddILRange(call);
		return userDefinedLogicOperator;
	}

	public static ILInstruction TransformDynamic(ILInstruction condition, ILInstruction trueInst, ILInstruction falseInst)
	{
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Invalid comparison between Unknown and I4
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Invalid comparison between Unknown and I4
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Invalid comparison between Unknown and I4
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Invalid comparison between Unknown and I4
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		ExpressionType val;
		if (condition.MatchLdLoc(out var variable))
		{
			if (trueInst is Box box && box.Type.IsKnownType(KnownTypeCode.Boolean))
			{
				val = (ExpressionType)83;
				trueInst = box.Argument;
			}
			else
			{
				if (!(falseInst is Box box2) || !box2.Type.IsKnownType(KnownTypeCode.Boolean))
				{
					return null;
				}
				val = (ExpressionType)84;
				falseInst = trueInst;
				trueInst = box2.Argument;
			}
		}
		else if (condition is DynamicUnaryOperatorInstruction dynamicUnaryOperatorInstruction)
		{
			val = dynamicUnaryOperatorInstruction.Operation;
			if (!dynamicUnaryOperatorInstruction.Operand.MatchLdLoc(out variable))
			{
				return null;
			}
		}
		else
		{
			if (!MatchCondition(condition, out variable, out var name))
			{
				return null;
			}
			if (name == "op_True")
			{
				val = (ExpressionType)83;
			}
			else
			{
				Debug.Assert(name == "op_False");
				val = (ExpressionType)84;
			}
			IType type = Enumerable.Single<IParameter>((IEnumerable<IParameter>)((Call)condition).Method.Parameters).Type.SkipModifiers();
			if (type.IsReferenceType == false)
			{
				if (trueInst is Box box3 && NormalizeTypeVisitor.TypeErasure.EquivalentTypes(box3.Type, type))
				{
					trueInst = box3.Argument;
				}
				else if (trueInst.OpCode != OpCode.LdcI4)
				{
					return null;
				}
			}
		}
		DynamicUnaryOperatorInstruction dynamicUnaryOperatorInstruction2;
		if (trueInst.MatchLdLoc(variable))
		{
			dynamicUnaryOperatorInstruction2 = null;
		}
		else
		{
			if (!trueInst.MatchLdcI4(1) || (int)val != 83)
			{
				return null;
			}
			dynamicUnaryOperatorInstruction2 = falseInst as DynamicUnaryOperatorInstruction;
			if (dynamicUnaryOperatorInstruction2 == null)
			{
				return null;
			}
			if ((int)dynamicUnaryOperatorInstruction2.Operation != 83)
			{
				return null;
			}
			falseInst = dynamicUnaryOperatorInstruction2.Operand;
		}
		ExpressionType val2;
		ExpressionType operation;
		if ((int)val == 84)
		{
			val2 = (ExpressionType)2;
			operation = (ExpressionType)3;
		}
		else
		{
			if ((int)val != 83)
			{
				return null;
			}
			val2 = (ExpressionType)36;
			operation = (ExpressionType)37;
		}
		if (!(falseInst is DynamicBinaryOperatorInstruction dynamicBinaryOperatorInstruction))
		{
			return null;
		}
		if (dynamicBinaryOperatorInstruction.Operation != val2)
		{
			return null;
		}
		if (!dynamicBinaryOperatorInstruction.Left.MatchLdLoc(variable))
		{
			return null;
		}
		DynamicLogicOperatorInstruction dynamicLogicOperatorInstruction = new DynamicLogicOperatorInstruction(dynamicBinaryOperatorInstruction.BinderFlags, operation, dynamicBinaryOperatorInstruction.CallingContext, dynamicBinaryOperatorInstruction.LeftArgumentInfo, dynamicBinaryOperatorInstruction.Left, dynamicBinaryOperatorInstruction.RightArgumentInfo, dynamicBinaryOperatorInstruction.Right).WithILRange(dynamicBinaryOperatorInstruction);
		if (dynamicUnaryOperatorInstruction2 != null)
		{
			dynamicUnaryOperatorInstruction2.Operand = dynamicLogicOperatorInstruction;
			return dynamicUnaryOperatorInstruction2;
		}
		return dynamicLogicOperatorInstruction;
	}
}
