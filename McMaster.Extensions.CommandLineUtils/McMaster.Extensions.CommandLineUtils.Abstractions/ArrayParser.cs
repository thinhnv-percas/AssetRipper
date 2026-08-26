using System;
using System.Collections.Generic;
using System.Globalization;

namespace McMaster.Extensions.CommandLineUtils.Abstractions;

internal class ArrayParser : ICollectionParser
{
	private readonly Type _elementType;

	private readonly IValueParser _elementParser;

	private readonly CultureInfo _parserCulture;

	public ArrayParser(Type elementType, IValueParser elementParser, CultureInfo parserCulture)
	{
		_elementType = elementType;
		_elementParser = elementParser;
		_parserCulture = parserCulture;
	}

	public object Parse(string argName, IReadOnlyList<string> values)
	{
		Array array = Array.CreateInstance(_elementType, values.Count);
		for (int i = 0; i < values.Count; i++)
		{
			array.SetValue(_elementParser.Parse(argName, values[i], _parserCulture), i);
		}
		return array;
	}
}
