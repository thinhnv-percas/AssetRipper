using System;
using System.Globalization;

namespace Humanizer.DateTimeHumanizeStrategy;

public class PrecisionDateTimeOffsetHumanizeStrategy : IDateTimeOffsetHumanizeStrategy
{
	private readonly double _precision;

	public PrecisionDateTimeOffsetHumanizeStrategy(double precision = 0.75)
	{
		_precision = precision;
	}

	public string Humanize(DateTimeOffset input, DateTimeOffset comparisonBase, CultureInfo culture)
	{
		return DateTimeHumanizeAlgorithms.PrecisionHumanize(input.UtcDateTime, comparisonBase.UtcDateTime, _precision, culture);
	}
}
