using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace System.Threading.Tasks.Dataflow.Internal;

[DebuggerDisplay("Count = {Count}")]
[DebuggerTypeProxy(typeof(EnumerableDebugView<, >))]
internal sealed class QueuedMap<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
{
	private sealed class ArrayBasedLinkedQueue<T> : IEnumerable<T>, IEnumerable
	{
		private const int TERMINATOR_INDEX = -1;

		private readonly List<KeyValuePair<int, T>> m_storage;

		private int m_headIndex = -1;

		private int m_tailIndex = -1;

		private int m_freeIndex = -1;

		internal bool IsEmpty => m_headIndex == -1;

		internal ArrayBasedLinkedQueue()
		{
			m_storage = new List<KeyValuePair<int, T>>();
		}

		internal ArrayBasedLinkedQueue(int capacity)
		{
			m_storage = new List<KeyValuePair<int, T>>(capacity);
		}

		internal int Enqueue(T item)
		{
			int num;
			if (m_freeIndex != -1)
			{
				num = m_freeIndex;
				m_freeIndex = m_storage[m_freeIndex].Key;
				m_storage[num] = new KeyValuePair<int, T>(-1, item);
			}
			else
			{
				num = m_storage.Count;
				m_storage.Add(new KeyValuePair<int, T>(-1, item));
			}
			if (m_headIndex == -1)
			{
				m_headIndex = num;
			}
			else
			{
				m_storage[m_tailIndex] = new KeyValuePair<int, T>(num, m_storage[m_tailIndex].Value);
			}
			m_tailIndex = num;
			return num;
		}

		internal bool TryDequeue(out T item)
		{
			if (m_headIndex == -1)
			{
				item = default(T);
				return false;
			}
			item = m_storage[m_headIndex].Value;
			int key = m_storage[m_headIndex].Key;
			m_storage[m_headIndex] = new KeyValuePair<int, T>(m_freeIndex, default(T));
			m_freeIndex = m_headIndex;
			m_headIndex = key;
			if (m_headIndex == -1)
			{
				m_tailIndex = -1;
			}
			return true;
		}

		internal void Replace(int index, T item)
		{
			m_storage[index] = new KeyValuePair<int, T>(m_storage[index].Key, item);
		}

		internal void Clear()
		{
			m_storage.Clear();
			m_headIndex = -1;
			m_tailIndex = -1;
			m_freeIndex = -1;
		}

		public IEnumerator<T> GetEnumerator()
		{
			for (int index = m_headIndex; index != -1; index = m_storage[index].Key)
			{
				yield return m_storage[index].Value;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}

	private readonly ArrayBasedLinkedQueue<KeyValuePair<TKey, TValue>> m_queue;

	private readonly Dictionary<TKey, int> m_mapKeyToIndex;

	internal int Count => m_mapKeyToIndex.Count;

	internal QueuedMap()
	{
		m_queue = new ArrayBasedLinkedQueue<KeyValuePair<TKey, TValue>>();
		m_mapKeyToIndex = new Dictionary<TKey, int>();
	}

	internal QueuedMap(int capacity)
	{
		m_queue = new ArrayBasedLinkedQueue<KeyValuePair<TKey, TValue>>(capacity);
		m_mapKeyToIndex = new Dictionary<TKey, int>(capacity);
	}

	internal void Push(TKey key, TValue value)
	{
		if (!m_queue.IsEmpty && m_mapKeyToIndex.TryGetValue(key, out var value2))
		{
			m_queue.Replace(value2, new KeyValuePair<TKey, TValue>(key, value));
			return;
		}
		value2 = m_queue.Enqueue(new KeyValuePair<TKey, TValue>(key, value));
		m_mapKeyToIndex.Add(key, value2);
	}

	internal bool TryPop(out KeyValuePair<TKey, TValue> item)
	{
		bool flag = m_queue.TryDequeue(out item);
		if (flag)
		{
			m_mapKeyToIndex.Remove(item.Key);
		}
		return flag;
	}

	internal int PopRange(KeyValuePair<TKey, TValue>[] items, int arrayOffset, int count)
	{
		int i = 0;
		int num = arrayOffset;
		for (; i < count; i++)
		{
			if (!TryPop(out var item))
			{
				break;
			}
			items[num] = item;
			num++;
		}
		return i;
	}

	internal void Clear()
	{
		m_queue.Clear();
		m_mapKeyToIndex.Clear();
	}

	public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
	{
		return m_queue.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
