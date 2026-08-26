#define DEBUG
#define STEP
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DecompTools.Decompiler.FlowAnalysis;
using DecompTools.Decompiler.IL.ControlFlow;

namespace DecompTools.Decompiler.IL.Transforms;

public class BlockILTransform : IILTransform
{
	private bool running;

	public IList<IBlockTransform> PreOrderTransforms { get; } = new List<IBlockTransform>();

	public IList<IBlockTransform> PostOrderTransforms { get; } = new List<IBlockTransform>();

	public override string ToString()
	{
		return "BlockILTransform (" + string.Join(", ", Enumerable.Select<IBlockTransform, string>(Enumerable.Concat<IBlockTransform>((IEnumerable<IBlockTransform>)PreOrderTransforms, (IEnumerable<IBlockTransform>)PostOrderTransforms), (Func<IBlockTransform, string>)((IBlockTransform t) => t.GetType().Name))) + ")";
	}

	public void Run(ILFunction function, ILTransformContext context)
	{
		if (running)
		{
			throw new InvalidOperationException("Reentrancy detected. Transforms (and the CSharpDecompiler) are neither neither thread-safe nor re-entrant.");
		}
		try
		{
			running = true;
			BlockTransformContext blockTransformContext = new BlockTransformContext(context);
			Debug.Assert(blockTransformContext.Function == function);
			foreach (BlockContainer item in Enumerable.ToList<BlockContainer>(Enumerable.OfType<BlockContainer>((IEnumerable)function.Descendants)))
			{
				context.CancellationToken.ThrowIfCancellationRequested();
				blockTransformContext.ControlFlowGraph = new ControlFlowGraph(item, context.CancellationToken);
				VisitBlock(blockTransformContext.ControlFlowGraph.GetNode(item.EntryPoint), blockTransformContext);
			}
		}
		finally
		{
			running = false;
		}
	}

	private void VisitBlock(ControlFlowNode cfgNode, BlockTransformContext context)
	{
		Block block = (Block)cfgNode.UserData;
		context.StepStartGroup(block.Label, block);
		context.ControlFlowNode = cfgNode;
		context.Block = block;
		block.RunTransforms(PreOrderTransforms, context);
		foreach (ControlFlowNode dominatorTreeChild in cfgNode.DominatorTreeChildren)
		{
			VisitBlock(dominatorTreeChild, context);
		}
		context.ControlFlowNode = cfgNode;
		context.Block = block;
		block.RunTransforms(PostOrderTransforms, context);
		context.StepEndGroup();
	}
}
