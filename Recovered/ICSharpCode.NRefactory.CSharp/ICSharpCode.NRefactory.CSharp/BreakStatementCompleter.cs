using ICSharpCode.NRefactory.Editor;

namespace ICSharpCode.NRefactory.CSharp
{
	internal class BreakStatementCompleter : ConstructCompleter
	{
		public override bool TryFix(ConstructFixer fixer, SyntaxTree syntaxTree, IDocument document, TextLocation location, ref int newOffset)
		{
			BreakStatement nodeAt = syntaxTree.GetNodeAt<BreakStatement>(location);
			if (nodeAt != null && nodeAt.SemicolonToken.IsNull)
			{
				return true;
			}
			return false;
		}
	}
}
