using ICSharpCode.NRefactory.Editor;
using System.Text;

namespace ICSharpCode.NRefactory.CSharp
{
	public class ConstructFixer
	{
		private static readonly ConstructCompleter[] completer = new ConstructCompleter[18]
		{
			new TypeDeclarationCompleter(),
			new DelegateDeclarationCompleter(),
			new MethodDeclarationCompleter(),
			new IfStatementCompleter(),
			new ForeachStatementCompleter(),
			new WhileStatementCompleter(),
			new LockStatementCompleter(),
			new FixedStatementCompleter(),
			new DoWhileStatementCompleter(),
			new SwitchStatementCompleter(),
			new BreakStatementCompleter(),
			new ThrowStatementCompleter(),
			new ReturnStatementCompleter(),
			new YieldReturnStatementCompleter(),
			new CheckedStatementCompleter(),
			new UncheckedStatementCompleter(),
			new InvocationCompleter(),
			new ExpressionStatementCompleter()
		};

		private readonly CSharpFormattingOptions options;

		private readonly TextEditorOptions textEditorOptions;

		public CSharpFormattingOptions Options => options;

		public ConstructFixer(CSharpFormattingOptions options, TextEditorOptions textEditorOptions)
		{
			this.options = options;
			this.textEditorOptions = textEditorOptions;
		}

		private string GetIndent(AstNode node)
		{
			if (node == null || node is SyntaxTree)
			{
				return "";
			}
			if (node is BlockStatement || node is TypeDeclaration || node is NamespaceDeclaration)
			{
				return "\t" + GetIndent(node.Parent);
			}
			return GetIndent(node.Parent);
		}

		internal string GenerateBody(AstNode node, BraceStyle braceStyle, bool addClosingBracket, ref int newOffset)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (addClosingBracket)
			{
				stringBuilder.Append(")");
			}
			string indent = GetIndent(node.Parent);
			switch (braceStyle)
			{
			case BraceStyle.DoNotChange:
			case BraceStyle.EndOfLine:
			case BraceStyle.BannerStyle:
				stringBuilder.Append(" ");
				stringBuilder.Append("{");
				stringBuilder.Append(textEditorOptions.EolMarker);
				stringBuilder.Append(indent + "\t");
				break;
			case BraceStyle.EndOfLineWithoutSpace:
				stringBuilder.Append("{");
				stringBuilder.Append(textEditorOptions.EolMarker);
				stringBuilder.Append(indent + "\t");
				break;
			case BraceStyle.NextLine:
				stringBuilder.Append(textEditorOptions.EolMarker);
				stringBuilder.Append(indent);
				stringBuilder.Append("{");
				stringBuilder.Append(textEditorOptions.EolMarker);
				stringBuilder.Append(indent + "\t");
				break;
			case BraceStyle.NextLineShifted:
				stringBuilder.Append(textEditorOptions.EolMarker);
				stringBuilder.Append(indent + "\t");
				stringBuilder.Append("{");
				stringBuilder.Append(textEditorOptions.EolMarker);
				stringBuilder.Append(indent + "\t");
				break;
			case BraceStyle.NextLineShifted2:
				stringBuilder.Append(textEditorOptions.EolMarker);
				stringBuilder.Append(indent + "\t");
				stringBuilder.Append("{");
				stringBuilder.Append(textEditorOptions.EolMarker);
				stringBuilder.Append(indent + "\t\t");
				break;
			}
			newOffset += stringBuilder.Length;
			stringBuilder.Append(textEditorOptions.EolMarker);
			stringBuilder.Append(indent);
			stringBuilder.Append("}");
			return stringBuilder.ToString();
		}

		public bool TryFix(IDocument document, int offset, out int newOffset)
		{
			newOffset = offset;
			SyntaxTree syntaxTree = SyntaxTree.Parse(document, "a.cs");
			TextLocation location = document.GetLocation(offset - 1);
			ConstructCompleter[] array = completer;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].TryFix(this, syntaxTree, document, location, ref newOffset))
				{
					return true;
				}
			}
			return false;
		}
	}
}
