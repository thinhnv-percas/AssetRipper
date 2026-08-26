namespace DevX.Cecil.Metadata
{
	public abstract class BaseMetadataTableVisitor : IMetadataTableVisitor
	{
		public virtual void VisitTableCollection(TableCollection coll)
		{
		}

		public virtual void VisitAssemblyTable(AssemblyTable table)
		{
		}

		public virtual void VisitAssemblyOSTable(AssemblyOSTable table)
		{
		}

		public virtual void VisitAssemblyProcessorTable(AssemblyProcessorTable table)
		{
		}

		public virtual void VisitAssemblyRefTable(AssemblyRefTable table)
		{
		}

		public virtual void VisitAssemblyRefOSTable(AssemblyRefOSTable table)
		{
		}

		public virtual void VisitAssemblyRefProcessorTable(AssemblyRefProcessorTable table)
		{
		}

		public virtual void VisitClassLayoutTable(ClassLayoutTable table)
		{
		}

		public virtual void VisitConstantTable(ConstantTable table)
		{
		}

		public virtual void VisitCustomAttributeTable(CustomAttributeTable table)
		{
		}

		public virtual void VisitDeclSecurityTable(DeclSecurityTable table)
		{
		}

		public virtual void VisitEventTable(EventTable table)
		{
		}

		public virtual void VisitEventMapTable(EventMapTable table)
		{
		}

		public virtual void VisitEventPtrTable(EventPtrTable table)
		{
		}

		public virtual void VisitExportedTypeTable(ExportedTypeTable table)
		{
		}

		public virtual void VisitFieldTable(FieldTable table)
		{
		}

		public virtual void VisitFieldLayoutTable(FieldLayoutTable table)
		{
		}

		public virtual void VisitFieldMarshalTable(FieldMarshalTable table)
		{
		}

		public virtual void VisitFieldPtrTable(FieldPtrTable table)
		{
		}

		public virtual void VisitFieldRVATable(FieldRVATable table)
		{
		}

		public virtual void VisitFileTable(FileTable table)
		{
		}

		public virtual void VisitGenericParamTable(GenericParamTable table)
		{
		}

		public virtual void VisitGenericParamConstraintTable(GenericParamConstraintTable table)
		{
		}

		public virtual void VisitImplMapTable(ImplMapTable table)
		{
		}

		public virtual void VisitInterfaceImplTable(InterfaceImplTable table)
		{
		}

		public virtual void VisitManifestResourceTable(ManifestResourceTable table)
		{
		}

		public virtual void VisitMemberRefTable(MemberRefTable table)
		{
		}

		public virtual void VisitMethodTable(MethodTable table)
		{
		}

		public virtual void VisitMethodImplTable(MethodImplTable table)
		{
		}

		public virtual void VisitMethodPtrTable(MethodPtrTable table)
		{
		}

		public virtual void VisitMethodSemanticsTable(MethodSemanticsTable table)
		{
		}

		public virtual void VisitMethodSpecTable(MethodSpecTable table)
		{
		}

		public virtual void VisitModuleTable(ModuleTable table)
		{
		}

		public virtual void VisitModuleRefTable(ModuleRefTable table)
		{
		}

		public virtual void VisitNestedClassTable(NestedClassTable table)
		{
		}

		public virtual void VisitParamTable(ParamTable table)
		{
		}

		public virtual void VisitParamPtrTable(ParamPtrTable table)
		{
		}

		public virtual void VisitPropertyTable(PropertyTable table)
		{
		}

		public virtual void VisitPropertyMapTable(PropertyMapTable table)
		{
		}

		public virtual void VisitPropertyPtrTable(PropertyPtrTable table)
		{
		}

		public virtual void VisitStandAloneSigTable(StandAloneSigTable table)
		{
		}

		public virtual void VisitTypeDefTable(TypeDefTable table)
		{
		}

		public virtual void VisitTypeRefTable(TypeRefTable table)
		{
		}

		public virtual void VisitTypeSpecTable(TypeSpecTable table)
		{
		}

		public virtual void TerminateTableCollection(TableCollection coll)
		{
		}

		public abstract IMetadataRowVisitor GetRowVisitor();
	}
}
