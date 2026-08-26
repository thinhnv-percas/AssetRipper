using System;
using System.Globalization;

namespace McMaster.Extensions.CommandLineUtils.Abstractions;

public interface IValueParser
{
	Type TargetType { get; }

	object Parse(string argName, string value, CultureInfo culture);
}
public interface IValueParser<T> : IValueParser
{
	new T Parse(string argName, string value, CultureInfo culture);
}
