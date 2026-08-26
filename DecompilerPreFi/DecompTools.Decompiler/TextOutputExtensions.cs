namespace DecompTools.Decompiler;

public static class TextOutputExtensions
{
	public static void Write(this ITextOutput output, string format, params object[] args)
	{
		output.Write(string.Format(format, args));
	}

	public static void WriteLine(this ITextOutput output, string text)
	{
		output.Write(text);
		output.WriteLine();
	}

	public static void WriteLine(this ITextOutput output, string format, params object[] args)
	{
		output.WriteLine(string.Format(format, args));
	}
}
