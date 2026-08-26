using System;
using System.Collections.Generic;
using System.Globalization;

namespace Humanizer.Localisation.NumberToWords;

internal class SerbianNumberToWordsConverter : GenderlessNumberToWordsConverter
{
	private static readonly string[] UnitsMap = new string[20]
	{
		"nula", "jedan", "dva", "tri", "četiri", "pet", "šest", "sedam", "osam", "devet",
		"deset", "jedanaest", "dvanaest", "trinaest", "četrnaestt", "petnaest", "šestnaest", "sedemnaest", "osemnaest", "devetnaest"
	};

	private static readonly string[] TensMap = new string[10] { "nula", "deset", "dvadeset", "trideset", "četrdeset", "petdeset", "šestdeset", "sedamdeset", "osamdeset", "devetdeset" };

	private readonly CultureInfo _culture;

	public SerbianNumberToWordsConverter(CultureInfo culture)
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
			return "nula";
		}
		if (num < 0)
		{
			return $"- {Convert(-num)}";
		}
		List<string> list = new List<string>();
		int num2 = num / 1000000000;
		if (num2 > 0)
		{
			list.Add(Part("milijarda", "dve milijarde", "{0} milijarde", "{0} milijarda", num2));
			num %= 1000000000;
			if (num > 0)
			{
				list.Add(" ");
			}
		}
		int num3 = num / 1000000;
		if (num3 > 0)
		{
			list.Add(Part("milion", "dva miliona", "{0} miliona", "{0} miliona", num3));
			num %= 1000000;
			if (num > 0)
			{
				list.Add(" ");
			}
		}
		int num4 = num / 1000;
		if (num4 > 0)
		{
			list.Add(Part("hiljadu", "dve hiljade", "{0} hiljade", "{0} hiljada", num4));
			num %= 1000;
			if (num > 0)
			{
				list.Add(" ");
			}
		}
		int num5 = num / 100;
		if (num5 > 0)
		{
			list.Add(Part("sto", "dvesto", "{0}sto", "{0}sto", num5));
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
