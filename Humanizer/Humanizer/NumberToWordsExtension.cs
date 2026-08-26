using System.Globalization;
using Humanizer.Configuration;

namespace Humanizer;

public static class NumberToWordsExtension
{
	public static string ToWords(this int number, CultureInfo culture = null)
	{
		return ((long)number).ToWords(culture);
	}

	public static string ToWords(this int number, GrammaticalGender gender, CultureInfo culture = null)
	{
		return ((long)number).ToWords(gender, culture);
	}

	public static string ToWords(this long number, CultureInfo culture = null)
	{
		return Configurator.GetNumberToWordsConverter(culture).Convert(number);
	}

	public static string ToWords(this long number, GrammaticalGender gender, CultureInfo culture = null)
	{
		return Configurator.GetNumberToWordsConverter(culture).Convert(number, gender);
	}

	public static string ToOrdinalWords(this int number, CultureInfo culture = null)
	{
		return Configurator.GetNumberToWordsConverter(culture).ConvertToOrdinal(number);
	}

	public static string ToOrdinalWords(this int number, GrammaticalGender gender, CultureInfo culture = null)
	{
		return Configurator.GetNumberToWordsConverter(culture).ConvertToOrdinal(number, gender);
	}
}
