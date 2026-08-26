namespace Humanizer.Localisation.NumberToWords;

public interface INumberToWordsConverter
{
	string Convert(long number);

	string Convert(long number, GrammaticalGender gender);

	string ConvertToOrdinal(int number);

	string ConvertToOrdinal(int number, GrammaticalGender gender);
}
