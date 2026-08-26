using System;
using System.Collections;

namespace DevX.Cecil
{
	public sealed class NestedTypeCollection : CollectionBase, IReflectionVisitable
	{
		private TypeDefinition m_container;

		public TypeDefinition this[int index]
		{
			get
			{
				return base.List[index] as TypeDefinition;
			}
			set
			{
				base.List[index] = value;
			}
		}

		public TypeDefinition Container => m_container;

		public NestedTypeCollection(TypeDefinition container)
		{
			m_container = container;
		}

		public void Add(TypeDefinition value)
		{
			Attach(value);
			base.List.Add(value);
		}

		public new void Clear()
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					TypeDefinition member = (TypeDefinition)enumerator.Current;
					Detach(member);
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			base.Clear();
		}

		public bool Contains(TypeDefinition value)
		{
			return base.List.Contains(value);
		}

		public int IndexOf(TypeDefinition value)
		{
			return base.List.IndexOf(value);
		}

		public void Insert(int index, TypeDefinition value)
		{
			Attach(value);
			base.List.Insert(index, value);
		}

		public void Remove(TypeDefinition value)
		{
			base.List.Remove(value);
			Detach(value);
		}

		public new void RemoveAt(int index)
		{
			TypeDefinition value = this[index];
			Remove(value);
		}

		protected override void OnValidate(object o)
		{
			if (!(o is TypeDefinition))
			{
				throw new ArgumentException("Must be of type " + typeof(TypeDefinition).FullName);
			}
		}

		private void Attach(MemberReference member)
		{
			if (member.DeclaringType != null)
			{
				throw new ReflectionException("Member already attached, clone it instead");
			}
			member.DeclaringType = m_container;
		}

		private void Detach(MemberReference member)
		{
			member.DeclaringType = null;
		}

		public void Accept(IReflectionVisitor visitor)
		{
			visitor.VisitNestedTypeCollection(this);
		}
	}
}
