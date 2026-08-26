using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

internal static class FormatUtils
{
	private static string[] _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020;

	private static Random _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A = new Random((int)DateTime.Now.Ticks);

	internal static decimal _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A(decimal _0020)
	{
		return Math.Floor(_0020 * 100m) / 100m;
	}

	internal static decimal _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020(decimal _0020)
	{
		return Math.Round(_0020, 2, MidpointRounding.AwayFromZero);
	}

	internal static string _0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A_0020(decimal _0020)
	{
		return $"{_0020:### ### ### ### ##0.##}".Trim();
	}

	internal static decimal _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A_0020_000A(params decimal[] list)
	{
		foreach (decimal num in list)
		{
			if (num != decimal.Zero)
			{
				return num;
			}
		}
		return decimal.Zero;
	}

	internal static decimal _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020(params decimal[] list)
	{
		foreach (decimal num in list)
		{
			if (num > decimal.Zero)
			{
				return num;
			}
		}
		return decimal.Zero;
	}

	internal static bool _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A(object _0020, object _0020_000A)
	{
		if (_0020 == null || _0020 == DBNull.Value || _0020_000A == null || _0020_000A == DBNull.Value)
		{
			return false;
		}
		if (_0020.Equals(_0020_000A))
		{
			return true;
		}
		long num = 0L;
		long num2 = 0L;
		if (_0020 is string)
		{
			num = (long)(_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A((string)_0020) * 100m);
		}
		if (_0020 is decimal)
		{
			num = (long)((decimal)_0020 * 100m);
		}
		if (_0020 is float)
		{
			num = (long)((float)_0020 * 100f);
		}
		if (_0020 is double)
		{
			num = (long)((double)_0020 * 100.0);
		}
		if (_0020 is int)
		{
			num = (long)_0020 * 100;
		}
		if (_0020_000A is string)
		{
			num2 = (long)(_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A((string)_0020_000A) * 100m);
		}
		if (_0020_000A is decimal)
		{
			num2 = (long)((decimal)_0020_000A * 100m);
		}
		if (_0020_000A is float)
		{
			num2 = (long)((float)_0020_000A * 100f);
		}
		if (_0020_000A is double)
		{
			num2 = (long)((double)_0020_000A * 100.0);
		}
		if (_0020_000A is int)
		{
			num2 = (long)_0020_000A * 100;
		}
		return num == num2;
	}

	internal static bool _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020(object _0020)
	{
		if (_0020 == null || _0020 == DBNull.Value)
		{
			return true;
		}
		long num = 0L;
		if (_0020 is string)
		{
			num = (long)(_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A((string)_0020) * 100m);
		}
		if (_0020 is decimal)
		{
			num = (long)((decimal)_0020 * 100m);
		}
		if (_0020 is float)
		{
			num = (long)((float)_0020 * 100f);
		}
		if (_0020 is double)
		{
			num = (long)((double)_0020 * 100.0);
		}
		if (_0020 is int)
		{
			num = (long)_0020 * 100;
		}
		return num == 0;
	}

	internal static decimal _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A(string _0020)
	{
		try
		{
			_0020 = _0020.Replace(" ", "").Replace(" ", "").Replace("\t", "")
				.Replace(".", ",")
				.Replace(",", CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator);
			return decimal.Parse(_0020, NumberStyles.Any);
		}
		catch
		{
			try
			{
				return decimal.Parse(_0020.Replace(",", "."), NumberStyles.Any);
			}
			catch
			{
				try
				{
					return decimal.Parse(_0020.Replace(".", ","), NumberStyles.Any);
				}
				catch (Exception innerException)
				{
					throw new Exception("value=" + _0020, innerException);
				}
			}
		}
	}

	internal static decimal _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020(string _0020)
	{
		return _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020(_0020, decimal.Zero);
	}

	internal static decimal _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020(string _0020, decimal _0020_000A)
	{
		decimal result = default(decimal);
		if (!_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020(_0020, out result))
		{
			return _0020_000A;
		}
		return result;
	}

	internal static bool _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020(string _0020, out decimal _0020_000A)
	{
		_0020_000A = default(decimal);
		try
		{
			_0020_000A = _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A(_0020);
			return true;
		}
		catch
		{
			return false;
		}
	}

	internal static int _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A(string _0020)
	{
		return _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A(_0020, 0);
	}

	internal static bool _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A(string _0020, out int _0020_000A)
	{
		_0020_000A = 0;
		if (string.IsNullOrEmpty(_0020))
		{
			return false;
		}
		_0020 = _0020.Replace(" ", "");
		_0020 = _0020.Replace("\t", "");
		if (_0020.StartsWith("0x") || _0020.StartsWith("-0x"))
		{
			try
			{
				bool flag = _0020.StartsWith("-");
				_0020 = _0020.TrimStart('-');
				_0020 = "00000000" + _0020.Substring(2);
				_0020 = _0020.Substring(_0020.Length - 8);
				_0020_000A = BitConverter.ToInt32(formatToArr(_0020, _0020_000A: true), 0);
				if (flag)
				{
					_0020_000A = -_0020_000A;
				}
				return true;
			}
			catch
			{
			}
		}
		if (int.TryParse(_0020, out _0020_000A))
		{
			return true;
		}
		return false;
	}

	internal static int _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A(string _0020, int _0020_000A)
	{
		int result = 0;
		if (string.IsNullOrEmpty(_0020))
		{
			return _0020_000A;
		}
		_0020 = _0020.Replace(" ", "");
		_0020 = _0020.Replace("\t", "");
		if (_0020.StartsWith("0x") || _0020.StartsWith("-0x"))
		{
			try
			{
				bool flag = _0020.StartsWith("-");
				_0020 = _0020.TrimStart('-');
				_0020 = "00000000" + _0020.Substring(2);
				_0020 = _0020.Substring(_0020.Length - 8);
				result = BitConverter.ToInt32(formatToArr(_0020, _0020_000A: true), 0);
				if (flag)
				{
					result = -result;
				}
				return result;
			}
			catch
			{
			}
		}
		if (int.TryParse(_0020, out result))
		{
			return result;
		}
		return _0020_000A;
	}

	internal static long _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020(string _0020)
	{
		return _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020(_0020, 0L);
	}

	internal static bool _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020(string _0020, out long _0020_000A)
	{
		_0020_000A = 0L;
		if (string.IsNullOrEmpty(_0020))
		{
			return false;
		}
		_0020 = _0020.Replace(" ", "");
		_0020 = _0020.Replace("\t", "");
		if (_0020.StartsWith("0x") || _0020.StartsWith("-0x"))
		{
			try
			{
				bool flag = _0020.StartsWith("-");
				_0020 = _0020.TrimStart('-');
				_0020 = "0000000000000000" + _0020.Substring(2);
				_0020 = _0020.Substring(_0020.Length - 16);
				_0020_000A = BitConverter.ToInt64(formatToArr(_0020, _0020_000A: true), 0);
				if (flag)
				{
					_0020_000A = -_0020_000A;
				}
				return true;
			}
			catch
			{
			}
		}
		if (long.TryParse(_0020, out _0020_000A))
		{
			return true;
		}
		return false;
	}

	internal static long _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020(string _0020, long _0020_000A)
	{
		long result = 0L;
		if (string.IsNullOrEmpty(_0020))
		{
			return _0020_000A;
		}
		_0020 = _0020.Replace(" ", "");
		_0020 = _0020.Replace("\t", "");
		if (_0020.StartsWith("0x") || _0020.StartsWith("-0x"))
		{
			try
			{
				bool flag = _0020.StartsWith("-");
				_0020 = _0020.TrimStart('-');
				_0020 = "0000000000000000" + _0020.Substring(2);
				_0020 = _0020.Substring(_0020.Length - 16);
				result = BitConverter.ToInt64(formatToArr(_0020, _0020_000A: true), 0);
				if (flag)
				{
					result = -result;
				}
				return result;
			}
			catch
			{
			}
		}
		if (long.TryParse(_0020, out result))
		{
			return result;
		}
		return _0020_000A;
	}

	internal static bool _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A(string _0020)
	{
		return _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A(_0020, _0020_000A: false);
	}

	internal static bool _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A(string _0020, out bool _0020_000A)
	{
		_0020_000A = false;
		if (string.IsNullOrEmpty(_0020))
		{
			return false;
		}
		_0020 = _0020.ToLower();
		switch (_0020)
		{
		case "1":
		case "true":
		case "on":
		case "set":
		case "enable":
			_0020_000A = true;
			return true;
		case "0":
		case "false":
		case "off":
		case "reset":
		case "disable":
			_0020_000A = false;
			return true;
		default:
			return false;
		}
	}

	internal static bool _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A(string _0020, bool _0020_000A)
	{
		bool result = false;
		if (string.IsNullOrEmpty(_0020))
		{
			return _0020_000A;
		}
		if (_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A(_0020, out result))
		{
			return result;
		}
		return _0020_000A;
	}

	internal static bool _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020(int _0020, int _0020_000A)
	{
		if ((_0020 & (1 << _0020_000A)) != 0)
		{
			return true;
		}
		return false;
	}

	internal static bool _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020(long _0020, int _0020_000A)
	{
		if ((_0020 & (1L << _0020_000A)) != 0L)
		{
			return true;
		}
		return false;
	}

	internal static int _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A(int _0020, int _0020_000A, bool _0020_0020)
	{
		_0020 &= ~(1 << _0020_000A);
		if (_0020_0020)
		{
			_0020 |= 1 << _0020_000A;
		}
		return _0020;
	}

	internal static long _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A(long _0020, int _0020_000A, bool _0020_0020)
	{
		_0020 &= ~(1L << _0020_000A);
		if (_0020_0020)
		{
			_0020 |= 1L << _0020_000A;
		}
		return _0020;
	}

	internal static bool _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020(byte[] _0020, byte[] _0020_000A)
	{
		if (_0020 == null || _0020_000A == null || _0020.Length < _0020_000A.Length)
		{
			return false;
		}
		for (int i = 0; i < _0020_000A.Length; i++)
		{
			if (_0020[i] != _0020_000A[i])
			{
				return false;
			}
		}
		return true;
	}

	internal static bool _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A_0020(byte[] _0020, byte[] _0020_000A)
	{
		if (_0020 == null || _0020_000A == null || _0020.Length != _0020_000A.Length)
		{
			return false;
		}
		for (int i = 0; i < _0020_000A.Length; i++)
		{
			if (_0020[i] != _0020_000A[i])
			{
				return false;
			}
		}
		return true;
	}

	internal static byte[] _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A(byte[] _0020, byte[] _0020_000A)
	{
		byte[] array = new byte[_0020.Length + _0020_000A.Length];
		int num = 0;
		for (int i = 0; i < _0020.Length; i++)
		{
			array[num] = _0020[i];
			num++;
		}
		for (int j = 0; j < _0020_000A.Length; j++)
		{
			array[num] = _0020_000A[j];
			num++;
		}
		return array;
	}

	internal static byte[] _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020(byte[] _0020, int _0020_000A)
	{
		return _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020(_0020, _0020_000A, _0020.Length - _0020_000A);
	}

	internal static byte[] _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020(byte[] _0020, int _0020_000A, int _0020_0020)
	{
		byte[] array = new byte[_0020_0020];
		if (_0020_0020 < 0)
		{
			_0020_0020 = _0020.Length - _0020_000A;
		}
		for (int i = 0; i < _0020_0020; i++)
		{
			array[i] = _0020[i + _0020_000A];
		}
		return array;
	}

	internal static int _0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020(byte[] _0020, byte[] _0020_000A, int _0020_0020 = 0, int _0020_000A_000A = -1)
	{
		if (_0020 == null || _0020_000A == null)
		{
			return -1;
		}
		if (_0020_0020 + _0020_000A.Length >= _0020.Length)
		{
			return -1;
		}
		if (_0020_0020 < 0)
		{
			_0020_0020 = 0;
		}
		for (int i = _0020_0020; i < _0020.Length - _0020_000A.Length && (_0020_000A_000A <= 0 || i <= _0020_000A_000A); i++)
		{
			bool flag = true;
			for (int j = 0; j < _0020_000A.Length; j++)
			{
				if (_0020_000A[j] != _0020[i + j])
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				return i;
			}
		}
		return -1;
	}

	public static byte[] Revert(byte[] buff)
	{
		if (buff == null)
		{
			return null;
		}
		if (buff.Length == 0)
		{
			return new byte[0];
		}
		byte[] array = new byte[buff.Length];
		for (int i = 0; i < buff.Length; i++)
		{
			array[buff.Length - i - 1] = buff[i];
		}
		return array;
	}

	internal static string _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A(byte[] _0020, bool _0020_000A = false, int _0020_0020 = 4, int _0020_000A_000A = 0, int _0020_000A_0020 = -1)
	{
		if (_0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020 == null)
		{
			_0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020 = new string[256];
			for (int i = 0; i < 256; i++)
			{
				_0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020[i] = $"{i:X2}";
			}
		}
		StringBuilder stringBuilder = new StringBuilder(_0020.Length * 2);
		_0020_000A_0020 = ((_0020_000A_0020 >= 0) ? Math.Min(_0020_000A_0020, _0020.Length - _0020_000A_000A) : (_0020.Length - _0020_000A_000A));
		for (int j = _0020_000A_000A; j < _0020_000A_0020; j++)
		{
			stringBuilder.Append(_0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020[_0020[j]]);
		}
		string text = stringBuilder.ToString();
		if (_0020_000A)
		{
			string text2 = text;
			string text3 = "";
			for (int k = 0; k < text.Length; k += _0020_0020)
			{
				if (!string.IsNullOrEmpty(text3))
				{
					text3 += "-";
				}
				text3 += text2.Substring(0, Math.Min(_0020_0020, text2.Length));
				text2 = text2.Remove(0, Math.Min(_0020_0020, text2.Length));
			}
			if (text2.Length > 0)
			{
				text3 += text2.Substring(0, Math.Min(4, text2.Length));
				text2 = text2.Remove(0, Math.Min(_0020_0020, text2.Length));
			}
			text = text3;
		}
		return text;
	}

	internal static byte[] formatToArr(string _0020, bool _0020_000A = false)
	{
		if (_0020 == null)
		{
			return null;
		}
		if (_0020.Contains("-"))
		{
			_0020 = _0020.Replace("-", "").Trim();
		}
		if (_0020.Contains(" "))
		{
			_0020 = _0020.Replace(" ", "").Trim();
		}
		if (_0020.Contains("\t"))
		{
			_0020 = _0020.Replace("\t", "").Trim();
		}
		if ((_0020.Length & 1) != 0)
		{
			return null;
		}
		byte[] array = new byte[_0020.Length / 2];
		for (int i = 0; i < _0020.Length; i += 2)
		{
			if (!byte.TryParse(_0020.Substring(i, 2), NumberStyles.HexNumber, null, out byte result))
			{
				return null;
			}
			if (_0020_000A)
			{
				array[array.Length - 1 - i / 2] = result;
			}
			else
			{
				array[i / 2] = result;
			}
		}
		return array;
	}

	internal static int _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A(int _0020 = int.MaxValue)
	{
		return _0020_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A.Next(_0020);
	}

	internal static float _0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_000A(object _0020)
	{
		if (_0020 == null)
		{
			return 0f;
		}
		if (_0020 is float)
		{
			return (float)_0020;
		}
		if (_0020 is double)
		{
			return (float)(double)_0020;
		}
		if (_0020 is decimal)
		{
			return (float)(decimal)_0020;
		}
		if (_0020 is long)
		{
			return (long)_0020;
		}
		if (_0020 is ulong)
		{
			return (float)(double)(ulong)_0020;
		}
		if (_0020 is int)
		{
			return (int)_0020;
		}
		if (_0020 is uint)
		{
			return (float)(double)(uint)_0020;
		}
		if (_0020 is byte)
		{
			return (int)(byte)_0020;
		}
		if (_0020 is sbyte)
		{
			return (sbyte)_0020;
		}
		if (_0020 is short)
		{
			return (short)_0020;
		}
		if (_0020 is ushort)
		{
			return (int)(ushort)_0020;
		}
		if (_0020 is char)
		{
			return (int)(char)_0020;
		}
		if (_0020 is bool)
		{
			return ((bool)_0020) ? 1 : 0;
		}
		if (_0020 is string)
		{
			return (float)_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020((string)_0020);
		}
		return (float)_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020(_0020.ToString());
	}

	internal static double _0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020(object _0020)
	{
		if (_0020 == null)
		{
			return 0.0;
		}
		if (_0020 is float)
		{
			return (float)_0020;
		}
		if (_0020 is double)
		{
			return (double)_0020;
		}
		if (_0020 is decimal)
		{
			return (double)(decimal)_0020;
		}
		if (_0020 is long)
		{
			return (long)_0020;
		}
		if (_0020 is ulong)
		{
			return (ulong)_0020;
		}
		if (_0020 is int)
		{
			return (int)_0020;
		}
		if (_0020 is uint)
		{
			return (uint)_0020;
		}
		if (_0020 is byte)
		{
			return (int)(byte)_0020;
		}
		if (_0020 is sbyte)
		{
			return (sbyte)_0020;
		}
		if (_0020 is short)
		{
			return (short)_0020;
		}
		if (_0020 is ushort)
		{
			return (int)(ushort)_0020;
		}
		if (_0020 is char)
		{
			return (int)(char)_0020;
		}
		if (_0020 is bool)
		{
			return ((bool)_0020) ? 1 : 0;
		}
		if (_0020 is string)
		{
			return (double)_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020((string)_0020);
		}
		return (double)_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020(_0020.ToString());
	}

	internal static decimal _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020(object _0020)
	{
		if (_0020 == null)
		{
			return decimal.Zero;
		}
		if (_0020 is float)
		{
			return (decimal)(float)_0020;
		}
		if (_0020 is double)
		{
			return (decimal)(double)_0020;
		}
		if (_0020 is decimal)
		{
			return (decimal)_0020;
		}
		if (_0020 is ulong)
		{
			return (ulong)_0020;
		}
		if (_0020 is long)
		{
			return (long)_0020;
		}
		if (_0020 is int)
		{
			return (int)_0020;
		}
		if (_0020 is uint)
		{
			return (uint)_0020;
		}
		if (_0020 is byte)
		{
			return (byte)_0020;
		}
		if (_0020 is sbyte)
		{
			return (sbyte)_0020;
		}
		if (_0020 is short)
		{
			return (short)_0020;
		}
		if (_0020 is ushort)
		{
			return (ushort)_0020;
		}
		if (_0020 is char)
		{
			return (char)_0020;
		}
		if (_0020 is bool)
		{
			return ((bool)_0020) ? 1 : 0;
		}
		if (_0020 is string)
		{
			return _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020((string)_0020);
		}
		return _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020(_0020.ToString());
	}

	internal static long _0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A(object _0020)
	{
		if (_0020 == null)
		{
			return 0L;
		}
		if (_0020 is long)
		{
			return (long)_0020;
		}
		if (_0020 is ulong)
		{
			return (long)(ulong)_0020;
		}
		if (_0020 is int)
		{
			return (int)_0020;
		}
		if (_0020 is uint)
		{
			return (uint)_0020;
		}
		if (_0020 is float)
		{
			return (long)(float)_0020;
		}
		if (_0020 is double)
		{
			return (long)(double)_0020;
		}
		if (_0020 is decimal)
		{
			return (long)(decimal)_0020;
		}
		if (_0020 is byte)
		{
			return (byte)_0020;
		}
		if (_0020 is sbyte)
		{
			return (sbyte)_0020;
		}
		if (_0020 is short)
		{
			return (short)_0020;
		}
		if (_0020 is ushort)
		{
			return (ushort)_0020;
		}
		if (_0020 is char)
		{
			return (char)_0020;
		}
		if (_0020 is bool)
		{
			return ((bool)_0020) ? 1 : 0;
		}
		if (_0020 is string)
		{
			return _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020((string)_0020);
		}
		return _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020(_0020.ToString());
	}

	internal static ulong _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A(object _0020)
	{
		if (_0020 == null)
		{
			return 0uL;
		}
		if (_0020 is string)
		{
			return (ulong)_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020((string)_0020);
		}
		if (_0020 is long)
		{
			return (ulong)(long)_0020;
		}
		if (_0020 is ulong)
		{
			return (ulong)_0020;
		}
		if (_0020 is int)
		{
			return (ulong)(int)_0020;
		}
		if (_0020 is uint)
		{
			return (uint)_0020;
		}
		if (_0020 is float)
		{
			return (ulong)(float)_0020;
		}
		if (_0020 is double)
		{
			return (ulong)(double)_0020;
		}
		if (_0020 is decimal)
		{
			return (ulong)(decimal)_0020;
		}
		if (_0020 is byte)
		{
			return (byte)_0020;
		}
		if (_0020 is sbyte)
		{
			return (ulong)(sbyte)_0020;
		}
		if (_0020 is short)
		{
			return (ulong)(short)_0020;
		}
		if (_0020 is ushort)
		{
			return (ushort)_0020;
		}
		if (_0020 is char)
		{
			return (char)_0020;
		}
		if (_0020 is bool)
		{
			return (ulong)(((bool)_0020) ? 1 : 0);
		}
		return (ulong)_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020(_0020.ToString());
	}

	internal static int _0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020(object _0020)
	{
		if (_0020 == null)
		{
			return 0;
		}
		if (_0020 is int)
		{
			return (int)_0020;
		}
		if (_0020 is uint)
		{
			return (int)(uint)_0020;
		}
		if (_0020 is string)
		{
			return _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A((string)_0020);
		}
		if (_0020 is ulong)
		{
			return (int)(ulong)_0020;
		}
		if (_0020 is long)
		{
			return (int)(long)_0020;
		}
		if (_0020 is float)
		{
			return (int)(float)_0020;
		}
		if (_0020 is double)
		{
			return (int)(double)_0020;
		}
		if (_0020 is decimal)
		{
			return (int)(decimal)_0020;
		}
		if (_0020 is byte)
		{
			return (byte)_0020;
		}
		if (_0020 is sbyte)
		{
			return (sbyte)_0020;
		}
		if (_0020 is short)
		{
			return (short)_0020;
		}
		if (_0020 is ushort)
		{
			return (ushort)_0020;
		}
		if (_0020 is char)
		{
			return (char)_0020;
		}
		if (_0020 is bool)
		{
			if (!(bool)_0020)
			{
				return 0;
			}
			return 1;
		}
		return _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A(_0020.ToString());
	}

	internal static uint _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020(object _0020)
	{
		if (_0020 == null)
		{
			return 0u;
		}
		if (_0020 is int)
		{
			return (uint)(int)_0020;
		}
		if (_0020 is uint)
		{
			return (uint)_0020;
		}
		if (_0020 is string)
		{
			return (uint)_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A((string)_0020);
		}
		if (_0020 is ulong)
		{
			return (uint)(ulong)_0020;
		}
		if (_0020 is long)
		{
			return (uint)(long)_0020;
		}
		if (_0020 is float)
		{
			return (uint)(float)_0020;
		}
		if (_0020 is double)
		{
			return (uint)(double)_0020;
		}
		if (_0020 is decimal)
		{
			return (uint)(decimal)_0020;
		}
		if (_0020 is byte)
		{
			return (byte)_0020;
		}
		if (_0020 is sbyte)
		{
			return (uint)(sbyte)_0020;
		}
		if (_0020 is short)
		{
			return (uint)(short)_0020;
		}
		if (_0020 is ushort)
		{
			return (ushort)_0020;
		}
		if (_0020 is char)
		{
			return (char)_0020;
		}
		if (_0020 is bool)
		{
			if (!(bool)_0020)
			{
				return 0u;
			}
			return 1u;
		}
		return (uint)_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A(_0020.ToString());
	}

	internal static short _0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_0020(object _0020)
	{
		if (_0020 == null)
		{
			return 0;
		}
		if (_0020 is short)
		{
			return (short)_0020;
		}
		if (_0020 is ushort)
		{
			return (short)(ushort)_0020;
		}
		if (_0020 is string)
		{
			return (short)_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A((string)_0020);
		}
		if (_0020 is long)
		{
			return (short)(long)_0020;
		}
		if (_0020 is ulong)
		{
			return (short)(ulong)_0020;
		}
		if (_0020 is int)
		{
			return (short)(int)_0020;
		}
		if (_0020 is uint)
		{
			return (short)(uint)_0020;
		}
		if (_0020 is float)
		{
			return (short)(float)_0020;
		}
		if (_0020 is double)
		{
			return (short)(double)_0020;
		}
		if (_0020 is decimal)
		{
			return (short)(decimal)_0020;
		}
		if (_0020 is byte)
		{
			return (byte)_0020;
		}
		if (_0020 is sbyte)
		{
			return (sbyte)_0020;
		}
		if (_0020 is char)
		{
			return (short)(char)_0020;
		}
		if (_0020 is bool)
		{
			return (short)(((bool)_0020) ? 1 : 0);
		}
		return (short)_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A(_0020.ToString());
	}

	internal static ushort _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A(object _0020)
	{
		if (_0020 == null)
		{
			return 0;
		}
		if (_0020 is string)
		{
			return (ushort)_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A((string)_0020);
		}
		if (_0020 is long)
		{
			return (ushort)(long)_0020;
		}
		if (_0020 is ulong)
		{
			return (ushort)(ulong)_0020;
		}
		if (_0020 is int)
		{
			return (ushort)(int)_0020;
		}
		if (_0020 is uint)
		{
			return (ushort)(uint)_0020;
		}
		if (_0020 is float)
		{
			return (ushort)(float)_0020;
		}
		if (_0020 is double)
		{
			return (ushort)(double)_0020;
		}
		if (_0020 is decimal)
		{
			return (ushort)(decimal)_0020;
		}
		if (_0020 is byte)
		{
			return (byte)_0020;
		}
		if (_0020 is sbyte)
		{
			return (ushort)(sbyte)_0020;
		}
		if (_0020 is short)
		{
			return (ushort)(short)_0020;
		}
		if (_0020 is ushort)
		{
			return (ushort)_0020;
		}
		if (_0020 is char)
		{
			return (char)_0020;
		}
		if (_0020 is bool)
		{
			return (ushort)(((bool)_0020) ? 1 : 0);
		}
		return (ushort)_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A(_0020.ToString());
	}

	internal static byte _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020(object _0020)
	{
		if (_0020 == null)
		{
			return 0;
		}
		if (_0020 is string)
		{
			return (byte)_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A((string)_0020);
		}
		if (_0020 is long)
		{
			return (byte)(long)_0020;
		}
		if (_0020 is ulong)
		{
			return (byte)(ulong)_0020;
		}
		if (_0020 is int)
		{
			return (byte)(int)_0020;
		}
		if (_0020 is uint)
		{
			return (byte)(uint)_0020;
		}
		if (_0020 is float)
		{
			return (byte)(float)_0020;
		}
		if (_0020 is double)
		{
			return (byte)(double)_0020;
		}
		if (_0020 is decimal)
		{
			return (byte)(decimal)_0020;
		}
		if (_0020 is byte)
		{
			return (byte)_0020;
		}
		if (_0020 is sbyte)
		{
			return (byte)(sbyte)_0020;
		}
		if (_0020 is short)
		{
			return (byte)(short)_0020;
		}
		if (_0020 is ushort)
		{
			return (byte)(ushort)_0020;
		}
		if (_0020 is char)
		{
			return (byte)(char)_0020;
		}
		if (_0020 is bool)
		{
			return (byte)(((bool)_0020) ? 1 : 0);
		}
		return (byte)_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A(_0020.ToString());
	}

	internal static bool _0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_000A_000A_0020_000A(object _0020)
	{
		if (_0020 == null)
		{
			return false;
		}
		if (_0020 is string)
		{
			if (!((string)_0020 == "1") && !((string)_0020 == "True"))
			{
				return (string)_0020 == "true";
			}
			return true;
		}
		if (_0020 is long)
		{
			return (int)(long)_0020 != 0;
		}
		if (_0020 is ulong)
		{
			return (int)(ulong)_0020 != 0;
		}
		if (_0020 is int)
		{
			return (int)_0020 != 0;
		}
		if (_0020 is uint)
		{
			return (uint)_0020 != 0;
		}
		if (_0020 is float)
		{
			return (int)(float)_0020 >= 1;
		}
		if (_0020 is double)
		{
			return (int)(double)_0020 >= 1;
		}
		if (_0020 is decimal)
		{
			return (int)(decimal)_0020 >= 1;
		}
		if (_0020 is byte)
		{
			return (byte)_0020 != 0;
		}
		if (_0020 is sbyte)
		{
			return (sbyte)_0020 != 0;
		}
		if (_0020 is short)
		{
			return (short)_0020 != 0;
		}
		if (_0020 is ushort)
		{
			return (ushort)_0020 != 0;
		}
		if (_0020 is char)
		{
			return (char)_0020 != '\0';
		}
		if (_0020 is bool)
		{
			return (bool)_0020;
		}
		Array array;
		if ((array = (_0020 as Array)) != null)
		{
			if (array != null)
			{
				return array.Length > 0;
			}
			return false;
		}
		List<object> list;
		if ((list = (_0020 as List<object>)) != null)
		{
			if (list != null)
			{
				return list.Count > 0;
			}
			return false;
		}
		string a = _0020.ToString();
		if (!(a == "1") && !(a == "True"))
		{
			return a == "true";
		}
		return true;
	}

	internal static char _0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020(object _0020)
	{
		if (_0020 == null)
		{
			return '\0';
		}
		if (_0020 is string)
		{
			if (((string)_0020).Length <= 0)
			{
				return '\0';
			}
			return ((string)_0020)[0];
		}
		if (_0020 is long)
		{
			return (char)(long)_0020;
		}
		if (_0020 is ulong)
		{
			return (char)(ulong)_0020;
		}
		if (_0020 is int)
		{
			return (char)(int)_0020;
		}
		if (_0020 is uint)
		{
			return (char)(uint)_0020;
		}
		if (_0020 is float)
		{
			return (char)(float)_0020;
		}
		if (_0020 is double)
		{
			return (char)(double)_0020;
		}
		if (_0020 is decimal)
		{
			return (char)(decimal)_0020;
		}
		if (_0020 is byte)
		{
			return (char)(byte)_0020;
		}
		if (_0020 is sbyte)
		{
			return (char)(sbyte)_0020;
		}
		if (_0020 is short)
		{
			return (char)(short)_0020;
		}
		if (_0020 is ushort)
		{
			return (char)(ushort)_0020;
		}
		if (_0020 is char)
		{
			return (char)_0020;
		}
		if (_0020 is bool)
		{
			return (char)(((bool)_0020) ? 1 : 0);
		}
		return char.Parse(_0020.ToString());
	}
}
