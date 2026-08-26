using ICSharpCode.NRefactory.Editor;

namespace ICSharpCode.NRefactory.CSharp
{
	internal class ReturnStatementCompleter : ConstructCompleter
	{
		public override bool TryFix(ConstructFixer fixer, SyntaxTree syntaxTree, IDocument document, TextLocation location, ref int newOffset)
		{
			ReturnStatement nodeAt = syntaxTree.GetNodeAt<ReturnStatement>(location);
			if (nodeAt != null && nodeAt.SemicolonToken.IsNull)
			{
				int offset = document.GetOffset(nodeAt.EndLocation);
				document.Insert(offset, ";");
				newOffset = offset + 1;
				return true;
			}
			return false;
		}
	}
}
