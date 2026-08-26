using System;
using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords;

internal class GermanNumberToWordsConverter : GenderedNumberToWordsConverter
{
	private static readonly string[] UnitsMap = new string[20]
	{
		"null", "ein", "zwei", "drei", "vier", "fünf", "sechs", "sieben", "acht", "neun",
		"zehn", "elf", "zwölf", "dreizehn", "vierzehn", "fünfzehn", "sechzehn", "siebzehn", "achtzehn", "neunzehn"
	};

	private static readonly string[] TensMap = new string[10] { "null", "zehn", "zwanzig", "dreißig", "vierzig", "fünfzig", "sechzig", "siebzig", "achtzig", "neunzig" };

	private static readonly string[] UnitsOrdinal = new string[20]
	{
		string.Empty,
		"ers",
		"zwei",
		"drit",
		"vier",
		"fünf",
		"sechs",
		"sieb",
		"ach",
		"neun",
		"zehn",
		"elf",
		"zwölf",
		"dreizehn",
		"vierzehn",
		"fünfzehn",
		"sechzehn",
		"siebzehn",
		"achtzehn",
		"neunzehn"
	};

	private static readonly string[] MillionOrdinalSingular = new string[2] { "einmillion", "einemillion" };

	private static readonly string[] MillionOrdinalPlural = new string[2] { "{0}million", "{0}millionen" };

	private static readonly string[] BillionOrdinalSingular = new string[2] { "einmilliard", "einemilliarde" };

	private static readonly string[] BillionOrdinalPlural = new string[2] { "{0}milliard", "{0}milliarden" };

	public override string Convert(long input, GrammaticalGender gender)
	{
		if (input > int.MaxValue || input < int.MinValue)
		{
			throw new NotImplementedException();
		}
		int num = (int)input;
		if (num == 0)
		{
			return "null";
		}
		if (num < 0)
		{
			return $"minus {Convert(-num)}";
		}
		List<string> list = new List<string>();
		int num2 = num / 1000000000;
		if (num2 > 0)
		{
			list.Add(Part("{0} Milliarden", "eine Milliarde", num2));
			num %= 1000000000;
			if (num > 0)
			{
				list.Add(" ");
			}
		}
		int num3 = num / 1000000;
		if (num3 > 0)
		{
			list.Add(Part("{0} Millionen", "eine Million", num3));
			num %= 1000000;
			if (num > 0)
			{
				list.Add(" ");
			}
		}
		int num4 = num / 1000;
		if (num4 > 0)
		{
			list.Add(Part("{0}tausend", "eintausend", num4));
			num %= 1000;
		}
		int num5 = num / 100;
		if (num5 > 0)
		{
			list.Add(Part("{0}hundert", "einhundert", num5));
			num %= 100;
		}
		if (num > 0)
		{
			if (num < 20)
			{
				if (num > 1)
				{
					list.Add(UnitsMap[num]);
				}
				else
				{
					list.Add("eins");
				}
			}
			else
			{
				int num6 = num % 10;
				if (num6 > 0)
				{
					list.Add($"{UnitsMap[num6]}und");
				}
				list.Add(TensMap[num / 10]);
			}
		}
		return string.Join("", list);
	}

	public override string ConvertToOrdinal(int number, GrammaticalGender gender)
	{
		if (number == 0)
		{
			return "null" + GetEndingForGender(gender);
		}
		List<string> list = new List<string>();
		if (number < 0)
		{
			list.Add("minus ");
			number = -number;
		}
		int num = number / 1000000000;
		if (num > 0)
		{
			number %= 1000000000;
			int num2 = NoRestIndex(number);
			list.Add(Part(BillionOrdinalPlural[num2], BillionOrdinalSingular[num2], num));
		}
		int num3 = number / 1000000;
		if (num3 > 0)
		{
			number %= 1000000;
			int num4 = NoRestIndex(number);
			list.Add(Part(MillionOrdinalPlural[num4], MillionOrdinalSingular[num4], num3));
		}
		int num5 = number / 1000;
		if (num5 > 0)
		{
			list.Add(Part("{0}tausend", "eintausend", num5));
			number %= 1000;
		}
		int num6 = number / 100;
		if (num6 > 0)
		{
			list.Add(Part("{0}hundert", "einhundert", num6));
			number %= 100;
		}
		if (number > 0)
		{
			list.Add((number < 20) ? UnitsOrdinal[number] : Convert(number));
		}
		if (number == 0 || number >= 20)
		{
			list.Add("s");
		}
		list.Add(GetEndingForGender(gender));
		return string.Join("", list);
	}

	private string Part(string pluralFormat, string singular, int number)
	{
		if (number == 1)
		{
			return singular;
		}
		return string.Format(pluralFormat, new object[1] { Convert(number) });
	}

	private static int NoRestIndex(int number)
	{
		if (number != 0)
		{
			return 1;
		}
		return 0;
	}

	private static string GetEndingForGender(GrammaticalGender gender)
	{
		return gender switch
		{
			GrammaticalGender.Masculine => "ter", 
			GrammaticalGender.Feminine => "te", 
			GrammaticalGender.Neuter => "tes", 
			_ => throw new ArgumentOutOfRangeException("gender"), 
		};
	}
}
