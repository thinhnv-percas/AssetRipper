using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;

namespace Microsoft.VisualStudio.Composition;

internal static class ByValueEquality
{
	private class AssemblyNameComparer : IEqualityComparer<AssemblyName>
	{
		internal static readonly AssemblyNameComparer Default = new AssemblyNameComparer();

		internal static readonly AssemblyNameComparer NoFastCheck = new AssemblyNameComparer(fastCheck: false);

		private bool fastCheck;

		internal AssemblyNameComparer(bool fastCheck = true)
		{
			this.fastCheck = fastCheck;
		}

		public bool Equals(AssemblyName x, AssemblyName y)
		{
			if ((x == null) ^ (y == null))
			{
				return false;
			}
			if (x == null)
			{
				return true;
			}
			if (fastCheck && x.CodeBase == y.CodeBase)
			{
				return true;
			}
			byte[] publicKey = x.GetPublicKey();
			byte[] publicKey2 = y.GetPublicKey();
			if (publicKey != null && publicKey2 != null)
			{
				if (x.Name == y.Name && x.Version.Equals(y.Version) && string.Equals(x.CultureName, y.CultureName))
				{
					return Buffer.Equals(publicKey, publicKey2);
				}
				return false;
			}
			if (x.Name == y.Name && x.Version.Equals(y.Version) && string.Equals(x.CultureName, y.CultureName))
			{
				return Buffer.Equals(x.GetPublicKeyToken(), y.GetPublicKeyToken());
			}
			return false;
		}

		public int GetHashCode(AssemblyName obj)
		{
			return obj.Name.GetHashCode();
		}
	}

	private class BufferComparer : IEqualityComparer<byte[]>
	{
		internal static readonly BufferComparer Default = new BufferComparer();

		private BufferComparer()
		{
		}

		public bool Equals(byte[] x, byte[] y)
		{
			if (x == y)
			{
				return true;
			}
			if ((x == null) ^ (y == null))
			{
				return false;
			}
			if (x.Length != y.Length)
			{
				return false;
			}
			for (int i = 0; i < x.Length; i++)
			{
				if (x[i] != y[i])
				{
					return false;
				}
			}
			return true;
		}

		public int GetHashCode(byte[] obj)
		{
			throw new NotImplementedException();
		}
	}

	private class CollectionIgnoreOrder<T> : IEqualityComparer<IReadOnlyCollection<T>>
	{
		internal static readonly CollectionIgnoreOrder<T> Default = new CollectionIgnoreOrder<T>();

		protected virtual IEqualityComparer<T> ValueComparer => EqualityComparer<T>.Default;

		private CollectionIgnoreOrder()
		{
		}

		public bool Equals(IReadOnlyCollection<T> x, IReadOnlyCollection<T> y)
		{
			if (x == y)
			{
				return true;
			}
			if ((x == null) ^ (y == null))
			{
				return false;
			}
			if (x == null)
			{
				return true;
			}
			if (x.Count != y.Count)
			{
				return false;
			}
			IEqualityComparer<T> valueComparer = ValueComparer;
			bool[] array = new bool[y.Count];
			IReadOnlyList<T> readOnlyList = (y as IReadOnlyList<T>) ?? y.ToList();
			foreach (T item in x)
			{
				int i;
				for (i = 0; i < y.Count; i++)
				{
					if (!array[i] && valueComparer.Equals(item, readOnlyList[i]))
					{
						array[i] = true;
						break;
					}
				}
				if (i == y.Count)
				{
					return false;
				}
			}
			return true;
		}

		public int GetHashCode(IReadOnlyCollection<T> obj)
		{
			int num = obj.Count;
			foreach (T item in obj)
			{
				num += item.GetHashCode();
			}
			return num;
		}
	}

	private class DictionaryEqualityComparer<TKey, TValue> : IEqualityComparer<IReadOnlyDictionary<TKey, TValue>>
	{
		private readonly IEqualityComparer<TValue> valueComparer;

		internal static readonly DictionaryEqualityComparer<TKey, TValue> Default = new DictionaryEqualityComparer<TKey, TValue>();

		protected DictionaryEqualityComparer(IEqualityComparer<TValue> valueComparer = null)
		{
			this.valueComparer = valueComparer ?? EqualityComparer<TValue>.Default;
		}

		internal static DictionaryEqualityComparer<TKey, TValue> Get(IEqualityComparer<TValue> valueComparer = null)
		{
			if (valueComparer == null || valueComparer == EqualityComparer<TValue>.Default)
			{
				return Default;
			}
			return new DictionaryEqualityComparer<TKey, TValue>(valueComparer);
		}

		public virtual bool Equals(IReadOnlyDictionary<TKey, TValue> x, IReadOnlyDictionary<TKey, TValue> y)
		{
			if (x == y)
			{
				return true;
			}
			if (x.Count != y.Count)
			{
				return false;
			}
			foreach (KeyValuePair<TKey, TValue> item in x)
			{
				if (!y.TryGetValue(item.Key, out var value))
				{
					return false;
				}
				if (!valueComparer.Equals(item.Value, value))
				{
					return false;
				}
			}
			return true;
		}

		public virtual int GetHashCode(IReadOnlyDictionary<TKey, TValue> obj)
		{
			int num = obj.Count;
			foreach (KeyValuePair<TKey, TValue> item in obj)
			{
				num += item.Key.GetHashCode();
			}
			return obj.Count;
		}
	}

	private class MetadataDictionaryEqualityComparer : DictionaryEqualityComparer<string, object>
	{
		private class MetadataValueComparer : IEqualityComparer<object>
		{
			internal static readonly MetadataValueComparer Default = new MetadataValueComparer();

			private MetadataValueComparer()
			{
			}

			public new bool Equals(object x, object y)
			{
				if (x == y)
				{
					return true;
				}
				if ((x == null) ^ (y == null))
				{
					return false;
				}
				LazyMetadataWrapper.ISubstitutedValue substitutedValue = x as LazyMetadataWrapper.ISubstitutedValue;
				LazyMetadataWrapper.ISubstitutedValue substitutedValue2 = y as LazyMetadataWrapper.ISubstitutedValue;
				if (substitutedValue != null || substitutedValue2 != null)
				{
					return substitutedValue?.Equals(y) ?? substitutedValue2.Equals(x);
				}
				if (x.GetType() != y.GetType() && (!x.GetType().IsArray || !y.GetType().IsArray || !typeof(Type).GetTypeInfo().IsAssignableFrom(x.GetType().GetElementType()) || !typeof(Type).GetTypeInfo().IsAssignableFrom(y.GetType().GetElementType())))
				{
					return false;
				}
				if (x.GetType().IsArray)
				{
					return ArrayEquals((Array)x, (Array)y, (object v) => v);
				}
				return x.Equals(y);
			}

			private static bool ArrayEquals(Array xArray, Array yArray, Func<object, object> translator)
			{
				if (xArray.Length != yArray.Length)
				{
					return false;
				}
				for (int i = 0; i < xArray.Length; i++)
				{
					if (!EqualityComparer<object>.Default.Equals(translator(xArray.GetValue(i)), translator(yArray.GetValue(i))))
					{
						return false;
					}
				}
				return true;
			}

			public int GetHashCode(object obj)
			{
				throw new NotImplementedException();
			}
		}

		internal new static readonly MetadataDictionaryEqualityComparer Default = new MetadataDictionaryEqualityComparer();

		protected MetadataDictionaryEqualityComparer()
			: base((IEqualityComparer<object>)MetadataValueComparer.Default)
		{
		}

		public override int GetHashCode(IReadOnlyDictionary<string, object> obj)
		{
			if (obj.TryGetValue<string>("ExportTypeIdentity", out var value) && value != null)
			{
				return value.GetHashCode();
			}
			return 1;
		}

		public override bool Equals(IReadOnlyDictionary<string, object> x, IReadOnlyDictionary<string, object> y)
		{
			if (x == y)
			{
				return true;
			}
			return base.Equals(LazyMetadataWrapper.TryUnwrap(x), LazyMetadataWrapper.TryUnwrap(y));
		}
	}

	private class DictionaryOfImmutableHashSetEqualityComparer<TKey, TValue> : DictionaryEqualityComparer<TKey, ImmutableHashSet<TValue>>
	{
		private class SetEqualityComparer : IEqualityComparer<ImmutableHashSet<TValue>>
		{
			internal static readonly SetEqualityComparer Default = new SetEqualityComparer();

			private SetEqualityComparer()
			{
			}

			public bool Equals(ImmutableHashSet<TValue> x, ImmutableHashSet<TValue> y)
			{
				if ((x == null) ^ (y == null))
				{
					return false;
				}
				return x?.SetEquals(y) ?? true;
			}

			public int GetHashCode(ImmutableHashSet<TValue> obj)
			{
				return obj.Count;
			}
		}

		internal new static readonly DictionaryOfImmutableHashSetEqualityComparer<TKey, TValue> Default = new DictionaryOfImmutableHashSetEqualityComparer<TKey, TValue>();

		protected DictionaryOfImmutableHashSetEqualityComparer()
			: base((IEqualityComparer<ImmutableHashSet<TValue>>)SetEqualityComparer.Default)
		{
		}
	}

	internal static IEqualityComparer<AssemblyName> AssemblyName => AssemblyNameComparer.Default;

	internal static IEqualityComparer<AssemblyName> AssemblyNameNoFastCheck => AssemblyNameComparer.NoFastCheck;

	internal static IEqualityComparer<byte[]> Buffer => BufferComparer.Default;

	internal static IEqualityComparer<IReadOnlyDictionary<string, object>> Metadata => MetadataDictionaryEqualityComparer.Default;

	internal static IEqualityComparer<IReadOnlyDictionary<TKey, TValue>> Dictionary<TKey, TValue>(IEqualityComparer<TValue> valueComparer = null)
	{
		return DictionaryEqualityComparer<TKey, TValue>.Get(valueComparer);
	}

	internal static IEqualityComparer<IReadOnlyDictionary<TKey, ImmutableHashSet<TValue>>> DictionaryOfImmutableHashSet<TKey, TValue>()
	{
		return DictionaryOfImmutableHashSetEqualityComparer<TKey, TValue>.Default;
	}

	internal static IEqualityComparer<IReadOnlyCollection<T>> EquivalentIgnoreOrder<T>()
	{
		return CollectionIgnoreOrder<T>.Default;
	}
}
