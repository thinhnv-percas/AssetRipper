namespace DevX.Cecil
{
	public interface IReflectionVisitor
	{
		void VisitModuleDefinition(ModuleDefinition module);

		void VisitTypeDefinitionCollection(TypeDefinitionCollection types);

		void VisitTypeDefinition(TypeDefinition type);

		void VisitTypeReferenceCollection(TypeReferenceCollection refs);

		void VisitTypeReference(TypeReference type);

		void VisitMemberReferenceCollection(MemberReferenceCollection members);

		void VisitMemberReference(MemberReference member);

		void VisitInterfaceCollection(InterfaceCollection interfaces);

		void VisitInterface(TypeReference interf);

		void VisitExternTypeCollection(ExternTypeCollection externs);

		void VisitExternType(TypeReference externType);

		void VisitOverrideCollection(OverrideCollection meth);

		void VisitOverride(MethodReference ov);

		void VisitNestedTypeCollection(NestedTypeCollection nestedTypes);

		void VisitNestedType(TypeDefinition nestedType);

		void VisitParameterDefinitionCollection(ParameterDefinitionCollection parameters);

		void VisitParameterDefinition(ParameterDefinition parameter);

		void VisitMethodDefinitionCollection(MethodDefinitionCollection methods);

		void VisitMethodDefinition(MethodDefinition method);

		void VisitConstructorCollection(ConstructorCollection ctors);

		void VisitConstructor(MethodDefinition ctor);

		void VisitPInvokeInfo(PInvokeInfo pinvk);

		void VisitEventDefinitionCollection(EventDefinitionCollection events);

		void VisitEventDefinition(EventDefinition evt);

		void VisitFieldDefinitionCollection(FieldDefinitionCollection fields);

		void VisitFieldDefinition(FieldDefinition field);

		void VisitPropertyDefinitionCollection(PropertyDefinitionCollection properties);

		void VisitPropertyDefinition(PropertyDefinition property);

		void VisitSecurityDeclarationCollection(SecurityDeclarationCollection secDecls);

		void VisitSecurityDeclaration(SecurityDeclaration secDecl);

		void VisitCustomAttributeCollection(CustomAttributeCollection customAttrs);

		void VisitCustomAttribute(CustomAttribute customAttr);

		void VisitGenericParameterCollection(GenericParameterCollection genparams);

		void VisitGenericParameter(GenericParameter genparam);

		void VisitMarshalSpec(MarshalSpec marshalSpec);

		void TerminateModuleDefinition(ModuleDefinition module);
	}
}
