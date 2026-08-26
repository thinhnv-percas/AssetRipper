using System;
using System.Globalization;
using Humanizer.Configuration;
using Humanizer.Localisation;
using Humanizer.Localisation.Formatters;

namespace Humanizer.DateTimeHumanizeStrategy;

internal static class DateTimeHumanizeAlgorithms
{
	public static string PrecisionHumanize(DateTime input, DateTime comparisonBase, double precision, CultureInfo culture)
	{
		TimeSpan timeSpan = new TimeSpan(Math.Abs(comparisonBase.Ticks - input.Ticks));
		Tense timeUnitTense = ((!(input > comparisonBase)) ? Tense.Past : Tense.Future);
		int num = timeSpan.Seconds;
		int num2 = timeSpan.Minutes;
		int num3 = timeSpan.Hours;
		int num4 = timeSpan.Days;
		int num5 = 0;
		int num6 = 0;
		if ((double)timeSpan.Milliseconds >= 999.0 * precision)
		{
			num++;
		}
		if ((double)num >= 59.0 * precision)
		{
			num2++;
		}
		if ((double)num2 >= 59.0 * precision)
		{
			num3++;
		}
		if ((double)num3 >= 23.0 * precision)
		{
			num4++;
		}
		if (((double)num4 >= 30.0 * precision) & (num4 <= 31))
		{
			num6 = 1;
		}
		if (num4 > 31 && (double)num4 < 365.0 * precision)
		{
			int num7 = Convert.ToInt32(Math.Floor((double)num4 / 30.0));
			int num8 = Convert.ToInt32(Math.Ceiling((double)num4 / 30.0));
			num6 = (((double)num4 >= 30.0 * ((double)num7 + precision)) ? num8 : (num8 - 1));
		}
		if ((double)num4 >= 365.0 * precision && num4 <= 366)
		{
			num5 = 1;
		}
		if (num4 > 365)
		{
			int num9 = Convert.ToInt32(Math.Floor((double)num4 / 365.0));
			int num10 = Convert.ToInt32(Math.Ceiling((double)num4 / 365.0));
			num5 = (((double)num4 >= 365.0 * ((double)num9 + precision)) ? num10 : (num10 - 1));
		}
		IFormatter formatter = Configurator.GetFormatter(culture);
		if (num5 > 0)
		{
			return formatter.DateHumanize(TimeUnit.Year, timeUnitTense, num5);
		}
		if (num6 > 0)
		{
			return formatter.DateHumanize(TimeUnit.Month, timeUnitTense, num6);
		}
		if (num4 > 0)
		{
			return formatter.DateHumanize(TimeUnit.Day, timeUnitTense, num4);
		}
		if (num3 > 0)
		{
			return formatter.DateHumanize(TimeUnit.Hour, timeUnitTense, num3);
		}
		if (num2 > 0)
		{
			return formatter.DateHumanize(TimeUnit.Minute, timeUnitTense, num2);
		}
		if (num > 0)
		{
			return formatter.DateHumanize(TimeUnit.Second, timeUnitTense, num);
		}
		return formatter.DateHumanize(TimeUnit.Millisecond, timeUnitTense, 0);
	}

	public static string DefaultHumanize(DateTime input, DateTime comparisonBase, CultureInfo culture)
	{
		Tense tense = ((!(input > comparisonBase)) ? Tense.Past : Tense.Future);
		TimeSpan timeSpan = new TimeSpan(Math.Abs(comparisonBase.Ticks - input.Ticks));
		IFormatter formatter = Configurator.GetFormatter(culture);
		if (timeSpan.TotalMilliseconds < 500.0)
		{
			return formatter.DateHumanize(TimeUnit.Millisecond, tense, 0);
		}
		if (timeSpan.TotalSeconds < 60.0)
		{
			return formatter.DateHumanize(TimeUnit.Second, tense, timeSpan.Seconds);
		}
		if (timeSpan.TotalSeconds < 120.0)
		{
			return formatter.DateHumanize(TimeUnit.Minute, tense, 1);
		}
		if (timeSpan.TotalMinutes < 60.0)
		{
			return formatter.DateHumanize(TimeUnit.Minute, tense, timeSpan.Minutes);
		}
		if (timeSpan.TotalMinutes < 90.0)
		{
			return formatter.DateHumanize(TimeUnit.Hour, tense, 1);
		}
		if (timeSpan.TotalHours < 24.0)
		{
			return formatter.DateHumanize(TimeUnit.Hour, tense, timeSpan.Hours);
		}
		if (timeSpan.TotalHours < 48.0)
		{
			int unit = Math.Abs((input.Date - comparisonBase.Date).Days);
			return formatter.DateHumanize(TimeUnit.Day, tense, unit);
		}
		if (timeSpan.TotalDays < 28.0)
		{
			return formatter.DateHumanize(TimeUnit.Day, tense, timeSpan.Days);
		}
		if (timeSpan.TotalDays >= 28.0 && timeSpan.TotalDays < 30.0)
		{
			if (comparisonBase.Date.AddMonths((tense == Tense.Future) ? 1 : (-1)) == input.Date)
			{
				return formatter.DateHumanize(TimeUnit.Month, tense, 1);
			}
			return formatter.DateHumanize(TimeUnit.Day, tense, timeSpan.Days);
		}
		if (timeSpan.TotalDays < 345.0)
		{
			int unit2 = Convert.ToInt32(Math.Floor(timeSpan.TotalDays / 29.5));
			return formatter.DateHumanize(TimeUnit.Month, tense, unit2);
		}
		int num = Convert.ToInt32(Math.Floor(timeSpan.TotalDays / 365.0));
		if (num == 0)
		{
			num = 1;
		}
		return formatter.DateHumanize(TimeUnit.Year, tense, num);
	}
}
