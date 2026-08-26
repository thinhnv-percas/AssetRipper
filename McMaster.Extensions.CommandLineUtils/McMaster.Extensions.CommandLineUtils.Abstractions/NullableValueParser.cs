using System;
using System.Globalization;

namespace McMaster.Extensions.CommandLineUtils.Abstractions;

internal class NullableValueParser : IValueParser
{
	private readonly IValueParser _wrapped;

	public Type TargetType
	{
		get
		{
			throw new InvalidOperationException("NullableValueParser does not have a target type");
		}
	}

	public NullableValueParser(IValueParser boxedParser)
	{
		_wrapped = boxedParser;
	}

	public object Parse(string argName, string value, CultureInfo culture)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			return null;
		}
		return _wrapped.Parse(argName, value, culture);
	}
}
