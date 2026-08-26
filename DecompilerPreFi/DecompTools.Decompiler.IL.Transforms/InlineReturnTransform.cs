using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DecompTools.Decompiler.IL.Transforms;

internal class InlineReturnTransform : IILTransform
{
	public void Run(ILFunction function, ILTransformContext context)
	{
		List<(BlockContainer, Block, Branch)> list = new List<(BlockContainer, Block, Branch)>();
		foreach (Leave item4 in Enumerable.OfType<Leave>((IEnumerable)function.Descendants))
		{
			if (item4.Parent is Block block && block.Instructions.Count == 1 && item4.Value.MatchLdLoc(out var variable) && variable.Kind == VariableKind.Local && CanModifyInstructions(variable, block, out var instructionsToModify))
			{
				list.AddRange(instructionsToModify);
			}
		}
		foreach (var item5 in list)
		{
			BlockContainer item = item5.Item1;
			Block item2 = item5.Item2;
			Branch item3 = item5.Item3;
			Block block2 = item2;
			if (block2.IncomingEdgeCount == 1)
			{
				block2.Remove();
			}
			else
			{
				block2 = (Block)block2.Clone();
			}
			item.Blocks.Add(block2);
			item3.TargetBlock = block2;
		}
	}

	private static bool CanModifyInstructions(ILVariable returnVar, Block leaveBlock, out List<(BlockContainer, Block, Branch)> instructionsToModify)
	{
		instructionsToModify = new List<(BlockContainer, Block, Branch)>();
		checked
		{
			foreach (IStoreInstruction storeInstruction in returnVar.StoreInstructions)
			{
				if (!(storeInstruction is StLoc stLoc))
				{
					return false;
				}
				if (!(stLoc.Parent is Block block))
				{
					return false;
				}
				if (stLoc.ChildIndex + 2 != block.Instructions.Count)
				{
					return false;
				}
				if (!(block.Instructions[stLoc.ChildIndex + 1] is Branch branch))
				{
					return false;
				}
				if (branch.TargetBlock != leaveBlock)
				{
					return false;
				}
				BlockContainer blockContainer = BlockContainer.FindClosestContainer(stLoc);
				if (blockContainer == null)
				{
					return false;
				}
				instructionsToModify.Add((blockContainer, leaveBlock, branch));
			}
			return true;
		}
	}
}
