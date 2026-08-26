using ICSharpCode.NRefactory.Editor;

namespace ICSharpCode.NRefactory.CSharp
{
	internal class WhileStatementCompleter : ConstructCompleter
	{
		public override bool TryFix(ConstructFixer fixer, SyntaxTree syntaxTree, IDocument document, TextLocation location, ref int newOffset)
		{
			WhileStatement nodeAt = syntaxTree.GetNodeAt<WhileStatement>(location);
			if (nodeAt != null && !nodeAt.LParToken.IsNull && nodeAt.RParToken.IsNull)
			{
				AstNode lastNonErrorChild = GetLastNonErrorChild(nodeAt);
				if (lastNonErrorChild == null)
				{
					return false;
				}
				int offset = document.GetOffset(lastNonErrorChild.EndLocation);
				document.Insert(offset, fixer.GenerateBody(nodeAt, fixer.Options.StatementBraceStyle, addClosingBracket: true, ref newOffset));
				return true;
			}
			return false;
		}
	}
}
