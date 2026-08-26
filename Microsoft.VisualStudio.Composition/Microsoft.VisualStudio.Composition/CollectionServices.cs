using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Microsoft.VisualStudio.Composition;

internal static class CollectionServices
{
	private class CollectionOfObjectList : ICollection<object>, IEnumerable<object>, IEnumerable
	{
		private readonly IList list;

		public int Count
		{
			get
			{
				throw Assumes.NotReachable();
			}
		}

		public bool IsReadOnly => list.IsReadOnly;

		public CollectionOfObjectList(IList list)
		{
			this.list = list;
		}

		public void Add(object item)
		{
			list.Add(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		public bool Contains(object item)
		{
			throw Assumes.NotReachable();
		}

		public void CopyTo(object[] array, int arrayIndex)
		{
			throw Assumes.NotReachable();
		}

		public bool Remove(object item)
		{
			throw Assumes.NotReachable();
		}

		public IEnumerator<object> GetEnumerator()
		{
			throw Assumes.NotReachable();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw Assumes.NotReachable();
		}
	}

	private class CollectionOfObject<T> : ICollection<object>, IEnumerable<object>, IEnumerable
	{
		private readonly ICollection<T> collectionOfT;

		public int Count
		{
			get
			{
				throw Assumes.NotReachable();
			}
		}

		public bool IsReadOnly => collectionOfT.IsReadOnly;

		public CollectionOfObject(object collectionOfT)
		{
			this.collectionOfT = (ICollection<T>)collectionOfT;
		}

		public void Add(object item)
		{
			collectionOfT.Add((T)item);
		}

		public void Clear()
		{
			collectionOfT.Clear();
		}

		public bool Contains(object item)
		{
			throw Assumes.NotReachable();
		}

		public void CopyTo(object[] array, int arrayIndex)
		{
			throw Assumes.NotReachable();
		}

		public bool Remove(object item)
		{
			throw Assumes.NotReachable();
		}

		public IEnumerator<object> GetEnumerator()
		{
			throw Assumes.NotReachable();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw Assumes.NotReachable();
		}
	}

	private static readonly Type[] CollectionOfObjectCtorArgTypes = new Type[1] { typeof(object) };

	private static readonly ConstructorInfo CollectionOfObjectCtor = typeof(CollectionOfObject<>).GetTypeInfo().GetConstructor(CollectionOfObjectCtorArgTypes);

	private static readonly Dictionary<Type, Func<object, ICollection<object>>> CachedCollectionWrapperFactories = new Dictionary<Type, Func<object, ICollection<object>>>();

	internal static ICollection<object> GetCollectionWrapper(Type itemType, object collectionObject)
	{
		Requires.NotNull(itemType, "itemType");
		Requires.NotNull(collectionObject, "collectionObject");
		Type underlyingSystemType = itemType.GetTypeInfo().UnderlyingSystemType;
		if (underlyingSystemType == typeof(object))
		{
			return (ICollection<object>)collectionObject;
		}
		if (typeof(IList).GetTypeInfo().IsAssignableFrom(collectionObject.GetType().GetTypeInfo()))
		{
			return new CollectionOfObjectList((IList)collectionObject);
		}
		Func<object, ICollection<object>> value;
		lock (CachedCollectionWrapperFactories)
		{
			CachedCollectionWrapperFactories.TryGetValue(underlyingSystemType, out value);
		}
		if (value == null)
		{
			Type type = typeof(CollectionOfObject<>).MakeGenericType(underlyingSystemType);
			ConstructorInfo ctor = (ConstructorInfo)MethodBase.GetMethodFromHandle(CollectionOfObjectCtor.MethodHandle, type.TypeHandle);
			value = delegate(object collection)
			{
				using Rental<object[]> rental = ArrayRental<object>.Get(1);
				rental.Value[0] = collection;
				return (ICollection<object>)ctor.Invoke(rental.Value);
			};
			lock (CachedCollectionWrapperFactories)
			{
				CachedCollectionWrapperFactories[underlyingSystemType] = value;
			}
		}
		return value(collectionObject);
	}
}
