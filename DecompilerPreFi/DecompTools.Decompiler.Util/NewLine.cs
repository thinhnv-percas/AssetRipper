using System;

namespace DecompTools.Decompiler.Util;

public static class NewLine
{
	public const char CR = '\r';

	public const char LF = '\n';

	public const char NEL = '\u0085';

	public const char VT = '\v';

	public const char FF = '\f';

	public const char LS = '\u2028';

	public const char PS = '\u2029';

	public static int GetDelimiterLength(char curChar, Func<char> nextChar = null)
	{
		switch (curChar)
		{
		case '\r':
			if (nextChar != null && nextChar() == '\n')
			{
				return 2;
			}
			return 1;
		default:
			if (curChar != '\u2029')
			{
				return 0;
			}
			goto case '\n';
		case '\n':
		case '\v':
		case '\f':
		case '\u0085':
		case '\u2028':
			return 1;
		}
	}

	public static int GetDelimiterLength(char curChar, char nextChar)
	{
		switch (curChar)
		{
		case '\r':
			if (nextChar == '\n')
			{
				return 2;
			}
			return 1;
		default:
			if (curChar != '\u2029')
			{
				return 0;
			}
			goto case '\n';
		case '\n':
		case '\v':
		case '\f':
		case '\u0085':
		case '\u2028':
			return 1;
		}
	}

	public static bool TryGetDelimiterLengthAndType(char curChar, out int length, out UnicodeNewline type, Func<char> nextChar = null)
	{
		if (curChar == '\r')
		{
			if (nextChar != null && nextChar() == '\n')
			{
				length = 2;
				type = UnicodeNewline.CRLF;
			}
			else
			{
				length = 1;
				type = UnicodeNewline.CR;
			}
			return true;
		}
		switch (curChar)
		{
		case '\n':
			type = UnicodeNewline.LF;
			length = 1;
			return true;
		case '\u0085':
			type = UnicodeNewline.NEL;
			length = 1;
			return true;
		case '\v':
			type = UnicodeNewline.VT;
			length = 1;
			return true;
		case '\f':
			type = UnicodeNewline.FF;
			length = 1;
			return true;
		case '\u2028':
			type = UnicodeNewline.LS;
			length = 1;
			return true;
		case '\u2029':
			type = UnicodeNewline.PS;
			length = 1;
			return true;
		default:
			length = -1;
			type = UnicodeNewline.Unknown;
			return false;
		}
	}

	public static bool TryGetDelimiterLengthAndType(char curChar, out int length, out UnicodeNewline type, char nextChar)
	{
		if (curChar == '\r')
		{
			if (nextChar == '\n')
			{
				length = 2;
				type = UnicodeNewline.CRLF;
			}
			else
			{
				length = 1;
				type = UnicodeNewline.CR;
			}
			return true;
		}
		switch (curChar)
		{
		case '\n':
			type = UnicodeNewline.LF;
			length = 1;
			return true;
		case '\u0085':
			type = UnicodeNewline.NEL;
			length = 1;
			return true;
		case '\v':
			type = UnicodeNewline.VT;
			length = 1;
			return true;
		case '\f':
			type = UnicodeNewline.FF;
			length = 1;
			return true;
		case '\u2028':
			type = UnicodeNewline.LS;
			length = 1;
			return true;
		case '\u2029':
			type = UnicodeNewline.PS;
			length = 1;
			return true;
		default:
			length = -1;
			type = UnicodeNewline.Unknown;
			return false;
		}
	}

	public static UnicodeNewline GetDelimiterType(char curChar, Func<char> nextChar = null)
	{
		switch (curChar)
		{
		case '\r':
			if (nextChar != null && nextChar() == '\n')
			{
				return UnicodeNewline.CRLF;
			}
			return UnicodeNewline.CR;
		case '\n':
			return UnicodeNewline.LF;
		case '\u0085':
			return UnicodeNewline.NEL;
		case '\v':
			return UnicodeNewline.VT;
		case '\f':
			return UnicodeNewline.FF;
		case '\u2028':
			return UnicodeNewline.LS;
		case '\u2029':
			return UnicodeNewline.PS;
		default:
			return UnicodeNewline.Unknown;
		}
	}

	public static UnicodeNewline GetDelimiterType(char curChar, char nextChar)
	{
		switch (curChar)
		{
		case '\r':
			if (nextChar == '\n')
			{
				return UnicodeNewline.CRLF;
			}
			return UnicodeNewline.CR;
		case '\n':
			return UnicodeNewline.LF;
		case '\u0085':
			return UnicodeNewline.NEL;
		case '\v':
			return UnicodeNewline.VT;
		case '\f':
			return UnicodeNewline.FF;
		case '\u2028':
			return UnicodeNewline.LS;
		case '\u2029':
			return UnicodeNewline.PS;
		default:
			return UnicodeNewline.Unknown;
		}
	}

	public static bool IsNewLine(char ch)
	{
		return ch == '\r' || ch == '\n' || ch == '\u0085' || ch == '\v' || ch == '\f' || ch == '\u2028' || ch == '\u2029';
	}

	public static string GetString(UnicodeNewline newLine)
	{
		return newLine switch
		{
			UnicodeNewline.Unknown => "", 
			UnicodeNewline.LF => "\n", 
			UnicodeNewline.CRLF => "\r\n", 
			UnicodeNewline.CR => "\r", 
			UnicodeNewline.NEL => "\u0085", 
			UnicodeNewline.VT => "\v", 
			UnicodeNewline.FF => "\f", 
			UnicodeNewline.LS => "\u2028", 
			UnicodeNewline.PS => "\u2029", 
			_ => throw new ArgumentOutOfRangeException(), 
		};
	}
}
