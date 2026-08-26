using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace System.Threading.Tasks.Dataflow.Internal;

[DebuggerDisplay("Count={Count}")]
[DebuggerTypeProxy(typeof(EnumerableDebugView<>))]
internal sealed class ImmutableList<T> : IEnumerable<T>, IEnumerable
{
	private static readonly ImmutableList<T> s_empty = new ImmutableList<T>();

	private readonly T[] m_array;

	public static ImmutableList<T> Empty => s_empty;

	public int Count => m_array.Length;

	private ImmutableList()
		: this(new T[0])
	{
	}

	private ImmutableList(T[] elements)
	{
		m_array = elements;
	}

	public ImmutableList<T> Add(T item)
	{
		T[] array = new T[m_array.Length + 1];
		Array.Copy(m_array, 0, array, 0, m_array.Length);
		array[array.Length - 1] = item;
		return new ImmutableList<T>(array);
	}

	public ImmutableList<T> Remove(T item)
	{
		int num = Array.IndexOf(m_array, item);
		if (num < 0)
		{
			return this;
		}
		if (m_array.Length == 1)
		{
			return Empty;
		}
		T[] array = new T[m_array.Length - 1];
		Array.Copy(m_array, 0, array, 0, num);
		Array.Copy(m_array, num + 1, array, num, m_array.Length - num - 1);
		return new ImmutableList<T>(array);
	}

	public bool Contains(T item)
	{
		return Array.IndexOf(m_array, item) >= 0;
	}

	public IEnumerator<T> GetEnumerator()
	{
		return ((IEnumerable<T>)m_array).GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
