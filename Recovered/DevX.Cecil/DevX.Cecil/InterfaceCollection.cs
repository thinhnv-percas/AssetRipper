using System;
using System.Collections;

namespace DevX.Cecil
{
	public sealed class InterfaceCollection : CollectionBase, IReflectionVisitable
	{
		private TypeDefinition m_container;

		public TypeReference this[int index]
		{
			get
			{
				return base.List[index] as TypeReference;
			}
			set
			{
				base.List[index] = value;
			}
		}

		public TypeDefinition Container => m_container;

		public InterfaceCollection(TypeDefinition container)
		{
			m_container = container;
		}

		public void Add(TypeReference value)
		{
			base.List.Add(value);
		}

		public bool Contains(TypeReference value)
		{
			return base.List.Contains(value);
		}

		public int IndexOf(TypeReference value)
		{
			return base.List.IndexOf(value);
		}

		public void Insert(int index, TypeReference value)
		{
			base.List.Insert(index, value);
		}

		public void Remove(TypeReference value)
		{
			base.List.Remove(value);
		}

		protected override void OnValidate(object o)
		{
			if (!(o is TypeReference))
			{
				throw new ArgumentException("Must be of type " + typeof(TypeReference).FullName);
			}
		}

		public void Accept(IReflectionVisitor visitor)
		{
			visitor.VisitInterfaceCollection(this);
		}
	}
}
