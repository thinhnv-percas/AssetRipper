using System;
using System.Collections.Generic;
using System.Globalization;

namespace Humanizer.Localisation.NumberToWords;

internal class PolishNumberToWordsConverter : GenderlessNumberToWordsConverter
{
	private static readonly string[] HundredsMap = new string[10] { "zero", "sto", "dwieście", "trzysta", "czterysta", "pięćset", "sześćset", "siedemset", "osiemset", "dziewięćset" };

	private static readonly string[] TensMap = new string[10] { "zero", "dziesięć", "dwadzieścia", "trzydzieści", "czterdzieści", "pięćdziesiąt", "sześćdziesiąt", "siedemdziesiąt", "osiemdziesiąt", "dziewięćdziesiąt" };

	private static readonly string[] UnitsMap = new string[20]
	{
		"zero", "jeden", "dwa", "trzy", "cztery", "pięć", "sześć", "siedem", "osiem", "dziewięć",
		"dziesięć", "jedenaście", "dwanaście", "trzynaście", "czternaście", "piętnaście", "szesnaście", "siedemnaście", "osiemnaście", "dziewiętnaście"
	};

	private readonly CultureInfo _culture;

	public PolishNumberToWordsConverter(CultureInfo culture)
	{
		_culture = culture;
	}

	private static void CollectPartsUnderThousand(ICollection<string> parts, int number)
	{
		int num = number / 100;
		if (num > 0)
		{
			parts.Add(HundredsMap[num]);
			number %= 100;
		}
		int num2 = number / 10;
		if (num2 > 1)
		{
			parts.Add(TensMap[num2]);
			number %= 10;
		}
		if (number > 0)
		{
			parts.Add(UnitsMap[number]);
		}
	}

	private static int GetMappingIndex(int number)
	{
		switch (number)
		{
		case 1:
			return 0;
		case 2:
		case 3:
		case 4:
			return 1;
		default:
			if (number / 10 > 1)
			{
				int num = number % 10;
				if (num > 1 && num < 5)
				{
					return 1;
				}
			}
			return 2;
		}
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
			return "zero";
		}
		List<string> list = new List<string>();
		if (num < 0)
		{
			list.Add("minus");
			num = -num;
		}
		int num2 = num / 1000000000;
		if (num2 > 0)
		{
			if (num2 > 1)
			{
				CollectPartsUnderThousand(list, num2);
			}
			string[] array = new string[3] { "miliard", "miliardy", "miliardów" };
			list.Add(array[GetMappingIndex(num2)]);
			num %= 1000000000;
		}
		int num3 = num / 1000000;
		if (num3 > 0)
		{
			if (num3 > 1)
			{
				CollectPartsUnderThousand(list, num3);
			}
			string[] array2 = new string[3] { "milion", "miliony", "milionów" };
			list.Add(array2[GetMappingIndex(num3)]);
			num %= 1000000;
		}
		int num4 = num / 1000;
		if (num4 > 0)
		{
			if (num4 > 1)
			{
				CollectPartsUnderThousand(list, num4);
			}
			string[] array3 = new string[3] { "tysiąc", "tysiące", "tysięcy" };
			list.Add(array3[GetMappingIndex(num4)]);
			num %= 1000;
		}
		int num5 = num / 1;
		if (num5 > 0)
		{
			CollectPartsUnderThousand(list, num5);
		}
		return string.Join(" ", list);
	}

	public override string ConvertToOrdinal(int number)
	{
		return number.ToString(_culture);
	}
}
