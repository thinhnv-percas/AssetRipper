using System;
using System.Collections;
using System.Collections.Specialized;

namespace DevX.Cecil
{
	public sealed class ExternTypeCollection : NameObjectCollectionBase, IEnumerable, IList, ICollection, IReflectionVisitable
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

		public TypeReference this[int index]
		{
			get
			{
				return BaseGet(index) as TypeReference;
			}
			set
			{
				BaseSet(index, value);
			}
		}

		public TypeReference this[string fullName]
		{
			get
			{
				return BaseGet(fullName) as TypeReference;
			}
			set
			{
				BaseSet(fullName, value);
			}
		}

		public ModuleDefinition Container => m_container;

		public bool IsSynchronized => false;

		public object SyncRoot => this;

		public ExternTypeCollection(ModuleDefinition container)
			: base(HashCodeProvider.Instance, Comparer.Default)
		{
			m_container = container;
		}

		int IList.Add(object value)
		{
			Check(value);
			Add(value as TypeReference);
			return 0;
		}

		bool IList.Contains(object value)
		{
			Check(value);
			return Contains(value as TypeReference);
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
			Remove(value as TypeReference);
		}

		public void Add(TypeReference value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			BaseAdd(value.FullName, value);
		}

		public void Clear()
		{
			BaseClear();
		}

		public bool Contains(TypeReference value)
		{
			return Contains(value.FullName);
		}

		public bool Contains(string fullName)
		{
			return BaseGet(fullName) != null;
		}

		public int IndexOf(TypeReference value)
		{
			string[] array = BaseGetAllKeys();
			return Array.IndexOf(array, value.FullName, 0, array.Length);
		}

		public void Remove(TypeReference value)
		{
			BaseRemove(value.FullName);
		}

		public void RemoveAt(int index)
		{
			TypeReference value = this[index];
			Remove(value);
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
			visitor.VisitExternTypeCollection(this);
		}

		private void Check(object value)
		{
			if (!(value is TypeReference))
			{
				throw new ArgumentException();
			}
		}
	}
}
