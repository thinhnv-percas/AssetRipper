using System;
using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords.Romanian;

internal class RomanianCardinalNumberConverter
{
	private enum ThreeDigitSets
	{
		Units,
		Thousands,
		Millions,
		Billions,
		More
	}

	private readonly string[] _units = new string[10]
	{
		string.Empty,
		"unu|una",
		"doi|două",
		"trei",
		"patru",
		"cinci",
		"șase",
		"șapte",
		"opt",
		"nouă"
	};

	private readonly string[] _teensUnder20NumberToText = new string[10] { "zece", "unsprezece", "doisprezece|douăsprezece", "treisprezece", "paisprezece", "cincisprezece", "șaisprezece", "șaptesprezece", "optsprezece", "nouăsprezece" };

	private readonly string[] _tensOver20NumberToText = new string[10]
	{
		string.Empty,
		string.Empty,
		"douăzeci",
		"treizeci",
		"patruzeci",
		"cincizeci",
		"șaizeci",
		"șaptezeci",
		"optzeci",
		"nouăzeci"
	};

	private readonly string _feminineSingular = "o";

	private readonly string _masculineSingular = "un";

	private readonly string _joinGroups = "și";

	private readonly string _joinAbove20 = "de";

	private readonly string _minusSign = "minus";

	public string Convert(int number, GrammaticalGender gender)
	{
		if (number == 0)
		{
			return "zero";
		}
		string text = string.Empty;
		bool flag = false;
		if (number < 0)
		{
			flag = true;
			number = -number;
		}
		List<int> list = SplitEveryThreeDigits(number);
		for (int i = 0; i < list.Count; i++)
		{
			ThreeDigitSets currentSet = (ThreeDigitSets)Enum.ToObject(typeof(ThreeDigitSets), (object)i);
			text = GetNextPartConverter(currentSet)(list[i], gender).Trim() + " " + text.Trim();
		}
		if (flag)
		{
			text = _minusSign + " " + text;
		}
		return text.TrimEnd(new char[0]).Replace("  ", " ");
	}

	private List<int> SplitEveryThreeDigits(int number)
	{
		List<int> list = new List<int>();
		for (int num = number; num > 0; num /= 1000)
		{
			int item = num % 1000;
			list.Add(item);
		}
		return list;
	}

	private Func<int, GrammaticalGender, string> GetNextPartConverter(ThreeDigitSets currentSet)
	{
		return currentSet switch
		{
			ThreeDigitSets.Units => UnitsConverter, 
			ThreeDigitSets.Thousands => ThousandsConverter, 
			ThreeDigitSets.Millions => MillionsConverter, 
			ThreeDigitSets.Billions => BillionsConverter, 
			ThreeDigitSets.More => null, 
			_ => throw new ArgumentOutOfRangeException("Unknow ThreeDigitSet: " + currentSet), 
		};
	}

	private string ThreeDigitSetConverter(int number, GrammaticalGender gender, bool thisIsLastSet = false)
	{
		if (number == 0)
		{
			return string.Empty;
		}
		int num = number % 100;
		int hundreds = number / 100;
		int num2 = num % 10;
		int num3 = num / 10;
		string empty = string.Empty;
		empty += HundredsToText(hundreds);
		empty = empty + ((num3 >= 2) ? " " : string.Empty) + _tensOver20NumberToText[num3];
		if (num <= 9)
		{
			return empty + " " + getPartByGender(_units[num], gender);
		}
		if (num <= 19)
		{
			return empty + " " + getPartByGender(_teensUnder20NumberToText[num - 10], gender);
		}
		string text = ((num2 == 0) ? string.Empty : (" " + _joinGroups + " " + getPartByGender(_units[num2], gender)));
		return empty + text;
	}

	private string getPartByGender(string multiGenderPart, GrammaticalGender gender)
	{
		if (multiGenderPart.Contains("|"))
		{
			string[] array = multiGenderPart.Split(new char[1] { '|' });
			if (gender == GrammaticalGender.Feminine)
			{
				return array[1];
			}
			return array[0];
		}
		return multiGenderPart;
	}

	private bool IsAbove20(int number)
	{
		return number >= 20;
	}

	private string HundredsToText(int hundreds)
	{
		return hundreds switch
		{
			0 => string.Empty, 
			1 => _feminineSingular + " sută", 
			_ => getPartByGender(_units[hundreds], GrammaticalGender.Feminine) + " sute", 
		};
	}

	private string UnitsConverter(int number, GrammaticalGender gender)
	{
		return ThreeDigitSetConverter(number, gender, thisIsLastSet: true);
	}

	private string ThousandsConverter(int number, GrammaticalGender gender)
	{
		return number switch
		{
			0 => string.Empty, 
			1 => _feminineSingular + " mie", 
			_ => ThreeDigitSetConverter(number, GrammaticalGender.Feminine) + (IsAbove20(number) ? (" " + _joinAbove20) : string.Empty) + " mii", 
		};
	}

	private string MillionsConverter(int number, GrammaticalGender gender)
	{
		return number switch
		{
			0 => string.Empty, 
			1 => _masculineSingular + " milion", 
			_ => ThreeDigitSetConverter(number, GrammaticalGender.Feminine, thisIsLastSet: true) + (IsAbove20(number) ? (" " + _joinAbove20) : string.Empty) + " milioane", 
		};
	}

	private string BillionsConverter(int number, GrammaticalGender gender)
	{
		if (number == 1)
		{
			return _masculineSingular + " miliard";
		}
		return ThreeDigitSetConverter(number, GrammaticalGender.Feminine) + (IsAbove20(number) ? (" " + _joinAbove20) : string.Empty) + " miliarde";
	}
}
