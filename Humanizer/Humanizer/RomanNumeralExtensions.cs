using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Humanizer;

public static class RomanNumeralExtensions
{
	private const int NumberOfRomanNumeralMaps = 13;

	private static readonly IDictionary<string, int> RomanNumerals;

	private static readonly Regex ValidRomanNumeral;

	public static int FromRoman(this string input)
	{
		if (input == null)
		{
			throw new ArgumentNullException("input");
		}
		input = input.Trim().ToUpperInvariant();
		int length = input.Length;
		if (length == 0 || IsInvalidRomanNumeral(input))
		{
			throw new ArgumentException("Empty or invalid Roman numeral string.", "input");
		}
		int num = 0;
		int num2 = length;
		while (num2 > 0)
		{
			int num3 = RomanNumerals[input[--num2].ToString()];
			if (num2 > 0)
			{
				int num4 = RomanNumerals[input[num2 - 1].ToString()];
				if (num4 < num3)
				{
					num3 -= num4;
					num2--;
				}
			}
			num += num3;
		}
		return num;
	}

	public static string ToRoman(this int input)
	{
		if (input < 1 || input > 3999)
		{
			throw new ArgumentOutOfRangeException();
		}
		StringBuilder stringBuilder = new StringBuilder(15);
		foreach (KeyValuePair<string, int> romanNumeral in RomanNumerals)
		{
			while (input / romanNumeral.Value > 0)
			{
				stringBuilder.Append(romanNumeral.Key);
				input -= romanNumeral.Value;
			}
		}
		return stringBuilder.ToString();
	}

	private static bool IsInvalidRomanNumeral(string input)
	{
		return !ValidRomanNumeral.IsMatch(input);
	}

	static RomanNumeralExtensions()
	{
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected O, but got Unknown
		RomanNumerals = new Dictionary<string, int>(13)
		{
			{ "M", 1000 },
			{ "CM", 900 },
			{ "D", 500 },
			{ "CD", 400 },
			{ "C", 100 },
			{ "XC", 90 },
			{ "L", 50 },
			{ "XL", 40 },
			{ "X", 10 },
			{ "IX", 9 },
			{ "V", 5 },
			{ "IV", 4 },
			{ "I", 1 }
		};
		ValidRomanNumeral = new Regex("^(?i:(?=[MDCLXVI])((M{0,3})((C[DM])|(D?C{0,3}))?((X[LC])|(L?XX{0,2})|L)?((I[VX])|(V?(II{0,2}))|V)?))$", RegexOptionsUtil.Compiled);
	}
}
