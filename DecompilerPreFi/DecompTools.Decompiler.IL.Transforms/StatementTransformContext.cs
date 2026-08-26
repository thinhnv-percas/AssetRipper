using System;

namespace DecompTools.Decompiler.IL.Transforms;

public class StatementTransformContext : ILTransformContext
{
	internal bool rerunCurrentPosition;

	internal int? rerunPosition;

	public BlockTransformContext BlockContext { get; }

	public Block Block => BlockContext.Block;

	public StatementTransformContext(BlockTransformContext blockContext)
		: base(blockContext)
	{
		BlockContext = blockContext ?? throw new ArgumentNullException("blockContext");
	}

	public void RequestRerun(int pos)
	{
		if (!rerunPosition.HasValue || pos > rerunPosition)
		{
			rerunPosition = pos;
		}
	}

	public void RequestRerun()
	{
		rerunCurrentPosition = true;
	}
}
