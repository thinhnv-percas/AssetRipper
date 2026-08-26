using System;
using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords;

internal class EnglishNumberToWordsConverter : GenderlessNumberToWordsConverter
{
	private static readonly string[] UnitsMap = new string[20]
	{
		"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine",
		"ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
	};

	private static readonly string[] TensMap = new string[10] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

	private static readonly Dictionary<long, string> OrdinalExceptions = new Dictionary<long, string>
	{
		{ 1L, "first" },
		{ 2L, "second" },
		{ 3L, "third" },
		{ 4L, "fourth" },
		{ 5L, "fifth" },
		{ 8L, "eighth" },
		{ 9L, "ninth" },
		{ 12L, "twelfth" }
	};

	public override string Convert(long number)
	{
		return Convert(number, isOrdinal: false);
	}

	public override string ConvertToOrdinal(int number)
	{
		return Convert(number, isOrdinal: true);
	}

	private string Convert(long number, bool isOrdinal)
	{
		if (number == 0L)
		{
			return GetUnitValue(0L, isOrdinal);
		}
		if (number < 0)
		{
			return $"minus {Convert(-number)}";
		}
		List<string> list = new List<string>();
		if (number / 1000000000000000000L > 0)
		{
			list.Add($"{Convert(number / 1000000000000000000L)} quintillion");
			number %= 1000000000000000000L;
		}
		if (number / 1000000000000000L > 0)
		{
			list.Add($"{Convert(number / 1000000000000000L)} quadrillion");
			number %= 1000000000000000L;
		}
		if (number / 1000000000000L > 0)
		{
			list.Add($"{Convert(number / 1000000000000L)} trillion");
			number %= 1000000000000L;
		}
		if (number / 1000000000 > 0)
		{
			list.Add($"{Convert(number / 1000000000)} billion");
			number %= 1000000000;
		}
		if (number / 1000000 > 0)
		{
			list.Add($"{Convert(number / 1000000)} million");
			number %= 1000000;
		}
		if (number / 1000 > 0)
		{
			list.Add($"{Convert(number / 1000)} thousand");
			number %= 1000;
		}
		if (number / 100 > 0)
		{
			list.Add($"{Convert(number / 100)} hundred");
			number %= 100;
		}
		if (number > 0)
		{
			if (list.Count != 0)
			{
				list.Add("and");
			}
			if (number < 20)
			{
				list.Add(GetUnitValue(number, isOrdinal));
			}
			else
			{
				string text = TensMap[number / 10];
				if (number % 10 > 0)
				{
					text += $"-{GetUnitValue(number % 10, isOrdinal)}";
				}
				else if (isOrdinal)
				{
					text = text.TrimEnd(new char[1] { 'y' }) + "ieth";
				}
				list.Add(text);
			}
		}
		else if (isOrdinal)
		{
			list[list.Count - 1] += "th";
		}
		string text2 = string.Join(" ", list.ToArray());
		if (isOrdinal)
		{
			text2 = RemoveOnePrefix(text2);
		}
		return text2;
	}

	private static string GetUnitValue(long number, bool isOrdinal)
	{
		if (isOrdinal)
		{
			if (ExceptionNumbersToWords(number, out var words))
			{
				return words;
			}
			return UnitsMap[number] + "th";
		}
		return UnitsMap[number];
	}

	private static string RemoveOnePrefix(string toWords)
	{
		if (toWords.IndexOf("one", StringComparison.Ordinal) == 0)
		{
			toWords = toWords.Remove(0, 4);
		}
		return toWords;
	}

	private static bool ExceptionNumbersToWords(long number, out string words)
	{
		return OrdinalExceptions.TryGetValue(number, out words);
	}
}
