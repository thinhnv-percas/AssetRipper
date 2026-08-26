using System;
using System.Collections;

namespace DevX.Cecil
{
	public sealed class ResourceCollection : CollectionBase, IReflectionStructureVisitable
	{
		private ModuleDefinition m_container;

		public Resource this[int index]
		{
			get
			{
				return base.List[index] as Resource;
			}
			set
			{
				base.List[index] = value;
			}
		}

		public ModuleDefinition Container => m_container;

		public ResourceCollection(ModuleDefinition container)
		{
			m_container = container;
		}

		public void Add(Resource value)
		{
			base.List.Add(value);
		}

		public bool Contains(Resource value)
		{
			return base.List.Contains(value);
		}

		public int IndexOf(Resource value)
		{
			return base.List.IndexOf(value);
		}

		public void Insert(int index, Resource value)
		{
			base.List.Insert(index, value);
		}

		public void Remove(Resource value)
		{
			base.List.Remove(value);
		}

		protected override void OnValidate(object o)
		{
			if (!(o is Resource))
			{
				throw new ArgumentException("Must be of type " + typeof(Resource).FullName);
			}
		}

		public void Accept(IReflectionStructureVisitor visitor)
		{
			visitor.VisitResourceCollection(this);
		}
	}
}
