using System;
using System.Collections;

namespace DevX.Cecil.Metadata
{
	public class MetadataStreamCollection : IEnumerable, ICollection, IMetadataVisitable
	{
		private IList m_items;

		private BlobHeap m_blobHeap;

		private GuidHeap m_guidHeap;

		private StringsHeap m_stringsHeap;

		private UserStringsHeap m_usHeap;

		private TablesHeap m_tablesHeap;

		public MetadataStream this[int index]
		{
			get
			{
				return m_items[index] as MetadataStream;
			}
			set
			{
				m_items[index] = value;
			}
		}

		public int Count => m_items.Count;

		public bool IsSynchronized => false;

		public object SyncRoot => this;

		public BlobHeap BlobHeap
		{
			get
			{
				if (m_blobHeap == null)
				{
					m_blobHeap = (GetHeap("#Blob") as BlobHeap);
				}
				return m_blobHeap;
			}
		}

		public GuidHeap GuidHeap
		{
			get
			{
				if (m_guidHeap == null)
				{
					m_guidHeap = (GetHeap("#GUID") as GuidHeap);
				}
				return m_guidHeap;
			}
		}

		public StringsHeap StringsHeap
		{
			get
			{
				if (m_stringsHeap == null)
				{
					m_stringsHeap = (GetHeap("#Strings") as StringsHeap);
				}
				return m_stringsHeap;
			}
		}

		public TablesHeap TablesHeap
		{
			get
			{
				if (m_tablesHeap == null)
				{
					m_tablesHeap = (GetHeap("#~") as TablesHeap);
				}
				return m_tablesHeap;
			}
		}

		public UserStringsHeap UserStringsHeap
		{
			get
			{
				if (m_usHeap == null)
				{
					m_usHeap = (GetHeap("#US") as UserStringsHeap);
				}
				return m_usHeap;
			}
		}

		public MetadataStreamCollection()
		{
			m_items = new ArrayList(5);
		}

		private MetadataHeap GetHeap(string name)
		{
			for (int i = 0; i < m_items.Count; i++)
			{
				MetadataStream metadataStream = m_items[i] as MetadataStream;
				if (metadataStream.Heap.Name == name)
				{
					return metadataStream.Heap;
				}
			}
			return null;
		}

		internal void Add(MetadataStream value)
		{
			m_items.Add(value);
		}

		internal void Remove(MetadataStream value)
		{
			m_items.Remove(value);
		}

		public void CopyTo(Array ary, int index)
		{
			m_items.CopyTo(ary, index);
		}

		public IEnumerator GetEnumerator()
		{
			return m_items.GetEnumerator();
		}

		public void Accept(IMetadataVisitor visitor)
		{
			visitor.VisitMetadataStreamCollection(this);
			for (int i = 0; i < m_items.Count; i++)
			{
				this[i].Accept(visitor);
			}
		}
	}
}
