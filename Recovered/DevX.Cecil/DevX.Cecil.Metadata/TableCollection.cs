using System;
using System.Collections;

namespace DevX.Cecil.Metadata
{
	public class TableCollection : IEnumerable, ICollection, IMetadataTableVisitable
	{
		private IMetadataTable[] m_tables = new IMetadataTable[45];

		private TablesHeap m_heap;

		public IMetadataTable this[int index]
		{
			get
			{
				return m_tables[index];
			}
			set
			{
				m_tables[index] = value;
			}
		}

		public int Count => GetList().Count;

		public bool IsSynchronized => false;

		public object SyncRoot => this;

		public TablesHeap Heap => m_heap;

		internal TableCollection(TablesHeap heap)
		{
			m_heap = heap;
		}

		internal void Add(IMetadataTable value)
		{
			m_tables[value.Id] = value;
		}

		public bool Contains(IMetadataTable value)
		{
			return m_tables[value.Id] != null;
		}

		internal void Remove(IMetadataTable value)
		{
			m_tables[value.Id] = null;
		}

		public void CopyTo(Array array, int index)
		{
			GetList().CopyTo(array, index);
		}

		internal IList GetList()
		{
			IList list = new ArrayList();
			for (int i = 0; i < m_tables.Length; i++)
			{
				IMetadataTable metadataTable = m_tables[i];
				if (metadataTable != null)
				{
					list.Add(metadataTable);
				}
			}
			return list;
		}

		public IEnumerator GetEnumerator()
		{
			return GetList().GetEnumerator();
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitTableCollection(this);
			foreach (IMetadataTable item in GetList())
			{
				item.Accept(visitor);
			}
			visitor.TerminateTableCollection(this);
		}
	}
}
