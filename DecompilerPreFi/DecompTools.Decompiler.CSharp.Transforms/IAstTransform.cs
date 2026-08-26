using DecompTools.Decompiler.CSharp.Syntax;

namespace DecompTools.Decompiler.CSharp.Transforms;

public interface IAstTransform
{
	void Run(AstNode rootNode, TransformContext context);
}
