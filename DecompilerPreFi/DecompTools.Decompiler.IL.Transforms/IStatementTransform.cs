namespace DecompTools.Decompiler.IL.Transforms;

public interface IStatementTransform
{
	void Run(Block block, int pos, StatementTransformContext context);
}
