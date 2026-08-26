#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace DecompTools.Decompiler.IL;

public sealed class InstructionCollection<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyList<T>, IReadOnlyCollection<T> where T : ILInstruction
{
	public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
	{
		private ILInstruction parentInstruction;

		private readonly List<T> list;

		private int pos;

		public T Current
		{
			[DebuggerStepThrough]
			get
			{
				return list[pos];
			}
		}

		object IEnumerator.Current => Current;

		public Enumerator(InstructionCollection<T> col)
		{
			list = col.list;
			pos = -1;
			parentInstruction = col.parentInstruction;
			col.parentInstruction.StartEnumerator();
		}

		[DebuggerStepThrough]
		public bool MoveNext()
		{
			return checked(++pos) < list.Count;
		}

		[DebuggerStepThrough]
		public void Dispose()
		{
			if (parentInstruction != null)
			{
				parentInstruction.StopEnumerator();
				parentInstruction = null;
			}
		}

		void IEnumerator.Reset()
		{
			pos = -1;
		}
	}

	private readonly ILInstruction parentInstruction;

	private readonly int firstChildIndex;

	private readonly List<T> list = new List<T>();

	public int Count => list.Count;

	public T this[int index]
	{
		get
		{
			return list[index];
		}
		set
		{
			T val = list[index];
			if (val != value)
			{
				list[index] = value;
				value.ChildIndex = checked(index + firstChildIndex);
				parentInstruction.InstructionCollectionAdded(value);
				parentInstruction.InstructionCollectionRemoved(val);
				parentInstruction.InstructionCollectionUpdateComplete();
			}
		}
	}

	bool ICollection<T>.IsReadOnly => false;

	public InstructionCollection(ILInstruction parentInstruction, int firstChildIndex)
	{
		if (parentInstruction == null)
		{
			throw new ArgumentNullException("parentInstruction");
		}
		this.parentInstruction = parentInstruction;
		this.firstChildIndex = firstChildIndex;
	}

	public Enumerator GetEnumerator()
	{
		return new Enumerator(this);
	}

	IEnumerator<T> IEnumerable<T>.GetEnumerator()
	{
		return GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public int IndexOf(T item)
	{
		if (item == null)
		{
			return -1;
		}
		int num = checked(item.ChildIndex - firstChildIndex);
		if (num >= 0 && num < list.Count && list[num] == item)
		{
			return num;
		}
		return list.IndexOf(item);
	}

	public bool Contains(T item)
	{
		return IndexOf(item) >= 0;
	}

	void ICollection<T>.CopyTo(T[] array, int arrayIndex)
	{
		list.CopyTo(array, arrayIndex);
	}

	public void Add(T value)
	{
		parentInstruction.AssertNoEnumerators();
		value.ChildIndex = checked(list.Count + firstChildIndex);
		list.Add(value);
		parentInstruction.InstructionCollectionAdded(value);
		parentInstruction.InstructionCollectionUpdateComplete();
	}

	public void AddRange(IEnumerable<T> values)
	{
		parentInstruction.AssertNoEnumerators();
		foreach (T value in values)
		{
			value.ChildIndex = checked(list.Count + firstChildIndex);
			list.Add(value);
			parentInstruction.InstructionCollectionAdded(value);
		}
		parentInstruction.InstructionCollectionUpdateComplete();
	}

	public void ReplaceList(IEnumerable<T> newList)
	{
		parentInstruction.AssertNoEnumerators();
		int num = 0;
		checked
		{
			foreach (T @new in newList)
			{
				@new.ChildIndex = num + firstChildIndex;
				if (num < list.Count)
				{
					T oldChild = list[num];
					list[num] = @new;
					parentInstruction.InstructionCollectionAdded(@new);
					parentInstruction.InstructionCollectionRemoved(oldChild);
				}
				else
				{
					list.Add(@new);
					parentInstruction.InstructionCollectionAdded(@new);
				}
				num++;
			}
			for (int i = num; i < list.Count; i++)
			{
				parentInstruction.InstructionCollectionRemoved(list[i]);
			}
			list.RemoveRange(num, list.Count - num);
			parentInstruction.InstructionCollectionUpdateComplete();
		}
	}

	public void Insert(int index, T item)
	{
		parentInstruction.AssertNoEnumerators();
		list.Insert(index, item);
		item.ChildIndex = index;
		parentInstruction.InstructionCollectionAdded(item);
		checked
		{
			for (int i = index + 1; i < list.Count; i++)
			{
				T val = list[i];
				if (val.Parent == parentInstruction && val.ChildIndex == i + firstChildIndex - 1)
				{
					val.ChildIndex = i + firstChildIndex;
				}
			}
			parentInstruction.InstructionCollectionUpdateComplete();
		}
	}

	public void RemoveAt(int index)
	{
		parentInstruction.AssertNoEnumerators();
		parentInstruction.InstructionCollectionRemoved(list[index]);
		list.RemoveAt(index);
		checked
		{
			for (int i = index; i < list.Count; i++)
			{
				T val = list[i];
				if (val.Parent == parentInstruction && val.ChildIndex == i + firstChildIndex + 1)
				{
					val.ChildIndex = i + firstChildIndex;
				}
			}
			parentInstruction.InstructionCollectionUpdateComplete();
		}
	}

	public void SwapRemoveAt(int index)
	{
		parentInstruction.AssertNoEnumerators();
		parentInstruction.InstructionCollectionRemoved(list[index]);
		checked
		{
			int num = list.Count - 1;
			T val = (list[index] = list[num]);
			T val3 = val;
			list.RemoveAt(num);
			if (val3.Parent == parentInstruction && val3.ChildIndex == num + firstChildIndex)
			{
				val3.ChildIndex = index + firstChildIndex;
			}
			parentInstruction.InstructionCollectionUpdateComplete();
		}
	}

	public void Clear()
	{
		parentInstruction.AssertNoEnumerators();
		foreach (T item in list)
		{
			parentInstruction.InstructionCollectionRemoved(item);
		}
		list.Clear();
		parentInstruction.InstructionCollectionUpdateComplete();
	}

	public bool Remove(T item)
	{
		int num = IndexOf(item);
		if (num >= 0)
		{
			RemoveAt(num);
			return true;
		}
		return false;
	}

	public void RemoveRange(int index, int count)
	{
		parentInstruction.AssertNoEnumerators();
		checked
		{
			for (int i = 0; i < count; i++)
			{
				parentInstruction.InstructionCollectionRemoved(list[index + i]);
			}
			list.RemoveRange(index, count);
			for (int j = index; j < list.Count; j++)
			{
				T val = list[j];
				if (val.Parent == parentInstruction && val.ChildIndex == j + firstChildIndex + count)
				{
					val.ChildIndex = j + firstChildIndex;
				}
			}
			parentInstruction.InstructionCollectionUpdateComplete();
		}
	}

	public int RemoveAll(Predicate<T> predicate)
	{
		parentInstruction.AssertNoEnumerators();
		int num = 0;
		checked
		{
			for (int i = 0; i < list.Count; i++)
			{
				T val = list[i];
				if (predicate(val))
				{
					parentInstruction.InstructionCollectionRemoved(val);
					continue;
				}
				if (val.Parent == parentInstruction && val.ChildIndex == i + firstChildIndex)
				{
					val.ChildIndex = num + firstChildIndex;
				}
				list[num] = val;
				num++;
			}
			int num2 = list.Count - num;
			if (num2 > 0)
			{
				list.RemoveRange(num, num2);
				parentInstruction.InstructionCollectionUpdateComplete();
			}
			return num2;
		}
	}

	public void MoveElementToIndex(int oldIndex, int newIndex)
	{
		parentInstruction.AssertNoEnumerators();
		T item = list[oldIndex];
		Insert(newIndex, item);
		if (oldIndex < newIndex)
		{
			RemoveAt(oldIndex);
		}
		else
		{
			RemoveAt(checked(oldIndex + 1));
		}
	}

	public void MoveElementToIndex(T item, int newIndex)
	{
		parentInstruction.AssertNoEnumerators();
		int num = IndexOf(item);
		if (num >= 0)
		{
			Insert(newIndex, item);
			if (num < newIndex)
			{
				RemoveAt(num);
			}
			else
			{
				RemoveAt(checked(num + 1));
			}
		}
	}

	public void MoveElementToEnd(int index)
	{
		MoveElementToIndex(index, list.Count);
	}

	public void MoveElementToEnd(T item)
	{
		MoveElementToIndex(item, list.Count);
	}

	public T First()
	{
		return list[0];
	}

	public T FirstOrDefault()
	{
		return (list.Count > 0) ? list[0] : null;
	}

	public T Last()
	{
		return list[checked(list.Count - 1)];
	}

	public T LastOrDefault()
	{
		return (list.Count > 0) ? list[checked(list.Count - 1)] : null;
	}

	public T SecondToLastOrDefault()
	{
		return (list.Count > 1) ? list[checked(list.Count - 2)] : null;
	}

	public T ElementAtOrDefault(int index)
	{
		if (index >= 0 && index < list.Count)
		{
			return list[index];
		}
		return null;
	}
}
