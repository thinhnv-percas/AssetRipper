using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace McMaster.Extensions.CommandLineUtils.Abstractions;

internal class ListParser : ICollectionParser
{
	private readonly IValueParser _elementParser;

	private readonly Type _listType;

	private readonly CultureInfo _parserCulture;

	public ListParser(Type elementType, IValueParser elementParser, CultureInfo parserCulture)
	{
		_elementParser = elementParser;
		_listType = typeof(List<>).MakeGenericType(elementType);
		_parserCulture = parserCulture;
	}

	public object Parse(string argName, IReadOnlyList<string> values)
	{
		IList list = (IList)Activator.CreateInstance(_listType, values.Count);
		for (int i = 0; i < values.Count; i++)
		{
			list.Add(_elementParser.Parse(argName, values[i], _parserCulture));
		}
		return list;
	}
}
