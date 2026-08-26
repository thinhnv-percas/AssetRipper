namespace Humanizer.Localisation.NumberToWords;

internal abstract class GenderedNumberToWordsConverter : INumberToWordsConverter
{
	private readonly GrammaticalGender _defaultGender;

	protected GenderedNumberToWordsConverter(GrammaticalGender defaultGender = GrammaticalGender.Masculine)
	{
		_defaultGender = defaultGender;
	}

	public string Convert(long number)
	{
		return Convert(number, _defaultGender);
	}

	public abstract string Convert(long number, GrammaticalGender gender);

	public string ConvertToOrdinal(int number)
	{
		return ConvertToOrdinal(number, _defaultGender);
	}

	public abstract string ConvertToOrdinal(int number, GrammaticalGender gender);
}
