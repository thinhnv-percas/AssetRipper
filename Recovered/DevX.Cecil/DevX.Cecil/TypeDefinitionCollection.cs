using System;
using System.Collections;
using System.Collections.Specialized;

namespace DevX.Cecil
{
	public sealed class TypeDefinitionCollection : NameObjectCollectionBase, IEnumerable, IList, ICollection, IReflectionVisitable
	{
		private ModuleDefinition m_container;

		bool IList.IsReadOnly => false;

		bool IList.IsFixedSize => false;

		object IList.this[int index]
		{
			get
			{
				return BaseGet(index);
			}
			set
			{
				Check(value);
				BaseSet(index, value);
			}
		}

		public TypeDefinition this[int index]
		{
			get
			{
				return BaseGet(index) as TypeDefinition;
			}
			set
			{
				BaseSet(index, value);
			}
		}

		public TypeDefinition this[string fullName]
		{
			get
			{
				return BaseGet(fullName) as TypeDefinition;
			}
			set
			{
				BaseSet(fullName, value);
			}
		}

		public ModuleDefinition Container => m_container;

		public bool IsSynchronized => false;

		public object SyncRoot => this;

		public TypeDefinitionCollection(ModuleDefinition container)
			: base(HashCodeProvider.Instance, Comparer.Default)
		{
			m_container = container;
		}

		int IList.Add(object value)
		{
			Check(value);
			Add(value as TypeDefinition);
			return 0;
		}

		bool IList.Contains(object value)
		{
			Check(value);
			return Contains(value as TypeDefinition);
		}

		int IList.IndexOf(object value)
		{
			throw new NotSupportedException();
		}

		void IList.Insert(int index, object value)
		{
			throw new NotSupportedException();
		}

		void IList.Remove(object value)
		{
			Check(value);
			Remove(value as TypeDefinition);
		}

		public void Add(TypeDefinition value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			Attach(value);
			BaseAdd(value.FullName, value);
		}

		public void Clear()
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					TypeDefinition type = (TypeDefinition)enumerator.Current;
					Detach(type);
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
			BaseClear();
		}

		public bool Contains(TypeDefinition value)
		{
			return Contains(value.FullName);
		}

		public bool Contains(string fullName)
		{
			return BaseGet(fullName) != null;
		}

		public int IndexOf(TypeDefinition value)
		{
			string[] array = BaseGetAllKeys();
			return Array.IndexOf(array, value.FullName, 0, array.Length);
		}

		public void Remove(TypeDefinition value)
		{
			BaseRemove(value.FullName);
			Detach(value);
		}

		public void RemoveAt(int index)
		{
			TypeDefinition typeDefinition = this[index];
			Remove(typeDefinition);
			Detach(typeDefinition);
		}

		public void CopyTo(Array ary, int index)
		{
			BaseGetAllValues().CopyTo(ary, index);
		}

		public new IEnumerator GetEnumerator()
		{
			return BaseGetAllValues().GetEnumerator();
		}

		public void Accept(IReflectionVisitor visitor)
		{
			visitor.VisitTypeDefinitionCollection(this);
		}

		private void Check(object value)
		{
			if (!(value is TypeDefinition))
			{
				throw new ArgumentException();
			}
		}

		private void Detach(TypeReference type)
		{
			type.Module = null;
		}

		private void Attach(TypeReference type)
		{
			if (type.Module != null)
			{
				throw new ReflectionException("Type is already attached, clone it instead");
			}
			type.Module = m_container;
			type.AttachToScope(m_container);
		}
	}
}
