using System;
using System.Collections.Generic;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Rendering;

namespace ICSharpCode.AvalonEdit.Highlighting;

public class RichTextColorizer : DocumentColorizingTransformer
{
	private readonly RichTextModel richTextModel;

	public RichTextColorizer(RichTextModel richTextModel)
	{
		if (richTextModel == null)
		{
			throw new ArgumentNullException("richTextModel");
		}
		this.richTextModel = richTextModel;
	}

	protected override void ColorizeLine(DocumentLine line)
	{
		IEnumerable<HighlightedSection> highlightedSections = richTextModel.GetHighlightedSections(line.Offset, line.Length);
		foreach (HighlightedSection section in highlightedSections)
		{
			if (!HighlightingColorizer.IsEmptyColor(section.Color))
			{
				ChangeLinePart(section.Offset, section.Offset + section.Length, delegate(VisualLineElement visualLineElement)
				{
					HighlightingColorizer.ApplyColorToElement(visualLineElement, section.Color, base.CurrentContext);
				});
			}
		}
	}
}
