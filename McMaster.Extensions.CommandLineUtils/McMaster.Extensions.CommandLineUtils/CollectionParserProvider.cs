using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using McMaster.Extensions.CommandLineUtils.Abstractions;

namespace McMaster.Extensions.CommandLineUtils;

internal class CollectionParserProvider
{
	public static CollectionParserProvider Default { get; } = new CollectionParserProvider();

	private CollectionParserProvider()
	{
	}

	public ICollectionParser GetParser(Type type, ValueParserProvider valueParsers)
	{
		if (type.IsArray)
		{
			Type elementType = type.GetElementType();
			IValueParser parser = valueParsers.GetParser(elementType);
			if (parser == null)
			{
				return null;
			}
			return new ArrayParser(elementType, parser, valueParsers.ParseCulture);
		}
		TypeInfo typeInfo = type.GetTypeInfo();
		if (typeInfo.IsGenericType)
		{
			Type genericTypeDefinition = type.GetGenericTypeDefinition();
			Type type2 = typeInfo.GetGenericArguments().First();
			IValueParser parser2 = valueParsers.GetParser(type2);
			if (typeof(IList<>) == genericTypeDefinition || typeof(IEnumerable<>) == genericTypeDefinition || typeof(ICollection<>) == genericTypeDefinition || typeof(IReadOnlyCollection<>) == genericTypeDefinition || typeof(IReadOnlyList<>) == genericTypeDefinition || typeof(List<>) == genericTypeDefinition)
			{
				return new ListParser(type2, parser2, valueParsers.ParseCulture);
			}
			if (typeof(ISet<>) == genericTypeDefinition || typeof(HashSet<>) == genericTypeDefinition)
			{
				return new HashSetParser(type2, parser2, valueParsers.ParseCulture);
			}
		}
		return null;
	}
}
