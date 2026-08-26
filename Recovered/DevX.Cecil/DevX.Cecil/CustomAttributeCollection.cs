using System;
using System.Collections;

namespace DevX.Cecil
{
	public sealed class CustomAttributeCollection : CollectionBase, IReflectionVisitable
	{
		private ICustomAttributeProvider m_container;

		public CustomAttribute this[int index]
		{
			get
			{
				return base.List[index] as CustomAttribute;
			}
			set
			{
				base.List[index] = value;
			}
		}

		public ICustomAttributeProvider Container => m_container;

		public CustomAttributeCollection(ICustomAttributeProvider container)
		{
			m_container = container;
		}

		public void Add(CustomAttribute value)
		{
			base.List.Add(value);
		}

		public bool Contains(CustomAttribute value)
		{
			return base.List.Contains(value);
		}

		public int IndexOf(CustomAttribute value)
		{
			return base.List.IndexOf(value);
		}

		public void Insert(int index, CustomAttribute value)
		{
			base.List.Insert(index, value);
		}

		public void Remove(CustomAttribute value)
		{
			base.List.Remove(value);
		}

		protected override void OnValidate(object o)
		{
			if (!(o is CustomAttribute))
			{
				throw new ArgumentException("Must be of type " + typeof(CustomAttribute).FullName);
			}
		}

		public void Accept(IReflectionVisitor visitor)
		{
			visitor.VisitCustomAttributeCollection(this);
		}
	}
}
