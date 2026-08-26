using ICSharpCode.NRefactory.CSharp;

namespace ICSharpCode.Decompiler.Ast.Transforms
{
	public interface IAstTransform
	{
		void Run(AstNode compilationUnit);
	}
}
