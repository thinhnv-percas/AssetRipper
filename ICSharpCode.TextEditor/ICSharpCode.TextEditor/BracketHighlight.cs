namespace ICSharpCode.TextEditor;

public class BracketHighlight
{
	public TextLocation OpenBrace { get; set; }

	public TextLocation CloseBrace { get; set; }

	public BracketHighlight(TextLocation openBrace, TextLocation closeBrace)
	{
		OpenBrace = openBrace;
		CloseBrace = closeBrace;
	}
}
