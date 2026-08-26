#define STEP
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DecompTools.Decompiler.FlowAnalysis;
using DecompTools.Decompiler.IL.Transforms;

namespace DecompTools.Decompiler.IL.ControlFlow;

internal class AwaitInCatchTransform
{
	public static void Run(ILFunction function, ILTransformContext context)
	{
		//IL_0351: Unknown result type (might be due to invalid IL or missing references)
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		if (!context.Settings.AwaitInCatchFinally)
		{
			return;
		}
		HashSet<BlockContainer> val = new HashSet<BlockContainer>();
		TryCatch[] array = Enumerable.ToArray<TryCatch>(Enumerable.OfType<TryCatch>((IEnumerable)function.Descendants));
		foreach (TryCatch tryCatch in array)
		{
			if (!(tryCatch.Parent?.Parent is BlockContainer blockContainer))
			{
				continue;
			}
			AnalyzeHandlers(tryCatch.Handlers, out ILVariable _, out List<(int, TryCatchHandler, Block, ILInstruction, IfInstruction, StLoc)> transformableCatchBlocks);
			ControlFlowGraph controlFlowGraph = new ControlFlowGraph(blockContainer, context.CancellationToken);
			if (transformableCatchBlocks.Count > 0)
			{
				val.Add(blockContainer);
			}
			foreach (var item in transformableCatchBlocks)
			{
				ControlFlowNode node = controlFlowGraph.GetNode(item.Item3);
				context.Step("Inline catch block with await", item.Item2);
				Block block = (Block)item.Item5.Parent;
				block.Instructions.RemoveAt(item.Item5.ChildIndex);
				foreach (Branch item2 in Enumerable.OfType<Branch>((IEnumerable)tryCatch.Descendants))
				{
					if (item2.TargetBlock == block)
					{
						if (item.Item4 is BlockContainer targetContainer)
						{
							item2.ReplaceWith(new Leave(targetContainer));
						}
						else
						{
							item2.ReplaceWith(new Branch((Block)item.Item4));
						}
					}
				}
				Block block2 = ((BlockContainer)item.Item2.Body).Blocks.Last();
				item.Item3.Remove();
				((BlockContainer)item.Item2.Body).Blocks.Insert(0, item.Item3);
				block2.Remove();
				ControlFlowNode[] cfg = controlFlowGraph.cfg;
				foreach (ControlFlowNode controlFlowNode in cfg)
				{
					if (((Block)controlFlowNode.UserData).Parent != item.Item2.Body && node.Dominates(controlFlowNode))
					{
						MoveBlock((Block)controlFlowNode.UserData, (BlockContainer)item.Item2.Body);
					}
				}
				if (item.Item6 == null)
				{
					continue;
				}
				LdLoc[] array2 = Enumerable.ToArray<LdLoc>((IEnumerable<LdLoc>)item.Item6.Variable.LoadInstructions);
				foreach (LdLoc ldLoc in array2)
				{
					if (ldLoc.Parent is CastClass castClass && castClass.Type == item.Item2.Variable.Type)
					{
						castClass.ReplaceWith(new LdLoc(item.Item2.Variable));
					}
					else
					{
						ldLoc.ReplaceWith(new LdLoc(item.Item2.Variable));
					}
				}
			}
		}
		Enumerator<BlockContainer> enumerator3 = val.GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				BlockContainer current3 = enumerator3.Current;
				current3.SortBlocks(deleteUnreachableBlocks: true);
			}
		}
		finally
		{
			((IDisposable)enumerator3/*cast due to constrained. prefix*/).Dispose();
		}
	}

	private static void MoveBlock(Block block, BlockContainer target)
	{
		block.Remove();
		target.Blocks.Add(block);
	}

	private static bool AnalyzeHandlers(InstructionCollection<TryCatchHandler> handlers, out ILVariable catchHandlerIdentifier, out List<(int Id, TryCatchHandler Handler, Block RealCatchBlockEntryPoint, ILInstruction NextBlockOrExitContainer, IfInstruction JumpTableEntry, StLoc ObjectVariableStore)> transformableCatchBlocks)
	{
		transformableCatchBlocks = new List<(int, TryCatchHandler, Block, ILInstruction, IfInstruction, StLoc)>();
		catchHandlerIdentifier = null;
		foreach (TryCatchHandler handler in handlers)
		{
			if (MatchAwaitCatchHandler((BlockContainer)handler.Body, out var id, out var identifierVariable, out var realEntryPoint, out var nextBlockOrExitContainer, out var jumpTableEntry, out var objectVariableStore) && id >= 1 && (catchHandlerIdentifier == null || identifierVariable == catchHandlerIdentifier))
			{
				catchHandlerIdentifier = identifierVariable;
				transformableCatchBlocks.Add((id, handler, realEntryPoint, nextBlockOrExitContainer, jumpTableEntry, objectVariableStore));
			}
		}
		return transformableCatchBlocks.Count > 0;
	}

	private static bool MatchAwaitCatchHandler(BlockContainer container, out int id, out ILVariable identifierVariable, out Block realEntryPoint, out ILInstruction nextBlockOrExitContainer, out IfInstruction jumpTableEntry, out StLoc objectVariableStore)
	{
		id = 0;
		identifierVariable = null;
		realEntryPoint = null;
		jumpTableEntry = null;
		objectVariableStore = null;
		nextBlockOrExitContainer = null;
		Block entryPoint = container.EntryPoint;
		if (entryPoint.Instructions.Count < 2 || entryPoint.Instructions.Count > 4)
		{
			return false;
		}
		if (!entryPoint.Instructions.Last().MatchBranch(out var targetBlock))
		{
			return false;
		}
		if (entryPoint.Instructions.Count > 2 && entryPoint.Instructions[checked(entryPoint.Instructions.Count - 3)] is StLoc stLoc)
		{
			objectVariableStore = stLoc;
		}
		ILInstruction iLInstruction = entryPoint.Instructions.SecondToLastOrDefault();
		if (!iLInstruction.MatchStLoc(out identifierVariable, out var value) || !value.MatchLdcI4(out id))
		{
			return false;
		}
		ILVariable variable;
		if (targetBlock.Instructions.Count == 3)
		{
			if (!targetBlock.Instructions[0].MatchStLoc(out variable, out var value2) || !value2.MatchLdLoc(identifierVariable))
			{
				return false;
			}
		}
		else
		{
			if (targetBlock.Instructions.Count != 2)
			{
				return false;
			}
			variable = identifierVariable;
		}
		Block targetBlock2 = targetBlock;
		do
		{
			if (!(targetBlock2.Instructions.SecondToLastOrDefault() is IfInstruction ifInstruction))
			{
				return false;
			}
			ILInstruction iLInstruction2 = targetBlock2.Instructions.Last();
			if (ifInstruction.Condition.MatchCompEquals(out var left, out var right))
			{
				if (!ifInstruction.TrueInst.MatchBranch(out realEntryPoint))
				{
					return false;
				}
				if (!iLInstruction2.MatchBranch(out targetBlock2) && !iLInstruction2.MatchLeave((BlockContainer)iLInstruction2.Parent.Parent))
				{
					return false;
				}
			}
			else
			{
				if (!ifInstruction.Condition.MatchCompNotEquals(out left, out right))
				{
					return false;
				}
				if (!iLInstruction2.MatchBranch(out realEntryPoint))
				{
					return false;
				}
				if (!ifInstruction.TrueInst.MatchBranch(out targetBlock2) && !ifInstruction.TrueInst.MatchLeave((BlockContainer)iLInstruction2.Parent.Parent))
				{
					return false;
				}
			}
			if (!left.MatchLdLoc(variable))
			{
				return false;
			}
			if (right.MatchLdcI4(id))
			{
				nextBlockOrExitContainer = targetBlock2 ?? iLInstruction2.Parent.Parent;
				jumpTableEntry = ifInstruction;
				return true;
			}
		}
		while (targetBlock2 != null && targetBlock2.Instructions.Count == 2);
		return false;
	}
}
