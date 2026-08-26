using DevX.Cecil.Binary;
using System.IO;

namespace DevX.Cecil.Metadata
{
	internal sealed class MetadataRowReader : BaseMetadataRowVisitor
	{
		private MetadataTableReader m_mtrv;

		private BinaryReader m_binaryReader;

		private MetadataRoot m_metadataRoot;

		private Utilities.TableRowCounter m_counter;

		private int[] m_ciCache;

		private int m_blobHeapIdxSz;

		private int m_stringsHeapIdxSz;

		private int m_guidHeapIdxSz;

		public MetadataRowReader(MetadataTableReader mtrv)
		{
			m_mtrv = mtrv;
			m_binaryReader = mtrv.GetReader();
			m_metadataRoot = mtrv.GetMetadataRoot();
			m_ciCache = new int[13];
			m_counter = m_mtrv.GetNumberOfRows;
		}

		private int GetIndexSize(int rid)
		{
			return (m_mtrv.GetNumberOfRows(rid) >= 65536) ? 4 : 2;
		}

		private int GetCodedIndexSize(CodedIndex ci)
		{
			return Utilities.GetCodedIndexSize(ci, m_counter, m_ciCache);
		}

		private uint ReadByIndexSize(int size)
		{
			switch (size)
			{
			case 2:
				return m_binaryReader.ReadUInt16();
			case 4:
				return m_binaryReader.ReadUInt32();
			default:
				throw new MetadataFormatException("Non valid size for indexing");
			}
		}

		public override void VisitRowCollection(RowCollection coll)
		{
			m_blobHeapIdxSz = ((m_metadataRoot.Streams.BlobHeap == null) ? 2 : m_metadataRoot.Streams.BlobHeap.IndexSize);
			m_stringsHeapIdxSz = ((m_metadataRoot.Streams.StringsHeap == null) ? 2 : m_metadataRoot.Streams.StringsHeap.IndexSize);
			m_guidHeapIdxSz = ((m_metadataRoot.Streams.GuidHeap == null) ? 2 : m_metadataRoot.Streams.GuidHeap.IndexSize);
		}

		public override void VisitAssemblyRow(AssemblyRow row)
		{
			row.HashAlgId = (AssemblyHashAlgorithm)m_binaryReader.ReadUInt32();
			row.MajorVersion = m_binaryReader.ReadUInt16();
			row.MinorVersion = m_binaryReader.ReadUInt16();
			row.BuildNumber = m_binaryReader.ReadUInt16();
			row.RevisionNumber = m_binaryReader.ReadUInt16();
			row.Flags = (AssemblyFlags)m_binaryReader.ReadUInt32();
			row.PublicKey = ReadByIndexSize(m_blobHeapIdxSz);
			row.Name = ReadByIndexSize(m_stringsHeapIdxSz);
			row.Culture = ReadByIndexSize(m_stringsHeapIdxSz);
		}

		public override void VisitAssemblyOSRow(AssemblyOSRow row)
		{
			row.OSPlatformID = m_binaryReader.ReadUInt32();
			row.OSMajorVersion = m_binaryReader.ReadUInt32();
			row.OSMinorVersion = m_binaryReader.ReadUInt32();
		}

		public override void VisitAssemblyProcessorRow(AssemblyProcessorRow row)
		{
			row.Processor = m_binaryReader.ReadUInt32();
		}

		public override void VisitAssemblyRefRow(AssemblyRefRow row)
		{
			row.MajorVersion = m_binaryReader.ReadUInt16();
			row.MinorVersion = m_binaryReader.ReadUInt16();
			row.BuildNumber = m_binaryReader.ReadUInt16();
			row.RevisionNumber = m_binaryReader.ReadUInt16();
			row.Flags = (AssemblyFlags)m_binaryReader.ReadUInt32();
			row.PublicKeyOrToken = ReadByIndexSize(m_blobHeapIdxSz);
			row.Name = ReadByIndexSize(m_stringsHeapIdxSz);
			row.Culture = ReadByIndexSize(m_stringsHeapIdxSz);
			row.HashValue = ReadByIndexSize(m_blobHeapIdxSz);
		}

		public override void VisitAssemblyRefOSRow(AssemblyRefOSRow row)
		{
			row.OSPlatformID = m_binaryReader.ReadUInt32();
			row.OSMajorVersion = m_binaryReader.ReadUInt32();
			row.OSMinorVersion = m_binaryReader.ReadUInt32();
			row.AssemblyRef = ReadByIndexSize(GetIndexSize(35));
		}

		public override void VisitAssemblyRefProcessorRow(AssemblyRefProcessorRow row)
		{
			row.Processor = m_binaryReader.ReadUInt32();
			row.AssemblyRef = ReadByIndexSize(GetIndexSize(35));
		}

		public override void VisitClassLayoutRow(ClassLayoutRow row)
		{
			row.PackingSize = m_binaryReader.ReadUInt16();
			row.ClassSize = m_binaryReader.ReadUInt32();
			row.Parent = ReadByIndexSize(GetIndexSize(2));
		}

		public override void VisitConstantRow(ConstantRow row)
		{
			row.Type = (ElementType)m_binaryReader.ReadUInt16();
			row.Parent = Utilities.GetMetadataToken(CodedIndex.HasConstant, ReadByIndexSize(GetCodedIndexSize(CodedIndex.HasConstant)));
			row.Value = ReadByIndexSize(m_blobHeapIdxSz);
		}

		public override void VisitCustomAttributeRow(CustomAttributeRow row)
		{
			row.Parent = Utilities.GetMetadataToken(CodedIndex.HasCustomAttribute, ReadByIndexSize(GetCodedIndexSize(CodedIndex.HasCustomAttribute)));
			row.Type = Utilities.GetMetadataToken(CodedIndex.CustomAttributeType, ReadByIndexSize(GetCodedIndexSize(CodedIndex.CustomAttributeType)));
			row.Value = ReadByIndexSize(m_blobHeapIdxSz);
		}

		public override void VisitDeclSecurityRow(DeclSecurityRow row)
		{
			row.Action = (SecurityAction)m_binaryReader.ReadInt16();
			row.Parent = Utilities.GetMetadataToken(CodedIndex.HasDeclSecurity, ReadByIndexSize(GetCodedIndexSize(CodedIndex.HasDeclSecurity)));
			row.PermissionSet = ReadByIndexSize(m_blobHeapIdxSz);
		}

		public override void VisitEventRow(EventRow row)
		{
			row.EventFlags = (EventAttributes)m_binaryReader.ReadUInt16();
			row.Name = ReadByIndexSize(m_stringsHeapIdxSz);
			row.EventType = Utilities.GetMetadataToken(CodedIndex.TypeDefOrRef, ReadByIndexSize(GetCodedIndexSize(CodedIndex.TypeDefOrRef)));
		}

		public override void VisitEventMapRow(EventMapRow row)
		{
			row.Parent = ReadByIndexSize(GetIndexSize(2));
			row.EventList = ReadByIndexSize(GetIndexSize(20));
		}

		public override void VisitEventPtrRow(EventPtrRow row)
		{
			row.Event = ReadByIndexSize(GetIndexSize(20));
		}

		public override void VisitExportedTypeRow(ExportedTypeRow row)
		{
			row.Flags = (TypeAttributes)m_binaryReader.ReadUInt32();
			row.TypeDefId = m_binaryReader.ReadUInt32();
			row.TypeName = ReadByIndexSize(m_stringsHeapIdxSz);
			row.TypeNamespace = ReadByIndexSize(m_stringsHeapIdxSz);
			row.Implementation = Utilities.GetMetadataToken(CodedIndex.Implementation, ReadByIndexSize(GetCodedIndexSize(CodedIndex.Implementation)));
		}

		public override void VisitFieldRow(FieldRow row)
		{
			row.Flags = (FieldAttributes)m_binaryReader.ReadUInt16();
			row.Name = ReadByIndexSize(m_stringsHeapIdxSz);
			row.Signature = ReadByIndexSize(m_blobHeapIdxSz);
		}

		public override void VisitFieldLayoutRow(FieldLayoutRow row)
		{
			row.Offset = m_binaryReader.ReadUInt32();
			row.Field = ReadByIndexSize(GetIndexSize(4));
		}

		public override void VisitFieldMarshalRow(FieldMarshalRow row)
		{
			row.Parent = Utilities.GetMetadataToken(CodedIndex.HasFieldMarshal, ReadByIndexSize(GetCodedIndexSize(CodedIndex.HasFieldMarshal)));
			row.NativeType = ReadByIndexSize(m_blobHeapIdxSz);
		}

		public override void VisitFieldPtrRow(FieldPtrRow row)
		{
			row.Field = ReadByIndexSize(GetIndexSize(4));
		}

		public override void VisitFieldRVARow(FieldRVARow row)
		{
			row.RVA = new RVA(m_binaryReader.ReadUInt32());
			row.Field = ReadByIndexSize(GetIndexSize(4));
		}

		public override void VisitFileRow(FileRow row)
		{
			row.Flags = (FileAttributes)m_binaryReader.ReadUInt32();
			row.Name = ReadByIndexSize(m_stringsHeapIdxSz);
			row.HashValue = ReadByIndexSize(m_blobHeapIdxSz);
		}

		public override void VisitGenericParamRow(GenericParamRow row)
		{
			row.Number = m_binaryReader.ReadUInt16();
			row.Flags = (GenericParameterAttributes)m_binaryReader.ReadUInt16();
			row.Owner = Utilities.GetMetadataToken(CodedIndex.TypeOrMethodDef, ReadByIndexSize(GetCodedIndexSize(CodedIndex.TypeOrMethodDef)));
			row.Name = ReadByIndexSize(m_stringsHeapIdxSz);
		}

		public override void VisitGenericParamConstraintRow(GenericParamConstraintRow row)
		{
			row.Owner = ReadByIndexSize(GetIndexSize(42));
			row.Constraint = Utilities.GetMetadataToken(CodedIndex.TypeDefOrRef, ReadByIndexSize(GetCodedIndexSize(CodedIndex.TypeDefOrRef)));
		}

		public override void VisitImplMapRow(ImplMapRow row)
		{
			row.MappingFlags = (PInvokeAttributes)m_binaryReader.ReadUInt16();
			row.MemberForwarded = Utilities.GetMetadataToken(CodedIndex.MemberForwarded, ReadByIndexSize(GetCodedIndexSize(CodedIndex.MemberForwarded)));
			row.ImportName = ReadByIndexSize(m_stringsHeapIdxSz);
			row.ImportScope = ReadByIndexSize(GetIndexSize(26));
		}

		public override void VisitInterfaceImplRow(InterfaceImplRow row)
		{
			row.Class = ReadByIndexSize(GetIndexSize(2));
			row.Interface = Utilities.GetMetadataToken(CodedIndex.TypeDefOrRef, ReadByIndexSize(GetCodedIndexSize(CodedIndex.TypeDefOrRef)));
		}

		public override void VisitManifestResourceRow(ManifestResourceRow row)
		{
			row.Offset = m_binaryReader.ReadUInt32();
			row.Flags = (ManifestResourceAttributes)m_binaryReader.ReadUInt32();
			row.Name = ReadByIndexSize(m_stringsHeapIdxSz);
			row.Implementation = Utilities.GetMetadataToken(CodedIndex.Implementation, ReadByIndexSize(GetCodedIndexSize(CodedIndex.Implementation)));
		}

		public override void VisitMemberRefRow(MemberRefRow row)
		{
			row.Class = Utilities.GetMetadataToken(CodedIndex.MemberRefParent, ReadByIndexSize(GetCodedIndexSize(CodedIndex.MemberRefParent)));
			row.Name = ReadByIndexSize(m_stringsHeapIdxSz);
			row.Signature = ReadByIndexSize(m_blobHeapIdxSz);
		}

		public override void VisitMethodRow(MethodRow row)
		{
			row.RVA = new RVA(m_binaryReader.ReadUInt32());
			row.ImplFlags = (MethodImplAttributes)m_binaryReader.ReadUInt16();
			row.Flags = (MethodAttributes)m_binaryReader.ReadUInt16();
			row.Name = ReadByIndexSize(m_stringsHeapIdxSz);
			row.Signature = ReadByIndexSize(m_blobHeapIdxSz);
			row.ParamList = ReadByIndexSize(GetIndexSize(8));
		}

		public override void VisitMethodImplRow(MethodImplRow row)
		{
			row.Class = ReadByIndexSize(GetIndexSize(2));
			row.MethodBody = Utilities.GetMetadataToken(CodedIndex.MethodDefOrRef, ReadByIndexSize(GetCodedIndexSize(CodedIndex.MethodDefOrRef)));
			row.MethodDeclaration = Utilities.GetMetadataToken(CodedIndex.MethodDefOrRef, ReadByIndexSize(GetCodedIndexSize(CodedIndex.MethodDefOrRef)));
		}

		public override void VisitMethodPtrRow(MethodPtrRow row)
		{
			row.Method = ReadByIndexSize(GetIndexSize(6));
		}

		public override void VisitMethodSemanticsRow(MethodSemanticsRow row)
		{
			row.Semantics = (MethodSemanticsAttributes)m_binaryReader.ReadUInt16();
			row.Method = ReadByIndexSize(GetIndexSize(6));
			row.Association = Utilities.GetMetadataToken(CodedIndex.HasSemantics, ReadByIndexSize(GetCodedIndexSize(CodedIndex.HasSemantics)));
		}

		public override void VisitMethodSpecRow(MethodSpecRow row)
		{
			row.Method = Utilities.GetMetadataToken(CodedIndex.MethodDefOrRef, ReadByIndexSize(GetCodedIndexSize(CodedIndex.MethodDefOrRef)));
			row.Instantiation = ReadByIndexSize(m_blobHeapIdxSz);
		}

		public override void VisitModuleRow(ModuleRow row)
		{
			row.Generation = m_binaryReader.ReadUInt16();
			row.Name = ReadByIndexSize(m_stringsHeapIdxSz);
			row.Mvid = ReadByIndexSize(m_guidHeapIdxSz);
			row.EncId = ReadByIndexSize(m_guidHeapIdxSz);
			row.EncBaseId = ReadByIndexSize(m_guidHeapIdxSz);
		}

		public override void VisitModuleRefRow(ModuleRefRow row)
		{
			row.Name = ReadByIndexSize(m_stringsHeapIdxSz);
		}

		public override void VisitNestedClassRow(NestedClassRow row)
		{
			row.NestedClass = ReadByIndexSize(GetIndexSize(2));
			row.EnclosingClass = ReadByIndexSize(GetIndexSize(2));
		}

		public override void VisitParamRow(ParamRow row)
		{
			row.Flags = (ParameterAttributes)m_binaryReader.ReadUInt16();
			row.Sequence = m_binaryReader.ReadUInt16();
			row.Name = ReadByIndexSize(m_stringsHeapIdxSz);
		}

		public override void VisitParamPtrRow(ParamPtrRow row)
		{
			row.Param = ReadByIndexSize(GetIndexSize(8));
		}

		public override void VisitPropertyRow(PropertyRow row)
		{
			row.Flags = (PropertyAttributes)m_binaryReader.ReadUInt16();
			row.Name = ReadByIndexSize(m_stringsHeapIdxSz);
			row.Type = ReadByIndexSize(m_blobHeapIdxSz);
		}

		public override void VisitPropertyMapRow(PropertyMapRow row)
		{
			row.Parent = ReadByIndexSize(GetIndexSize(2));
			row.PropertyList = ReadByIndexSize(GetIndexSize(23));
		}

		public override void VisitPropertyPtrRow(PropertyPtrRow row)
		{
			row.Property = ReadByIndexSize(GetIndexSize(23));
		}

		public override void VisitStandAloneSigRow(StandAloneSigRow row)
		{
			row.Signature = ReadByIndexSize(m_blobHeapIdxSz);
		}

		public override void VisitTypeDefRow(TypeDefRow row)
		{
			row.Flags = (TypeAttributes)m_binaryReader.ReadUInt32();
			row.Name = ReadByIndexSize(m_stringsHeapIdxSz);
			row.Namespace = ReadByIndexSize(m_stringsHeapIdxSz);
			row.Extends = Utilities.GetMetadataToken(CodedIndex.TypeDefOrRef, ReadByIndexSize(GetCodedIndexSize(CodedIndex.TypeDefOrRef)));
			row.FieldList = ReadByIndexSize(GetIndexSize(4));
			row.MethodList = ReadByIndexSize(GetIndexSize(6));
		}

		public override void VisitTypeRefRow(TypeRefRow row)
		{
			row.ResolutionScope = Utilities.GetMetadataToken(CodedIndex.ResolutionScope, ReadByIndexSize(GetCodedIndexSize(CodedIndex.ResolutionScope)));
			row.Name = ReadByIndexSize(m_stringsHeapIdxSz);
			row.Namespace = ReadByIndexSize(m_stringsHeapIdxSz);
		}

		public override void VisitTypeSpecRow(TypeSpecRow row)
		{
			row.Signature = ReadByIndexSize(m_blobHeapIdxSz);
		}
	}
}
