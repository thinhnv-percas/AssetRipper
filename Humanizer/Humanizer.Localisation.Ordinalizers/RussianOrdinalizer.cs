namespace Humanizer.Localisation.Ordinalizers;

internal class RussianOrdinalizer : DefaultOrdinalizer
{
	public override string Convert(int number, string numberString)
	{
		return Convert(number, numberString, GrammaticalGender.Masculine);
	}

	public override string Convert(int number, string numberString, GrammaticalGender gender)
	{
		return gender switch
		{
			GrammaticalGender.Masculine => numberString + "-й", 
			GrammaticalGender.Feminine => numberString + "-я", 
			_ => numberString + "-е", 
		};
	}
}
