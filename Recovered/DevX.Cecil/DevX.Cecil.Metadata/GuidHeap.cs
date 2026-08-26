using System;
using System.Collections;

namespace DevX.Cecil.Metadata
{
	public class GuidHeap : MetadataHeap
	{
		private readonly IDictionary m_guids;

		public IDictionary Guids => m_guids;

		public Guid this[uint index]
		{
			get
			{
				if (index == 0)
				{
					return new Guid(new byte[16]);
				}
				int num = (int)(index - 1);
				if (m_guids.Contains(num))
				{
					return (Guid)m_guids[num];
				}
				if (num + 16 > base.Data.Length)
				{
					throw new IndexOutOfRangeException();
				}
				byte[] array = null;
				if (base.Data.Length == 16)
				{
					array = base.Data;
				}
				else
				{
					array = new byte[16];
					Buffer.BlockCopy(base.Data, num, array, 0, 16);
				}
				Guid guid = new Guid(array);
				m_guids[num] = guid;
				return guid;
			}
			set
			{
				m_guids[index] = value;
			}
		}

		public GuidHeap(MetadataStream stream)
			: base(stream, "#GUID")
		{
			int capacity = (int)(stream.Header.Size / 16u);
			m_guids = new Hashtable(capacity);
		}

		public override void Accept(IMetadataVisitor visitor)
		{
			visitor.VisitGuidHeap(this);
		}
	}
}
