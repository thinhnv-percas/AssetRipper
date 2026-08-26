namespace DecompTools.Decompiler.CSharp.Syntax;

public class LinePreprocessorDirective : PreProcessorDirective
{
	public int LineNumber { get; set; }

	public string FileName { get; set; }

	public LinePreprocessorDirective(TextLocation startLocation, TextLocation endLocation)
		: base(PreProcessorDirectiveType.Line, startLocation, endLocation)
	{
	}

	public LinePreprocessorDirective(string argument = null)
		: base(PreProcessorDirectiveType.Line, argument)
	{
	}
}
