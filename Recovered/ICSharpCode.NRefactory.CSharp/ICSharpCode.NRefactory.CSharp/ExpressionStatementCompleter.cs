using ICSharpCode.NRefactory.Editor;

namespace ICSharpCode.NRefactory.CSharp
{
	internal class ExpressionStatementCompleter : ConstructCompleter
	{
		public override bool TryFix(ConstructFixer fixer, SyntaxTree syntaxTree, IDocument document, TextLocation location, ref int newOffset)
		{
			ExpressionStatement nodeAt = syntaxTree.GetNodeAt<ExpressionStatement>(location);
			if (nodeAt != null)
			{
				int offset = document.GetOffset(nodeAt.Expression.EndLocation);
				if (nodeAt.SemicolonToken.IsNull)
				{
					document.Insert(offset, ";");
					newOffset = offset + 1;
				}
				return true;
			}
			return false;
		}
	}
}
