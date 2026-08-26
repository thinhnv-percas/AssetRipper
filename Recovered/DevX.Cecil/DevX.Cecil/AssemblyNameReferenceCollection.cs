using System;
using System.Collections;

namespace DevX.Cecil
{
	public sealed class AssemblyNameReferenceCollection : CollectionBase, IReflectionStructureVisitable
	{
		private ModuleDefinition m_container;

		public AssemblyNameReference this[int index]
		{
			get
			{
				return base.List[index] as AssemblyNameReference;
			}
			set
			{
				base.List[index] = value;
			}
		}

		public ModuleDefinition Container => m_container;

		public AssemblyNameReferenceCollection(ModuleDefinition container)
		{
			m_container = container;
		}

		public void Add(AssemblyNameReference value)
		{
			base.List.Add(value);
		}

		public bool Contains(AssemblyNameReference value)
		{
			return base.List.Contains(value);
		}

		public int IndexOf(AssemblyNameReference value)
		{
			return base.List.IndexOf(value);
		}

		public void Insert(int index, AssemblyNameReference value)
		{
			base.List.Insert(index, value);
		}

		public void Remove(AssemblyNameReference value)
		{
			base.List.Remove(value);
		}

		protected override void OnValidate(object o)
		{
			if (!(o is AssemblyNameReference))
			{
				throw new ArgumentException("Must be of type " + typeof(AssemblyNameReference).FullName);
			}
		}

		public void Accept(IReflectionStructureVisitor visitor)
		{
			visitor.VisitAssemblyNameReferenceCollection(this);
		}
	}
}
