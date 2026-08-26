using System;
using System.Collections;

namespace DevX.Cecil
{
	public sealed class GenericParameterCollection : CollectionBase, IReflectionVisitable
	{
		private IGenericParameterProvider m_container;

		public GenericParameter this[int index]
		{
			get
			{
				return base.List[index] as GenericParameter;
			}
			set
			{
				base.List[index] = value;
			}
		}

		public IGenericParameterProvider Container => m_container;

		public GenericParameterCollection(IGenericParameterProvider container)
		{
			m_container = container;
		}

		public void Add(GenericParameter value)
		{
			base.List.Add(value);
		}

		public bool Contains(GenericParameter value)
		{
			return base.List.Contains(value);
		}

		public int IndexOf(GenericParameter value)
		{
			return base.List.IndexOf(value);
		}

		public void Insert(int index, GenericParameter value)
		{
			base.List.Insert(index, value);
		}

		public void Remove(GenericParameter value)
		{
			base.List.Remove(value);
		}

		protected override void OnValidate(object o)
		{
			if (!(o is GenericParameter))
			{
				throw new ArgumentException("Must be of type " + typeof(GenericParameter).FullName);
			}
		}

		public void Accept(IReflectionVisitor visitor)
		{
			visitor.VisitGenericParameterCollection(this);
		}
	}
}
