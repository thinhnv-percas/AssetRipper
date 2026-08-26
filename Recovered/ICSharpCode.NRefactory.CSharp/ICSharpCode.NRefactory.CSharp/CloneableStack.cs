using System;
using System.Collections;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.CSharp
{
	internal class CloneableStack<T> : IEnumerable<T>, IEnumerable, ICollection<T>, ICloneable, IEquatable<CloneableStack<T>>
	{
		private class StackItem
		{
			public readonly StackItem Parent;

			public readonly T Item;

			public StackItem(StackItem parent, T item)
			{
				Parent = parent;
				Item = item;
			}
		}

		private class StackItemEnumerator : IEnumerator<T>, IDisposable, IEnumerator
		{
			private StackItem cur;

			private StackItem first;

			object IEnumerator.Current => cur.Item;

			T IEnumerator<T>.Current => cur.Item;

			public StackItemEnumerator(StackItem cur)
			{
				this.cur = (first = new StackItem(cur, default(T)));
			}

			void IDisposable.Dispose()
			{
				cur = (first = null);
			}

			bool IEnumerator.MoveNext()
			{
				if (cur == null)
				{
					return false;
				}
				cur = cur.Parent;
				return cur != null;
			}

			void IEnumerator.Reset()
			{
				cur = first;
			}
		}

		private int count;

		private StackItem top;

		public int Count => count;

		bool ICollection<T>.IsReadOnly => false;

		public IEnumerator<T> GetEnumerator()
		{
			return new StackItemEnumerator(top);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new StackItemEnumerator(top);
		}

		public CloneableStack<T> Clone()
		{
			return new CloneableStack<T>
			{
				count = count,
				top = top
			};
		}

		object ICloneable.Clone()
		{
			return Clone();
		}

		public void Clear()
		{
			top = null;
			count = 0;
		}

		public void Push(T item)
		{
			top = new StackItem(top, item);
			count++;
		}

		public T Peek()
		{
			return top.Item;
		}

		public T Pop()
		{
			T item = top.Item;
			top = top.Parent;
			count--;
			return item;
		}

		public bool Equals(CloneableStack<T> other)
		{
			return top == other.top;
		}

		void ICollection<T>.Add(T item)
		{
			Push(item);
		}

		void ICollection<T>.Clear()
		{
			top = null;
			count = 0;
		}

		bool ICollection<T>.Contains(T item)
		{
			using (IEnumerator<T> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Equals(item))
					{
						return true;
					}
				}
			}
			return false;
		}

		void ICollection<T>.CopyTo(T[] array, int arrayIndex)
		{
			int num = arrayIndex;
			using (IEnumerator<T> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					T current = enumerator.Current;
					array[num++] = current;
				}
			}
		}

		bool ICollection<T>.Remove(T item)
		{
			throw new NotImplementedException();
		}
	}
}
