using ICSharpCode.NRefactory.Editor;

namespace ICSharpCode.NRefactory.CSharp
{
	internal class DelegateDeclarationCompleter : ConstructCompleter
	{
		public override bool TryFix(ConstructFixer fixer, SyntaxTree syntaxTree, IDocument document, TextLocation location, ref int newOffset)
		{
			DelegateDeclaration nodeAt = syntaxTree.GetNodeAt<DelegateDeclaration>(location);
			if (nodeAt != null && nodeAt.RParToken.IsNull)
			{
				AstNode lastNonErrorChild = GetLastNonErrorChild(nodeAt);
				if (lastNonErrorChild == null)
				{
					return false;
				}
				int offset = document.GetOffset(lastNonErrorChild.EndLocation);
				document.Insert(offset, ");\n");
				newOffset += ");\n".Length;
				return true;
			}
			return false;
		}
	}
}
