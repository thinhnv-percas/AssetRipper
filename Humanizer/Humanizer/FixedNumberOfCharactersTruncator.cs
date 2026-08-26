using System;
using System.Collections.Generic;
using System.Linq;

namespace Humanizer;

internal class FixedNumberOfCharactersTruncator : ITruncator
{
	public string Truncate(string value, int length, string truncationString, TruncateFrom truncateFrom = TruncateFrom.Right)
	{
		if (value == null)
		{
			return null;
		}
		if (value.Length == 0)
		{
			return value;
		}
		if (truncationString == null)
		{
			truncationString = string.Empty;
		}
		if (truncationString.Length > length)
		{
			if (truncateFrom != TruncateFrom.Right)
			{
				return value.Substring(value.Length - length);
			}
			return value.Substring(0, length);
		}
		int num = 0;
		if (Enumerable.Count<char>((IEnumerable<char>)value.ToCharArray(), (Func<char, bool>)char.IsLetterOrDigit) <= length)
		{
			return value;
		}
		if (truncateFrom == TruncateFrom.Left)
		{
			for (int num2 = value.Length - 1; num2 > 0; num2--)
			{
				if (char.IsLetterOrDigit(value[num2]))
				{
					num++;
				}
				if (num + truncationString.Length == length)
				{
					return truncationString + value.Substring(num2);
				}
			}
		}
		for (int i = 0; i < value.Length - truncationString.Length; i++)
		{
			if (char.IsLetterOrDigit(value[i]))
			{
				num++;
			}
			if (num + truncationString.Length == length)
			{
				return value.Substring(0, i + 1) + truncationString;
			}
		}
		return value;
	}
}
