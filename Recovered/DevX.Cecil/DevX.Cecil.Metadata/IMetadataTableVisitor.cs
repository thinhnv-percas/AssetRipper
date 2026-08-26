namespace DevX.Cecil.Metadata
{
	public interface IMetadataTableVisitor
	{
		void VisitTableCollection(TableCollection coll);

		void VisitAssemblyTable(AssemblyTable table);

		void VisitAssemblyOSTable(AssemblyOSTable table);

		void VisitAssemblyProcessorTable(AssemblyProcessorTable table);

		void VisitAssemblyRefTable(AssemblyRefTable table);

		void VisitAssemblyRefOSTable(AssemblyRefOSTable table);

		void VisitAssemblyRefProcessorTable(AssemblyRefProcessorTable table);

		void VisitClassLayoutTable(ClassLayoutTable table);

		void VisitConstantTable(ConstantTable table);

		void VisitCustomAttributeTable(CustomAttributeTable table);

		void VisitDeclSecurityTable(DeclSecurityTable table);

		void VisitEventTable(EventTable table);

		void VisitEventMapTable(EventMapTable table);

		void VisitEventPtrTable(EventPtrTable table);

		void VisitExportedTypeTable(ExportedTypeTable table);

		void VisitFieldTable(FieldTable table);

		void VisitFieldLayoutTable(FieldLayoutTable table);

		void VisitFieldMarshalTable(FieldMarshalTable table);

		void VisitFieldPtrTable(FieldPtrTable table);

		void VisitFieldRVATable(FieldRVATable table);

		void VisitFileTable(FileTable table);

		void VisitGenericParamTable(GenericParamTable table);

		void VisitGenericParamConstraintTable(GenericParamConstraintTable table);

		void VisitImplMapTable(ImplMapTable table);

		void VisitInterfaceImplTable(InterfaceImplTable table);

		void VisitManifestResourceTable(ManifestResourceTable table);

		void VisitMemberRefTable(MemberRefTable table);

		void VisitMethodTable(MethodTable table);

		void VisitMethodImplTable(MethodImplTable table);

		void VisitMethodPtrTable(MethodPtrTable table);

		void VisitMethodSemanticsTable(MethodSemanticsTable table);

		void VisitMethodSpecTable(MethodSpecTable table);

		void VisitModuleTable(ModuleTable table);

		void VisitModuleRefTable(ModuleRefTable table);

		void VisitNestedClassTable(NestedClassTable table);

		void VisitParamTable(ParamTable table);

		void VisitParamPtrTable(ParamPtrTable table);

		void VisitPropertyTable(PropertyTable table);

		void VisitPropertyMapTable(PropertyMapTable table);

		void VisitPropertyPtrTable(PropertyPtrTable table);

		void VisitStandAloneSigTable(StandAloneSigTable table);

		void VisitTypeDefTable(TypeDefTable table);

		void VisitTypeRefTable(TypeRefTable table);

		void VisitTypeSpecTable(TypeSpecTable table);

		void TerminateTableCollection(TableCollection coll);

		IMetadataRowVisitor GetRowVisitor();
	}
}
