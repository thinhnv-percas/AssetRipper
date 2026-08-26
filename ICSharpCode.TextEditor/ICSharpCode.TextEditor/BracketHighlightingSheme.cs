using System;
using ICSharpCode.TextEditor.Document;

namespace ICSharpCode.TextEditor;

public class BracketHighlightingSheme
{
	private char opentag;

	private char closingtag;

	public char OpenTag
	{
		get
		{
			return opentag;
		}
		set
		{
			opentag = value;
		}
	}

	public char ClosingTag
	{
		get
		{
			return closingtag;
		}
		set
		{
			closingtag = value;
		}
	}

	public BracketHighlightingSheme(char opentag, char closingtag)
	{
		this.opentag = opentag;
		this.closingtag = closingtag;
	}

	public BracketHighlight GetHighlight(IDocument document, int offset)
	{
		int num = ((document.TextEditorProperties.BracketMatchingStyle != BracketMatchingStyle.After) ? (offset + 1) : offset);
		char charAt = document.GetCharAt(Math.Max(0, Math.Min(document.TextLength - 1, num)));
		TextLocation closeBrace = document.OffsetToPosition(num);
		if (charAt == opentag)
		{
			if (num < document.TextLength)
			{
				int num2 = TextUtilities.SearchBracketForward(document, num + 1, opentag, closingtag);
				if (num2 >= 0)
				{
					return new BracketHighlight(document.OffsetToPosition(num2), closeBrace);
				}
			}
		}
		else if (charAt == closingtag && num > 0)
		{
			int num3 = TextUtilities.SearchBracketBackward(document, num - 1, opentag, closingtag);
			if (num3 >= 0)
			{
				return new BracketHighlight(document.OffsetToPosition(num3), closeBrace);
			}
		}
		return null;
	}
}
