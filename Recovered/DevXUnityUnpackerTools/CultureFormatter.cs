using @as;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

internal class CultureFormatter
{
	internal class SomeItem : Dictionary<string, object>
	{
		internal _0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A;

		internal Dictionary<string, string> _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020;

		internal Dictionary<string, _0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A> _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A;

		internal Dictionary<string, _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020> _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020;

		internal static char[] _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_000A = new char[3]
		{
			'.',
			'/',
			'\\'
		};

		internal static object _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020;

		internal IEnumerable<_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A> _0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_000A
		{
			get
			{
				foreach (var item in _0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020)
				{
					yield return item.item;
				}
			}
		}

		internal IEnumerable<(int index, int level, _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A item)> _0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020
		{
			get
			{
				int num = 0;
				foreach (var item in _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020(0))
				{
					yield return (num, item.level, item.item);
					num++;
				}
			}
		}

		internal IEnumerable<_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A> _0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A
		{
			get
			{
				if (DateTime.Now.Ticks + 234 <= 662380415999999766L)
				{
					using (Enumerator enumerator = GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							yield return _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A(enumerator.Current.Key);
						}
					}
				}
			}
		}

		internal object _0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020
		{
			get
			{
				object obj = _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("first");
				if (obj is SomeItem)
				{
					SomeItem someItem = obj as SomeItem;
					if (someItem.Count == 1 && someItem._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("name") != null)
					{
						return someItem._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("name");
					}
				}
				return obj;
			}
		}

		internal string _0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A
		{
			get
			{
				object obj = _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("first");
				if (obj == null)
				{
					return null;
				}
				if (obj is float)
				{
					return ((float)obj)._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020();
				}
				if (obj is bool)
				{
					if (!(bool)obj)
					{
						return "0";
					}
					return "1";
				}
				if (obj is SomeItem)
				{
					SomeItem someItem = obj as SomeItem;
					if (someItem.Count == 1 && someItem._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("name") != null)
					{
						object obj2 = someItem._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("name");
						if (obj2 == null)
						{
							return null;
						}
						if (obj2 is float)
						{
							return ((float)obj2)._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020();
						}
						if (obj2 is bool)
						{
							if (!(bool)obj)
							{
								return "0";
							}
							return "1";
						}
						return obj2.ToString().Trim('\'');
					}
					return someItem._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A();
				}
				return obj.ToString().Trim('\'');
			}
		}

		internal object _0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020
		{
			get
			{
				return _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("second");
			}
			set
			{
				base["second"] = value;
			}
		}

		internal string _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_000A_000A_000A
		{
			get
			{
				object obj = _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("second");
				if (obj == null)
				{
					return null;
				}
				if (obj is float)
				{
					return ((float)obj)._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020();
				}
				if (obj is bool)
				{
					if (!(bool)obj)
					{
						return "0";
					}
					return "1";
				}
				if (obj is SomeItem)
				{
					SomeItem someItem = obj as SomeItem;
					if (someItem.Count == 1 && someItem._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("name") != null)
					{
						object obj2 = someItem._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("name");
						if (obj2 == null)
						{
							return null;
						}
						if (obj2 is float)
						{
							return ((float)obj2)._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020();
						}
						if (obj2 is bool)
						{
							if (!(bool)obj)
							{
								return "0";
							}
							return "1";
						}
						return obj2.ToString().Trim('\'');
					}
					return someItem._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A();
				}
				return obj.ToString().Trim('\'');
			}
		}

		internal IEnumerable<(int level, _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A item)> _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020(int _0020)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<string, object> current = enumerator.Current;
					_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A item = _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A(current.Key);
					yield return (_0020, item);
					if (current.Value is SomeItem)
					{
						foreach (var item2 in (current.Value as SomeItem)._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020(_0020 + 1))
						{
							yield return item2;
						}
					}
					if (current.Value is object[])
					{
						object[] array = current.Value as object[];
						foreach (object obj in array)
						{
							if (obj is SomeItem)
							{
								foreach (var item3 in (obj as SomeItem)._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020(_0020 + 1))
								{
									yield return item3;
								}
							}
							else
							{
								if (!(obj is object[]))
								{
									break;
								}
								object[] array2 = obj as object[];
								foreach (object obj2 in array2)
								{
									if (!(obj2 is SomeItem))
									{
										break;
									}
									foreach (var item4 in (obj2 as SomeItem)._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020(_0020 + 1))
									{
										yield return item4;
									}
								}
							}
						}
					}
				}
			}
		}

		internal object _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020(string _0020)
		{
			if (TryGetValue(_0020, out object value))
			{
				if (value is _0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020)
				{
					return (value as _0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020)._0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A;
				}
				if (value is _0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020)
				{
					return (value as _0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020)._0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A;
				}
				if (value is _0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A)
				{
					return (value as _0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A)._0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A;
				}
				return value;
			}
			return null;
		}

		internal void _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020(_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A _0020, string _0020_000A, object _0020_0020, _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020 _0020_000A_000A)
		{
			if (_0020_000A == null)
			{
				return;
			}
			if (_0020_0020 != null && _0020_0020 is byte[] && (_0020_0020 as byte[]).Length > 500)
			{
				base[_0020_000A] = new _0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020(_0020_0020 as byte[]);
			}
			else if (_0020_0020 != null && _0020_0020 is string && (_0020_0020 as string).Length > 256)
			{
				base[_0020_000A] = new _0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A((string)_0020_0020);
			}
			else
			{
				base[_0020_000A] = _0020_0020;
			}
			if (_0020 != null && _0020._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A != null)
			{
				if (_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020 == null)
				{
					_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020 = new Dictionary<string, string>();
				}
				if (_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A == null)
				{
					_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A = new Dictionary<string, _0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A>();
				}
				_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020[_0020_000A] = _0020._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A;
				_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A[_0020_000A] = _0020;
			}
			if (_0020_000A_000A != null)
			{
				if (_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020 == null)
				{
					_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020 = new Dictionary<string, _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020>();
				}
				_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020[_0020_000A] = _0020_000A_000A;
			}
		}

		internal string _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_0020(string _0020)
		{
			if (_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020 != null && _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020.TryGetValue(_0020, out string value))
			{
				return value;
			}
			return null;
		}

		internal _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A(string _0020)
		{
			if (!ContainsKey(_0020))
			{
				return null;
			}
			_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A = new _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A();
			_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A._0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020 = this;
			_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020 = _0020;
			if (_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020 != null && _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020.ContainsKey(_0020))
			{
				_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A._0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A = _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020[_0020];
			}
			if (_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A != null && _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A.ContainsKey(_0020))
			{
				_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A = _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A[_0020];
			}
			if (_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020 != null && _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020.ContainsKey(_0020))
			{
				_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A._0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020 = _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020[_0020];
			}
			return _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A;
		}

		internal bool _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020(string _0020, out _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A _0020_000A)
		{
			_0020_000A = _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020(_0020);
			if (_0020_000A == null)
			{
				return false;
			}
			return true;
		}

		internal _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020(string _0020)
		{
			if (string.IsNullOrEmpty(_0020))
			{
				return null;
			}
			int num = _0020.IndexOfAny(_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_000A);
			_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A = _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A(_0020);
			if (num >= 0 && _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A == null)
			{
				string text = _0020.Substring(0, num);
				string text2 = _0020.Substring(num + 1);
				object obj = _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020(text);
				if (obj == null)
				{
					object obj2 = _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("data");
					if (obj2 is SomeItem)
					{
						obj = (obj2 as SomeItem)._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020(text);
					}
				}
				if (obj == null && text != "Array")
				{
					object _00202 = _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("Array");
					return _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A(_00202, _0020);
				}
				if (obj is SomeItem)
				{
					return (obj as SomeItem)._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020(text2);
				}
				if (obj != null && obj is object[] && (obj as object[]).Length != 0 && (obj as object[])[0] is SomeItem)
				{
					return _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A(obj, text2);
				}
				return null;
			}
			_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A2 = _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A;
			if (_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A2 == null)
			{
				object obj3 = _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("data");
				if (obj3 is SomeItem)
				{
					_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A2 = (obj3 as SomeItem)._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A(_0020);
				}
			}
			if (_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A2 == null && _0020 != "Array")
			{
				_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A _00203 = _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A("Array");
				return _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A(_00203, _0020);
			}
			return _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A2;
		}

		internal _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A(object _0020, string _0020_000A)
		{
			if (string.IsNullOrEmpty(_0020_000A) || _0020 == null)
			{
				return null;
			}
			if (_0020 is SomeItem)
			{
				return (_0020 as SomeItem)._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020(_0020_000A);
			}
			if (_0020 != null && _0020 is object[] && (_0020 as object[]).Length != 0 && (_0020 as object[])[0] is SomeItem)
			{
				string b = _0020_000A;
				string _0020_000A2 = null;
				int num = _0020_000A.IndexOfAny(_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_000A);
				if (num >= 0)
				{
					b = _0020_000A.Substring(0, num);
					_0020_000A2 = _0020_000A.Substring(num + 1);
				}
				object[] array = _0020 as object[];
				for (int i = 0; i < array.Length; i++)
				{
					SomeItem someItem = (SomeItem)array[i];
					if (someItem._0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A == b)
					{
						return _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A(someItem._0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020, _0020_000A2);
					}
				}
			}
			return null;
		}

		internal object SetProp(string _0020, object _0020_000A = null)
		{
			if (string.IsNullOrEmpty(_0020))
			{
				return _0020_000A;
			}
			int num = _0020.IndexOfAny(_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_000A);
			object obj = _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020(_0020);
			if (num >= 0 && obj == null)
			{
				string text = _0020.Substring(0, num);
				string text2 = _0020.Substring(num + 1);
				object obj2 = _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020(text);
				if (obj2 == null)
				{
					object obj3 = _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("data");
					if (obj3 is SomeItem)
					{
						obj2 = (obj3 as SomeItem)._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020(text);
					}
				}
				if (obj2 == null && text != "Array")
				{
					object _00202 = _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("Array");
					return _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020(_00202, _0020, _0020_000A);
				}
				if (obj2 is SomeItem)
				{
					return (obj2 as SomeItem).SetProp(text2, _0020_000A);
				}
				if (obj2 != null && obj2 is object[] && (obj2 as object[]).Length != 0 && (obj2 as object[])[0] is SomeItem)
				{
					return _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020(obj2, text2, _0020_000A);
				}
				return _0020_000A;
			}
			object obj4 = _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020(_0020);
			if (obj4 == null)
			{
				object obj5 = _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("data");
				if (obj5 is SomeItem)
				{
					obj4 = (obj5 as SomeItem)._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020(_0020);
				}
			}
			if (obj4 == null && _0020 != "Array")
			{
				object _00203 = _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("Array");
				return _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020(_00203, _0020, _0020_000A);
			}
			return obj4 ?? _0020_000A;
		}

		internal object _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020(object _0020, string _0020_000A, object _0020_0020 = null)
		{
			if (string.IsNullOrEmpty(_0020_000A) || _0020 == null)
			{
				return _0020 ?? _0020_0020;
			}
			if (_0020 is SomeItem)
			{
				return (_0020 as SomeItem).SetProp(_0020_000A, _0020_0020);
			}
			if (_0020 != null && _0020 is object[] && (_0020 as object[]).Length != 0 && (_0020 as object[])[0] is SomeItem)
			{
				string b = _0020_000A;
				string _0020_000A2 = null;
				int num = _0020_000A.IndexOfAny(_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_000A);
				if (num >= 0)
				{
					b = _0020_000A.Substring(0, num);
					_0020_000A2 = _0020_000A.Substring(num + 1);
				}
				object[] array = _0020 as object[];
				for (int i = 0; i < array.Length; i++)
				{
					SomeItem someItem = (SomeItem)array[i];
					if (someItem._0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A == b)
					{
						return _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020(someItem._0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020, _0020_000A2, _0020_0020);
					}
				}
			}
			return _0020_0020;
		}

		internal SomeItem _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020_0020(string _0020)
		{
			SomeItem someItem = string.IsNullOrEmpty(_0020) ? this : ((SomeItem)SetProp(_0020));
			if (someItem == null)
			{
				return null;
			}
			return someItem;
		}

		internal bool _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_000A_000A_000A(string _0020, bool _0020_000A = false)
		{
			object obj = SetProp(_0020);
			if (obj == null)
			{
				return _0020_000A;
			}
			if (obj is bool)
			{
				return (bool)obj;
			}
			if (obj is byte)
			{
				return (byte)obj == 1;
			}
			if (obj is sbyte)
			{
				return (sbyte)obj == 1;
			}
			if (obj is int)
			{
				return (int)obj == 1;
			}
			if (obj is uint)
			{
				return (uint)obj == 1;
			}
			if (obj is long)
			{
				return (int)(long)obj == 1;
			}
			if (obj is ulong)
			{
				return (int)(ulong)obj == 1;
			}
			if (obj is short)
			{
				return (short)obj == 1;
			}
			if (obj is ushort)
			{
				return (ushort)obj == 1;
			}
			if (obj is float)
			{
				return (int)(float)obj != 0;
			}
			if (obj is double)
			{
				return (int)(double)obj != 0;
			}
			if (obj is decimal)
			{
				return (int)(decimal)obj != 0;
			}
			if (obj is char)
			{
				return (char)obj == '\u0001';
			}
			switch (obj as string)
			{
			default:
				return false;
			case "1":
			case "True":
			case "true":
			case "on":
				return true;
			case null:
				return _0020_000A;
			}
		}

		internal string _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020(string _0020, string _0020_000A = null)
		{
			object obj = SetProp(_0020);
			if (obj == null)
			{
				return _0020_000A;
			}
			if (obj is string)
			{
				return (string)obj;
			}
			if (obj is byte[])
			{
				return Encoding.UTF8.GetString((byte[])obj);
			}
			object obj2;
			if ((obj2 = obj) is float)
			{
				float _00202 = (float)obj2;
				return _00202._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020();
			}
			if ((obj2 = obj) is double)
			{
				double _00203 = (double)obj2;
				return _00203._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020();
			}
			if ((obj2 = obj) is decimal)
			{
				decimal _00204 = (decimal)obj2;
				return _00204._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020();
			}
			return obj.ToString();
		}

		internal int _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020_000A(string _0020, int _0020_000A = 0)
		{
			object obj = SetProp(_0020);
			if (obj == null)
			{
				return _0020_000A;
			}
			if (obj is int)
			{
				return (int)obj;
			}
			if (obj is long)
			{
				return (int)(long)obj;
			}
			if (obj is ulong)
			{
				return (int)(ulong)obj;
			}
			if (obj is uint)
			{
				return (int)(uint)obj;
			}
			if (obj is short)
			{
				return (short)obj;
			}
			if (obj is ushort)
			{
				return (ushort)obj;
			}
			if (obj is char)
			{
				return (char)obj;
			}
			if (obj is byte)
			{
				return (byte)obj;
			}
			if (obj is sbyte)
			{
				return (sbyte)obj;
			}
			if (obj is float)
			{
				return (int)(float)obj;
			}
			if (obj is double)
			{
				return (int)(double)obj;
			}
			if (obj is decimal)
			{
				return (int)(decimal)obj;
			}
			if (obj is bool)
			{
				if (!(bool)obj)
				{
					return 0;
				}
				return 1;
			}
			return FormatUtils._0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A(string.Concat(obj), _0020_000A);
		}

		internal uint _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020(string _0020, uint _0020_000A = 0u)
		{
			object obj = SetProp(_0020);
			if (obj == null)
			{
				return _0020_000A;
			}
			if (obj is long)
			{
				return (uint)(long)obj;
			}
			if (obj is ulong)
			{
				return (uint)(ulong)obj;
			}
			if (obj is int)
			{
				return (uint)(int)obj;
			}
			if (obj is uint)
			{
				return (uint)obj;
			}
			if (obj is short)
			{
				return (uint)(short)obj;
			}
			if (obj is ushort)
			{
				return (ushort)obj;
			}
			if (obj is char)
			{
				return (char)obj;
			}
			if (obj is byte)
			{
				return (byte)obj;
			}
			if (obj is sbyte)
			{
				return (uint)(sbyte)obj;
			}
			if (obj is float)
			{
				return (uint)(float)obj;
			}
			if (obj is double)
			{
				return (uint)(double)obj;
			}
			if (obj is decimal)
			{
				return (uint)(decimal)obj;
			}
			if (obj is bool)
			{
				if (!(bool)obj)
				{
					return 0u;
				}
				return 1u;
			}
			return (uint)FormatUtils._0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A(string.Concat(obj), (int)_0020_000A);
		}

		internal ushort _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A(string _0020, ushort _0020_000A = 0)
		{
			object obj = SetProp(_0020);
			if (obj == null)
			{
				return _0020_000A;
			}
			if (obj is long)
			{
				return (ushort)(long)obj;
			}
			if (obj is ulong)
			{
				return (ushort)(ulong)obj;
			}
			if (obj is int)
			{
				return (ushort)(int)obj;
			}
			if (obj is uint)
			{
				return (ushort)(uint)obj;
			}
			if (obj is short)
			{
				return (ushort)(short)obj;
			}
			if (obj is ushort)
			{
				return (ushort)obj;
			}
			if (obj is char)
			{
				return (char)obj;
			}
			if (obj is byte)
			{
				return (byte)obj;
			}
			if (obj is sbyte)
			{
				return (ushort)(sbyte)obj;
			}
			if (obj is float)
			{
				return (ushort)(float)obj;
			}
			if (obj is double)
			{
				return (ushort)(double)obj;
			}
			if (obj is decimal)
			{
				return (ushort)(decimal)obj;
			}
			if (obj is bool)
			{
				return (ushort)(((bool)obj) ? 1 : 0);
			}
			return _0020_000A;
		}

		internal byte _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020(string _0020, byte _0020_000A = 0)
		{
			object obj = SetProp(_0020);
			if (obj == null)
			{
				return _0020_000A;
			}
			if (obj is long)
			{
				return (byte)(long)obj;
			}
			if (obj is ulong)
			{
				return (byte)(ulong)obj;
			}
			if (obj is int)
			{
				return (byte)(int)obj;
			}
			if (obj is uint)
			{
				return (byte)(uint)obj;
			}
			if (obj is short)
			{
				return (byte)(short)obj;
			}
			if (obj is ushort)
			{
				return (byte)(ushort)obj;
			}
			if (obj is char)
			{
				return (byte)(char)obj;
			}
			if (obj is byte)
			{
				return (byte)obj;
			}
			if (obj is sbyte)
			{
				return (byte)(sbyte)obj;
			}
			if (obj is float)
			{
				return (byte)(float)obj;
			}
			if (obj is double)
			{
				return (byte)(double)obj;
			}
			if (obj is decimal)
			{
				return (byte)(decimal)obj;
			}
			if (obj is bool)
			{
				return (byte)(((bool)obj) ? 1 : 0);
			}
			return (byte)FormatUtils._0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A(string.Concat(obj), _0020_000A);
		}

		internal long _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_0020_000A(string _0020, long _0020_000A = 0L)
		{
			object obj = SetProp(_0020);
			if (obj == null)
			{
				return _0020_000A;
			}
			if (obj is int)
			{
				return (int)obj;
			}
			if (obj is long)
			{
				return (long)obj;
			}
			if (obj is ulong)
			{
				return (long)(ulong)obj;
			}
			if (obj is uint)
			{
				return (uint)obj;
			}
			if (obj is short)
			{
				return (short)obj;
			}
			if (obj is ushort)
			{
				return (ushort)obj;
			}
			if (obj is char)
			{
				return (char)obj;
			}
			if (obj is byte)
			{
				return (byte)obj;
			}
			if (obj is sbyte)
			{
				return (sbyte)obj;
			}
			if (obj is float)
			{
				return (long)(float)obj;
			}
			if (obj is double)
			{
				return (long)(double)obj;
			}
			if (obj is decimal)
			{
				return (long)(decimal)obj;
			}
			if (obj is bool)
			{
				return ((bool)obj) ? 1 : 0;
			}
			return FormatUtils._0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020(string.Concat(obj), _0020_000A);
		}

		internal ulong _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020(string _0020, ulong _0020_000A = 0uL)
		{
			object obj = SetProp(_0020);
			if (obj == null)
			{
				return _0020_000A;
			}
			if (obj is int)
			{
				return (ulong)(int)obj;
			}
			if (obj is long)
			{
				return (ulong)(long)obj;
			}
			if (obj is ulong)
			{
				return (ulong)obj;
			}
			if (obj is uint)
			{
				return (uint)obj;
			}
			if (obj is short)
			{
				return (ulong)(short)obj;
			}
			if (obj is ushort)
			{
				return (ushort)obj;
			}
			if (obj is char)
			{
				return (char)obj;
			}
			if (obj is byte)
			{
				return (byte)obj;
			}
			if (obj is sbyte)
			{
				return (ulong)(sbyte)obj;
			}
			if (obj is float)
			{
				return (ulong)(float)obj;
			}
			if (obj is double)
			{
				return (ulong)(double)obj;
			}
			if (obj is decimal)
			{
				return (ulong)(decimal)obj;
			}
			if (obj is bool)
			{
				return (ulong)(((bool)obj) ? 1 : 0);
			}
			return _0020_000A;
		}

		internal string _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A(string _0020, float? _0020_000A = default(float?))
		{
			object obj = SetProp(_0020);
			if (obj == null)
			{
				if (_0020_000A.HasValue)
				{
					return _0020_000A.Value._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020();
				}
				return null;
			}
			return ((float)(obj ?? ((object)_0020_000A)))._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020();
		}

		internal string _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_0020(string _0020, string _0020_000A = null)
		{
			SomeItem someItem = string.IsNullOrEmpty(_0020) ? this : ((SomeItem)SetProp(_0020));
			if (someItem == null)
			{
				return _0020_000A;
			}
			float _00202 = (float)(someItem?._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("x") ?? ((object)0f));
			float _00203 = (float)(someItem?._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("y") ?? ((object)0f));
			float _00204 = (float)(someItem?._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("z") ?? ((object)0f));
			float _00205 = (float)(someItem?._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("w") ?? ((object)0f));
			return "{x: " + _00202._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020() + ", y: " + _00203._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020() + ", z: " + _00204._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020() + ", w: " + _00205._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020() + "}";
		}

		internal string _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020_000A(string _0020, string _0020_000A = null)
		{
			SomeItem someItem = string.IsNullOrEmpty(_0020) ? this : ((SomeItem)SetProp(_0020));
			if (someItem == null)
			{
				return _0020_000A;
			}
			float _00202 = (float)(someItem?._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("x") ?? ((object)0f));
			float _00203 = (float)(someItem?._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("y") ?? ((object)0f));
			float _00204 = (float)(someItem?._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("z") ?? ((object)0f));
			return "{x: " + _00202._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020() + ", y: " + _00203._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020() + ", z: " + _00204._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020() + "}";
		}

		internal _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_000A _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020(string _0020)
		{
			return _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020(_0020, default(_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_000A));
		}

		internal _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_000A _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020(string _0020, _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_000A _0020_000A)
		{
			SomeItem someItem = string.IsNullOrEmpty(_0020) ? this : ((SomeItem)SetProp(_0020));
			if (someItem == null)
			{
				return _0020_000A;
			}
			float x = (float)(someItem?._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("x") ?? ((object)_0020_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020));
			float y = (float)(someItem?._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("y") ?? ((object)_0020_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A));
			float w = (float)(someItem?._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("width") ?? ((object)_0020_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020));
			float h = (float)(someItem?._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("height") ?? ((object)_0020_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A));
			return new _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_000A(x, y, w, h);
		}

		internal _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020 _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A(string _0020)
		{
			return _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A(_0020, default(_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020));
		}

		internal _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020 _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A(string _0020, _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020 _0020_000A)
		{
			SomeItem someItem = string.IsNullOrEmpty(_0020) ? this : ((SomeItem)SetProp(_0020));
			if (someItem == null)
			{
				return _0020_000A;
			}
			float x = (float)(someItem?._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("x") ?? ((object)_0020_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020));
			float y = (float)(someItem?._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("y") ?? ((object)_0020_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A));
			float z = (float)(someItem?._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("z") ?? ((object)_0020_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020));
			float w = (float)(someItem?._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("w") ?? ((object)_0020_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A));
			return new _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020(x, y, z, w);
		}

		internal Vector3 _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020(string _0020)
		{
			return _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020(_0020, default(Vector3));
		}

		internal Vector3 _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020(string _0020, Vector3 _0020_000A)
		{
			SomeItem someItem = string.IsNullOrEmpty(_0020) ? this : ((SomeItem)SetProp(_0020));
			if (someItem == null)
			{
				return _0020_000A;
			}
			float x = (float)(someItem._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("x") ?? ((object)_0020_000A.x));
			float y = (float)(someItem._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("y") ?? ((object)_0020_000A.y));
			float z = (float)(someItem._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("z") ?? ((object)_0020_000A.z));
			return new Vector3(x, y, z);
		}

		internal _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A(string _0020, _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 _0020_000A = default(_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020))
		{
			SomeItem someItem = string.IsNullOrEmpty(_0020) ? this : ((SomeItem)SetProp(_0020));
			if (someItem == null)
			{
				return _0020_000A;
			}
			float x = (float)(someItem._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("x") ?? ((object)0f));
			float y = (float)(someItem._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("y") ?? ((object)0f));
			return new _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020(x, y);
		}

		internal _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020 _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020_0020_0020(string _0020)
		{
			return _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020_0020_0020(_0020, new _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020(1f, 1f, 1f, 1f));
		}

		internal _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020 _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020_0020_0020(string _0020, _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020 _0020_000A)
		{
			SomeItem someItem = string.IsNullOrEmpty(_0020) ? this : ((SomeItem)SetProp(_0020));
			if (someItem == null)
			{
				return _0020_000A;
			}
			object obj = someItem._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("rgba");
			if (obj != null)
			{
				uint num = FormatUtils._0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020(obj);
				return new _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020((float)(double)((num >> 24) & 0xFF) / 255f, (float)(double)((num >> 16) & 0xFF) / 255f, (float)(double)((num >> 8) & 0xFF) / 255f, (float)(double)(num & 0xFF) / 255f);
			}
			float r = (float)(someItem._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("r") ?? ((object)_0020_000A._0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020));
			float g = (float)(someItem._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("g") ?? ((object)_0020_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A));
			float b = (float)(someItem._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("b") ?? ((object)_0020_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020));
			float a = (float)(someItem._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020("a") ?? ((object)_0020_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A));
			return new _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020(r, g, b, a);
		}

		internal string _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020(string _0020, string _0020_000A = null, bool _0020_0020 = false)
		{
			object obj = SetProp(_0020);
			if (obj is ImageResData)
			{
				return ((ImageResData)obj)._0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020(_0020_0020);
			}
			return _0020_000A;
		}

		internal ImageResData _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_000A_000A_000A(string _0020)
		{
			object obj = SetProp(_0020);
			if (obj is ImageResData)
			{
				return (ImageResData)obj;
			}
			return null;
		}

		internal float _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A(string _0020, float _0020_000A = 0f)
		{
			object obj = SetProp(_0020);
			if (obj is float)
			{
				return (float)obj;
			}
			return _0020_000A;
		}

		internal float _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A(string[] _0020, float _0020_000A = 0f)
		{
			foreach (string _00202 in _0020)
			{
				object obj = SetProp(_00202);
				if (obj != null && obj is float)
				{
					return (float)obj;
				}
			}
			return _0020_000A;
		}

		internal byte[] _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020(string _0020)
		{
			if (_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_0020(_0020, out object obj))
			{
				if (obj is _0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020)
				{
					return (obj as _0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020)._0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A;
				}
				if (obj is byte[])
				{
					return obj as byte[];
				}
				ConsoleManager.LogExeption("Error convert types from " + obj?.GetType().FullName + " to byte[], path=" + _0020);
				return null;
			}
			return null;
		}

		internal object _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_0020(string _0020)
		{
			if (_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_0020(_0020, out object obj))
			{
				if (obj is _0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020)
				{
					return (obj as _0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020)._0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A;
				}
				return obj;
			}
			return null;
		}

		internal bool _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_0020(string _0020, out object[] _0020_000A)
		{
			_0020_000A = null;
			if (_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_0020(_0020, out object obj))
			{
				if (obj is object[])
				{
					_0020_000A = (obj as object[]);
					return true;
				}
				List<object> list;
				if ((list = (obj as List<object>)) != null)
				{
					_0020_000A = list.ToArray();
					return true;
				}
			}
			return false;
		}

		internal bool _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_0020(string _0020, out object _0020_000A)
		{
			_0020_000A = SetProp(_0020);
			if (_0020_000A != null && !(_0020_000A is SomeItem))
			{
				return true;
			}
			_0020_000A = SetProp(_0020 + ".Array");
			if (_0020_000A != null && !(_0020_000A is SomeItem))
			{
				return true;
			}
			_0020_000A = SetProp(_0020 + ".data");
			if (_0020_000A != null && !(_0020_000A is SomeItem))
			{
				return true;
			}
			_0020_000A = SetProp(_0020 + ".data.Array");
			if (_0020_000A != null && !(_0020_000A is SomeItem))
			{
				return true;
			}
			if (SetProp(_0020 + "[0]") != null)
			{
				List<object> list = new List<object>();
				for (int i = 0; i < 100; i++)
				{
					object obj = SetProp(_0020 + "[" + i + "]");
					if (obj == null)
					{
						break;
					}
					list.Add(obj);
				}
				if (list.Count > 0)
				{
					_0020_000A = list.ToArray();
					return true;
				}
			}
			return false;
		}

		internal string _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_0020_000A(string _0020)
		{
			object obj = SetProp(_0020);
			if (obj != null && !(obj is SomeItem))
			{
				return _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A(_0020);
			}
			string _00202 = _0020 + ".Array";
			obj = SetProp(_00202);
			if (obj != null && !(obj is SomeItem))
			{
				return _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A(_00202);
			}
			string _00203 = _0020 + ".data";
			obj = SetProp(_00203);
			if (obj != null && !(obj is SomeItem))
			{
				return _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A(_00203);
			}
			string _00204 = _0020 + ".data.Array";
			obj = SetProp(_00204);
			if (obj != null && !(obj is SomeItem))
			{
				return _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A(_00204);
			}
			return null;
		}

		internal string _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020(string _0020, bool _0020_000A = false)
		{
			object obj = _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_0020(_0020);
			if (obj == null)
			{
				return null;
			}
			StringBuilder stringBuilder = new StringBuilder();
			MemoryStream memoryStream = new MemoryStream();
			_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A _0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A = new _0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A(memoryStream);
			_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_000A_0020(ByteOrder.LITTLE_ENDIAN);
			byte[] array7;
			if (obj is ulong[])
			{
				ulong[] array = (ulong[])obj;
				foreach (ulong _00202 in array)
				{
					_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020(_00202);
				}
			}
			else if (obj is long[])
			{
				long[] array2 = (long[])obj;
				foreach (long _00203 in array2)
				{
					_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A(_00203);
				}
			}
			else if (obj is uint[])
			{
				uint[] array3 = (uint[])obj;
				foreach (uint num in array3)
				{
					if (_0020_000A)
					{
						_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020((ushort)num);
					}
					else
					{
						_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A(num);
					}
				}
			}
			else if (obj is int[])
			{
				int[] array4 = (int[])obj;
				foreach (int num2 in array4)
				{
					if (_0020_000A)
					{
						_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020((short)num2);
					}
					else
					{
						_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020(num2);
					}
				}
			}
			else if (obj is ushort[])
			{
				ushort[] array5 = (ushort[])obj;
				foreach (ushort _00204 in array5)
				{
					_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020(_00204);
				}
			}
			else if (obj is short[])
			{
				short[] array6 = (short[])obj;
				foreach (short _00205 in array6)
				{
					_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020(_00205);
				}
			}
			else if (obj is byte[])
			{
				array7 = (byte[])obj;
				foreach (byte _00206 in array7)
				{
					_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020(_00206);
				}
			}
			else if (obj is sbyte[])
			{
				sbyte[] array8 = (sbyte[])obj;
				foreach (sbyte b in array8)
				{
					_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020((byte)b);
				}
			}
			else if (obj is float[])
			{
				float[] array9 = (float[])obj;
				foreach (float _00207 in array9)
				{
					_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A(_00207);
				}
			}
			array7 = memoryStream.ToArray();
			for (int i = 0; i < array7.Length; i++)
			{
				byte b2 = array7[i];
				stringBuilder.Append(b2.ToString("x2"));
			}
			return stringBuilder.ToString();
		}

		internal List<ImageResData> _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020_000A()
		{
			List<ImageResData> list = new List<ImageResData>();
			_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A(list, this);
			return list;
		}

		internal List<ImageResData> _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020_000A(string _0020)
		{
			List<ImageResData> list = new List<ImageResData>();
			if (_0020 == null)
			{
				_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A(list, this);
			}
			else
			{
				object _0020_000A = SetProp(_0020);
				_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A(list, _0020_000A);
			}
			return list;
		}

		internal List<ImageResData> _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020_000A(List<ImageResData> _0020, string _0020_000A)
		{
			if (_0020_000A == null)
			{
				_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A(_0020, this);
			}
			else
			{
				object _0020_000A2 = SetProp(_0020_000A);
				_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A(_0020, _0020_000A2);
			}
			return _0020;
		}

		internal void _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A(List<ImageResData> _0020, object _0020_000A)
		{
			if (_0020_000A == null)
			{
				return;
			}
			if (_0020_000A is ImageResData)
			{
				_0020.Add((ImageResData)_0020_000A);
			}
			else if (_0020_000A is ImageResData[])
			{
				_0020.AddRange((ImageResData[])_0020_000A);
			}
			else if (_0020_000A is object[])
			{
				object[] array = (object[])_0020_000A;
				foreach (object _0020_000A2 in array)
				{
					_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A(_0020, _0020_000A2);
				}
			}
			else if (_0020_000A is SomeItem)
			{
				foreach (KeyValuePair<string, object> item in (SomeItem)_0020_000A)
				{
					_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A(_0020, item.Value);
				}
			}
		}

		internal List<_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A> _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020(string _0020 = null)
		{
			List<_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A> list = new List<_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A>();
			_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020(list, _0020);
			return list;
		}

		internal void _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020(List<_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A> _0020, string _0020_000A)
		{
			if (!string.IsNullOrEmpty(_0020_000A))
			{
				object obj = SetProp(_0020_000A);
				ImageResData[] array;
				object[] array2;
				if (obj is ImageResData)
				{
					_0020.Add(_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020(_0020_000A));
				}
				else if ((array = (obj as ImageResData[])) != null && array.Length != 0)
				{
					_0020.AddRange(_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020(_0020_000A)._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_0020_0020_000A());
				}
				else if ((array2 = (obj as object[])) != null && array2.Length != 0 && array2[0] is ImageResData)
				{
					_0020.AddRange(_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020(_0020_000A)._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_0020_0020_000A());
				}
				else if (obj is object[])
				{
					object[] array3 = (object[])obj;
					for (int i = 0; i < array3.Length; i++)
					{
						SomeItem someItem;
						if ((someItem = (array3[i] as SomeItem)) != null)
						{
							someItem._0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020(_0020, null);
						}
					}
				}
				else if (obj is SomeItem)
				{
					((SomeItem)obj)._0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020(_0020, null);
				}
			}
			else
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020(_0020, enumerator.Current.Key);
					}
				}
			}
		}

		internal string _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A(string _0020, string _0020_000A = null, string _0020_0020 = null, string _0020_000A_000A = null, bool _0020_000A_0020 = false)
		{
			object obj = SetProp(_0020);
			if (obj == null)
			{
				return _0020_000A;
			}
			string text = _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020(obj, _0020_000A, _0020_0020, _0020_000A_0020);
			if (!string.IsNullOrEmpty(_0020_000A_000A))
			{
				StringBuilder stringBuilder = new StringBuilder();
				string[] array = (text ?? string.Empty).Split('\n');
				int num = 0;
				string[] array2 = array;
				foreach (string value in array2)
				{
					if (num == 0)
					{
						stringBuilder.Append(_0020_000A_000A);
					}
					else
					{
						stringBuilder.Append("\n" + _0020_000A_000A);
					}
					stringBuilder.Append(value);
					num++;
				}
				return stringBuilder.ToString();
			}
			return text;
		}

		internal static string _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020(object _0020, string _0020_000A = null, string _0020_0020 = null, bool _0020_000A_000A = false)
		{
			if (_0020 == null)
			{
				return _0020_000A;
			}
			if (_0020 is bool)
			{
				if (!(bool)_0020)
				{
					return "0";
				}
				return "1";
			}
			if (_0020 is float)
			{
				return Foramt((float)_0020);
			}
			if (_0020 is double)
			{
				return Foramt((double)_0020);
			}
			if (_0020 is decimal)
			{
				return Foramt((decimal)_0020);
			}
			if (_0020 is ImageResData)
			{
				return ((ImageResData)_0020)._0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020(_0020_000A_000A);
			}
			if (_0020 is string)
			{
				if (!_0020_000A_000A)
				{
					return _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020((string)_0020, _0020_0020);
				}
				return "\"" + _0020 + "\"";
			}
			if (_0020 is _0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020)
			{
				StringBuilder stringBuilder = new StringBuilder();
				byte[] array = ((_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020)_0020)._0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A;
				for (int i = 0; i < array.Length; i++)
				{
					byte b = array[i];
					stringBuilder.Append(b.ToString("X2"));
				}
				return stringBuilder.ToString();
			}
			if (_0020 is byte[])
			{
				StringBuilder stringBuilder2 = new StringBuilder();
				byte[] array = (byte[])_0020;
				for (int i = 0; i < array.Length; i++)
				{
					byte b2 = array[i];
					stringBuilder2.Append(b2.ToString("X2"));
				}
				return stringBuilder2.ToString();
			}
			if (_0020 is int[])
			{
				StringBuilder stringBuilder3 = new StringBuilder();
				int[] array2 = (int[])_0020;
				foreach (int num in array2)
				{
					stringBuilder3.Append(((byte)num & 0xFF).ToString("X2"));
					stringBuilder3.Append(((byte)((ulong)num >> 8) & 0xFF).ToString("X2"));
					stringBuilder3.Append(((byte)((ulong)num >> 16) & 0xFF).ToString("X2"));
					stringBuilder3.Append(((byte)((ulong)num >> 24) & 0xFF).ToString("X2"));
				}
				return stringBuilder3.ToString();
			}
			if (_0020 is uint[])
			{
				StringBuilder stringBuilder4 = new StringBuilder();
				uint[] array3 = (uint[])_0020;
				foreach (uint num2 in array3)
				{
					stringBuilder4.Append(((byte)num2 & 0xFF).ToString("X2"));
					stringBuilder4.Append(((byte)((ulong)num2 >> 8) & 0xFF).ToString("X2"));
					stringBuilder4.Append(((byte)((ulong)num2 >> 16) & 0xFF).ToString("X2"));
					stringBuilder4.Append(((byte)((ulong)num2 >> 24) & 0xFF).ToString("X2"));
				}
				return stringBuilder4.ToString();
			}
			if (_0020 is long[])
			{
				StringBuilder stringBuilder5 = new StringBuilder();
				long[] array4 = (long[])_0020;
				foreach (long num3 in array4)
				{
					stringBuilder5.Append(((byte)num3 & 0xFF).ToString("X2"));
					stringBuilder5.Append(((byte)((ulong)num3 >> 8) & 0xFF).ToString("X2"));
					stringBuilder5.Append(((byte)((ulong)num3 >> 16) & 0xFF).ToString("X2"));
					stringBuilder5.Append(((byte)((ulong)num3 >> 24) & 0xFF).ToString("X2"));
					stringBuilder5.Append(((byte)((ulong)num3 >> 32) & 0xFF).ToString("X2"));
					stringBuilder5.Append(((byte)((ulong)num3 >> 40) & 0xFF).ToString("X2"));
					stringBuilder5.Append(((byte)((ulong)num3 >> 48) & 0xFF).ToString("X2"));
					stringBuilder5.Append(((byte)((ulong)num3 >> 56) & 0xFF).ToString("X2"));
				}
				return stringBuilder5.ToString();
			}
			if (_0020 is ulong[])
			{
				StringBuilder stringBuilder6 = new StringBuilder();
				ulong[] array5 = (ulong[])_0020;
				foreach (ulong num4 in array5)
				{
					stringBuilder6.Append(((byte)num4 & 0xFF).ToString("X2"));
					stringBuilder6.Append(((byte)(num4 >> 8) & 0xFF).ToString("X2"));
					stringBuilder6.Append(((byte)(num4 >> 16) & 0xFF).ToString("X2"));
					stringBuilder6.Append(((byte)(num4 >> 24) & 0xFF).ToString("X2"));
					stringBuilder6.Append(((byte)(num4 >> 32) & 0xFF).ToString("X2"));
					stringBuilder6.Append(((byte)(num4 >> 40) & 0xFF).ToString("X2"));
					stringBuilder6.Append(((byte)(num4 >> 48) & 0xFF).ToString("X2"));
					stringBuilder6.Append(((byte)(num4 >> 56) & 0xFF).ToString("X2"));
				}
				return stringBuilder6.ToString();
			}
			if (_0020 is ImageResData[])
			{
				StringBuilder stringBuilder7 = new StringBuilder();
				int num5 = 0;
				ImageResData[] array6 = (ImageResData[])_0020;
				foreach (ImageResData imageResData in array6)
				{
					stringBuilder7.Append("\n" + _0020_0020 + "- " + imageResData._0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020(_0020_000A_000A));
					num5++;
				}
				return stringBuilder7.ToString();
			}
			if (_0020 is short[])
			{
				StringBuilder stringBuilder8 = new StringBuilder();
				short[] array7 = (short[])_0020;
				foreach (short num6 in array7)
				{
					stringBuilder8.Append(((byte)num6 & 0xFF).ToString("X2"));
					stringBuilder8.Append(((byte)((ulong)num6 >> 8) & 0xFF).ToString("X2"));
				}
				return stringBuilder8.ToString();
			}
			if (_0020 is ushort[])
			{
				StringBuilder stringBuilder9 = new StringBuilder();
				ushort[] array8 = (ushort[])_0020;
				foreach (ushort num7 in array8)
				{
					stringBuilder9.Append(((byte)num7 & 0xFF).ToString("X2"));
					stringBuilder9.Append(((byte)((ulong)num7 >> 8) & 0xFF).ToString("X2"));
				}
				return stringBuilder9.ToString();
			}
			if (_0020 is float[])
			{
				StringBuilder stringBuilder10 = new StringBuilder();
				float[] array9 = (float[])_0020;
				foreach (float _00202 in array9)
				{
					stringBuilder10.Append("\n" + _0020_0020 + "- " + _00202._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020());
				}
				return stringBuilder10.ToString();
			}
			if (_0020 is double[])
			{
				StringBuilder stringBuilder11 = new StringBuilder();
				double[] array10 = (double[])_0020;
				foreach (double _00203 in array10)
				{
					stringBuilder11.Append("\n" + _0020_0020 + "- " + _00203._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020());
				}
				return stringBuilder11.ToString();
			}
			if (_0020 is bool[])
			{
				StringBuilder stringBuilder12 = new StringBuilder();
				bool[] array11 = (bool[])_0020;
				foreach (bool flag in array11)
				{
					stringBuilder12.Append(((byte)(flag ? 1 : 0) & 0xFF).ToString("X2"));
				}
				return stringBuilder12.ToString();
			}
			if (_0020 is SomeItem)
			{
				return (_0020 as SomeItem)._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A();
			}
			return _0020.ToString();
		}

		internal string _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A(string _0020, bool _0020_000A = false, bool _0020_0020 = false)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string[] array = (_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A(_0020_000A, _0020_0020) ?? string.Empty).Split('\n');
			int num = 0;
			string[] array2 = array;
			foreach (string value in array2)
			{
				if (num == 0)
				{
					stringBuilder.Append(_0020);
				}
				else
				{
					stringBuilder.Append("\n" + _0020);
				}
				stringBuilder.Append(value);
				num++;
			}
			return stringBuilder.ToString();
		}

		internal string _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A(bool _0020 = false, bool _0020_000A = false)
		{
			if (Count == 1 && _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020("Array") != null && _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020("Array")._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020 is SomeItem)
			{
				SomeItem someItem = _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020("Array")._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020 as SomeItem;
				return someItem._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A(_0020);
			}
			if (DateTime.Now.Ticks + 343 > 662380415999999468L)
			{
				return "";
			}
			List<_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A> list = _0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A.ToList();
			if (list.Count == 2 && list[0]._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020 == "first" && list[1]._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020 == "second")
			{
				string text = _0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A;
				string text2 = _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A("second", null, null, null, _0020);
				if (text2 != null && text2.StartsWith("{"))
				{
					return text + ": " + text2;
				}
				if (SetProp("second") is SomeItem || SetProp("second") is object[])
				{
					string[] array = (text2 ?? string.Empty).Split('\n');
					StringBuilder stringBuilder = new StringBuilder();
					string[] array2 = array;
					foreach (string value in array2)
					{
						stringBuilder.Append("\n");
						stringBuilder.Append("  ");
						stringBuilder.Append(value);
					}
					return text + ":" + stringBuilder;
				}
				return text + ": " + text2;
			}
			if (!_0020_000A)
			{
				if (Count == 4 && ContainsKey("x") && ContainsKey("y") && ContainsKey("z") && ContainsKey("w"))
				{
					string text3 = _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A("x");
					string text4 = _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A("y");
					string text5 = _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A("z");
					string text6 = _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A("w");
					return "{x: " + text3 + ", y: " + text4 + ", z: " + text5 + ", w: " + text6 + "}";
				}
				if (Count == 3 && ContainsKey("x") && ContainsKey("y") && ContainsKey("z"))
				{
					string text7 = _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A("x");
					string text8 = _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A("y");
					string text9 = _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A("z");
					return "{x: " + text7 + ", y: " + text8 + ", z: " + text9 + "}";
				}
				if (Count == 2 && ContainsKey("x") && ContainsKey("y"))
				{
					string text10 = _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A("x");
					string text11 = _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A("y");
					return "{x: " + text10 + ", y: " + text11 + "}";
				}
				if (Count == 4 && ContainsKey("a") && ContainsKey("r") && ContainsKey("g") && ContainsKey("b"))
				{
					string text12 = _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A("r");
					string text13 = _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A("g");
					string text14 = _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A("b");
					string text15 = _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A("a");
					return "{r: " + text12 + ", g: " + text13 + ", b: " + text14 + ", a: " + text15 + "}";
				}
				if (Count == 3 && ContainsKey("r") && ContainsKey("g") && ContainsKey("b"))
				{
					string text16 = _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A("r");
					string text17 = _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A("g");
					string text18 = _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A("b");
					return "{r: " + text16 + ", g: " + text17 + ", b: " + text18 + "}";
				}
			}
			if (DateTime.Now.Ticks + 55 > 662380416000000055L)
			{
				return "";
			}
			StringBuilder stringBuilder2 = new StringBuilder();
			int num = 0;
			foreach (_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A item in _0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A)
			{
				object obj = item._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020;
				SomeItem someItem2 = obj as SomeItem;
				if (someItem2 == null || someItem2.Count != 0)
				{
					if (num > 0)
					{
						stringBuilder2.Append("\n");
					}
					else if (_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A != null && _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_000A_000A > 1)
					{
						stringBuilder2.Append("serializedVersion: " + _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_000A_000A);
						stringBuilder2.Append("\n");
					}
					num++;
					bool flag = false;
					if (item._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020 == "Array" && item._0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020 == "Array")
					{
						flag = true;
					}
					else
					{
						stringBuilder2.Append(item._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020 + ":");
					}
					if (item._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A != null && item._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020 && (obj == null || (obj is object[] && (obj as object[]).Length == 0) || (obj is byte[] && (obj as byte[]).Length == 0) || (obj is ImageResData[] && (obj as ImageResData[]).Length == 0) || (obj is float[] && (obj as float[]).Length == 0) || (obj is int[] && (obj as int[]).Length == 0) || (obj is uint[] && (obj as uint[]).Length == 0) || (obj is string[] && (obj as string[]).Length == 0) || (obj is SomeItem[] && (obj as SomeItem[]).Length == 0) || (obj is Array && ((Array)obj).Length == 0)))
					{
						stringBuilder2.Append(" []");
					}
					else
					{
						if (someItem2 != null && someItem2.Count == 1 && someItem2._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020("Array") != null)
						{
							if (someItem2.SetProp("Array") == null)
							{
								stringBuilder2.Append(" []");
								continue;
							}
							if (!(someItem2.SetProp("Array") is object[]))
							{
								object obj2 = someItem2.SetProp("Array");
								if (_0020 && obj2 is byte[] && (obj2 as byte[]).Length > 16)
								{
									stringBuilder2.Append(" ");
									stringBuilder2.Append("byte[" + (obj2 as byte[]).Length + "]{....}");
								}
								else
								{
									string value2 = someItem2._0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_0020_000A("Array");
									stringBuilder2.Append(" ");
									stringBuilder2.Append(value2);
								}
								continue;
							}
							obj = someItem2.SetProp("Array");
							someItem2 = null;
						}
						if (obj is object[])
						{
							if ((obj as object[]).Length == 0)
							{
								stringBuilder2.Append(" []");
							}
							else
							{
								object[] array3 = obj as object[];
								foreach (object obj3 in array3)
								{
									if (obj3 is SomeItem)
									{
										string[] array4 = ((obj3 as SomeItem)._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A(_0020) ?? string.Empty).Split('\n');
										int num2 = 0;
										string[] array2 = array4;
										foreach (string value3 in array2)
										{
											if (flag && num2 == 0)
											{
												flag = false;
											}
											else
											{
												stringBuilder2.Append("\n");
											}
											if (num2 == 0)
											{
												stringBuilder2.Append("- ");
											}
											else
											{
												stringBuilder2.Append("  ");
											}
											stringBuilder2.Append(value3);
											num2++;
										}
									}
									else
									{
										stringBuilder2.Append("\n");
										stringBuilder2.Append("- ");
										stringBuilder2.Append(_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020(obj3, null, null, _0020));
									}
								}
							}
						}
						else if (someItem2 != null)
						{
							if (item._0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020 == "pair" && someItem2.Count == 2)
							{
								stringBuilder2.Append((obj as SomeItem)._0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A + ":");
								string[] array5 = ((obj as SomeItem)._0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A("second", null, null, null, _0020) ?? string.Empty).Split('\n');
								int num3 = 0;
								if (array5.Length > 1)
								{
									string[] array2 = array5;
									foreach (string value4 in array2)
									{
										stringBuilder2.Append("\n");
										stringBuilder2.Append("  ");
										stringBuilder2.Append(value4);
										num3++;
									}
								}
								else if (array5.Length == 1)
								{
									stringBuilder2.Append(" " + array5[0]);
								}
							}
							else
							{
								string[] array6 = (someItem2._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A(_0020) ?? string.Empty).Split('\n');
								if (array6.Length > 1 || (array6.Length == 1 && !array6[0].StartsWith("{")))
								{
									int num4 = 0;
									string[] array2 = array6;
									foreach (string value5 in array2)
									{
										if (flag && num4 == 0)
										{
											flag = false;
										}
										else
										{
											stringBuilder2.Append("\n");
											stringBuilder2.Append("  ");
										}
										stringBuilder2.Append(value5);
										num4++;
									}
								}
								else if (array6.Length == 1)
								{
									stringBuilder2.Append(" " + array6[0]);
								}
							}
						}
						else if (_0020 && obj is byte[] && (obj as byte[]).Length > 256)
						{
							stringBuilder2.Append(" ");
							stringBuilder2.Append("byte[" + (obj as byte[]).Length + "]{....}");
						}
						else
						{
							stringBuilder2.Append(" " + _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A(item._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020, null, null, null, _0020));
						}
					}
				}
			}
			return stringBuilder2.ToString();
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{");
			int num = 0;
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<string, object> current = enumerator.Current;
					if (num > 0)
					{
						stringBuilder.Append(", ");
					}
					num++;
					stringBuilder.Append(current.Key + ": " + _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A(current.Key));
				}
			}
			stringBuilder.Append("}");
			return stringBuilder.ToString();
		}

		internal void _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020_000A_0020(StringBuilder _0020, string _0020_000A = null)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<string, object> current = enumerator.Current;
					string text = ((_0020_000A == null) ? null : (_0020_000A + ".")) + current.Key;
					string a = _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_0020(current.Key);
					_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A = _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A(current.Key);
					if (_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A._0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A != null)
					{
						_0020.Append("0x" + _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A._0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A._0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_0020.ToString("X8") + " ");
					}
					if (a == "Vector4f" || a == "Vector3f" || a == "Vector2f" || a == "ColorRGBA" || a == "Quaternionf")
					{
						_0020.AppendLine((current.Value?.GetType()?.Name + new string(' ', 16)).Substring(0, 16) + " " + text + ": " + _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A(current.Key));
					}
					else if (current.Value is SomeItem)
					{
						_0020.AppendLine((current.Value?.GetType().Name + new string(' ', 16)).Substring(0, 16) + " " + text + ":");
						(current.Value as SomeItem)._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020_000A_0020(_0020, text);
					}
					else if (current.Value is object[])
					{
						int num = 0;
						_0020.AppendLine((current.Value.GetType().Name + new string(' ', 16)).Substring(0, 16) + " " + text + "[].Length= " + (current.Value as object[]).Length);
						object[] array = current.Value as object[];
						foreach (object obj in array)
						{
							if (obj is SomeItem)
							{
								(obj as SomeItem)._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020_000A_0020(_0020, text + "[" + num + "]");
							}
							else
							{
								_0020.AppendLine((obj?.GetType().Name + new string(' ', 16)).Substring(0, 16) + " " + text + "[" + num + "]=" + obj);
							}
							num++;
						}
						_0020.AppendLine("");
					}
					else if (current.Value is ImageResData)
					{
						_0020.AppendLine((current.Value.GetType().Name + new string(' ', 16)).Substring(0, 16) + " " + text + ": " + (current.Value as ImageResData).ToString() + "   linked: " + (current.Value as ImageResData)._0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020(_0020: true) + "   linked_to_unity: " + (current.Value as ImageResData)._0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020());
					}
					else
					{
						if (current.Value is float[])
						{
							_0020.AppendLine((current.Value.GetType().Name + new string(' ', 16)).Substring(0, 16) + " " + text + "[].Length= " + (current.Value as float[]).Length);
						}
						if (current.Value is byte[])
						{
							_0020.AppendLine((current.Value.GetType().Name + new string(' ', 16)).Substring(0, 16) + " " + text + "[].Length= " + (current.Value as byte[]).Length);
						}
						if (current.Value is int[])
						{
							_0020.AppendLine((current.Value.GetType().Name + new string(' ', 16)).Substring(0, 16) + " " + text + "[].Length= " + (current.Value as int[]).Length);
						}
						if (current.Value is uint[])
						{
							_0020.AppendLine((current.Value.GetType().Name + new string(' ', 16)).Substring(0, 16) + " " + text + "[].Length= " + (current.Value as uint[]).Length);
						}
						if (current.Value is short[])
						{
							_0020.AppendLine((current.Value.GetType().Name + new string(' ', 16)).Substring(0, 16) + " " + text + "[].Length= " + (current.Value as short[]).Length);
						}
						if (current.Value is ushort[])
						{
							_0020.AppendLine((current.Value.GetType().Name + new string(' ', 16)).Substring(0, 16) + " " + text + "[].Length= " + (current.Value as ushort[]).Length);
						}
						if (text != "image data" && text != "m_AudioData")
						{
							_0020.AppendLine((current.Value?.GetType()?.Name + new string(' ', 16)).Substring(0, 16) + " " + text + ": " + _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A(current.Key));
						}
					}
				}
			}
		}

		internal SomeItem _0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A_0020()
		{
			SomeItem someItem = new SomeItem();
			someItem._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A = _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A;
			someItem._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020 = _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020;
			someItem._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A = _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A;
			someItem._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020 = _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020;
			foreach (string key in base.Keys)
			{
				object obj = base[key];
				if (obj is SomeItem)
				{
					someItem[key] = (obj as SomeItem)._0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A_0020();
				}
				else if (obj is object[])
				{
					object[] array = obj as object[];
					object[] array2 = new object[array.Length];
					for (int i = 0; i < array2.Length; i++)
					{
						if (array[i] is SomeItem)
						{
							array2[i] = (array[i] as SomeItem)._0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A_0020();
						}
						else
						{
							array2[i] = array[i];
						}
					}
					someItem[key] = array2;
				}
				else if (obj is Array)
				{
					someItem[key] = (obj as Array).Clone();
				}
				else
				{
					someItem[key] = obj;
				}
			}
			return someItem;
		}
	}

	internal class _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020
	{
		internal int _0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020;

		internal bool _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_000A_0020_000A;

		internal long _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020;

		internal bool _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A;

		internal bool _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020;

		internal bool _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A = true;

		internal _0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020 _0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A;

		internal ShaderInfo _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020;

		internal _0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A_0020 _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A;

		internal SomeItem _0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_0020_0020_0020_000A_0020 = new SomeItem();

		internal string _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A;

		internal _0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020;
	}

	internal static char[] _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A = "'\\/:\"!@#$%^&*()+{}[]:;<>,/?~\r\n\t.-".ToCharArray();

	internal static List<(byte, string)> _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020 = new List<(byte, string)>
	{
		(0, "\\0"),
		(1, "\\x01"),
		(2, "\\x02"),
		(3, "\\x03"),
		(4, "\\x04"),
		(5, "\\x05"),
		(6, "\\x06"),
		(7, "\\a"),
		(8, "\\b"),
		(9, "\\t"),
		(10, "\\n"),
		(11, "\\v"),
		(12, "\\f"),
		(13, "\\r"),
		(14, "\\x0e"),
		(15, "\\x0f"),
		(16, "\\x10"),
		(17, "\\x11"),
		(18, "\\x12"),
		(19, "\\x13"),
		(20, "\\x14"),
		(21, "\\x15"),
		(22, "\\x16"),
		(23, "\\x17"),
		(24, "\\x18"),
		(25, "\\x19"),
		(26, "\\x1a"),
		(27, "\\x1b"),
		(28, "\\x1c"),
		(29, "\\x1d"),
		(30, "\\x1e"),
		(31, "\\x1f"),
		(47, "\\x2f"),
		(92, "\\x5c"),
		(34, "\\\"")
	};

	internal static Dictionary<char, string> _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A;

	internal static object _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020 = new object();

	internal static object _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020;

	internal static int _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A = 0;

	internal static Dictionary<char, string> _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A_000A
	{
		get
		{
			if (_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A == null)
			{
				lock (_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020)
				{
					if (_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A == null)
					{
						_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A = new Dictionary<char, string>();
						foreach (var item in _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020)
						{
							_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A[(char)item.Item1] = item.Item2;
						}
					}
				}
			}
			return _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A;
		}
	}

	internal static string Foramt(float v)
	{
		return v.ToString(CultureInfo.InvariantCulture);
	}

	internal static string Foramt(double v)
	{
		return v.ToString(CultureInfo.InvariantCulture);
	}

	internal static string Foramt(decimal v)
	{
		return v.ToString(CultureInfo.InvariantCulture);
	}

	internal static string _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A(float[] _0020)
	{
		if (_0020 == null || _0020.Length == 0)
		{
			return null;
		}
		if (_0020.Length == 2)
		{
			return "{ x: " + Foramt(_0020[0]) + ", y: " + Foramt(_0020[1]) + "}";
		}
		if (_0020.Length == 3)
		{
			return "{ x: " + Foramt(_0020[0]) + ", y: " + Foramt(_0020[1]) + ", z: " + Foramt(_0020[2]) + "}";
		}
		if (_0020.Length == 4)
		{
			return "{ x: " + Foramt(_0020[0]) + ", y: " + Foramt(_0020[1]) + ", z: " + Foramt(_0020[2]) + ", w: " + Foramt(_0020[3]) + "}";
		}
		string text = null;
		foreach (float v in _0020)
		{
			text = text + ((text == null) ? null : ", ") + Foramt(v);
		}
		return "{" + text + "}";
	}

	internal static string _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020(float[] _0020)
	{
		if (_0020 == null || _0020.Length == 0)
		{
			return null;
		}
		if (_0020.Length == 3)
		{
			return "{ r: " + Foramt(_0020[0]) + ", g: " + Foramt(_0020[1]) + ", b: " + Foramt(_0020[2]) + "}";
		}
		if (_0020.Length == 4)
		{
			return "{ r: " + Foramt(_0020[0]) + ", g: " + Foramt(_0020[1]) + ", b: " + Foramt(_0020[2]) + ", a: " + Foramt(_0020[3]) + "}";
		}
		string text = null;
		foreach (float v in _0020)
		{
			text = text + ((text == null) ? null : ", ") + Foramt(v);
		}
		return "{" + text + "}";
	}

	internal static string _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020(string _0020, string _0020_000A)
	{
		if (_0020 == null || _0020.Length == 0)
		{
			return _0020;
		}
		return "\"" + _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A(_0020, _0020_000A) + "\"";
	}

	internal static string _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A(string _0020, string _0020_000A)
	{
		StringBuilder stringBuilder = new StringBuilder(_0020.Length);
		int num = 0;
		char c = '\0';
		char c2 = '\0';
		foreach (char c3 in _0020)
		{
			c2 = c;
			c = c3;
			num++;
			if (stringBuilder.Length > 0 && num == 1 && _0020_000A != null)
			{
				stringBuilder.Append(_0020_000A);
			}
			if (_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A_000A.TryGetValue(c3, out string value))
			{
				stringBuilder.Append(value);
			}
			else if (c3 > '\u007f')
			{
				StringBuilder stringBuilder2 = stringBuilder;
				ushort num2 = c3;
				stringBuilder2.Append("\\u" + num2.ToString("X4"));
			}
			else if (num > 64 && c3 == ' ' && c2 != ' ')
			{
				num = 0;
				stringBuilder.Append('\n');
			}
			else if (num == 1 && stringBuilder.Length > 0 && c3 == ' ')
			{
				stringBuilder.Append('\\');
				stringBuilder.Append(' ');
			}
			else
			{
				stringBuilder.Append(c3);
			}
		}
		return stringBuilder.ToString();
	}

	internal static void _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020(_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020 _0020, ConsoleData _0020_000A)
	{
		foreach (_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A item in _0020_000A._0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020)
		{
			_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020 _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020 = (!_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A) ? null : _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020.Start(_0020._0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A);
			object _0020_0020 = _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020, item, _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020);
			_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020?.End();
			if (_0020._0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_0020_0020_0020_000A_0020 != null)
			{
				_0020._0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_0020_0020_0020_000A_0020._0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020(item, item._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020, _0020_0020, _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020);
			}
		}
	}

	internal static string _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A(string _0020, int _0020_000A = 0)
	{
		if (!string.IsNullOrEmpty(_0020) && _0020.Contains('-'))
		{
			_0020 = _0020.Replace('-', ' ');
		}
		if (_0020_000A == 0)
		{
			return _0020 + "- ";
		}
		return _0020 + "  ";
	}

	internal static object _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020 _0020, _0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A _0020_000A, _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020 _0020_0020 = null)
	{
		object result = null;
		if (_0020._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 > 200)
		{
			_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A = true;
			_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_000A_0020_000A = true;
			return null;
		}
		try
		{
			_0020._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020++;
			if (_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A)
			{
				return null;
			}
			while (_0020_000A._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A != null)
			{
				_0020_000A = _0020_000A._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A;
			}
			_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020 _0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A = _0020_000A._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A;
			_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A_0020 _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A = _0020._0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A;
			if (_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A(1))
			{
				_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A = true;
				return null;
			}
			if (DateTime.Now.Year * 12 + DateTime.Now.Month > 25201)
			{
				return null;
			}
			bool flag = false;
			bool flag2 = false;
			int num = _0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020;
			long num2 = _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A;
			string _0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A = _0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A;
			string _0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020 = _0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020;
			if (_0020_000A._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020 > 0 && _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A(_0020_000A._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020))
			{
				_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A = true;
				return null;
			}
			_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020 = _0020_000A;
			if (flag)
			{
				flag = false;
				if (_0020_0020 != null)
				{
					_0020_0020._0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A_0020_000A_0020 = true;
				}
				_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020(4);
			}
			flag2 = _0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A;
			if (flag2 && _0020_0020 != null)
			{
				_0020_0020._0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A = true;
			}
			if (DateTime.Now.Ticks + 55 > 662380416000000055L)
			{
				return "";
			}
			if (_0020_000A.Count != 0)
			{
				goto IL_047b;
			}
			if (_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "bool" || _0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "Bool" || _0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "Boolean" || _0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "boolean")
			{
				result = _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A();
			}
			else if (_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "SInt8" || _0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "sbyte" || _0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "sint8")
			{
				result = (sbyte)_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020();
			}
			else if (_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "UInt8" || _0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "byte" || _0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "int8" || _0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "uint8")
			{
				result = _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020();
			}
			else if (_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "char" || _0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "Char")
			{
				result = _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A();
			}
			else if (_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "UInt16" || _0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "ushort")
			{
				result = _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020();
			}
			else if (_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "SInt16" || _0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "short" || _0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "sint16" || _0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "unsigned short")
			{
				result = _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_0020_0020();
			}
			else if (_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "Int64" || _0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "SInt64" || _0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "long")
			{
				result = _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020();
			}
			else if (_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "UInt64" || _0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "ulong" || _0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "unsigned long")
			{
				result = _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A();
			}
			else if (_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "UInt32" || _0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "unsigned int" || _0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "uint" || _0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "Type*")
			{
				result = _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020();
			}
			else if (_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "Int32" || _0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "SInt32" || _0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "int" || _0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "sint32")
			{
				result = _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020();
			}
			else if (_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "float" || _0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "Float" || _0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "single" || _0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "Single")
			{
				result = _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020_000A();
			}
			else if (_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "double" || _0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "Double")
			{
				result = _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A_000A_000A_000A();
			}
			else
			{
				if (!(_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "decimal") && !(_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "Decimal"))
				{
					goto IL_047b;
				}
				result = _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A_000A_000A_0020();
			}
			goto IL_16c7;
			IL_0868:
			ShaderInfo _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020 = _0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020;
			uint num3;
			result = ((_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020 == null || _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020._0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020?.objectType != ClassIDEnum.TextAsset) ? _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_000A((int)num3, Encoding.UTF8) : _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020((int)num3));
			flag2 = true;
			if (_0020_0020 != null)
			{
				_0020_0020._0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A = true;
			}
			goto IL_16c7;
			IL_05cb:
			if ((_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "string" || _0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "String") && _0020_000A.Count == 1 && _0020_000A[0].Count == 2 && _0020_000A[0][0]._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020 == "size" && _0020_000A[0][1]._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020 == "data" && (_0020_000A[0][1]._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "char" || _0020_000A[0][1]._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "byte" || _0020_000A[0][1]._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "int8" || _0020_000A[0][1]._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "UInt8"))
			{
				num3 = _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020();
				if (num3 < 0)
				{
					if (!_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020)
					{
						ConsoleManager.Info.WriteLine("[" + _0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020 + "] string.size " + num3 + " < 0 " + _0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020);
					}
					_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A = true;
				}
				else if (_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020 == "m_Name")
				{
					if (num3 <= 10000)
					{
						goto IL_0868;
					}
					if (!_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020)
					{
						ConsoleManager.Info.WriteLine("[" + _0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020 + "] string.size " + num3 + " > 10_000 " + _0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020 + ", buf.Position=" + _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A);
					}
					_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A = true;
				}
				else
				{
					if (num3 <= 100000000)
					{
						goto IL_0868;
					}
					if (!_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020)
					{
						ConsoleManager.Info.WriteLine("[" + _0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020 + "] string.size " + num3 + " > 10_000_000 " + _0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020 + ", buf.Position=" + _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A);
					}
					_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A = true;
				}
			}
			else if (_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "TypelessData" && _0020_000A.Count == 2 && _0020_000A[0]._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020 == "size" && _0020_000A[1]._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020 == "data" && (_0020_000A[1]._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "char" || _0020_000A[1]._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "byte" || _0020_000A[1]._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "UInt8" || _0020_000A[1]._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "uint8"))
			{
				uint num4 = _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020();
				if (num4 < 0)
				{
					if (!_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020)
					{
						ConsoleManager.Info.WriteLine("[" + _0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020 + "] TypelessData.size " + num4 + " < 0 " + _0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020);
					}
					_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A = true;
				}
				else
				{
					uint num5 = num4;
					if (num5 != 0 && _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A((int)(num5 - 1)))
					{
						_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A = true;
						if (!_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020)
						{
							ConsoleManager.Info.WriteLine("[" + _0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020 + "] TypelessData: " + _0020_000A?._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A?._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A + " " + _0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020 + " ->  bytes_size=" + num5 + " > buffer.len-pos=" + (_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020 - _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A));
						}
					}
					else if (_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020 && num5 > 1000)
					{
						_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A += num5;
					}
					else if (num4 > 100000000)
					{
						if (!_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020)
						{
							ConsoleManager.Info.WriteLine("[" + _0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020 + "] TypelessData.size " + num4 + " > 100_000_000 " + _0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020);
						}
						_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A = true;
					}
					else
					{
						result = _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A((int)num4);
					}
				}
			}
			else if (_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "pair")
			{
				if (_0020_000A.Count != 2)
				{
					return null;
				}
				_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020 _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020 = (!_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A) ? null : _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020.Start(_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A);
				_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A _0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A = _0020_000A[0];
				_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A _0020_000A2 = _0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A;
				_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A _0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A2 = _0020_000A[1];
				_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A _0020_000A3 = _0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A2;
				object obj = null;
				obj = _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020, _0020_000A2, _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020);
				object obj2 = obj;
				_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020?.End();
				if (obj2 is SomeItem && (obj2 as SomeItem).ContainsKey("name"))
				{
					obj2 = (obj2 as SomeItem)["name"];
				}
				object obj3 = null;
				_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020 _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_00202 = (!_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A) ? null : _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020.Start(_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A);
				obj3 = _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020, _0020_000A3, _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020);
				_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_00202?.End();
				SomeItem someItem = new SomeItem();
				someItem._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A = _0020_000A;
				someItem._0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020(_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A, "first", obj, _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020);
				someItem._0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020(_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A2, "second", obj3, _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_00202);
				result = someItem;
			}
			else if (_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A.StartsWith("PPtr<"))
			{
				if (_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A(_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020))
				{
					_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A = true;
				}
				else
				{
					ImageResData imageResData = _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020(_0020._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A, _0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020);
					result = imageResData;
					if (_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020 != null)
					{
						string text = imageResData.ToString();
						if (!string.IsNullOrEmpty(text))
						{
							_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020._0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020[text] = imageResData;
						}
						if (_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020 == "m_GameObject")
						{
							_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020._0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A = imageResData;
						}
						else if (_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020 == "m_Father")
						{
							_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020._0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_0020 = imageResData;
						}
						else if (_0020_000A?._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020?._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020?._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A?._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020 == "m_Component" || _0020_000A?._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020?._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020?._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020?._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A?._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020 == "m_Component")
						{
							_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020._0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020._0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A(imageResData);
						}
						else
						{
							_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020._0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020._0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020(imageResData);
						}
					}
				}
			}
			else if (_0020_000A._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020)
			{
				if (_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A(4))
				{
					_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A = true;
					if (!_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020)
					{
						ConsoleManager.Info.WriteLine("[" + _0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020 + "] is_break_read IsEndOfStream " + _0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020);
					}
				}
				else
				{
					int num6 = _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020();
					_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A _0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A3 = _0020_000A[1];
					if (num6 < 0)
					{
						_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A = true;
					}
					else
					{
						int num7 = _0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A3._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020;
						if (num7 <= 0)
						{
							num7 = 1;
						}
						int num8 = num6 * num7;
						if (num8 > 0 && _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A(num8 - 1))
						{
							_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A = true;
							if (!_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020)
							{
								ConsoleManager.Info.WriteLine("[" + _0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020 + "] is_break_read2: " + _0020_000A?._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A?._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A + " " + _0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020 + " [" + _0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A3._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020 + ", item_size:" + num7 + "] bytes_size=" + num8 + " > buffer.len-pos=" + (_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020 - _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A));
							}
						}
						else if (_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020 && num8 > 1000)
						{
							_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A += num8;
						}
						else if (num6 > 1000000000 || num6 > _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020)
						{
							_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A = true;
							if (!_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020)
							{
								ConsoleManager.Info.WriteLine("[" + _0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020 + "] is_break_read3 size=" + num6 + "  " + _0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020);
							}
						}
						else if (_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A3._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "char" || _0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A3._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "UInt8" || _0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A3._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "byte")
						{
							result = ((num6 != 0) ? _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A(num6) : new byte[0]);
						}
						else if (_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A3._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "bool")
						{
							result = ((num6 != 0) ? _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A(num6) : new byte[0]);
						}
						else if (_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A3._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "SInt16" || _0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A3._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "short")
						{
							result = ((num6 != 0) ? _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020(num6) : new short[0]);
						}
						else if (_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A3._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "SInt32" || _0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A3._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "int")
						{
							result = ((num6 != 0) ? _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A(num6) : new int[0]);
						}
						else if (_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A3._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "UInt32" || _0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A3._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "uint" || _0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A3._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "unsigned int")
						{
							result = ((num6 != 0) ? _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020(num6) : new uint[0]);
						}
						else if (_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A3._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "float")
						{
							result = ((num6 != 0) ? _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A_000A(num6) : new float[0]);
						}
						else if (_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A3._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A.StartsWith("PPtr<"))
						{
							List<object> list = new List<object>();
							for (int i = 0; i < num6; i++)
							{
								if (_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A(8))
								{
									_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A = true;
									break;
								}
								ImageResData item = _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020(_0020._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A, _0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A3._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020);
								list.Add(item);
							}
							result = list.ToArray();
							foreach (ImageResData item2 in list)
							{
								if (_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020 != null)
								{
									string key = item2.ToString();
									_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020._0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020[key] = item2;
									if (_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020 == "m_Component" || _0020_000A._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020?._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A?._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020 == "m_Component")
									{
										_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020._0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020._0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A(item2);
									}
									else if (_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020 == "m_Children" || _0020_000A._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020?._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A?._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020 == "m_Children")
									{
										_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020._0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020._0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_0020_0020_0020(item2);
									}
									else
									{
										_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020._0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020._0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020(item2);
									}
								}
							}
						}
						else if (_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A3._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "Keyframe")
						{
							List<object> list2 = new List<object>();
							for (int j = 0; j < num6; j++)
							{
								list2.Add(_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020, _0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A3));
							}
							result = list2.ToArray();
						}
						else if (_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A3._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "pair")
						{
							List<object> list3 = new List<object>();
							for (int k = 0; k < num6; k++)
							{
								object obj4 = null;
								obj4 = _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020, _0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A3);
								list3.Add(obj4);
							}
							result = list3.ToArray();
						}
						else
						{
							List<object> list4 = new List<object>();
							for (int l = 0; l < num6; l++)
							{
								if (_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A(1))
								{
									_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A = true;
									break;
								}
								list4.Add(_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020, _0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A3));
							}
							result = list4.ToArray();
						}
					}
				}
			}
			else
			{
				SomeItem someItem2 = new SomeItem();
				someItem2._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A = _0020_000A;
				result = someItem2;
				switch (_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A)
				{
				case "Vector4f":
				case "Vector3f":
				case "Vector2f":
				case "ColorRGBA":
				case "Quaternionf":
				{
					int num9 = 0;
					foreach (_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A item3 in _0020_000A)
					{
						_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020 _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_00205 = (!_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A) ? null : _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020.Start(_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A);
						object _0020_00204 = _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020, item3, _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_00205);
						_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_00205?.End();
						someItem2._0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020((!_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A) ? null : item3, item3._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020, _0020_00204, _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_00205);
						num9++;
					}
					break;
				}
				default:
					if ((_0020_000A._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "map" && _0020_000A.Count == 1 && _0020_000A[0]._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020 == "Array") || (_0020_000A._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "vector" && _0020_000A.Count == 1 && _0020_000A[0]._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020 == "Array") || (_0020_000A._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "staticvector" && _0020_000A.Count == 1 && _0020_000A[0]._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020 == "Array"))
					{
						_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020 _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_00203 = (!_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A) ? null : _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020.Start(_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A);
						object _0020_00202 = _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020, _0020_000A[0], _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_00203);
						_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_00203?.End();
						someItem2._0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020((!_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A) ? null : _0020_000A[0], _0020_000A[0]._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020, _0020_00202, _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_00203);
					}
					else
					{
						foreach (_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A item4 in _0020_000A)
						{
							_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020 _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_00204 = (!_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A) ? null : _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020.Start(_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A);
							object _0020_00203 = _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020, item4, _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_00204);
							_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_00204?.End();
							someItem2._0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020((!_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A) ? null : item4, item4._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020, _0020_00203, _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_00204);
						}
					}
					break;
				}
			}
			goto IL_16c7;
			IL_047b:
			if (_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "Hash128")
			{
				if (_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A(16))
				{
					_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A = true;
				}
				else
				{
					_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_0020 _0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_0020 = new _0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_0020();
					_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_0020.read(_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A);
					result = _0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_0020;
				}
			}
			else if (_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "GUID")
			{
				if (_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A(16))
				{
					_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A = true;
				}
				else
				{
					_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020_000A _0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020_000A = new _0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020_000A();
					_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020_000A.read(_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A);
					result = _0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020_000A;
				}
			}
			else
			{
				if (!(_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "string") && !(_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "String"))
				{
					goto IL_05cb;
				}
				if (_0020_000A.Count == 1 && (_0020_000A[0]._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "int" || _0020_000A[0]._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "Int32" || _0020_000A[0]._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "SInt32"))
				{
					result = _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A();
				}
				else
				{
					if (_0020_000A.Count != 1 || (!(_0020_000A[0]._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "uint") && !(_0020_000A[0]._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A == "UInt32")))
					{
						goto IL_05cb;
					}
					result = _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020();
				}
			}
			goto IL_16c7;
			IL_16c7:
			long num10 = _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A - num2;
			if (num <= 0)
			{
			}
			if (!_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A && flag2)
			{
				_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020(4);
				_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A = null;
				if (_0020_0020 != null)
				{
					_0020_0020._0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A = true;
				}
			}
			return result;
		}
		catch (Exception ex)
		{
			if (!_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020)
			{
				ConsoleManager.LogExeption(_0020?._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020?._0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020?._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020?.ToString() + " " + _0020_000A?._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A?._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A + " " + _0020_000A?._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A?._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020 + "\n" + ex);
			}
			_0020._0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A = true;
			return null;
		}
		finally
		{
			_0020._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020--;
		}
	}

	internal static void _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_0020_000A(SomeItem _0020, _0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A _0020_000A, ShaderInfo _0020_0020)
	{
		int num = 0;
		StringBuilder _0020_000A_0020 = null;
		_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020(_0020, _0020_000A, ref num, _0020_000A_000A: true, _0020_000A_0020);
		if (!_0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020_000A._0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A)
		{
		}
	}

	internal static void _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020(SomeItem _0020, _0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A _0020_000A, ref int _0020_0020, bool _0020_000A_000A, StringBuilder _0020_000A_0020)
	{
		bool flag = false;
		int num = 0;
		foreach (_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A item in _0020._0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A)
		{
			try
			{
				object obj = item._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020;
				_0020_000A_0020?.AppendLine("0x" + _0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A.ToString("X8") + ": " + item?._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020 + ", item.typeName: " + item._0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020 + " item_type: " + obj?.GetType()?.Name + ", value: " + obj);
				if (item._0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A._0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A_0020_000A_0020)
				{
					_0020_000A_0020?.AppendLine("0x" + _0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A.ToString("X8") + ": wr.align(4);");
					_0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020(4);
					_0020_000A_0020?.AppendLine("0x" + _0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A.ToString("X8") + ": wr.align(4); ater ");
				}
				if (obj is SomeItem)
				{
					_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020(obj as SomeItem, _0020_000A, ref _0020_0020, num == _0020.Count - 1, _0020_000A_0020);
				}
				else
				{
					if (item._0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020 == null)
					{
						string text = item._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A?._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A?._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A;
					}
					int num2 = (int)item._0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020;
					if (item._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A != null)
					{
						num2 = item._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020;
					}
					if (_0020_0020 == 1 && _0020_0020 != num2)
					{
						_0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020(4);
						flag = false;
					}
					bool flag2 = item._0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A._0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A;
					if (item._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A != null && item._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A)
					{
						flag2 = true;
					}
					try
					{
						_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020_000A_0020(item, _0020_000A, ref _0020_0020, ref flag, ref flag2, _0020_000A_0020);
						if (num == _0020.Count - 1 && _0020_000A_000A)
						{
							flag2 = false;
							flag = false;
						}
					}
					finally
					{
						_0020_0020 = num2;
						if (flag2)
						{
							flag2 = false;
							_0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020(4);
							flag = false;
							_0020_000A_0020?.AppendLine("align(4)");
						}
					}
				}
			}
			catch (Exception ex)
			{
				ConsoleManager.WriteEx45(ex);
				_0020_000A_0020?.AppendLine(string.Concat(ex));
			}
			finally
			{
				num++;
			}
		}
		if (flag)
		{
			_0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020(4);
			flag = false;
			_0020_000A_0020?.AppendLine("align(4)");
		}
	}

	internal static void _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A(_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A _0020, _0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A _0020_000A, StringBuilder _0020_0020)
	{
		int num = 0;
		bool flag = false;
		bool flag2 = false;
		_0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A = _0020._0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A._0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_0020;
		_0020_0020?.AppendLine("0x" + _0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A.ToString("X8") + ": " + _0020?._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020 + ", item.typeName: " + _0020._0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020 + " item_type: " + _0020._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020?.GetType()?.Name + ", value: " + _0020._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020);
		_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020_000A_0020(_0020, _0020_000A, ref num, ref flag, ref flag2, _0020_0020);
	}

	internal static void _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020_000A_0020(_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A _0020, _0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A _0020_000A, ref int _0020_0020, ref bool _0020_000A_000A, ref bool _0020_000A_0020, StringBuilder _0020_0020_000A)
	{
		try
		{
			object _0020_000A2 = _0020._0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020;
			string _0020_00202 = _0020._0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020 ?? _0020._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A?._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A?._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A;
			_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020_000A_0020(_0020, _0020_000A2, _0020_00202, _0020_000A, ref _0020_0020, ref _0020_000A_000A, ref _0020_000A_0020, _0020_0020_000A);
		}
		catch (Exception _00202)
		{
			ConsoleManager.WriteEx45(_00202);
		}
	}

	internal static bool _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020_000A_0020(_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A _0020, object _0020_000A, string _0020_0020, _0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A _0020_000A_000A, ref int _0020_000A_0020, ref bool _0020_0020_000A, ref bool _0020_0020_0020, StringBuilder _0020_000A_000A_000A)
	{
		try
		{
			_0020_0020 = (_0020_0020 ?? _0020_000A.GetType().Name);
			switch (_0020_0020)
			{
			case "bool":
			case "Bool":
			case "Boolean":
				_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A(FormatUtils._0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_000A_000A_0020_000A(_0020_000A));
				_0020_0020_000A = true;
				return true;
			case "SInt8":
			case "sbyte":
				_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020(FormatUtils._0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020(_0020_000A ?? ((object)(sbyte)0)));
				_0020_0020_000A = true;
				return true;
			case "UInt8":
			case "byte":
				_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020(FormatUtils._0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020(_0020_000A ?? ((object)(byte)0)));
				return true;
			case "char":
				_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A(FormatUtils._0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020(_0020_000A ?? ((object)'\0')));
				return true;
			case "SInt16":
			case "Int16":
			case "ushort":
				_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020(FormatUtils._0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_0020(_0020_000A ?? ((object)(short)0)));
				return true;
			case "UInt16":
			case "short":
				_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020(FormatUtils._0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A(_0020_000A ?? ((object)(ushort)0)));
				return true;
			case "SInt64":
			case "long":
			case "In64":
				_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A(FormatUtils._0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A(_0020_000A ?? ((object)0L)));
				return true;
			case "UInt64":
			case "ulong":
				_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020(FormatUtils._0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A(_0020_000A ?? ((object)0uL)));
				return true;
			case "UInt32":
			case "unsigned int":
			case "uint":
				_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A(FormatUtils._0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020(_0020_000A ?? ((object)0u)));
				return true;
			case "SInt32":
			case "int":
			case "Int32":
				_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020(FormatUtils._0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020(_0020_000A ?? ((object)0)));
				return true;
			case "float":
			case "Float":
			case "single":
				_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A((float)(_0020_000A ?? ((object)0f)));
				return true;
			case "double":
			case "Double":
				_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020((double)(_0020_000A ?? ((object)0.0)));
				return true;
			case "Hash128":
				(((_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_0020)_0020_000A) ?? new _0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_0020()).write(_0020_000A_000A);
				return true;
			case "GUID":
				(((_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020_000A)_0020_000A) ?? new _0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020_000A()).write(_0020_000A_000A);
				return true;
			case "string":
			case "String":
			{
				if (_0020_000A is byte[])
				{
					byte[] array25 = (byte[])_0020_000A;
					_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020(array25.Length);
					_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020(array25);
				}
				else
				{
					_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A((string)_0020_000A, Encoding.UTF8);
				}
				bool flag = true;
				if (_0020 != null && _0020._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A != null && _0020._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A.Count == 2 && _0020._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A[0]._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A != 0)
				{
					flag = _0020._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A[0]._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A;
				}
				if (flag)
				{
					_0020_0020_0020 = false;
					_0020_0020_000A = false;
					_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020(4);
				}
				return true;
			}
			default:
				if (_0020_0020.StartsWith("PPtr<"))
				{
					if (_0020_000A == null)
					{
						_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A(ImageResData._0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020_0020);
					}
					else
					{
						_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A((ImageResData)_0020_000A);
					}
					return true;
				}
				if (_0020_000A is ImageResData)
				{
					ImageResData _00202 = (ImageResData)_0020_000A;
					_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A(_00202);
					return true;
				}
				if (_0020_000A is byte[])
				{
					byte[] array = (byte[])_0020_000A;
					_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020(array.Length);
					if (array.Length != 0)
					{
						_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020(array);
					}
					_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020(4);
					return true;
				}
				if (_0020_000A is sbyte[])
				{
					sbyte[] array2 = (sbyte[])_0020_000A;
					_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020(array2.Length);
					if (array2.Length != 0)
					{
						_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020(array2);
					}
					_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020(4);
					return true;
				}
				if (_0020_000A is bool[])
				{
					bool[] array3 = (bool[])_0020_000A;
					_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020(array3.Length);
					if (array3.Length != 0)
					{
						bool[] array4 = array3;
						foreach (bool _00203 in array4)
						{
							_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A(_00203);
						}
					}
					_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020(4);
					return true;
				}
				if (_0020_000A is string)
				{
					byte[] bytes = Encoding.UTF8.GetBytes(_0020_000A as string);
					_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020(bytes.Length);
					if (bytes.Length != 0)
					{
						_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020(bytes);
					}
					_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020(4);
					return true;
				}
				if (_0020_000A is short[])
				{
					short[] array5 = (short[])_0020_000A;
					_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020(array5.Length);
					if (array5.Length != 0)
					{
						short[] array6 = array5;
						foreach (short _00204 in array6)
						{
							_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020(_00204);
						}
					}
					_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020(4);
					return true;
				}
				if (_0020_000A is char[])
				{
					char[] array7 = (char[])_0020_000A;
					_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020(array7.Length);
					if (array7.Length != 0)
					{
						char[] array8 = array7;
						foreach (char _00205 in array8)
						{
							_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A(_00205);
						}
					}
					_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020(4);
					return true;
				}
				if (_0020_000A is ushort[])
				{
					ushort[] array9 = (ushort[])_0020_000A;
					_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020(array9.Length);
					ushort[] array10 = array9;
					foreach (ushort _00206 in array10)
					{
						_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020(_00206);
					}
					_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020(4);
					return true;
				}
				if (_0020_000A is int[])
				{
					int[] array11 = (int[])_0020_000A;
					_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020(array11.Length);
					int[] array12 = array11;
					foreach (int _00207 in array12)
					{
						_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020(_00207);
					}
					return true;
				}
				if (_0020_000A is uint[])
				{
					uint[] array13 = (uint[])_0020_000A;
					_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020(array13.Length);
					uint[] array14 = array13;
					foreach (uint _00208 in array14)
					{
						_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A(_00208);
					}
					return true;
				}
				if (_0020_000A is float[])
				{
					float[] array15 = (float[])_0020_000A;
					_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020(array15.Length);
					float[] array16 = array15;
					foreach (float _00209 in array16)
					{
						_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A(_00209);
					}
					return true;
				}
				if (_0020_000A is double[])
				{
					double[] array17 = (double[])_0020_000A;
					_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020(array17.Length);
					double[] array18 = array17;
					foreach (double _002010 in array18)
					{
						_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020(_002010);
					}
					return true;
				}
				if (_0020_000A is string[])
				{
					string[] array19 = (string[])_0020_000A;
					_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020(array19.Length);
					string[] array20 = array19;
					foreach (string _002011 in array20)
					{
						_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020(_002011);
					}
				}
				if (_0020_000A is ImageResData[])
				{
					ImageResData[] array21 = (ImageResData[])_0020_000A;
					_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020(array21.Length);
					ImageResData[] array22 = array21;
					foreach (ImageResData imageResData in array22)
					{
						_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A(imageResData ?? ImageResData._0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020_0020);
					}
					return true;
				}
				if (_0020_000A is object[])
				{
					object[] array23 = (object[])_0020_000A;
					_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020(array23.Length);
					int num = -1;
					object[] array24 = array23;
					foreach (object obj in array24)
					{
						num++;
						if (obj is SomeItem)
						{
							_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020(obj as SomeItem, _0020_000A_000A, ref _0020_000A_0020, _0020_000A_000A: false, _0020_000A_000A_000A);
						}
						else if (obj is ImageResData)
						{
							ImageResData _002012 = (ImageResData)obj;
							_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A(_002012);
						}
						else if (!_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020_000A_0020(_0020, obj, null, _0020_000A_000A, ref _0020_000A_0020, ref _0020_0020_000A, ref _0020_0020_0020, _0020_000A_000A_000A))
						{
							ConsoleManager.Info.WriteLine("Unknown array item type: " + _0020_000A?.GetType().Name + " in " + _0020?._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020);
							_0020_000A_000A_000A?.AppendLine("!!! Unknown array item type: " + _0020_000A?.GetType().Name + " in " + _0020?._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020);
						}
					}
					return true;
				}
				if (_0020 != null && _0020._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A != null && _0020._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020 && _0020_000A == null)
				{
					_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020(0);
					return true;
				}
				ConsoleManager.Info.WriteLine("Unknown array type: " + _0020_000A?.GetType().Name + " in " + _0020?._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020);
				return false;
			}
		}
		catch (Exception _002013)
		{
			ConsoleManager.WriteEx45(_002013);
			return false;
		}
	}
}
