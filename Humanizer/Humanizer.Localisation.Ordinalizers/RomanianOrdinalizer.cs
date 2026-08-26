namespace Humanizer.Localisation.Ordinalizers;

internal class RomanianOrdinalizer : DefaultOrdinalizer
{
	public override string Convert(int number, string numberString)
	{
		return Convert(number, numberString, GrammaticalGender.Masculine);
	}

	public override string Convert(int number, string numberString, GrammaticalGender gender)
	{
		switch (number)
		{
		case 0:
			return "0";
		case 1:
			if (gender == GrammaticalGender.Feminine)
			{
				return "prima";
			}
			return "primul";
		default:
			if (gender == GrammaticalGender.Feminine)
			{
				return $"a {numberString}-a";
			}
			return $"al {numberString}-lea";
		}
	}
}
