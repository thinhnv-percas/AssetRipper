using System;
using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords;

internal abstract class FrenchNumberToWordsConverterBase : GenderedNumberToWordsConverter
{
	private static readonly string[] UnitsMap = new string[20]
	{
		"zéro", "un", "deux", "trois", "quatre", "cinq", "six", "sept", "huit", "neuf",
		"dix", "onze", "douze", "treize", "quatorze", "quinze", "seize", "dix-sept", "dix-huit", "dix-neuf"
	};

	private static readonly string[] TensMap = new string[10] { "zéro", "dix", "vingt", "trente", "quarante", "cinquante", "soixante", "septante", "octante", "nonante" };

	public override string Convert(long input, GrammaticalGender gender)
	{
		if (input > int.MaxValue || input < int.MinValue)
		{
			throw new NotImplementedException();
		}
		int number = (int)input;
		if (number == 0)
		{
			return UnitsMap[0];
		}
		List<string> list = new List<string>();
		if (number < 0)
		{
			list.Add("moins");
			number = -number;
		}
		CollectParts(list, ref number, 1000000000, "milliard");
		CollectParts(list, ref number, 1000000, "million");
		CollectThousands(list, ref number, 1000, "mille");
		CollectPartsUnderAThousand(list, number, gender, pluralize: true);
		return string.Join(" ", list);
	}

	public override string ConvertToOrdinal(int number, GrammaticalGender gender)
	{
		if (number == 1)
		{
			if (gender != GrammaticalGender.Feminine)
			{
				return "premier";
			}
			return "première";
		}
		string text = Convert(number);
		if (text.EndsWith("s") && !text.EndsWith("trois"))
		{
			text = text.TrimEnd(new char[1] { 's' });
		}
		else if (text.EndsWith("cinq"))
		{
			text += "u";
		}
		else if (text.EndsWith("neuf"))
		{
			text = text.TrimEnd(new char[1] { 'f' }) + "v";
		}
		if (text.StartsWith("un "))
		{
			text = text.Remove(0, 3);
		}
		if (number == 0)
		{
			text += "t";
		}
		text = text.TrimEnd(new char[1] { 'e' });
		return text + "ième";
	}

	protected static string GetUnits(int number, GrammaticalGender gender)
	{
		if (number == 1 && gender == GrammaticalGender.Feminine)
		{
			return "une";
		}
		return UnitsMap[number];
	}

	private static void CollectHundreds(ICollection<string> parts, ref int number, int d, string form, bool pluralize)
	{
		if (number < d)
		{
			return;
		}
		int num = number / d;
		if (num == 1)
		{
			parts.Add(form);
		}
		else
		{
			parts.Add(GetUnits(num, GrammaticalGender.Masculine));
			if ((number % d == 0) & pluralize)
			{
				parts.Add(form + "s");
			}
			else
			{
				parts.Add(form);
			}
		}
		number %= d;
	}

	private void CollectParts(ICollection<string> parts, ref int number, int d, string form)
	{
		if (number >= d)
		{
			int num = number / d;
			CollectPartsUnderAThousand(parts, num, GrammaticalGender.Masculine, pluralize: true);
			if (num == 1)
			{
				parts.Add(form);
			}
			else
			{
				parts.Add(form + "s");
			}
			number %= d;
		}
	}

	private void CollectPartsUnderAThousand(ICollection<string> parts, int number, GrammaticalGender gender, bool pluralize)
	{
		CollectHundreds(parts, ref number, 100, "cent", pluralize);
		if (number > 0)
		{
			CollectPartsUnderAHundred(parts, ref number, gender, pluralize);
		}
	}

	private void CollectThousands(ICollection<string> parts, ref int number, int d, string form)
	{
		if (number >= d)
		{
			int num = number / d;
			if (num > 1)
			{
				CollectPartsUnderAThousand(parts, num, GrammaticalGender.Masculine, pluralize: false);
			}
			parts.Add(form);
			number %= d;
		}
	}

	protected virtual void CollectPartsUnderAHundred(ICollection<string> parts, ref int number, GrammaticalGender gender, bool pluralize)
	{
		if (number < 20)
		{
			parts.Add(GetUnits(number, gender));
			return;
		}
		int num = number % 10;
		string tens = GetTens(number / 10);
		switch (num)
		{
		case 0:
			parts.Add(tens);
			break;
		case 1:
			parts.Add(tens);
			parts.Add("et");
			parts.Add(GetUnits(1, gender));
			break;
		default:
			parts.Add(string.Format("{0}-{1}", new object[2]
			{
				tens,
				GetUnits(num, gender)
			}));
			break;
		}
	}

	protected virtual string GetTens(int tens)
	{
		return TensMap[tens];
	}
}
