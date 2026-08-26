using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace System.Net.Http.Headers;

public abstract class HttpHeaders : IEnumerable<KeyValuePair<string, IEnumerable<string>>>, IEnumerable
{
	private enum StoreLocation
	{
		Raw,
		Invalid,
		Parsed
	}

	private class HeaderStoreItemInfo
	{
		private object _rawValue;

		private object _invalidValue;

		private object _parsedValue;

		private HttpHeaderParser _parser;

		internal object RawValue
		{
			get
			{
				return _rawValue;
			}
			set
			{
				_rawValue = value;
			}
		}

		internal object InvalidValue
		{
			get
			{
				return _invalidValue;
			}
			set
			{
				_invalidValue = value;
			}
		}

		internal object ParsedValue
		{
			get
			{
				return _parsedValue;
			}
			set
			{
				_parsedValue = value;
			}
		}

		internal HttpHeaderParser Parser => _parser;

		internal bool CanAddValue
		{
			get
			{
				if (!_parser.SupportsMultipleValues)
				{
					if (_invalidValue == null)
					{
						return _parsedValue == null;
					}
					return false;
				}
				return true;
			}
		}

		internal bool IsEmpty
		{
			get
			{
				if (_rawValue == null && _invalidValue == null)
				{
					return _parsedValue == null;
				}
				return false;
			}
		}

		internal HeaderStoreItemInfo(HttpHeaderParser parser)
		{
			_parser = parser;
		}
	}

	private Dictionary<string, HeaderStoreItemInfo> _headerStore;

	private Dictionary<string, HttpHeaderParser> _parserStore;

	private HashSet<string> _invalidHeaders;

	public void Add(string name, string value)
	{
		CheckHeaderName(name);
		PrepareHeaderInfoForAdd(name, out var info, out var addToStore);
		ParseAndAddValue(name, info, value);
		if (addToStore && info.ParsedValue != null)
		{
			AddHeaderToStore(name, info);
		}
	}

	public void Add(string name, IEnumerable<string> values)
	{
		if (values == null)
		{
			throw new ArgumentNullException("values");
		}
		CheckHeaderName(name);
		PrepareHeaderInfoForAdd(name, out var info, out var addToStore);
		try
		{
			foreach (string value in values)
			{
				ParseAndAddValue(name, info, value);
			}
		}
		finally
		{
			if (addToStore && info.ParsedValue != null)
			{
				AddHeaderToStore(name, info);
			}
		}
	}

	public bool TryAddWithoutValidation(string name, string value)
	{
		if (!TryCheckHeaderName(name))
		{
			return false;
		}
		if (value == null)
		{
			value = string.Empty;
		}
		HeaderStoreItemInfo orCreateHeaderInfo = GetOrCreateHeaderInfo(name, parseRawValues: false);
		AddValue(orCreateHeaderInfo, value, StoreLocation.Raw);
		return true;
	}

	public bool TryAddWithoutValidation(string name, IEnumerable<string> values)
	{
		if (values == null)
		{
			throw new ArgumentNullException("values");
		}
		if (!TryCheckHeaderName(name))
		{
			return false;
		}
		HeaderStoreItemInfo orCreateHeaderInfo = GetOrCreateHeaderInfo(name, parseRawValues: false);
		foreach (string value in values)
		{
			AddValue(orCreateHeaderInfo, value ?? string.Empty, StoreLocation.Raw);
		}
		return true;
	}

	public void Clear()
	{
		if (_headerStore != null)
		{
			_headerStore.Clear();
		}
	}

	public bool Remove(string name)
	{
		CheckHeaderName(name);
		if (_headerStore == null)
		{
			return false;
		}
		return _headerStore.Remove(name);
	}

	public IEnumerable<string> GetValues(string name)
	{
		CheckHeaderName(name);
		if (!TryGetValues(name, out var values))
		{
			throw new InvalidOperationException(System.SR.net_http_headers_not_found);
		}
		return values;
	}

	public bool TryGetValues(string name, out IEnumerable<string> values)
	{
		if (!TryCheckHeaderName(name))
		{
			values = null;
			return false;
		}
		if (_headerStore == null)
		{
			values = null;
			return false;
		}
		HeaderStoreItemInfo info = null;
		if (TryGetAndParseHeaderInfo(name, out info))
		{
			values = GetValuesAsStrings(info);
			return true;
		}
		values = null;
		return false;
	}

	public bool Contains(string name)
	{
		CheckHeaderName(name);
		if (_headerStore == null)
		{
			return false;
		}
		HeaderStoreItemInfo info = null;
		return TryGetAndParseHeaderInfo(name, out info);
	}

	public override string ToString()
	{
		if (_headerStore == null || _headerStore.Count == 0)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		using (IEnumerator<KeyValuePair<string, IEnumerable<string>>> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<string, IEnumerable<string>> current = enumerator.Current;
				stringBuilder.Append(current.Key);
				stringBuilder.Append(": ");
				stringBuilder.Append(GetHeaderString(current.Key));
				stringBuilder.Append("\r\n");
			}
		}
		return stringBuilder.ToString();
	}

	internal IEnumerable<KeyValuePair<string, string>> GetHeaderStrings()
	{
		if (_headerStore == null)
		{
			yield break;
		}
		foreach (KeyValuePair<string, HeaderStoreItemInfo> item in _headerStore)
		{
			HeaderStoreItemInfo value = item.Value;
			string headerString = GetHeaderString(value);
			yield return new KeyValuePair<string, string>(item.Key, headerString);
		}
	}

	internal string GetHeaderString(string headerName)
	{
		return GetHeaderString(headerName, null);
	}

	internal string GetHeaderString(string headerName, object exclude)
	{
		if (!TryGetHeaderInfo(headerName, out var info))
		{
			return string.Empty;
		}
		return GetHeaderString(info, exclude);
	}

	private string GetHeaderString(HeaderStoreItemInfo info)
	{
		return GetHeaderString(info, null);
	}

	private string GetHeaderString(HeaderStoreItemInfo info, object exclude)
	{
		string[] valuesAsStrings = GetValuesAsStrings(info, exclude);
		if (valuesAsStrings.Length == 1)
		{
			return valuesAsStrings[0];
		}
		string separator = ", ";
		if (info.Parser != null && info.Parser.SupportsMultipleValues)
		{
			separator = info.Parser.Separator;
		}
		return string.Join(separator, valuesAsStrings);
	}

	public IEnumerator<KeyValuePair<string, IEnumerable<string>>> GetEnumerator()
	{
		if (_headerStore == null || _headerStore.Count <= 0)
		{
			return ((IEnumerable<KeyValuePair<string, IEnumerable<string>>>)Array.Empty<KeyValuePair<string, IEnumerable<string>>>()).GetEnumerator();
		}
		return GetEnumeratorCore();
	}

	private IEnumerator<KeyValuePair<string, IEnumerable<string>>> GetEnumeratorCore()
	{
		List<string> invalidHeaders = null;
		foreach (KeyValuePair<string, HeaderStoreItemInfo> item in _headerStore)
		{
			HeaderStoreItemInfo value = item.Value;
			if (!ParseRawHeaderValues(item.Key, value, removeEmptyHeader: false))
			{
				if (invalidHeaders == null)
				{
					invalidHeaders = new List<string>();
				}
				invalidHeaders.Add(item.Key);
			}
			else
			{
				string[] valuesAsStrings = GetValuesAsStrings(value);
				yield return new KeyValuePair<string, IEnumerable<string>>(item.Key, valuesAsStrings);
			}
		}
		if (invalidHeaders == null)
		{
			yield break;
		}
		foreach (string item2 in invalidHeaders)
		{
			_headerStore.Remove(item2);
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	internal void SetConfiguration(Dictionary<string, HttpHeaderParser> parserStore, HashSet<string> invalidHeaders)
	{
		_parserStore = parserStore;
		_invalidHeaders = invalidHeaders;
	}

	internal void AddParsedValue(string name, object value)
	{
		HeaderStoreItemInfo orCreateHeaderInfo = GetOrCreateHeaderInfo(name, parseRawValues: true);
		AddValue(orCreateHeaderInfo, value, StoreLocation.Parsed);
	}

	internal void SetParsedValue(string name, object value)
	{
		HeaderStoreItemInfo orCreateHeaderInfo = GetOrCreateHeaderInfo(name, parseRawValues: true);
		orCreateHeaderInfo.InvalidValue = null;
		orCreateHeaderInfo.ParsedValue = null;
		orCreateHeaderInfo.RawValue = null;
		AddValue(orCreateHeaderInfo, value, StoreLocation.Parsed);
	}

	internal void SetOrRemoveParsedValue(string name, object value)
	{
		if (value == null)
		{
			Remove(name);
		}
		else
		{
			SetParsedValue(name, value);
		}
	}

	internal bool RemoveParsedValue(string name, object value)
	{
		if (_headerStore == null)
		{
			return false;
		}
		HeaderStoreItemInfo info = null;
		if (TryGetAndParseHeaderInfo(name, out info))
		{
			bool result = false;
			if (info.ParsedValue == null)
			{
				return false;
			}
			IEqualityComparer comparer = info.Parser.Comparer;
			if (!(info.ParsedValue is List<object> list))
			{
				if (AreEqual(value, info.ParsedValue, comparer))
				{
					info.ParsedValue = null;
					result = true;
				}
			}
			else
			{
				foreach (object item in list)
				{
					if (AreEqual(value, item, comparer))
					{
						result = list.Remove(item);
						break;
					}
				}
				if (list.Count == 0)
				{
					info.ParsedValue = null;
				}
			}
			if (info.IsEmpty)
			{
				bool flag = Remove(name);
			}
			return result;
		}
		return false;
	}

	internal bool ContainsParsedValue(string name, object value)
	{
		if (_headerStore == null)
		{
			return false;
		}
		HeaderStoreItemInfo info = null;
		if (TryGetAndParseHeaderInfo(name, out info))
		{
			if (info.ParsedValue == null)
			{
				return false;
			}
			List<object> list = info.ParsedValue as List<object>;
			IEqualityComparer comparer = info.Parser.Comparer;
			if (list == null)
			{
				return AreEqual(value, info.ParsedValue, comparer);
			}
			foreach (object item in list)
			{
				if (AreEqual(value, item, comparer))
				{
					return true;
				}
			}
			return false;
		}
		return false;
	}

	internal virtual void AddHeaders(HttpHeaders sourceHeaders)
	{
		if (sourceHeaders._headerStore == null)
		{
			return;
		}
		List<string> list = null;
		foreach (KeyValuePair<string, HeaderStoreItemInfo> item in sourceHeaders._headerStore)
		{
			if (_headerStore != null && _headerStore.ContainsKey(item.Key))
			{
				continue;
			}
			HeaderStoreItemInfo value = item.Value;
			if (!sourceHeaders.ParseRawHeaderValues(item.Key, value, removeEmptyHeader: false))
			{
				if (list == null)
				{
					list = new List<string>();
				}
				list.Add(item.Key);
			}
			else
			{
				AddHeaderInfo(item.Key, value);
			}
		}
		if (list == null)
		{
			return;
		}
		foreach (string item2 in list)
		{
			sourceHeaders._headerStore.Remove(item2);
		}
	}

	private void AddHeaderInfo(string headerName, HeaderStoreItemInfo sourceInfo)
	{
		HeaderStoreItemInfo headerStoreItemInfo = CreateAndAddHeaderToStore(headerName);
		if (headerStoreItemInfo.Parser == null)
		{
			headerStoreItemInfo.ParsedValue = CloneStringHeaderInfoValues(sourceInfo.ParsedValue);
			return;
		}
		headerStoreItemInfo.InvalidValue = CloneStringHeaderInfoValues(sourceInfo.InvalidValue);
		if (sourceInfo.ParsedValue == null)
		{
			return;
		}
		if (!(sourceInfo.ParsedValue is List<object> list))
		{
			CloneAndAddValue(headerStoreItemInfo, sourceInfo.ParsedValue);
			return;
		}
		foreach (object item in list)
		{
			CloneAndAddValue(headerStoreItemInfo, item);
		}
	}

	private static void CloneAndAddValue(HeaderStoreItemInfo destinationInfo, object source)
	{
		if (source is ICloneable cloneable)
		{
			AddValue(destinationInfo, cloneable.Clone(), StoreLocation.Parsed);
		}
		else
		{
			AddValue(destinationInfo, source, StoreLocation.Parsed);
		}
	}

	private static object CloneStringHeaderInfoValues(object source)
	{
		if (source == null)
		{
			return null;
		}
		if (!(source is List<object> collection))
		{
			return source;
		}
		return new List<object>(collection);
	}

	private HeaderStoreItemInfo GetOrCreateHeaderInfo(string name, bool parseRawValues)
	{
		HeaderStoreItemInfo info = null;
		bool flag = false;
		if (!((!parseRawValues) ? TryGetHeaderInfo(name, out info) : TryGetAndParseHeaderInfo(name, out info)))
		{
			info = CreateAndAddHeaderToStore(name);
		}
		return info;
	}

	private HeaderStoreItemInfo CreateAndAddHeaderToStore(string name)
	{
		HeaderStoreItemInfo headerStoreItemInfo = new HeaderStoreItemInfo(GetParser(name));
		AddHeaderToStore(name, headerStoreItemInfo);
		return headerStoreItemInfo;
	}

	private void AddHeaderToStore(string name, HeaderStoreItemInfo info)
	{
		if (_headerStore == null)
		{
			_headerStore = new Dictionary<string, HeaderStoreItemInfo>(StringComparer.OrdinalIgnoreCase);
		}
		_headerStore.Add(name, info);
	}

	private bool TryGetHeaderInfo(string name, out HeaderStoreItemInfo info)
	{
		if (_headerStore == null)
		{
			info = null;
			return false;
		}
		return _headerStore.TryGetValue(name, out info);
	}

	private bool TryGetAndParseHeaderInfo(string name, out HeaderStoreItemInfo info)
	{
		if (TryGetHeaderInfo(name, out info))
		{
			return ParseRawHeaderValues(name, info, removeEmptyHeader: true);
		}
		return false;
	}

	private bool ParseRawHeaderValues(string name, HeaderStoreItemInfo info, bool removeEmptyHeader)
	{
		lock (info)
		{
			if (info.RawValue != null)
			{
				if (!(info.RawValue is List<string> rawValues))
				{
					ParseSingleRawHeaderValue(name, info);
				}
				else
				{
					ParseMultipleRawHeaderValues(name, info, rawValues);
				}
				info.RawValue = null;
				if (info.InvalidValue == null && info.ParsedValue == null)
				{
					if (removeEmptyHeader)
					{
						_headerStore.Remove(name);
					}
					return false;
				}
			}
		}
		return true;
	}

	private static void ParseMultipleRawHeaderValues(string name, HeaderStoreItemInfo info, List<string> rawValues)
	{
		if (info.Parser == null)
		{
			foreach (string rawValue in rawValues)
			{
				if (!ContainsInvalidNewLine(rawValue, name))
				{
					AddValue(info, rawValue, StoreLocation.Parsed);
				}
			}
			return;
		}
		foreach (string rawValue2 in rawValues)
		{
			if (!TryParseAndAddRawHeaderValue(name, info, rawValue2, addWhenInvalid: true) && NetEventSource.IsEnabled)
			{
				NetEventSource.Log.HeadersInvalidValue(name, rawValue2);
			}
		}
	}

	private static void ParseSingleRawHeaderValue(string name, HeaderStoreItemInfo info)
	{
		string text = info.RawValue as string;
		if (info.Parser == null)
		{
			if (!ContainsInvalidNewLine(text, name))
			{
				AddValue(info, text, StoreLocation.Parsed);
			}
		}
		else if (!TryParseAndAddRawHeaderValue(name, info, text, addWhenInvalid: true) && NetEventSource.IsEnabled)
		{
			NetEventSource.Log.HeadersInvalidValue(name, text);
		}
	}

	internal bool TryParseAndAddValue(string name, string value)
	{
		PrepareHeaderInfoForAdd(name, out var info, out var addToStore);
		bool flag = TryParseAndAddRawHeaderValue(name, info, value, addWhenInvalid: false);
		if ((flag & addToStore) && info.ParsedValue != null)
		{
			AddHeaderToStore(name, info);
		}
		return flag;
	}

	private static bool TryParseAndAddRawHeaderValue(string name, HeaderStoreItemInfo info, string value, bool addWhenInvalid)
	{
		if (!info.CanAddValue)
		{
			if (addWhenInvalid)
			{
				AddValue(info, value ?? string.Empty, StoreLocation.Invalid);
			}
			return false;
		}
		int index = 0;
		object parsedValue = null;
		if (info.Parser.TryParseValue(value, info.ParsedValue, ref index, out parsedValue))
		{
			if (value == null || index == value.Length)
			{
				if (parsedValue != null)
				{
					AddValue(info, parsedValue, StoreLocation.Parsed);
				}
				return true;
			}
			List<object> list = new List<object>();
			if (parsedValue != null)
			{
				list.Add(parsedValue);
			}
			while (index < value.Length)
			{
				if (info.Parser.TryParseValue(value, info.ParsedValue, ref index, out parsedValue))
				{
					if (parsedValue != null)
					{
						list.Add(parsedValue);
					}
					continue;
				}
				if (!ContainsInvalidNewLine(value, name) & addWhenInvalid)
				{
					AddValue(info, value, StoreLocation.Invalid);
				}
				return false;
			}
			foreach (object item in list)
			{
				AddValue(info, item, StoreLocation.Parsed);
			}
			return true;
		}
		if (!ContainsInvalidNewLine(value, name) & addWhenInvalid)
		{
			AddValue(info, value ?? string.Empty, StoreLocation.Invalid);
		}
		return false;
	}

	private static void AddValue(HeaderStoreItemInfo info, object value, StoreLocation location)
	{
		object obj = null;
		switch (location)
		{
		case StoreLocation.Raw:
			obj = info.RawValue;
			AddValueToStoreValue<string>(info, value, ref obj);
			info.RawValue = obj;
			break;
		case StoreLocation.Invalid:
			obj = info.InvalidValue;
			AddValueToStoreValue<string>(info, value, ref obj);
			info.InvalidValue = obj;
			break;
		case StoreLocation.Parsed:
			obj = info.ParsedValue;
			AddValueToStoreValue<object>(info, value, ref obj);
			info.ParsedValue = obj;
			break;
		}
	}

	private static void AddValueToStoreValue<T>(HeaderStoreItemInfo info, object value, ref object currentStoreValue) where T : class
	{
		if (currentStoreValue == null)
		{
			currentStoreValue = value;
			return;
		}
		List<T> list = currentStoreValue as List<T>;
		if (list == null)
		{
			list = new List<T>(2);
			list.Add(currentStoreValue as T);
			currentStoreValue = list;
		}
		list.Add(value as T);
	}

	internal object GetParsedValues(string name)
	{
		HeaderStoreItemInfo info = null;
		if (!TryGetAndParseHeaderInfo(name, out info))
		{
			return null;
		}
		return info.ParsedValue;
	}

	private void PrepareHeaderInfoForAdd(string name, out HeaderStoreItemInfo info, out bool addToStore)
	{
		info = null;
		addToStore = false;
		if (!TryGetAndParseHeaderInfo(name, out info))
		{
			info = new HeaderStoreItemInfo(GetParser(name));
			addToStore = true;
		}
	}

	private void ParseAndAddValue(string name, HeaderStoreItemInfo info, string value)
	{
		if (info.Parser == null)
		{
			CheckInvalidNewLine(value);
			AddValue(info, value ?? string.Empty, StoreLocation.Parsed);
			return;
		}
		if (!info.CanAddValue)
		{
			throw new FormatException(string.Format(CultureInfo.InvariantCulture, System.SR.net_http_headers_single_value_header, name));
		}
		int index = 0;
		object obj = info.Parser.ParseValue(value, info.ParsedValue, ref index);
		if (value == null || index == value.Length)
		{
			if (obj != null)
			{
				AddValue(info, obj, StoreLocation.Parsed);
			}
			return;
		}
		List<object> list = new List<object>();
		if (obj != null)
		{
			list.Add(obj);
		}
		while (index < value.Length)
		{
			obj = info.Parser.ParseValue(value, info.ParsedValue, ref index);
			if (obj != null)
			{
				list.Add(obj);
			}
		}
		foreach (object item in list)
		{
			AddValue(info, item, StoreLocation.Parsed);
		}
	}

	private HttpHeaderParser GetParser(string name)
	{
		if (_parserStore == null)
		{
			return null;
		}
		HttpHeaderParser value = null;
		if (_parserStore.TryGetValue(name, out value))
		{
			return value;
		}
		return null;
	}

	private void CheckHeaderName(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			throw new ArgumentException(System.SR.net_http_argument_empty_string, "name");
		}
		if (HttpRuleParser.GetTokenLength(name, 0) != name.Length)
		{
			throw new FormatException(System.SR.net_http_headers_invalid_header_name);
		}
		if (_invalidHeaders != null && _invalidHeaders.Contains(name))
		{
			throw new InvalidOperationException(System.SR.net_http_headers_not_allowed_header_name);
		}
	}

	private bool TryCheckHeaderName(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			return false;
		}
		if (HttpRuleParser.GetTokenLength(name, 0) != name.Length)
		{
			return false;
		}
		if (_invalidHeaders != null && _invalidHeaders.Contains(name))
		{
			return false;
		}
		return true;
	}

	private static void CheckInvalidNewLine(string value)
	{
		if (value == null || !HttpRuleParser.ContainsInvalidNewLine(value))
		{
			return;
		}
		throw new FormatException(System.SR.net_http_headers_no_newlines);
	}

	private static bool ContainsInvalidNewLine(string value, string name)
	{
		if (HttpRuleParser.ContainsInvalidNewLine(value))
		{
			if (NetEventSource.IsEnabled)
			{
				NetEventSource.Error(null, System.SR.Format(System.SR.net_http_log_headers_no_newlines, name, value), "ContainsInvalidNewLine");
			}
			return true;
		}
		return false;
	}

	private static string[] GetValuesAsStrings(HeaderStoreItemInfo info)
	{
		return GetValuesAsStrings(info, null);
	}

	private static string[] GetValuesAsStrings(HeaderStoreItemInfo info, object exclude)
	{
		int valueCount = GetValueCount(info);
		string[] array;
		if (valueCount > 0)
		{
			array = new string[valueCount];
			int currentIndex = 0;
			ReadStoreValues<string>(array, info.RawValue, null, null, ref currentIndex);
			ReadStoreValues(array, info.ParsedValue, info.Parser, exclude, ref currentIndex);
			ReadStoreValues<string>(array, info.InvalidValue, null, null, ref currentIndex);
			if (currentIndex < valueCount)
			{
				string[] array2 = new string[currentIndex];
				Array.Copy(array, 0, array2, 0, currentIndex);
				array = array2;
			}
		}
		else
		{
			array = Array.Empty<string>();
		}
		return array;
	}

	private static int GetValueCount(HeaderStoreItemInfo info)
	{
		int valueCount = 0;
		UpdateValueCount<string>(info.RawValue, ref valueCount);
		UpdateValueCount<string>(info.InvalidValue, ref valueCount);
		UpdateValueCount<object>(info.ParsedValue, ref valueCount);
		return valueCount;
	}

	private static void UpdateValueCount<T>(object valueStore, ref int valueCount)
	{
		if (valueStore != null)
		{
			if (valueStore is List<T> list)
			{
				valueCount += list.Count;
			}
			else
			{
				valueCount++;
			}
		}
	}

	private static void ReadStoreValues<T>(string[] values, object storeValue, HttpHeaderParser parser, T exclude, ref int currentIndex)
	{
		if (storeValue == null)
		{
			return;
		}
		if (!(storeValue is List<T> list))
		{
			if (ShouldAdd(storeValue, parser, exclude))
			{
				values[currentIndex] = ((parser == null) ? storeValue.ToString() : parser.ToString(storeValue));
				currentIndex++;
			}
			return;
		}
		foreach (T item in list)
		{
			object obj = item;
			if (ShouldAdd(obj, parser, exclude))
			{
				values[currentIndex] = ((parser == null) ? obj.ToString() : parser.ToString(obj));
				currentIndex++;
			}
		}
	}

	private static bool ShouldAdd<T>(object storeValue, HttpHeaderParser parser, T exclude)
	{
		bool result = true;
		if (parser != null && exclude != null)
		{
			result = ((parser.Comparer == null) ? (!exclude.Equals(storeValue)) : (!parser.Comparer.Equals(exclude, storeValue)));
		}
		return result;
	}

	private bool AreEqual(object value, object storeValue, IEqualityComparer comparer)
	{
		return comparer?.Equals(value, storeValue) ?? value.Equals(storeValue);
	}
}
