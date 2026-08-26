namespace DevX.Cecil
{
	public interface IReflectionStructureVisitor
	{
		void VisitAssemblyDefinition(AssemblyDefinition asm);

		void VisitAssemblyNameDefinition(AssemblyNameDefinition name);

		void VisitAssemblyNameReferenceCollection(AssemblyNameReferenceCollection names);

		void VisitAssemblyNameReference(AssemblyNameReference name);

		void VisitResourceCollection(ResourceCollection resources);

		void VisitEmbeddedResource(EmbeddedResource res);

		void VisitLinkedResource(LinkedResource res);

		void VisitAssemblyLinkedResource(AssemblyLinkedResource res);

		void VisitModuleDefinition(ModuleDefinition module);

		void VisitModuleDefinitionCollection(ModuleDefinitionCollection modules);

		void VisitModuleReference(ModuleReference module);

		void VisitModuleReferenceCollection(ModuleReferenceCollection modules);

		void TerminateAssemblyDefinition(AssemblyDefinition asm);
	}
}
