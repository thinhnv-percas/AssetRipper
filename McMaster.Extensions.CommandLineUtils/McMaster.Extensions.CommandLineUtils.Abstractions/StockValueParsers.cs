using System;
using System.Globalization;

namespace McMaster.Extensions.CommandLineUtils.Abstractions;

internal static class StockValueParsers
{
	private delegate bool NumberParser<T>(string s, NumberStyles styles, IFormatProvider provider, out T result);

	private delegate bool DateTimeParser<T>(string s, IFormatProvider provider, DateTimeStyles styles, out T result);

	public static readonly IValueParser<bool> Boolean = ValueParser.Create(delegate(string argName, string value, CultureInfo culture)
	{
		if (value == null)
		{
			return false;
		}
		switch (value)
		{
		case "T":
		case "t":
			return true;
		case "F":
		case "f":
			return false;
		default:
		{
			if (!bool.TryParse(value, out var result))
			{
				if (short.TryParse(value, out var result2))
				{
					switch (result2)
					{
					case 0:
						return false;
					case 1:
						return true;
					}
				}
				throw InvalidValueException(argName, "Cannot convert '" + value + "' to a boolean.");
			}
			return result;
		}
		}
	});

	public static readonly IValueParser<string> String = ValueParser.Create((string _, string value, CultureInfo __) => value);

	public static readonly IValueParser<Uri> Uri = ValueParser.Create((string _, string value, CultureInfo culture) => new Uri(value, UriKind.RelativeOrAbsolute));

	public static readonly IValueParser<double> Double = FloatingPointParser<double>(double.TryParse);

	public static readonly IValueParser<float> Float = FloatingPointParser<float>(float.TryParse);

	public static readonly IValueParser<short> Int16 = IntegerParser<short>(short.TryParse);

	public static readonly IValueParser<int> Int32 = IntegerParser<int>(int.TryParse);

	public static readonly IValueParser<long> Int64 = IntegerParser<long>(long.TryParse);

	public static readonly IValueParser<byte> Byte = NonNegativeIntegerParser<byte>(byte.TryParse);

	public static readonly IValueParser<ushort> UInt16 = NonNegativeIntegerParser<ushort>(ushort.TryParse);

	public static readonly IValueParser<uint> UInt32 = NonNegativeIntegerParser<uint>(uint.TryParse);

	public static readonly IValueParser<ulong> UInt64 = NonNegativeIntegerParser<ulong>(ulong.TryParse);

	public static readonly IValueParser<DateTime> DateTime = Create<DateTime>(System.DateTime.TryParse, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.RoundtripKind, (string argName, string value) => InvalidValueException(argName, "'" + value + "' is not a valid date-time."));

	public static readonly IValueParser<DateTimeOffset> DateTimeOffset = Create<DateTimeOffset>(System.DateTimeOffset.TryParse, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.RoundtripKind, (string argName, string value) => InvalidValueException(argName, "'" + value + "' is not a valid date-time (with offset)."));

	public static readonly IValueParser<TimeSpan> TimeSpan = ValueParser.Create((string value, CultureInfo culture) => (!System.TimeSpan.TryParse(value, culture, out var result)) ? default((bool, TimeSpan)) : (true, result), (string argName, string value) => InvalidValueException(argName, "'" + value + "' is not a valid time-span."));

	private static FormatException InvalidValueException(string argName, string specifics)
	{
		return new FormatException("Invalid value specified for " + argName + ". " + specifics);
	}

	private static IValueParser<T> Create<T>(NumberParser<T> parser, NumberStyles styles, Func<string, string, FormatException> errorSelector)
	{
		if (parser == null)
		{
			throw new ArgumentNullException("parser");
		}
		if (errorSelector == null)
		{
			throw new ArgumentNullException("errorSelector");
		}
		return ValueParser.Create((string value, CultureInfo culture) => (!parser(value, styles, culture.NumberFormat, out var result)) ? default((bool, T)) : (true, result), errorSelector);
	}

	private static IValueParser<T> FloatingPointParser<T>(NumberParser<T> parser)
	{
		return Create(parser, NumberStyles.Float | NumberStyles.AllowThousands, (string argName, string value) => InvalidValueException(argName, "'" + value + "' is not a valid floating-point number."));
	}

	private static IValueParser<T> IntegerParser<T>(NumberParser<T> parser)
	{
		return Create(parser, NumberStyles.Integer, (string argName, string value) => InvalidValueException(argName, "'" + value + "' is not a valid number."));
	}

	private static IValueParser<T> NonNegativeIntegerParser<T>(NumberParser<T> parser)
	{
		return Create(parser, NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite, (string argName, string value) => InvalidValueException(argName, "'" + value + "' is not a valid, non-negative number."));
	}

	private static IValueParser<T> Create<T>(DateTimeParser<T> parser, DateTimeStyles styles, Func<string, string, FormatException> errorSelector)
	{
		if (parser == null)
		{
			throw new ArgumentNullException("parser");
		}
		if (errorSelector == null)
		{
			throw new ArgumentNullException("errorSelector");
		}
		return ValueParser.Create((string value, CultureInfo culture) => (!parser(value, culture.DateTimeFormat, styles, out var result)) ? default((bool, T)) : (true, result), errorSelector);
	}
}
