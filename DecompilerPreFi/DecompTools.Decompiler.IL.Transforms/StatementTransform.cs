#define DEBUG
using System;
using System.Diagnostics;

namespace DecompTools.Decompiler.IL.Transforms;

public class StatementTransform : IBlockTransform
{
	private readonly IStatementTransform[] children;

	public StatementTransform(params IStatementTransform[] children)
	{
		this.children = children;
	}

	public void Run(Block block, BlockTransformContext context)
	{
		StatementTransformContext statementTransformContext = new StatementTransformContext(context);
		int i = 0;
		checked
		{
			statementTransformContext.rerunPosition = block.Instructions.Count - 1;
			while (i >= 0)
			{
				if (statementTransformContext.rerunPosition.HasValue)
				{
					Debug.Assert(statementTransformContext.rerunPosition >= i);
					for (; i < statementTransformContext.rerunPosition; i++)
					{
						block.Instructions[i].ResetDirty();
					}
					Debug.Assert(i == statementTransformContext.rerunPosition);
					statementTransformContext.rerunPosition = null;
				}
				IStatementTransform[] array = children;
				foreach (IStatementTransform statementTransform in array)
				{
					statementTransform.Run(block, i, statementTransformContext);
					block.Instructions[i].CheckInvariant(ILPhase.Normal);
					for (int k = Math.Max(0, i - 100); k < i; k++)
					{
						if (block.Instructions[k].IsDirty)
						{
							Debug.Fail(statementTransform.GetType().Name + " modified an instruction before pos");
						}
					}
					if (statementTransformContext.rerunCurrentPosition)
					{
						statementTransformContext.rerunCurrentPosition = false;
						statementTransformContext.RequestRerun(i);
					}
					if (statementTransformContext.rerunPosition.HasValue)
					{
						break;
					}
				}
				if (!statementTransformContext.rerunPosition.HasValue)
				{
					i--;
				}
			}
		}
	}
}
