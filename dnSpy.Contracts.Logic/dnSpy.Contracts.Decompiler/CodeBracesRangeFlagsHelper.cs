namespace dnSpy.Contracts.Decompiler;

public static class CodeBracesRangeFlagsHelper
{
	private const CodeBracesRangeFlags BraceKindMask = CodeBracesRangeFlags.BraceKind_OtherBraces;

	private const CodeBracesRangeFlags BlockKindMask = CodeBracesRangeFlags.BlockKind_Event | CodeBracesRangeFlags.BlockKind_Try;

	public static CodeBracesRangeFlags ToBraceKind(this CodeBracesRangeFlags flags)
	{
		return flags & CodeBracesRangeFlags.BraceKind_OtherBraces;
	}

	public static CodeBracesRangeFlags ToBlockKind(this CodeBracesRangeFlags flags)
	{
		return flags & (CodeBracesRangeFlags.BlockKind_Event | CodeBracesRangeFlags.BlockKind_Try);
	}

	public static bool IsBraces(this CodeBracesRangeFlags flags)
	{
		return (flags & CodeBracesRangeFlags.BraceKind_OtherBraces) != 0;
	}

	public static bool IsBlock(this CodeBracesRangeFlags flags)
	{
		return (flags & (CodeBracesRangeFlags.BlockKind_Event | CodeBracesRangeFlags.BlockKind_Try)) != 0;
	}
}
