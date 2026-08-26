using System;
using System.Collections;

namespace DevX.Cecil.Binary
{
	public sealed class SectionCollection : IEnumerable, IBinaryVisitable, ICollection
	{
		private IList m_items;

		public Section this[int index]
		{
			get
			{
				return m_items[index] as Section;
			}
			set
			{
				m_items[index] = value;
			}
		}

		public int Count => m_items.Count;

		public bool IsSynchronized => false;

		public object SyncRoot => this;

		internal SectionCollection()
		{
			m_items = new ArrayList(4);
		}

		internal void Add(Section value)
		{
			m_items.Add(value);
		}

		internal void Clear()
		{
			m_items.Clear();
		}

		public bool Contains(Section value)
		{
			return m_items.Contains(value);
		}

		public int IndexOf(Section value)
		{
			return m_items.IndexOf(value);
		}

		internal void Insert(int index, Section value)
		{
			m_items.Insert(index, value);
		}

		internal void Remove(Section value)
		{
			m_items.Remove(value);
		}

		internal void RemoveAt(int index)
		{
			m_items.Remove(index);
		}

		public void CopyTo(Array ary, int index)
		{
			m_items.CopyTo(ary, index);
		}

		public IEnumerator GetEnumerator()
		{
			return m_items.GetEnumerator();
		}

		public void Accept(IBinaryVisitor visitor)
		{
			visitor.VisitSectionCollection(this);
			for (int i = 0; i < m_items.Count; i++)
			{
				this[i].Accept(visitor);
			}
		}
	}
}
