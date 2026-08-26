using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Microsoft.DiaSymReader.PortablePdb;

internal static class ImmutableArrayExtensions
{
	internal static ImmutableArray<T> ToImmutableArrayOrEmpty<T>(this IEnumerable<T> items)
	{
		if (items == null)
		{
			return ImmutableArray.Create<T>();
		}
		return ImmutableArray.CreateRange(items);
	}

	internal static ImmutableArray<T> ToImmutableArrayOrEmpty<T>(this ImmutableArray<T> items)
	{
		if (items.IsDefault)
		{
			return ImmutableArray.Create<T>();
		}
		return items;
	}

	internal static int BinarySearch<TElement, TValue>(this ImmutableArray<TElement> array, TValue value, Func<TElement, TValue, int> comparer)
	{
		int num = 0;
		int num2 = array.Length - 1;
		while (num <= num2)
		{
			int num3 = num + (num2 - num >> 1);
			int num4 = comparer(array[num3], value);
			if (num4 == 0)
			{
				return num3;
			}
			if (num4 > 0)
			{
				num2 = num3 - 1;
			}
			else
			{
				num = num3 + 1;
			}
		}
		return ~num;
	}

	internal static void AddSubRange<T>(this ImmutableArray<T>.Builder builder, ImmutableArray<T> items, int start)
	{
		for (int i = start; i < items.Length; i++)
		{
			builder.Add(items[i]);
		}
	}
}
