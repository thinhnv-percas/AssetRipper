using System.Collections.Generic;
using System.Composition.Hosting.Properties;
using System.Linq;
using Microsoft.Internal;

namespace System.Composition.Hosting.Util;

internal static class Formatters
{
	public static string ReadableList(IEnumerable<string> items)
	{
		Microsoft.Internal.Assumes.NotNull(items);
		string text = string.Join(System.Composition.Hosting.Properties.Resources.Formatter_ListSeparatorWithSpace, items.OrderBy((string t) => t));
		if (string.IsNullOrEmpty(text))
		{
			return System.Composition.Hosting.Properties.Resources.Formatter_None;
		}
		return text;
	}

	public static string Format(Type type)
	{
		Microsoft.Internal.Assumes.NotNull(type);
		if (type.IsConstructedGenericType)
		{
			return FormatClosedGeneric(type);
		}
		return type.Name;
	}

	private static string FormatClosedGeneric(Type closedGenericType)
	{
		Microsoft.Internal.Assumes.NotNull(closedGenericType);
		Microsoft.Internal.Assumes.IsTrue(closedGenericType.IsConstructedGenericType);
		string text = closedGenericType.Name.Substring(0, closedGenericType.Name.IndexOf("`"));
		IEnumerable<string> values = closedGenericType.GenericTypeArguments.Select((Type t) => Format(t));
		return string.Format("{0}<{1}>", new object[2]
		{
			text,
			string.Join(", ", values)
		});
	}
}
