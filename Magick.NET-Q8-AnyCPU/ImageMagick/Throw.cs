using System;
using System.Globalization;

namespace ImageMagick;

internal static class Throw
{
	public static void IfFalse(string paramName, bool condition, string message, params object[] args)
	{
		if (!condition)
		{
			throw new ArgumentException(FormatMessage(message, args), paramName);
		}
	}

	public static void IfNull(string paramName, object value)
	{
		if (value == null)
		{
			throw new ArgumentNullException(paramName);
		}
	}

	public static void IfNull(string paramName, object value, string message, params object[] args)
	{
		if (value == null)
		{
			throw new ArgumentNullException(paramName, FormatMessage(message, args));
		}
	}

	public static void IfNullOrEmpty(string paramName, [ValidatedNotNull] string value)
	{
		IfNull(paramName, value);
		if (value.Length == 0)
		{
			throw new ArgumentException("Value cannot be empty.", paramName);
		}
	}

	public static void IfNullOrEmpty(string paramName, string value, string message, params object[] args)
	{
		IfNull(paramName, value, message, args);
		if (value.Length == 0)
		{
			throw new ArgumentException(FormatMessage(message, args), paramName);
		}
	}

	public static void IfNullOrEmpty(string paramName, [ValidatedNotNull] Array value)
	{
		IfNull(paramName, value);
		if (value.Length == 0)
		{
			throw new ArgumentException("Value cannot be empty.", paramName);
		}
	}

	public static void IfNegative(string paramName, Percentage value)
	{
		if ((double)value < 0.0)
		{
			throw new ArgumentException("Value should be greater then zero.", paramName);
		}
	}

	public static void IfOutOfRange(string paramName, int index, int length)
	{
		if (index < 0 || index >= length)
		{
			throw new ArgumentOutOfRangeException(paramName);
		}
	}

	public static void IfOutOfRange(string paramName, int min, int max, int value, string message, params object[] args)
	{
		if (value < min || value > max)
		{
			throw new ArgumentOutOfRangeException(paramName, FormatMessage(message, args));
		}
	}

	public static void IfTrue(string paramName, bool condition, string message, params object[] args)
	{
		if (condition)
		{
			throw new ArgumentException(FormatMessage(message, args), paramName);
		}
	}

	private static string FormatMessage(string message, params object[] args)
	{
		if (args.Length == 0)
		{
			return message;
		}
		return string.Format(CultureInfo.InvariantCulture, message, args);
	}
}
