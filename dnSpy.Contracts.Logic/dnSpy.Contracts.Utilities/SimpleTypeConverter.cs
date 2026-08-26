#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using dnSpy.Contracts.Properties;

namespace dnSpy.Contracts.Utilities;

public static class SimpleTypeConverter
{
	private delegate T ParseListCallBack<T, U>(U data, string s, ref int index, out string error);

	private const string digitSeparator = "_";

	private static readonly HashSet<long> decimalInt64;

	private static readonly HashSet<ulong> decimalUInt64;

	public static byte[] ParseByteArray(string s, out string error)
	{
		s = s.Replace(" ", string.Empty);
		s = s.Replace("\t", string.Empty);
		s = s.Replace("\r", string.Empty);
		s = s.Replace("\n", string.Empty);
		s = s.Replace("\u0085", string.Empty);
		s = s.Replace("\u2028", string.Empty);
		s = s.Replace("\u2029", string.Empty);
		if (s.Length % 2 != 0)
		{
			error = dnSpy_Contracts_Logic_Resources.InvalidHexStringSize;
			return null;
		}
		byte[] array = new byte[s.Length / 2];
		for (int i = 0; i < s.Length; i += 2)
		{
			int num = TryParseHexChar(s[i]);
			int num2 = TryParseHexChar(s[i + 1]);
			if (num < 0 || num2 < 0)
			{
				error = dnSpy_Contracts_Logic_Resources.InvalidHexCharacter;
				return null;
			}
			array[i / 2] = (byte)((num << 4) | num2);
		}
		error = null;
		return array;
	}

	private static int TryParseHexChar(char c)
	{
		if ('0' <= c && c <= '9')
		{
			return c - 48;
		}
		if ('a' <= c && c <= 'f')
		{
			return c - 97 + 10;
		}
		if ('A' <= c && c <= 'F')
		{
			return c - 65 + 10;
		}
		return -1;
	}

	public static string ByteArrayToString(IList<byte> value, bool upper = true)
	{
		if (value == null)
		{
			return string.Empty;
		}
		char[] array = new char[value.Count * 2];
		int i = 0;
		int num = 0;
		for (; i < value.Count; i++)
		{
			byte b = value[i];
			array[num++] = ToHexChar(b >> 4, upper);
			array[num++] = ToHexChar(b & 0xF, upper);
		}
		return new string(array);
	}

	static SimpleTypeConverter()
	{
		decimalInt64 = new HashSet<long>();
		decimalUInt64 = new HashSet<ulong>();
		for (ulong num = 0uL; num <= 20; num++)
		{
			AddNumber(num);
		}
		ulong num2 = 10uL;
		while (true)
		{
			AddNumber(num2 - 1);
			AddNumber(num2);
			AddNumber(num2 + 1);
			ulong num3 = num2 * 10;
			if (num3 < num2)
			{
				break;
			}
			num2 = num3;
		}
	}

	private static void AddNumber(ulong n)
	{
		decimalUInt64.Add(n);
		if (n <= long.MaxValue)
		{
			decimalInt64.Add((long)n);
		}
		if (n <= 9223372036854775808uL)
		{
			decimalInt64.Add((long)(0L - n));
		}
	}

	private static char ToHexChar(int val, bool upper)
	{
		if (0 <= val && val <= 9)
		{
			return (char)(val + 48);
		}
		return (char)(val - 10 + (upper ? 65 : 97));
	}

	public static string ToString(ulong value, ulong min, ulong max, bool? useDecimal)
	{
		if (!useDecimal.HasValue)
		{
			if (decimalUInt64.Contains(value))
			{
				return value.ToString();
			}
		}
		else
		{
			if (useDecimal.Value)
			{
				return value.ToString();
			}
			if (value <= 9)
			{
				return value.ToString();
			}
		}
		return $"0x{value:X}";
	}

	public static string ToString(long value, long min, long max, bool? useDecimal)
	{
		if (!useDecimal.HasValue)
		{
			if (decimalInt64.Contains(value))
			{
				return value.ToString();
			}
		}
		else
		{
			if (useDecimal.Value)
			{
				return value.ToString();
			}
			if (-9 <= value && value <= 9)
			{
				return value.ToString();
			}
		}
		if (value < 0)
		{
			return $"-0x{-value:X}";
		}
		return $"0x{value:X}";
	}

	public static string ToString(long value)
	{
		return ToString(value, long.MinValue, long.MaxValue, false);
	}

	public static string ToString(ulong value)
	{
		return ToString(value, 0uL, ulong.MaxValue, false);
	}

	public static string ToString(float value)
	{
		return value.ToString("R");
	}

	public static string ToString(double value)
	{
		return value.ToString("R");
	}

	public static string ToString(decimal value)
	{
		return value.ToString();
	}

	public static string ToString(DateTime value)
	{
		return value.ToString();
	}

	public static string ToString(TimeSpan value)
	{
		return value.ToString();
	}

	public static string ToString(bool value)
	{
		return value.ToString();
	}

	public static string ToString(char value)
	{
		StringBuilder stringBuilder = new StringBuilder(8);
		stringBuilder.Append('\'');
		switch (value)
		{
		case '\a':
			stringBuilder.Append("\\a");
			break;
		case '\b':
			stringBuilder.Append("\\b");
			break;
		case '\f':
			stringBuilder.Append("\\f");
			break;
		case '\n':
			stringBuilder.Append("\\n");
			break;
		case '\r':
			stringBuilder.Append("\\r");
			break;
		case '\t':
			stringBuilder.Append("\\t");
			break;
		case '\v':
			stringBuilder.Append("\\v");
			break;
		case '\\':
			stringBuilder.Append("\\\\");
			break;
		case '\0':
			stringBuilder.Append("\\0");
			break;
		case '\'':
			stringBuilder.Append("\\'");
			break;
		default:
			if (char.IsControl(value))
			{
				stringBuilder.Append($"\\u{(ushort)value:X4}");
			}
			else
			{
				stringBuilder.Append(value);
			}
			break;
		}
		stringBuilder.Append('\'');
		return stringBuilder.ToString();
	}

	public static string ToString(string s, bool canHaveNull)
	{
		if (s == null)
		{
			return canHaveNull ? "null" : string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder(s.Length + 10);
		stringBuilder.Append('"');
		foreach (char c in s)
		{
			switch (c)
			{
			case '\a':
				stringBuilder.Append("\\a");
				continue;
			case '\b':
				stringBuilder.Append("\\b");
				continue;
			case '\f':
				stringBuilder.Append("\\f");
				continue;
			case '\n':
				stringBuilder.Append("\\n");
				continue;
			case '\r':
				stringBuilder.Append("\\r");
				continue;
			case '\t':
				stringBuilder.Append("\\t");
				continue;
			case '\v':
				stringBuilder.Append("\\v");
				continue;
			case '\\':
				stringBuilder.Append("\\\\");
				continue;
			case '\0':
				stringBuilder.Append("\\0");
				continue;
			case '"':
				stringBuilder.Append("\\\"");
				continue;
			}
			if (char.IsControl(c))
			{
				stringBuilder.Append($"\\u{(ushort)c:X4}");
			}
			else
			{
				stringBuilder.Append(c);
			}
		}
		stringBuilder.Append('"');
		return stringBuilder.ToString();
	}

	private static string TryParseUnsigned(string s, ulong min, ulong max, out ulong value)
	{
		value = 0uL;
		s = s.Trim();
		s = s.Replace("_", string.Empty);
		bool flag;
		if (s.StartsWith("0x", StringComparison.OrdinalIgnoreCase) || s.StartsWith("&H", StringComparison.OrdinalIgnoreCase))
		{
			string text = s.Substring(2);
			flag = text.Trim() == text && ulong.TryParse(text, NumberStyles.HexNumber, null, out value);
		}
		else
		{
			flag = ulong.TryParse(s, NumberStyles.Integer, null, out value);
		}
		if (!flag)
		{
			if (s.StartsWith("-"))
			{
				return dnSpy_Contracts_Logic_Resources.InvalidUnsignedInteger1;
			}
			return dnSpy_Contracts_Logic_Resources.InvalidUnsignedInteger2;
		}
		if (value < min || value > max)
		{
			if (min == 0)
			{
				return string.Format(dnSpy_Contracts_Logic_Resources.InvalidUnsignedInteger3, min, max);
			}
			return string.Format(dnSpy_Contracts_Logic_Resources.InvalidUnsignedInteger4, min, max);
		}
		return null;
	}

	private static ulong ParseUnsigned(string s, ulong min, ulong max, out string error)
	{
		error = TryParseUnsigned(s, min, max, out var value);
		if (error != null)
		{
			return 0uL;
		}
		return value;
	}

	public static float ParseSingle(string s, out string error)
	{
		if (float.TryParse(s, out var result))
		{
			error = null;
			return result;
		}
		error = dnSpy_Contracts_Logic_Resources.InvalidSingle;
		return 0f;
	}

	public static double ParseDouble(string s, out string error)
	{
		if (double.TryParse(s, out var result))
		{
			error = null;
			return result;
		}
		error = dnSpy_Contracts_Logic_Resources.InvalidDouble;
		return 0.0;
	}

	public static decimal ParseDecimal(string s, out string error)
	{
		if (decimal.TryParse(s, out var result))
		{
			error = null;
			return result;
		}
		error = dnSpy_Contracts_Logic_Resources.InvalidDecimal;
		return 0m;
	}

	public static DateTime ParseDateTime(string s, out string error)
	{
		if (DateTime.TryParse(s, out var result))
		{
			error = null;
			return result;
		}
		error = dnSpy_Contracts_Logic_Resources.InvalidDateTime;
		return DateTime.MinValue;
	}

	public static TimeSpan ParseTimeSpan(string s, out string error)
	{
		if (TimeSpan.TryParse(s, out var result))
		{
			error = null;
			return result;
		}
		error = dnSpy_Contracts_Logic_Resources.InvalidTimeSpan;
		return TimeSpan.Zero;
	}

	public static bool ParseBoolean(string s, out string error)
	{
		if (bool.TryParse(s, out var result))
		{
			error = null;
			return result;
		}
		error = dnSpy_Contracts_Logic_Resources.InvalidBoolean;
		return false;
	}

	public static char ParseChar(string s, out string error)
	{
		int index = 0;
		char result = ParseChar(s, ref index, out error);
		if (error != null)
		{
			return '\0';
		}
		SkipSpaces(s, ref index);
		if (index != s.Length)
		{
			return SetParseCharError(out error);
		}
		return result;
	}

	private static char SetParseCharError(out string error)
	{
		error = dnSpy_Contracts_Logic_Resources.InvalidChar;
		return '\0';
	}

	private static char ParseChar(string s, ref int index, out string error)
	{
		SkipSpaces(s, ref index);
		if (index >= s.Length || s[index] != '\'')
		{
			return SetParseCharError(out error);
		}
		index++;
		if (index >= s.Length)
		{
			return SetParseCharError(out error);
		}
		char c = s[index++];
		if (c == '\\')
		{
			if (index >= s.Length)
			{
				return SetParseCharError(out error);
			}
			c = s[index++];
			switch (c)
			{
			case 'a':
				c = '\a';
				break;
			case 'b':
				c = '\b';
				break;
			case 'f':
				c = '\f';
				break;
			case 'n':
				c = '\n';
				break;
			case 'r':
				c = '\r';
				break;
			case 't':
				c = '\t';
				break;
			case 'v':
				c = '\v';
				break;
			case '\\':
				c = '\\';
				break;
			case '0':
				c = '\0';
				break;
			case '"':
				c = '"';
				break;
			case '\'':
				c = '\'';
				break;
			case 'u':
			case 'x':
			{
				if (index >= s.Length)
				{
					return SetParseCharError(out error);
				}
				int num = ParseHex(s, ref index, (c == 'x') ? (-1) : 4, out var _);
				if (num < 0)
				{
					return SetParseCharError(out error);
				}
				c = (char)num;
				break;
			}
			default:
				error = string.Format(dnSpy_Contracts_Logic_Resources.InvalidEscapeSequence, c);
				return '\0';
			}
		}
		if (index >= s.Length)
		{
			return SetParseCharError(out error);
		}
		if (s[index] != '\'')
		{
			return SetParseCharError(out error);
		}
		index++;
		error = null;
		return c;
	}

	public static string ParseString(string s, bool canHaveNull, out string error)
	{
		int index = 0;
		string result = ParseString(s, canHaveNull, ref index, out error);
		if (error != null)
		{
			return null;
		}
		SkipSpaces(s, ref index);
		if (index != s.Length)
		{
			return SetParseStringError(canHaveNull, out error);
		}
		return result;
	}

	private static string SetParseStringError(bool canHaveNull, out string error)
	{
		error = (canHaveNull ? dnSpy_Contracts_Logic_Resources.InvalidString1 : dnSpy_Contracts_Logic_Resources.InvalidString2);
		return null;
	}

	private static string ParseString(string s, bool canHaveNull, ref int index, out string error)
	{
		SkipSpaces(s, ref index);
		if (canHaveNull && s.Substring(index).StartsWith("null"))
		{
			index += 4;
			error = null;
			return null;
		}
		if (index + 2 > s.Length || s[index] != '"')
		{
			return SetParseStringError(canHaveNull, out error);
		}
		StringBuilder stringBuilder = new StringBuilder(s.Length - index - 2);
		while (true)
		{
			index++;
			if (index >= s.Length)
			{
				break;
			}
			char c = s[index];
			switch (c)
			{
			case '"':
				index++;
				error = null;
				return stringBuilder.ToString();
			case '\\':
				index++;
				if (index >= s.Length)
				{
					return SetParseStringError(canHaveNull, out error);
				}
				c = s[index];
				switch (c)
				{
				case 'a':
					stringBuilder.Append('\a');
					break;
				case 'b':
					stringBuilder.Append('\b');
					break;
				case 'f':
					stringBuilder.Append('\f');
					break;
				case 'n':
					stringBuilder.Append('\n');
					break;
				case 'r':
					stringBuilder.Append('\r');
					break;
				case 't':
					stringBuilder.Append('\t');
					break;
				case 'v':
					stringBuilder.Append('\v');
					break;
				case '\\':
					stringBuilder.Append('\\');
					break;
				case '0':
					stringBuilder.Append('\0');
					break;
				case '"':
					stringBuilder.Append('"');
					break;
				case '\'':
					stringBuilder.Append('\'');
					break;
				case 'U':
				case 'u':
				case 'x':
				{
					index++;
					if (index >= s.Length)
					{
						return SetParseStringError(canHaveNull, out error);
					}
					int num = ParseHex(s, ref index, c switch
					{
						'u' => 4, 
						'x' => -1, 
						_ => 8, 
					}, out var surrogate);
					if (num < 0)
					{
						return SetParseStringError(canHaveNull, out error);
					}
					if (c == 'U' && surrogate != 0)
					{
						stringBuilder.Append(surrogate);
					}
					stringBuilder.Append((char)num);
					index--;
					break;
				}
				default:
					error = string.Format(dnSpy_Contracts_Logic_Resources.InvalidEscapeSequence2, c);
					return null;
				}
				break;
			default:
				stringBuilder.Append(c);
				break;
			}
		}
		return SetParseStringError(canHaveNull, out error);
	}

	private static void SkipSpaces(string s, ref int index)
	{
		while (index < s.Length && char.IsWhiteSpace(s[index]))
		{
			index++;
		}
	}

	private static int ParseHex(string s, ref int index, int hexChars, out char surrogate)
	{
		surrogate = '\0';
		if (index >= s.Length)
		{
			return -1;
		}
		int num = 0;
		int num2 = ((hexChars < 0) ? 4 : hexChars);
		int num3 = 0;
		while (num3 < num2 && index < s.Length)
		{
			int num4 = TryParseHexChar(s[index]);
			if (num4 < 0)
			{
				break;
			}
			num = (num << 4) | num4;
			num3++;
			index++;
		}
		if (hexChars >= 0 && hexChars != num3)
		{
			return -1;
		}
		if (hexChars < 0 && num3 == 0)
		{
			return -1;
		}
		if (hexChars == 8)
		{
			if (num >= 1114112)
			{
				return -1;
			}
			if (num >= 65536)
			{
				num -= 65536;
				surrogate = (char)(55296 + (num >> 10));
				num = 56320 + (num & 0x3FF);
			}
		}
		return num;
	}

	public static byte ParseByte(string s, byte min, byte max, out string error)
	{
		return (byte)ParseUnsigned(s, min, max, out error);
	}

	public static ushort ParseUInt16(string s, ushort min, ushort max, out string error)
	{
		return (ushort)ParseUnsigned(s, min, max, out error);
	}

	public static uint ParseUInt32(string s, uint min, uint max, out string error)
	{
		return (uint)ParseUnsigned(s, min, max, out error);
	}

	public static ulong ParseUInt64(string s, ulong min, ulong max, out string error)
	{
		return ParseUnsigned(s, min, max, out error);
	}

	private static string TryParseSigned(string s, long min, long max, object minObject, out long value)
	{
		value = 0L;
		s = s.Trim();
		s = s.Replace("_", string.Empty);
		bool flag = s.StartsWith("-", StringComparison.OrdinalIgnoreCase);
		if (flag)
		{
			s = s.Substring(1);
		}
		ulong result = 0uL;
		bool flag2;
		if (s.Trim() != s)
		{
			flag2 = false;
		}
		else if (s.StartsWith("0x", StringComparison.OrdinalIgnoreCase) || s.StartsWith("&H", StringComparison.OrdinalIgnoreCase))
		{
			string text = s.Substring(2);
			flag2 = text.Trim() == text && ulong.TryParse(text, NumberStyles.HexNumber, null, out result);
		}
		else
		{
			flag2 = ulong.TryParse(s, NumberStyles.Integer, null, out result);
		}
		if (!flag2)
		{
			return dnSpy_Contracts_Logic_Resources.InvalidInteger1;
		}
		if (flag)
		{
			if (result > 9223372036854775808uL)
			{
				return dnSpy_Contracts_Logic_Resources.InvalidInteger2;
			}
			value = (long)(0L - result);
		}
		else
		{
			if (result > long.MaxValue)
			{
				return dnSpy_Contracts_Logic_Resources.InvalidInteger3;
			}
			value = (long)result;
		}
		if (value < min || value > max)
		{
			if (min == 0)
			{
				return string.Format(dnSpy_Contracts_Logic_Resources.InvalidInteger4, min, max);
			}
			return string.Format(dnSpy_Contracts_Logic_Resources.InvalidInteger5, minObject, max, (min < 0) ? "-" : string.Empty);
		}
		return null;
	}

	private static long ParseSigned(string s, long min, long max, object minObject, out string error)
	{
		error = TryParseSigned(s, min, max, minObject, out var value);
		if (error != null)
		{
			return 0L;
		}
		return value;
	}

	public static sbyte ParseSByte(string s, sbyte min, sbyte max, out string error)
	{
		return (sbyte)ParseSigned(s, min, max, min, out error);
	}

	public static short ParseInt16(string s, short min, short max, out string error)
	{
		return (short)ParseSigned(s, min, max, min, out error);
	}

	public static int ParseInt32(string s, int min, int max, out string error)
	{
		return (int)ParseSigned(s, min, max, min, out error);
	}

	public static long ParseInt64(string s, long min, long max, out string error)
	{
		return ParseSigned(s, min, max, min, out error);
	}

	private static string ToString<T>(IList<T> list, Func<T, string> toString)
	{
		if (list == null)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < list.Count; i++)
		{
			if (i != 0)
			{
				stringBuilder.Append(", ");
			}
			stringBuilder.Append(toString(list[i]));
		}
		return stringBuilder.ToString();
	}

	public static string ToString(IList<bool> values)
	{
		return ToString(values, (bool v) => ToString(v));
	}

	public static string ToString(IList<char> values)
	{
		return ToString(values, (char v) => ToString(v));
	}

	public static string ToString(IList<byte> values, byte min, byte max, bool? useDecimal)
	{
		return ToString(values, (byte v) => ToString(v, min, max, useDecimal));
	}

	public static string ToString(IList<ushort> values, ushort min, ushort max, bool? useDecimal)
	{
		return ToString(values, (ushort v) => ToString(v, min, max, useDecimal));
	}

	public static string ToString(IList<uint> values, uint min, uint max, bool? useDecimal)
	{
		return ToString(values, (uint v) => ToString(v, min, max, useDecimal));
	}

	public static string ToString(IList<ulong> values, ulong min, ulong max, bool? useDecimal)
	{
		return ToString(values, (ulong v) => ToString(v, min, max, useDecimal));
	}

	public static string ToString(IList<sbyte> values, sbyte min, sbyte max, bool? useDecimal)
	{
		return ToString(values, (sbyte v) => ToString(v, min, max, useDecimal));
	}

	public static string ToString(IList<short> values, short min, short max, bool? useDecimal)
	{
		return ToString(values, (short v) => ToString(v, min, max, useDecimal));
	}

	public static string ToString(IList<int> values, int min, int max, bool? useDecimal)
	{
		return ToString(values, (int v) => ToString(v, min, max, useDecimal));
	}

	public static string ToString(IList<long> values, long min, long max, bool? useDecimal)
	{
		return ToString(values, (long v) => ToString(v, min, max, useDecimal));
	}

	public static string ToString(IList<float> values)
	{
		return ToString(values, (float v) => ToString(v));
	}

	public static string ToString(IList<double> values)
	{
		return ToString(values, (double v) => ToString(v));
	}

	public static string ToString(IList<string> values, bool canHaveNull)
	{
		return ToString(values, (string v) => ToString(v, canHaveNull));
	}

	private static T[] ParseList<T>(string s, out string error, Func<string, (T value, string error)> parseValue)
	{
		List<T> list = new List<T>();
		s = s.Trim();
		if (s == string.Empty)
		{
			error = null;
			return list.ToArray();
		}
		string[] array = s.Split(',');
		foreach (string text in array)
		{
			string text2 = text.Trim();
			if (text2 == string.Empty)
			{
				error = dnSpy_Contracts_Logic_Resources.InvalidListValue;
				return null;
			}
			(T, string) tuple = parseValue(text2);
			if (tuple.Item2 != null)
			{
				error = tuple.Item2;
				return null;
			}
			list.Add(tuple.Item1);
		}
		error = null;
		return list.ToArray();
	}

	private static T[] ParseList<T, U>(string s, out string error, ParseListCallBack<T, U> parseValue, U data)
	{
		List<T> list = new List<T>();
		if (s.Trim() == string.Empty)
		{
			error = null;
			return list.ToArray();
		}
		int index = 0;
		while (true)
		{
			int num = index;
			list.Add(parseValue(data, s, ref index, out error));
			if (error != null)
			{
				return null;
			}
			Debug.Assert(num < index);
			if (num >= index)
			{
				throw new InvalidOperationException();
			}
			SkipSpaces(s, ref index);
			if (index >= s.Length)
			{
				break;
			}
			if (s[index] != ',')
			{
				error = dnSpy_Contracts_Logic_Resources.InvalidListValue2;
				return null;
			}
			index++;
		}
		return list.ToArray();
	}

	public static bool[] ParseBooleanList(string s, out string error)
	{
		return ParseList(s, out error, delegate(string v)
		{
			bool item = ParseBoolean(v, out var error2);
			return (value: item, error: error2);
		});
	}

	public static char[] ParseCharList(string s, out string error)
	{
		return ParseList(s, out error, ParseCharPart, 0);
	}

	private static char ParseCharPart(int data, string s, ref int index, out string error)
	{
		return ParseChar(s, ref index, out error);
	}

	public static byte[] ParseByteList(string s, byte min, byte max, out string error)
	{
		return ParseList(s, out error, delegate(string v)
		{
			byte item = ParseByte(v, min, max, out var error2);
			return (value: item, error: error2);
		});
	}

	public static ushort[] ParseUInt16List(string s, ushort min, ushort max, out string error)
	{
		return ParseList(s, out error, delegate(string v)
		{
			ushort item = ParseUInt16(v, min, max, out var error2);
			return (value: item, error: error2);
		});
	}

	public static uint[] ParseUInt32List(string s, uint min, uint max, out string error)
	{
		return ParseList(s, out error, delegate(string v)
		{
			uint item = ParseUInt32(v, min, max, out var error2);
			return (value: item, error: error2);
		});
	}

	public static ulong[] ParseUInt64List(string s, ulong min, ulong max, out string error)
	{
		return ParseList(s, out error, delegate(string v)
		{
			ulong item = ParseUInt64(v, min, max, out var error2);
			return (value: item, error: error2);
		});
	}

	public static sbyte[] ParseSByteList(string s, sbyte min, sbyte max, out string error)
	{
		return ParseList(s, out error, delegate(string v)
		{
			sbyte item = ParseSByte(v, min, max, out var error2);
			return (value: item, error: error2);
		});
	}

	public static short[] ParseInt16List(string s, short min, short max, out string error)
	{
		return ParseList(s, out error, delegate(string v)
		{
			short item = ParseInt16(v, min, max, out var error2);
			return (value: item, error: error2);
		});
	}

	public static int[] ParseInt32List(string s, int min, int max, out string error)
	{
		return ParseList(s, out error, delegate(string v)
		{
			int item = ParseInt32(v, min, max, out var error2);
			return (value: item, error: error2);
		});
	}

	public static long[] ParseInt64List(string s, long min, long max, out string error)
	{
		return ParseList(s, out error, delegate(string v)
		{
			long item = ParseInt64(v, min, max, out var error2);
			return (value: item, error: error2);
		});
	}

	public static float[] ParseSingleList(string s, out string error)
	{
		return ParseList(s, out error, delegate(string v)
		{
			float item = ParseSingle(v, out var error2);
			return (value: item, error: error2);
		});
	}

	public static double[] ParseDoubleList(string s, out string error)
	{
		return ParseList(s, out error, delegate(string v)
		{
			double item = ParseDouble(v, out var error2);
			return (value: item, error: error2);
		});
	}

	public static string[] ParseStringList(string s, bool canHaveNull, out string error)
	{
		return ParseList(s, out error, ParseStringPart, canHaveNull);
	}

	private static string ParseStringPart(bool canHaveNull, string s, ref int index, out string error)
	{
		return ParseString(s, canHaveNull, ref index, out error);
	}
}
