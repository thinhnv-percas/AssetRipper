using System;
using System.Collections.Generic;
using System.Linq;

namespace Humanizer;

public static class StringDehumanizeExtensions
{
	public static string Dehumanize(this string input)
	{
		IEnumerable<string> values = Enumerable.Select<string, string>((IEnumerable<string>)input.Split(new char[1] { ' ' }), (Func<string, string>)((string word) => word.Humanize(LetterCasing.Title)));
		return string.Join("", values).Replace(" ", "");
	}
}
