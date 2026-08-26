using System;

namespace HelixToolkit.Wpf;

public sealed class SimpleRingBuffer<T>
{
	private readonly T[] buffer;

	private int next = 0;

	private int last = -1;

	private int first = 0;

	private readonly int bufferSize;

	private int count;

	public int Count => count;

	public T Last => IsEmpty() ? default(T) : buffer[last];

	public T First => IsEmpty() ? default(T) : buffer[first];

	public T this[int i]
	{
		get
		{
			if (i >= bufferSize)
			{
				throw new IndexOutOfRangeException();
			}
			return buffer[(first + i) % bufferSize];
		}
	}

	public SimpleRingBuffer(int size)
	{
		buffer = new T[size];
		bufferSize = size;
	}

	public bool Add(T item)
	{
		if (!IsFull())
		{
			buffer[next] = item;
			last = next;
			next = IncLast();
			count++;
			return true;
		}
		return false;
	}

	public bool RemoveLast()
	{
		if (IsEmpty())
		{
			return false;
		}
		next = DecLast();
		buffer[next] = default(T);
		last = ((next == 0) ? (bufferSize - 1) : (next - 1));
		count--;
		return true;
	}

	public bool RemoveFirst()
	{
		if (IsEmpty())
		{
			return false;
		}
		buffer[first] = default(T);
		first = IncFirst();
		count--;
		return true;
	}

	public bool IsFull()
	{
		return count == bufferSize;
	}

	public bool IsEmpty()
	{
		return count == 0;
	}

	private int IncLast()
	{
		return (next + 1) % bufferSize;
	}

	private int DecLast()
	{
		int num = next - 1;
		return (num >= 0) ? num : (bufferSize - 1);
	}

	private int IncFirst()
	{
		return (first + 1) % bufferSize;
	}

	public void Clear()
	{
		Array.Clear(buffer, 0, bufferSize);
		first = (next = 0);
		last = -1;
		count = 0;
	}
}
