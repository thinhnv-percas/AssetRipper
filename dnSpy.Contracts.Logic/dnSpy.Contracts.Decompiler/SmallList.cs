using System;
using System.Collections.Generic;

namespace dnSpy.Contracts.Decompiler;

internal struct SmallList<T>
{
	private T firstValue;

	private bool hasFirstValue;

	private List<T> list;

	public void Add(T value)
	{
		if (!hasFirstValue)
		{
			firstValue = value;
			hasFirstValue = true;
			return;
		}
		if (list == null)
		{
			list = new List<T>(2) { firstValue };
		}
		list.Add(value);
	}

	public T[] ToArray()
	{
		if (list != null)
		{
			return list.ToArray();
		}
		if (hasFirstValue)
		{
			return new T[1] { firstValue };
		}
		return Array.Empty<T>();
	}
}
