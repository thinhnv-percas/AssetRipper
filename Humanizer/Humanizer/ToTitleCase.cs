using System;
using System.Collections.Generic;
using System.Linq;

namespace Humanizer;

internal class ToTitleCase : IStringTransformer
{
	public string Transform(string input)
	{
		string[] array = input.Split(new char[1] { ' ' });
		List<string> list = new List<string>();
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (text.Length == 0 || AllCapitals(text))
			{
				list.Add(text);
			}
			else if (text.Length == 1)
			{
				list.Add(text.ToUpper());
			}
			else
			{
				list.Add(char.ToUpper(text[0]) + text.Remove(0, 1).ToLower());
			}
		}
		return string.Join(" ", list);
	}

	private static bool AllCapitals(string input)
	{
		return Enumerable.All<char>((IEnumerable<char>)input.ToCharArray(), (Func<char, bool>)char.IsUpper);
	}
}
