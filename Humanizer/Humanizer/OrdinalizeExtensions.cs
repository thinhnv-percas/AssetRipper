using System.Globalization;
using Humanizer.Configuration;

namespace Humanizer;

public static class OrdinalizeExtensions
{
	public static string Ordinalize(this string numberString)
	{
		return Configurator.Ordinalizer.Convert(int.Parse(numberString), numberString);
	}

	public static string Ordinalize(this string numberString, GrammaticalGender gender)
	{
		return Configurator.Ordinalizer.Convert(int.Parse(numberString), numberString, gender);
	}

	public static string Ordinalize(this int number)
	{
		return Configurator.Ordinalizer.Convert(number, number.ToString(CultureInfo.InvariantCulture));
	}

	public static string Ordinalize(this int number, GrammaticalGender gender)
	{
		return Configurator.Ordinalizer.Convert(number, number.ToString(CultureInfo.InvariantCulture), gender);
	}
}
