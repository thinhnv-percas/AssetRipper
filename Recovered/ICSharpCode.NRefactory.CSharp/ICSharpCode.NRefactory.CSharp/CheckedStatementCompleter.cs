using ICSharpCode.NRefactory.Editor;

namespace ICSharpCode.NRefactory.CSharp
{
	internal class CheckedStatementCompleter : ConstructCompleter
	{
		public override bool TryFix(ConstructFixer fixer, SyntaxTree syntaxTree, IDocument document, TextLocation location, ref int newOffset)
		{
			CheckedExpression nodeAt = syntaxTree.GetNodeAt<CheckedExpression>(location);
			if (nodeAt != null && nodeAt.Parent is ExpressionStatement)
			{
				int offset = document.GetOffset(nodeAt.EndLocation);
				document.Insert(offset, fixer.GenerateBody(nodeAt, fixer.Options.StatementBraceStyle, addClosingBracket: false, ref newOffset));
				return true;
			}
			return false;
		}
	}
}
