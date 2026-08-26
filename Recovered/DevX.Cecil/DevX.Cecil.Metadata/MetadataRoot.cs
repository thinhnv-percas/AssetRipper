using DevX.Cecil.Binary;

namespace DevX.Cecil.Metadata
{
	public sealed class MetadataRoot : IMetadataVisitable
	{
		public sealed class MetadataRootHeader : IHeader, IMetadataVisitable
		{
			public const uint StandardSignature = 1112167234u;

			public uint Signature;

			public ushort MinorVersion;

			public ushort MajorVersion;

			public uint Reserved;

			public string Version;

			public ushort Flags;

			public ushort Streams;

			internal MetadataRootHeader()
			{
			}

			public void SetDefaultValues()
			{
				Signature = 1112167234u;
				Reserved = 0u;
				Flags = 0;
			}

			public void Accept(IMetadataVisitor visitor)
			{
				visitor.VisitMetadataRootHeader(this);
			}
		}

		private MetadataRootHeader m_header;

		private Image m_image;

		private MetadataStreamCollection m_streams;

		public MetadataRootHeader Header
		{
			get
			{
				return m_header;
			}
			set
			{
				m_header = value;
			}
		}

		public MetadataStreamCollection Streams
		{
			get
			{
				return m_streams;
			}
			set
			{
				m_streams = value;
			}
		}

		internal MetadataRoot(Image img)
		{
			m_image = img;
		}

		public Image GetImage()
		{
			return m_image;
		}

		public void Accept(IMetadataVisitor visitor)
		{
			visitor.VisitMetadataRoot(this);
			m_header.Accept(visitor);
			m_streams.Accept(visitor);
			visitor.TerminateMetadataRoot(this);
		}
	}
}
