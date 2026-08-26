#define STEP
#define DEBUG
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DecompTools.Decompiler.IL.Transforms;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL.ControlFlow;

public class ControlFlowSimplification : IILTransform
{
	internal bool aggressivelyDuplicateReturnBlocks;

	public void Run(ILFunction function, ILTransformContext context)
	{
		foreach (Block item in Enumerable.OfType<Block>((IEnumerable)function.Descendants))
		{
			context.CancellationToken.ThrowIfCancellationRequested();
			RemoveNopInstructions(item);
			InlineVariableInReturnBlock(item, context);
			SwitchDetection.SimplifySwitchInstruction(item);
		}
		SimplifyBranchChains(function, context);
		CleanUpEmptyBlocks(function, context);
	}

	private static void RemoveNopInstructions(Block block)
	{
		checked
		{
			for (int num = block.Instructions.Count - 1; num > 0; num--)
			{
				if (block.Instructions[num] is Nop { Kind: NopKind.Pop } nop)
				{
					block.Instructions[num - 1].AddILRange(nop);
				}
			}
			block.Instructions.RemoveAll((ILInstruction inst) => inst.OpCode == OpCode.Nop);
		}
	}

	private void InlineVariableInReturnBlock(Block block, ILTransformContext context)
	{
		if (block.Instructions.Count == 2 && block.Instructions[1].MatchReturn(out var value))
		{
			Leave leave = (Leave)block.Instructions[1];
			if (value.MatchLdLoc(out var variable) && variable.IsSingleDefinition && variable.LoadCount == 1 && block.Instructions[0].MatchStLoc(variable, out var value2))
			{
				context.Step("Inline variable in return block", block);
				value2.AddILRange(leave.Value);
				value2.AddILRange(block.Instructions[0]);
				leave.Value = value2;
				block.Instructions.RemoveAt(0);
			}
		}
	}

	private void SimplifyBranchChains(ILFunction function, ILTransformContext context)
	{
		List<(BlockContainer, Block)> list = new List<(BlockContainer, Block)>();
		HashSet<Block> val = new HashSet<Block>();
		foreach (Branch item2 in Enumerable.OfType<Branch>((IEnumerable)function.Descendants))
		{
			Block targetBlock = item2.TargetBlock;
			val.Clear();
			while (targetBlock.Instructions.Count == 1 && targetBlock.Instructions[0].OpCode == OpCode.Branch && val.Add(targetBlock))
			{
				context.Step("Simplify branch to branch", item2);
				Branch branch = (Branch)targetBlock.Instructions[0];
				item2.TargetBlock = branch.TargetBlock;
				item2.AddILRange(branch);
				if (targetBlock.IncomingEdgeCount == 0)
				{
					targetBlock.Instructions.Clear();
				}
				targetBlock = item2.TargetBlock;
			}
			if (IsBranchToReturnBlock(item2))
			{
				if (aggressivelyDuplicateReturnBlocks)
				{
					context.Step("Replace branch to return with return", item2);
					item2.ReplaceWith(targetBlock.Instructions[0].Clone());
				}
				else if (item2.TargetContainer != Enumerable.First<BlockContainer>(Enumerable.OfType<BlockContainer>((IEnumerable)item2.Ancestors)))
				{
					context.Step("Copy return block into try block", item2);
					Block block = (Block)item2.TargetBlock.Clone();
					BlockContainer item = Enumerable.First<BlockContainer>(Enumerable.OfType<BlockContainer>((IEnumerable)item2.Ancestors));
					list.Add((item, block));
					item2.TargetBlock = block;
				}
			}
			else if (targetBlock.Instructions.Count == 1 && targetBlock.Instructions[0] is Leave leave && leave.Value.MatchNop())
			{
				context.Step("Replace branch to leave with leave", item2);
				ILInstruction iLInstruction = leave.Clone();
				if (!item2.HasILRange)
				{
					iLInstruction.AddILRange(item2);
				}
				item2.ReplaceWith(iLInstruction);
			}
			if (targetBlock.IncomingEdgeCount == 0)
			{
				targetBlock.Instructions.Clear();
			}
		}
		foreach (var (blockContainer, value) in list)
		{
			blockContainer.Blocks.Add(value);
		}
	}

	private void CleanUpEmptyBlocks(ILFunction function, ILTransformContext context)
	{
		foreach (BlockContainer item in Enumerable.OfType<BlockContainer>((IEnumerable)function.Descendants))
		{
			foreach (Block block in item.Blocks)
			{
				if (block.Instructions.Count != 0)
				{
					while (CombineBlockWithNextBlock(item, block, context))
					{
					}
				}
			}
			item.Blocks.RemoveAll((Block b) => b.IncomingEdgeCount == 0 && b.Instructions.Count == 0);
			if (context.Settings.RemoveDeadCode)
			{
				item.SortBlocks(deleteUnreachableBlocks: true);
			}
		}
	}

	private bool IsBranchToReturnBlock(Branch branch)
	{
		Block targetBlock = branch.TargetBlock;
		if (targetBlock.Instructions.Count != 1 || targetBlock.FinalInstruction.OpCode != OpCode.Nop)
		{
			return false;
		}
		ILInstruction value;
		return targetBlock.Instructions[0].MatchReturn(out value) && value is LdLoc;
	}

	private static bool CombineBlockWithNextBlock(BlockContainer container, Block block, ILTransformContext context)
	{
		Debug.Assert(container == block.Parent);
		checked
		{
			if (block.Instructions.Count > 1 && block.Instructions[block.Instructions.Count - 2].HasFlag(InstructionFlags.MayBranch))
			{
				return false;
			}
			if (!(block.Instructions.Last() is Branch branch) || branch.TargetBlock.Parent != container || branch.TargetBlock.IncomingEdgeCount != 1)
			{
				return false;
			}
			if (branch.TargetBlock == block)
			{
				return false;
			}
			context.Step("CombineBlockWithNextBlock", branch);
			Block targetBlock = branch.TargetBlock;
			if (targetBlock.StartILOffset < block.StartILOffset && IsDeadTrueStore(block))
			{
				block.Instructions.RemoveRange(block.Instructions.Count - 3, 2);
			}
			if (block.HasILRange)
			{
				block.AddILRange(targetBlock);
			}
			block.Instructions.Remove(branch);
			block.Instructions.AddRange(targetBlock.Instructions);
			targetBlock.Instructions.Clear();
			return true;
		}
	}

	private static bool IsDeadTrueStore(Block block)
	{
		if (block.Instructions.Count < 3)
		{
			return false;
		}
		if (!(block.Instructions.SecondToLastOrDefault() is StLoc stLoc) || !(block.Instructions[checked(block.Instructions.Count - 3)] is StLoc stLoc2))
		{
			return false;
		}
		if (stLoc.Variable.LoadCount != 0 || stLoc.Variable.AddressCount != 0)
		{
			return false;
		}
		if (!stLoc.Value.MatchLdLoc(stLoc2.Variable) || !stLoc2.Variable.IsSingleDefinition || stLoc2.Variable.LoadCount != 1)
		{
			return false;
		}
		return stLoc2.Value.MatchLdcI4(1) && stLoc.Variable.Type.IsKnownType(KnownTypeCode.Boolean);
	}
}
