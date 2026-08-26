using System;
using Humanizer.Localisation.NumberToWords.Italian;

namespace Humanizer.Localisation.NumberToWords;

internal class ItalianNumberToWordsConverter : GenderedNumberToWordsConverter
{
	public override string Convert(long input, GrammaticalGender gender)
	{
		if (input > int.MaxValue || input < int.MinValue)
		{
			throw new NotImplementedException();
		}
		int num = (int)input;
		if (num < 0)
		{
			return "meno " + Convert(Math.Abs(num), gender);
		}
		return new ItalianCardinalNumberCruncher(num, gender).Convert();
	}

	public override string ConvertToOrdinal(int number, GrammaticalGender gender)
	{
		return new ItalianOrdinalNumberCruncher(number, gender).Convert();
	}
}
