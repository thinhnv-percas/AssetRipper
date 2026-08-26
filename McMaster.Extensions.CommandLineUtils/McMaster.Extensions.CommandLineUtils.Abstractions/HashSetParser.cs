using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace McMaster.Extensions.CommandLineUtils.Abstractions;

internal class HashSetParser : ICollectionParser
{
	private readonly IValueParser _elementParser;

	private readonly Type _listType;

	private readonly MethodInfo _addMethod;

	private readonly CultureInfo _parserCulture;

	public HashSetParser(Type elementType, IValueParser elementParser, CultureInfo parserCulture)
	{
		_elementParser = elementParser;
		_listType = typeof(HashSet<>).MakeGenericType(elementType);
		_addMethod = _listType.GetRuntimeMethod("Add", new Type[1] { elementType });
		_parserCulture = parserCulture;
	}

	public object Parse(string argName, IReadOnlyList<string> values)
	{
		object obj = Activator.CreateInstance(_listType, Util.EmptyArray<object>());
		for (int i = 0; i < values.Count; i++)
		{
			_addMethod.Invoke(obj, new object[1] { _elementParser.Parse(argName, values[i], _parserCulture) });
		}
		return obj;
	}
}
