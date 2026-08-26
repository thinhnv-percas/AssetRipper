using System;
using System.Collections;
using System.Linq;

namespace Humanizer;

public static class EnumDehumanizeExtensions
{
	public static TTargetEnum DehumanizeTo<TTargetEnum>(this string input) where TTargetEnum : struct, IComparable, IFormattable
	{
		return (TTargetEnum)DehumanizeToPrivate(input, typeof(TTargetEnum), OnNoMatch.ThrowsException);
	}

	public static Enum DehumanizeTo(this string input, Type targetEnum, OnNoMatch onNoMatch = OnNoMatch.ThrowsException)
	{
		return (Enum)DehumanizeToPrivate(input, targetEnum, onNoMatch);
	}

	private static object DehumanizeToPrivate(string input, Type targetEnum, OnNoMatch onNoMatch)
	{
		Enum obj = Enumerable.FirstOrDefault<Enum>(Enumerable.Cast<Enum>((IEnumerable)Enum.GetValues(targetEnum)), (Func<Enum, bool>)((Enum value) => string.Equals(value.Humanize(), input, StringComparison.OrdinalIgnoreCase)));
		if (obj == null && onNoMatch == OnNoMatch.ThrowsException)
		{
			throw new NoMatchFoundException("Couldn't find any enum member that matches the string " + input);
		}
		return obj;
	}
}
