using System;
using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords;

internal class BanglaNumberToWordsConverter : GenderlessNumberToWordsConverter
{
	private static readonly string[] UnitsMap = new string[100]
	{
		"শ\u09c2ন\u09cdয", "এক", "দ\u09c1ই", "ত\u09bfন", "চ\u09beর", "প\u09be\u0981চ", "ছয়", "স\u09beত", "আট", "নয়",
		"দশ", "এগ\u09beর\u09cb", "ব\u09beর\u09cb", "ত\u09c7র\u09cb", "চ\u09cbদ\u09cdদ", "পন\u09c7র\u09cb", "ষ\u09cbল", "সত\u09c7র\u09cb", "আঠ\u09beর\u09cb", "উন\u09bfশ",
		"ব\u09bfশ", "এক\u09c1শ", "ব\u09beইশ", "ত\u09c7ইশ", "চব\u09cdব\u09bfশ", "প\u0981চ\u09bfশ", "ছ\u09beব\u09cdব\u09bfশ", "স\u09beত\u09beশ", "আঠ\u09beশ", "উনত\u09bfর\u09bfশ",
		"ত\u09bfর\u09bfশ", "একত\u09bfর\u09bfশ", "বত\u09cdর\u09bfশ", "ত\u09c7ত\u09cdর\u09bfশ", "চ\u09cc\u0981ত\u09bfর\u09bfশ", "প\u0981য়ত\u09bfর\u09bfশ", "ছত\u09cdর\u09bfশ", "স\u09be\u0981ইত\u09bfর\u09bfশ", "আটত\u09bfর\u09bfশ", "উনচল\u09cdল\u09bfশ",
		"চল\u09cdল\u09bfশ", "একচল\u09cdল\u09bfশ", "ব\u09bfয\u09bc\u09beল\u09cdল\u09bfশ", "ত\u09c7ত\u09beল\u09cdল\u09bfশ", "চ\u09c1য\u09bc\u09beল\u09cdল\u09bfশ", "প\u0981য়ত\u09beল\u09cdল\u09bfশ", "ছ\u09c7চ\u09beল\u09cdল\u09bfশ", "স\u09beতচল\u09cdল\u09bfশ", "আটচল\u09cdল\u09bfশ", "উনপঞ\u09cdচ\u09beশ",
		"পঞ\u09cdচ\u09beশ", "এক\u09beন\u09cdন", "ব\u09beহ\u09beন\u09cdন", "ত\u09bfপ\u09cdপ\u09beন\u09cdন", "চ\u09c1য\u09bc\u09beন\u09cdন", "পঞ\u09cdচ\u09beন\u09cdন", "ছ\u09beপ\u09cdপ\u09beন\u09cdন", "স\u09beত\u09beন\u09cdন", "আট\u09beন\u09cdন", "উনষ\u09beট",
		"ষ\u09beট", "একষট\u09cdট\u09bf", "ব\u09beষট\u09cdট\u09bf", "ত\u09c7ষট\u09cdট\u09bf", "চ\u09ccষট\u09cdট\u09bf", "প\u0981য়ষট\u09cdট\u09bf", "ছ\u09c7ষট\u09cdট\u09bf", "স\u09beতষট\u09cdট\u09bf", "আটষট\u09cdট\u09bf", "উনসত\u09cdতর",
		"সত\u09cdতর", "এক\u09beত\u09cdতর", "ব\u09beহ\u09beত\u09cdতর", "ত\u09bfয\u09bc\u09beত\u09cdতর", "চ\u09c1য\u09bc\u09beত\u09cdতর", "প\u0981চ\u09beত\u09cdতর", "ছ\u09bfয\u09bc\u09beত\u09cdতর", "স\u09beত\u09beত\u09cdতর", "আট\u09beত\u09cdতর", "উনআশ\u09bf",
		"আশ\u09bf", "এক\u09beশ\u09bf", "ব\u09bfর\u09beশ\u09bf", "ত\u09bfর\u09beশ\u09bf", "চ\u09c1র\u09beশ\u09bf", "প\u0981চ\u09beশ\u09bf", "ছ\u09bfয\u09bc\u09beশ\u09bf", "স\u09beত\u09beশ\u09bf", "আট\u09beশ\u09bf", "উননব\u09cdবই",
		"নব\u09cdবই", "এক\u09beনব\u09cdবই", "ব\u09bfর\u09beনব\u09cdবই", "ত\u09bfর\u09beনব\u09cdব\u09bfই", "চ\u09c1র\u09beনব\u09cdবই", "প\u0981চ\u09beনব\u09cdবই", "ছ\u09bfয\u09bc\u09beনব\u09cdবই", "স\u09beত\u09beনব\u09cdবই", "আট\u09beনব\u09cdবই", "ন\u09bfর\u09beনব\u09cdবই"
	};

	private static readonly string[] HundredsMap = new string[10] { "শ\u09c2ন\u09cdয", "একশ", "দ\u09c1ইশ", "ত\u09bfনশ", "চ\u09beরশ", "প\u09be\u0981চশ", "ছয়শ", "স\u09beতশ", "আটশ", "নয়শ" };

	private static readonly Dictionary<int, string> OrdinalExceptions = new Dictionary<int, string>
	{
		{ 1, "প\u09cdরথম" },
		{ 2, "দ\u09cdব\u09bfত\u09c0য়" },
		{ 3, "ত\u09c3ত\u09c0য়" },
		{ 4, "চত\u09c1র\u09cdথ" },
		{ 5, "পঞ\u09cdচম" },
		{ 6, "ষষ\u09cdট" },
		{ 7, "সপ\u09cdতম" },
		{ 8, "অষ\u09cdটম" },
		{ 9, "নবম" },
		{ 10, "দশম" },
		{ 11, "এক\u09beদশ" },
		{ 12, "দ\u09cdব\u09beদশ" },
		{ 13, "ত\u09cdরয়\u09cbদশ" },
		{ 14, "চত\u09c1র\u09cdদশ" },
		{ 15, "পঞ\u09cdচদশ" },
		{ 16, "ষ\u09c7\u09beড\u09bcশ" },
		{ 17, "সপ\u09cdতদশ" },
		{ 18, "অষ\u09cdট\u09beদশ" },
		{ 100, "শত তম" },
		{ 1000, "হ\u09beজ\u09beর তম" },
		{ 100000, "লক\u09cdষ তম" },
		{ 10000000, "ক\u09cbট\u09bf তম" }
	};

	public override string ConvertToOrdinal(int number)
	{
		if (ExceptionNumbersToWords(number, out var words))
		{
			return words;
		}
		return Convert(number) + " তম";
	}

	public override string Convert(long input)
	{
		if (input > int.MaxValue || input < int.MinValue)
		{
			throw new NotImplementedException();
		}
		int num = (int)input;
		if (num == 0)
		{
			return UnitsMap[0];
		}
		if (num < 0)
		{
			return $"ঋণ\u09beত\u09cdমক {Convert(-num)}";
		}
		List<string> list = new List<string>();
		if (num / 10000000 > 0)
		{
			list.Add($"{Convert(num / 10000000)} ক\u09cbট\u09bf");
			num %= 10000000;
		}
		if (num / 100000 > 0)
		{
			list.Add($"{Convert(num / 100000)} লক\u09cdষ");
			num %= 100000;
		}
		if (num / 1000 > 0)
		{
			list.Add($"{Convert(num / 1000)} হ\u09beজ\u09beর");
			num %= 1000;
		}
		if (num / 100 > 0)
		{
			list.Add($"{HundredsMap[num / 100]}");
			num %= 100;
		}
		if (num > 0)
		{
			list.Add(UnitsMap[num]);
		}
		return string.Join(" ", list.ToArray());
	}

	private static bool ExceptionNumbersToWords(int number, out string words)
	{
		return OrdinalExceptions.TryGetValue(number, out words);
	}
}
