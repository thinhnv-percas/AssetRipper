using System.Globalization;

namespace Humanizer.Localisation.NumberToWords;

internal class DefaultNumberToWordsConverter : GenderlessNumberToWordsConverter
{
	private readonly CultureInfo _culture;

	public DefaultNumberToWordsConverter(CultureInfo culture)
	{
		_culture = culture;
	}

	public override string Convert(long number)
	{
		return number.ToString(_culture);
	}

	public override string ConvertToOrdinal(int number)
	{
		return number.ToString(_culture);
	}
}
