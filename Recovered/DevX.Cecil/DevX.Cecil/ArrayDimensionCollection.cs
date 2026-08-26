using System;
using System.Collections;

namespace DevX.Cecil
{
	public sealed class ArrayDimensionCollection : CollectionBase
	{
		private ArrayType m_container;

		public ArrayDimension this[int index]
		{
			get
			{
				return base.List[index] as ArrayDimension;
			}
			set
			{
				base.List[index] = value;
			}
		}

		public ArrayType Container => m_container;

		public ArrayDimensionCollection(ArrayType container)
		{
			m_container = container;
		}

		public void Add(ArrayDimension value)
		{
			base.List.Add(value);
		}

		public bool Contains(ArrayDimension value)
		{
			return base.List.Contains(value);
		}

		public int IndexOf(ArrayDimension value)
		{
			return base.List.IndexOf(value);
		}

		public void Insert(int index, ArrayDimension value)
		{
			base.List.Insert(index, value);
		}

		public void Remove(ArrayDimension value)
		{
			base.List.Remove(value);
		}

		protected override void OnValidate(object o)
		{
			if (!(o is ArrayDimension))
			{
				throw new ArgumentException("Must be of type " + typeof(ArrayDimension).FullName);
			}
		}
	}
}
