namespace System;

internal class UriShim
{
	private const char c_DummyChar = '\uffff';

	private static readonly char[] s_hexUpperChars = new char[16]
	{
		'0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
		'A', 'B', 'C', 'D', 'E', 'F'
	};

	public static string HexEscape(char character)
	{
		if (character > 'ÿ')
		{
			throw new ArgumentOutOfRangeException("character");
		}
		char[] array = new char[3];
		int pos = 0;
		EscapeAsciiChar(character, array, ref pos);
		return new string(array);
	}

	public static char HexUnescape(string pattern, ref int index)
	{
		if (index < 0 || index >= pattern.Length)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (pattern[index] == '%' && pattern.Length - index >= 3)
		{
			char c = EscapedAscii(pattern[index + 1], pattern[index + 2]);
			if (c != '\uffff')
			{
				index += 3;
				return c;
			}
		}
		return pattern[index++];
	}

	public static bool IsHexEncoding(string pattern, int index)
	{
		if (pattern.Length - index < 3)
		{
			return false;
		}
		if (pattern[index] == '%' && EscapedAscii(pattern[index + 1], pattern[index + 2]) != '\uffff')
		{
			return true;
		}
		return false;
	}

	internal static void EscapeAsciiChar(char ch, char[] to, ref int pos)
	{
		to[pos++] = '%';
		to[pos++] = s_hexUpperChars[(ch & 0xF0) >> 4];
		to[pos++] = s_hexUpperChars[ch & 0xF];
	}

	private static char EscapedAscii(char digit, char next)
	{
		if ((digit < '0' || digit > '9') && (digit < 'A' || digit > 'F') && (digit < 'a' || digit > 'f'))
		{
			return '\uffff';
		}
		int num = ((digit <= '9') ? (digit - 48) : (((digit <= 'F') ? (digit - 65) : (digit - 97)) + 10));
		if ((next < '0' || next > '9') && (next < 'A' || next > 'F') && (next < 'a' || next > 'f'))
		{
			return '\uffff';
		}
		return (char)((num << 4) + ((next <= '9') ? (next - 48) : (((next <= 'F') ? (next - 65) : (next - 97)) + 10)));
	}
}
