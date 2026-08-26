using System;

namespace dnSpy.Contracts.Decompiler;

public static class DecompilerOutputExtensions
{
	public static void AddDebugInfo(this IDecompilerOutput output, MethodDebugInfo methodDebugInfo)
	{
		if (methodDebugInfo == null)
		{
			throw new ArgumentNullException("methodDebugInfo");
		}
		output.AddCustomData("DebugInfo", methodDebugInfo);
	}

	public static void AddSpanReference(this IDecompilerOutput output, SpanReference spanReference)
	{
		output.AddCustomData("SpanReference", spanReference);
	}

	public static void AddSpanReference(this IDecompilerOutput output, object reference, int start, int end, string id)
	{
		output.AddCustomData("SpanReference", new SpanReference(reference, TextSpan.FromBounds(start, end), id));
	}

	public static void AddCodeBracesRange(this IDecompilerOutput output, CodeBracesRange range)
	{
		output.AddCustomData("CodeBracesRange", range);
	}

	public static void AddBracePair(this IDecompilerOutput output, TextSpan start, TextSpan end, CodeBracesRangeFlags flags)
	{
		output.AddCustomData("CodeBracesRange", new CodeBracesRange(start, end, flags));
	}

	public static void AddLineSeparator(this IDecompilerOutput output, int position)
	{
		output.AddCustomData("LineSeparator", new LineSeparator(position));
	}

	public static void WriteLine(this IDecompilerOutput output, string text, object color)
	{
		output.Write(text, color);
		output.WriteLine();
	}

	public static void WriteXmlDoc(this IDecompilerOutput output, string xmlDocText)
	{
		foreach (var item in SimpleXmlParser.Parse(xmlDocText))
		{
			output.Write(item.text, item.color);
		}
	}
}
