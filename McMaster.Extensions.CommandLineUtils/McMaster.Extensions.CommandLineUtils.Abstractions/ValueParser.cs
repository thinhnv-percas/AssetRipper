using System;
using System.Globalization;

namespace McMaster.Extensions.CommandLineUtils.Abstractions;

public static class ValueParser
{
	private sealed class DelegatingValueParser<T> : IValueParser<T>, IValueParser
	{
		private readonly Func<string, string, CultureInfo, T> _parser;

		public Type TargetType => typeof(T);

		public DelegatingValueParser(Func<string, string, CultureInfo, T> parser)
		{
			_parser = parser ?? throw new ArgumentNullException("parser");
		}

		public T Parse(string argName, string value, CultureInfo culture)
		{
			return _parser(argName, value, culture);
		}

		object IValueParser.Parse(string argName, string value, CultureInfo culture)
		{
			return Parse(argName, value, culture);
		}
	}

	private class DelegatingValueParser : IValueParser
	{
		private readonly IValueParser<object> _parser;

		public Type TargetType { get; }

		public DelegatingValueParser(Type targetType, IValueParser<object> parser)
		{
			TargetType = targetType ?? throw new ArgumentNullException("targetType");
			_parser = parser ?? throw new ArgumentNullException("parser");
		}

		public object Parse(string argName, string value, CultureInfo culture)
		{
			return _parser.Parse(argName, value, culture);
		}
	}

	public static IValueParser Create(Type targetType, Func<string, string, CultureInfo, object> parser)
	{
		return new DelegatingValueParser(targetType, Create(parser));
	}

	public static IValueParser<T> Create<T>(Func<string, string, CultureInfo, T> parser)
	{
		return new DelegatingValueParser<T>(parser);
	}

	public static IValueParser<T> Create<T>(Func<string, CultureInfo, (bool, T)> parser)
	{
		return Create(parser, (string argName, string value) => new FormatException("Invalid value specified for " + argName + ". '" + value + "' is an invalid representation of " + typeof(T).Name + "."));
	}

	public static IValueParser<T> Create<T>(Func<string, CultureInfo, (bool, T)> parser, Func<string, string, FormatException> errorSelector)
	{
		if (parser == null)
		{
			throw new ArgumentNullException("parser");
		}
		if (errorSelector == null)
		{
			throw new ArgumentNullException("errorSelector");
		}
		return Create(delegate(string argName, string value, CultureInfo culture)
		{
			if (value == null)
			{
				return default(T);
			}
			var (flag, result) = parser(value, culture);
			if (!flag)
			{
				throw errorSelector(argName, value);
			}
			return result;
		});
	}
}
