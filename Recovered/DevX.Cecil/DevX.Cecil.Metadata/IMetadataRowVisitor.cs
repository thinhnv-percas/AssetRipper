namespace DevX.Cecil.Metadata
{
	public interface IMetadataRowVisitor
	{
		void VisitRowCollection(RowCollection coll);

		void VisitAssemblyRow(AssemblyRow row);

		void VisitAssemblyOSRow(AssemblyOSRow row);

		void VisitAssemblyProcessorRow(AssemblyProcessorRow row);

		void VisitAssemblyRefRow(AssemblyRefRow row);

		void VisitAssemblyRefOSRow(AssemblyRefOSRow row);

		void VisitAssemblyRefProcessorRow(AssemblyRefProcessorRow row);

		void VisitClassLayoutRow(ClassLayoutRow row);

		void VisitConstantRow(ConstantRow row);

		void VisitCustomAttributeRow(CustomAttributeRow row);

		void VisitDeclSecurityRow(DeclSecurityRow row);

		void VisitEventRow(EventRow row);

		void VisitEventMapRow(EventMapRow row);

		void VisitEventPtrRow(EventPtrRow row);

		void VisitExportedTypeRow(ExportedTypeRow row);

		void VisitFieldRow(FieldRow row);

		void VisitFieldLayoutRow(FieldLayoutRow row);

		void VisitFieldMarshalRow(FieldMarshalRow row);

		void VisitFieldPtrRow(FieldPtrRow row);

		void VisitFieldRVARow(FieldRVARow row);

		void VisitFileRow(FileRow row);

		void VisitGenericParamRow(GenericParamRow row);

		void VisitGenericParamConstraintRow(GenericParamConstraintRow row);

		void VisitImplMapRow(ImplMapRow row);

		void VisitInterfaceImplRow(InterfaceImplRow row);

		void VisitManifestResourceRow(ManifestResourceRow row);

		void VisitMemberRefRow(MemberRefRow row);

		void VisitMethodRow(MethodRow row);

		void VisitMethodImplRow(MethodImplRow row);

		void VisitMethodPtrRow(MethodPtrRow row);

		void VisitMethodSemanticsRow(MethodSemanticsRow row);

		void VisitMethodSpecRow(MethodSpecRow row);

		void VisitModuleRow(ModuleRow row);

		void VisitModuleRefRow(ModuleRefRow row);

		void VisitNestedClassRow(NestedClassRow row);

		void VisitParamRow(ParamRow row);

		void VisitParamPtrRow(ParamPtrRow row);

		void VisitPropertyRow(PropertyRow row);

		void VisitPropertyMapRow(PropertyMapRow row);

		void VisitPropertyPtrRow(PropertyPtrRow row);

		void VisitStandAloneSigRow(StandAloneSigRow row);

		void VisitTypeDefRow(TypeDefRow row);

		void VisitTypeRefRow(TypeRefRow row);

		void VisitTypeSpecRow(TypeSpecRow row);

		void TerminateRowCollection(RowCollection coll);
	}
}
