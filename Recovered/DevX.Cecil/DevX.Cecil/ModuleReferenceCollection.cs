using System;
using System.Collections;

namespace DevX.Cecil
{
	public sealed class ModuleReferenceCollection : CollectionBase, IReflectionStructureVisitable
	{
		private ModuleDefinition m_container;

		public ModuleReference this[int index]
		{
			get
			{
				return base.List[index] as ModuleReference;
			}
			set
			{
				base.List[index] = value;
			}
		}

		public ModuleDefinition Container => m_container;

		public ModuleReferenceCollection(ModuleDefinition container)
		{
			m_container = container;
		}

		public void Add(ModuleReference value)
		{
			base.List.Add(value);
		}

		public bool Contains(ModuleReference value)
		{
			return base.List.Contains(value);
		}

		public int IndexOf(ModuleReference value)
		{
			return base.List.IndexOf(value);
		}

		public void Insert(int index, ModuleReference value)
		{
			base.List.Insert(index, value);
		}

		public void Remove(ModuleReference value)
		{
			base.List.Remove(value);
		}

		protected override void OnValidate(object o)
		{
			if (!(o is ModuleReference))
			{
				throw new ArgumentException("Must be of type " + typeof(ModuleReference).FullName);
			}
		}

		public void Accept(IReflectionStructureVisitor visitor)
		{
			visitor.VisitModuleReferenceCollection(this);
		}
	}
}
