using System.Linq;
using ICSharpCode.NRefactory.CSharp;

namespace ICSharpCode.Decompiler.Ast.Transforms;

internal class FlattenSwitchBlocks : IAstTransformPoolObject, IAstTransform
{
	public void Reset(DecompilerContext context)
	{
	}

	public void Run(AstNode compilationUnit)
	{
		foreach (SwitchSection item in compilationUnit.Descendants.OfType<SwitchSection>())
		{
			if (item.Statements.Count == 1 && item.Statements.First() is BlockStatement blockStatement && !blockStatement.Statements.Any((Statement st) => st is VariableDeclarationStatement) && blockStatement.HiddenStart == null && blockStatement.HiddenEnd == null && blockStatement.GetAllILSpans().Count <= 0)
			{
				blockStatement.Remove();
				blockStatement.Statements.MoveTo(item.Statements);
			}
		}
	}
}
