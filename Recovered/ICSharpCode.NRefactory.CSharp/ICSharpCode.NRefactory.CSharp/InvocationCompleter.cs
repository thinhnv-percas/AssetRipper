using ICSharpCode.NRefactory.Editor;

namespace ICSharpCode.NRefactory.CSharp
{
	internal class InvocationCompleter : ConstructCompleter
	{
		public override bool TryFix(ConstructFixer fixer, SyntaxTree syntaxTree, IDocument document, TextLocation location, ref int newOffset)
		{
			InvocationExpression nodeAt = syntaxTree.GetNodeAt<InvocationExpression>(location);
			if (nodeAt != null && !nodeAt.LParToken.IsNull && nodeAt.RParToken.IsNull)
			{
				AstNode lastNonErrorChild = GetLastNonErrorChild(nodeAt);
				if (lastNonErrorChild == null)
				{
					return false;
				}
				int offset = newOffset = document.GetOffset(lastNonErrorChild.EndLocation);
				string text = ")";
				newOffset++;
				ExpressionStatement expressionStatement = nodeAt.Parent as ExpressionStatement;
				if (expressionStatement != null)
				{
					if (expressionStatement.SemicolonToken.IsNull)
					{
						text = ");";
					}
					newOffset++;
				}
				document.Insert(offset, text);
				return true;
			}
			return false;
		}
	}
}
