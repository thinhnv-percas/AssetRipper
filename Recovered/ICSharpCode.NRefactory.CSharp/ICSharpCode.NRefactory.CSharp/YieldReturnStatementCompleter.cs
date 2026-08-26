using ICSharpCode.NRefactory.Editor;

namespace ICSharpCode.NRefactory.CSharp
{
	internal class YieldReturnStatementCompleter : ConstructCompleter
	{
		public override bool TryFix(ConstructFixer fixer, SyntaxTree syntaxTree, IDocument document, TextLocation location, ref int newOffset)
		{
			YieldReturnStatement nodeAt = syntaxTree.GetNodeAt<YieldReturnStatement>(location);
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
