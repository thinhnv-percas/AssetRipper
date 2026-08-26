using System;

namespace Humanizer;

public static class TruncateExtensions
{
	public static string Truncate(this string input, int length)
	{
		return input.Truncate(length, "…", Truncator.FixedLength);
	}

	public static string Truncate(this string input, int length, ITruncator truncator, TruncateFrom from = TruncateFrom.Right)
	{
		return input.Truncate(length, "…", truncator, from);
	}

	public static string Truncate(this string input, int length, string truncationString, TruncateFrom from = TruncateFrom.Right)
	{
		return input.Truncate(length, truncationString, Truncator.FixedLength, from);
	}

	public static string Truncate(this string input, int length, string truncationString, ITruncator truncator, TruncateFrom from = TruncateFrom.Right)
	{
		if (truncator == null)
		{
			throw new ArgumentNullException("truncator");
		}
		if (input == null)
		{
			return null;
		}
		return truncator.Truncate(input, length, truncationString, from);
	}
}
