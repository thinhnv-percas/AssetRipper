using System;
using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords.Italian;

internal class ItalianCardinalNumberCruncher
{
	protected enum ThreeDigitSets
	{
		Units,
		Thousands,
		Millions,
		Billions,
		More
	}

	protected readonly int _fullNumber;

	protected readonly List<int> _threeDigitParts;

	protected readonly GrammaticalGender _gender;

	protected ThreeDigitSets _nextSet;

	protected static string[] _unitsNumberToText = new string[10]
	{
		string.Empty,
		"uno",
		"due",
		"tre",
		"quattro",
		"cinque",
		"sei",
		"sette",
		"otto",
		"nove"
	};

	protected static string[] _tensOver20NumberToText = new string[10]
	{
		string.Empty,
		string.Empty,
		"venti",
		"trenta",
		"quaranta",
		"cinquanta",
		"sessanta",
		"settanta",
		"ottanta",
		"novanta"
	};

	protected static string[] _teensUnder20NumberToText = new string[10] { "dieci", "undici", "dodici", "tredici", "quattordici", "quindici", "sedici", "diciassette", "diciotto", "diciannove" };

	protected static string[] _hundredNumberToText = new string[10]
	{
		string.Empty,
		"cento",
		"duecento",
		"trecento",
		"quattrocento",
		"cinquecento",
		"seicento",
		"settecento",
		"ottocento",
		"novecento"
	};

	public ItalianCardinalNumberCruncher(int number, GrammaticalGender gender)
	{
		_fullNumber = number;
		_threeDigitParts = SplitEveryThreeDigits(number);
		_gender = gender;
		_nextSet = ThreeDigitSets.Units;
	}

	public string Convert()
	{
		if (_fullNumber == 0)
		{
			return "zero";
		}
		string text = string.Empty;
		foreach (int threeDigitPart in _threeDigitParts)
		{
			text = GetNextPartConverter()(threeDigitPart) + text;
		}
		return text.TrimEnd(new char[0]);
	}

	protected static List<int> SplitEveryThreeDigits(int number)
	{
		List<int> list = new List<int>();
		for (int num = number; num > 0; num /= 1000)
		{
			int item = num % 1000;
			list.Add(item);
		}
		return list;
	}

	public Func<int, string> GetNextPartConverter()
	{
		Func<int, string> result;
		switch (_nextSet)
		{
		case ThreeDigitSets.Units:
			result = UnitsConverter;
			_nextSet = ThreeDigitSets.Thousands;
			break;
		case ThreeDigitSets.Thousands:
			result = ThousandsConverter;
			_nextSet = ThreeDigitSets.Millions;
			break;
		case ThreeDigitSets.Millions:
			result = MillionsConverter;
			_nextSet = ThreeDigitSets.Billions;
			break;
		case ThreeDigitSets.Billions:
			result = BillionsConverter;
			_nextSet = ThreeDigitSets.More;
			break;
		case ThreeDigitSets.More:
			result = null;
			break;
		default:
			throw new ArgumentOutOfRangeException("Unknow ThreeDigitSet: " + _nextSet);
		}
		return result;
	}

	protected static string ThreeDigitSetConverter(int number, bool thisIsLastSet = false)
	{
		if (number == 0)
		{
			return string.Empty;
		}
		int num = number % 100;
		int num2 = number / 100;
		int num3 = num % 10;
		int num4 = num / 10;
		string empty = string.Empty;
		empty += _hundredNumberToText[num2];
		empty += _tensOver20NumberToText[num4];
		if (num <= 9)
		{
			return empty + _unitsNumberToText[num];
		}
		if (num <= 19)
		{
			return empty + _teensUnder20NumberToText[num - 10];
		}
		if (num3 == 1 || num3 == 8)
		{
			empty = empty.Remove(empty.Length - 1);
		}
		string text = ((thisIsLastSet && num3 == 3) ? "tré" : _unitsNumberToText[num3]);
		return empty + text;
	}

	protected string UnitsConverter(int number)
	{
		if (_gender == GrammaticalGender.Feminine && _fullNumber == 1)
		{
			return "una";
		}
		return ThreeDigitSetConverter(number, thisIsLastSet: true);
	}

	protected static string ThousandsConverter(int number)
	{
		return number switch
		{
			0 => string.Empty, 
			1 => "mille", 
			_ => ThreeDigitSetConverter(number) + "mila", 
		};
	}

	protected static string MillionsConverter(int number)
	{
		return number switch
		{
			0 => string.Empty, 
			1 => "un milione ", 
			_ => ThreeDigitSetConverter(number, thisIsLastSet: true) + " milioni ", 
		};
	}

	protected static string BillionsConverter(int number)
	{
		if (number == 1)
		{
			return "un miliardo ";
		}
		return ThreeDigitSetConverter(number) + " miliardi ";
	}
}
