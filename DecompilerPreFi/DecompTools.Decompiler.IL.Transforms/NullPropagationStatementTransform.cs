namespace DecompTools.Decompiler.IL.Transforms;

internal class NullPropagationStatementTransform : IStatementTransform
{
	public void Run(Block block, int pos, StatementTransformContext context)
	{
		if (context.Settings.NullPropagation)
		{
			new NullPropagationTransform(context).RunStatements(block, pos);
		}
	}
}
