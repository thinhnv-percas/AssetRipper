using ICSharpCode.NRefactory.Editor;
using ICSharpCode.NRefactory.TypeSystem;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ICSharpCode.NRefactory.CSharp
{
	public class CSharpFormatter
	{
		private readonly CSharpFormattingOptions policy;

		private readonly TextEditorOptions options;

		private List<DomRegion> formattingRegions = new List<DomRegion>();

		internal TextLocation lastFormattingLocation = new TextLocation(int.MaxValue, int.MaxValue);

		public CSharpFormattingOptions Policy => policy;

		public TextEditorOptions TextEditorOptions => options;

		public IList<DomRegion> FormattingRegions => formattingRegions;

		public FormattingMode FormattingMode
		{
			get;
			set;
		}

		public CSharpFormatter(CSharpFormattingOptions policy, TextEditorOptions options = null)
		{
			if (policy == null)
			{
				throw new ArgumentNullException("policy");
			}
			this.policy = policy;
			this.options = (options ?? TextEditorOptions.Default);
		}

		public string Format(IDocument document)
		{
			return InternalFormat(new StringBuilderDocument(document.Text));
		}

		public string Format(string text)
		{
			return InternalFormat(new StringBuilderDocument(text));
		}

		private string InternalFormat(IDocument document)
		{
			SyntaxTree syntaxTree = SyntaxTree.Parse(document, document.FileName);
			AnalyzeFormatting(document, syntaxTree).ApplyChanges();
			return document.Text;
		}

		public FormattingChanges AnalyzeFormatting(IDocument document, SyntaxTree syntaxTree, CancellationToken token = default(CancellationToken))
		{
			if (document == null)
			{
				throw new ArgumentNullException("document");
			}
			if (syntaxTree == null)
			{
				throw new ArgumentNullException("syntaxTree");
			}
			FormattingChanges formattingChanges = new FormattingChanges(document);
			FormattingVisitor visitor = new FormattingVisitor(this, document, formattingChanges, token);
			syntaxTree.AcceptVisitor(visitor);
			return formattingChanges;
		}

		public void AddFormattingRegion(DomRegion region)
		{
			formattingRegions.Add(region);
			if (formattingRegions.Count == 1)
			{
				lastFormattingLocation = region.End;
			}
			else
			{
				lastFormattingLocation = ((lastFormattingLocation < region.End) ? region.End : lastFormattingLocation);
			}
		}
	}
}
