using System;
using System.Collections.Generic;
using System.Linq;

namespace DecompTools.Decompiler.Util;

internal static class CollectionExtensions
{
	public static void Deconstruct<K, V>(this KeyValuePair<K, V> pair, out K key, out V value)
	{
		key = pair.Key;
		value = pair.Value;
	}

	public static IEnumerable<(A, B)> Zip<A, B>(this IEnumerable<A> input1, IEnumerable<B> input2)
	{
		return Enumerable.Zip<A, B, (A, B)>(input1, input2, (Func<A, B, (A, B)>)((A a, B b) => (a: a, b: b)));
	}

	public static IEnumerable<(A, B)> ZipLongest<A, B>(this IEnumerable<A> input1, IEnumerable<B> input2)
	{
		using IEnumerator<A> it1 = input1.GetEnumerator();
		using IEnumerator<B> it2 = input2.GetEnumerator();
		bool hasElements1 = true;
		bool hasElements2 = true;
		while (true)
		{
			if (hasElements1)
			{
				hasElements1 = it1.MoveNext();
			}
			if (hasElements2)
			{
				hasElements2 = it2.MoveNext();
			}
			if (!(hasElements1 | hasElements2))
			{
				break;
			}
			yield return (hasElements1 ? it1.Current : default(A), hasElements2 ? it2.Current : default(B));
		}
	}

	public static IEnumerable<T> Slice<T>(this IReadOnlyList<T> input, int offset, int length)
	{
		checked
		{
			for (int i = offset; i < offset + length; i++)
			{
				yield return input[i];
			}
		}
	}

	public static IEnumerable<T> Slice<T>(this IReadOnlyList<T> input, int offset)
	{
		int length = input.Count;
		for (int i = offset; i < length; i = checked(i + 1))
		{
			yield return input[i];
		}
	}

	public static HashSet<T> ToHashSet<T>(this IEnumerable<T> input)
	{
		return new HashSet<T>(input);
	}

	public static IEnumerable<T> SkipLast<T>(this IReadOnlyCollection<T> input, int count)
	{
		return Enumerable.Take<T>((IEnumerable<T>)input, checked(input.Count - count));
	}

	public static IEnumerable<T> TakeLast<T>(this IReadOnlyCollection<T> input, int count)
	{
		return Enumerable.Skip<T>((IEnumerable<T>)input, checked(input.Count - count));
	}

	public static T PopOrDefault<T>(this Stack<T> stack)
	{
		if (stack.Count == 0)
		{
			return default(T);
		}
		return stack.Pop();
	}

	public static T PeekOrDefault<T>(this Stack<T> stack)
	{
		if (stack.Count == 0)
		{
			return default(T);
		}
		return stack.Peek();
	}

	public static int MaxOrDefault<T>(this IEnumerable<T> input, Func<T, int> selector, int defaultValue = 0)
	{
		int num = defaultValue;
		foreach (T item in input)
		{
			int num2 = selector(item);
			if (num2 > num)
			{
				num = num2;
			}
		}
		return num;
	}

	public static int IndexOf<T>(this IReadOnlyList<T> collection, T value)
	{
		EqualityComparer<T> equalityComparer = EqualityComparer<T>.Default;
		int num = 0;
		foreach (T item in collection)
		{
			if (equalityComparer.Equals(item, value))
			{
				return num;
			}
			num = checked(num + 1);
		}
		return -1;
	}

	public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> input)
	{
		foreach (T item in input)
		{
			collection.Add(item);
		}
	}

	public static U[] SelectArray<T, U>(this ICollection<T> collection, Func<T, U> func)
	{
		U[] array = new U[collection.Count];
		int num = 0;
		foreach (T item in collection)
		{
			array[checked(num++)] = func(item);
		}
		return array;
	}

	public static U[] SelectReadOnlyArray<T, U>(this IReadOnlyCollection<T> collection, Func<T, U> func)
	{
		U[] array = new U[collection.Count];
		int num = 0;
		foreach (T item in collection)
		{
			array[checked(num++)] = func(item);
		}
		return array;
	}

	public static U[] SelectArray<T, U>(this List<T> collection, Func<T, U> func)
	{
		U[] array = new U[collection.Count];
		int num = 0;
		foreach (T item in collection)
		{
			array[checked(num++)] = func(item);
		}
		return array;
	}

	public static U[] SelectArray<T, U>(this T[] collection, Func<T, U> func)
	{
		U[] array = new U[collection.Length];
		int num = 0;
		foreach (T arg in collection)
		{
			array[checked(num++)] = func(arg);
		}
		return array;
	}

	public static List<U> SelectList<T, U>(this ICollection<T> collection, Func<T, U> func)
	{
		List<U> list = new List<U>(collection.Count);
		foreach (T item in collection)
		{
			list.Add(func(item));
		}
		return list;
	}

	public static IEnumerable<U> SelectWithIndex<T, U>(this IEnumerable<T> source, Func<int, T, U> func)
	{
		int index = 0;
		using IEnumerator<T> enumerator = source.GetEnumerator();
		while (enumerator.MoveNext())
		{
			yield return func(arg2: enumerator.Current, arg1: checked(index++));
		}
	}

	public static IEnumerable<(int, T)> WithIndex<T>(this ICollection<T> source)
	{
		int index = 0;
		foreach (T item in source)
		{
			yield return (index, item);
			index = checked(index + 1);
		}
	}

	public static IEnumerable<T> Merge<T>(this IEnumerable<T> input1, IEnumerable<T> input2, Comparison<T> comparison)
	{
		using IEnumerator<T> enumA = input1.GetEnumerator();
		using IEnumerator<T> enumB = input2.GetEnumerator();
		bool moreA = enumA.MoveNext();
		bool moreB = enumB.MoveNext();
		while (moreA & moreB)
		{
			if (comparison(enumA.Current, enumB.Current) <= 0)
			{
				yield return enumA.Current;
				moreA = enumA.MoveNext();
			}
			else
			{
				yield return enumB.Current;
				moreB = enumB.MoveNext();
			}
		}
		while (moreA)
		{
			yield return enumA.Current;
			moreA = enumA.MoveNext();
		}
		while (moreB)
		{
			yield return enumB.Current;
			moreB = enumB.MoveNext();
		}
	}

	public static T MinBy<T, K>(this IEnumerable<T> source, Func<T, K> keySelector) where K : IComparable<K>
	{
		return source.MinBy(keySelector, Comparer<K>.Default);
	}

	public static T MinBy<T, K>(this IEnumerable<T> source, Func<T, K> keySelector, IComparer<K> keyComparer)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (keySelector == null)
		{
			throw new ArgumentNullException("keySelector");
		}
		if (keyComparer == null)
		{
			keyComparer = Comparer<K>.Default;
		}
		using IEnumerator<T> enumerator = source.GetEnumerator();
		if (!enumerator.MoveNext())
		{
			throw new InvalidOperationException("Sequence contains no elements");
		}
		T val = enumerator.Current;
		K y = keySelector(val);
		while (enumerator.MoveNext())
		{
			T current = enumerator.Current;
			K val2 = keySelector(current);
			if (keyComparer.Compare(val2, y) < 0)
			{
				val = current;
				y = val2;
			}
		}
		return val;
	}

	public static T MaxBy<T, K>(this IEnumerable<T> source, Func<T, K> keySelector) where K : IComparable<K>
	{
		return source.MaxBy(keySelector, Comparer<K>.Default);
	}

	public static T MaxBy<T, K>(this IEnumerable<T> source, Func<T, K> keySelector, IComparer<K> keyComparer)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (keySelector == null)
		{
			throw new ArgumentNullException("keySelector");
		}
		if (keyComparer == null)
		{
			keyComparer = Comparer<K>.Default;
		}
		using IEnumerator<T> enumerator = source.GetEnumerator();
		if (!enumerator.MoveNext())
		{
			throw new InvalidOperationException("Sequence contains no elements");
		}
		T val = enumerator.Current;
		K y = keySelector(val);
		while (enumerator.MoveNext())
		{
			T current = enumerator.Current;
			K val2 = keySelector(current);
			if (keyComparer.Compare(val2, y) > 0)
			{
				val = current;
				y = val2;
			}
		}
		return val;
	}

	public static void RemoveLast<T>(this IList<T> list)
	{
		if (list == null)
		{
			throw new ArgumentNullException("list");
		}
		list.RemoveAt(checked(list.Count - 1));
	}

	public static T OnlyOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate)
	{
		return Enumerable.Where<T>(source, predicate).OnlyOrDefault();
	}

	public static T OnlyOrDefault<T>(this IEnumerable<T> source)
	{
		bool flag = false;
		T result = default(T);
		foreach (T item in source)
		{
			if (flag)
			{
				return default(T);
			}
			result = item;
			flag = true;
		}
		return result;
	}

	public static bool Any<T>(this ICollection<T> list)
	{
		return list.Count > 0;
	}

	public static bool Any<T>(this T[] array, Predicate<T> match)
	{
		return Array.Exists(array, match);
	}

	public static bool Any<T>(this List<T> list, Predicate<T> match)
	{
		return list.Exists(match);
	}

	public static bool All<T>(this T[] array, Predicate<T> match)
	{
		return Array.TrueForAll(array, match);
	}

	public static bool All<T>(this List<T> list, Predicate<T> match)
	{
		return list.TrueForAll(match);
	}

	public static T FirstOrDefault<T>(this T[] array, Predicate<T> predicate)
	{
		return Array.Find(array, predicate);
	}

	public static T FirstOrDefault<T>(this List<T> list, Predicate<T> predicate)
	{
		return list.Find(predicate);
	}

	public static T Last<T>(this IList<T> list)
	{
		return list[checked(list.Count - 1)];
	}
}
