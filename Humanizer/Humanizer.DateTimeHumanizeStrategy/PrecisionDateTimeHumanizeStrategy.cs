using System;
using System.Globalization;

namespace Humanizer.DateTimeHumanizeStrategy;

public class PrecisionDateTimeHumanizeStrategy : IDateTimeHumanizeStrategy
{
	private readonly double _precision;

	public PrecisionDateTimeHumanizeStrategy(double precision = 0.75)
	{
		_precision = precision;
	}

	public string Humanize(DateTime input, DateTime comparisonBase, CultureInfo culture)
	{
		return DateTimeHumanizeAlgorithms.PrecisionHumanize(input, comparisonBase, _precision, culture);
	}
}
