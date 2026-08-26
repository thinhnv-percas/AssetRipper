using System.IO;

namespace DevX.Cecil.Metadata
{
	internal sealed class MetadataTableReader : BaseMetadataTableVisitor
	{
		private MetadataRoot m_metadataRoot;

		private TablesHeap m_heap;

		private MetadataRowReader m_mrrv;

		private BinaryReader m_binaryReader;

		private int[] m_rows = new int[45];

		public MetadataTableReader(MetadataReader mrv)
		{
			m_metadataRoot = mrv.GetMetadataRoot();
			m_heap = m_metadataRoot.Streams.TablesHeap;
			m_binaryReader = new BinaryReader(new MemoryStream(m_heap.Data));
			m_binaryReader.BaseStream.Position = 24L;
			m_mrrv = new MetadataRowReader(this);
		}

		public MetadataRoot GetMetadataRoot()
		{
			return m_metadataRoot;
		}

		public BinaryReader GetReader()
		{
			return m_binaryReader;
		}

		public override IMetadataRowVisitor GetRowVisitor()
		{
			return m_mrrv;
		}

		public int GetNumberOfRows(int rid)
		{
			return m_rows[rid];
		}

		public AssemblyTable GetAssemblyTable()
		{
			return (AssemblyTable)m_heap[32];
		}

		public AssemblyOSTable GetAssemblyOSTable()
		{
			return (AssemblyOSTable)m_heap[34];
		}

		public AssemblyProcessorTable GetAssemblyProcessorTable()
		{
			return (AssemblyProcessorTable)m_heap[33];
		}

		public AssemblyRefTable GetAssemblyRefTable()
		{
			return (AssemblyRefTable)m_heap[35];
		}

		public AssemblyRefOSTable GetAssemblyRefOSTable()
		{
			return (AssemblyRefOSTable)m_heap[37];
		}

		public AssemblyRefProcessorTable GetAssemblyRefProcessorTable()
		{
			return (AssemblyRefProcessorTable)m_heap[36];
		}

		public ClassLayoutTable GetClassLayoutTable()
		{
			return (ClassLayoutTable)m_heap[15];
		}

		public ConstantTable GetConstantTable()
		{
			return (ConstantTable)m_heap[11];
		}

		public CustomAttributeTable GetCustomAttributeTable()
		{
			return (CustomAttributeTable)m_heap[12];
		}

		public DeclSecurityTable GetDeclSecurityTable()
		{
			return (DeclSecurityTable)m_heap[14];
		}

		public EventTable GetEventTable()
		{
			return (EventTable)m_heap[20];
		}

		public EventMapTable GetEventMapTable()
		{
			return (EventMapTable)m_heap[18];
		}

		public EventPtrTable GetEventPtrTable()
		{
			return (EventPtrTable)m_heap[19];
		}

		public ExportedTypeTable GetExportedTypeTable()
		{
			return (ExportedTypeTable)m_heap[39];
		}

		public FieldTable GetFieldTable()
		{
			return (FieldTable)m_heap[4];
		}

		public FieldLayoutTable GetFieldLayoutTable()
		{
			return (FieldLayoutTable)m_heap[16];
		}

		public FieldMarshalTable GetFieldMarshalTable()
		{
			return (FieldMarshalTable)m_heap[13];
		}

		public FieldPtrTable GetFieldPtrTable()
		{
			return (FieldPtrTable)m_heap[3];
		}

		public FieldRVATable GetFieldRVATable()
		{
			return (FieldRVATable)m_heap[29];
		}

		public FileTable GetFileTable()
		{
			return (FileTable)m_heap[38];
		}

		public GenericParamTable GetGenericParamTable()
		{
			return (GenericParamTable)m_heap[42];
		}

		public GenericParamConstraintTable GetGenericParamConstraintTable()
		{
			return (GenericParamConstraintTable)m_heap[44];
		}

		public ImplMapTable GetImplMapTable()
		{
			return (ImplMapTable)m_heap[28];
		}

		public InterfaceImplTable GetInterfaceImplTable()
		{
			return (InterfaceImplTable)m_heap[9];
		}

		public ManifestResourceTable GetManifestResourceTable()
		{
			return (ManifestResourceTable)m_heap[40];
		}

		public MemberRefTable GetMemberRefTable()
		{
			return (MemberRefTable)m_heap[10];
		}

		public MethodTable GetMethodTable()
		{
			return (MethodTable)m_heap[6];
		}

		public MethodImplTable GetMethodImplTable()
		{
			return (MethodImplTable)m_heap[25];
		}

		public MethodPtrTable GetMethodPtrTable()
		{
			return (MethodPtrTable)m_heap[5];
		}

		public MethodSemanticsTable GetMethodSemanticsTable()
		{
			return (MethodSemanticsTable)m_heap[24];
		}

		public MethodSpecTable GetMethodSpecTable()
		{
			return (MethodSpecTable)m_heap[43];
		}

		public ModuleTable GetModuleTable()
		{
			return (ModuleTable)m_heap[0];
		}

		public ModuleRefTable GetModuleRefTable()
		{
			return (ModuleRefTable)m_heap[26];
		}

		public NestedClassTable GetNestedClassTable()
		{
			return (NestedClassTable)m_heap[41];
		}

		public ParamTable GetParamTable()
		{
			return (ParamTable)m_heap[8];
		}

		public ParamPtrTable GetParamPtrTable()
		{
			return (ParamPtrTable)m_heap[7];
		}

		public PropertyTable GetPropertyTable()
		{
			return (PropertyTable)m_heap[23];
		}

		public PropertyMapTable GetPropertyMapTable()
		{
			return (PropertyMapTable)m_heap[21];
		}

		public PropertyPtrTable GetPropertyPtrTable()
		{
			return (PropertyPtrTable)m_heap[22];
		}

		public StandAloneSigTable GetStandAloneSigTable()
		{
			return (StandAloneSigTable)m_heap[17];
		}

		public TypeDefTable GetTypeDefTable()
		{
			return (TypeDefTable)m_heap[2];
		}

		public TypeRefTable GetTypeRefTable()
		{
			return (TypeRefTable)m_heap[1];
		}

		public TypeSpecTable GetTypeSpecTable()
		{
			return (TypeSpecTable)m_heap[27];
		}

		public override void VisitTableCollection(TableCollection coll)
		{
			if (m_heap.HasTable(0))
			{
				coll.Add(new ModuleTable());
				m_rows[0] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(1))
			{
				coll.Add(new TypeRefTable());
				m_rows[1] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(2))
			{
				coll.Add(new TypeDefTable());
				m_rows[2] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(3))
			{
				coll.Add(new FieldPtrTable());
				m_rows[3] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(4))
			{
				coll.Add(new FieldTable());
				m_rows[4] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(5))
			{
				coll.Add(new MethodPtrTable());
				m_rows[5] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(6))
			{
				coll.Add(new MethodTable());
				m_rows[6] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(7))
			{
				coll.Add(new ParamPtrTable());
				m_rows[7] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(8))
			{
				coll.Add(new ParamTable());
				m_rows[8] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(9))
			{
				coll.Add(new InterfaceImplTable());
				m_rows[9] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(10))
			{
				coll.Add(new MemberRefTable());
				m_rows[10] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(11))
			{
				coll.Add(new ConstantTable());
				m_rows[11] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(12))
			{
				coll.Add(new CustomAttributeTable());
				m_rows[12] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(13))
			{
				coll.Add(new FieldMarshalTable());
				m_rows[13] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(14))
			{
				coll.Add(new DeclSecurityTable());
				m_rows[14] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(15))
			{
				coll.Add(new ClassLayoutTable());
				m_rows[15] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(16))
			{
				coll.Add(new FieldLayoutTable());
				m_rows[16] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(17))
			{
				coll.Add(new StandAloneSigTable());
				m_rows[17] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(18))
			{
				coll.Add(new EventMapTable());
				m_rows[18] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(19))
			{
				coll.Add(new EventPtrTable());
				m_rows[19] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(20))
			{
				coll.Add(new EventTable());
				m_rows[20] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(21))
			{
				coll.Add(new PropertyMapTable());
				m_rows[21] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(22))
			{
				coll.Add(new PropertyPtrTable());
				m_rows[22] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(23))
			{
				coll.Add(new PropertyTable());
				m_rows[23] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(24))
			{
				coll.Add(new MethodSemanticsTable());
				m_rows[24] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(25))
			{
				coll.Add(new MethodImplTable());
				m_rows[25] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(26))
			{
				coll.Add(new ModuleRefTable());
				m_rows[26] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(27))
			{
				coll.Add(new TypeSpecTable());
				m_rows[27] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(28))
			{
				coll.Add(new ImplMapTable());
				m_rows[28] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(29))
			{
				coll.Add(new FieldRVATable());
				m_rows[29] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(32))
			{
				coll.Add(new AssemblyTable());
				m_rows[32] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(33))
			{
				coll.Add(new AssemblyProcessorTable());
				m_rows[33] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(34))
			{
				coll.Add(new AssemblyOSTable());
				m_rows[34] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(35))
			{
				coll.Add(new AssemblyRefTable());
				m_rows[35] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(36))
			{
				coll.Add(new AssemblyRefProcessorTable());
				m_rows[36] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(37))
			{
				coll.Add(new AssemblyRefOSTable());
				m_rows[37] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(38))
			{
				coll.Add(new FileTable());
				m_rows[38] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(39))
			{
				coll.Add(new ExportedTypeTable());
				m_rows[39] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(40))
			{
				coll.Add(new ManifestResourceTable());
				m_rows[40] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(41))
			{
				coll.Add(new NestedClassTable());
				m_rows[41] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(42))
			{
				coll.Add(new GenericParamTable());
				m_rows[42] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(43))
			{
				coll.Add(new MethodSpecTable());
				m_rows[43] = m_binaryReader.ReadInt32();
			}
			if (m_heap.HasTable(44))
			{
				coll.Add(new GenericParamConstraintTable());
				m_rows[44] = m_binaryReader.ReadInt32();
			}
		}

		public override void VisitAssemblyTable(AssemblyTable table)
		{
			int num = m_rows[32];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new AssemblyRow());
			}
		}

		public override void VisitAssemblyOSTable(AssemblyOSTable table)
		{
			int num = m_rows[34];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new AssemblyOSRow());
			}
		}

		public override void VisitAssemblyProcessorTable(AssemblyProcessorTable table)
		{
			int num = m_rows[33];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new AssemblyProcessorRow());
			}
		}

		public override void VisitAssemblyRefTable(AssemblyRefTable table)
		{
			int num = m_rows[35];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new AssemblyRefRow());
			}
		}

		public override void VisitAssemblyRefOSTable(AssemblyRefOSTable table)
		{
			int num = m_rows[37];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new AssemblyRefOSRow());
			}
		}

		public override void VisitAssemblyRefProcessorTable(AssemblyRefProcessorTable table)
		{
			int num = m_rows[36];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new AssemblyRefProcessorRow());
			}
		}

		public override void VisitClassLayoutTable(ClassLayoutTable table)
		{
			int num = m_rows[15];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new ClassLayoutRow());
			}
		}

		public override void VisitConstantTable(ConstantTable table)
		{
			int num = m_rows[11];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new ConstantRow());
			}
		}

		public override void VisitCustomAttributeTable(CustomAttributeTable table)
		{
			int num = m_rows[12];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new CustomAttributeRow());
			}
		}

		public override void VisitDeclSecurityTable(DeclSecurityTable table)
		{
			int num = m_rows[14];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new DeclSecurityRow());
			}
		}

		public override void VisitEventTable(EventTable table)
		{
			int num = m_rows[20];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new EventRow());
			}
		}

		public override void VisitEventMapTable(EventMapTable table)
		{
			int num = m_rows[18];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new EventMapRow());
			}
		}

		public override void VisitEventPtrTable(EventPtrTable table)
		{
			int num = m_rows[19];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new EventPtrRow());
			}
		}

		public override void VisitExportedTypeTable(ExportedTypeTable table)
		{
			int num = m_rows[39];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new ExportedTypeRow());
			}
		}

		public override void VisitFieldTable(FieldTable table)
		{
			int num = m_rows[4];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new FieldRow());
			}
		}

		public override void VisitFieldLayoutTable(FieldLayoutTable table)
		{
			int num = m_rows[16];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new FieldLayoutRow());
			}
		}

		public override void VisitFieldMarshalTable(FieldMarshalTable table)
		{
			int num = m_rows[13];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new FieldMarshalRow());
			}
		}

		public override void VisitFieldPtrTable(FieldPtrTable table)
		{
			int num = m_rows[3];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new FieldPtrRow());
			}
		}

		public override void VisitFieldRVATable(FieldRVATable table)
		{
			int num = m_rows[29];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new FieldRVARow());
			}
		}

		public override void VisitFileTable(FileTable table)
		{
			int num = m_rows[38];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new FileRow());
			}
		}

		public override void VisitGenericParamTable(GenericParamTable table)
		{
			int num = m_rows[42];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new GenericParamRow());
			}
		}

		public override void VisitGenericParamConstraintTable(GenericParamConstraintTable table)
		{
			int num = m_rows[44];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new GenericParamConstraintRow());
			}
		}

		public override void VisitImplMapTable(ImplMapTable table)
		{
			int num = m_rows[28];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new ImplMapRow());
			}
		}

		public override void VisitInterfaceImplTable(InterfaceImplTable table)
		{
			int num = m_rows[9];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new InterfaceImplRow());
			}
		}

		public override void VisitManifestResourceTable(ManifestResourceTable table)
		{
			int num = m_rows[40];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new ManifestResourceRow());
			}
		}

		public override void VisitMemberRefTable(MemberRefTable table)
		{
			int num = m_rows[10];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new MemberRefRow());
			}
		}

		public override void VisitMethodTable(MethodTable table)
		{
			int num = m_rows[6];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new MethodRow());
			}
		}

		public override void VisitMethodImplTable(MethodImplTable table)
		{
			int num = m_rows[25];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new MethodImplRow());
			}
		}

		public override void VisitMethodPtrTable(MethodPtrTable table)
		{
			int num = m_rows[5];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new MethodPtrRow());
			}
		}

		public override void VisitMethodSemanticsTable(MethodSemanticsTable table)
		{
			int num = m_rows[24];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new MethodSemanticsRow());
			}
		}

		public override void VisitMethodSpecTable(MethodSpecTable table)
		{
			int num = m_rows[43];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new MethodSpecRow());
			}
		}

		public override void VisitModuleTable(ModuleTable table)
		{
			int num = m_rows[0];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new ModuleRow());
			}
		}

		public override void VisitModuleRefTable(ModuleRefTable table)
		{
			int num = m_rows[26];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new ModuleRefRow());
			}
		}

		public override void VisitNestedClassTable(NestedClassTable table)
		{
			int num = m_rows[41];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new NestedClassRow());
			}
		}

		public override void VisitParamTable(ParamTable table)
		{
			int num = m_rows[8];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new ParamRow());
			}
		}

		public override void VisitParamPtrTable(ParamPtrTable table)
		{
			int num = m_rows[7];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new ParamPtrRow());
			}
		}

		public override void VisitPropertyTable(PropertyTable table)
		{
			int num = m_rows[23];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new PropertyRow());
			}
		}

		public override void VisitPropertyMapTable(PropertyMapTable table)
		{
			int num = m_rows[21];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new PropertyMapRow());
			}
		}

		public override void VisitPropertyPtrTable(PropertyPtrTable table)
		{
			int num = m_rows[22];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new PropertyPtrRow());
			}
		}

		public override void VisitStandAloneSigTable(StandAloneSigTable table)
		{
			int num = m_rows[17];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new StandAloneSigRow());
			}
		}

		public override void VisitTypeDefTable(TypeDefTable table)
		{
			int num = m_rows[2];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new TypeDefRow());
			}
		}

		public override void VisitTypeRefTable(TypeRefTable table)
		{
			int num = m_rows[1];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new TypeRefRow());
			}
		}

		public override void VisitTypeSpecTable(TypeSpecTable table)
		{
			int num = m_rows[27];
			table.Rows = new RowCollection(num);
			for (int i = 0; i < num; i++)
			{
				table.Rows.Add(new TypeSpecRow());
			}
		}
	}
}
