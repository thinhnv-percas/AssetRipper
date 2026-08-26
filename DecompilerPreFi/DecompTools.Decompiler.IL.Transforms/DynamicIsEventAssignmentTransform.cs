#define STEP
namespace DecompTools.Decompiler.IL.Transforms;

public class DynamicIsEventAssignmentTransform : IStatementTransform
{
	public void Run(Block block, int pos, StatementTransformContext context)
	{
		checked
		{
			if (pos + 3 >= block.Instructions.Count || !block.Instructions[pos].MatchStLoc(out var variable, out var value) || !(value is DynamicIsEventInstruction dynamicIsEventInstruction) || !variable.IsSingleDefinition || variable.LoadCount != 2 || !MatchLhsCacheIfInstruction(block.Instructions[pos + 1], variable, out var cacheStore) || !cacheStore.MatchStLoc(out var variable2, out value) || !(value is DynamicGetMemberInstruction replacement))
			{
				return;
			}
			foreach (ILInstruction descendant in block.Instructions[pos + 2].Descendants)
			{
				if (!MatchIsEventAssignmentIfInstruction(descendant, dynamicIsEventInstruction, variable, variable2, out var setMemberInst, out var getMemberVarUse, out var isEventConditionUse))
				{
					continue;
				}
				context.Step("DynamicIsEventAssignmentTransform", block.Instructions[pos]);
				getMemberVarUse.ReplaceWith(replacement);
				isEventConditionUse.ReplaceWith(dynamicIsEventInstruction);
				block.Instructions.RemoveRange(pos, 2);
				ExpressionTransforms.TransformDynamicSetMemberInstruction(setMemberInst, context);
				context.RequestRerun();
				break;
			}
		}
	}

	private static bool MatchIsEventAssignmentIfInstruction(ILInstruction ifInst, DynamicIsEventInstruction isEvent, ILVariable flagVar, ILVariable getMemberVar, out DynamicSetMemberInstruction setMemberInst, out ILInstruction getMemberVarUse, out ILInstruction isEventConditionUse)
	{
		setMemberInst = null;
		getMemberVarUse = null;
		isEventConditionUse = null;
		if (!ifInst.MatchIfInstruction(out var condition, out var trueInst, out var falseInst))
		{
			return false;
		}
		if (MatchFlagEqualsZero(condition, flagVar))
		{
			if (!condition.MatchCompEquals(out var left, out var _))
			{
				return false;
			}
			isEventConditionUse = left;
		}
		else
		{
			if (!condition.MatchLdLoc(flagVar))
			{
				return false;
			}
			ILInstruction iLInstruction = trueInst;
			trueInst = falseInst;
			falseInst = iLInstruction;
			isEventConditionUse = condition;
		}
		setMemberInst = Block.Unwrap(trueInst) as DynamicSetMemberInstruction;
		if (setMemberInst == null)
		{
			return false;
		}
		if (!isEvent.Argument.Match(setMemberInst.Target).Success)
		{
			return false;
		}
		if (!(Block.Unwrap(falseInst) is DynamicInvokeMemberInstruction dynamicInvokeMemberInstruction) || dynamicInvokeMemberInstruction.Arguments.Count != 2)
		{
			return false;
		}
		if (!isEvent.Argument.Match(dynamicInvokeMemberInstruction.Arguments[0]).Success)
		{
			return false;
		}
		if (!(setMemberInst.Value is DynamicBinaryOperatorInstruction dynamicBinaryOperatorInstruction) || !dynamicBinaryOperatorInstruction.Left.MatchLdLoc(getMemberVar))
		{
			return false;
		}
		getMemberVarUse = dynamicBinaryOperatorInstruction.Left;
		return true;
	}

	private static bool MatchLhsCacheIfInstruction(ILInstruction ifInst, ILVariable flagVar, out StLoc cacheStore)
	{
		cacheStore = null;
		if (!ifInst.MatchIfInstruction(out var condition, out var trueInst))
		{
			return false;
		}
		if (!MatchFlagEqualsZero(condition, flagVar))
		{
			return false;
		}
		cacheStore = Block.Unwrap(trueInst) as StLoc;
		return cacheStore != null;
	}

	private static bool MatchFlagEqualsZero(ILInstruction condition, ILVariable flagVar)
	{
		ILInstruction left;
		ILInstruction right;
		return condition.MatchCompEquals(out left, out right) && left.MatchLdLoc(flagVar) && right.MatchLdcI4(0);
	}
}
