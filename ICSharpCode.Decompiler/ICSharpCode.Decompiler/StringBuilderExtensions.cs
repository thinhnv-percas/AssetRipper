using System.Text;

namespace ICSharpCode.Decompiler;

internal static class StringBuilderExtensions
{
	public static bool CheckEquals(this StringBuilder sb, string s)
	{
		if (s == null || sb.Length != s.Length)
		{
			return false;
		}
		for (int i = 0; i < s.Length; i++)
		{
			if (sb[i] != s[i])
			{
				return false;
			}
		}
		return true;
	}

	public static bool StartsWith(this string s, StringBuilder sb)
	{
		int length = sb.Length;
		if (s.Length < length)
		{
			return false;
		}
		for (int i = 0; i < length; i++)
		{
			if (sb[i] != s[i])
			{
				return false;
			}
		}
		return true;
	}

	public static bool EndsWith(this StringBuilder sb, string s)
	{
		int length = sb.Length;
		if (length < s.Length)
		{
			return false;
		}
		int num = 0;
		int num2 = length - s.Length;
		while (num < s.Length)
		{
			if (sb[num2] != s[num])
			{
				return false;
			}
			num++;
			num2++;
		}
		return true;
	}
}
