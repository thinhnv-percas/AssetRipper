#define STEP
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DecompTools.Decompiler.FlowAnalysis;
using DecompTools.Decompiler.IL.Transforms;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL.ControlFlow;

internal class AwaitInFinallyTransform
{
	public static void Run(ILFunction function, ILTransformContext context)
	{
		//IL_0421: Unknown result type (might be due to invalid IL or missing references)
		//IL_0426: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a8: Unknown result type (might be due to invalid IL or missing references)
		HashSet<BlockContainer> val = new HashSet<BlockContainer>();
		TryCatch[] array = Enumerable.ToArray<TryCatch>(Enumerable.OfType<TryCatch>((IEnumerable)function.Descendants));
		foreach (TryCatch tryCatch in array)
		{
			if (!(tryCatch.Parent?.Parent is BlockContainer blockContainer) || tryCatch.Handlers.Count != 1 || !(tryCatch.Handlers[0].Body is BlockContainer blockContainer2) || !tryCatch.Handlers[0].Variable.Type.IsKnownType(KnownTypeCode.Object))
			{
				continue;
			}
			Block entryPoint = blockContainer2.EntryPoint;
			if (entryPoint.Instructions.Count < 2 || !entryPoint.Instructions[0].MatchStLoc(out var variable, out var value) || !value.MatchLdLoc(tryCatch.Handlers[0].Variable))
			{
				continue;
			}
			if (entryPoint.Instructions.Count == 3)
			{
				if (!entryPoint.Instructions[1].MatchStLoc(out var variable2, out value) || !value.MatchLdLoc(variable))
				{
					continue;
				}
				variable = variable2;
			}
			if (!entryPoint.Instructions[checked(entryPoint.Instructions.Count - 1)].MatchBranch(out var targetBlock) || variable.LoadCount != 1 || variable.StoreCount > 2 || !(variable.LoadInstructions[0].Parent is StLoc stLoc) || !MatchExceptionCaptureBlock(stLoc, out var endOfFinally, out var afterFinally, out var blocksToRemove) || !MatchAfterFinallyBlock(ref afterFinally, blocksToRemove, out var removeFirstInstructionInAfterFinally))
			{
				continue;
			}
			ControlFlowGraph controlFlowGraph = new ControlFlowGraph(blockContainer, context.CancellationToken);
			ControlFlowNode exitOfFinallyNode = controlFlowGraph.GetNode(endOfFinally);
			ControlFlowNode entryPointOfFinallyNode = controlFlowGraph.GetNode(targetBlock);
			HashSet<Block> additionalBlocksInFinally = new HashSet<Block>();
			List<ControlFlowNode> invalidExits = new List<ControlFlowNode>();
			TraverseDominatorTree(entryPointOfFinallyNode);
			if (Enumerable.Any<ControlFlowNode>((IEnumerable<ControlFlowNode>)invalidExits))
			{
				continue;
			}
			context.Step("Inline finally block with await", tryCatch.Handlers[0]);
			foreach (Block item in blocksToRemove)
			{
				item.Remove();
			}
			BlockContainer blockContainer3 = new BlockContainer();
			targetBlock.Remove();
			if (removeFirstInstructionInAfterFinally)
			{
				afterFinally.Instructions.RemoveAt(0);
			}
			val.Add(blockContainer);
			BlockContainer blockContainer4 = BlockContainer.FindClosestContainer(blockContainer.Parent);
			if (blockContainer4 != null)
			{
				val.Add(blockContainer4);
			}
			blockContainer3.Blocks.Add(targetBlock);
			blockContainer3.AddILRange(targetBlock);
			endOfFinally.Instructions.RemoveRange(stLoc.ChildIndex, 3);
			endOfFinally.Instructions.Add(new Leave(blockContainer3));
			foreach (Branch item2 in Enumerable.OfType<Branch>((IEnumerable)blockContainer.Descendants))
			{
				if (item2.TargetBlock == targetBlock)
				{
					item2.ReplaceWith(new Branch(afterFinally));
				}
			}
			var enumerator3 = additionalBlocksInFinally.GetEnumerator();
			try
			{
				while (enumerator3.MoveNext())
				{
					Block current3 = enumerator3.Current;
					current3.Remove();
					blockContainer3.Blocks.Add(current3);
					blockContainer3.AddILRange(current3);
				}
			}
			finally
			{
				((IDisposable)enumerator3/*cast due to constrained. prefix*/).Dispose();
			}
			tryCatch.ReplaceWith(new TryFinally(tryCatch.TryBlock, blockContainer3).WithILRange(tryCatch.TryBlock));
			void TraverseDominatorTree(ControlFlowNode node)
			{
				if (entryPointOfFinallyNode != node)
				{
					if (entryPointOfFinallyNode.Dominates(node))
					{
						additionalBlocksInFinally.Add((Block)node.UserData);
					}
					else
					{
						invalidExits.Add(node);
					}
				}
				if (node == exitOfFinallyNode)
				{
					return;
				}
				foreach (ControlFlowNode dominatorTreeChild in node.DominatorTreeChildren)
				{
					TraverseDominatorTree(dominatorTreeChild);
				}
			}
		}
		var enumerator4 = val.GetEnumerator();
		try
		{
			while (enumerator4.MoveNext())
			{
				BlockContainer current4 = enumerator4.Current;
				current4.SortBlocks(deleteUnreachableBlocks: true);
			}
		}
		finally
		{
			((IDisposable)enumerator4/*cast due to constrained. prefix*/).Dispose();
		}
	}

	private static bool MatchExceptionCaptureBlock(StLoc tempStore, out Block endOfFinally, out Block afterFinally, out List<Block> blocksToRemove)
	{
		afterFinally = null;
		endOfFinally = (Block)tempStore.Parent;
		blocksToRemove = new List<Block>();
		int count = endOfFinally.Instructions.Count;
		checked
		{
			if (tempStore.ChildIndex != count - 3)
			{
				return false;
			}
			if (!(endOfFinally.Instructions[count - 2] is IfInstruction ifInstruction))
			{
				return false;
			}
			if (!endOfFinally.Instructions.Last().MatchBranch(out var targetBlock))
			{
				return false;
			}
			if (!ifInstruction.TrueInst.MatchBranch(out afterFinally))
			{
				return false;
			}
			if (targetBlock.Instructions.Count != 3)
			{
				return false;
			}
			if (!targetBlock.Instructions[0].MatchStLoc(out var variable, out var value) || !value.MatchIsInst(out var argument, out var type) || !type.IsKnownType(KnownTypeCode.Exception) || !argument.MatchLdLoc(tempStore.Variable))
			{
				return false;
			}
			if (!targetBlock.Instructions[1].MatchIfInstruction(out var condition, out var trueInst))
			{
				return false;
			}
			if (!condition.MatchCompNotEqualsNull(out argument) || !argument.MatchLdLoc(variable))
			{
				return false;
			}
			if (!targetBlock.Instructions[2].MatchBranch(out var targetBlock2))
			{
				return false;
			}
			if (!trueInst.MatchBranch(out var targetBlock3))
			{
				return false;
			}
			if (targetBlock2.Instructions.Count != 1 || !targetBlock2.Instructions[0].MatchThrow(out argument) || !argument.MatchLdLoc(tempStore.Variable))
			{
				return false;
			}
			if (targetBlock3.Instructions.Count != 2)
			{
				return false;
			}
			if (!targetBlock3.Instructions[1].MatchBranch(afterFinally))
			{
				return false;
			}
			if (!(targetBlock3.Instructions[0] is CallVirt callVirt) || callVirt.Method.FullName != "System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw" || callVirt.Arguments.Count != 1)
			{
				return false;
			}
			if (!(callVirt.Arguments[0] is Call call) || call.Method.FullName != "System.Runtime.ExceptionServices.ExceptionDispatchInfo.Capture" || call.Arguments.Count != 1)
			{
				return false;
			}
			if (!call.Arguments[0].MatchLdLoc(variable))
			{
				return false;
			}
			blocksToRemove.Add(targetBlock);
			blocksToRemove.Add(targetBlock2);
			blocksToRemove.Add(targetBlock3);
			return true;
		}
	}

	private static bool MatchAfterFinallyBlock(ref Block afterFinally, List<Block> blocksToRemove, out bool removeFirstInstructionInAfterFinally)
	{
		removeFirstInstructionInAfterFinally = false;
		if (afterFinally.Instructions.Count < 2)
		{
			return false;
		}
		ILInstruction iLInstruction = afterFinally.Instructions[0];
		ILInstruction iLInstruction2 = iLInstruction;
		if (iLInstruction2 == null)
		{
			goto IL_01d0;
		}
		if (!(iLInstruction2 is IfInstruction ifInstruction))
		{
			ILVariable variable;
			if (!(iLInstruction2 is LdLoc ldLoc))
			{
				if (!(iLInstruction2 is StLoc stLoc))
				{
					goto IL_01d0;
				}
				StLoc stLoc2 = stLoc;
				variable = stLoc2.Variable;
				if (!stLoc2.Value.MatchLdNull())
				{
					return false;
				}
			}
			else
			{
				LdLoc ldLoc2 = ldLoc;
				if (ldLoc2.Variable.LoadCount != 1 || ldLoc2.Variable.StoreCount != 1)
				{
					return false;
				}
				if (!afterFinally.Instructions[1].MatchStLoc(out variable, out var value) || !value.MatchLdNull())
				{
					return false;
				}
				removeFirstInstructionInAfterFinally = true;
			}
			if (variable.StoreCount != 1 || variable.LoadCount != 0)
			{
				return false;
			}
			return true;
		}
		IfInstruction ifInstruction2 = ifInstruction;
		if (ifInstruction2.Condition.MatchCompEquals(out var left, out var right) && right.MatchLdcI4(1) && left.MatchLdLoc(out var variable2))
		{
			if (!ifInstruction2.TrueInst.MatchBranch(out var targetBlock))
			{
				return false;
			}
			blocksToRemove.Add(afterFinally);
			afterFinally = targetBlock;
			return true;
		}
		if (ifInstruction2.Condition.MatchCompNotEquals(out left, out right) && right.MatchLdcI4(1) && left.MatchLdLoc(out variable2))
		{
			if (!afterFinally.Instructions[1].MatchBranch(out var targetBlock2))
			{
				return false;
			}
			blocksToRemove.Add(afterFinally);
			afterFinally = targetBlock2;
			return true;
		}
		return false;
		IL_01d0:
		return false;
	}
}
