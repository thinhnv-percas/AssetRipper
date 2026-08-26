using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Humanizer.Configuration;
using Humanizer.Localisation;
using Humanizer.Localisation.Formatters;

namespace Humanizer;

public static class TimeSpanHumanizeExtensions
{
	private const int _daysInAWeek = 7;

	private const double _daysInAYear = 365.2425;

	private const double _daysInAMonth = 30.436875;

	public static string Humanize(this TimeSpan timeSpan, int precision = 1, CultureInfo culture = null, TimeUnit maxUnit = TimeUnit.Week, TimeUnit minUnit = TimeUnit.Millisecond, string collectionSeparator = ", ")
	{
		return timeSpan.Humanize(precision, countEmptyUnits: false, culture, maxUnit, minUnit, collectionSeparator);
	}

	public static string Humanize(this TimeSpan timeSpan, int precision, bool countEmptyUnits, CultureInfo culture = null, TimeUnit maxUnit = TimeUnit.Week, TimeUnit minUnit = TimeUnit.Millisecond, string collectionSeparator = ", ")
	{
		return ConcatenateTimeSpanParts(SetPrecisionOfTimeSpan(CreateTheTimePartsWithUpperAndLowerLimits(timeSpan, culture, maxUnit, minUnit), precision, countEmptyUnits), collectionSeparator);
	}

	private static IEnumerable<string> CreateTheTimePartsWithUpperAndLowerLimits(TimeSpan timespan, CultureInfo culture, TimeUnit maxUnit, TimeUnit minUnit)
	{
		IFormatter formatter = Configurator.GetFormatter(culture);
		bool flag = false;
		IEnumerable<TimeUnit> enumTypesForTimeUnit = GetEnumTypesForTimeUnit();
		List<string> list = new List<string>();
		foreach (TimeUnit item in enumTypesForTimeUnit)
		{
			string timeUnitPart = GetTimeUnitPart(item, timespan, culture, maxUnit, minUnit, formatter);
			if ((timeUnitPart != null) | flag)
			{
				flag = true;
				list.Add(timeUnitPart);
			}
		}
		if (IsContainingOnlyNullValue(list))
		{
			list = CreateTimePartsWithNoTimeValue(formatter.TimeSpanHumanize_Zero());
		}
		return list;
	}

	private static IEnumerable<TimeUnit> GetEnumTypesForTimeUnit()
	{
		return Enumerable.Reverse<TimeUnit>((IEnumerable<TimeUnit>)Enum.GetValues(typeof(TimeUnit)));
	}

	private static string GetTimeUnitPart(TimeUnit timeUnitToGet, TimeSpan timespan, CultureInfo culture, TimeUnit maximumTimeUnit, TimeUnit minimumTimeUnit, IFormatter cultureFormatter)
	{
		if (timeUnitToGet <= maximumTimeUnit && timeUnitToGet >= minimumTimeUnit)
		{
			bool isTimeUnitToGetTheMaximumTimeUnit = timeUnitToGet == maximumTimeUnit;
			int timeUnitNumericalValue = GetTimeUnitNumericalValue(timeUnitToGet, timespan, isTimeUnitToGetTheMaximumTimeUnit);
			return BuildFormatTimePart(cultureFormatter, timeUnitToGet, timeUnitNumericalValue);
		}
		return null;
	}

	private static int GetTimeUnitNumericalValue(TimeUnit timeUnitToGet, TimeSpan timespan, bool isTimeUnitToGetTheMaximumTimeUnit)
	{
		return timeUnitToGet switch
		{
			TimeUnit.Millisecond => GetNormalCaseTimeAsInteger(timespan.Milliseconds, timespan.TotalMilliseconds, isTimeUnitToGetTheMaximumTimeUnit), 
			TimeUnit.Second => GetNormalCaseTimeAsInteger(timespan.Seconds, timespan.TotalSeconds, isTimeUnitToGetTheMaximumTimeUnit), 
			TimeUnit.Minute => GetNormalCaseTimeAsInteger(timespan.Minutes, timespan.TotalMinutes, isTimeUnitToGetTheMaximumTimeUnit), 
			TimeUnit.Hour => GetNormalCaseTimeAsInteger(timespan.Hours, timespan.TotalHours, isTimeUnitToGetTheMaximumTimeUnit), 
			TimeUnit.Day => GetSpecialCaseDaysAsInteger(timespan, isTimeUnitToGetTheMaximumTimeUnit), 
			TimeUnit.Week => GetSpecialCaseWeeksAsInteger(timespan, isTimeUnitToGetTheMaximumTimeUnit), 
			TimeUnit.Month => GetSpecialCaseMonthAsInteger(timespan, isTimeUnitToGetTheMaximumTimeUnit), 
			TimeUnit.Year => GetSpecialCaseYearAsInteger(timespan), 
			_ => 0, 
		};
	}

	private static int GetSpecialCaseMonthAsInteger(TimeSpan timespan, bool isTimeUnitToGetTheMaximumTimeUnit)
	{
		if (isTimeUnitToGetTheMaximumTimeUnit)
		{
			return (int)((double)timespan.Days / 30.436875);
		}
		return (int)((double)timespan.Days % 365.2425 / 30.436875);
	}

	private static int GetSpecialCaseYearAsInteger(TimeSpan timespan)
	{
		return (int)((double)timespan.Days / 365.2425);
	}

	private static int GetSpecialCaseWeeksAsInteger(TimeSpan timespan, bool isTimeUnitToGetTheMaximumTimeUnit)
	{
		if (isTimeUnitToGetTheMaximumTimeUnit || (double)timespan.Days < 30.436875)
		{
			return timespan.Days / 7;
		}
		return 0;
	}

	private static int GetSpecialCaseDaysAsInteger(TimeSpan timespan, bool isTimeUnitToGetTheMaximumTimeUnit)
	{
		if (isTimeUnitToGetTheMaximumTimeUnit)
		{
			return timespan.Days;
		}
		if ((double)timespan.Days < 30.436875)
		{
			return timespan.Days % 7;
		}
		return (int)((double)timespan.Days % 30.436875);
	}

	private static int GetNormalCaseTimeAsInteger(int timeNumberOfUnits, double totalTimeNumberOfUnits, bool isTimeUnitToGetTheMaximumTimeUnit)
	{
		if (isTimeUnitToGetTheMaximumTimeUnit)
		{
			try
			{
				return (int)totalTimeNumberOfUnits;
			}
			catch
			{
				return 0;
			}
		}
		return timeNumberOfUnits;
	}

	private static string BuildFormatTimePart(IFormatter cultureFormatter, TimeUnit timeUnitType, int amountOfTimeUnits)
	{
		if (amountOfTimeUnits == 0)
		{
			return null;
		}
		return cultureFormatter.TimeSpanHumanize(timeUnitType, Math.Abs(amountOfTimeUnits));
	}

	private static List<string> CreateTimePartsWithNoTimeValue(string noTimeValue)
	{
		return new List<string> { noTimeValue };
	}

	private static bool IsContainingOnlyNullValue(IEnumerable<string> timeParts)
	{
		return Enumerable.Count<string>(timeParts, (Func<string, bool>)((string x) => x != null)) == 0;
	}

	private static IEnumerable<string> SetPrecisionOfTimeSpan(IEnumerable<string> timeParts, int precision, bool countEmptyUnits)
	{
		if (!countEmptyUnits)
		{
			timeParts = Enumerable.Where<string>(timeParts, (Func<string, bool>)((string x) => x != null));
		}
		timeParts = Enumerable.Take<string>(timeParts, precision);
		if (countEmptyUnits)
		{
			timeParts = Enumerable.Where<string>(timeParts, (Func<string, bool>)((string x) => x != null));
		}
		return timeParts;
	}

	private static string ConcatenateTimeSpanParts(IEnumerable<string> timeSpanParts, string collectionSeparator)
	{
		if (collectionSeparator == null)
		{
			return Configurator.CollectionFormatter.Humanize(timeSpanParts);
		}
		return string.Join(collectionSeparator, timeSpanParts);
	}
}
