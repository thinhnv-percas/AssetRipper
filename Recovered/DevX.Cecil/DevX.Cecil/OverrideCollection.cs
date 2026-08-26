using System;
using System.Collections;

namespace DevX.Cecil
{
	public sealed class OverrideCollection : CollectionBase, IReflectionVisitable
	{
		private MethodDefinition m_container;

		public MethodReference this[int index]
		{
			get
			{
				return base.List[index] as MethodReference;
			}
			set
			{
				base.List[index] = value;
			}
		}

		public MethodDefinition Container => m_container;

		public OverrideCollection(MethodDefinition container)
		{
			m_container = container;
		}

		public void Add(MethodReference value)
		{
			base.List.Add(value);
		}

		public bool Contains(MethodReference value)
		{
			return base.List.Contains(value);
		}

		public int IndexOf(MethodReference value)
		{
			return base.List.IndexOf(value);
		}

		public void Insert(int index, MethodReference value)
		{
			base.List.Insert(index, value);
		}

		public void Remove(MethodReference value)
		{
			base.List.Remove(value);
		}

		protected override void OnValidate(object o)
		{
			if (!(o is MethodReference))
			{
				throw new ArgumentException("Must be of type " + typeof(MethodReference).FullName);
			}
		}

		public void Accept(IReflectionVisitor visitor)
		{
			visitor.VisitOverrideCollection(this);
		}
	}
}
