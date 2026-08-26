using System;

namespace dnSpy.Contracts.Text;

public static class TextColorWriterExtensions
{
	public static void Write(this ITextColorWriter writer, string text)
	{
		writer.Write(BoxedTextColor.Text, text);
	}

	public static void WriteLine(this ITextColorWriter writer, string text = null)
	{
		writer.Write(BoxedTextColor.Text, text);
		writer.Write(BoxedTextColor.Text, Environment.NewLine);
	}
}
