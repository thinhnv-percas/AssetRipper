using System;
using System.Collections.Generic;
using Humanizer.Localisation.GrammaticalNumber;

namespace Humanizer.Localisation.NumberToWords;

internal class RussianNumberToWordsConverter : GenderedNumberToWordsConverter
{
	private static readonly string[] HundredsMap = new string[10] { "ноль", "сто", "двести", "триста", "четыреста", "пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот" };

	private static readonly string[] TensMap = new string[10] { "ноль", "десять", "двадцать", "тридцать", "сорок", "пятьдесят", "шестьдесят", "семьдесят", "восемьдесят", "девяносто" };

	private static readonly string[] UnitsMap = new string[20]
	{
		"ноль", "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять",
		"десять", "одиннадцать", "двенадцать", "тринадцать", "четырнадцать", "пятнадцать", "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать"
	};

	private static readonly string[] UnitsOrdinalPrefixes = new string[20]
	{
		string.Empty,
		string.Empty,
		"двух",
		"трёх",
		"четырёх",
		"пяти",
		"шести",
		"семи",
		"восьми",
		"девяти",
		"десяти",
		"одиннадцати",
		"двенадцати",
		"тринадцати",
		"четырнадцати",
		"пятнадцати",
		"шестнадцати",
		"семнадцати",
		"восемнадцати",
		"девятнадцати"
	};

	private static readonly string[] TensOrdinalPrefixes = new string[10]
	{
		string.Empty,
		"десяти",
		"двадцати",
		"тридцати",
		"сорока",
		"пятидесяти",
		"шестидесяти",
		"семидесяти",
		"восьмидесяти",
		"девяносто"
	};

	private static readonly string[] TensOrdinal = new string[10]
	{
		string.Empty,
		"десят",
		"двадцат",
		"тридцат",
		"сороков",
		"пятидесят",
		"шестидесят",
		"семидесят",
		"восьмидесят",
		"девяност"
	};

	private static readonly string[] UnitsOrdinal = new string[20]
	{
		string.Empty,
		"перв",
		"втор",
		"трет",
		"четверт",
		"пят",
		"шест",
		"седьм",
		"восьм",
		"девят",
		"десят",
		"одиннадцат",
		"двенадцат",
		"тринадцат",
		"четырнадцат",
		"пятнадцат",
		"шестнадцат",
		"семнадцат",
		"восемнадцат",
		"девятнадцат"
	};

	public override string Convert(long input, GrammaticalGender gender)
	{
		if (input > int.MaxValue || input < int.MinValue)
		{
			throw new NotImplementedException();
		}
		int number = (int)input;
		if (number == 0)
		{
			return "ноль";
		}
		List<string> list = new List<string>();
		if (number < 0)
		{
			list.Add("минус");
			number = -number;
		}
		CollectParts(list, ref number, 1000000000, GrammaticalGender.Masculine, "миллиард", "миллиарда", "миллиардов");
		CollectParts(list, ref number, 1000000, GrammaticalGender.Masculine, "миллион", "миллиона", "миллионов");
		CollectParts(list, ref number, 1000, GrammaticalGender.Feminine, "тысяча", "тысячи", "тысяч");
		if (number > 0)
		{
			CollectPartsUnderOneThousand(list, number, gender);
		}
		return string.Join(" ", list);
	}

	public override string ConvertToOrdinal(int number, GrammaticalGender gender)
	{
		if (number == 0)
		{
			return "нулев" + GetEndingForGender(gender, number);
		}
		List<string> list = new List<string>();
		if (number < 0)
		{
			list.Add("минус");
			number = -number;
		}
		CollectOrdinalParts(list, ref number, 1000000000, GrammaticalGender.Masculine, "миллиардн" + GetEndingForGender(gender, number), "миллиард", "миллиарда", "миллиардов");
		CollectOrdinalParts(list, ref number, 1000000, GrammaticalGender.Masculine, "миллионн" + GetEndingForGender(gender, number), "миллион", "миллиона", "миллионов");
		CollectOrdinalParts(list, ref number, 1000, GrammaticalGender.Feminine, "тысячн" + GetEndingForGender(gender, number), "тысяча", "тысячи", "тысяч");
		if (number >= 100)
		{
			string endingForGender = GetEndingForGender(gender, number);
			int num = number / 100;
			number %= 100;
			if (number == 0)
			{
				list.Add(UnitsOrdinalPrefixes[num] + "сот" + endingForGender);
			}
			else
			{
				list.Add(HundredsMap[num]);
			}
		}
		if (number >= 20)
		{
			string endingForGender2 = GetEndingForGender(gender, number);
			int num2 = number / 10;
			number %= 10;
			if (number == 0)
			{
				list.Add(TensOrdinal[num2] + endingForGender2);
			}
			else
			{
				list.Add(TensMap[num2]);
			}
		}
		if (number > 0)
		{
			list.Add(UnitsOrdinal[number] + GetEndingForGender(gender, number));
		}
		return string.Join(" ", list);
	}

	private static void CollectPartsUnderOneThousand(ICollection<string> parts, int number, GrammaticalGender gender)
	{
		if (number >= 100)
		{
			int num = number / 100;
			number %= 100;
			parts.Add(HundredsMap[num]);
		}
		if (number >= 20)
		{
			int num2 = number / 10;
			parts.Add(TensMap[num2]);
			number %= 10;
		}
		if (number > 0)
		{
			if (number == 1 && gender == GrammaticalGender.Feminine)
			{
				parts.Add("одна");
			}
			else if (number == 1 && gender == GrammaticalGender.Neuter)
			{
				parts.Add("одно");
			}
			else if (number == 2 && gender == GrammaticalGender.Feminine)
			{
				parts.Add("две");
			}
			else if (number < 20)
			{
				parts.Add(UnitsMap[number]);
			}
		}
	}

	private static string GetPrefix(int number)
	{
		List<string> list = new List<string>();
		if (number >= 100)
		{
			int num = number / 100;
			number %= 100;
			if (num != 1)
			{
				list.Add(UnitsOrdinalPrefixes[num] + "сот");
			}
			else
			{
				list.Add("сто");
			}
		}
		if (number >= 20)
		{
			int num2 = number / 10;
			number %= 10;
			list.Add(TensOrdinalPrefixes[num2]);
		}
		if (number > 0)
		{
			list.Add((number == 1) ? "одно" : UnitsOrdinalPrefixes[number]);
		}
		return string.Join("", list);
	}

	private static void CollectParts(ICollection<string> parts, ref int number, int divisor, GrammaticalGender gender, params string[] forms)
	{
		if (number >= divisor)
		{
			int number2 = number / divisor;
			number %= divisor;
			CollectPartsUnderOneThousand(parts, number2, gender);
			parts.Add(ChooseOneForGrammaticalNumber(number2, forms));
		}
	}

	private static void CollectOrdinalParts(ICollection<string> parts, ref int number, int divisor, GrammaticalGender gender, string prefixedForm, params string[] forms)
	{
		if (number < divisor)
		{
			return;
		}
		int num = number / divisor;
		number %= divisor;
		if (number == 0)
		{
			if (num == 1)
			{
				parts.Add(prefixedForm);
			}
			else
			{
				parts.Add(GetPrefix(num) + prefixedForm);
			}
		}
		else
		{
			CollectPartsUnderOneThousand(parts, num, gender);
			parts.Add(ChooseOneForGrammaticalNumber(num, forms));
		}
	}

	private static int GetIndex(RussianGrammaticalNumber number)
	{
		return number switch
		{
			RussianGrammaticalNumber.Singular => 0, 
			RussianGrammaticalNumber.Paucal => 1, 
			_ => 2, 
		};
	}

	private static string ChooseOneForGrammaticalNumber(int number, string[] forms)
	{
		return forms[GetIndex(RussianGrammaticalNumberDetector.Detect(number))];
	}

	private static string GetEndingForGender(GrammaticalGender gender, int number)
	{
		switch (gender)
		{
		case GrammaticalGender.Masculine:
			switch (number)
			{
			case 0:
			case 2:
			case 6:
			case 7:
			case 8:
			case 40:
				return "ой";
			case 3:
				return "ий";
			default:
				return "ый";
			}
		case GrammaticalGender.Feminine:
			if (number == 3)
			{
				return "ья";
			}
			return "ая";
		case GrammaticalGender.Neuter:
			if (number == 3)
			{
				return "ье";
			}
			return "ое";
		default:
			throw new ArgumentOutOfRangeException("gender");
		}
	}
}
