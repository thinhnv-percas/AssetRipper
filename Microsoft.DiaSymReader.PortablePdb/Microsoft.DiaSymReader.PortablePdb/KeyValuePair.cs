using System.Collections.Generic;

namespace Microsoft.DiaSymReader.PortablePdb;

internal static class KeyValuePair
{
	public static KeyValuePair<K, V> Create<K, V>(K key, V value)
	{
		return new KeyValuePair<K, V>(key, value);
	}

	public static void Deconstruct<K, V>(this KeyValuePair<K, V> pair, out K key, out V value)
	{
		key = pair.Key;
		value = pair.Value;
	}
}
