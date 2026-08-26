using ICSharpCode.NRefactory.CSharp.Refactoring;
using ICSharpCode.NRefactory.Editor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.CSharp
{
	public class FormattingChanges
	{
		internal sealed class TextReplaceAction
		{
			internal readonly int Offset;

			internal readonly int RemovalLength;

			internal readonly string NewText;

			internal TextReplaceAction DependsOn;

			public TextReplaceAction(int offset, int removalLength, string newText)
			{
				Offset = offset;
				RemovalLength = removalLength;
				NewText = (newText ?? string.Empty);
			}

			public override bool Equals(object obj)
			{
				TextReplaceAction textReplaceAction = obj as TextReplaceAction;
				if (textReplaceAction == null)
				{
					return false;
				}
				if (Offset == textReplaceAction.Offset && RemovalLength == textReplaceAction.RemovalLength)
				{
					return NewText == textReplaceAction.NewText;
				}
				return false;
			}

			public override int GetHashCode()
			{
				return 0;
			}

			public override string ToString()
			{
				return $"[TextReplaceAction: Offset={Offset}, RemovalLength={RemovalLength}, NewText={NewText}]";
			}
		}

		private readonly IDocument document;

		internal readonly List<TextReplaceAction> changes = new List<TextReplaceAction>();

		public int Count => changes.Count;

		internal FormattingChanges(IDocument document)
		{
			if (document == null)
			{
				throw new ArgumentNullException("document");
			}
			this.document = document;
		}

		public void ApplyChanges()
		{
			int textLength = document.TextLength;
			IDocument obj = document;
			ApplyChanges(0, textLength, obj.Replace, (int o, int l, string v) => document.GetText(o, l) == v);
		}

		public void ApplyChanges(int startOffset, int length)
		{
			IDocument obj = document;
			ApplyChanges(startOffset, length, obj.Replace, (int o, int l, string v) => document.GetText(o, l) == v);
		}

		public void ApplyChanges(Script script)
		{
			ApplyChanges(0, document.TextLength, script.Replace);
		}

		public void ApplyChanges(int startOffset, int length, Script script)
		{
			ApplyChanges(startOffset, length, script.Replace);
		}

		public void ApplyChanges(int startOffset, int length, Action<int, int, string> documentReplace, Func<int, int, string, bool> filter = null)
		{
			int num = startOffset + length;
			TextReplaceAction textReplaceAction = null;
			int num2 = 0;
			List<TextReplaceAction> list = new List<TextReplaceAction>();
			foreach (TextReplaceAction item in from c in changes
				orderby c.Offset
				select c)
			{
				if (textReplaceAction != null)
				{
					if (item.Equals(textReplaceAction))
					{
						continue;
					}
					if (item.Offset < textReplaceAction.Offset + textReplaceAction.RemovalLength)
					{
						throw new InvalidOperationException("Detected overlapping changes " + item + "/" + textReplaceAction);
					}
				}
				textReplaceAction = item;
				if (!(((item.Offset + item.RemovalLength < startOffset || item.Offset > num) | (filter?.Invoke(item.Offset + num2, item.RemovalLength, item.NewText) ?? false)) & !list.Contains(item)))
				{
					documentReplace(item.Offset + num2, item.RemovalLength, item.NewText);
					num2 += item.NewText.Length - item.RemovalLength;
					if (item.DependsOn != null)
					{
						list.Add(item.DependsOn);
					}
				}
			}
			changes.Clear();
		}

		internal TextReplaceAction AddChange(int offset, int removedChars, string insertedText)
		{
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset", "Should be >= 0");
			}
			if (offset >= document.TextLength)
			{
				throw new ArgumentOutOfRangeException("offset", "Should be < document.TextLength");
			}
			if (removedChars < 0)
			{
				throw new ArgumentOutOfRangeException("removedChars", "Should be >= 0");
			}
			if (removedChars > offset + document.TextLength)
			{
				throw new ArgumentOutOfRangeException("removedChars", "Tried to remove beyond end of text");
			}
			if (removedChars == 0 && string.IsNullOrEmpty(insertedText))
			{
				return null;
			}
			TextReplaceAction textReplaceAction = new TextReplaceAction(offset, removedChars, insertedText);
			changes.Add(textReplaceAction);
			return textReplaceAction;
		}
	}
}
