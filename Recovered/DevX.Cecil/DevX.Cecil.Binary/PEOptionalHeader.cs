namespace DevX.Cecil.Binary
{
	public sealed class PEOptionalHeader : IBinaryVisitable, IHeader
	{
		public sealed class StandardFieldsHeader : IBinaryVisitable, IHeader
		{
			public ushort Magic;

			public byte LMajor;

			public byte LMinor;

			public uint CodeSize;

			public uint InitializedDataSize;

			public uint UninitializedDataSize;

			public RVA EntryPointRVA;

			public RVA BaseOfCode;

			public RVA BaseOfData;

			public bool IsPE64
			{
				get
				{
					return Magic == 523;
				}
				set
				{
					if (value)
					{
						Magic = 523;
					}
					else
					{
						Magic = 267;
					}
				}
			}

			internal StandardFieldsHeader()
			{
			}

			public void SetDefaultValues()
			{
				Magic = 267;
				LMajor = 6;
				LMinor = 0;
			}

			public void Accept(IBinaryVisitor visitor)
			{
				visitor.VisitStandardFieldsHeader(this);
			}
		}

		public sealed class NTSpecificFieldsHeader : IBinaryVisitable, IHeader
		{
			public ulong ImageBase;

			public uint SectionAlignment;

			public uint FileAlignment;

			public ushort OSMajor;

			public ushort OSMinor;

			public ushort UserMajor;

			public ushort UserMinor;

			public ushort SubSysMajor;

			public ushort SubSysMinor;

			public uint Reserved;

			public uint ImageSize;

			public uint HeaderSize;

			public uint FileChecksum;

			public SubSystem SubSystem;

			public ushort DLLFlags;

			public ulong StackReserveSize;

			public ulong StackCommitSize;

			public ulong HeapReserveSize;

			public ulong HeapCommitSize;

			public uint LoaderFlags;

			public uint NumberOfDataDir;

			internal NTSpecificFieldsHeader()
			{
			}

			public void SetDefaultValues()
			{
				ImageBase = 4194304uL;
				SectionAlignment = 8192u;
				FileAlignment = 512u;
				OSMajor = 4;
				OSMinor = 0;
				UserMajor = 0;
				UserMinor = 0;
				SubSysMajor = 4;
				SubSysMinor = 0;
				Reserved = 0u;
				HeaderSize = 512u;
				FileChecksum = 0u;
				DLLFlags = 0;
				StackReserveSize = 1048576uL;
				StackCommitSize = 4096uL;
				HeapReserveSize = 1048576uL;
				HeapCommitSize = 4096uL;
				LoaderFlags = 0u;
				NumberOfDataDir = 16u;
			}

			public void Accept(IBinaryVisitor visitor)
			{
				visitor.VisitNTSpecificFieldsHeader(this);
			}
		}

		public sealed class DataDirectoriesHeader : IBinaryVisitable, IHeader
		{
			public DataDirectory ExportTable;

			public DataDirectory ImportTable;

			public DataDirectory ResourceTable;

			public DataDirectory ExceptionTable;

			public DataDirectory CertificateTable;

			public DataDirectory BaseRelocationTable;

			public DataDirectory Debug;

			public DataDirectory Copyright;

			public DataDirectory GlobalPtr;

			public DataDirectory TLSTable;

			public DataDirectory LoadConfigTable;

			public DataDirectory BoundImport;

			public DataDirectory IAT;

			public DataDirectory DelayImportDescriptor;

			public DataDirectory CLIHeader;

			public DataDirectory Reserved;

			internal DataDirectoriesHeader()
			{
			}

			public void SetDefaultValues()
			{
				ExportTable = DataDirectory.Zero;
				ResourceTable = DataDirectory.Zero;
				ExceptionTable = DataDirectory.Zero;
				CertificateTable = DataDirectory.Zero;
				Debug = DataDirectory.Zero;
				Copyright = DataDirectory.Zero;
				GlobalPtr = DataDirectory.Zero;
				TLSTable = DataDirectory.Zero;
				LoadConfigTable = DataDirectory.Zero;
				BoundImport = DataDirectory.Zero;
				IAT = new DataDirectory(new RVA(8192u), 8u);
				DelayImportDescriptor = DataDirectory.Zero;
				CLIHeader = new DataDirectory(new RVA(8200u), 72u);
				Reserved = DataDirectory.Zero;
			}

			public void Accept(IBinaryVisitor visitor)
			{
				visitor.VisitDataDirectoriesHeader(this);
			}
		}

		public StandardFieldsHeader StandardFields;

		public NTSpecificFieldsHeader NTSpecificFields;

		public DataDirectoriesHeader DataDirectories;

		internal PEOptionalHeader()
		{
			StandardFields = new StandardFieldsHeader();
			NTSpecificFields = new NTSpecificFieldsHeader();
			DataDirectories = new DataDirectoriesHeader();
		}

		public void SetDefaultValues()
		{
		}

		public void Accept(IBinaryVisitor visitor)
		{
			visitor.VisitPEOptionalHeader(this);
			StandardFields.Accept(visitor);
			NTSpecificFields.Accept(visitor);
			DataDirectories.Accept(visitor);
		}
	}
}
