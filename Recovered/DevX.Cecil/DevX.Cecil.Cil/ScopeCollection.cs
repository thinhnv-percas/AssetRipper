using System;
using System.Collections;

namespace DevX.Cecil.Cil
{
	public sealed class ScopeCollection : CollectionBase, ICodeVisitable
	{
		private IScopeProvider m_container;

		public Scope this[int index]
		{
			get
			{
				return base.List[index] as Scope;
			}
			set
			{
				base.List[index] = value;
			}
		}

		public IScopeProvider Container => m_container;

		public ScopeCollection(IScopeProvider container)
		{
			m_container = container;
		}

		public void Add(Scope value)
		{
			base.List.Add(value);
		}

		public bool Contains(Scope value)
		{
			return base.List.Contains(value);
		}

		public int IndexOf(Scope value)
		{
			return base.List.IndexOf(value);
		}

		public void Insert(int index, Scope value)
		{
			base.List.Insert(index, value);
		}

		public void Remove(Scope value)
		{
			base.List.Remove(value);
		}

		protected override void OnValidate(object o)
		{
			if (!(o is Scope))
			{
				throw new ArgumentException("Must be of type " + typeof(Scope).FullName);
			}
		}

		public void Accept(ICodeVisitor visitor)
		{
			visitor.VisitScopeCollection(this);
		}
	}
}
