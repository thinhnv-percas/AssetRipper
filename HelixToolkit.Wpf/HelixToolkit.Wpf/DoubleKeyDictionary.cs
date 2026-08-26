using System;
using System.Collections;
using System.Collections.Generic;

namespace HelixToolkit.Wpf;

public class DoubleKeyDictionary<K, T, V> : IEnumerable<DoubleKeyPairValue<K, T, V>>, IEnumerable, IEquatable<DoubleKeyDictionary<K, T, V>>
{
	private Dictionary<T, V> m_innerDictionary;

	private Dictionary<K, Dictionary<T, V>> OuterDictionary { get; set; }

	public V this[K index1, T index2]
	{
		get
		{
			return OuterDictionary[index1][index2];
		}
		set
		{
			Add(index1, index2, value);
		}
	}

	public DoubleKeyDictionary()
	{
		OuterDictionary = new Dictionary<K, Dictionary<T, V>>();
	}

	public void Clear()
	{
		OuterDictionary.Clear();
		if (m_innerDictionary != null)
		{
			m_innerDictionary.Clear();
		}
	}

	public void Add(K key1, T key2, V value)
	{
		if (OuterDictionary.ContainsKey(key1))
		{
			if (m_innerDictionary.ContainsKey(key2))
			{
				OuterDictionary[key1][key2] = value;
				return;
			}
			m_innerDictionary = OuterDictionary[key1];
			m_innerDictionary.Add(key2, value);
			OuterDictionary[key1] = m_innerDictionary;
		}
		else
		{
			m_innerDictionary = new Dictionary<T, V>();
			m_innerDictionary[key2] = value;
			OuterDictionary.Add(key1, m_innerDictionary);
		}
	}

	public bool ContainsKey(K index1, T index2)
	{
		if (!OuterDictionary.ContainsKey(index1))
		{
			return false;
		}
		if (!OuterDictionary[index1].ContainsKey(index2))
		{
			return false;
		}
		return true;
	}

	public bool Equals(DoubleKeyDictionary<K, T, V> other)
	{
		if (OuterDictionary.Keys.Count != other.OuterDictionary.Keys.Count)
		{
			return false;
		}
		bool flag = true;
		foreach (KeyValuePair<K, Dictionary<T, V>> item in OuterDictionary)
		{
			if (!other.OuterDictionary.ContainsKey(item.Key))
			{
				flag = false;
			}
			if (!flag)
			{
				break;
			}
			Dictionary<T, V> dictionary = other.OuterDictionary[item.Key];
			foreach (KeyValuePair<T, V> item2 in item.Value)
			{
				if (!dictionary.ContainsValue(item2.Value))
				{
					flag = false;
				}
				if (!dictionary.ContainsKey(item2.Key))
				{
					flag = false;
				}
			}
			if (!flag)
			{
				break;
			}
		}
		return flag;
	}

	public IEnumerator<DoubleKeyPairValue<K, T, V>> GetEnumerator()
	{
		foreach (KeyValuePair<K, Dictionary<T, V>> outer in OuterDictionary)
		{
			foreach (KeyValuePair<T, V> inner in outer.Value)
			{
				yield return new DoubleKeyPairValue<K, T, V>(outer.Key, inner.Key, inner.Value);
			}
		}
	}

	public void Remove(K key1, T key2)
	{
		OuterDictionary[key1].Remove(key2);
		if (OuterDictionary[key1].Count == 0)
		{
			OuterDictionary.Remove(key1);
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
