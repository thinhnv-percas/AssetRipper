namespace DecompTools.Decompiler.IL.Transforms;

public interface IILTransform
{
	void Run(ILFunction function, ILTransformContext context);
}
