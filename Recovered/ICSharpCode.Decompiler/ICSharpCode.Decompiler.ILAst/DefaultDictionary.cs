using System;
using System.Collections;
using System.Collections.Generic;

namespace ICSharpCode.Decompiler.ILAst
{
	internal sealed class DefaultDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
	{
		private readonly IDictionary<TKey, TValue> dict;

		private readonly Func<TKey, TValue> defaultProvider;

		public TValue this[TKey key]
		{
			get
			{
				if (dict.TryGetValue(key, out TValue value))
				{
					return value;
				}
				return dict[key] = defaultProvider(key);
			}
			set
			{
				dict[key] = value;
			}
		}

		public ICollection<TKey> Keys => dict.Keys;

		public ICollection<TValue> Values => dict.Values;

		public int Count => dict.Count;

		bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => false;

		public DefaultDictionary(TValue defaultValue, IDictionary<TKey, TValue> dictionary = null)
			: this((Func<TKey, TValue>)((TKey key) => defaultValue), dictionary)
		{
		}

		public DefaultDictionary(Func<TKey, TValue> defaultProvider = null, IDictionary<TKey, TValue> dictionary = null)
		{
			dict = (dictionary ?? new Dictionary<TKey, TValue>());
			this.defaultProvider = (defaultProvider ?? ((Func<TKey, TValue>)((TKey key) => default(TValue))));
		}

		public bool ContainsKey(TKey key)
		{
			return dict.ContainsKey(key);
		}

		public void Add(TKey key, TValue value)
		{
			dict.Add(key, value);
		}

		public bool Remove(TKey key)
		{
			return dict.Remove(key);
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			return dict.TryGetValue(key, out value);
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
		{
			dict.Add(item);
		}

		public void Clear()
		{
			dict.Clear();
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item)
		{
			return dict.Contains(item);
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			dict.CopyTo(array, arrayIndex);
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
		{
			return dict.Remove(item);
		}

		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			return dict.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return dict.GetEnumerator();
		}
	}
}
