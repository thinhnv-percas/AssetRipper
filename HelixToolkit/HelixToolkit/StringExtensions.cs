using System.Collections;
using System.Text;
using System.Text.RegularExpressions;

namespace HelixToolkit;

public static class StringExtensions
{
	private static Regex oneOrMoreWhitespaces = new Regex("\\s+");

	public static string[] SplitOnWhitespace(this string input)
	{
		return oneOrMoreWhitespaces.Split(input.Trim());
	}

	public static string EnumerateToString(this IEnumerable items, string prefix = null, string separator = " ")
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (object item in items)
		{
			if (stringBuilder.Length > 0)
			{
				stringBuilder.Append(separator);
			}
			if (prefix != null)
			{
				stringBuilder.Append(prefix);
			}
			stringBuilder.Append(item);
		}
		return stringBuilder.ToString();
	}
}
