using System;
using System.Collections;

namespace DevX.Cecil
{
	public sealed class ModuleDefinitionCollection : CollectionBase, IReflectionStructureVisitable
	{
		private AssemblyDefinition m_container;

		public ModuleDefinition this[int index]
		{
			get
			{
				return base.List[index] as ModuleDefinition;
			}
			set
			{
				base.List[index] = value;
			}
		}

		public AssemblyDefinition Container => m_container;

		public ModuleDefinitionCollection(AssemblyDefinition container)
		{
			m_container = container;
		}

		public void Add(ModuleDefinition value)
		{
			base.List.Add(value);
		}

		public bool Contains(ModuleDefinition value)
		{
			return base.List.Contains(value);
		}

		public int IndexOf(ModuleDefinition value)
		{
			return base.List.IndexOf(value);
		}

		public void Insert(int index, ModuleDefinition value)
		{
			base.List.Insert(index, value);
		}

		public void Remove(ModuleDefinition value)
		{
			base.List.Remove(value);
		}

		protected override void OnValidate(object o)
		{
			if (!(o is ModuleDefinition))
			{
				throw new ArgumentException("Must be of type " + typeof(ModuleDefinition).FullName);
			}
		}

		public void Accept(IReflectionStructureVisitor visitor)
		{
			visitor.VisitModuleDefinitionCollection(this);
		}
	}
}
