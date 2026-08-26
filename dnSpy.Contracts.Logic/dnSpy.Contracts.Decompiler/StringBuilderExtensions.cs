using System.Text;

namespace dnSpy.Contracts.Decompiler;

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
}
