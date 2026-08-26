using System;
using System.Text;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Rendering;
using ICSharpCode.AvalonEdit.Utils;

namespace ICSharpCode.AvalonEdit.Folding;

public sealed class FoldingSection : TextSegment
{
	private readonly FoldingManager manager;

	private bool isFolded;

	internal CollapsedLineSection[] collapsedSections;

	private string title;

	public bool IsFolded
	{
		get
		{
			return isFolded;
		}
		set
		{
			if (isFolded != value)
			{
				isFolded = value;
				ValidateCollapsedLineSections();
				manager.Redraw(this);
			}
		}
	}

	public string Title
	{
		get
		{
			return title;
		}
		set
		{
			if (title != value)
			{
				title = value;
				if (IsFolded)
				{
					manager.Redraw(this);
				}
			}
		}
	}

	public string TextContent => manager.document.GetText(base.StartOffset, base.EndOffset - base.StartOffset);

	[Obsolete]
	public string TooltipText
	{
		get
		{
			DocumentLine lineByOffset = manager.document.GetLineByOffset(base.StartOffset);
			DocumentLine lineByOffset2 = manager.document.GetLineByOffset(base.EndOffset);
			StringBuilder stringBuilder = new StringBuilder();
			DocumentLine documentLine = lineByOffset;
			ISegment leadingWhitespace = TextUtilities.GetLeadingWhitespace(manager.document, lineByOffset);
			while (documentLine != lineByOffset2.NextLine)
			{
				ISegment leadingWhitespace2 = TextUtilities.GetLeadingWhitespace(manager.document, documentLine);
				if (documentLine == lineByOffset && documentLine == lineByOffset2)
				{
					stringBuilder.Append(manager.document.GetText(base.StartOffset, base.EndOffset - base.StartOffset));
				}
				else if (documentLine == lineByOffset)
				{
					if (documentLine.EndOffset - base.StartOffset > 0)
					{
						stringBuilder.AppendLine(manager.document.GetText(base.StartOffset, documentLine.EndOffset - base.StartOffset).TrimStart());
					}
				}
				else if (documentLine == lineByOffset2)
				{
					if (leadingWhitespace.Length <= leadingWhitespace2.Length)
					{
						stringBuilder.Append(manager.document.GetText(documentLine.Offset + leadingWhitespace.Length, base.EndOffset - documentLine.Offset - leadingWhitespace.Length));
					}
					else
					{
						stringBuilder.Append(manager.document.GetText(documentLine.Offset + leadingWhitespace2.Length, base.EndOffset - documentLine.Offset - leadingWhitespace2.Length));
					}
				}
				else if (leadingWhitespace.Length <= leadingWhitespace2.Length)
				{
					stringBuilder.AppendLine(manager.document.GetText(documentLine.Offset + leadingWhitespace.Length, documentLine.Length - leadingWhitespace.Length));
				}
				else
				{
					stringBuilder.AppendLine(manager.document.GetText(documentLine.Offset + leadingWhitespace2.Length, documentLine.Length - leadingWhitespace2.Length));
				}
				documentLine = documentLine.NextLine;
			}
			return stringBuilder.ToString();
		}
	}

	public object Tag { get; set; }

	internal void ValidateCollapsedLineSections()
	{
		if (!isFolded)
		{
			RemoveCollapsedLineSection();
			return;
		}
		DocumentLine lineByOffset = manager.document.GetLineByOffset(base.StartOffset.CoerceValue(0, manager.document.TextLength));
		DocumentLine lineByOffset2 = manager.document.GetLineByOffset(base.EndOffset.CoerceValue(0, manager.document.TextLength));
		if (lineByOffset == lineByOffset2)
		{
			RemoveCollapsedLineSection();
			return;
		}
		if (collapsedSections == null)
		{
			collapsedSections = new CollapsedLineSection[manager.textViews.Count];
		}
		DocumentLine nextLine = lineByOffset.NextLine;
		for (int i = 0; i < collapsedSections.Length; i++)
		{
			CollapsedLineSection collapsedLineSection = collapsedSections[i];
			if (collapsedLineSection == null || collapsedLineSection.Start != nextLine || collapsedLineSection.End != lineByOffset2)
			{
				collapsedLineSection?.Uncollapse();
				collapsedSections[i] = manager.textViews[i].CollapseLines(nextLine, lineByOffset2);
			}
		}
	}

	protected override void OnSegmentChanged()
	{
		ValidateCollapsedLineSections();
		base.OnSegmentChanged();
		if (base.IsConnectedToCollection)
		{
			manager.Redraw(this);
		}
	}

	internal FoldingSection(FoldingManager manager, int startOffset, int endOffset)
	{
		this.manager = manager;
		base.StartOffset = startOffset;
		base.Length = endOffset - startOffset;
	}

	private void RemoveCollapsedLineSection()
	{
		if (collapsedSections == null)
		{
			return;
		}
		CollapsedLineSection[] array = collapsedSections;
		foreach (CollapsedLineSection collapsedLineSection in array)
		{
			if (collapsedLineSection != null && collapsedLineSection.Start != null)
			{
				collapsedLineSection.Uncollapse();
			}
		}
		collapsedSections = null;
	}
}
