using System;
using System.Globalization;

namespace McMaster.Extensions.CommandLineUtils.Abstractions;

internal class TupleValueParser
{
	public static IValueParser<Tuple<bool, T>> Create<T>(IValueParser<T> typeParser)
	{
		if (typeParser == null)
		{
			throw new ArgumentNullException("typeParser");
		}
		return ValueParser.Create((string argName, string value, CultureInfo culture) => (value != null) ? Tuple.Create(item1: true, typeParser.Parse(argName, value, culture)) : Tuple.Create(item1: false, default(T)));
	}
}
