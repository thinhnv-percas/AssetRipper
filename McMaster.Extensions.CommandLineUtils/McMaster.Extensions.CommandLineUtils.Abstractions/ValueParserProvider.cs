using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace McMaster.Extensions.CommandLineUtils.Abstractions;

public class ValueParserProvider
{
	private sealed class GenericParserAdapter<T> : IValueParser<T>, IValueParser
	{
		private IValueParser _inner;

		public Type TargetType => _inner.TargetType;

		public GenericParserAdapter(IValueParser inner)
		{
			_inner = inner;
		}

		public T Parse(string argName, string value, CultureInfo culture)
		{
			return (T)_inner.Parse(argName, value, culture);
		}

		object IValueParser.Parse(string argName, string value, CultureInfo culture)
		{
			return _inner.Parse(argName, value, culture);
		}
	}

	private readonly Dictionary<Type, IValueParser> _parsers = new Dictionary<Type, IValueParser>(10);

	private static readonly MethodInfo s_GetParserGeneric = typeof(ValueParserProvider).GetTypeInfo().GetMethods(BindingFlags.Instance | BindingFlags.Public).Single((MethodInfo m) => m.Name == "GetParser" && m.IsGenericMethod);

	public CultureInfo ParseCulture { get; set; } = CultureInfo.CurrentCulture;

	internal ValueParserProvider()
	{
		AddRange(new IValueParser[15]
		{
			StockValueParsers.String,
			StockValueParsers.Boolean,
			StockValueParsers.Byte,
			StockValueParsers.Int16,
			StockValueParsers.Int32,
			StockValueParsers.Int64,
			StockValueParsers.UInt16,
			StockValueParsers.UInt32,
			StockValueParsers.UInt64,
			StockValueParsers.Float,
			StockValueParsers.Double,
			StockValueParsers.Uri,
			StockValueParsers.DateTime,
			StockValueParsers.DateTimeOffset,
			StockValueParsers.TimeSpan
		});
	}

	public IValueParser GetParser(Type type)
	{
		return (IValueParser)s_GetParserGeneric.MakeGenericMethod(type).Invoke(this, Util.EmptyArray<object>());
	}

	public IValueParser<T> GetParser<T>()
	{
		IValueParser parserImpl = GetParserImpl<T>();
		if (parserImpl == null)
		{
			return null;
		}
		if (parserImpl is IValueParser<T> result)
		{
			return result;
		}
		return new GenericParserAdapter<T>(parserImpl);
	}

	internal IValueParser GetParserImpl<T>()
	{
		Type typeFromHandle = typeof(T);
		if (_parsers.TryGetValue(typeFromHandle, out var value))
		{
			return value;
		}
		TypeInfo typeInfo = typeFromHandle.GetTypeInfo();
		if (typeInfo.IsEnum)
		{
			return EnumParser.Create(typeFromHandle);
		}
		if (ReflectionHelper.IsNullableType(typeInfo, out var wrappedType))
		{
			if (wrappedType.GetTypeInfo().IsEnum)
			{
				return new NullableValueParser(EnumParser.Create(wrappedType));
			}
			if (_parsers.TryGetValue(wrappedType, out value))
			{
				return new NullableValueParser(value);
			}
		}
		if (!typeInfo.IsGenericType)
		{
			return null;
		}
		if (typeInfo.GetGenericTypeDefinition() == typeof(ValueTuple<, >) && typeInfo.GenericTypeArguments[0] == typeof(bool))
		{
			IValueParser parser = GetParser(typeInfo.GenericTypeArguments[1]);
			if (parser == null)
			{
				return null;
			}
			return (IValueParser)typeof(ValueTupleValueParser).GetTypeInfo().GetMethod("Create").MakeGenericMethod(typeInfo.GenericTypeArguments[1])
				.Invoke(null, new object[1] { parser });
		}
		return null;
	}

	public void Add(IValueParser parser)
	{
		SafeAdd(parser);
	}

	public void AddRange(IEnumerable<IValueParser> parsers)
	{
		if (parsers == null)
		{
			throw new ArgumentNullException("parsers");
		}
		foreach (IValueParser parser in parsers)
		{
			SafeAdd(parser);
		}
	}

	public void AddOrReplace(IValueParser parser)
	{
		SafeAdd(parser, andReplace: true);
	}

	private void SafeAdd(IValueParser parser, bool andReplace = false)
	{
		if (parser == null)
		{
			throw new ArgumentNullException("parser");
		}
		Type targetType = parser.TargetType;
		if (targetType == null)
		{
			throw new ArgumentNullException("TargetType", "The value parser must have a target type set");
		}
		targetType = (ReflectionHelper.IsNullableType(targetType.GetTypeInfo(), out var wrappedType) ? wrappedType : targetType);
		if (_parsers.ContainsKey(targetType))
		{
			if (!andReplace)
			{
				throw new ArgumentException($"Value parser provider for type '{targetType}' already exists.");
			}
			_parsers.Remove(targetType);
		}
		_parsers.Add(targetType, parser);
	}
}
