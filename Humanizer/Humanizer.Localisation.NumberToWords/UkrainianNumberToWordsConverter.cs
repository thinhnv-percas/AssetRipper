using System;
using System.Collections.Generic;
using Humanizer.Localisation.GrammaticalNumber;

namespace Humanizer.Localisation.NumberToWords;

internal class UkrainianNumberToWordsConverter : GenderedNumberToWordsConverter
{
	private static readonly string[] HundredsMap = new string[10] { "нуль", "сто", "двісті", "триста", "чотириста", "п'ятсот", "шістсот", "сімсот", "вісімсот", "дев'ятсот" };

	private static readonly string[] TensMap = new string[10] { "нуль", "десять", "двадцять", "тридцять", "сорок", "п'ятдесят", "шістдесят", "сімдесят", "вісімдесят", "дев'яносто" };

	private static readonly string[] UnitsMap = new string[20]
	{
		"нуль", "один", "два", "три", "чотири", "п'ять", "шість", "сім", "вісім", "дев'ять",
		"десять", "одинадцять", "дванадцять", "тринадцять", "чотирнадцять", "п'ятнадцять", "шістнадцять", "сімнадцять", "вісімнадцять", "дев'ятнадцять"
	};

	private static readonly string[] UnitsOrdinalPrefixes = new string[21]
	{
		string.Empty,
		string.Empty,
		"двох",
		"трьох",
		"чотирьох",
		"п'яти",
		"шести",
		"семи",
		"восьми",
		"дев'яти",
		"десяти",
		"одинадцяти",
		"дванадцяти",
		"тринадцяти",
		"чотирнадцяти",
		"п'ятнадцяти",
		"шістнадцяти",
		"сімнадцяти",
		"вісімнадцяти",
		"дев'ятнадцяти",
		"двадцяти"
	};

	private static readonly string[] TensOrdinalPrefixes = new string[10]
	{
		string.Empty,
		"десяти",
		"двадцяти",
		"тридцяти",
		"сорока",
		"п'ятдесяти",
		"шістдесяти",
		"сімдесяти",
		"вісімдесяти",
		"дев'яносто"
	};

	private static readonly string[] TensOrdinal = new string[10]
	{
		string.Empty,
		"десят",
		"двадцят",
		"тридцят",
		"сороков",
		"п'ятдесят",
		"шістдесят",
		"сімдесят",
		"вісімдесят",
		"дев'яност"
	};

	private static readonly string[] UnitsOrdinal = new string[20]
	{
		"нульов", "перш", "друг", "трет", "четверт", "п'ят", "шост", "сьом", "восьм", "дев'ят",
		"десят", "одинадцят", "дванадцят", "тринадцят", "чотирнадцят", "п'ятнадцят", "шістнадцят", "сімнадцят", "вісімнадцят", "дев'ятнадцят"
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
			return "нуль";
		}
		List<string> list = new List<string>();
		if (number < 0)
		{
			list.Add("мінус");
			number = -number;
		}
		CollectParts(list, ref number, 1000000000, GrammaticalGender.Masculine, "мільярд", "мільярда", "мільярдів");
		CollectParts(list, ref number, 1000000, GrammaticalGender.Masculine, "мільйон", "мільйона", "мільйонів");
		CollectParts(list, ref number, 1000, GrammaticalGender.Feminine, "тисяча", "тисячі", "тисяч");
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
			return "нульов" + GetEndingForGender(gender, number);
		}
		List<string> list = new List<string>();
		if (number < 0)
		{
			list.Add("мінус");
			number = -number;
		}
		CollectOrdinalParts(list, ref number, 1000000000, GrammaticalGender.Masculine, "мільярдн" + GetEndingForGender(gender, number), "мільярд", "мільярда", "мільярдів");
		CollectOrdinalParts(list, ref number, 1000000, GrammaticalGender.Masculine, "мільйонн" + GetEndingForGender(gender, number), "мільйон", "мільйона", "мільйонів");
		CollectOrdinalParts(list, ref number, 1000, GrammaticalGender.Feminine, "тисячн" + GetEndingForGender(gender, number), "тисяча", "тисячі", "тисяч");
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
				parts.Add("одне");
			}
			else if (number == 2 && gender == GrammaticalGender.Feminine)
			{
				parts.Add("дві");
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
			if (number == 3)
			{
				return "ій";
			}
			return "ий";
		case GrammaticalGender.Feminine:
			if (number == 3)
			{
				return "я";
			}
			return "а";
		case GrammaticalGender.Neuter:
			if (number == 3)
			{
				return "є";
			}
			return "е";
		default:
			throw new ArgumentOutOfRangeException("gender");
		}
	}
}
