using System;
using System.Collections.Generic;
using System.Globalization;

namespace Humanizer.Localisation.NumberToWords;

internal class SerbianCyrlNumberToWordsConverter : GenderlessNumberToWordsConverter
{
	private static readonly string[] UnitsMap = new string[20]
	{
		"нула", "један", "два", "три", "четири", "пет", "шест", "седам", "осам", "девет",
		"десет", "једанест", "дванаест", "тринаест", "четрнаест", "петнаест", "шеснаест", "седамнаест", "осамнаест", "деветнаест"
	};

	private static readonly string[] TensMap = new string[10] { "нула", "десет", "двадесет", "тридесет", "четрдесет", "петдесет", "шестдесет", "седамдесет", "осамдесет", "деветдесет" };

	private readonly CultureInfo _culture;

	public SerbianCyrlNumberToWordsConverter(CultureInfo culture)
	{
		_culture = culture;
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
			return "нула";
		}
		if (num < 0)
		{
			return $"- {Convert(-num)}";
		}
		List<string> list = new List<string>();
		int num2 = num / 1000000000;
		if (num2 > 0)
		{
			list.Add(Part("милијарда", "две милијарде", "{0} милијарде", "{0} милијарда", num2));
			num %= 1000000000;
			if (num > 0)
			{
				list.Add(" ");
			}
		}
		int num3 = num / 1000000;
		if (num3 > 0)
		{
			list.Add(Part("милион", "два милиона", "{0} милиона", "{0} милиона", num3));
			num %= 1000000;
			if (num > 0)
			{
				list.Add(" ");
			}
		}
		int num4 = num / 1000;
		if (num4 > 0)
		{
			list.Add(Part("хиљаду", "две хиљаде", "{0} хиљаде", "{0} хиљада", num4));
			num %= 1000;
			if (num > 0)
			{
				list.Add(" ");
			}
		}
		int num5 = num / 100;
		if (num5 > 0)
		{
			list.Add(Part("сто", "двесто", "{0}сто", "{0}сто", num5));
			num %= 100;
			if (num > 0)
			{
				list.Add(" ");
			}
		}
		if (num > 0)
		{
			if (num < 20)
			{
				list.Add(UnitsMap[num]);
			}
			else
			{
				list.Add(TensMap[num / 10]);
				int num6 = num % 10;
				if (num6 > 0)
				{
					list.Add($" {UnitsMap[num6]}");
				}
			}
		}
		return string.Join("", list);
	}

	public override string ConvertToOrdinal(int number)
	{
		return number.ToString(_culture);
	}

	private string Part(string singular, string dual, string trialQuadral, string plural, int number)
	{
		switch (number)
		{
		case 1:
			return singular;
		case 2:
			return dual;
		case 3:
		case 4:
			return string.Format(trialQuadral, new object[1] { Convert(number) });
		default:
			return string.Format(plural, new object[1] { Convert(number) });
		}
	}
}
