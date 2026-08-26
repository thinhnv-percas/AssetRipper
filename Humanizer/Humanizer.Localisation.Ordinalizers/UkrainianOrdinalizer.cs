namespace Humanizer.Localisation.Ordinalizers;

internal class UkrainianOrdinalizer : DefaultOrdinalizer
{
	public override string Convert(int number, string numberString)
	{
		return Convert(number, numberString, GrammaticalGender.Masculine);
	}

	public override string Convert(int number, string numberString, GrammaticalGender gender)
	{
		switch (gender)
		{
		case GrammaticalGender.Masculine:
			return numberString + "-й";
		case GrammaticalGender.Feminine:
			if (number % 10 == 3)
			{
				return numberString + "-я";
			}
			return numberString + "-а";
		case GrammaticalGender.Neuter:
			if (number % 10 == 3)
			{
				return numberString + "-є";
			}
			break;
		}
		return numberString + "-е";
	}
}
