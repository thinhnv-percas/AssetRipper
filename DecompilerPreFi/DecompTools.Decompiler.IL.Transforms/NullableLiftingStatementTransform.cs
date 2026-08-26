namespace DecompTools.Decompiler.IL.Transforms;

internal class NullableLiftingStatementTransform : IStatementTransform
{
	public void Run(Block block, int pos, StatementTransformContext context)
	{
		new NullableLiftingTransform(context).RunStatements(block, pos);
	}
}
