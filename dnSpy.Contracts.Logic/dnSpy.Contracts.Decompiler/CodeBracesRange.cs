namespace dnSpy.Contracts.Decompiler;

public readonly struct CodeBracesRange
{
	public TextSpan Left { get; }

	public TextSpan Right { get; }

	public CodeBracesRangeFlags Flags { get; }

	public CodeBracesRange(TextSpan left, TextSpan right, CodeBracesRangeFlags flags)
	{
		Left = left;
		Right = right;
		Flags = flags;
	}
}
