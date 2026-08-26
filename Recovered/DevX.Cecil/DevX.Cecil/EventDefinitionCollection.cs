using System;
using System.Collections;

namespace DevX.Cecil
{
	public sealed class EventDefinitionCollection : CollectionBase, IReflectionVisitable
	{
		private TypeDefinition m_container;

		public EventDefinition this[int index]
		{
			get
			{
				return base.List[index] as EventDefinition;
			}
			set
			{
				base.List[index] = value;
			}
		}

		public TypeDefinition Container => m_container;

		public EventDefinitionCollection(TypeDefinition container)
		{
			m_container = container;
		}

		public void Add(EventDefinition value)
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
					EventDefinition member = (EventDefinition)enumerator.Current;
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

		public bool Contains(EventDefinition value)
		{
			return base.List.Contains(value);
		}

		public int IndexOf(EventDefinition value)
		{
			return base.List.IndexOf(value);
		}

		public void Insert(int index, EventDefinition value)
		{
			Attach(value);
			base.List.Insert(index, value);
		}

		public void Remove(EventDefinition value)
		{
			base.List.Remove(value);
			Detach(value);
		}

		public new void RemoveAt(int index)
		{
			EventDefinition value = this[index];
			Remove(value);
		}

		protected override void OnValidate(object o)
		{
			if (!(o is EventDefinition))
			{
				throw new ArgumentException("Must be of type " + typeof(EventDefinition).FullName);
			}
		}

		public EventDefinition GetEvent(string name)
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					EventDefinition eventDefinition = (EventDefinition)enumerator.Current;
					if (eventDefinition.Name == name)
					{
						return eventDefinition;
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
			visitor.VisitEventDefinitionCollection(this);
		}
	}
}
