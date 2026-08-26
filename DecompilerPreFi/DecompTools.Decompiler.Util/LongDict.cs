using System;
using System.Collections;
using System.Collections.Generic;

namespace DecompTools.Decompiler.Util;

internal static class LongDict
{
	internal static readonly KeyComparer<LongInterval, long> StartComparer = KeyComparer.Create((LongInterval i) => i.Start);

	public static LongDict<T> Create<T>(IEnumerable<(LongSet, T)> entries)
	{
		return new LongDict<T>(entries);
	}
}
internal struct LongDict<T> : IEnumerable<KeyValuePair<LongInterval, T>>, IEnumerable
{
	private readonly LongInterval[] keys;

	private readonly T[] values;

	public LongDict(IEnumerable<(LongSet, T)> entries)
	{
		LongSet other = LongSet.Universe;
		List<LongInterval> list = new List<LongInterval>();
		List<T> list2 = new List<T>();
		foreach (var entry in entries)
		{
			LongSet item = entry.Item1;
			T item2 = entry.Item2;
			foreach (LongInterval interval in item.IntersectWith(other).Intervals)
			{
				list.Add(interval);
				list2.Add(item2);
			}
			other = other.ExceptWith(item);
		}
		keys = list.ToArray();
		values = list2.ToArray();
		Array.Sort(keys, values, LongDict.StartComparer);
	}

	public bool TryGetValue(long key, out T value)
	{
		int num = Array.BinarySearch(keys, new LongInterval(key, key), LongDict.StartComparer);
		if (num < 0)
		{
			num = checked(~num - 1);
		}
		if (num >= 0 && keys[num].Contains(key))
		{
			value = values[num];
			return true;
		}
		value = default(T);
		return false;
	}

	public T GetOrDefault(long key)
	{
		TryGetValue(key, out var value);
		return value;
	}

	public IEnumerator<KeyValuePair<LongInterval, T>> GetEnumerator()
	{
		int i = 0;
		while (i < keys.Length)
		{
			yield return new KeyValuePair<LongInterval, T>(keys[i], values[i]);
			int num = checked(i + 1);
			i = num;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
