using System.Collections.Generic;
using System.Collections.Immutable;

namespace Microsoft.DiaSymReader.PortablePdb;

internal static class EnumerableHelpers
{
	public static Dictionary<K, (V Single, ImmutableArray<V> Multiple)> GroupBy<K, V>(this IEnumerable<KeyValuePair<K, V>> entries, IEqualityComparer<K> keyComparer)
	{
		Dictionary<K, (V, ImmutableArray<V>.Builder)> dictionary = new Dictionary<K, (V, ImmutableArray<V>.Builder)>(keyComparer);
		foreach (KeyValuePair<K, V> entry in entries)
		{
			if (!dictionary.TryGetValue(entry.Key, out var value))
			{
				dictionary[entry.Key] = (entry.Value, null);
			}
			else if (value.Item2 == null)
			{
				ImmutableArray<V>.Builder builder = ImmutableArray.CreateBuilder<V>();
				builder.Add(value.Item1);
				builder.Add(entry.Value);
				dictionary[entry.Key] = (default(V), builder);
			}
			else
			{
				value.Item2.Add(entry.Value);
			}
		}
		Dictionary<K, (V, ImmutableArray<V>)> dictionary2 = new Dictionary<K, (V, ImmutableArray<V>)>(dictionary.Count, keyComparer);
		foreach (KeyValuePair<K, (V, ImmutableArray<V>.Builder)> item in dictionary)
		{
			dictionary2.Add(item.Key, (item.Value.Item1, item.Value.Item2?.ToImmutable() ?? default(ImmutableArray<V>)));
		}
		return dictionary2;
	}
}
