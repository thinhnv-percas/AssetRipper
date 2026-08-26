using System;
using System.Collections.Generic;
using Humanizer.Configuration;

namespace Humanizer;

public static class CollectionHumanizeExtensions
{
	public static string Humanize<T>(this IEnumerable<T> collection)
	{
		return Configurator.CollectionFormatter.Humanize(collection);
	}

	public static string Humanize<T>(this IEnumerable<T> collection, Func<T, string> displayFormatter)
	{
		if (displayFormatter == null)
		{
			throw new ArgumentNullException("displayFormatter");
		}
		return Configurator.CollectionFormatter.Humanize(collection, displayFormatter);
	}

	public static string Humanize<T>(this IEnumerable<T> collection, string separator)
	{
		return Configurator.CollectionFormatter.Humanize(collection, separator);
	}

	public static string Humanize<T>(this IEnumerable<T> collection, Func<T, string> displayFormatter, string separator)
	{
		if (displayFormatter == null)
		{
			throw new ArgumentNullException("displayFormatter");
		}
		return Configurator.CollectionFormatter.Humanize(collection, displayFormatter, separator);
	}
}
