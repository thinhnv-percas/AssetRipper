using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

internal class MaybeHashCalc
{
	private static char[] _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A = "()[]{}<>.,:;'\"+-*/=\\?|&^%#@!~` \t\r\n\0".ToCharArray();

	private static char[] _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020 = " \t\r\n".ToCharArray();

	private static Dictionary<string, int> _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_000A_0020_000A = new Dictionary<string, int>();

	internal static char[] _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020 => _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A;

	internal static bool _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020(string _0020, string _0020_000A, int _0020_0020 = 0)
	{
		return _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020(_0020, _0020_000A, _0020_0020, _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020);
	}

	internal static bool _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020(string _0020, string _0020_000A, int _0020_0020, params char[] separator_chars)
	{
		if (_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A(_0020, _0020_000A, _0020_0020, separator_chars) < 0)
		{
			return false;
		}
		return true;
	}

	internal static string _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A(string _0020, string _0020_000A, string _0020_0020, int _0020_000A_000A = 0)
	{
		return _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A(_0020, _0020_000A, _0020_0020, _0020_000A_000A, _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020);
	}

	internal static string _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A(string _0020, string _0020_000A, string _0020_0020, int _0020_000A_000A, params char[] separator_chars)
	{
		if (string.IsNullOrEmpty(_0020) || string.IsNullOrEmpty(_0020_000A))
		{
			return _0020;
		}
		if (_0020_000A_000A < 0)
		{
			_0020_000A_000A = 0;
		}
		do
		{
			int num = _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A(_0020, _0020_000A, _0020_000A_000A, separator_chars);
			if (num < 0)
			{
				return _0020;
			}
			_0020 = _0020.Remove(num, _0020_000A.Length);
			if (!string.IsNullOrEmpty(_0020_0020))
			{
				_0020 = _0020.Insert(num, _0020_0020);
			}
			_0020_000A_000A = num + (_0020_0020?.Length ?? 0);
		}
		while (_0020_000A_000A < _0020.Length);
		return _0020;
	}

	internal static string _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020(string _0020, string _0020_000A, string _0020_0020, int _0020_000A_000A = 0)
	{
		if (_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020(_0020, _0020_000A, _0020_000A_000A, out int startIndex, out int count))
		{
			_0020 = _0020.Remove(startIndex, count).Insert(startIndex, _0020_0020);
		}
		return _0020;
	}

	internal static bool _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A(string _0020, string _0020_000A, int _0020_0020 = 0)
	{
		int num;
		int num2;
		return _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020(_0020, _0020_000A, _0020_0020, out num, out num2);
	}

	internal static bool _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020(string _0020, string _0020_000A, int _0020_0020, out int _0020_000A_000A, out int _0020_000A_0020)
	{
		_0020_000A_000A = -1;
		_0020_000A_0020 = 0;
		List<char> list = new List<char>(_0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020);
		List<char> list2 = new List<char>(_0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A);
		if (string.IsNullOrEmpty(_0020) || string.IsNullOrEmpty(_0020_000A))
		{
			return false;
		}
		List<string> list3 = new List<string>();
		string text = "";
		for (int i = 0; i < _0020_000A.Length; i++)
		{
			char item = _0020_000A[i];
			if (list2.Contains(item))
			{
				if (!string.IsNullOrEmpty(text))
				{
					list3.Add(text);
				}
				text = "";
				if (!list.Contains(item))
				{
					list3.Add(item.ToString() ?? "");
				}
			}
			else
			{
				text += item.ToString();
			}
		}
		if (!string.IsNullOrEmpty(text))
		{
			list3.Add(text);
		}
		text = "";
		if (list3.Count == 0)
		{
			return false;
		}
		int num = -1;
		bool flag = true;
		foreach (string item2 in list3)
		{
			if (!string.IsNullOrEmpty(item2))
			{
				int num2 = _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A(_0020, item2, _0020_0020);
				if (flag)
				{
					num = num2;
				}
				if (num2 < 0)
				{
					return false;
				}
				if (!flag)
				{
					for (int j = _0020_0020; j < num2; j++)
					{
						if (!list.Contains(_0020[j]))
						{
							return false;
						}
					}
				}
				_0020_0020 = num2 + item2.Length;
				flag = false;
			}
		}
		_0020_000A_000A = num;
		_0020_000A_0020 = _0020_0020 - num;
		return true;
	}

	internal static int _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A(string _0020, string _0020_000A, int _0020_0020 = 0)
	{
		return _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A(_0020, _0020_000A, _0020_0020, _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020);
	}

	internal static int _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A(string _0020, string _0020_000A, int _0020_0020, params char[] separator_chars)
	{
		if (separator_chars == null || separator_chars.Length == 0)
		{
			separator_chars = _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020;
		}
		if (string.IsNullOrEmpty(_0020) || string.IsNullOrEmpty(_0020_000A))
		{
			return -1;
		}
		if (_0020.Length < _0020_000A.Length)
		{
			return -1;
		}
		if (_0020 == _0020_000A)
		{
			return 0;
		}
		int num = 0;
		do
		{
			num = _0020.IndexOf(_0020_000A, _0020_0020);
			if (num == 0 && num + _0020_000A.Length < _0020.Length)
			{
				char[] array = separator_chars;
				foreach (char c in array)
				{
					if (_0020_000A[_0020_000A.Length - 1] == c)
					{
						return num;
					}
					if (_0020[num + _0020_000A.Length] == c)
					{
						return num;
					}
				}
			}
			if (num > 0 && num + _0020_000A.Length < _0020.Length)
			{
				bool flag = false;
				bool flag2 = false;
				char[] array = separator_chars;
				foreach (char c2 in array)
				{
					if (_0020[num - 1] == c2 || _0020_000A[0] == c2)
					{
						flag = true;
					}
					if (_0020[num + _0020_000A.Length] == c2 || _0020_000A[_0020_000A.Length - 1] == c2)
					{
						flag2 = true;
					}
					if (flag && flag2)
					{
						return num;
					}
				}
			}
			if (num > 0 && num + _0020_000A.Length == _0020.Length)
			{
				char[] array = separator_chars;
				foreach (char c3 in array)
				{
					if (_0020[num - 1] == c3 || _0020_000A[0] == c3)
					{
						return num;
					}
				}
			}
			_0020_0020 = num + 1;
		}
		while (num >= 0);
		return -1;
	}

	internal static bool _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020(string _0020, params string[] list)
	{
		foreach (string b in list)
		{
			if (_0020 == b)
			{
				return true;
			}
		}
		return false;
	}

	internal static bool _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A(string _0020, params string[] list)
	{
		foreach (string b in list)
		{
			if (string.Equals(_0020, b, StringComparison.InvariantCultureIgnoreCase))
			{
				return true;
			}
		}
		return false;
	}

	internal static bool _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_0020(string _0020, params string[] list)
	{
		foreach (string b in list)
		{
			if (_0020 == b)
			{
				return false;
			}
		}
		return true;
	}

	internal static bool _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A_0020_000A_000A(string _0020, params string[] list)
	{
		foreach (string b in list)
		{
			if (string.Equals(_0020, b, StringComparison.InvariantCultureIgnoreCase))
			{
				return false;
			}
		}
		return true;
	}

	internal static string _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A_0020_000A_0020(string _0020, int _0020_000A)
	{
		if (string.IsNullOrEmpty(_0020) || _0020.Length <= _0020_000A)
		{
			return _0020;
		}
		return _0020.Substring(0, _0020_000A) + "..";
	}

	internal static string _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A(params string[] list)
	{
		foreach (string text in list)
		{
			if (!string.IsNullOrEmpty(text))
			{
				return text;
			}
		}
		return null;
	}

	internal static string _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020(params string[] list)
	{
		foreach (string text in list)
		{
			if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(text.Replace(" ", "").Replace("\t", "").Replace("\r", "")
				.Replace("\n", "")))
			{
				return text;
			}
		}
		return null;
	}

	internal static string _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A(string _0020, string _0020_000A = null)
	{
		if (string.IsNullOrEmpty(_0020_000A))
		{
			return _0020;
		}
		StringBuilder stringBuilder = new StringBuilder();
		string[] array = (_0020 ?? string.Empty).Split('\n');
		int num = 0;
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (num == 0)
			{
				stringBuilder.Append(_0020_000A);
			}
			else
			{
				stringBuilder.Append("\n" + _0020_000A);
			}
			stringBuilder.Append(text?.Trim('\r'));
			num++;
		}
		return stringBuilder.ToString();
	}

	internal static uint toHash(params string[] str_in)
	{
		if (str_in == null || str_in.Length == 0 || (str_in.Length == 1 && string.IsNullOrEmpty(str_in[0])))
		{
			return 123u;
		}
		int num = 352654597;
		int num2 = num;
		foreach (string text in str_in)
		{
			if (string.IsNullOrEmpty(text))
			{
				continue;
			}
			int num3 = 0;
			for (int num4 = text.Length; num4 > 0; num4 -= 4)
			{
				num = ((num3 + 1 < text.Length) ? (((num << 5) + num + (num >> 27)) ^ (int)(text[num3] | ((uint)text[num3 + 1] << 16))) : ((num3 >= text.Length) ? (((num << 5) + num + (num >> 27)) ^ 0) : (((num << 5) + num + (num >> 27)) ^ text[num3])));
				if (num4 <= 2)
				{
					break;
				}
				num3 += 2;
				num2 = ((num3 + 1 >= text.Length) ? ((num3 >= text.Length) ? (((num2 << 5) + num2 + (num2 >> 27)) ^ 0) : (((num2 << 5) + num2 + (num2 >> 27)) ^ text[num3])) : (((num2 << 5) + num2 + (num2 >> 27)) ^ (int)(text[num3] | ((uint)text[num3 + 1] << 16))));
				num3 += 2;
			}
		}
		return (uint)(num + num2 * 1566083941);
	}

	internal static string _0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_000A(string _0020)
	{
		return $"{toHash(_0020):X}";
	}

	internal static string Calc(string _0020)
	{
		uint num = 0u;
		uint num2 = 0u;
		if (_0020.Length < 2)
		{
			_0020 += " ";
		}
		string text = _0020.Substring(0, _0020.Length / 2);
		string text2 = _0020.Substring(_0020.Length / 2);
		num = toHash(text);
		num2 = toHash(text2);
		return $"{num:X}{num2:X}";
	}

	internal static string _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A(string _0020)
	{
		uint num = 0u;
		uint num2 = 0u;
		uint num3 = 0u;
		uint num4 = 0u;
		if (_0020.Length < 4)
		{
			_0020 += "   ";
		}
		string text = _0020.Substring(0, _0020.Length / 4);
		string text2 = _0020.Substring(_0020.Length / 4, _0020.Length / 4);
		string text3 = _0020.Substring(_0020.Length / 4 * 2, _0020.Length / 4);
		string text4 = _0020.Substring(_0020.Length / 4 * 3, _0020.Length / 4);
		num = toHash(text);
		num2 = toHash(text2);
		num3 = toHash(text3);
		num4 = toHash(text4);
		return $"{num:x8}{num2:x8}{num3:x8}{num4:x8}";
	}

	internal static string _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_0020_0020(byte[] _0020)
	{
		if (_0020 == null)
		{
			return null;
		}
		if (_0020.Length == 0)
		{
			return string.Empty;
		}
		return Encoding.UTF8.GetString(_0020);
	}

	internal static byte[] _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A(string _0020)
	{
		if (_0020 == null)
		{
			return null;
		}
		if (_0020.Length == 0)
		{
			return new byte[0];
		}
		return Encoding.UTF8.GetBytes(_0020);
	}

	internal static uint _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020(params string[] str_in)
	{
		if (str_in == null || str_in.Length == 0 || (str_in.Length == 1 && string.IsNullOrEmpty(str_in[0])))
		{
			return 123u;
		}
		uint num = 352654597u;
		foreach (string text in str_in)
		{
			num = (num ^ _0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020._0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A(text ?? string.Empty)) + num;
			string.IsNullOrEmpty(text);
		}
		return num;
	}

	internal static string _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A(string _0020)
	{
		return $"{_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020(_0020):X}";
	}

	internal static string _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020(string _0020)
	{
		uint num = 0u;
		uint num2 = 0u;
		if (_0020.Length < 2)
		{
			_0020 += " ";
		}
		string text = _0020.Substring(0, _0020.Length / 2);
		string text2 = _0020.Substring(_0020.Length / 2);
		num = _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020(text);
		num2 = _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020(text2);
		return $"{num:X}{num2:X}";
	}

	internal static string _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A(string _0020)
	{
		uint num = 0u;
		uint num2 = 0u;
		uint num3 = 0u;
		uint num4 = 0u;
		if (_0020.Length < 4)
		{
			_0020 += "   ";
		}
		string text = _0020.Substring(0, _0020.Length / 4);
		string text2 = _0020.Substring(_0020.Length / 4, _0020.Length / 4);
		string text3 = _0020.Substring(_0020.Length / 4 * 2, _0020.Length / 4);
		string text4 = _0020.Substring(_0020.Length / 4 * 3, _0020.Length / 4);
		num = _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020(text);
		num2 = _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020(text2);
		num3 = _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020(text3);
		num4 = _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020(text4);
		return $"{num:x8}{num2:x8}{num3:x8}{num4:x8}";
	}

	private static int _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020(string _0020)
	{
		if (!_0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_000A_0020_000A.ContainsKey(_0020))
		{
			_0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_000A_0020_000A[_0020] = 1;
		}
		int num = _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_000A_0020_000A[_0020];
		_0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_000A_0020_000A[_0020] = num + 1;
		return num;
	}

	internal static string _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A(string _0020, string _0020_000A = null)
	{
		_0020_000A = (_0020_000A ?? "Name");
		if (string.IsNullOrEmpty(_0020))
		{
			return _0020_000A + "_" + _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020(_0020_000A);
		}
		if (char.IsDigit(_0020[0]))
		{
			return _0020_000A + "_" + _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020(_0020_000A);
		}
		int num = 0;
		int num2 = 0;
		char c = _0020[0];
		foreach (char c2 in _0020)
		{
			if (!char.IsDigit(c2) && (c2 < 'A' || c2 > 'Z') && (c2 < 'a' || c2 > 'z'))
			{
				switch (c2)
				{
				default:
					if (c2 < 'а' || c2 > 'я')
					{
						return _0020_000A + "_" + _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020(_0020_000A);
					}
					break;
				case '.':
				case '_':
				case 'А':
				case 'Б':
				case 'В':
				case 'Г':
				case 'Д':
				case 'Е':
				case 'Ж':
				case 'З':
				case 'И':
				case 'Й':
				case 'К':
				case 'Л':
				case 'М':
				case 'Н':
				case 'О':
				case 'П':
				case 'Р':
				case 'С':
				case 'Т':
				case 'У':
				case 'Ф':
				case 'Х':
				case 'Ц':
				case 'Ч':
				case 'Ш':
				case 'Щ':
				case 'Ъ':
				case 'Ы':
				case 'Ь':
				case 'Э':
				case 'Ю':
				case 'Я':
					break;
				}
			}
			if (char.IsDigit(c2))
			{
				num++;
			}
			if ((c >= 'A' && c <= 'Z' && ((c2 >= 'a' && c <= 'z') || char.IsDigit(c2))) || (c >= 'a' && c <= 'z' && ((c2 >= 'A' && c <= 'Z') || char.IsDigit(c2))) || (char.IsDigit(c) && !char.IsDigit(c2)))
			{
				num2++;
			}
			c = c2;
		}
		if (num > 3 || num2 > 5)
		{
			return _0020_000A + "_" + _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020(_0020_000A);
		}
		return _0020;
	}

	internal static char _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020(byte _0020)
	{
		if (_0020 <= 31 || (_0020 > 126 && _0020 < 160))
		{
			return '.';
		}
		return (char)_0020;
	}

	internal static string _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A(byte[] _0020, int _0020_000A = 0, int _0020_0020 = -1)
	{
		try
		{
			if (_0020 != null)
			{
				if (_0020_0020 == -1 || _0020_0020 > _0020.Length)
				{
					_0020_0020 = _0020.Length - _0020_000A;
				}
				using (StringWriter stringWriter = new StringWriter())
				{
					stringWriter.WriteLine("      : 00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F | 0123456789ABCDEF");
					int num = 16;
					int num2 = 0;
					int num3 = 0;
					while (num3 < (_0020_0020 + num - 1) / num)
					{
						int num4 = num2 * num;
						if (num4 >= _0020_0020)
						{
							break;
						}
						string text = num4.ToString("X6") + ": ";
						int num5 = num4;
						for (int i = 0; i < num; i++)
						{
							text = ((num5 >= _0020_0020) ? (text + "   ") : (text + _0020[_0020_000A + num5].ToString("X2") + ((i % 4 < 3) ? "-" : " ")));
							num5++;
						}
						if (text.Length > 0)
						{
							text += "| ";
						}
						int num6 = num4;
						for (int j = 0; j < num; j++)
						{
							text = ((num6 >= _0020_0020) ? (text + " ") : (text + _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020(_0020[_0020_000A + num6]).ToString()));
							num6++;
						}
						stringWriter.WriteLine(text);
						num3++;
						num2++;
					}
					return stringWriter.ToString();
				}
			}
			return null;
		}
		catch (Exception)
		{
			return null;
		}
	}

	internal static bool _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020(byte[] _0020, out string _0020_000A)
	{
		_0020_000A = null;
		int[] array = new int[256];
		for (int i = 0; i < _0020.Length; i++)
		{
			array[_0020[i]]++;
		}
		if (array[1] > 1 || array[2] > 1 || array[3] > 1)
		{
			return false;
		}
		Encoding encoding = Encoding.UTF8;
		if (array[0] > 1)
		{
			if (array[0] <= _0020.Length / 3 || array[0] >= _0020.Length + _0020.Length / 10)
			{
				return false;
			}
			encoding = Encoding.Unicode;
		}
		string @string = encoding.GetString(_0020);
		byte[] bytes = encoding.GetBytes(@string);
		if (bytes.Length != _0020.Length)
		{
			return false;
		}
		for (int j = 0; j < _0020.Length; j++)
		{
			if (bytes[j] != _0020[j])
			{
				return false;
			}
		}
		_0020_000A = @string;
		return true;
	}
}
