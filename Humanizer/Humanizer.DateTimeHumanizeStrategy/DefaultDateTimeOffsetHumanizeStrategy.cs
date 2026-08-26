using System;
using System.Globalization;

namespace Humanizer.DateTimeHumanizeStrategy;

public class DefaultDateTimeOffsetHumanizeStrategy : IDateTimeOffsetHumanizeStrategy
{
	public string Humanize(DateTimeOffset input, DateTimeOffset comparisonBase, CultureInfo culture)
	{
		return DateTimeHumanizeAlgorithms.DefaultHumanize(input.UtcDateTime, comparisonBase.UtcDateTime, culture);
	}
}
