using ICSharpCode.NRefactory.Editor;

namespace ICSharpCode.NRefactory.CSharp
{
	internal class UncheckedStatementCompleter : ConstructCompleter
	{
		public override bool TryFix(ConstructFixer fixer, SyntaxTree syntaxTree, IDocument document, TextLocation location, ref int newOffset)
		{
			UncheckedExpression nodeAt = syntaxTree.GetNodeAt<UncheckedExpression>(location);
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
