using ICSharpCode.NRefactory.Editor;

namespace ICSharpCode.NRefactory.CSharp
{
	internal class DoWhileStatementCompleter : ConstructCompleter
	{
		public override bool TryFix(ConstructFixer fixer, SyntaxTree syntaxTree, IDocument document, TextLocation location, ref int newOffset)
		{
			DoWhileStatement nodeAt = syntaxTree.GetNodeAt<DoWhileStatement>(location);
			if (nodeAt != null && !nodeAt.LParToken.IsNull && nodeAt.RParToken.IsNull)
			{
				AstNode lastNonErrorChild = GetLastNonErrorChild(nodeAt);
				if (lastNonErrorChild == null)
				{
					return false;
				}
				int offset = document.GetOffset(lastNonErrorChild.EndLocation);
				document.Insert(offset, ");");
				newOffset = offset + 2;
				return true;
			}
			return false;
		}
	}
}
