using System;
using System.Collections.Generic;
using System.Linq;

namespace McMaster.Extensions.CommandLineUtils;

internal static class StringDistance
{
	private static int LevenshteinDistance(string s, string t, bool damareu)
	{
		if (s == t)
		{
			return 0;
		}
		if (string.IsNullOrEmpty(s))
		{
			if (string.IsNullOrEmpty(t))
			{
				return 0;
			}
			return t.Length;
		}
		if (string.IsNullOrEmpty(t))
		{
			if (string.IsNullOrEmpty(s))
			{
				return 0;
			}
			return s.Length;
		}
		int[,] array = new int[s.Length + 1, t.Length + 1];
		for (int i = 0; i <= s.Length; i++)
		{
			array[i, 0] = i;
		}
		for (int j = 0; j <= t.Length; j++)
		{
			array[0, j] = j;
		}
		for (int k = 1; k <= s.Length; k++)
		{
			for (int l = 1; l <= t.Length; l++)
			{
				int num = ((s[k - 1] != t[l - 1]) ? 1 : 0);
				int num2 = new int[3]
				{
					array[k, l - 1] + 1,
					array[k - 1, l] + 1,
					array[k - 1, l - 1] + num
				}.Min();
				if (damareu && k > 1 && l > 1 && s[k - 1] == t[l - 2] && s[k - 2] == t[l - 1])
				{
					num2 = Math.Min(num2, array[k - 2, l - 2] + num);
				}
				array[k, l] = num2;
			}
		}
		return array[s.Length, t.Length];
	}

	internal static int LevenshteinDistance(string s, string t)
	{
		return LevenshteinDistance(s, t, damareu: false);
	}

	internal static int DamareuLevenshteinDistance(string s, string t)
	{
		return LevenshteinDistance(s, t, damareu: true);
	}

	internal static double NormalizeDistance(int distance, int length)
	{
		if (length == 0)
		{
			return 0.0;
		}
		if (distance == 0)
		{
			return 1.0;
		}
		return 1.0 - (double)distance / (double)length;
	}

	internal static IEnumerable<string> GetBestMatchesSorted(Func<string, string, int> distanceMethod, string value, IEnumerable<string> values, double threshold)
	{
		if (distanceMethod == null || value == null || values == null)
		{
			return null;
		}
		return from candidate in values.Where((string v) => v != null).Select(delegate(string stringValue)
			{
				int distance = distanceMethod(value, stringValue);
				int length = Math.Max(value.Length, stringValue.Length);
				double item = NormalizeDistance(distance, length);
				return (stringValue: stringValue, normalizedDistance: item);
			})
			where candidate.normalizedDistance >= threshold
			orderby candidate.normalizedDistance descending
			select candidate.stringValue;
	}
}
