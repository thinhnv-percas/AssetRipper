using System.Globalization;
using System.Text;

namespace dnSpy.Contracts.Decompiler;

public static class IdentifierEscaper
{
	private const int MAX_IDENTIFIER_LENGTH = 512;

	private const string EMPTY_NAME = "<<EMPTY_NAME>>";

	public static string Truncate(string s)
	{
		if (s == null || s.Length <= 512)
		{
			return s;
		}
		return s.Substring(0, 512) + "…";
	}

	public static string Escape(string id)
	{
		if (string.IsNullOrEmpty(id))
		{
			return "<<EMPTY_NAME>>";
		}
		int i = 0;
		if (id.Length <= 512)
		{
			while (true)
			{
				if (i >= id.Length)
				{
					return id;
				}
				if (!IsValidChar(id[i]))
				{
					break;
				}
				i++;
			}
		}
		StringBuilder stringBuilder = new StringBuilder(id.Length + 10);
		if (i != 0)
		{
			stringBuilder.Append(id, 0, i);
		}
		for (; i < id.Length; i++)
		{
			char c = id[i];
			if (!IsValidChar(c))
			{
				stringBuilder.Append($"\\u{(ushort)c:X4}");
			}
			else
			{
				stringBuilder.Append(c);
			}
			if (stringBuilder.Length >= 512)
			{
				break;
			}
		}
		if (stringBuilder.Length > 512)
		{
			stringBuilder.Length = 512;
			stringBuilder.Append('…');
		}
		return stringBuilder.ToString();
	}

	private static bool IsValidChar(char c)
	{
		if ('!' <= c && c <= '~')
		{
			return true;
		}
		if (c <= ' ')
		{
			return false;
		}
		switch (char.GetUnicodeCategory(c))
		{
		case UnicodeCategory.UppercaseLetter:
		case UnicodeCategory.LowercaseLetter:
		case UnicodeCategory.OtherLetter:
		case UnicodeCategory.DecimalDigitNumber:
			return true;
		default:
			return false;
		}
	}
}
