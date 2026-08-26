using System;
using System.Collections;

namespace DevX.Cecil
{
	public sealed class PropertyDefinitionCollection : CollectionBase, IReflectionVisitable
	{
		private TypeDefinition m_container;

		public PropertyDefinition this[int index]
		{
			get
			{
				return base.List[index] as PropertyDefinition;
			}
			set
			{
				base.List[index] = value;
			}
		}

		public TypeDefinition Container => m_container;

		public PropertyDefinitionCollection(TypeDefinition container)
		{
			m_container = container;
		}

		public void Add(PropertyDefinition value)
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
					PropertyDefinition member = (PropertyDefinition)enumerator.Current;
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

		public bool Contains(PropertyDefinition value)
		{
			return base.List.Contains(value);
		}

		public int IndexOf(PropertyDefinition value)
		{
			return base.List.IndexOf(value);
		}

		public void Insert(int index, PropertyDefinition value)
		{
			Attach(value);
			base.List.Insert(index, value);
		}

		public void Remove(PropertyDefinition value)
		{
			base.List.Remove(value);
			Detach(value);
		}

		public new void RemoveAt(int index)
		{
			PropertyDefinition value = this[index];
			Remove(value);
		}

		protected override void OnValidate(object o)
		{
			if (!(o is PropertyDefinition))
			{
				throw new ArgumentException("Must be of type " + typeof(PropertyDefinition).FullName);
			}
		}

		public PropertyDefinition[] GetProperties(string name)
		{
			ArrayList arrayList = new ArrayList();
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					PropertyDefinition propertyDefinition = (PropertyDefinition)enumerator.Current;
					if (propertyDefinition.Name == name)
					{
						arrayList.Add(propertyDefinition);
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
			return arrayList.ToArray(typeof(PropertyDefinition)) as PropertyDefinition[];
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
			visitor.VisitPropertyDefinitionCollection(this);
		}
	}
}
