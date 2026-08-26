using ICSharpCode.NRefactory.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ICSharpCode.NRefactory.Editor
{
	public class StringBuilderDocument : IDocument, ITextSource, IServiceProvider
	{
		[Serializable]
		private sealed class InsertionWithMovementBefore : TextChangeEventArgs
		{
			public InsertionWithMovementBefore(int offset, string newText)
				: base(offset, string.Empty, newText)
			{
			}

			public override int GetNewOffset(int offset, AnchorMovementType movementType)
			{
				if (offset == base.Offset && movementType == AnchorMovementType.Default)
				{
					return offset;
				}
				return base.GetNewOffset(offset, movementType);
			}
		}

		private sealed class SimpleAnchor : ITextAnchor
		{
			private readonly StringBuilderDocument document;

			private int offset;

			public TextLocation Location
			{
				get
				{
					if (IsDeleted)
					{
						throw new InvalidOperationException();
					}
					return document.GetLocation(offset);
				}
			}

			public int Offset
			{
				get
				{
					if (IsDeleted)
					{
						throw new InvalidOperationException();
					}
					return offset;
				}
			}

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

			public bool IsDeleted => offset < 0;

			public int Line => Location.Line;

			public int Column => Location.Column;

			public event EventHandler Deleted;

			public SimpleAnchor(StringBuilderDocument document, int offset)
			{
				this.document = document;
				this.offset = offset;
			}

			public void Update(TextChangeEventArgs change)
			{
				if (SurviveDeletion || offset <= change.Offset || offset >= change.Offset + change.RemovalLength)
				{
					offset = change.GetNewOffset(offset, MovementType);
				}
				else
				{
					offset = -1;
				}
			}

			public void RaiseDeletedEvent()
			{
				if (this.Deleted != null)
				{
					this.Deleted(this, EventArgs.Empty);
				}
			}
		}

		private readonly StringBuilder b;

		private readonly TextSourceVersionProvider versionProvider = new TextSourceVersionProvider();

		private bool isInChange;

		private int undoGroupNesting;

		private ReadOnlyDocument documentSnapshot;

		private string cachedText;

		private readonly List<WeakReference> anchors = new List<WeakReference>();

		public ITextSourceVersion Version => versionProvider.CurrentVersion;

		public int LineCount => CreateDocumentSnapshot().LineCount;

		public string Text
		{
			get
			{
				if (cachedText == null)
				{
					cachedText = b.ToString();
				}
				return cachedText;
			}
			set
			{
				Replace(0, b.Length, value);
			}
		}

		public int TextLength => b.Length;

		public virtual string FileName => string.Empty;

		public event EventHandler<TextChangeEventArgs> TextChanging;

		public event EventHandler<TextChangeEventArgs> TextChanged;

		public event EventHandler ChangeCompleted;

		public virtual event EventHandler FileNameChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		public StringBuilderDocument()
		{
			b = new StringBuilder();
		}

		public StringBuilderDocument(string text)
		{
			if (text == null)
			{
				throw new ArgumentNullException("text");
			}
			b = new StringBuilder(text);
		}

		public StringBuilderDocument(ITextSource textSource)
		{
			if (textSource == null)
			{
				throw new ArgumentNullException("textSource");
			}
			b = new StringBuilder(textSource.TextLength);
			textSource.WriteTextTo(new StringWriter(b));
		}

		public IDocumentLine GetLineByNumber(int lineNumber)
		{
			return CreateDocumentSnapshot().GetLineByNumber(lineNumber);
		}

		public IDocumentLine GetLineByOffset(int offset)
		{
			return CreateDocumentSnapshot().GetLineByOffset(offset);
		}

		public int GetOffset(int line, int column)
		{
			return CreateDocumentSnapshot().GetOffset(line, column);
		}

		public int GetOffset(TextLocation location)
		{
			return CreateDocumentSnapshot().GetOffset(location);
		}

		public TextLocation GetLocation(int offset)
		{
			return CreateDocumentSnapshot().GetLocation(offset);
		}

		public void Insert(int offset, string text)
		{
			Replace(offset, 0, text);
		}

		public void Insert(int offset, ITextSource text)
		{
			if (text == null)
			{
				throw new ArgumentNullException("text");
			}
			Replace(offset, 0, text.Text);
		}

		public void Insert(int offset, string text, AnchorMovementType defaultAnchorMovementType)
		{
			if (offset < 0 || offset > TextLength)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			if (text == null)
			{
				throw new ArgumentNullException("text");
			}
			if (defaultAnchorMovementType == AnchorMovementType.BeforeInsertion)
			{
				PerformChange(new InsertionWithMovementBefore(offset, text));
			}
			else
			{
				Replace(offset, 0, text);
			}
		}

		public void Insert(int offset, ITextSource text, AnchorMovementType defaultAnchorMovementType)
		{
			if (text == null)
			{
				throw new ArgumentNullException("text");
			}
			Insert(offset, text.Text, defaultAnchorMovementType);
		}

		public void Remove(int offset, int length)
		{
			Replace(offset, length, string.Empty);
		}

		public void Replace(int offset, int length, string newText)
		{
			if (offset < 0 || offset > TextLength)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			if (length < 0 || length > TextLength - offset)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			if (newText == null)
			{
				throw new ArgumentNullException("newText");
			}
			PerformChange(new TextChangeEventArgs(offset, b.ToString(offset, length), newText));
		}

		public void Replace(int offset, int length, ITextSource newText)
		{
			if (newText == null)
			{
				throw new ArgumentNullException("newText");
			}
			Replace(offset, length, newText.Text);
		}

		private void PerformChange(TextChangeEventArgs change)
		{
			StartUndoableAction();
			try
			{
				isInChange = true;
				try
				{
					if (this.TextChanging != null)
					{
						this.TextChanging(this, change);
					}
					documentSnapshot = null;
					cachedText = null;
					b.Remove(change.Offset, change.RemovalLength);
					b.Insert(change.Offset, change.InsertedText.Text);
					versionProvider.AppendChange(change);
					UpdateAnchors(change);
					if (this.TextChanged != null)
					{
						this.TextChanged(this, change);
					}
				}
				finally
				{
					isInChange = false;
				}
			}
			finally
			{
				EndUndoableAction();
			}
		}

		public void StartUndoableAction()
		{
			if (isInChange)
			{
				throw new InvalidOperationException();
			}
			undoGroupNesting++;
		}

		public void EndUndoableAction()
		{
			undoGroupNesting--;
			if (undoGroupNesting == 0 && this.ChangeCompleted != null)
			{
				this.ChangeCompleted(this, EventArgs.Empty);
			}
		}

		public IDisposable OpenUndoGroup()
		{
			StartUndoableAction();
			return new CallbackOnDispose(EndUndoableAction);
		}

		public IDocument CreateDocumentSnapshot()
		{
			if (documentSnapshot == null)
			{
				documentSnapshot = new ReadOnlyDocument(this, FileName);
			}
			return documentSnapshot;
		}

		public ITextSource CreateSnapshot()
		{
			return new StringTextSource(Text, versionProvider.CurrentVersion);
		}

		public ITextSource CreateSnapshot(int offset, int length)
		{
			return new StringTextSource(GetText(offset, length));
		}

		public TextReader CreateReader()
		{
			return new StringReader(Text);
		}

		public TextReader CreateReader(int offset, int length)
		{
			return new StringReader(GetText(offset, length));
		}

		public void WriteTextTo(TextWriter writer)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			writer.Write(Text);
		}

		public void WriteTextTo(TextWriter writer, int offset, int length)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			writer.Write(GetText(offset, length));
		}

		public char GetCharAt(int offset)
		{
			return b[offset];
		}

		public string GetText(int offset, int length)
		{
			return b.ToString(offset, length);
		}

		public string GetText(ISegment segment)
		{
			if (segment == null)
			{
				throw new ArgumentNullException("segment");
			}
			return b.ToString(segment.Offset, segment.Length);
		}

		public int IndexOf(char c, int startIndex, int count)
		{
			return Text.IndexOf(c, startIndex, count);
		}

		public int IndexOfAny(char[] anyOf, int startIndex, int count)
		{
			return Text.IndexOfAny(anyOf, startIndex, count);
		}

		public int IndexOf(string searchText, int startIndex, int count, StringComparison comparisonType)
		{
			return Text.IndexOf(searchText, startIndex, count, comparisonType);
		}

		public int LastIndexOf(char c, int startIndex, int count)
		{
			return Text.LastIndexOf(c, startIndex + count - 1, count);
		}

		public int LastIndexOf(string searchText, int startIndex, int count, StringComparison comparisonType)
		{
			return Text.LastIndexOf(searchText, startIndex + count - 1, count, comparisonType);
		}

		public ITextAnchor CreateAnchor(int offset)
		{
			SimpleAnchor simpleAnchor = new SimpleAnchor(this, offset);
			for (int i = 0; i < anchors.Count; i++)
			{
				if (!anchors[i].IsAlive)
				{
					anchors[i] = new WeakReference(simpleAnchor);
				}
			}
			anchors.Add(new WeakReference(simpleAnchor));
			return simpleAnchor;
		}

		private void UpdateAnchors(TextChangeEventArgs change)
		{
			List<int> list = new List<int>();
			for (int i = 0; i < anchors.Count; i++)
			{
				SimpleAnchor simpleAnchor = anchors[i].Target as SimpleAnchor;
				if (simpleAnchor != null)
				{
					simpleAnchor.Update(change);
					if (simpleAnchor.IsDeleted)
					{
						list.Add(i);
					}
				}
			}
			list.Reverse();
			foreach (int item in list)
			{
				(anchors[item].Target as SimpleAnchor)?.RaiseDeletedEvent();
				anchors.RemoveAt(item);
			}
		}

		public virtual object GetService(Type serviceType)
		{
			return null;
		}
	}
}
