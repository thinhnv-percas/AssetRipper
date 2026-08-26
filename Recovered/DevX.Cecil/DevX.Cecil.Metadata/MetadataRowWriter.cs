using DevX.Cecil.Binary;

namespace DevX.Cecil.Metadata
{
	internal sealed class MetadataRowWriter : BaseMetadataRowVisitor
	{
		private MetadataRoot m_root;

		private MemoryBinaryWriter m_binaryWriter;

		private Utilities.TableRowCounter m_counter;

		private int[] m_ciCache;

		private int m_blobHeapIdxSz;

		private int m_stringsHeapIdxSz;

		private int m_guidHeapIdxSz;

		public MetadataRowWriter(MetadataTableWriter mtwv)
		{
			m_binaryWriter = mtwv.GetWriter();
			m_root = mtwv.GetMetadataRoot();
			m_ciCache = new int[13];
			m_counter = GetNumberOfRows;
		}

		private void WriteBlobPointer(uint pointer)
		{
			WriteByIndexSize(pointer, m_blobHeapIdxSz);
		}

		private void WriteStringPointer(uint pointer)
		{
			WriteByIndexSize(pointer, m_stringsHeapIdxSz);
		}

		private void WriteGuidPointer(uint pointer)
		{
			WriteByIndexSize(pointer, m_guidHeapIdxSz);
		}

		private void WriteTablePointer(uint pointer, int rid)
		{
			WriteByIndexSize(pointer, (GetNumberOfRows(rid) >= 65536) ? 4 : 2);
		}

		private void WriteMetadataToken(MetadataToken token, CodedIndex ci)
		{
			WriteByIndexSize(Utilities.CompressMetadataToken(ci, token), Utilities.GetCodedIndexSize(ci, m_counter, m_ciCache));
		}

		private int GetNumberOfRows(int rid)
		{
			IMetadataTable metadataTable = m_root.Streams.TablesHeap[rid];
			if (metadataTable == null || metadataTable.Rows == null)
			{
				return 0;
			}
			return metadataTable.Rows.Count;
		}

		private void WriteByIndexSize(uint value, int size)
		{
			switch (size)
			{
			case 4:
				m_binaryWriter.Write(value);
				break;
			case 2:
				m_binaryWriter.Write((ushort)value);
				break;
			default:
				throw new MetadataFormatException("Non valid size for indexing");
			}
		}

		public AssemblyRow CreateAssemblyRow(AssemblyHashAlgorithm _hashAlgId, ushort _majorVersion, ushort _minorVersion, ushort _buildNumber, ushort _revisionNumber, AssemblyFlags _flags, uint _publicKey, uint _name, uint _culture)
		{
			AssemblyRow assemblyRow = new AssemblyRow();
			assemblyRow.HashAlgId = _hashAlgId;
			assemblyRow.MajorVersion = _majorVersion;
			assemblyRow.MinorVersion = _minorVersion;
			assemblyRow.BuildNumber = _buildNumber;
			assemblyRow.RevisionNumber = _revisionNumber;
			assemblyRow.Flags = _flags;
			assemblyRow.PublicKey = _publicKey;
			assemblyRow.Name = _name;
			assemblyRow.Culture = _culture;
			return assemblyRow;
		}

		public AssemblyOSRow CreateAssemblyOSRow(uint _oSPlatformID, uint _oSMajorVersion, uint _oSMinorVersion)
		{
			AssemblyOSRow assemblyOSRow = new AssemblyOSRow();
			assemblyOSRow.OSPlatformID = _oSPlatformID;
			assemblyOSRow.OSMajorVersion = _oSMajorVersion;
			assemblyOSRow.OSMinorVersion = _oSMinorVersion;
			return assemblyOSRow;
		}

		public AssemblyProcessorRow CreateAssemblyProcessorRow(uint _processor)
		{
			AssemblyProcessorRow assemblyProcessorRow = new AssemblyProcessorRow();
			assemblyProcessorRow.Processor = _processor;
			return assemblyProcessorRow;
		}

		public AssemblyRefRow CreateAssemblyRefRow(ushort _majorVersion, ushort _minorVersion, ushort _buildNumber, ushort _revisionNumber, AssemblyFlags _flags, uint _publicKeyOrToken, uint _name, uint _culture, uint _hashValue)
		{
			AssemblyRefRow assemblyRefRow = new AssemblyRefRow();
			assemblyRefRow.MajorVersion = _majorVersion;
			assemblyRefRow.MinorVersion = _minorVersion;
			assemblyRefRow.BuildNumber = _buildNumber;
			assemblyRefRow.RevisionNumber = _revisionNumber;
			assemblyRefRow.Flags = _flags;
			assemblyRefRow.PublicKeyOrToken = _publicKeyOrToken;
			assemblyRefRow.Name = _name;
			assemblyRefRow.Culture = _culture;
			assemblyRefRow.HashValue = _hashValue;
			return assemblyRefRow;
		}

		public AssemblyRefOSRow CreateAssemblyRefOSRow(uint _oSPlatformID, uint _oSMajorVersion, uint _oSMinorVersion, uint _assemblyRef)
		{
			AssemblyRefOSRow assemblyRefOSRow = new AssemblyRefOSRow();
			assemblyRefOSRow.OSPlatformID = _oSPlatformID;
			assemblyRefOSRow.OSMajorVersion = _oSMajorVersion;
			assemblyRefOSRow.OSMinorVersion = _oSMinorVersion;
			assemblyRefOSRow.AssemblyRef = _assemblyRef;
			return assemblyRefOSRow;
		}

		public AssemblyRefProcessorRow CreateAssemblyRefProcessorRow(uint _processor, uint _assemblyRef)
		{
			AssemblyRefProcessorRow assemblyRefProcessorRow = new AssemblyRefProcessorRow();
			assemblyRefProcessorRow.Processor = _processor;
			assemblyRefProcessorRow.AssemblyRef = _assemblyRef;
			return assemblyRefProcessorRow;
		}

		public ClassLayoutRow CreateClassLayoutRow(ushort _packingSize, uint _classSize, uint _parent)
		{
			ClassLayoutRow classLayoutRow = new ClassLayoutRow();
			classLayoutRow.PackingSize = _packingSize;
			classLayoutRow.ClassSize = _classSize;
			classLayoutRow.Parent = _parent;
			return classLayoutRow;
		}

		public ConstantRow CreateConstantRow(ElementType _type, MetadataToken _parent, uint _value)
		{
			ConstantRow constantRow = new ConstantRow();
			constantRow.Type = _type;
			constantRow.Parent = _parent;
			constantRow.Value = _value;
			return constantRow;
		}

		public CustomAttributeRow CreateCustomAttributeRow(MetadataToken _parent, MetadataToken _type, uint _value)
		{
			CustomAttributeRow customAttributeRow = new CustomAttributeRow();
			customAttributeRow.Parent = _parent;
			customAttributeRow.Type = _type;
			customAttributeRow.Value = _value;
			return customAttributeRow;
		}

		public DeclSecurityRow CreateDeclSecurityRow(SecurityAction _action, MetadataToken _parent, uint _permissionSet)
		{
			DeclSecurityRow declSecurityRow = new DeclSecurityRow();
			declSecurityRow.Action = _action;
			declSecurityRow.Parent = _parent;
			declSecurityRow.PermissionSet = _permissionSet;
			return declSecurityRow;
		}

		public EventRow CreateEventRow(EventAttributes _eventFlags, uint _name, MetadataToken _eventType)
		{
			EventRow eventRow = new EventRow();
			eventRow.EventFlags = _eventFlags;
			eventRow.Name = _name;
			eventRow.EventType = _eventType;
			return eventRow;
		}

		public EventMapRow CreateEventMapRow(uint _parent, uint _eventList)
		{
			EventMapRow eventMapRow = new EventMapRow();
			eventMapRow.Parent = _parent;
			eventMapRow.EventList = _eventList;
			return eventMapRow;
		}

		public EventPtrRow CreateEventPtrRow(uint _event)
		{
			EventPtrRow eventPtrRow = new EventPtrRow();
			eventPtrRow.Event = _event;
			return eventPtrRow;
		}

		public ExportedTypeRow CreateExportedTypeRow(TypeAttributes _flags, uint _typeDefId, uint _typeName, uint _typeNamespace, MetadataToken _implementation)
		{
			ExportedTypeRow exportedTypeRow = new ExportedTypeRow();
			exportedTypeRow.Flags = _flags;
			exportedTypeRow.TypeDefId = _typeDefId;
			exportedTypeRow.TypeName = _typeName;
			exportedTypeRow.TypeNamespace = _typeNamespace;
			exportedTypeRow.Implementation = _implementation;
			return exportedTypeRow;
		}

		public FieldRow CreateFieldRow(FieldAttributes _flags, uint _name, uint _signature)
		{
			FieldRow fieldRow = new FieldRow();
			fieldRow.Flags = _flags;
			fieldRow.Name = _name;
			fieldRow.Signature = _signature;
			return fieldRow;
		}

		public FieldLayoutRow CreateFieldLayoutRow(uint _offset, uint _field)
		{
			FieldLayoutRow fieldLayoutRow = new FieldLayoutRow();
			fieldLayoutRow.Offset = _offset;
			fieldLayoutRow.Field = _field;
			return fieldLayoutRow;
		}

		public FieldMarshalRow CreateFieldMarshalRow(MetadataToken _parent, uint _nativeType)
		{
			FieldMarshalRow fieldMarshalRow = new FieldMarshalRow();
			fieldMarshalRow.Parent = _parent;
			fieldMarshalRow.NativeType = _nativeType;
			return fieldMarshalRow;
		}

		public FieldPtrRow CreateFieldPtrRow(uint _field)
		{
			FieldPtrRow fieldPtrRow = new FieldPtrRow();
			fieldPtrRow.Field = _field;
			return fieldPtrRow;
		}

		public FieldRVARow CreateFieldRVARow(RVA _rVA, uint _field)
		{
			FieldRVARow fieldRVARow = new FieldRVARow();
			fieldRVARow.RVA = _rVA;
			fieldRVARow.Field = _field;
			return fieldRVARow;
		}

		public FileRow CreateFileRow(FileAttributes _flags, uint _name, uint _hashValue)
		{
			FileRow fileRow = new FileRow();
			fileRow.Flags = _flags;
			fileRow.Name = _name;
			fileRow.HashValue = _hashValue;
			return fileRow;
		}

		public GenericParamRow CreateGenericParamRow(ushort _number, GenericParameterAttributes _flags, MetadataToken _owner, uint _name)
		{
			GenericParamRow genericParamRow = new GenericParamRow();
			genericParamRow.Number = _number;
			genericParamRow.Flags = _flags;
			genericParamRow.Owner = _owner;
			genericParamRow.Name = _name;
			return genericParamRow;
		}

		public GenericParamConstraintRow CreateGenericParamConstraintRow(uint _owner, MetadataToken _constraint)
		{
			GenericParamConstraintRow genericParamConstraintRow = new GenericParamConstraintRow();
			genericParamConstraintRow.Owner = _owner;
			genericParamConstraintRow.Constraint = _constraint;
			return genericParamConstraintRow;
		}

		public ImplMapRow CreateImplMapRow(PInvokeAttributes _mappingFlags, MetadataToken _memberForwarded, uint _importName, uint _importScope)
		{
			ImplMapRow implMapRow = new ImplMapRow();
			implMapRow.MappingFlags = _mappingFlags;
			implMapRow.MemberForwarded = _memberForwarded;
			implMapRow.ImportName = _importName;
			implMapRow.ImportScope = _importScope;
			return implMapRow;
		}

		public InterfaceImplRow CreateInterfaceImplRow(uint _class, MetadataToken _interface)
		{
			InterfaceImplRow interfaceImplRow = new InterfaceImplRow();
			interfaceImplRow.Class = _class;
			interfaceImplRow.Interface = _interface;
			return interfaceImplRow;
		}

		public ManifestResourceRow CreateManifestResourceRow(uint _offset, ManifestResourceAttributes _flags, uint _name, MetadataToken _implementation)
		{
			ManifestResourceRow manifestResourceRow = new ManifestResourceRow();
			manifestResourceRow.Offset = _offset;
			manifestResourceRow.Flags = _flags;
			manifestResourceRow.Name = _name;
			manifestResourceRow.Implementation = _implementation;
			return manifestResourceRow;
		}

		public MemberRefRow CreateMemberRefRow(MetadataToken _class, uint _name, uint _signature)
		{
			MemberRefRow memberRefRow = new MemberRefRow();
			memberRefRow.Class = _class;
			memberRefRow.Name = _name;
			memberRefRow.Signature = _signature;
			return memberRefRow;
		}

		public MethodRow CreateMethodRow(RVA _rVA, MethodImplAttributes _implFlags, MethodAttributes _flags, uint _name, uint _signature, uint _paramList)
		{
			MethodRow methodRow = new MethodRow();
			methodRow.RVA = _rVA;
			methodRow.ImplFlags = _implFlags;
			methodRow.Flags = _flags;
			methodRow.Name = _name;
			methodRow.Signature = _signature;
			methodRow.ParamList = _paramList;
			return methodRow;
		}

		public MethodImplRow CreateMethodImplRow(uint _class, MetadataToken _methodBody, MetadataToken _methodDeclaration)
		{
			MethodImplRow methodImplRow = new MethodImplRow();
			methodImplRow.Class = _class;
			methodImplRow.MethodBody = _methodBody;
			methodImplRow.MethodDeclaration = _methodDeclaration;
			return methodImplRow;
		}

		public MethodPtrRow CreateMethodPtrRow(uint _method)
		{
			MethodPtrRow methodPtrRow = new MethodPtrRow();
			methodPtrRow.Method = _method;
			return methodPtrRow;
		}

		public MethodSemanticsRow CreateMethodSemanticsRow(MethodSemanticsAttributes _semantics, uint _method, MetadataToken _association)
		{
			MethodSemanticsRow methodSemanticsRow = new MethodSemanticsRow();
			methodSemanticsRow.Semantics = _semantics;
			methodSemanticsRow.Method = _method;
			methodSemanticsRow.Association = _association;
			return methodSemanticsRow;
		}

		public MethodSpecRow CreateMethodSpecRow(MetadataToken _method, uint _instantiation)
		{
			MethodSpecRow methodSpecRow = new MethodSpecRow();
			methodSpecRow.Method = _method;
			methodSpecRow.Instantiation = _instantiation;
			return methodSpecRow;
		}

		public ModuleRow CreateModuleRow(ushort _generation, uint _name, uint _mvid, uint _encId, uint _encBaseId)
		{
			ModuleRow moduleRow = new ModuleRow();
			moduleRow.Generation = _generation;
			moduleRow.Name = _name;
			moduleRow.Mvid = _mvid;
			moduleRow.EncId = _encId;
			moduleRow.EncBaseId = _encBaseId;
			return moduleRow;
		}

		public ModuleRefRow CreateModuleRefRow(uint _name)
		{
			ModuleRefRow moduleRefRow = new ModuleRefRow();
			moduleRefRow.Name = _name;
			return moduleRefRow;
		}

		public NestedClassRow CreateNestedClassRow(uint _nestedClass, uint _enclosingClass)
		{
			NestedClassRow nestedClassRow = new NestedClassRow();
			nestedClassRow.NestedClass = _nestedClass;
			nestedClassRow.EnclosingClass = _enclosingClass;
			return nestedClassRow;
		}

		public ParamRow CreateParamRow(ParameterAttributes _flags, ushort _sequence, uint _name)
		{
			ParamRow paramRow = new ParamRow();
			paramRow.Flags = _flags;
			paramRow.Sequence = _sequence;
			paramRow.Name = _name;
			return paramRow;
		}

		public ParamPtrRow CreateParamPtrRow(uint _param)
		{
			ParamPtrRow paramPtrRow = new ParamPtrRow();
			paramPtrRow.Param = _param;
			return paramPtrRow;
		}

		public PropertyRow CreatePropertyRow(PropertyAttributes _flags, uint _name, uint _type)
		{
			PropertyRow propertyRow = new PropertyRow();
			propertyRow.Flags = _flags;
			propertyRow.Name = _name;
			propertyRow.Type = _type;
			return propertyRow;
		}

		public PropertyMapRow CreatePropertyMapRow(uint _parent, uint _propertyList)
		{
			PropertyMapRow propertyMapRow = new PropertyMapRow();
			propertyMapRow.Parent = _parent;
			propertyMapRow.PropertyList = _propertyList;
			return propertyMapRow;
		}

		public PropertyPtrRow CreatePropertyPtrRow(uint _property)
		{
			PropertyPtrRow propertyPtrRow = new PropertyPtrRow();
			propertyPtrRow.Property = _property;
			return propertyPtrRow;
		}

		public StandAloneSigRow CreateStandAloneSigRow(uint _signature)
		{
			StandAloneSigRow standAloneSigRow = new StandAloneSigRow();
			standAloneSigRow.Signature = _signature;
			return standAloneSigRow;
		}

		public TypeDefRow CreateTypeDefRow(TypeAttributes _flags, uint _name, uint _namespace, MetadataToken _extends, uint _fieldList, uint _methodList)
		{
			TypeDefRow typeDefRow = new TypeDefRow();
			typeDefRow.Flags = _flags;
			typeDefRow.Name = _name;
			typeDefRow.Namespace = _namespace;
			typeDefRow.Extends = _extends;
			typeDefRow.FieldList = _fieldList;
			typeDefRow.MethodList = _methodList;
			return typeDefRow;
		}

		public TypeRefRow CreateTypeRefRow(MetadataToken _resolutionScope, uint _name, uint _namespace)
		{
			TypeRefRow typeRefRow = new TypeRefRow();
			typeRefRow.ResolutionScope = _resolutionScope;
			typeRefRow.Name = _name;
			typeRefRow.Namespace = _namespace;
			return typeRefRow;
		}

		public TypeSpecRow CreateTypeSpecRow(uint _signature)
		{
			TypeSpecRow typeSpecRow = new TypeSpecRow();
			typeSpecRow.Signature = _signature;
			return typeSpecRow;
		}

		public override void VisitRowCollection(RowCollection coll)
		{
			m_blobHeapIdxSz = ((m_root.Streams.BlobHeap == null) ? 2 : m_root.Streams.BlobHeap.IndexSize);
			m_stringsHeapIdxSz = ((m_root.Streams.StringsHeap == null) ? 2 : m_root.Streams.StringsHeap.IndexSize);
			m_guidHeapIdxSz = ((m_root.Streams.GuidHeap == null) ? 2 : m_root.Streams.GuidHeap.IndexSize);
		}

		public override void VisitAssemblyRow(AssemblyRow row)
		{
			m_binaryWriter.Write((uint)row.HashAlgId);
			m_binaryWriter.Write(row.MajorVersion);
			m_binaryWriter.Write(row.MinorVersion);
			m_binaryWriter.Write(row.BuildNumber);
			m_binaryWriter.Write(row.RevisionNumber);
			m_binaryWriter.Write((uint)row.Flags);
			WriteBlobPointer(row.PublicKey);
			WriteStringPointer(row.Name);
			WriteStringPointer(row.Culture);
		}

		public override void VisitAssemblyOSRow(AssemblyOSRow row)
		{
			m_binaryWriter.Write(row.OSPlatformID);
			m_binaryWriter.Write(row.OSMajorVersion);
			m_binaryWriter.Write(row.OSMinorVersion);
		}

		public override void VisitAssemblyProcessorRow(AssemblyProcessorRow row)
		{
			m_binaryWriter.Write(row.Processor);
		}

		public override void VisitAssemblyRefRow(AssemblyRefRow row)
		{
			m_binaryWriter.Write(row.MajorVersion);
			m_binaryWriter.Write(row.MinorVersion);
			m_binaryWriter.Write(row.BuildNumber);
			m_binaryWriter.Write(row.RevisionNumber);
			m_binaryWriter.Write((uint)row.Flags);
			WriteBlobPointer(row.PublicKeyOrToken);
			WriteStringPointer(row.Name);
			WriteStringPointer(row.Culture);
			WriteBlobPointer(row.HashValue);
		}

		public override void VisitAssemblyRefOSRow(AssemblyRefOSRow row)
		{
			m_binaryWriter.Write(row.OSPlatformID);
			m_binaryWriter.Write(row.OSMajorVersion);
			m_binaryWriter.Write(row.OSMinorVersion);
			WriteTablePointer(row.AssemblyRef, 35);
		}

		public override void VisitAssemblyRefProcessorRow(AssemblyRefProcessorRow row)
		{
			m_binaryWriter.Write(row.Processor);
			WriteTablePointer(row.AssemblyRef, 35);
		}

		public override void VisitClassLayoutRow(ClassLayoutRow row)
		{
			m_binaryWriter.Write(row.PackingSize);
			m_binaryWriter.Write(row.ClassSize);
			WriteTablePointer(row.Parent, 2);
		}

		public override void VisitConstantRow(ConstantRow row)
		{
			m_binaryWriter.Write((ushort)row.Type);
			WriteMetadataToken(row.Parent, CodedIndex.HasConstant);
			WriteBlobPointer(row.Value);
		}

		public override void VisitCustomAttributeRow(CustomAttributeRow row)
		{
			WriteMetadataToken(row.Parent, CodedIndex.HasCustomAttribute);
			WriteMetadataToken(row.Type, CodedIndex.CustomAttributeType);
			WriteBlobPointer(row.Value);
		}

		public override void VisitDeclSecurityRow(DeclSecurityRow row)
		{
			m_binaryWriter.Write((short)row.Action);
			WriteMetadataToken(row.Parent, CodedIndex.HasDeclSecurity);
			WriteBlobPointer(row.PermissionSet);
		}

		public override void VisitEventRow(EventRow row)
		{
			m_binaryWriter.Write((ushort)row.EventFlags);
			WriteStringPointer(row.Name);
			WriteMetadataToken(row.EventType, CodedIndex.TypeDefOrRef);
		}

		public override void VisitEventMapRow(EventMapRow row)
		{
			WriteTablePointer(row.Parent, 2);
			WriteTablePointer(row.EventList, 20);
		}

		public override void VisitEventPtrRow(EventPtrRow row)
		{
			WriteTablePointer(row.Event, 20);
		}

		public override void VisitExportedTypeRow(ExportedTypeRow row)
		{
			m_binaryWriter.Write((uint)row.Flags);
			m_binaryWriter.Write(row.TypeDefId);
			WriteStringPointer(row.TypeName);
			WriteStringPointer(row.TypeNamespace);
			WriteMetadataToken(row.Implementation, CodedIndex.Implementation);
		}

		public override void VisitFieldRow(FieldRow row)
		{
			m_binaryWriter.Write((ushort)row.Flags);
			WriteStringPointer(row.Name);
			WriteBlobPointer(row.Signature);
		}

		public override void VisitFieldLayoutRow(FieldLayoutRow row)
		{
			m_binaryWriter.Write(row.Offset);
			WriteTablePointer(row.Field, 4);
		}

		public override void VisitFieldMarshalRow(FieldMarshalRow row)
		{
			WriteMetadataToken(row.Parent, CodedIndex.HasFieldMarshal);
			WriteBlobPointer(row.NativeType);
		}

		public override void VisitFieldPtrRow(FieldPtrRow row)
		{
			WriteTablePointer(row.Field, 4);
		}

		public override void VisitFieldRVARow(FieldRVARow row)
		{
			m_binaryWriter.Write(row.RVA.Value);
			WriteTablePointer(row.Field, 4);
		}

		public override void VisitFileRow(FileRow row)
		{
			m_binaryWriter.Write((uint)row.Flags);
			WriteStringPointer(row.Name);
			WriteBlobPointer(row.HashValue);
		}

		public override void VisitGenericParamRow(GenericParamRow row)
		{
			m_binaryWriter.Write(row.Number);
			m_binaryWriter.Write((ushort)row.Flags);
			WriteMetadataToken(row.Owner, CodedIndex.TypeOrMethodDef);
			WriteStringPointer(row.Name);
		}

		public override void VisitGenericParamConstraintRow(GenericParamConstraintRow row)
		{
			WriteTablePointer(row.Owner, 42);
			WriteMetadataToken(row.Constraint, CodedIndex.TypeDefOrRef);
		}

		public override void VisitImplMapRow(ImplMapRow row)
		{
			m_binaryWriter.Write((ushort)row.MappingFlags);
			WriteMetadataToken(row.MemberForwarded, CodedIndex.MemberForwarded);
			WriteStringPointer(row.ImportName);
			WriteTablePointer(row.ImportScope, 26);
		}

		public override void VisitInterfaceImplRow(InterfaceImplRow row)
		{
			WriteTablePointer(row.Class, 2);
			WriteMetadataToken(row.Interface, CodedIndex.TypeDefOrRef);
		}

		public override void VisitManifestResourceRow(ManifestResourceRow row)
		{
			m_binaryWriter.Write(row.Offset);
			m_binaryWriter.Write((uint)row.Flags);
			WriteStringPointer(row.Name);
			WriteMetadataToken(row.Implementation, CodedIndex.Implementation);
		}

		public override void VisitMemberRefRow(MemberRefRow row)
		{
			WriteMetadataToken(row.Class, CodedIndex.MemberRefParent);
			WriteStringPointer(row.Name);
			WriteBlobPointer(row.Signature);
		}

		public override void VisitMethodRow(MethodRow row)
		{
			m_binaryWriter.Write(row.RVA.Value);
			m_binaryWriter.Write((ushort)row.ImplFlags);
			m_binaryWriter.Write((ushort)row.Flags);
			WriteStringPointer(row.Name);
			WriteBlobPointer(row.Signature);
			WriteTablePointer(row.ParamList, 8);
		}

		public override void VisitMethodImplRow(MethodImplRow row)
		{
			WriteTablePointer(row.Class, 2);
			WriteMetadataToken(row.MethodBody, CodedIndex.MethodDefOrRef);
			WriteMetadataToken(row.MethodDeclaration, CodedIndex.MethodDefOrRef);
		}

		public override void VisitMethodPtrRow(MethodPtrRow row)
		{
			WriteTablePointer(row.Method, 6);
		}

		public override void VisitMethodSemanticsRow(MethodSemanticsRow row)
		{
			m_binaryWriter.Write((ushort)row.Semantics);
			WriteTablePointer(row.Method, 6);
			WriteMetadataToken(row.Association, CodedIndex.HasSemantics);
		}

		public override void VisitMethodSpecRow(MethodSpecRow row)
		{
			WriteMetadataToken(row.Method, CodedIndex.MethodDefOrRef);
			WriteBlobPointer(row.Instantiation);
		}

		public override void VisitModuleRow(ModuleRow row)
		{
			m_binaryWriter.Write(row.Generation);
			WriteStringPointer(row.Name);
			WriteGuidPointer(row.Mvid);
			WriteGuidPointer(row.EncId);
			WriteGuidPointer(row.EncBaseId);
		}

		public override void VisitModuleRefRow(ModuleRefRow row)
		{
			WriteStringPointer(row.Name);
		}

		public override void VisitNestedClassRow(NestedClassRow row)
		{
			WriteTablePointer(row.NestedClass, 2);
			WriteTablePointer(row.EnclosingClass, 2);
		}

		public override void VisitParamRow(ParamRow row)
		{
			m_binaryWriter.Write((ushort)row.Flags);
			m_binaryWriter.Write(row.Sequence);
			WriteStringPointer(row.Name);
		}

		public override void VisitParamPtrRow(ParamPtrRow row)
		{
			WriteTablePointer(row.Param, 8);
		}

		public override void VisitPropertyRow(PropertyRow row)
		{
			m_binaryWriter.Write((ushort)row.Flags);
			WriteStringPointer(row.Name);
			WriteBlobPointer(row.Type);
		}

		public override void VisitPropertyMapRow(PropertyMapRow row)
		{
			WriteTablePointer(row.Parent, 2);
			WriteTablePointer(row.PropertyList, 23);
		}

		public override void VisitPropertyPtrRow(PropertyPtrRow row)
		{
			WriteTablePointer(row.Property, 23);
		}

		public override void VisitStandAloneSigRow(StandAloneSigRow row)
		{
			WriteBlobPointer(row.Signature);
		}

		public override void VisitTypeDefRow(TypeDefRow row)
		{
			m_binaryWriter.Write((uint)row.Flags);
			WriteStringPointer(row.Name);
			WriteStringPointer(row.Namespace);
			WriteMetadataToken(row.Extends, CodedIndex.TypeDefOrRef);
			WriteTablePointer(row.FieldList, 4);
			WriteTablePointer(row.MethodList, 6);
		}

		public override void VisitTypeRefRow(TypeRefRow row)
		{
			WriteMetadataToken(row.ResolutionScope, CodedIndex.ResolutionScope);
			WriteStringPointer(row.Name);
			WriteStringPointer(row.Namespace);
		}

		public override void VisitTypeSpecRow(TypeSpecRow row)
		{
			WriteBlobPointer(row.Signature);
		}
	}
}
