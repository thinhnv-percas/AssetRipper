using System;
using System.Collections;

namespace DevX.Cecil
{
	public sealed class MemberReferenceCollection : CollectionBase, IReflectionVisitable
	{
		private ModuleDefinition m_container;

		public MemberReference this[int index]
		{
			get
			{
				return base.List[index] as MemberReference;
			}
			set
			{
				base.List[index] = value;
			}
		}

		public ModuleDefinition Container => m_container;

		public MemberReferenceCollection(ModuleDefinition container)
		{
			m_container = container;
		}

		public void Add(MemberReference value)
		{
			base.List.Add(value);
		}

		public bool Contains(MemberReference value)
		{
			return base.List.Contains(value);
		}

		public int IndexOf(MemberReference value)
		{
			return base.List.IndexOf(value);
		}

		public void Insert(int index, MemberReference value)
		{
			base.List.Insert(index, value);
		}

		public void Remove(MemberReference value)
		{
			base.List.Remove(value);
		}

		protected override void OnValidate(object o)
		{
			if (!(o is MemberReference))
			{
				throw new ArgumentException("Must be of type " + typeof(MemberReference).FullName);
			}
		}

		public void Accept(IReflectionVisitor visitor)
		{
			visitor.VisitMemberReferenceCollection(this);
		}
	}
}
