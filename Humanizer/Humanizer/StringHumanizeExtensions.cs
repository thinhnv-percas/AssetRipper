using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Humanizer;

public static class StringHumanizeExtensions
{
	private static readonly Regex PascalCaseWordPartsRegex;

	private static readonly Regex FreestandingSpacingCharRegex;

	static StringHumanizeExtensions()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		PascalCaseWordPartsRegex = new Regex("[\\p{Lu}]?[\\p{Ll}]+|[0-9]+[\\p{Ll}]*|[\\p{Lu}]+(?=[\\p{Lu}][\\p{Ll}]|[0-9]|\\b)|[\\p{Lo}]+", RegexOptions.ExplicitCapture | RegexOptions.IgnorePatternWhitespace | RegexOptionsUtil.Compiled);
		FreestandingSpacingCharRegex = new Regex("\\s[-_]|[-_]\\s", RegexOptionsUtil.Compiled);
	}

	private static string FromUnderscoreDashSeparatedWords(string input)
	{
		return string.Join(" ", input.Split('_', '-'));
	}

	private static string FromPascalCase(string input)
	{
		string text = string.Join(" ", Enumerable.Select<Match, string>(Enumerable.Cast<Match>((IEnumerable)PascalCaseWordPartsRegex.Matches(input)), (Func<Match, string>)((Match match) => (!Enumerable.All<char>((IEnumerable<char>)((Capture)match).Value.ToCharArray(), (Func<char, bool>)char.IsUpper) || (((Capture)match).Value.Length <= 1 && (((Capture)match).Index <= 0 || input[((Capture)match).Index - 1] != ' ') && !(((Capture)match).Value == "I"))) ? ((Capture)match).Value.ToLower() : ((Capture)match).Value)));
		if (text.Length <= 0)
		{
			return text;
		}
		return char.ToUpper(text[0]) + text.Substring(1, text.Length - 1);
	}

	public static string Humanize(this string input)
	{
		if (Enumerable.All<char>((IEnumerable<char>)input.ToCharArray(), (Func<char, bool>)char.IsUpper))
		{
			return input;
		}
		if (FreestandingSpacingCharRegex.IsMatch(input))
		{
			return FromPascalCase(FromUnderscoreDashSeparatedWords(input));
		}
		if (input.Contains("_") || input.Contains("-"))
		{
			return FromUnderscoreDashSeparatedWords(input);
		}
		return FromPascalCase(input);
	}

	public static string Humanize(this string input, LetterCasing casing)
	{
		return input.Humanize().ApplyCase(casing);
	}
}
