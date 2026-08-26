using System;
using System.Collections.Generic;
using System.IO;

namespace ICSharpCode.NRefactory.Editor
{
	[Serializable]
	public sealed class ReadOnlyDocument : IDocument, ITextSource, IServiceProvider
	{
		private sealed class ReadOnlyDocumentLine : IDocumentLine, ISegment
		{
			private readonly ReadOnlyDocument doc;

			private readonly int lineNumber;

			private readonly int offset;

			private readonly int endOffset;

			public int Offset => offset;

			public int Length => endOffset - offset;

			public int EndOffset => endOffset;

			public int TotalLength => doc.GetTotalEndOffset(lineNumber) - offset;

			public int DelimiterLength => doc.GetTotalEndOffset(lineNumber) - endOffset;

			public int LineNumber => lineNumber;

			public IDocumentLine PreviousLine
			{
				get
				{
					if (lineNumber == 1)
					{
						return null;
					}
					return new ReadOnlyDocumentLine(doc, lineNumber - 1);
				}
			}

			public IDocumentLine NextLine
			{
				get
				{
					if (lineNumber == doc.LineCount)
					{
						return null;
					}
					return new ReadOnlyDocumentLine(doc, lineNumber + 1);
				}
			}

			public bool IsDeleted => false;

			public ReadOnlyDocumentLine(ReadOnlyDocument doc, int lineNumber)
			{
				this.doc = doc;
				this.lineNumber = lineNumber;
				offset = doc.GetStartOffset(lineNumber);
				endOffset = doc.GetEndOffset(lineNumber);
			}

			public override int GetHashCode()
			{
				return doc.GetHashCode() ^ lineNumber;
			}

			public override bool Equals(object obj)
			{
				ReadOnlyDocumentLine readOnlyDocumentLine = obj as ReadOnlyDocumentLine;
				if (readOnlyDocumentLine != null && doc == readOnlyDocumentLine.doc)
				{
					return lineNumber == readOnlyDocumentLine.lineNumber;
				}
				return false;
			}
		}

		private sealed class ReadOnlyDocumentTextAnchor : ITextAnchor
		{
			private readonly TextLocation location;

			private readonly int offset;

			public TextLocation Location => location;

			public int Offset => offset;

			public AnchorMovementType MovementType
			{
				get;
				set;
			}

			public bool SurviveDeletion
			{
				get;
				set;
			}

			public bool IsDeleted => false;

			public int Line => location.Line;

			public int Column => location.Column;

			public event EventHandler Deleted
			{
				add
				{
				}
				remove
				{
				}
			}

			public ReadOnlyDocumentTextAnchor(TextLocation location, int offset)
			{
				this.location = location;
				this.offset = offset;
			}
		}

		private readonly ITextSource textSource;

		private readonly string fileName;

		private int[] lines;

		private static readonly char[] newline = new char[2]
		{
			'\r',
			'\n'
		};

		public string Text
		{
			get
			{
				return textSource.Text;
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		public int LineCount => lines.Length;

		public ITextSourceVersion Version => textSource.Version;

		public int TextLength => textSource.TextLength;

		public string FileName => fileName;

		event EventHandler<TextChangeEventArgs> IDocument.TextChanging
		{
			add
			{
			}
			remove
			{
			}
		}

		event EventHandler<TextChangeEventArgs> IDocument.TextChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		event EventHandler IDocument.ChangeCompleted
		{
			add
			{
			}
			remove
			{
			}
		}

		public event EventHandler FileNameChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		public ReadOnlyDocument(ITextSource textSource)
		{
			if (textSource == null)
			{
				throw new ArgumentNullException("textSource");
			}
			this.textSource = textSource.CreateSnapshot();
			List<int> list = new List<int>
			{
				0
			};
			int num = 0;
			int textLength = textSource.TextLength;
			while ((num = textSource.IndexOfAny(newline, num, textLength - num)) >= 0)
			{
				num++;
				if (textSource.GetCharAt(num - 1) == '\r' && num < textLength && textSource.GetCharAt(num) == '\n')
				{
					num++;
				}
				list.Add(num);
			}
			lines = list.ToArray();
		}

		public ReadOnlyDocument(string text)
			: this(new StringTextSource(text))
		{
		}

		public ReadOnlyDocument(ITextSource textSource, string fileName)
			: this(textSource)
		{
			this.fileName = fileName;
		}

		public IDocumentLine GetLineByNumber(int lineNumber)
		{
			if (lineNumber < 1 || lineNumber > lines.Length)
			{
				throw new ArgumentOutOfRangeException("lineNumber", lineNumber, "Value must be between 1 and " + lines.Length);
			}
			return new ReadOnlyDocumentLine(this, lineNumber);
		}

		private int GetStartOffset(int lineNumber)
		{
			return lines[lineNumber - 1];
		}

		private int GetTotalEndOffset(int lineNumber)
		{
			if (lineNumber >= lines.Length)
			{
				return textSource.TextLength;
			}
			return lines[lineNumber];
		}

		private int GetEndOffset(int lineNumber)
		{
			if (lineNumber == lines.Length)
			{
				return textSource.TextLength;
			}
			int num = lines[lineNumber] - 1;
			if (num > 0 && textSource.GetCharAt(num - 1) == '\r' && textSource.GetCharAt(num) == '\n')
			{
				num--;
			}
			return num;
		}

		public IDocumentLine GetLineByOffset(int offset)
		{
			return GetLineByNumber(GetLineNumberForOffset(offset));
		}

		private int GetLineNumberForOffset(int offset)
		{
			int num = Array.BinarySearch(lines, offset);
			if (num >= 0)
			{
				return num + 1;
			}
			return ~num;
		}

		public int GetOffset(int line, int column)
		{
			if (line < 1 || line > lines.Length)
			{
				throw new ArgumentOutOfRangeException("line", line, "Value must be between 1 and " + lines.Length);
			}
			int startOffset = GetStartOffset(line);
			if (column <= 1)
			{
				return startOffset;
			}
			int endOffset = GetEndOffset(line);
			if (column - 1 >= endOffset - startOffset)
			{
				return endOffset;
			}
			return startOffset + column - 1;
		}

		public int GetOffset(TextLocation location)
		{
			return GetOffset(location.Line, location.Column);
		}

		public TextLocation GetLocation(int offset)
		{
			if (offset < 0 || offset > textSource.TextLength)
			{
				throw new ArgumentOutOfRangeException("offset", offset, "Value must be between 0 and " + textSource.TextLength);
			}
			int lineNumberForOffset = GetLineNumberForOffset(offset);
			return new TextLocation(lineNumberForOffset, offset - GetStartOffset(lineNumberForOffset) + 1);
		}

		void IDocument.Insert(int offset, string text)
		{
			throw new NotSupportedException();
		}

		void IDocument.Insert(int offset, string text, AnchorMovementType defaultAnchorMovementType)
		{
			throw new NotSupportedException();
		}

		void IDocument.Remove(int offset, int length)
		{
			throw new NotSupportedException();
		}

		void IDocument.Replace(int offset, int length, string newText)
		{
			throw new NotSupportedException();
		}

		void IDocument.Insert(int offset, ITextSource text)
		{
			throw new NotSupportedException();
		}

		void IDocument.Insert(int offset, ITextSource text, AnchorMovementType defaultAnchorMovementType)
		{
			throw new NotSupportedException();
		}

		void IDocument.Replace(int offset, int length, ITextSource newText)
		{
			throw new NotSupportedException();
		}

		void IDocument.StartUndoableAction()
		{
		}

		void IDocument.EndUndoableAction()
		{
		}

		IDisposable IDocument.OpenUndoGroup()
		{
			return null;
		}

		public ITextAnchor CreateAnchor(int offset)
		{
			return new ReadOnlyDocumentTextAnchor(GetLocation(offset), offset);
		}

		public ITextSource CreateSnapshot()
		{
			return textSource;
		}

		public ITextSource CreateSnapshot(int offset, int length)
		{
			return textSource.CreateSnapshot(offset, length);
		}

		public IDocument CreateDocumentSnapshot()
		{
			return this;
		}

		public TextReader CreateReader()
		{
			return textSource.CreateReader();
		}

		public TextReader CreateReader(int offset, int length)
		{
			return textSource.CreateReader(offset, length);
		}

		public void WriteTextTo(TextWriter writer)
		{
			textSource.WriteTextTo(writer);
		}

		public void WriteTextTo(TextWriter writer, int offset, int length)
		{
			textSource.WriteTextTo(writer, offset, length);
		}

		public char GetCharAt(int offset)
		{
			return textSource.GetCharAt(offset);
		}

		public string GetText(int offset, int length)
		{
			return textSource.GetText(offset, length);
		}

		public string GetText(ISegment segment)
		{
			return textSource.GetText(segment);
		}

		public int IndexOf(char c, int startIndex, int count)
		{
			return textSource.IndexOf(c, startIndex, count);
		}

		public int IndexOfAny(char[] anyOf, int startIndex, int count)
		{
			return textSource.IndexOfAny(anyOf, startIndex, count);
		}

		public int IndexOf(string searchText, int startIndex, int count, StringComparison comparisonType)
		{
			return textSource.IndexOf(searchText, startIndex, count, comparisonType);
		}

		public int LastIndexOf(char c, int startIndex, int count)
		{
			return textSource.LastIndexOf(c, startIndex, count);
		}

		public int LastIndexOf(string searchText, int startIndex, int count, StringComparison comparisonType)
		{
			return textSource.LastIndexOf(searchText, startIndex, count, comparisonType);
		}

		object IServiceProvider.GetService(Type serviceType)
		{
			return null;
		}
	}
}
