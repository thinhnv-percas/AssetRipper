using System;
using System.Collections.Generic;
using System.Linq;

namespace Humanizer;

public static class MetricNumeralExtensions
{
	private static readonly double BigLimit;

	private static readonly double SmallLimit;

	private static readonly List<char>[] Symbols;

	private static readonly Dictionary<char, string> Names;

	static MetricNumeralExtensions()
	{
		Symbols = new List<char>[2]
		{
			new List<char> { 'k', 'M', 'G', 'T', 'P', 'E', 'Z', 'Y' },
			new List<char> { 'm', 'μ', 'n', 'p', 'f', 'a', 'z', 'y' }
		};
		Names = new Dictionary<char, string>
		{
			{ 'Y', "yotta" },
			{ 'Z', "zetta" },
			{ 'E', "exa" },
			{ 'P', "peta" },
			{ 'T', "tera" },
			{ 'G', "giga" },
			{ 'M', "mega" },
			{ 'k', "kilo" },
			{ 'm', "milli" },
			{ 'μ', "micro" },
			{ 'n', "nano" },
			{ 'p', "pico" },
			{ 'f', "femto" },
			{ 'a', "atto" },
			{ 'z', "zepto" },
			{ 'y', "yocto" }
		};
		BigLimit = Math.Pow(10.0, 27.0);
		SmallLimit = Math.Pow(10.0, -27.0);
	}

	public static double FromMetric(this string input)
	{
		input = CleanRepresentation(input);
		return BuildNumber(input, input[input.Length - 1]);
	}

	public static string ToMetric(this int input, bool hasSpace = false, bool useSymbol = true, int? decimals = null)
	{
		return ((double)input).ToMetric(hasSpace, useSymbol, decimals);
	}

	public static string ToMetric(this double input, bool hasSpace = false, bool useSymbol = true, int? decimals = null)
	{
		if (input.Equals(0.0))
		{
			return input.ToString();
		}
		if (input.IsOutOfRange())
		{
			throw new ArgumentOutOfRangeException("input");
		}
		return BuildRepresentation(input, hasSpace, useSymbol, decimals);
	}

	private static string CleanRepresentation(string input)
	{
		if (input == null)
		{
			throw new ArgumentNullException("input");
		}
		input = input.Trim();
		input = ReplaceNameBySymbol(input);
		if (input.Length == 0 || input.IsInvalidMetricNumeral())
		{
			throw new ArgumentException("Empty or invalid Metric string.", "input");
		}
		return input.Replace(" ", string.Empty);
	}

	private static double BuildNumber(string input, char last)
	{
		if (!char.IsLetter(last))
		{
			return double.Parse(input);
		}
		return BuildMetricNumber(input, last);
	}

	private static double BuildMetricNumber(string input, char last)
	{
		Func<List<char>, double> func = (List<char> symbols) => (symbols.IndexOf(last) + 1) * 3;
		double num = double.Parse(input.Remove(input.Length - 1));
		double num2 = Math.Pow(10.0, Symbols[0].Contains(last) ? func(Symbols[0]) : (0.0 - func(Symbols[1])));
		return num * num2;
	}

	private static string ReplaceNameBySymbol(string input)
	{
		return Enumerable.Aggregate<KeyValuePair<char, string>, string>((IEnumerable<KeyValuePair<char, string>>)Names, input, (Func<string, KeyValuePair<char, string>, string>)((string current, KeyValuePair<char, string> name) => current.Replace(name.Value, name.Key.ToString())));
	}

	private static string BuildRepresentation(double input, bool hasSpace, bool useSymbol, int? decimals)
	{
		int exponent = (int)Math.Floor(Math.Log10(Math.Abs(input)) / 3.0);
		if (!exponent.Equals(0))
		{
			return BuildMetricRepresentation(input, exponent, hasSpace, useSymbol, decimals);
		}
		return input.ToString();
	}

	private static string BuildMetricRepresentation(double input, int exponent, bool hasSpace, bool useSymbol, int? decimals)
	{
		double num = input * Math.Pow(1000.0, -exponent);
		if (decimals.HasValue)
		{
			num = Math.Round(num, decimals.Value);
		}
		char symbol = ((Math.Sign(exponent) == 1) ? Symbols[0][exponent - 1] : Symbols[1][-exponent - 1]);
		return num + (hasSpace ? " " : string.Empty) + GetUnit(symbol, useSymbol);
	}

	private static string GetUnit(char symbol, bool useSymbol)
	{
		if (!useSymbol)
		{
			return Names[symbol];
		}
		return symbol.ToString();
	}

	private static bool IsOutOfRange(this double input)
	{
		Func<double, double, bool> func = (double min, double max) => !(max > input) || !(input > min);
		if (Math.Sign(input) != 1 || !func(SmallLimit, BigLimit))
		{
			if (Math.Sign(input) == -1)
			{
				return func(0.0 - BigLimit, 0.0 - SmallLimit);
			}
			return false;
		}
		return true;
	}

	private static bool IsInvalidMetricNumeral(this string input)
	{
		int num = input.Length - 1;
		char item = input[num];
		double result;
		return !double.TryParse((Symbols[0].Contains(item) || Symbols[1].Contains(item)) ? input.Remove(num) : input, out result);
	}
}
