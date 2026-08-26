using System;
using System.Collections;

namespace DevX.Cecil
{
	public sealed class FieldDefinitionCollection : CollectionBase, IReflectionVisitable
	{
		private TypeDefinition m_container;

		public FieldDefinition this[int index]
		{
			get
			{
				return base.List[index] as FieldDefinition;
			}
			set
			{
				base.List[index] = value;
			}
		}

		public TypeDefinition Container => m_container;

		public FieldDefinitionCollection(TypeDefinition container)
		{
			m_container = container;
		}

		public void Add(FieldDefinition value)
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
					FieldDefinition member = (FieldDefinition)enumerator.Current;
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

		public bool Contains(FieldDefinition value)
		{
			return base.List.Contains(value);
		}

		public int IndexOf(FieldDefinition value)
		{
			return base.List.IndexOf(value);
		}

		public void Insert(int index, FieldDefinition value)
		{
			Attach(value);
			base.List.Insert(index, value);
		}

		public void Remove(FieldDefinition value)
		{
			base.List.Remove(value);
			Detach(value);
		}

		public new void RemoveAt(int index)
		{
			FieldDefinition value = this[index];
			Remove(value);
		}

		protected override void OnValidate(object o)
		{
			if (!(o is FieldDefinition))
			{
				throw new ArgumentException("Must be of type " + typeof(FieldDefinition).FullName);
			}
		}

		public FieldDefinition GetField(string name)
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					FieldDefinition fieldDefinition = (FieldDefinition)enumerator.Current;
					if (fieldDefinition.Name == name)
					{
						return fieldDefinition;
					}
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
			return null;
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
			visitor.VisitFieldDefinitionCollection(this);
		}
	}
}
