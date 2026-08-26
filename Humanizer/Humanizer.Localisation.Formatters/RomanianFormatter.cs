using System;
using System.Globalization;

namespace Humanizer.Localisation.Formatters;

internal class RomanianFormatter : DefaultFormatter
{
	private const int PrepositionIndicatingDecimals = 2;

	private const int MaxNumeralWithNoPreposition = 19;

	private const int MinNumeralWithNoPreposition = 1;

	private const string UnitPreposition = " de";

	private const string RomanianCultureCode = "ro";

	private static readonly double Divider = Math.Pow(10.0, 2.0);

	private readonly CultureInfo _romanianCulture;

	public RomanianFormatter()
		: base("ro")
	{
		_romanianCulture = new CultureInfo("ro");
	}

	protected override string Format(string resourceKey, int number)
	{
		string resource = Resources.GetResource(GetResourceKey(resourceKey, number), _romanianCulture);
		string text = (ShouldUsePreposition(number) ? " de" : string.Empty);
		return resource.FormatWith(number, text);
	}

	private static bool ShouldUsePreposition(int number)
	{
		double num = Math.Abs((double)number % Divider);
		if (!(num < 1.0))
		{
			return num > 19.0;
		}
		return true;
	}
}
