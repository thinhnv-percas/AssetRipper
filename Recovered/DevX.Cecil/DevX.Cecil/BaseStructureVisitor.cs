using System.Collections;

namespace DevX.Cecil
{
	public abstract class BaseStructureVisitor : IReflectionStructureVisitor
	{
		public virtual void VisitAssemblyDefinition(AssemblyDefinition asm)
		{
		}

		public virtual void VisitAssemblyNameDefinition(AssemblyNameDefinition name)
		{
		}

		public virtual void VisitAssemblyNameReferenceCollection(AssemblyNameReferenceCollection names)
		{
		}

		public virtual void VisitAssemblyNameReference(AssemblyNameReference name)
		{
		}

		public virtual void VisitResourceCollection(ResourceCollection resources)
		{
		}

		public virtual void VisitEmbeddedResource(EmbeddedResource res)
		{
		}

		public virtual void VisitLinkedResource(LinkedResource res)
		{
		}

		public virtual void VisitAssemblyLinkedResource(AssemblyLinkedResource res)
		{
		}

		public virtual void VisitModuleDefinition(ModuleDefinition module)
		{
		}

		public virtual void VisitModuleDefinitionCollection(ModuleDefinitionCollection modules)
		{
		}

		public virtual void VisitModuleReference(ModuleReference module)
		{
		}

		public virtual void VisitModuleReferenceCollection(ModuleReferenceCollection modules)
		{
		}

		public virtual void TerminateAssemblyDefinition(AssemblyDefinition asm)
		{
		}

		protected void VisitCollection(ICollection coll)
		{
			if (coll.Count != 0)
			{
				foreach (IReflectionStructureVisitable item in coll)
				{
					item.Accept(this);
				}
			}
		}
	}
}
