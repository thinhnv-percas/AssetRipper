using System;
using System.Collections;

namespace DevX.Cecil.Metadata
{
	public class RowCollection : IEnumerable, ICollection, IMetadataRowVisitable
	{
		private ArrayList m_items;

		public IMetadataRow this[int index]
		{
			get
			{
				return m_items[index] as IMetadataRow;
			}
			set
			{
				m_items[index] = value;
			}
		}

		public int Count => m_items.Count;

		public bool IsSynchronized => false;

		public object SyncRoot => this;

		internal RowCollection(int size)
		{
			m_items = new ArrayList(size);
		}

		internal RowCollection()
		{
			m_items = new ArrayList();
		}

		internal void Add(IMetadataRow value)
		{
			m_items.Add(value);
		}

		public void Clear()
		{
			m_items.Clear();
		}

		public bool Contains(IMetadataRow value)
		{
			return m_items.Contains(value);
		}

		public int IndexOf(IMetadataRow value)
		{
			return m_items.IndexOf(value);
		}

		public void Insert(int index, IMetadataRow value)
		{
			m_items.Insert(index, value);
		}

		public void Remove(IMetadataRow value)
		{
			m_items.Remove(value);
		}

		public void RemoveAt(int index)
		{
			m_items.Remove(index);
		}

		public void CopyTo(Array ary, int index)
		{
			m_items.CopyTo(ary, index);
		}

		public void Sort(IComparer comp)
		{
			m_items.Sort(comp);
		}

		public IEnumerator GetEnumerator()
		{
			return m_items.GetEnumerator();
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitRowCollection(this);
			for (int i = 0; i < m_items.Count; i++)
			{
				this[i].Accept(visitor);
			}
			visitor.TerminateRowCollection(this);
		}
	}
}
