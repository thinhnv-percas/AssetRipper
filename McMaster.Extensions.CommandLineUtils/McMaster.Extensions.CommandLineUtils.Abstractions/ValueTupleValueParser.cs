using System;
using System.Globalization;

namespace McMaster.Extensions.CommandLineUtils.Abstractions;

internal static class ValueTupleValueParser
{
	public static IValueParser<(bool, T)> Create<T>(IValueParser<T> typeParser)
	{
		if (typeParser == null)
		{
			throw new ArgumentNullException("typeParser");
		}
		return ValueParser.Create((string argName, string value, CultureInfo culture) => (value != null) ? (true, typeParser.Parse(argName, value, culture)) : (true, default(T)));
	}
}
