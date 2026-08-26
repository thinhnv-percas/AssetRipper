using System;
using System.Collections;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.Utils
{
	public sealed class ProjectedList<TInput, TOutput> : IList<TOutput>, ICollection<TOutput>, IEnumerable<TOutput>, IEnumerable where TOutput : class
	{
		private readonly IList<TInput> input;

		private readonly Func<TInput, TOutput> projection;

		private readonly TOutput[] items;

		public TOutput this[int index]
		{
			get
			{
				TOutput val = LazyInit.VolatileRead(ref items[index]);
				if (val != null)
				{
					return val;
				}
				return LazyInit.GetOrSet(ref items[index], projection(input[index]));
			}
		}

		TOutput IList<TOutput>.this[int index]
		{
			get
			{
				return this[index];
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		public int Count => items.Length;

		bool ICollection<TOutput>.IsReadOnly => true;

		public ProjectedList(IList<TInput> input, Func<TInput, TOutput> projection)
		{
			if (input == null)
			{
				throw new ArgumentNullException("input");
			}
			if (projection == null)
			{
				throw new ArgumentNullException("projection");
			}
			this.input = input;
			this.projection = projection;
			items = new TOutput[input.Count];
		}

		int IList<TOutput>.IndexOf(TOutput item)
		{
			EqualityComparer<TOutput> @default = EqualityComparer<TOutput>.Default;
			for (int i = 0; i < Count; i++)
			{
				if (@default.Equals(this[i], item))
				{
					return i;
				}
			}
			return -1;
		}

		void IList<TOutput>.Insert(int index, TOutput item)
		{
			throw new NotSupportedException();
		}

		void IList<TOutput>.RemoveAt(int index)
		{
			throw new NotSupportedException();
		}

		void ICollection<TOutput>.Add(TOutput item)
		{
			throw new NotSupportedException();
		}

		void ICollection<TOutput>.Clear()
		{
			throw new NotSupportedException();
		}

		bool ICollection<TOutput>.Contains(TOutput item)
		{
			EqualityComparer<TOutput> @default = EqualityComparer<TOutput>.Default;
			for (int i = 0; i < Count; i++)
			{
				if (@default.Equals(this[i], item))
				{
					return true;
				}
			}
			return false;
		}

		void ICollection<TOutput>.CopyTo(TOutput[] array, int arrayIndex)
		{
			for (int i = 0; i < items.Length; i++)
			{
				array[arrayIndex + i] = this[i];
			}
		}

		bool ICollection<TOutput>.Remove(TOutput item)
		{
			throw new NotSupportedException();
		}

		public IEnumerator<TOutput> GetEnumerator()
		{
			for (int i = 0; i < Count; i++)
			{
				yield return this[i];
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
	public sealed class ProjectedList<TContext, TInput, TOutput> : IList<TOutput>, ICollection<TOutput>, IEnumerable<TOutput>, IEnumerable where TOutput : class
	{
		private readonly IList<TInput> input;

		private readonly TContext context;

		private readonly Func<TContext, TInput, TOutput> projection;

		private readonly TOutput[] items;

		public TOutput this[int index]
		{
			get
			{
				TOutput val = LazyInit.VolatileRead(ref items[index]);
				if (val != null)
				{
					return val;
				}
				return LazyInit.GetOrSet(ref items[index], projection(context, input[index]));
			}
		}

		TOutput IList<TOutput>.this[int index]
		{
			get
			{
				return this[index];
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		public int Count => items.Length;

		bool ICollection<TOutput>.IsReadOnly => true;

		public ProjectedList(TContext context, IList<TInput> input, Func<TContext, TInput, TOutput> projection)
		{
			if (input == null)
			{
				throw new ArgumentNullException("input");
			}
			if (projection == null)
			{
				throw new ArgumentNullException("projection");
			}
			this.input = input;
			this.context = context;
			this.projection = projection;
			items = new TOutput[input.Count];
		}

		int IList<TOutput>.IndexOf(TOutput item)
		{
			EqualityComparer<TOutput> @default = EqualityComparer<TOutput>.Default;
			for (int i = 0; i < Count; i++)
			{
				if (@default.Equals(this[i], item))
				{
					return i;
				}
			}
			return -1;
		}

		void IList<TOutput>.Insert(int index, TOutput item)
		{
			throw new NotSupportedException();
		}

		void IList<TOutput>.RemoveAt(int index)
		{
			throw new NotSupportedException();
		}

		void ICollection<TOutput>.Add(TOutput item)
		{
			throw new NotSupportedException();
		}

		void ICollection<TOutput>.Clear()
		{
			throw new NotSupportedException();
		}

		bool ICollection<TOutput>.Contains(TOutput item)
		{
			EqualityComparer<TOutput> @default = EqualityComparer<TOutput>.Default;
			for (int i = 0; i < Count; i++)
			{
				if (@default.Equals(this[i], item))
				{
					return true;
				}
			}
			return false;
		}

		void ICollection<TOutput>.CopyTo(TOutput[] array, int arrayIndex)
		{
			for (int i = 0; i < items.Length; i++)
			{
				array[arrayIndex + i] = this[i];
			}
		}

		bool ICollection<TOutput>.Remove(TOutput item)
		{
			throw new NotSupportedException();
		}

		public IEnumerator<TOutput> GetEnumerator()
		{
			for (int i = 0; i < Count; i++)
			{
				yield return this[i];
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
