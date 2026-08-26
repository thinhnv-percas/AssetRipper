using System;
using System.Collections.Generic;
using System.Linq;

namespace Humanizer;

internal class FixedNumberOfWordsTruncator : ITruncator
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
		if (Enumerable.Count<string>((IEnumerable<string>)value.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries)) <= length)
		{
			return value;
		}
		if (truncateFrom != TruncateFrom.Left)
		{
			return TruncateFromRight(value, length, truncationString);
		}
		return TruncateFromLeft(value, length, truncationString);
	}

	private static string TruncateFromRight(string value, int length, string truncationString)
	{
		bool flag = true;
		int num = 0;
		for (int i = 0; i < value.Length; i++)
		{
			if (char.IsWhiteSpace(value[i]))
			{
				if (!flag)
				{
					num++;
				}
				flag = true;
				if (num == length)
				{
					return value.Substring(0, i) + truncationString;
				}
			}
			else
			{
				flag = false;
			}
		}
		return value + truncationString;
	}

	private static string TruncateFromLeft(string value, int length, string truncationString)
	{
		bool flag = true;
		int num = 0;
		for (int num2 = value.Length - 1; num2 > 0; num2--)
		{
			if (char.IsWhiteSpace(value[num2]))
			{
				if (!flag)
				{
					num++;
				}
				flag = true;
				if (num == length)
				{
					return truncationString + value.Substring(num2 + 1).TrimEnd(new char[0]);
				}
			}
			else
			{
				flag = false;
			}
		}
		return truncationString + value;
	}
}
