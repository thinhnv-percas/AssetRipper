using System.Globalization;
using System.Text;

namespace Roslyn.Utilities;

internal static class StringUtilities
{
	internal static string EscapeNonPrintableCharacters(string str)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (char c in str)
		{
			UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
			if ((uint)(unicodeCategory - 13) <= 1u || unicodeCategory == UnicodeCategory.Surrogate || unicodeCategory == UnicodeCategory.OtherNotAssigned || c >= '￼')
			{
				stringBuilder.AppendFormat("\\u{0:X4}", (int)c);
			}
			else
			{
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString();
	}
}
