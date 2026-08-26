namespace Humanizer.Localisation.NumberToWords.Italian;

internal class ItalianOrdinalNumberCruncher
{
	protected readonly int _fullNumber;

	protected readonly GrammaticalGender _gender;

	private readonly string _genderSuffix;

	protected static string[] _unitsUnder10NumberToText = new string[10]
	{
		string.Empty,
		"prim",
		"second",
		"terz",
		"quart",
		"quint",
		"sest",
		"settim",
		"ottav",
		"non"
	};

	protected static int _lengthOf10AsCardinal = "dieci".Length;

	public ItalianOrdinalNumberCruncher(int number, GrammaticalGender gender)
	{
		_fullNumber = number;
		_gender = gender;
		_genderSuffix = ((gender == GrammaticalGender.Feminine) ? "a" : "o");
	}

	public string Convert()
	{
		if (_fullNumber == 0)
		{
			return "zero";
		}
		if (_fullNumber <= 9)
		{
			return _unitsUnder10NumberToText[_fullNumber] + _genderSuffix;
		}
		string text = new ItalianCardinalNumberCruncher(_fullNumber, _gender).Convert();
		if (_fullNumber % 100 == 10)
		{
			return text.Remove(text.Length - _lengthOf10AsCardinal) + "decim" + _genderSuffix;
		}
		text = text.Remove(text.Length - 1);
		switch (_fullNumber % 10)
		{
		case 3:
			text += "e";
			break;
		case 6:
			text += "i";
			break;
		}
		int num = _fullNumber % 1000;
		int num2 = _fullNumber % 1000000;
		if (_fullNumber % 1000000000 == 0)
		{
			text = text.Replace(" miliard", "miliard");
			if (_fullNumber == 1000000000)
			{
				text = text.Replace("un", string.Empty);
			}
		}
		else if (num2 == 0)
		{
			text = text.Replace(" milion", "milion");
			if (_fullNumber == 1000000)
			{
				text = text.Replace("un", string.Empty);
			}
		}
		else if (num == 0 && _fullNumber > 1000)
		{
			text += "l";
		}
		return text + "esim" + _genderSuffix;
	}
}
