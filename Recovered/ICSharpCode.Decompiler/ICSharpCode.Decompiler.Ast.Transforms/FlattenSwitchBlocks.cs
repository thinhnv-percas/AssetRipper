using ICSharpCode.NRefactory.CSharp;
using System.Linq;

namespace ICSharpCode.Decompiler.Ast.Transforms
{
	internal class FlattenSwitchBlocks : IAstTransform
	{
		public void Run(AstNode compilationUnit)
		{
			foreach (SwitchSection item in compilationUnit.Descendants.OfType<SwitchSection>())
			{
				if (item.Statements.Count == 1)
				{
					BlockStatement blockStatement = item.Statements.First() as BlockStatement;
					if (blockStatement != null && !blockStatement.Statements.Any((Statement st) => st is VariableDeclarationStatement))
					{
						blockStatement.Remove();
						blockStatement.Statements.MoveTo(item.Statements);
					}
				}
			}
		}
	}
}
