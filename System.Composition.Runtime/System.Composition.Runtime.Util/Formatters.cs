using System.Collections.Generic;
using System.Composition.Properties;
using System.Linq;

namespace System.Composition.Runtime.Util;

internal static class Formatters
{
	public static string Format(object value)
	{
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		if (value is string)
		{
			return string.Concat("\"", value, "\"");
		}
		return value.ToString();
	}

	public static string Format(Type type)
	{
		if ((object)type == null)
		{
			throw new ArgumentNullException("type");
		}
		if (type.IsConstructedGenericType)
		{
			return FormatClosedGeneric(type);
		}
		return type.Name;
	}

	private static string FormatClosedGeneric(Type closedGenericType)
	{
		if ((object)closedGenericType == null)
		{
			throw new ArgumentNullException("closedGenericType");
		}
		if (!closedGenericType.IsConstructedGenericType)
		{
			throw new ArgumentException();
		}
		string text = closedGenericType.Name.Substring(0, closedGenericType.Name.IndexOf("`"));
		IEnumerable<string> values = closedGenericType.GenericTypeArguments.Select((Type t) => Format(t));
		return string.Format("{0}<{1}>", new object[2]
		{
			text,
			string.Join(System.Composition.Properties.Resources.Formatter_ListSeparatorWithSpace, values)
		});
	}
}
