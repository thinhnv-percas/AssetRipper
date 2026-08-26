#define STEP
using System;
using System.Collections.Generic;

namespace DecompTools.Decompiler.IL.Transforms;

public class LoopingBlockTransform : IBlockTransform
{
	private readonly IBlockTransform[] children;

	private bool running;

	public IReadOnlyCollection<IBlockTransform> Transforms => children;

	public LoopingBlockTransform(params IBlockTransform[] children)
	{
		this.children = children;
	}

	public void Run(Block block, BlockTransformContext context)
	{
		if (running)
		{
			throw new InvalidOperationException("LoopingBlockTransform already running. Transforms (and the CSharpDecompiler) are neither neither thread-safe nor re-entrant.");
		}
		running = true;
		try
		{
			int num = 1;
			do
			{
				block.ResetDirty();
				block.RunTransforms(children, context);
				if (block.IsDirty)
				{
					context.Step($"Block is dirty; running loop iteration #{num = checked(num + 1)}.", block);
				}
			}
			while (block.IsDirty);
		}
		finally
		{
			running = false;
		}
	}
}
