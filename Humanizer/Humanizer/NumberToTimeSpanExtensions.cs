using System;

namespace Humanizer;

public static class NumberToTimeSpanExtensions
{
	public static TimeSpan Milliseconds(this byte ms)
	{
		return ((double)(int)ms).Milliseconds();
	}

	public static TimeSpan Milliseconds(this sbyte ms)
	{
		return ((double)ms).Milliseconds();
	}

	public static TimeSpan Milliseconds(this short ms)
	{
		return ((double)ms).Milliseconds();
	}

	public static TimeSpan Milliseconds(this ushort ms)
	{
		return ((double)(int)ms).Milliseconds();
	}

	public static TimeSpan Milliseconds(this int ms)
	{
		return ((double)ms).Milliseconds();
	}

	public static TimeSpan Milliseconds(this uint ms)
	{
		return ((double)ms).Milliseconds();
	}

	public static TimeSpan Milliseconds(this long ms)
	{
		return ((double)ms).Milliseconds();
	}

	public static TimeSpan Milliseconds(this ulong ms)
	{
		return ((double)ms).Milliseconds();
	}

	public static TimeSpan Milliseconds(this double ms)
	{
		return TimeSpan.FromMilliseconds(ms);
	}

	public static TimeSpan Seconds(this byte seconds)
	{
		return ((double)(int)seconds).Seconds();
	}

	public static TimeSpan Seconds(this sbyte seconds)
	{
		return ((double)seconds).Seconds();
	}

	public static TimeSpan Seconds(this short seconds)
	{
		return ((double)seconds).Seconds();
	}

	public static TimeSpan Seconds(this ushort seconds)
	{
		return ((double)(int)seconds).Seconds();
	}

	public static TimeSpan Seconds(this int seconds)
	{
		return ((double)seconds).Seconds();
	}

	public static TimeSpan Seconds(this uint seconds)
	{
		return ((double)seconds).Seconds();
	}

	public static TimeSpan Seconds(this long seconds)
	{
		return ((double)seconds).Seconds();
	}

	public static TimeSpan Seconds(this ulong seconds)
	{
		return ((double)seconds).Seconds();
	}

	public static TimeSpan Seconds(this double seconds)
	{
		return TimeSpan.FromSeconds(seconds);
	}

	public static TimeSpan Minutes(this byte minutes)
	{
		return ((double)(int)minutes).Minutes();
	}

	public static TimeSpan Minutes(this sbyte minutes)
	{
		return ((double)minutes).Minutes();
	}

	public static TimeSpan Minutes(this short minutes)
	{
		return ((double)minutes).Minutes();
	}

	public static TimeSpan Minutes(this ushort minutes)
	{
		return ((double)(int)minutes).Minutes();
	}

	public static TimeSpan Minutes(this int minutes)
	{
		return ((double)minutes).Minutes();
	}

	public static TimeSpan Minutes(this uint minutes)
	{
		return ((double)minutes).Minutes();
	}

	public static TimeSpan Minutes(this long minutes)
	{
		return ((double)minutes).Minutes();
	}

	public static TimeSpan Minutes(this ulong minutes)
	{
		return ((double)minutes).Minutes();
	}

	public static TimeSpan Minutes(this double minutes)
	{
		return TimeSpan.FromMinutes(minutes);
	}

	public static TimeSpan Hours(this byte hours)
	{
		return ((double)(int)hours).Hours();
	}

	public static TimeSpan Hours(this sbyte hours)
	{
		return ((double)hours).Hours();
	}

	public static TimeSpan Hours(this short hours)
	{
		return ((double)hours).Hours();
	}

	public static TimeSpan Hours(this ushort hours)
	{
		return ((double)(int)hours).Hours();
	}

	public static TimeSpan Hours(this int hours)
	{
		return ((double)hours).Hours();
	}

	public static TimeSpan Hours(this uint hours)
	{
		return ((double)hours).Hours();
	}

	public static TimeSpan Hours(this long hours)
	{
		return ((double)hours).Hours();
	}

	public static TimeSpan Hours(this ulong hours)
	{
		return ((double)hours).Hours();
	}

	public static TimeSpan Hours(this double hours)
	{
		return TimeSpan.FromHours(hours);
	}

	public static TimeSpan Days(this byte days)
	{
		return ((double)(int)days).Days();
	}

	public static TimeSpan Days(this sbyte days)
	{
		return ((double)days).Days();
	}

	public static TimeSpan Days(this short days)
	{
		return ((double)days).Days();
	}

	public static TimeSpan Days(this ushort days)
	{
		return ((double)(int)days).Days();
	}

	public static TimeSpan Days(this int days)
	{
		return ((double)days).Days();
	}

	public static TimeSpan Days(this uint days)
	{
		return ((double)days).Days();
	}

	public static TimeSpan Days(this long days)
	{
		return ((double)days).Days();
	}

	public static TimeSpan Days(this ulong days)
	{
		return ((double)days).Days();
	}

	public static TimeSpan Days(this double days)
	{
		return TimeSpan.FromDays(days);
	}

	public static TimeSpan Weeks(this byte input)
	{
		return ((double)(int)input).Weeks();
	}

	public static TimeSpan Weeks(this sbyte input)
	{
		return ((double)input).Weeks();
	}

	public static TimeSpan Weeks(this short input)
	{
		return ((double)input).Weeks();
	}

	public static TimeSpan Weeks(this ushort input)
	{
		return ((double)(int)input).Weeks();
	}

	public static TimeSpan Weeks(this int input)
	{
		return ((double)input).Weeks();
	}

	public static TimeSpan Weeks(this uint input)
	{
		return ((double)input).Weeks();
	}

	public static TimeSpan Weeks(this long input)
	{
		return ((double)input).Weeks();
	}

	public static TimeSpan Weeks(this ulong input)
	{
		return ((double)input).Weeks();
	}

	public static TimeSpan Weeks(this double input)
	{
		return (7.0 * input).Days();
	}
}
