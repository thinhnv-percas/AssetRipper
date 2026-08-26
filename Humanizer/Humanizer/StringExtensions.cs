using System;

namespace Humanizer;

public static class StringExtensions
{
	public static string FormatWith(this string format, params object[] args)
	{
		return string.Format(format, args);
	}

	public static string FormatWith(this string format, IFormatProvider provider, params object[] args)
	{
		return string.Format(provider, format, args);
	}
}
