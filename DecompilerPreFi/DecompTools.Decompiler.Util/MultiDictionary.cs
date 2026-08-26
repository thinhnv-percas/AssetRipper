using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DecompTools.Decompiler.Util;

public class MultiDictionary<TKey, TValue> : ILookup<TKey, TValue>, IEnumerable<IGrouping<TKey, TValue>>, IEnumerable
{
	private sealed class Grouping : IGrouping<TKey, TValue>, IEnumerable<TValue>, IEnumerable
	{
		private readonly TKey key;

		private readonly List<TValue> values;

		public TKey Key => key;

		public Grouping(TKey key, List<TValue> values)
		{
			this.key = key;
			this.values = values;
		}

		public IEnumerator<TValue> GetEnumerator()
		{
			return values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return values.GetEnumerator();
		}
	}

	private readonly Dictionary<TKey, List<TValue>> dict;

	public IReadOnlyList<TValue> this[TKey key]
	{
		get
		{
			if (dict.TryGetValue(key, out var value))
			{
				return value;
			}
			return EmptyList<TValue>.Instance;
		}
	}

	public int Count => dict.Count;

	public ICollection<TKey> Keys => dict.Keys;

	public IEnumerable<TValue> Values => Enumerable.SelectMany<List<TValue>, TValue>((IEnumerable<List<TValue>>)dict.Values, (Func<List<TValue>, IEnumerable<TValue>>)((List<TValue> list) => list));

	IEnumerable<TValue> ILookup<TKey, TValue>.this[TKey key] => this[key];

	public MultiDictionary()
	{
		dict = new Dictionary<TKey, List<TValue>>();
	}

	public MultiDictionary(IEqualityComparer<TKey> comparer)
	{
		dict = new Dictionary<TKey, List<TValue>>(comparer);
	}

	public void Add(TKey key, TValue value)
	{
		if (!dict.TryGetValue(key, out var value2))
		{
			value2 = new List<TValue>();
			dict.Add(key, value2);
		}
		value2.Add(value);
	}

	public bool Remove(TKey key, TValue value)
	{
		if (dict.TryGetValue(key, out var value2) && value2.Remove(value))
		{
			if (value2.Count == 0)
			{
				dict.Remove(key);
			}
			return true;
		}
		return false;
	}

	public bool RemoveAll(TKey key)
	{
		return dict.Remove(key);
	}

	public void Clear()
	{
		dict.Clear();
	}

	bool ILookup<TKey, TValue>.Contains(TKey key)
	{
		return dict.ContainsKey(key);
	}

	public IEnumerator<IGrouping<TKey, TValue>> GetEnumerator()
	{
		foreach (KeyValuePair<TKey, List<TValue>> pair in dict)
		{
			yield return new Grouping(pair.Key, pair.Value);
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
