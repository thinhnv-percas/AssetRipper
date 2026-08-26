#define DEBUG
#define STEP
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DecompTools.Decompiler.FlowAnalysis;
using DecompTools.Decompiler.IL.ControlFlow;
using DecompTools.Decompiler.IL.Transforms;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.IL;

public class ReduceNestingTransform : IILTransform
{
	private ILTransformContext context;

	public void Run(ILFunction function, ILTransformContext context)
	{
		this.context = context;
		Visit((BlockContainer)function.Body, null);
		foreach (TryFinally item in Enumerable.OfType<TryFinally>((IEnumerable)function.Descendants))
		{
			EliminateRedundantTryFinally(item, context);
		}
	}

	private void Visit(BlockContainer container, Block continueTarget)
	{
		switch (container.Kind)
		{
		case ContainerKind.Loop:
		case ContainerKind.While:
			continueTarget = container.EntryPoint;
			break;
		case ContainerKind.DoWhile:
		case ContainerKind.For:
			continueTarget = container.Blocks.Last();
			break;
		}
		foreach (Block block in container.Blocks)
		{
			Visit(block, continueTarget);
		}
	}

	private void Visit(Block block, Block continueTarget, ILInstruction nextInstruction = null)
	{
		Debug.Assert(block.HasFlag(InstructionFlags.EndPointUnreachable) || nextInstruction != null);
		int i;
		checked
		{
			for (i = 0; i < block.Instructions.Count; i++)
			{
				ILInstruction iLInstruction = block.Instructions[i];
				ILInstruction iLInstruction2 = iLInstruction;
				ILInstruction iLInstruction3 = iLInstruction2;
				if (iLInstruction3 == null)
				{
					continue;
				}
				if (!(iLInstruction3 is BlockContainer blockContainer))
				{
					if (!(iLInstruction3 is IfInstruction ifInstruction))
					{
						continue;
					}
					IfInstruction ifInstruction2 = ifInstruction;
					ImproveILOrdering(block, ifInstruction2);
					if (CanDuplicateExit(NextInsn(), continueTarget) && ReduceNesting(block, ifInstruction2, NextInsn()))
					{
						RemoveRedundantExit(block, nextInstruction);
					}
					if (ifInstruction2.TrueInst is Block block2)
					{
						Visit(block2, continueTarget, NextInsn());
					}
					if (ifInstruction2.FalseInst is Block block3)
					{
						if (ifInstruction2.TrueInst.HasFlag(InstructionFlags.EndPointUnreachable))
						{
							ExtractElseBlock(ifInstruction2);
						}
						else
						{
							Visit(block3, continueTarget, NextInsn());
						}
					}
				}
				else
				{
					BlockContainer blockContainer2 = blockContainer;
					Visit(blockContainer2, continueTarget);
					if (blockContainer2.Kind == ContainerKind.Switch && CanDuplicateExit(NextInsn(), continueTarget) && ReduceNesting(block, blockContainer2, NextInsn()))
					{
						RemoveRedundantExit(block, nextInstruction);
					}
				}
			}
		}
		ILInstruction NextInsn()
		{
			return checked((i + 1 < block.Instructions.Count) ? block.Instructions[i + 1] : nextInstruction);
		}
	}

	private void ImproveILOrdering(Block block, IfInstruction ifInst)
	{
		if (block.HasFlag(InstructionFlags.EndPointUnreachable) && ifInst.TrueInst.HasFlag(InstructionFlags.EndPointUnreachable) && ifInst.FalseInst.MatchNop())
		{
			Debug.Assert(ifInst != block.Instructions.Last());
			int startILOffset = ConditionDetection.GetStartILOffset(ifInst.TrueInst, out var isEmpty);
			int startILOffset2 = ConditionDetection.GetStartILOffset(block.Instructions[checked(block.Instructions.IndexOf(ifInst) + 1)], out var isEmpty2);
			if (!isEmpty && !isEmpty2 && startILOffset2 < startILOffset)
			{
				ConditionDetection.InvertIf(block, ifInst, context);
			}
		}
	}

	private bool ReduceNesting(Block block, IfInstruction ifInst, ILInstruction exitInst)
	{
		int maxStatements = 0;
		int maxDepth = 0;
		UpdateStats(ifInst.TrueInst, ref maxStatements, ref maxDepth);
		if (ifInst.FalseInst.MatchNop())
		{
			if (maxDepth < 2)
			{
				return false;
			}
			EnsureEndPointUnreachable(ifInst.TrueInst, exitInst);
			EnsureEndPointUnreachable(block, exitInst);
			ConditionDetection.InvertIf(block, ifInst, context);
			return true;
		}
		if (GetElseIfParent(ifInst) != null)
		{
			return false;
		}
		while (Block.Unwrap(ifInst.FalseInst) is IfInstruction ifInstruction)
		{
			UpdateStats(ifInstruction.TrueInst, ref maxStatements, ref maxDepth);
			ifInst = ifInstruction;
		}
		if (!ShouldReduceNesting(ifInst.FalseInst, maxStatements, maxDepth))
		{
			return false;
		}
		do
		{
			IfInstruction elseIfParent = GetElseIfParent(ifInst);
			EnsureEndPointUnreachable(ifInst.TrueInst, exitInst);
			ExtractElseBlock(ifInst);
			ifInst = elseIfParent;
		}
		while (ifInst != null);
		return true;
	}

	private bool ReduceNesting(Block parentBlock, BlockContainer switchContainer, ILInstruction exitInst)
	{
		if (exitInst is Leave { IsLeavingFunction: false })
		{
			return false;
		}
		SwitchInstruction switchInstruction = (SwitchInstruction)Enumerable.Single<ILInstruction>((IEnumerable<ILInstruction>)switchContainer.EntryPoint.Instructions);
		SwitchSection switchSection = switchInstruction.Sections.MaxBy((SwitchSection s) => s.Labels.Count());
		if (!switchSection.Body.MatchBranch(out var targetBlock) || targetBlock.IncomingEdgeCount != 1)
		{
			return false;
		}
		int maxStatements = 0;
		int maxDepth = 0;
		foreach (SwitchSection section in switchInstruction.Sections)
		{
			if (section != switchSection && section.Body.MatchBranch(out var targetBlock2) && targetBlock2.Parent == switchContainer)
			{
				UpdateStats(targetBlock2, ref maxStatements, ref maxDepth);
			}
		}
		if (!ShouldReduceNesting(targetBlock, maxStatements, maxDepth))
		{
			return false;
		}
		Debug.Assert(targetBlock.HasFlag(InstructionFlags.EndPointUnreachable));
		ControlFlowGraph controlFlowGraph = new ControlFlowGraph(switchContainer, context.CancellationToken);
		ControlFlowNode defaultNode = controlFlowGraph.GetNode(targetBlock);
		List<ControlFlowNode> list = Enumerable.ToList<ControlFlowNode>(TreeTraversal.PreOrder(defaultNode, (ControlFlowNode n) => n.DominatorTreeChildren));
		if (Enumerable.Any<ControlFlowNode>(Enumerable.SelectMany<ControlFlowNode, ControlFlowNode>((IEnumerable<ControlFlowNode>)list, (Func<ControlFlowNode, IEnumerable<ControlFlowNode>>)((ControlFlowNode n) => n.Successors)), (Func<ControlFlowNode, bool>)((ControlFlowNode n) => !defaultNode.Dominates(n))))
		{
			return false;
		}
		EnsureEndPointUnreachable(parentBlock, exitInst);
		context.Step("Extract default case of switch", switchContainer);
		IEnumerable<ILInstruction> enumerable = Enumerable.Where<ILInstruction>(switchContainer.Descendants, (Func<ILInstruction, bool>)((ILInstruction inst) => inst.MatchLeave(switchContainer)));
		ILInstruction[] array = Enumerable.ToArray<ILInstruction>(enumerable);
		foreach (ILInstruction iLInstruction in array)
		{
			iLInstruction.ReplaceWith(exitInst.Clone());
		}
		switchSection.Body.ReplaceWith(new Leave(switchContainer));
		List<Block> list2 = Enumerable.ToList<Block>(Enumerable.Select<ControlFlowNode, Block>((IEnumerable<ControlFlowNode>)list, (Func<ControlFlowNode, Block>)((ControlFlowNode c) => (Block)c.UserData)));
		foreach (Block item in list2)
		{
			switchContainer.Blocks.Remove(item);
		}
		parentBlock.Instructions.RemoveLast();
		parentBlock.Instructions.AddRange(targetBlock.Instructions);
		BlockContainer blockContainer = (BlockContainer)Enumerable.First<ILInstruction>(parentBlock.Ancestors, (Func<ILInstruction, bool>)((ILInstruction p) => p is BlockContainer));
		checked
		{
			int num2 = blockContainer.Blocks.IndexOf(parentBlock) + 1;
			foreach (Block item2 in Enumerable.Skip<Block>((IEnumerable<Block>)list2, 1))
			{
				blockContainer.Blocks.Insert(num2++, item2);
			}
			return true;
		}
	}

	private bool CanDuplicateExit(ILInstruction exit, Block continueTarget)
	{
		return exit != null && ((exit is Leave leave && leave.Value.MatchNop()) || exit.MatchBranch(continueTarget));
	}

	private void EnsureEndPointUnreachable(ILInstruction inst, ILInstruction fallthroughExit)
	{
		if (!(inst is Block block))
		{
			Debug.Assert(inst.HasFlag(InstructionFlags.EndPointUnreachable));
		}
		else if (!block.HasFlag(InstructionFlags.EndPointUnreachable))
		{
			context.Step("Duplicate block exit", fallthroughExit);
			block.Instructions.Add(fallthroughExit.Clone());
		}
	}

	private void RemoveRedundantExit(Block block, ILInstruction implicitExit)
	{
		if (block.Instructions.Last().Match(implicitExit).Success)
		{
			context.Step("Remove redundant exit", block.Instructions.Last());
			block.Instructions.RemoveLast();
		}
	}

	private IfInstruction GetElseIfParent(IfInstruction ifInst)
	{
		Debug.Assert(ifInst.Parent is Block);
		if (Block.Unwrap(ifInst.Parent) == ifInst && ifInst.Parent.Parent is IfInstruction ifInstruction && ifInstruction.FalseInst == ifInst.Parent)
		{
			return ifInstruction;
		}
		return null;
	}

	private void UpdateStats(ILInstruction inst, ref int maxStatements, ref int maxDepth)
	{
		int numStatements = 0;
		ComputeStats(inst, ref numStatements, ref maxDepth, 0);
		maxStatements = Math.Max(numStatements, maxStatements);
	}

	private void ComputeStats(ILInstruction inst, ref int numStatements, ref int maxDepth, int currentDepth)
	{
		checked
		{
			if (inst != null)
			{
				if (inst is Block block)
				{
					Block block2 = block;
					{
						foreach (ILInstruction instruction in block2.Instructions)
						{
							ComputeStats(instruction, ref numStatements, ref maxDepth, currentDepth);
						}
						return;
					}
				}
				if (inst is BlockContainer blockContainer)
				{
					BlockContainer blockContainer2 = blockContainer;
					numStatements++;
					Block bodyStartBlock = blockContainer2.EntryPoint;
					if ((blockContainer2.Kind == ContainerKind.For || blockContainer2.Kind == ContainerKind.While) && !blockContainer2.MatchConditionBlock(blockContainer2.EntryPoint, out var _, out bodyStartBlock))
					{
						throw new NotSupportedException("Invalid condition block in loop.");
					}
					ComputeStats(bodyStartBlock, ref numStatements, ref maxDepth, currentDepth + 1);
					return;
				}
				if (inst is IfInstruction ifInstruction)
				{
					IfInstruction ifInstruction2 = ifInstruction;
					numStatements++;
					ComputeStats(ifInstruction2.TrueInst, ref numStatements, ref maxDepth, currentDepth + 1);
					ILInstruction falseInst = ifInstruction2.FalseInst;
					while (Block.Unwrap(falseInst) is IfInstruction ifInstruction3)
					{
						numStatements++;
						ComputeStats(ifInstruction3.TrueInst, ref numStatements, ref maxDepth, currentDepth + 1);
						falseInst = ifInstruction3.FalseInst;
					}
					ComputeStats(falseInst, ref numStatements, ref maxDepth, currentDepth + 1);
					return;
				}
				if (inst is SwitchInstruction switchInstruction)
				{
					SwitchInstruction switchInstruction2 = switchInstruction;
					numStatements += switchInstruction2.Sections.Count + 1;
					{
						foreach (SwitchSection section in switchInstruction2.Sections)
						{
							if (section.Body.MatchBranch(out var targetBlock) && targetBlock.Parent == switchInstruction2.Parent.Parent)
							{
								ComputeStats(targetBlock, ref numStatements, ref maxDepth, currentDepth);
							}
						}
						return;
					}
				}
			}
			numStatements++;
			if (currentDepth > maxDepth)
			{
				maxDepth = currentDepth;
			}
		}
	}

	private bool ShouldReduceNesting(ILInstruction inst, int maxStatements, int maxDepth)
	{
		int maxStatements2 = 0;
		int maxDepth2 = 0;
		UpdateStats(inst, ref maxStatements2, ref maxDepth2);
		return maxDepth2 >= 2 || (maxDepth2 >= 1 && maxStatements2 > maxStatements) || maxStatements2 >= checked(2 * maxStatements);
	}

	private void ExtractElseBlock(IfInstruction ifInst)
	{
		Debug.Assert(ifInst.TrueInst.HasFlag(InstructionFlags.EndPointUnreachable));
		Block block = (Block)ifInst.Parent;
		Block block2 = (Block)ifInst.FalseInst;
		context.Step("Extract else block", ifInst);
		checked
		{
			int num = block.Instructions.IndexOf(ifInst) + 1;
			for (int i = 0; i < block2.Instructions.Count; i++)
			{
				block.Instructions.Insert(num++, block2.Instructions[i]);
			}
			ifInst.FalseInst = new Nop();
		}
	}

	private void EliminateRedundantTryFinally(TryFinally tryFinally, ILTransformContext context)
	{
		if (tryFinally.FinallyBlock is BlockContainer blockContainer && blockContainer.SingleInstruction().MatchLeave(blockContainer) && tryFinally.TryBlock is BlockContainer blockContainer2 && blockContainer2.SingleInstruction() is PinnedRegion pinnedRegion)
		{
			context.Step("Removing try-finally around PinnedRegion", pinnedRegion);
			tryFinally.ReplaceWith(pinnedRegion);
		}
	}
}
