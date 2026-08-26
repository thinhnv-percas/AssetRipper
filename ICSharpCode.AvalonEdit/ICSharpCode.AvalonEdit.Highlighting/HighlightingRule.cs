using System;
using System.Text.RegularExpressions;

namespace ICSharpCode.AvalonEdit.Highlighting;

[Serializable]
public class HighlightingRule
{
	public Regex Regex { get; set; }

	public HighlightingColor Color { get; set; }

	public override string ToString()
	{
		return string.Concat("[", GetType().Name, " ", Regex, "]");
	}
}
