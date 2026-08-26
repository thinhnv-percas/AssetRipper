using ICSharpCode.NRefactory.Editor;
using System.Linq;

namespace ICSharpCode.NRefactory.CSharp
{
	internal class TypeDeclarationCompleter : ConstructCompleter
	{
		public override bool TryFix(ConstructFixer fixer, SyntaxTree syntaxTree, IDocument document, TextLocation location, ref int newOffset)
		{
			TypeDeclaration nodeAt = syntaxTree.GetNodeAt<TypeDeclaration>(location);
			if (nodeAt != null && nodeAt.LBraceToken.IsNull && nodeAt.RBraceToken.IsNull)
			{
				if (nodeAt.Members.Any())
				{
					return false;
				}
				AstNode lastNonErrorChild = GetLastNonErrorChild(nodeAt);
				if (lastNonErrorChild == null)
				{
					return false;
				}
				int offset = document.GetOffset(lastNonErrorChild.EndLocation);
				document.Insert(offset, fixer.GenerateBody(nodeAt, fixer.Options.ClassBraceStyle, addClosingBracket: false, ref newOffset));
				return true;
			}
			return false;
		}
	}
}
