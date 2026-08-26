using System;
using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords;

internal class NorwegianBokmalNumberToWordsConverter : GenderedNumberToWordsConverter
{
	private static readonly string[] UnitsMap = new string[20]
	{
		"null", "en", "to", "tre", "fire", "fem", "seks", "sju", "åtte", "ni",
		"ti", "elleve", "tolv", "tretten", "fjorten", "femten", "seksten", "sytten", "atten", "nitten"
	};

	private static readonly string[] TensMap = new string[10] { "null", "ti", "tjue", "tretti", "førti", "femti", "seksti", "sytti", "åtti", "nitti" };

	private static readonly Dictionary<int, string> OrdinalExceptions = new Dictionary<int, string>
	{
		{ 0, "nullte" },
		{ 1, "første" },
		{ 2, "andre" },
		{ 3, "tredje" },
		{ 4, "fjerde" },
		{ 5, "femte" },
		{ 6, "sjette" },
		{ 11, "ellevte" },
		{ 12, "tolvte" }
	};

	public override string Convert(long number, GrammaticalGender gender)
	{
		if (number > int.MaxValue || number < int.MinValue)
		{
			throw new NotImplementedException();
		}
		return Convert((int)number, isOrdinal: false, gender);
	}

	public override string ConvertToOrdinal(int number, GrammaticalGender gender)
	{
		return Convert(number, isOrdinal: true, gender);
	}

	private string Convert(int number, bool isOrdinal, GrammaticalGender gender)
	{
		if (number == 0)
		{
			return GetUnitValue(0, isOrdinal);
		}
		if (number < 0)
		{
			return $"minus {Convert(-number, isOrdinal, gender)}";
		}
		if (number == 1)
		{
			switch (gender)
			{
			case GrammaticalGender.Feminine:
				return "ei";
			case GrammaticalGender.Neuter:
				return "et";
			}
		}
		List<string> list = new List<string>();
		bool flag = false;
		if (number / 1000000000 > 0)
		{
			flag = true;
			bool flag2 = isOrdinal && number % 1000000000 == 0;
			list.Add(Part("{0} milliard" + (flag2 ? "" : "er"), (flag2 ? "" : "en ") + "milliard", number / 1000000000, !flag2));
			number %= 1000000000;
		}
		if (number / 1000000 > 0)
		{
			flag = true;
			bool flag3 = isOrdinal && number % 1000000 == 0;
			list.Add(Part("{0} million" + (flag3 ? "" : "er"), (flag3 ? "" : "en ") + "million", number / 1000000, !flag3));
			number %= 1000000;
		}
		bool flag4 = false;
		if (number / 1000 > 0)
		{
			flag4 = true;
			list.Add(Part("{0}tusen", (number % 1000 < 100) ? "tusen" : "ettusen", number / 1000));
			number %= 1000;
		}
		bool flag5 = false;
		if (number / 100 > 0)
		{
			flag5 = true;
			list.Add(Part("{0}hundre", (flag4 | flag) ? "ethundre" : "hundre", number / 100));
			number %= 100;
		}
		if (number > 0)
		{
			if (list.Count != 0)
			{
				if (flag && !flag5 && !flag4)
				{
					list.Add("og ");
				}
				else
				{
					list.Add("og");
				}
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
					text += $"{GetUnitValue(number % 10, isOrdinal)}";
				}
				else if (isOrdinal)
				{
					text = text.TrimEnd(new char[1] { 'e' }) + "ende";
				}
				list.Add(text);
			}
		}
		else if (isOrdinal)
		{
			List<string> list2 = list;
			int index = list.Count - 1;
			list2[index] = list2[index] + ((number == 0) ? "" : "en") + (flag ? "te" : "de");
		}
		return string.Join("", list.ToArray()).Trim();
	}

	private static string GetUnitValue(int number, bool isOrdinal)
	{
		if (isOrdinal)
		{
			if (ExceptionNumbersToWords(number, out var words))
			{
				return words;
			}
			if (number < 13)
			{
				return UnitsMap[number].TrimEnd(new char[1] { 'e' }) + "ende";
			}
			return UnitsMap[number] + "de";
		}
		return UnitsMap[number];
	}

	private static bool ExceptionNumbersToWords(int number, out string words)
	{
		return OrdinalExceptions.TryGetValue(number, out words);
	}

	private string Part(string pluralFormat, string singular, int number, bool postfixSpace = false)
	{
		string text = (postfixSpace ? " " : "");
		if (number == 1)
		{
			return singular + text;
		}
		return string.Format(pluralFormat, new object[1] { Convert(number) }) + text;
	}
}
