using System;
using Humanizer.Localisation.NumberToWords.Romanian;

namespace Humanizer.Localisation.NumberToWords;

internal class RomanianNumberToWordsConverter : GenderedNumberToWordsConverter
{
	public override string Convert(long number, GrammaticalGender gender)
	{
		if (number > int.MaxValue || number < int.MinValue)
		{
			throw new NotImplementedException();
		}
		return new RomanianCardinalNumberConverter().Convert((int)number, gender);
	}

	public override string ConvertToOrdinal(int number, GrammaticalGender gender)
	{
		return new RomanianOrdinalNumberConverter().Convert(number, gender);
	}
}
