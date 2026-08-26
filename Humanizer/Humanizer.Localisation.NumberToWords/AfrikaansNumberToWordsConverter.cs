using System;
using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords;

internal class AfrikaansNumberToWordsConverter : GenderlessNumberToWordsConverter
{
	private static readonly string[] UnitsMap = new string[20]
	{
		"nul", "een", "twee", "drie", "vier", "vyf", "ses", "sewe", "agt", "nege",
		"tien", "elf", "twaalf", "dertien", "veertien", "vyftien", "sestien", "sewentien", "agtien", "negentien"
	};

	private static readonly string[] TensMap = new string[10] { "nul", "tien", "twintig", "dertig", "veertig", "vyftig", "sestig", "sewentig", "tagtig", "negentig" };

	private static readonly Dictionary<int, string> OrdinalExceptions = new Dictionary<int, string>
	{
		{ 0, "nulste" },
		{ 1, "eerste" },
		{ 3, "derde" },
		{ 7, "sewende" },
		{ 8, "agste" },
		{ 9, "negende" },
		{ 10, "tiende" },
		{ 14, "veertiende" },
		{ 17, "sewentiende" },
		{ 19, "negentiende" }
	};

	public override string Convert(long number)
	{
		if (number > int.MaxValue || number < int.MinValue)
		{
			throw new NotImplementedException();
		}
		return Convert((int)number, isOrdinal: false);
	}

	public override string ConvertToOrdinal(int number)
	{
		return Convert(number, isOrdinal: true);
	}

	private string Convert(int number, bool isOrdinal)
	{
		if (number == 0)
		{
			return GetUnitValue(0, isOrdinal);
		}
		if (number < 0)
		{
			return $"minus {Convert(-number)}";
		}
		List<string> list = new List<string>();
		if (number / 1000000000 > 0)
		{
			list.Add($"{Convert(number / 1000000000)} miljard");
			number %= 1000000000;
		}
		if (number / 1000000 > 0)
		{
			list.Add($"{Convert(number / 1000000)} miljoen");
			number %= 1000000;
		}
		if (number / 1000 > 0)
		{
			list.Add($"{Convert(number / 1000)} duisend");
			number %= 1000;
		}
		if (number / 100 > 0)
		{
			list.Add($"{Convert(number / 100)} honderd");
			number %= 100;
		}
		if (number > 0)
		{
			if (number < 20)
			{
				if (list.Count > 0)
				{
					list.Add("en");
				}
				list.Add(GetUnitValue(number, isOrdinal));
			}
			else
			{
				int number2 = number / 10 * 10;
				string text = TensMap[number / 10];
				if (number % 10 > 0)
				{
					text = string.Format("{0} en {1}", new object[2]
					{
						GetUnitValue(number % 10, isOrdinal: false),
						isOrdinal ? GetUnitValue(number2, isOrdinal) : text
					});
				}
				else if (number % 10 == 0)
				{
					text = string.Format("{0}{1}{2}", new object[3]
					{
						(list.Count > 0) ? "en " : "",
						text,
						isOrdinal ? "ste" : ""
					});
				}
				else if (isOrdinal)
				{
					text = text.TrimEnd(new char[1] { '~' }) + "ste";
				}
				list.Add(text);
			}
		}
		else if (isOrdinal)
		{
			list[list.Count - 1] += "ste";
		}
		string text2 = string.Join(" ", list.ToArray());
		if (isOrdinal)
		{
			text2 = RemoveOnePrefix(text2);
		}
		return text2;
	}

	private static string GetUnitValue(int number, bool isOrdinal)
	{
		if (isOrdinal)
		{
			if (ExceptionNumbersToWords(number, out var words))
			{
				return words;
			}
			if (number > 19)
			{
				return TensMap[number / 10] + "ste";
			}
			return UnitsMap[number] + "de";
		}
		return UnitsMap[number];
	}

	private static string RemoveOnePrefix(string toWords)
	{
		if (toWords.IndexOf("een", StringComparison.Ordinal) == 0 && toWords.IndexOf("een en", StringComparison.Ordinal) != 0)
		{
			toWords = toWords.Remove(0, 4);
		}
		return toWords;
	}

	private static bool ExceptionNumbersToWords(int number, out string words)
	{
		return OrdinalExceptions.TryGetValue(number, out words);
	}
}
