namespace Humanizer.Localisation.GrammaticalNumber;

internal static class RussianGrammaticalNumberDetector
{
	public static RussianGrammaticalNumber Detect(int number)
	{
		if (number % 100 / 10 != 1)
		{
			switch (number % 10)
			{
			case 1:
				return RussianGrammaticalNumber.Singular;
			case 2:
			case 3:
			case 4:
				return RussianGrammaticalNumber.Paucal;
			}
		}
		return RussianGrammaticalNumber.Plural;
	}
}
