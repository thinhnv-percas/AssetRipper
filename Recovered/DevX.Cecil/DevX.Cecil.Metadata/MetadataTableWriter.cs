using DevX.Cecil.Binary;

namespace DevX.Cecil.Metadata
{
	internal sealed class MetadataTableWriter : BaseMetadataTableVisitor
	{
		private MetadataRoot m_root;

		private TablesHeap m_heap;

		private MetadataRowWriter m_mrrw;

		private MemoryBinaryWriter m_binaryWriter;

		public MetadataTableWriter(MetadataWriter mrv, MemoryBinaryWriter writer)
		{
			m_root = mrv.GetMetadataRoot();
			m_heap = m_root.Streams.TablesHeap;
			m_binaryWriter = writer;
			m_mrrw = new MetadataRowWriter(this);
		}

		public MetadataRoot GetMetadataRoot()
		{
			return m_root;
		}

		public override IMetadataRowVisitor GetRowVisitor()
		{
			return m_mrrw;
		}

		public MemoryBinaryWriter GetWriter()
		{
			return m_binaryWriter;
		}

		private void InitializeTable(IMetadataTable table)
		{
			table.Rows = new RowCollection();
			m_heap.Valid |= 1L << table.Id;
			m_heap.Tables.Add(table);
		}

		private void WriteCount(int rid)
		{
			if (m_heap.HasTable(rid))
			{
				m_binaryWriter.Write(m_heap[rid].Rows.Count);
			}
		}

		public AssemblyTable GetAssemblyTable()
		{
			AssemblyTable assemblyTable = m_heap[32] as AssemblyTable;
			if (assemblyTable != null)
			{
				return assemblyTable;
			}
			assemblyTable = new AssemblyTable();
			InitializeTable(assemblyTable);
			return assemblyTable;
		}

		public AssemblyOSTable GetAssemblyOSTable()
		{
			AssemblyOSTable assemblyOSTable = m_heap[34] as AssemblyOSTable;
			if (assemblyOSTable != null)
			{
				return assemblyOSTable;
			}
			assemblyOSTable = new AssemblyOSTable();
			InitializeTable(assemblyOSTable);
			return assemblyOSTable;
		}

		public AssemblyProcessorTable GetAssemblyProcessorTable()
		{
			AssemblyProcessorTable assemblyProcessorTable = m_heap[33] as AssemblyProcessorTable;
			if (assemblyProcessorTable != null)
			{
				return assemblyProcessorTable;
			}
			assemblyProcessorTable = new AssemblyProcessorTable();
			InitializeTable(assemblyProcessorTable);
			return assemblyProcessorTable;
		}

		public AssemblyRefTable GetAssemblyRefTable()
		{
			AssemblyRefTable assemblyRefTable = m_heap[35] as AssemblyRefTable;
			if (assemblyRefTable != null)
			{
				return assemblyRefTable;
			}
			assemblyRefTable = new AssemblyRefTable();
			InitializeTable(assemblyRefTable);
			return assemblyRefTable;
		}

		public AssemblyRefOSTable GetAssemblyRefOSTable()
		{
			AssemblyRefOSTable assemblyRefOSTable = m_heap[37] as AssemblyRefOSTable;
			if (assemblyRefOSTable != null)
			{
				return assemblyRefOSTable;
			}
			assemblyRefOSTable = new AssemblyRefOSTable();
			InitializeTable(assemblyRefOSTable);
			return assemblyRefOSTable;
		}

		public AssemblyRefProcessorTable GetAssemblyRefProcessorTable()
		{
			AssemblyRefProcessorTable assemblyRefProcessorTable = m_heap[36] as AssemblyRefProcessorTable;
			if (assemblyRefProcessorTable != null)
			{
				return assemblyRefProcessorTable;
			}
			assemblyRefProcessorTable = new AssemblyRefProcessorTable();
			InitializeTable(assemblyRefProcessorTable);
			return assemblyRefProcessorTable;
		}

		public ClassLayoutTable GetClassLayoutTable()
		{
			ClassLayoutTable classLayoutTable = m_heap[15] as ClassLayoutTable;
			if (classLayoutTable != null)
			{
				return classLayoutTable;
			}
			classLayoutTable = new ClassLayoutTable();
			InitializeTable(classLayoutTable);
			return classLayoutTable;
		}

		public ConstantTable GetConstantTable()
		{
			ConstantTable constantTable = m_heap[11] as ConstantTable;
			if (constantTable != null)
			{
				return constantTable;
			}
			constantTable = new ConstantTable();
			InitializeTable(constantTable);
			return constantTable;
		}

		public CustomAttributeTable GetCustomAttributeTable()
		{
			CustomAttributeTable customAttributeTable = m_heap[12] as CustomAttributeTable;
			if (customAttributeTable != null)
			{
				return customAttributeTable;
			}
			customAttributeTable = new CustomAttributeTable();
			InitializeTable(customAttributeTable);
			return customAttributeTable;
		}

		public DeclSecurityTable GetDeclSecurityTable()
		{
			DeclSecurityTable declSecurityTable = m_heap[14] as DeclSecurityTable;
			if (declSecurityTable != null)
			{
				return declSecurityTable;
			}
			declSecurityTable = new DeclSecurityTable();
			InitializeTable(declSecurityTable);
			return declSecurityTable;
		}

		public EventTable GetEventTable()
		{
			EventTable eventTable = m_heap[20] as EventTable;
			if (eventTable != null)
			{
				return eventTable;
			}
			eventTable = new EventTable();
			InitializeTable(eventTable);
			return eventTable;
		}

		public EventMapTable GetEventMapTable()
		{
			EventMapTable eventMapTable = m_heap[18] as EventMapTable;
			if (eventMapTable != null)
			{
				return eventMapTable;
			}
			eventMapTable = new EventMapTable();
			InitializeTable(eventMapTable);
			return eventMapTable;
		}

		public EventPtrTable GetEventPtrTable()
		{
			EventPtrTable eventPtrTable = m_heap[19] as EventPtrTable;
			if (eventPtrTable != null)
			{
				return eventPtrTable;
			}
			eventPtrTable = new EventPtrTable();
			InitializeTable(eventPtrTable);
			return eventPtrTable;
		}

		public ExportedTypeTable GetExportedTypeTable()
		{
			ExportedTypeTable exportedTypeTable = m_heap[39] as ExportedTypeTable;
			if (exportedTypeTable != null)
			{
				return exportedTypeTable;
			}
			exportedTypeTable = new ExportedTypeTable();
			InitializeTable(exportedTypeTable);
			return exportedTypeTable;
		}

		public FieldTable GetFieldTable()
		{
			FieldTable fieldTable = m_heap[4] as FieldTable;
			if (fieldTable != null)
			{
				return fieldTable;
			}
			fieldTable = new FieldTable();
			InitializeTable(fieldTable);
			return fieldTable;
		}

		public FieldLayoutTable GetFieldLayoutTable()
		{
			FieldLayoutTable fieldLayoutTable = m_heap[16] as FieldLayoutTable;
			if (fieldLayoutTable != null)
			{
				return fieldLayoutTable;
			}
			fieldLayoutTable = new FieldLayoutTable();
			InitializeTable(fieldLayoutTable);
			return fieldLayoutTable;
		}

		public FieldMarshalTable GetFieldMarshalTable()
		{
			FieldMarshalTable fieldMarshalTable = m_heap[13] as FieldMarshalTable;
			if (fieldMarshalTable != null)
			{
				return fieldMarshalTable;
			}
			fieldMarshalTable = new FieldMarshalTable();
			InitializeTable(fieldMarshalTable);
			return fieldMarshalTable;
		}

		public FieldPtrTable GetFieldPtrTable()
		{
			FieldPtrTable fieldPtrTable = m_heap[3] as FieldPtrTable;
			if (fieldPtrTable != null)
			{
				return fieldPtrTable;
			}
			fieldPtrTable = new FieldPtrTable();
			InitializeTable(fieldPtrTable);
			return fieldPtrTable;
		}

		public FieldRVATable GetFieldRVATable()
		{
			FieldRVATable fieldRVATable = m_heap[29] as FieldRVATable;
			if (fieldRVATable != null)
			{
				return fieldRVATable;
			}
			fieldRVATable = new FieldRVATable();
			InitializeTable(fieldRVATable);
			return fieldRVATable;
		}

		public FileTable GetFileTable()
		{
			FileTable fileTable = m_heap[38] as FileTable;
			if (fileTable != null)
			{
				return fileTable;
			}
			fileTable = new FileTable();
			InitializeTable(fileTable);
			return fileTable;
		}

		public GenericParamTable GetGenericParamTable()
		{
			GenericParamTable genericParamTable = m_heap[42] as GenericParamTable;
			if (genericParamTable != null)
			{
				return genericParamTable;
			}
			genericParamTable = new GenericParamTable();
			InitializeTable(genericParamTable);
			return genericParamTable;
		}

		public GenericParamConstraintTable GetGenericParamConstraintTable()
		{
			GenericParamConstraintTable genericParamConstraintTable = m_heap[44] as GenericParamConstraintTable;
			if (genericParamConstraintTable != null)
			{
				return genericParamConstraintTable;
			}
			genericParamConstraintTable = new GenericParamConstraintTable();
			InitializeTable(genericParamConstraintTable);
			return genericParamConstraintTable;
		}

		public ImplMapTable GetImplMapTable()
		{
			ImplMapTable implMapTable = m_heap[28] as ImplMapTable;
			if (implMapTable != null)
			{
				return implMapTable;
			}
			implMapTable = new ImplMapTable();
			InitializeTable(implMapTable);
			return implMapTable;
		}

		public InterfaceImplTable GetInterfaceImplTable()
		{
			InterfaceImplTable interfaceImplTable = m_heap[9] as InterfaceImplTable;
			if (interfaceImplTable != null)
			{
				return interfaceImplTable;
			}
			interfaceImplTable = new InterfaceImplTable();
			InitializeTable(interfaceImplTable);
			return interfaceImplTable;
		}

		public ManifestResourceTable GetManifestResourceTable()
		{
			ManifestResourceTable manifestResourceTable = m_heap[40] as ManifestResourceTable;
			if (manifestResourceTable != null)
			{
				return manifestResourceTable;
			}
			manifestResourceTable = new ManifestResourceTable();
			InitializeTable(manifestResourceTable);
			return manifestResourceTable;
		}

		public MemberRefTable GetMemberRefTable()
		{
			MemberRefTable memberRefTable = m_heap[10] as MemberRefTable;
			if (memberRefTable != null)
			{
				return memberRefTable;
			}
			memberRefTable = new MemberRefTable();
			InitializeTable(memberRefTable);
			return memberRefTable;
		}

		public MethodTable GetMethodTable()
		{
			MethodTable methodTable = m_heap[6] as MethodTable;
			if (methodTable != null)
			{
				return methodTable;
			}
			methodTable = new MethodTable();
			InitializeTable(methodTable);
			return methodTable;
		}

		public MethodImplTable GetMethodImplTable()
		{
			MethodImplTable methodImplTable = m_heap[25] as MethodImplTable;
			if (methodImplTable != null)
			{
				return methodImplTable;
			}
			methodImplTable = new MethodImplTable();
			InitializeTable(methodImplTable);
			return methodImplTable;
		}

		public MethodPtrTable GetMethodPtrTable()
		{
			MethodPtrTable methodPtrTable = m_heap[5] as MethodPtrTable;
			if (methodPtrTable != null)
			{
				return methodPtrTable;
			}
			methodPtrTable = new MethodPtrTable();
			InitializeTable(methodPtrTable);
			return methodPtrTable;
		}

		public MethodSemanticsTable GetMethodSemanticsTable()
		{
			MethodSemanticsTable methodSemanticsTable = m_heap[24] as MethodSemanticsTable;
			if (methodSemanticsTable != null)
			{
				return methodSemanticsTable;
			}
			methodSemanticsTable = new MethodSemanticsTable();
			InitializeTable(methodSemanticsTable);
			return methodSemanticsTable;
		}

		public MethodSpecTable GetMethodSpecTable()
		{
			MethodSpecTable methodSpecTable = m_heap[43] as MethodSpecTable;
			if (methodSpecTable != null)
			{
				return methodSpecTable;
			}
			methodSpecTable = new MethodSpecTable();
			InitializeTable(methodSpecTable);
			return methodSpecTable;
		}

		public ModuleTable GetModuleTable()
		{
			ModuleTable moduleTable = m_heap[0] as ModuleTable;
			if (moduleTable != null)
			{
				return moduleTable;
			}
			moduleTable = new ModuleTable();
			InitializeTable(moduleTable);
			return moduleTable;
		}

		public ModuleRefTable GetModuleRefTable()
		{
			ModuleRefTable moduleRefTable = m_heap[26] as ModuleRefTable;
			if (moduleRefTable != null)
			{
				return moduleRefTable;
			}
			moduleRefTable = new ModuleRefTable();
			InitializeTable(moduleRefTable);
			return moduleRefTable;
		}

		public NestedClassTable GetNestedClassTable()
		{
			NestedClassTable nestedClassTable = m_heap[41] as NestedClassTable;
			if (nestedClassTable != null)
			{
				return nestedClassTable;
			}
			nestedClassTable = new NestedClassTable();
			InitializeTable(nestedClassTable);
			return nestedClassTable;
		}

		public ParamTable GetParamTable()
		{
			ParamTable paramTable = m_heap[8] as ParamTable;
			if (paramTable != null)
			{
				return paramTable;
			}
			paramTable = new ParamTable();
			InitializeTable(paramTable);
			return paramTable;
		}

		public ParamPtrTable GetParamPtrTable()
		{
			ParamPtrTable paramPtrTable = m_heap[7] as ParamPtrTable;
			if (paramPtrTable != null)
			{
				return paramPtrTable;
			}
			paramPtrTable = new ParamPtrTable();
			InitializeTable(paramPtrTable);
			return paramPtrTable;
		}

		public PropertyTable GetPropertyTable()
		{
			PropertyTable propertyTable = m_heap[23] as PropertyTable;
			if (propertyTable != null)
			{
				return propertyTable;
			}
			propertyTable = new PropertyTable();
			InitializeTable(propertyTable);
			return propertyTable;
		}

		public PropertyMapTable GetPropertyMapTable()
		{
			PropertyMapTable propertyMapTable = m_heap[21] as PropertyMapTable;
			if (propertyMapTable != null)
			{
				return propertyMapTable;
			}
			propertyMapTable = new PropertyMapTable();
			InitializeTable(propertyMapTable);
			return propertyMapTable;
		}

		public PropertyPtrTable GetPropertyPtrTable()
		{
			PropertyPtrTable propertyPtrTable = m_heap[22] as PropertyPtrTable;
			if (propertyPtrTable != null)
			{
				return propertyPtrTable;
			}
			propertyPtrTable = new PropertyPtrTable();
			InitializeTable(propertyPtrTable);
			return propertyPtrTable;
		}

		public StandAloneSigTable GetStandAloneSigTable()
		{
			StandAloneSigTable standAloneSigTable = m_heap[17] as StandAloneSigTable;
			if (standAloneSigTable != null)
			{
				return standAloneSigTable;
			}
			standAloneSigTable = new StandAloneSigTable();
			InitializeTable(standAloneSigTable);
			return standAloneSigTable;
		}

		public TypeDefTable GetTypeDefTable()
		{
			TypeDefTable typeDefTable = m_heap[2] as TypeDefTable;
			if (typeDefTable != null)
			{
				return typeDefTable;
			}
			typeDefTable = new TypeDefTable();
			InitializeTable(typeDefTable);
			return typeDefTable;
		}

		public TypeRefTable GetTypeRefTable()
		{
			TypeRefTable typeRefTable = m_heap[1] as TypeRefTable;
			if (typeRefTable != null)
			{
				return typeRefTable;
			}
			typeRefTable = new TypeRefTable();
			InitializeTable(typeRefTable);
			return typeRefTable;
		}

		public TypeSpecTable GetTypeSpecTable()
		{
			TypeSpecTable typeSpecTable = m_heap[27] as TypeSpecTable;
			if (typeSpecTable != null)
			{
				return typeSpecTable;
			}
			typeSpecTable = new TypeSpecTable();
			InitializeTable(typeSpecTable);
			return typeSpecTable;
		}

		public override void VisitTableCollection(TableCollection coll)
		{
			WriteCount(0);
			WriteCount(1);
			WriteCount(2);
			WriteCount(3);
			WriteCount(4);
			WriteCount(5);
			WriteCount(6);
			WriteCount(7);
			WriteCount(8);
			WriteCount(9);
			WriteCount(10);
			WriteCount(11);
			WriteCount(12);
			WriteCount(13);
			WriteCount(14);
			WriteCount(15);
			WriteCount(16);
			WriteCount(17);
			WriteCount(18);
			WriteCount(19);
			WriteCount(20);
			WriteCount(21);
			WriteCount(22);
			WriteCount(23);
			WriteCount(24);
			WriteCount(25);
			WriteCount(26);
			WriteCount(27);
			WriteCount(28);
			WriteCount(29);
			WriteCount(32);
			WriteCount(33);
			WriteCount(34);
			WriteCount(35);
			WriteCount(36);
			WriteCount(37);
			WriteCount(38);
			WriteCount(39);
			WriteCount(40);
			WriteCount(41);
			WriteCount(42);
			WriteCount(43);
			WriteCount(44);
		}
	}
}
