using System.Collections;
using System.Collections.Generic;

namespace System.Net.Http.Headers;

public sealed class HttpHeaderValueCollection<T> : ICollection<T>, IEnumerable<T>, IEnumerable where T : class
{
	private string _headerName;

	private HttpHeaders _store;

	private T _specialValue;

	private Action<HttpHeaderValueCollection<T>, T> _validator;

	public int Count => GetCount();

	public bool IsReadOnly => false;

	internal bool IsSpecialValueSet
	{
		get
		{
			if (_specialValue == null)
			{
				return false;
			}
			return _store.ContainsParsedValue(_headerName, _specialValue);
		}
	}

	internal HttpHeaderValueCollection(string headerName, HttpHeaders store)
		: this(headerName, store, (T)null, (Action<HttpHeaderValueCollection<T>, T>)null)
	{
	}

	internal HttpHeaderValueCollection(string headerName, HttpHeaders store, Action<HttpHeaderValueCollection<T>, T> validator)
		: this(headerName, store, (T)null, validator)
	{
	}

	internal HttpHeaderValueCollection(string headerName, HttpHeaders store, T specialValue)
		: this(headerName, store, specialValue, (Action<HttpHeaderValueCollection<T>, T>)null)
	{
	}

	internal HttpHeaderValueCollection(string headerName, HttpHeaders store, T specialValue, Action<HttpHeaderValueCollection<T>, T> validator)
	{
		_store = store;
		_headerName = headerName;
		_specialValue = specialValue;
		_validator = validator;
	}

	public void Add(T item)
	{
		CheckValue(item);
		_store.AddParsedValue(_headerName, item);
	}

	public void ParseAdd(string input)
	{
		_store.Add(_headerName, input);
	}

	public bool TryParseAdd(string input)
	{
		return _store.TryParseAndAddValue(_headerName, input);
	}

	public void Clear()
	{
		_store.Remove(_headerName);
	}

	public bool Contains(T item)
	{
		CheckValue(item);
		return _store.ContainsParsedValue(_headerName, item);
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		if (arrayIndex < 0 || arrayIndex > array.Length)
		{
			throw new ArgumentOutOfRangeException("arrayIndex");
		}
		object parsedValues = _store.GetParsedValues(_headerName);
		if (parsedValues == null)
		{
			return;
		}
		if (!(parsedValues is List<object> list))
		{
			if (arrayIndex == array.Length)
			{
				throw new ArgumentException(System.SR.net_http_copyto_array_too_small);
			}
			array[arrayIndex] = parsedValues as T;
		}
		else
		{
			list.CopyTo(array, arrayIndex);
		}
	}

	public bool Remove(T item)
	{
		CheckValue(item);
		return _store.RemoveParsedValue(_headerName, item);
	}

	public IEnumerator<T> GetEnumerator()
	{
		object parsedValues = _store.GetParsedValues(_headerName);
		if (parsedValues == null)
		{
			yield break;
		}
		if (!(parsedValues is List<object> storeValues))
		{
			yield return parsedValues as T;
			yield break;
		}
		foreach (object item in storeValues)
		{
			yield return item as T;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public override string ToString()
	{
		return _store.GetHeaderString(_headerName);
	}

	internal string GetHeaderStringWithoutSpecial()
	{
		if (!IsSpecialValueSet)
		{
			return ToString();
		}
		return _store.GetHeaderString(_headerName, _specialValue);
	}

	internal void SetSpecialValue()
	{
		if (!_store.ContainsParsedValue(_headerName, _specialValue))
		{
			_store.AddParsedValue(_headerName, _specialValue);
		}
	}

	internal void RemoveSpecialValue()
	{
		_store.RemoveParsedValue(_headerName, _specialValue);
	}

	private void CheckValue(T item)
	{
		if (item == null)
		{
			throw new ArgumentNullException("item");
		}
		if (_validator != null)
		{
			_validator(this, item);
		}
	}

	private int GetCount()
	{
		object parsedValues = _store.GetParsedValues(_headerName);
		if (parsedValues == null)
		{
			return 0;
		}
		if (!(parsedValues is List<object> list))
		{
			return 1;
		}
		return list.Count;
	}
}
