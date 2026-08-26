#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DecompTools.Decompiler.FlowAnalysis;
using DecompTools.Decompiler.IL.Transforms;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.IL.ControlFlow;

internal class SwitchDetection : IILTransform
{
	public class LoopContext
	{
		private readonly IDictionary<ControlFlowNode, int> continueDepth = new Dictionary<ControlFlowNode, int>();

		public LoopContext(ControlFlowGraph cfg, ControlFlowNode contextNode)
		{
			List<ControlFlowNode> loopHeads = new List<ControlFlowNode>();
			contextNode.Successors.ForEach(Analyze);
			ResetVisited(cfg.cfg);
			int num = 1;
			foreach (ControlFlowNode item in (IEnumerable<ControlFlowNode>)Enumerable.OrderBy<ControlFlowNode, int>((IEnumerable<ControlFlowNode>)loopHeads, (Func<ControlFlowNode, int>)((ControlFlowNode n) => n.PostOrderNumber)))
			{
				continueDepth[FindContinue(item)] = checked(num++);
			}
			void Analyze(ControlFlowNode n)
			{
				if (!n.Visited)
				{
					n.Visited = true;
					if (n.Dominates(contextNode))
					{
						loopHeads.Add(n);
					}
					else
					{
						n.Successors.ForEach(Analyze);
					}
				}
			}
		}

		private static ControlFlowNode FindContinue(ControlFlowNode loopHead)
		{
			ControlFlowNode controlFlowNode = loopHead.Predecessors.OnlyOrDefault((ControlFlowNode p) => p != loopHead && loopHead.Dominates(p));
			if (controlFlowNode == null)
			{
				return loopHead;
			}
			if (controlFlowNode.Successors.Count == 1 && HighLevelLoopTransform.MatchIncrementBlock((Block)controlFlowNode.UserData, out var loopHead2) && loopHead2 == loopHead.UserData)
			{
				return controlFlowNode;
			}
			if (controlFlowNode.Successors.Count <= 2 && HighLevelLoopTransform.MatchDoWhileConditionBlock((Block)controlFlowNode.UserData, out var target, out var target2) && (target == loopHead.UserData || target2 == loopHead.UserData))
			{
				return controlFlowNode;
			}
			return loopHead;
		}

		public bool MatchContinue(ControlFlowNode node)
		{
			int depth;
			return MatchContinue(node, out depth);
		}

		public bool MatchContinue(ControlFlowNode node, int depth)
		{
			int depth2;
			return MatchContinue(node, out depth2) && depth == depth2;
		}

		public bool MatchContinue(ControlFlowNode node, out int depth)
		{
			return continueDepth.TryGetValue(node, out depth);
		}

		public int GetContinueDepth(ControlFlowNode node)
		{
			int depth;
			return MatchContinue(node, out depth) ? depth : 0;
		}

		internal IEnumerable<ControlFlowNode> GetBreakTargets(ControlFlowNode dominator)
		{
			return Enumerable.Where<ControlFlowNode>(Enumerable.SelectMany<ControlFlowNode, ControlFlowNode>(TreeTraversal.PreOrder(dominator, (ControlFlowNode n) => Enumerable.Where<ControlFlowNode>((IEnumerable<ControlFlowNode>)n.DominatorTreeChildren, (Func<ControlFlowNode, bool>)((ControlFlowNode c) => !MatchContinue(c)))), (Func<ControlFlowNode, IEnumerable<ControlFlowNode>>)((ControlFlowNode n) => n.Successors)), (Func<ControlFlowNode, bool>)((ControlFlowNode n) => !dominator.Dominates(n) && !MatchContinue(n, 1)));
		}
	}

	private readonly SwitchAnalysis analysis = new SwitchAnalysis();

	private ILTransformContext context;

	private BlockContainer currentContainer;

	private ControlFlowGraph controlFlowGraph;

	private LoopContext loopContext;

	private const ulong MaxValuesPerSection = 100uL;

	public void Run(ILFunction function, ILTransformContext context)
	{
		this.context = context;
		foreach (BlockContainer item in Enumerable.OfType<BlockContainer>((IEnumerable)function.Descendants))
		{
			BlockContainer blockContainer = (currentContainer = item);
			controlFlowGraph = null;
			bool blockContainerNeedsCleanup = false;
			foreach (Block block in blockContainer.Blocks)
			{
				context.CancellationToken.ThrowIfCancellationRequested();
				ProcessBlock(block, ref blockContainerNeedsCleanup);
			}
			if (!blockContainerNeedsCleanup)
			{
				continue;
			}
			Debug.Assert(Enumerable.All<Block>((IEnumerable<Block>)blockContainer.Blocks, (Func<Block, bool>)((Block b) => b.Instructions.Count != 0 || b.IncomingEdgeCount == 0)));
			if (context.Settings.RemoveDeadCode)
			{
				blockContainer.SortBlocks(deleteUnreachableBlocks: true);
				continue;
			}
			blockContainer.Blocks.RemoveAll((Block b) => b.Instructions.Count == 0);
		}
	}

	private void ProcessBlock(Block block, ref bool blockContainerNeedsCleanup)
	{
		checked
		{
			if (analysis.AnalyzeBlock(block) && UseCSharpSwitch(out var _))
			{
				ILInstruction iLInstruction = new LdLoc(analysis.SwitchVariable);
				if (iLInstruction.ResultType == StackType.Unknown)
				{
					iLInstruction = new Conv(iLInstruction, PrimitiveType.I8, checkForOverflow: false, Sign.Signed);
				}
				SwitchInstruction switchInstruction = new SwitchInstruction(iLInstruction);
				foreach (KeyValuePair<LongSet, ILInstruction> section in analysis.Sections)
				{
					switchInstruction.Sections.Add(new SwitchSection
					{
						Labels = section.Key,
						Body = section.Value
					});
				}
				if (!(block.Instructions.Last() is SwitchInstruction))
				{
					Debug.Assert(block.Instructions.SecondToLastOrDefault() is IfInstruction);
					block.Instructions.RemoveAt(block.Instructions.Count - 1);
				}
				switchInstruction.AddILRange(block.Instructions[block.Instructions.Count - 1]);
				block.Instructions[block.Instructions.Count - 1] = switchInstruction;
				foreach (Block innerBlock in analysis.InnerBlocks)
				{
					Debug.Assert(innerBlock.Parent == block.Parent);
					Debug.Assert(innerBlock != ((BlockContainer)block.Parent).EntryPoint);
					innerBlock.Instructions.Clear();
				}
				controlFlowGraph = null;
				blockContainerNeedsCleanup = true;
				SortSwitchSections(switchInstruction);
			}
			else
			{
				SimplifySwitchInstruction(block);
			}
		}
	}

	internal static void SimplifySwitchInstruction(Block block)
	{
		if (!(block.Instructions.LastOrDefault() is SwitchInstruction switchInstruction))
		{
			return;
		}
		Dictionary<Block, SwitchSection> dict = new Dictionary<Block, SwitchSection>();
		switchInstruction.Sections.RemoveAll(delegate(SwitchSection section)
		{
			if (section.Body.MatchBranch(out var targetBlock))
			{
				if (dict.TryGetValue(targetBlock, out var value))
				{
					value.Labels = value.Labels.UnionWith(section.Labels);
					value.HasNullLabel |= section.HasNullLabel;
					return true;
				}
				dict.Add(targetBlock, section);
			}
			return false;
		});
		AdjustLabels(switchInstruction);
		SortSwitchSections(switchInstruction);
	}

	private static void SortSwitchSections(SwitchInstruction sw)
	{
		sw.Sections.ReplaceList((IEnumerable<SwitchSection>)Enumerable.ThenBy<SwitchSection, long>(Enumerable.OrderBy<SwitchSection, int?>((IEnumerable<SwitchSection>)sw.Sections, (Func<SwitchSection, int?>)((SwitchSection s) => (s.Body as Branch)?.TargetILOffset)), (Func<SwitchSection, long>)((SwitchSection s) => Enumerable.FirstOrDefault<long>(s.Labels.Values))));
	}

	private static void AdjustLabels(SwitchInstruction sw)
	{
		if (!(sw.Value is BinaryNumericInstruction { CheckForOverflow: false } binaryNumericInstruction) || !binaryNumericInstruction.Right.MatchLdcI(out var val))
		{
			return;
		}
		long val2;
		switch (binaryNumericInstruction.Operator)
		{
		default:
			return;
		case BinaryNumericOperator.Add:
			val2 = -val;
			break;
		case BinaryNumericOperator.Sub:
			val2 = val;
			break;
		}
		sw.Value = binaryNumericInstruction.Left;
		foreach (SwitchSection section in sw.Sections)
		{
			section.Labels = section.Labels.AddOffset(val2);
		}
	}

	private bool UseCSharpSwitch(out KeyValuePair<LongSet, ILInstruction> defaultSection)
	{
		if (!analysis.InnerBlocks.Any())
		{
			defaultSection = default(KeyValuePair<LongSet, ILInstruction>);
			return false;
		}
		defaultSection = analysis.Sections.FirstOrDefault((KeyValuePair<LongSet, ILInstruction> s) => s.Key.Count() > 100);
		if (defaultSection.Value == null)
		{
			return false;
		}
		LongSet defaultSectionKey = defaultSection.Key;
		if (analysis.Sections.Any((KeyValuePair<LongSet, ILInstruction> s) => !s.Key.SetEquals(defaultSectionKey) && s.Key.Count() > 100))
		{
			return false;
		}
		if (analysis.ContainsILSwitch || MatchRoslynSwitchOnString())
		{
			return true;
		}
		int num = checked(analysis.InnerBlocks.Count + 1);
		int num2 = Enumerable.Sum<KeyValuePair<LongSet, ILInstruction>>(Enumerable.Where<KeyValuePair<LongSet, ILInstruction>>((IEnumerable<KeyValuePair<LongSet, ILInstruction>>)analysis.Sections, (Func<KeyValuePair<LongSet, ILInstruction>, bool>)((KeyValuePair<LongSet, ILInstruction> s) => !s.Key.SetEquals(defaultSectionKey))), (Func<KeyValuePair<LongSet, ILInstruction>, int>)((KeyValuePair<LongSet, ILInstruction> s) => s.Key.Intervals.Length));
		if (num < num2)
		{
			return false;
		}
		var (flowNodes, caseNodes) = AnalyzeControlFlow();
		if (analysis.Sections.Count == 2 && IsSingleCondition(flowNodes, caseNodes))
		{
			return false;
		}
		if (SwitchUsesGoto(flowNodes, caseNodes, out var breakBlock))
		{
			return false;
		}
		if (breakBlock == null)
		{
			return true;
		}
		return breakBlock.StartILOffset >= Enumerable.Max(Enumerable.Select<KeyValuePair<LongSet, ILInstruction>, int>((IEnumerable<KeyValuePair<LongSet, ILInstruction>>)analysis.Sections, (Func<KeyValuePair<LongSet, ILInstruction>, int>)((KeyValuePair<LongSet, ILInstruction> s) => s.Value.MatchBranch(out var targetBlock) ? targetBlock.StartILOffset : (-1))));
	}

	private bool MatchRoslynSwitchOnString()
	{
		InstructionCollection<ILInstruction> instructions = analysis.RootBlock.Instructions;
		LdLoc switchValue;
		return instructions.Count >= 3 && SwitchOnStringTransform.MatchComputeStringHashCall(instructions[checked(instructions.Count - 3)], analysis.SwitchVariable, out switchValue);
	}

	private (List<ControlFlowNode> flowNodes, List<ControlFlowNode> caseNodes) AnalyzeControlFlow()
	{
		if (controlFlowGraph == null)
		{
			controlFlowGraph = new ControlFlowGraph(currentContainer, context.CancellationToken);
		}
		ControlFlowNode node = controlFlowGraph.GetNode(analysis.RootBlock);
		loopContext = new LoopContext(controlFlowGraph, node);
		List<ControlFlowNode> flowNodes = new List<ControlFlowNode> { node };
		flowNodes.AddRange(Enumerable.Select<Block, ControlFlowNode>((IEnumerable<Block>)analysis.InnerBlocks, (Func<Block, ControlFlowNode>)controlFlowGraph.GetNode));
		List<ControlFlowNode> caseNodes = new List<ControlFlowNode>();
		foreach (KeyValuePair<LongSet, ILInstruction> section in analysis.Sections)
		{
			if (section.Value.MatchBranch(out var targetBlock) && targetBlock.Parent == currentContainer)
			{
				ControlFlowNode node2 = controlFlowGraph.GetNode(targetBlock);
				if (!loopContext.MatchContinue(node2))
				{
					caseNodes.Add(node2);
				}
			}
		}
		AddNullCase(flowNodes, caseNodes);
		Debug.Assert(Enumerable.All<ControlFlowNode>(Enumerable.SelectMany<ControlFlowNode, ControlFlowNode>((IEnumerable<ControlFlowNode>)flowNodes, (Func<ControlFlowNode, IEnumerable<ControlFlowNode>>)((ControlFlowNode n) => n.Successors)), (Func<ControlFlowNode, bool>)((ControlFlowNode n) => flowNodes.Contains(n) || caseNodes.Contains(n) || loopContext.MatchContinue(n))));
		return (flowNodes: flowNodes, caseNodes: caseNodes);
	}

	private bool SwitchUsesGoto(List<ControlFlowNode> flowNodes, List<ControlFlowNode> caseNodes, out Block breakBlock)
	{
		List<ControlFlowNode> list = Enumerable.ToList<ControlFlowNode>(Enumerable.Where<ControlFlowNode>((IEnumerable<ControlFlowNode>)caseNodes, (Func<ControlFlowNode, bool>)((ControlFlowNode c) => c.Predecessors.Any((ControlFlowNode n) => !flowNodes.Contains(n)))));
		breakBlock = null;
		if (list.Count > 1)
		{
			return true;
		}
		HashSet<ControlFlowNode> val = Enumerable.SelectMany<ControlFlowNode, ControlFlowNode>(Enumerable.Except<ControlFlowNode>((IEnumerable<ControlFlowNode>)caseNodes, (IEnumerable<ControlFlowNode>)list), (Func<ControlFlowNode, IEnumerable<ControlFlowNode>>)((ControlFlowNode n) => loopContext.GetBreakTargets(n))).ToHashSet();
		if (val.Count != 1)
		{
			return val.Count > 1;
		}
		breakBlock = (Block)Enumerable.Single<ControlFlowNode>((IEnumerable<ControlFlowNode>)val).UserData;
		return list.Count == 1 && breakBlock != Enumerable.Single<ControlFlowNode>((IEnumerable<ControlFlowNode>)list).UserData;
	}

	private void AddNullCase(List<ControlFlowNode> flowNodes, List<ControlFlowNode> caseNodes)
	{
		if (analysis.RootBlock.IncomingEdgeCount == 1)
		{
			Block block = (Block)(Enumerable.SingleOrDefault<ControlFlowNode>((IEnumerable<ControlFlowNode>)controlFlowGraph.GetNode(analysis.RootBlock).Predecessors)?.UserData);
			if (block != null && block.Instructions.Count >= 2 && block.Instructions.Last().MatchBranch(analysis.RootBlock) && block.Instructions.SecondToLastOrDefault().MatchIfInstruction(out var condition, out var trueInst) && condition.MatchLogicNot(out var arg) && NullableLiftingTransform.MatchHasValueCall(arg, out ILInstruction _) && trueInst.MatchBranch(out var nullBlock) && caseNodes.Exists((ControlFlowNode n) => n.UserData == nullBlock))
			{
				flowNodes.Add(controlFlowGraph.GetNode(block));
			}
		}
	}

	private static bool IsShortCircuit(ControlFlowNode parent, int side)
	{
		ControlFlowNode controlFlowNode = parent.Successors[side];
		ControlFlowNode item = parent.Successors[side ^ 1];
		if (!IsFlowNode(controlFlowNode) || controlFlowNode.Successors.Count > 2 || controlFlowNode.Predecessors.Count != 1)
		{
			return false;
		}
		return controlFlowNode.Successors.Contains(item);
	}

	private static bool IsFlowNode(ControlFlowNode n)
	{
		return ((Block)n.UserData).Instructions.FirstOrDefault() is IfInstruction;
	}

	private bool IsSingleCondition(List<ControlFlowNode> flowNodes, List<ControlFlowNode> caseNodes)
	{
		if (flowNodes.Count == 1)
		{
			return true;
		}
		ControlFlowNode node = controlFlowGraph.GetNode(analysis.RootBlock);
		node.Visited = true;
		ControlFlowNode controlFlowNode = node;
		while (controlFlowNode.Successors.Count > 0 && (controlFlowNode == node || IsFlowNode(controlFlowNode)))
		{
			if (controlFlowNode.Successors.Count == 1)
			{
				if (caseNodes.Count > 1)
				{
					break;
				}
				controlFlowNode = controlFlowNode.Successors[0];
			}
			else if (IsShortCircuit(controlFlowNode, 0))
			{
				controlFlowNode = controlFlowNode.Successors[0];
			}
			else
			{
				if (!IsShortCircuit(controlFlowNode, 1))
				{
					break;
				}
				controlFlowNode = controlFlowNode.Successors[1];
			}
			controlFlowNode.Visited = true;
			if (loopContext.MatchContinue(controlFlowNode))
			{
				break;
			}
		}
		bool result = flowNodes.All((ControlFlowNode f) => f.Visited);
		ResetVisited(controlFlowGraph.cfg);
		return result;
	}

	private static void ResetVisited(IEnumerable<ControlFlowNode> nodes)
	{
		foreach (ControlFlowNode node in nodes)
		{
			node.Visited = false;
		}
	}
}
