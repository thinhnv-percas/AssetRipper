using System;
using System.Collections.Generic;
using System.Linq;

namespace Humanizer.Localisation.CollectionFormatters;

internal class DefaultCollectionFormatter : ICollectionFormatter
{
	protected string DefaultSeparator = "";

	public DefaultCollectionFormatter(string defaultSeparator)
	{
		DefaultSeparator = defaultSeparator;
	}

	public virtual string Humanize<T>(IEnumerable<T> collection)
	{
		return Humanize(collection, (T o) => o?.ToString(), DefaultSeparator);
	}

	public virtual string Humanize<T>(IEnumerable<T> collection, Func<T, string> objectFormatter)
	{
		return Humanize(collection, objectFormatter, DefaultSeparator);
	}

	public virtual string Humanize<T>(IEnumerable<T> collection, string separator)
	{
		return Humanize(collection, (T o) => o?.ToString(), separator);
	}

	public virtual string Humanize<T>(IEnumerable<T> collection, Func<T, string> objectFormatter, string separator)
	{
		if (collection == null)
		{
			throw new ArgumentException("collection");
		}
		string[] array = Enumerable.ToArray<string>(Enumerable.Where<string>(Enumerable.Select<string, string>(Enumerable.Select<T, string>(collection, objectFormatter), (Func<string, string>)((string item) => (item != null) ? item.Trim() : string.Empty)), (Func<string, bool>)((string item) => !string.IsNullOrWhiteSpace(item))));
		int num = array.Length;
		switch (num)
		{
		case 0:
			return "";
		case 1:
			return array[0];
		default:
		{
			IEnumerable<string> values = Enumerable.Take<string>((IEnumerable<string>)array, num - 1);
			string text = Enumerable.First<string>(Enumerable.Skip<string>((IEnumerable<string>)array, num - 1));
			return string.Format(GetConjunctionFormatString(num), new object[3]
			{
				string.Join(", ", values),
				separator,
				text
			});
		}
		}
	}

	protected virtual string GetConjunctionFormatString(int itemCount)
	{
		return "{0} {1} {2}";
	}
}
