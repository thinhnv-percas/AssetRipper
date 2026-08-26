using ICSharpCode.NRefactory.Editor;

namespace ICSharpCode.NRefactory.CSharp
{
	internal abstract class ConstructCompleter
	{
		public abstract bool TryFix(ConstructFixer fixer, SyntaxTree syntaxTree, IDocument document, TextLocation location, ref int newOffset);

		protected AstNode GetLastNonErrorChild(AstNode node)
		{
			AstNode astNode = node.LastChild;
			while (astNode is ErrorNode)
			{
				astNode = astNode.GetPrevNode(FormattingVisitor.NoWhitespacePredicate);
			}
			return astNode;
		}
	}
}
