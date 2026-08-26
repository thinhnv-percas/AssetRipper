using System;
using System.Collections.Generic;
using System.Threading;

namespace Microsoft.VisualStudio.Composition;

internal static class ArrayRental<T>
{
	private static readonly ThreadLocal<Dictionary<int, Stack<T[]>>> Arrays = new ThreadLocal<Dictionary<int, Stack<T[]>>>(() => new Dictionary<int, Stack<T[]>>());

	internal static Rental<T[]> Get(int length)
	{
		if (!Arrays.Value.TryGetValue(length, out var value))
		{
			Arrays.Value.Add(length, value = new Stack<T[]>());
		}
		return new Rental<T[]>(value, (int len) => new T[len], delegate(T[] array)
		{
			Array.Clear(array, 0, array.Length);
		}, length);
	}
}
