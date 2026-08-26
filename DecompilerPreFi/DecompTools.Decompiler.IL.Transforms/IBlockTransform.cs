namespace DecompTools.Decompiler.IL.Transforms;

public interface IBlockTransform
{
	void Run(Block block, BlockTransformContext context);
}
