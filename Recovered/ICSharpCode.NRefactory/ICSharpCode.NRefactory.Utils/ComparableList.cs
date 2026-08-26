using System;
using System.Collections;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.Utils
{
	public sealed class ComparableList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IEquatable<ComparableList<T>>
	{
		private List<T> elements;

		public T this[int index]
		{
			get
			{
				return elements[index];
			}
			set
			{
				elements[index] = value;
			}
		}

		public int Count => elements.Count;

		public bool IsReadOnly => false;

		public ComparableList()
		{
			elements = new List<T>();
		}

		public ComparableList(IEnumerable<T> values)
		{
			elements = new List<T>(values);
		}

		public int IndexOf(T item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			return elements.IndexOf(item);
		}

		public void Insert(int index, T item)
		{
			elements.Insert(index, item);
		}

		public void RemoveAt(int index)
		{
			elements.RemoveAt(index);
		}

		public void Add(T item)
		{
			elements.Add(item);
		}

		public void Clear()
		{
			elements.Clear();
		}

		public bool Contains(T item)
		{
			return elements.Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			elements.CopyTo(array, arrayIndex);
		}

		public bool Remove(T item)
		{
			return elements.Remove(item);
		}

		public IEnumerator<T> GetEnumerator()
		{
			return elements.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as ComparableList<T>);
		}

		public bool Equals(ComparableList<T> obj)
		{
			if (obj == null || Count != obj.Count)
			{
				return false;
			}
			for (int i = 0; i < Count; i++)
			{
				if (!this[i].Equals(obj[i]))
				{
					return false;
				}
			}
			return true;
		}

		public override int GetHashCode()
		{
			int num = 19;
			using (IEnumerator<T> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					T current = enumerator.Current;
					num *= 31;
					num += current.GetHashCode();
				}
				return num;
			}
		}

		public static bool operator ==(ComparableList<T> item1, ComparableList<T> item2)
		{
			return item1?.Equals(item2) ?? ((object)item2 == null);
		}

		public static bool operator !=(ComparableList<T> item1, ComparableList<T> item2)
		{
			return !(item1 == item2);
		}
	}
}
