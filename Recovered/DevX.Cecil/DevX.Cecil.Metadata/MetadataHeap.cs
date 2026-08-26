using System;

namespace DevX.Cecil.Metadata
{
	public abstract class MetadataHeap : IMetadataVisitable
	{
		private MetadataStream m_stream;

		private string m_name;

		private byte[] m_data;

		public int IndexSize;

		public string Name => m_name;

		public byte[] Data
		{
			get
			{
				return m_data;
			}
			set
			{
				m_data = value;
			}
		}

		internal MetadataHeap(MetadataStream stream, string name)
		{
			m_name = name;
			m_stream = stream;
		}

		public static MetadataHeap HeapFactory(MetadataStream stream)
		{
			switch (stream.Header.Name)
			{
			case "#~":
			case "#-":
				return new TablesHeap(stream);
			case "#GUID":
				return new GuidHeap(stream);
			case "#Strings":
				return new StringsHeap(stream);
			case "#US":
				return new UserStringsHeap(stream);
			case "#Blob":
				return new BlobHeap(stream);
			default:
				return null;
			}
		}

		public MetadataStream GetStream()
		{
			return m_stream;
		}

		protected virtual byte[] ReadBytesFromStream(uint pos)
		{
			int start;
			int num = Utilities.ReadCompressedInteger(m_data, (int)pos, out start);
			byte[] array = new byte[num];
			Buffer.BlockCopy(m_data, start, array, 0, num);
			return array;
		}

		public abstract void Accept(IMetadataVisitor visitor);
	}
}
