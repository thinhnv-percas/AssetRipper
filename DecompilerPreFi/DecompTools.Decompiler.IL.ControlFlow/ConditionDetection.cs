#define DEBUG
#define STEP
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DecompTools.Decompiler.FlowAnalysis;
using DecompTools.Decompiler.IL.Transforms;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.IL.ControlFlow;

public class ConditionDetection : IBlockTransform
{
	private enum Keyword
	{
		Break,
		Return,
		Continue,
		Other
	}

	private BlockTransformContext context;

	private ControlFlowNode cfgNode;

	private BlockContainer currentContainer;

	public void Run(Block block, BlockTransformContext context)
	{
		this.context = context;
		currentContainer = (BlockContainer)block.Parent;
		cfgNode = context.ControlFlowNode;
		Debug.Assert(cfgNode.UserData == block);
		if (block.Instructions.SecondToLastOrDefault() is IfInstruction ifInst)
		{
			HandleIfInstruction(block, ifInst);
		}
		else
		{
			InlineExitBranch(block);
		}
	}

	private void HandleIfInstruction(Block block, IfInstruction ifInst)
	{
		while (InlineTrueBranch(block, ifInst) || InlineExitBranch(block))
		{
			PickBetterBlockExit(block, ifInst);
			MergeCommonBranches(block, ifInst);
			SwapEmptyThen(ifInst);
			IntroduceShortCircuit(ifInst);
		}
		PickBetterBlockExit(block, ifInst);
		OrderIfBlocks(ifInst);
	}

	private bool InlineTrueBranch(Block block, IfInstruction ifInst)
	{
		if (!CanInline(ifInst.TrueInst))
		{
			if (block.Instructions.SecondToLastOrDefault() == ifInst && ifInst.FalseInst.MatchNop())
			{
				ILInstruction exit = block.Instructions.Last();
				if (DetectExitPoints.CompatibleExitInstruction(ifInst.TrueInst, exit))
				{
					context.Step("Use empty block as then-branch", ifInst.TrueInst);
					ifInst.TrueInst = new Nop().WithILRange(ifInst.TrueInst);
					return false;
				}
			}
			return false;
		}
		context.Step("Inline block as then-branch", ifInst.TrueInst);
		Block targetBlock = ((Branch)ifInst.TrueInst).TargetBlock;
		targetBlock.AddRef();
		targetBlock.Remove();
		ifInst.TrueInst = targetBlock;
		targetBlock.ReleaseRef();
		return true;
	}

	private bool InlineExitBranch(Block block)
	{
		ILInstruction exit = GetExit(block);
		if (!CanInline(exit))
		{
			return false;
		}
		context.Step("Inline target block of unconditional branch", exit);
		Block targetBlock = ((Branch)exit).TargetBlock;
		block.Instructions.RemoveAt(checked(block.Instructions.Count - 1));
		block.Instructions.AddRange(targetBlock.Instructions);
		targetBlock.Remove();
		return true;
	}

	private bool CanInline(ILInstruction exitInst)
	{
		if (exitInst is Branch branch && branch.TargetBlock.Parent == currentContainer && branch.TargetBlock.IncomingEdgeCount == 1)
		{
			Debug.Assert(cfgNode.Dominates(context.ControlFlowGraph.GetNode(branch.TargetBlock)));
			Debug.Assert(branch.TargetBlock.FinalInstruction is Nop);
			return true;
		}
		return false;
	}

	private void MergeCommonBranches(Block block, IfInstruction ifInst)
	{
		List<ILInstruction> thenExits = new List<ILInstruction>();
		AddExits(ifInst.TrueInst, 0, thenExits);
		if (thenExits.Count == 0)
		{
			return;
		}
		Debug.Assert(IsEmpty(ifInst.FalseInst));
		Debug.Assert(ifInst.Parent == block);
		List<ILInstruction> list = new List<ILInstruction>();
		checked
		{
			int startIndex = block.Instructions.IndexOf(ifInst) + 1;
			AddExits(block, startIndex, list);
			IEnumerable<ILInstruction> enumerable = Enumerable.Where<ILInstruction>((IEnumerable<ILInstruction>)list, (Func<ILInstruction, bool>)((ILInstruction e1) => thenExits.Any((ILInstruction exit2) => DetectExitPoints.CompatibleExitInstruction(e1, exit2))));
			ILInstruction iLInstruction = null;
			foreach (ILInstruction item in enumerable)
			{
				if (iLInstruction == null || CompareBlockExitPriority(item, iLInstruction) > 0)
				{
					iLInstruction = item;
				}
			}
			if (iLInstruction == null)
			{
				return;
			}
			ILInstruction exit = block.Instructions.Last();
			if (CompareBlockExitPriority(exit, iLInstruction, strongly: true) <= 0 || WillShortCircuit(block, ifInst, iLInstruction))
			{
				context.StepStartGroup("Merge common branches " + iLInstruction, ifInst);
				ProduceExit(ifInst.TrueInst, 0, iLInstruction);
				ProduceExit(block, startIndex, iLInstruction);
				if (ifInst != block.Instructions.SecondToLastOrDefault())
				{
					context.Step("Embed else-block for goto removal", ifInst);
					Debug.Assert(IsEmpty(ifInst.FalseInst));
					ifInst.FalseInst = ExtractBlock(block, block.Instructions.IndexOf(ifInst) + 1, block.Instructions.Count - 1);
				}
				context.Step("Remove redundant 'goto blockExit;' in then-branch", ifInst);
				if (!(ifInst.TrueInst is Block block2) || block2.Instructions.Count == 1)
				{
					ifInst.TrueInst = new Nop().WithILRange(ifInst.TrueInst);
				}
				else
				{
					block2.Instructions.RemoveAt(block2.Instructions.Count - 1);
				}
				context.StepEndGroup();
			}
		}
	}

	private void AddExits(ILInstruction searchInst, int startIndex, IList<ILInstruction> exits)
	{
		if (!TryGetExit(searchInst, out var exitInst))
		{
			return;
		}
		exits.Add(exitInst);
		if (!(searchInst is Block block))
		{
			return;
		}
		for (int i = startIndex; i < block.Instructions.Count; i = checked(i + 1))
		{
			if (block.Instructions[i] is IfInstruction ifInstruction)
			{
				AddExits(ifInstruction.TrueInst, 0, exits);
			}
		}
	}

	private bool ProduceExit(ILInstruction searchInst, int startIndex, ILInstruction targetExit)
	{
		if (!TryGetExit(searchInst, out var exitInst))
		{
			return false;
		}
		if (DetectExitPoints.CompatibleExitInstruction(exitInst, targetExit))
		{
			return true;
		}
		if (searchInst is Block block)
		{
			for (int i = startIndex; i < block.Instructions.Count; i = checked(i + 1))
			{
				if (block.Instructions[i] is IfInstruction ifInstruction && ProduceExit(ifInstruction.TrueInst, 0, targetExit))
				{
					InvertIf(block, ifInstruction);
					Debug.Assert(DetectExitPoints.CompatibleExitInstruction(GetExit(block), targetExit));
					return true;
				}
			}
		}
		return false;
	}

	private bool WillShortCircuit(Block block, IfInstruction ifInst, ILInstruction elseExit)
	{
		if (!ThenInstIsSingleExit(ifInst))
		{
			return false;
		}
		ILInstruction iLInstruction = elseExit;
		while (iLInstruction.Parent != block)
		{
			iLInstruction = iLInstruction.Parent;
		}
		return block.Instructions.IndexOf(iLInstruction) == checked(block.Instructions.IndexOf(ifInst) + 1) && ThenInstIsSingleExit(iLInstruction);
		static bool ThenInstIsSingleExit(ILInstruction inst)
		{
			ILInstruction condition;
			ILInstruction trueInst;
			return inst.MatchIfInstruction(out condition, out trueInst) && (!(trueInst is Block block2) || block2.Instructions.Count == 1) && TryGetExit(trueInst, out condition);
		}
	}

	private void InvertIf(Block block, IfInstruction ifInst)
	{
		InvertIf(block, ifInst, context);
	}

	internal static void InvertIf(Block block, IfInstruction ifInst, ILTransformContext context)
	{
		Debug.Assert(ifInst.Parent == block);
		ILInstruction exit = GetExit(ifInst.TrueInst);
		ILInstruction exit2 = GetExit(block);
		context.Step("Negate if for desired branch " + exit, ifInst);
		Debug.Assert(IsEmpty(ifInst.FalseInst));
		ILInstruction trueInst = ifInst.TrueInst;
		checked
		{
			if (ifInst != block.Instructions.SecondToLastOrDefault())
			{
				ifInst.TrueInst = ExtractBlock(block, block.Instructions.IndexOf(ifInst) + 1, block.Instructions.Count);
			}
			else
			{
				block.Instructions.RemoveAt(block.Instructions.Count - 1);
				ifInst.TrueInst = exit2;
			}
			if (trueInst is Block block2)
			{
				block.Instructions.AddRange(block2.Instructions);
			}
			else
			{
				block.Instructions.Add(trueInst);
			}
			ifInst.Condition = Comp.LogicNot(ifInst.Condition);
			ExpressionTransforms.RunOnSingleStatement(ifInst, context);
		}
	}

	private void SwapEmptyThen(IfInstruction ifInst)
	{
		if (IsEmpty(ifInst.TrueInst))
		{
			context.Step("Swap empty then-branch with else-branch", ifInst);
			ILInstruction trueInst = ifInst.TrueInst;
			ifInst.TrueInst = ifInst.FalseInst;
			ifInst.FalseInst = new Nop().WithILRange(trueInst);
			ifInst.Condition = Comp.LogicNot(ifInst.Condition);
		}
	}

	private void IntroduceShortCircuit(IfInstruction ifInst)
	{
		if (IsEmpty(ifInst.FalseInst) && ifInst.TrueInst is Block block && block.Instructions.Count == 1 && block.FinalInstruction is Nop && block.Instructions[0].MatchIfInstruction(out var condition, out var trueInst))
		{
			context.Step("Combine 'if (cond1 && cond2)' in then-branch", ifInst);
			ifInst.Condition = IfInstruction.LogicAnd(ifInst.Condition, condition);
			ifInst.TrueInst = trueInst;
		}
	}

	private void OrderIfBlocks(IfInstruction ifInst)
	{
		if (!IsEmpty(ifInst.FalseInst) && GetStartILOffset(ifInst.TrueInst, out var isEmpty) > GetStartILOffset(ifInst.FalseInst, out isEmpty))
		{
			context.Step("Swap then-branch with else-branch to match IL order", ifInst);
			ILInstruction trueInst = ifInst.TrueInst;
			trueInst.AddRef();
			ifInst.TrueInst = ifInst.FalseInst;
			ifInst.FalseInst = trueInst;
			trueInst.ReleaseRef();
			ifInst.Condition = Comp.LogicNot(ifInst.Condition);
		}
	}

	public static int GetStartILOffset(ILInstruction inst, out bool isEmpty)
	{
		if (inst is Leave leave && !leave.Value.MatchNop())
		{
			isEmpty = leave.Value.HasILRange;
			return leave.Value.StartILOffset;
		}
		isEmpty = inst.HasILRange;
		return inst.StartILOffset;
	}

	private void PickBetterBlockExit(Block block, IfInstruction ifInst)
	{
		ILInstruction exit = GetExit(block);
		if (IsEmpty(ifInst.FalseInst) && TryGetExit(ifInst.TrueInst, out var exitInst) && CompareBlockExitPriority(exitInst, exit) > 0)
		{
			InvertIf(block, ifInst);
		}
	}

	private int CompareBlockExitPriority(ILInstruction exit1, ILInstruction exit2, bool strongly = false)
	{
		bool flag = IsKeywordExit(exit1, out var keyword);
		bool flag2 = IsKeywordExit(exit2, out var keyword2);
		if (flag != flag2)
		{
			return (!flag) ? 1 : (-1);
		}
		if (flag)
		{
			if (currentContainer.Kind == ContainerKind.Switch)
			{
				if (keyword == Keyword.Break != (keyword2 == Keyword.Break))
				{
					return (keyword == Keyword.Break) ? 1 : (-1);
				}
			}
			else
			{
				if (keyword == Keyword.Break != (keyword2 == Keyword.Break))
				{
					return (keyword != Keyword.Break) ? 1 : (-1);
				}
				if (keyword == Keyword.Continue != (keyword2 == Keyword.Continue))
				{
					return (keyword == Keyword.Continue) ? 1 : (-1);
				}
			}
		}
		else
		{
			bool flag3 = exit1 is Branch;
			bool flag4 = exit2 is Branch;
			if (flag3 != flag4)
			{
				return (!flag3) ? 1 : (-1);
			}
			if (exit1.MatchLeave(out var targetContainer) && exit2.MatchLeave(out var targetContainer2) && targetContainer != targetContainer2)
			{
				return targetContainer2.IsDescendantOf(targetContainer) ? 1 : (-1);
			}
		}
		if (strongly)
		{
			return 0;
		}
		if (exit1.MatchBranch(out var targetBlock) && exit2.MatchBranch(out var targetBlock2))
		{
			return targetBlock.StartILOffset.CompareTo(targetBlock2.StartILOffset);
		}
		if (exit1.MatchLeave(out var targetContainer3, out var value) && exit2.MatchLeave(out targetContainer3, out var value2))
		{
			return value.StartILOffset.CompareTo(value2.StartILOffset);
		}
		return exit1.StartILOffset.CompareTo(exit2.StartILOffset);
	}

	private bool IsKeywordExit(ILInstruction exitInst, out Keyword keyword)
	{
		keyword = Keyword.Other;
		if (exitInst != null)
		{
			if (exitInst is Branch branch)
			{
				Branch branch2 = branch;
				if (IsContinueBlock(branch2.TargetContainer, branch2.TargetBlock))
				{
					keyword = Keyword.Continue;
					return true;
				}
				return false;
			}
			if (exitInst is Leave leave)
			{
				Leave leave2 = leave;
				if (leave2.IsLeavingFunction)
				{
					keyword = Keyword.Return;
					return true;
				}
				if (leave2.TargetContainer.Kind != ContainerKind.Normal)
				{
					keyword = Keyword.Break;
					return true;
				}
				return false;
			}
		}
		return true;
	}

	private static bool TryGetExit(ILInstruction inst, out ILInstruction exitInst)
	{
		if (inst is Block block && block.Instructions.Count > 0)
		{
			inst = block.Instructions.Last();
		}
		if (inst.HasFlag(InstructionFlags.EndPointUnreachable))
		{
			exitInst = inst;
			return true;
		}
		exitInst = null;
		return false;
	}

	private static ILInstruction GetExit(ILInstruction inst)
	{
		ILInstruction iLInstruction = ((inst is Block block) ? block.Instructions.Last() : inst);
		Debug.Assert(iLInstruction.HasFlag(InstructionFlags.EndPointUnreachable));
		return iLInstruction;
	}

	private static bool IsEmpty(ILInstruction inst)
	{
		return inst is Nop || (inst is Block block && block.Instructions.Count == 0 && block.FinalInstruction is Nop);
	}

	private static bool IsContinueBlock(BlockContainer container, Block block)
	{
		if (container.Kind != ContainerKind.Loop)
		{
			return false;
		}
		if (container.EntryPoint.IncomingEdgeCount == 2)
		{
			Block incrementBlock = HighLevelLoopTransform.GetIncrementBlock(container, container.EntryPoint);
			if (incrementBlock != null)
			{
				return block == incrementBlock;
			}
		}
		return block == container.EntryPoint;
	}

	internal static Block ExtractBlock(Block block, int startIndex, int endIndex)
	{
		Block block2 = new Block();
		checked
		{
			for (int i = startIndex; i < endIndex; i++)
			{
				ILInstruction iLInstruction = block.Instructions[i];
				block2.Instructions.Add(iLInstruction);
				block2.AddILRange(iLInstruction);
			}
			block.Instructions.RemoveRange(startIndex, endIndex - startIndex);
			return block2;
		}
	}
}
