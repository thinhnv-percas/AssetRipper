using System;
using System.Collections.Generic;
using System.Linq;

namespace Humanizer.Localisation.NumberToWords;

internal class DutchNumberToWordsConverter : GenderlessNumberToWordsConverter
{
	private class Fact
	{
		public int Value { get; set; }

		public string Name { get; set; }

		public string Prefix { get; set; }

		public string Postfix { get; set; }

		public bool DisplayOneUnit { get; set; }
	}

	private static readonly string[] UnitsMap = new string[20]
	{
		"nul", "een", "twee", "drie", "vier", "vijf", "zes", "zeven", "acht", "negen",
		"tien", "elf", "twaalf", "dertien", "veertien", "vijftien", "zestien", "zeventien", "achttien", "negentien"
	};

	private static readonly string[] TensMap = new string[10] { "nul", "tien", "twintig", "dertig", "veertig", "vijftig", "zestig", "zeventig", "tachtig", "negentig" };

	private static readonly Fact[] Hunderds = new Fact[4]
	{
		new Fact
		{
			Value = 1000000000,
			Name = "miljard",
			Prefix = " ",
			Postfix = " ",
			DisplayOneUnit = true
		},
		new Fact
		{
			Value = 1000000,
			Name = "miljoen",
			Prefix = " ",
			Postfix = " ",
			DisplayOneUnit = true
		},
		new Fact
		{
			Value = 1000,
			Name = "duizend",
			Prefix = "",
			Postfix = " ",
			DisplayOneUnit = false
		},
		new Fact
		{
			Value = 100,
			Name = "honderd",
			Prefix = "",
			Postfix = "",
			DisplayOneUnit = false
		}
	};

	private static readonly Dictionary<string, string> OrdinalExceptions = new Dictionary<string, string>
	{
		{ "een", "eerste" },
		{ "drie", "derde" },
		{ "miljoen", "miljoenste" }
	};

	private static readonly char[] EndingCharForSte = new char[3] { 't', 'g', 'd' };

	public override string Convert(long input)
	{
		if (input > int.MaxValue || input < int.MinValue)
		{
			throw new NotImplementedException();
		}
		int num = (int)input;
		if (num == 0)
		{
			return UnitsMap[0];
		}
		if (num < 0)
		{
			return $"min {Convert(-num)}";
		}
		string text = "";
		Fact[] hunderds = Hunderds;
		foreach (Fact fact in hunderds)
		{
			int num2 = num / fact.Value;
			if (num2 > 0)
			{
				text = ((num2 != 1 || fact.DisplayOneUnit) ? (text + Convert(num2) + fact.Prefix + fact.Name) : (text + fact.Name));
				num %= fact.Value;
				if (num > 0)
				{
					text += fact.Postfix;
				}
			}
		}
		if (num > 0)
		{
			if (num < 20)
			{
				text += UnitsMap[num];
			}
			else
			{
				string text2 = TensMap[num / 10];
				int num3 = num % 10;
				if (num3 > 0)
				{
					string text3 = UnitsMap[num3];
					bool flag = text3.EndsWith("e");
					text = text + text3 + (flag ? "ën" : "en") + text2;
				}
				else
				{
					text += text2;
				}
			}
		}
		return text;
	}

	public override string ConvertToOrdinal(int number)
	{
		string word = Convert(number);
		using (IEnumerator<KeyValuePair<string, string>> enumerator = Enumerable.Where<KeyValuePair<string, string>>((IEnumerable<KeyValuePair<string, string>>)OrdinalExceptions, (Func<KeyValuePair<string, string>, bool>)((KeyValuePair<string, string> kv) => word.EndsWith(kv.Key))).GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				KeyValuePair<string, string> current = enumerator.Current;
				return word.Substring(0, word.Length - current.Key.Length) + current.Value;
			}
		}
		if (word.LastIndexOfAny(EndingCharForSte) == word.Length - 1)
		{
			return word + "ste";
		}
		return word + "de";
	}
}
