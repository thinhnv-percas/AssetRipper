using ICSharpCode.NRefactory.Editor;

namespace ICSharpCode.NRefactory.CSharp
{
	internal class MethodDeclarationCompleter : ConstructCompleter
	{
		public override bool TryFix(ConstructFixer fixer, SyntaxTree syntaxTree, IDocument document, TextLocation location, ref int newOffset)
		{
			MethodDeclaration nodeAt = syntaxTree.GetNodeAt<MethodDeclaration>(location);
			if (nodeAt != null && !nodeAt.LParToken.IsNull && nodeAt.RParToken.IsNull)
			{
				AstNode lastNonErrorChild = GetLastNonErrorChild(nodeAt);
				if (lastNonErrorChild == null)
				{
					return false;
				}
				int offset = document.GetOffset(lastNonErrorChild.EndLocation);
				document.Insert(offset, ")\n\t{\t\t\n\t}");
				newOffset += ")\n\t{\t\t".Length;
				return true;
			}
			return false;
		}
	}
}
