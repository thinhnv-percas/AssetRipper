using ICSharpCode.NRefactory.Editor;
using ICSharpCode.NRefactory.TypeSystem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.CSharp.Refactoring
{
	public class DocumentScript : Script
	{
		private sealed class TrackedSegment : ISegment
		{
			private readonly DocumentScript script;

			private readonly ITextSourceVersion originalVersion;

			private readonly int originalStart;

			private readonly int originalEnd;

			public int Offset => originalVersion.MoveOffsetTo(script.currentDocument.Version, originalStart);

			public int Length => EndOffset - Offset;

			public int EndOffset => originalVersion.MoveOffsetTo(script.currentDocument.Version, originalEnd);

			public TrackedSegment(DocumentScript script, int originalStart, int originalEnd)
			{
				this.script = script;
				originalVersion = script.currentDocument.Version;
				this.originalStart = originalStart;
				this.originalEnd = originalEnd;
			}
		}

		private readonly IDocument currentDocument;

		private readonly IDocument originalDocument;

		private readonly IDisposable undoGroup;

		public IDocument CurrentDocument => currentDocument;

		public IDocument OriginalDocument => originalDocument;

		public DocumentScript(IDocument document, CSharpFormattingOptions formattingOptions, TextEditorOptions options)
			: base(formattingOptions, options)
		{
			originalDocument = document.CreateDocumentSnapshot();
			currentDocument = document;
			undoGroup = document.OpenUndoGroup();
		}

		public override void Dispose()
		{
			base.Dispose();
			if (undoGroup != null)
			{
				undoGroup.Dispose();
			}
		}

		public override void Remove(AstNode node, bool removeEmptyLine = true)
		{
			ISegment segment = GetSegment(node);
			int offset = segment.Offset;
			int num = segment.EndOffset;
			IDocumentLine lineByOffset = currentDocument.GetLineByOffset(offset);
			IDocumentLine lineByOffset2 = currentDocument.GetLineByOffset(num);
			if (lineByOffset != null && lineByOffset2 != null)
			{
				bool num2 = string.IsNullOrWhiteSpace(currentDocument.GetText(lineByOffset.Offset, offset - lineByOffset.Offset));
				if (num2)
				{
					offset = lineByOffset.Offset;
				}
				bool flag = string.IsNullOrWhiteSpace(currentDocument.GetText(num, lineByOffset2.EndOffset - num));
				if (flag)
				{
					num = lineByOffset2.EndOffset;
				}
				if (num2 & flag)
				{
					num += lineByOffset2.DelimiterLength;
				}
			}
			Replace(offset, num - offset, string.Empty);
		}

		public override void Replace(int offset, int length, string newText)
		{
			currentDocument.Replace(offset, length, newText);
		}

		public override int GetCurrentOffset(TextLocation originalDocumentLocation)
		{
			int offset = originalDocument.GetOffset(originalDocumentLocation);
			return GetCurrentOffset(offset);
		}

		public override int GetCurrentOffset(int originalDocumentOffset)
		{
			return originalDocument.Version.MoveOffsetTo(currentDocument.Version, originalDocumentOffset);
		}

		public override void FormatText(IEnumerable<AstNode> nodes)
		{
			SyntaxTree syntaxTree = SyntaxTree.Parse(currentDocument, "dummy.cs");
			CSharpFormatter cSharpFormatter = new CSharpFormatter(base.FormattingOptions, base.Options);
			List<ISegment> list = new List<ISegment>();
			foreach (AstNode item in from n in nodes
				orderby n.StartLocation descending
				select n)
			{
				ISegment segment = GetSegment(item);
				cSharpFormatter.AddFormattingRegion(new DomRegion(currentDocument.GetLocation(segment.Offset), currentDocument.GetLocation(segment.EndOffset)));
				list.Add(segment);
			}
			if (list.Count != 0)
			{
				FormattingChanges formattingChanges = cSharpFormatter.AnalyzeFormatting(currentDocument, syntaxTree);
				foreach (ISegment item2 in list)
				{
					formattingChanges.ApplyChanges(item2.Offset, item2.Length - 1);
				}
			}
		}

		protected override int GetIndentLevelAt(int offset)
		{
			IDocumentLine lineByOffset = currentDocument.GetLineByOffset(offset);
			int num = 0;
			int num2 = 0;
			for (int i = lineByOffset.Offset; i < currentDocument.TextLength; i++)
			{
				switch (currentDocument.GetCharAt(i))
				{
				case '\t':
					num = 0;
					num2++;
					continue;
				case ' ':
					num++;
					if (num == 4)
					{
						num = 0;
						num2++;
					}
					continue;
				}
				break;
			}
			return num2;
		}

		protected override ISegment CreateTrackedSegment(int offset, int length)
		{
			return new TrackedSegment(this, offset, offset + length);
		}
	}
}
