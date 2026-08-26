using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ICSharpCode.AvalonEdit.Search;

public static class SearchStrategyFactory
{
	public static ISearchStrategy Create(string searchPattern, bool ignoreCase, bool matchWholeWords, SearchMode mode)
	{
		if (searchPattern == null)
		{
			throw new ArgumentNullException("searchPattern");
		}
		RegexOptions regexOptions = RegexOptions.Multiline | RegexOptions.Compiled;
		if (ignoreCase)
		{
			regexOptions |= RegexOptions.IgnoreCase;
		}
		switch (mode)
		{
		case SearchMode.Normal:
			searchPattern = Regex.Escape(searchPattern);
			break;
		case SearchMode.Wildcard:
			searchPattern = ConvertWildcardsToRegex(searchPattern);
			break;
		}
		try
		{
			Regex searchPattern2 = new Regex(searchPattern, regexOptions);
			return new RegexSearchStrategy(searchPattern2, matchWholeWords);
		}
		catch (ArgumentException ex)
		{
			throw new SearchPatternException(ex.Message, ex);
		}
	}

	private static string ConvertWildcardsToRegex(string searchPattern)
	{
		if (string.IsNullOrEmpty(searchPattern))
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < searchPattern.Length; i++)
		{
			char c = searchPattern[i];
			switch (c)
			{
			case '?':
				stringBuilder.Append(".");
				break;
			case '*':
				stringBuilder.Append(".*");
				break;
			default:
				stringBuilder.Append(Regex.Escape(c.ToString()));
				break;
			}
		}
		return stringBuilder.ToString();
	}
}
