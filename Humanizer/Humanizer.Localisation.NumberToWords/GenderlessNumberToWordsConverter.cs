namespace Humanizer.Localisation.NumberToWords;

internal abstract class GenderlessNumberToWordsConverter : INumberToWordsConverter
{
	public abstract string Convert(long number);

	public string Convert(long number, GrammaticalGender gender)
	{
		return Convert(number);
	}

	public abstract string ConvertToOrdinal(int number);

	public string ConvertToOrdinal(int number, GrammaticalGender gender)
	{
		return ConvertToOrdinal(number);
	}
}
