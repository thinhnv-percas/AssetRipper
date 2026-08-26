using System.Collections;
using System.Linq;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL.Transforms;

public class DetectCatchWhenConditionBlocks : IILTransform
{
	public void Run(ILFunction function, ILTransformContext context)
	{
		foreach (TryCatchHandler item in Enumerable.OfType<TryCatchHandler>((IEnumerable)function.Descendants))
		{
			if (item.Filter is BlockContainer blockContainer && MatchCatchWhenEntryPoint(item.Variable, blockContainer, blockContainer.EntryPoint, out var exceptionType, out var exceptionSlot, out var whenConditionBlock))
			{
				item.Variable.Type = exceptionType;
				InstructionCollection<ILInstruction> instructions = blockContainer.EntryPoint.Instructions;
				if (instructions.Count == 3)
				{
					((StLoc)instructions[0]).Value = exceptionSlot;
					instructions[1].ReplaceWith(new Branch(whenConditionBlock));
					instructions.RemoveAt(2);
					blockContainer.SortBlocks(deleteUnreachableBlocks: true);
				}
				else if (instructions.Count == 2)
				{
					instructions[0].ReplaceWith(new Branch(whenConditionBlock));
					instructions.RemoveAt(1);
					blockContainer.SortBlocks(deleteUnreachableBlocks: true);
				}
			}
		}
	}

	private bool MatchCatchWhenEntryPoint(ILVariable exceptionVar, BlockContainer container, Block entryPoint, out IType exceptionType, out ILInstruction exceptionSlot, out Block whenConditionBlock)
	{
		exceptionType = null;
		exceptionSlot = null;
		whenConditionBlock = null;
		if (entryPoint == null || entryPoint.IncomingEdgeCount != 1)
		{
			return false;
		}
		if (entryPoint.Instructions.Count == 3)
		{
			if (!entryPoint.Instructions[0].MatchStLoc(out var variable, out var value) || variable.Kind != VariableKind.StackSlot || !value.MatchIsInst(out exceptionSlot, out exceptionType))
			{
				return false;
			}
			if (!exceptionSlot.MatchLdLoc(exceptionVar))
			{
				return false;
			}
			if (!entryPoint.Instructions[1].MatchIfInstruction(out var condition, out var trueInst))
			{
				return false;
			}
			if (!condition.MatchCompNotEquals(out var left, out var right))
			{
				return false;
			}
			if (!entryPoint.Instructions[2].MatchBranch(out var targetBlock) || !MatchFalseBlock(container, targetBlock, out var _, out var _))
			{
				return false;
			}
			if ((left.MatchLdNull() && right.MatchLdLoc(variable)) || (right.MatchLdNull() && left.MatchLdLoc(variable)))
			{
				return trueInst.MatchBranch(out whenConditionBlock);
			}
		}
		else if (entryPoint.Instructions.Count == 2)
		{
			if (!entryPoint.Instructions[0].MatchIfInstruction(out var condition2, out var trueInst2))
			{
				return false;
			}
			if (!condition2.MatchCompNotEquals(out var left2, out var right2))
			{
				return false;
			}
			if (!entryPoint.Instructions[1].MatchBranch(out var targetBlock2) || !MatchFalseBlock(container, targetBlock2, out var _, out var _))
			{
				return false;
			}
			if (!left2.MatchIsInst(out exceptionSlot, out exceptionType))
			{
				return false;
			}
			if (!exceptionSlot.MatchLdLoc(exceptionVar))
			{
				return false;
			}
			if (right2.MatchLdNull())
			{
				return trueInst2.MatchBranch(out whenConditionBlock);
			}
		}
		return false;
	}

	private bool MatchFalseBlock(BlockContainer container, Block falseBlock, out ILVariable returnVar, out Block exitBlock)
	{
		returnVar = null;
		exitBlock = null;
		if (falseBlock.IncomingEdgeCount != 1 || falseBlock.Instructions.Count != 2)
		{
			return false;
		}
		ILInstruction value;
		return falseBlock.Instructions[0].MatchStLoc(out returnVar, out value) && value.MatchLdcI4(0) && falseBlock.Instructions[1].MatchBranch(out exitBlock) && MatchExitBlock(container, exitBlock, returnVar);
	}

	private bool MatchExitBlock(BlockContainer container, Block exitBlock, ILVariable returnVar)
	{
		if (exitBlock.IncomingEdgeCount != 2 || exitBlock.Instructions.Count != 1)
		{
			return false;
		}
		ILInstruction value;
		return exitBlock.Instructions[0].MatchLeave(container, out value) && value.MatchLdLoc(returnVar);
	}
}
