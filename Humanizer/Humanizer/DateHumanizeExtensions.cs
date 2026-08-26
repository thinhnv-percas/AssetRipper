using System;
using System.Globalization;
using Humanizer.Configuration;

namespace Humanizer;

public static class DateHumanizeExtensions
{
	public static string Humanize(this DateTime input, bool utcDate = true, DateTime? dateToCompareAgainst = null, CultureInfo culture = null)
	{
		DateTime comparisonBase = dateToCompareAgainst ?? DateTime.UtcNow;
		if (!utcDate)
		{
			comparisonBase = comparisonBase.ToLocalTime();
		}
		return Configurator.DateTimeHumanizeStrategy.Humanize(input, comparisonBase, culture);
	}

	public static string Humanize(this DateTime? input, bool utcDate = true, DateTime? dateToCompareAgainst = null, CultureInfo culture = null)
	{
		if (input.HasValue)
		{
			return input.Value.Humanize(utcDate, dateToCompareAgainst, culture);
		}
		return Configurator.GetFormatter(culture).DateHumanize_Never();
	}

	public static string Humanize(this DateTimeOffset input, DateTimeOffset? dateToCompareAgainst = null, CultureInfo culture = null)
	{
		DateTimeOffset comparisonBase = dateToCompareAgainst ?? DateTimeOffset.UtcNow;
		return Configurator.DateTimeOffsetHumanizeStrategy.Humanize(input, comparisonBase, culture);
	}

	public static string Humanize(this DateTimeOffset? input, DateTimeOffset? dateToCompareAgainst = null, CultureInfo culture = null)
	{
		if (input.HasValue)
		{
			return input.Value.Humanize(dateToCompareAgainst, culture);
		}
		return Configurator.GetFormatter(culture).DateHumanize_Never();
	}
}
