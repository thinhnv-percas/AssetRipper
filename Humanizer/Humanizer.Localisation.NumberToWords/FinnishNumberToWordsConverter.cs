using System;
using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords;

internal class FinnishNumberToWordsConverter : GenderlessNumberToWordsConverter
{
	private static readonly string[] UnitsMap = new string[11]
	{
		"nolla", "yksi", "kaksi", "kolme", "neljä", "viisi", "kuusi", "seitsemän", "kahdeksan", "yhdeksän",
		"kymmenen"
	};

	private static readonly string[] OrdinalUnitsMap = new string[11]
	{
		"nollas", "ensimmäinen", "toinen", "kolmas", "neljäs", "viides", "kuudes", "seitsemäs", "kahdeksas", "yhdeksäs",
		"kymmenes"
	};

	private static readonly Dictionary<int, string> OrdinalExceptions = new Dictionary<int, string>
	{
		{ 1, "yhdes" },
		{ 2, "kahdes" }
	};

	public override string Convert(long input)
	{
		if (input > int.MaxValue || input < int.MinValue)
		{
			throw new NotImplementedException();
		}
		int num = (int)input;
		if (num < 0)
		{
			return $"miinus {Convert(-num)}";
		}
		if (num == 0)
		{
			return UnitsMap[0];
		}
		List<string> list = new List<string>();
		if (num / 1000000000 > 0)
		{
			list.Add((num / 1000000000 == 1) ? "miljardi " : $"{Convert(num / 1000000000)}miljardia ");
			num %= 1000000000;
		}
		if (num / 1000000 > 0)
		{
			list.Add((num / 1000000 == 1) ? "miljoona " : $"{Convert(num / 1000000)}miljoonaa ");
			num %= 1000000;
		}
		if (num / 1000 > 0)
		{
			list.Add((num / 1000 == 1) ? "tuhat " : $"{Convert(num / 1000)}tuhatta ");
			num %= 1000;
		}
		if (num / 100 > 0)
		{
			list.Add((num / 100 == 1) ? "sata" : $"{Convert(num / 100)}sataa");
			num %= 100;
		}
		if (num >= 20 && num / 10 > 0)
		{
			list.Add($"{Convert(num / 10)}kymmentä");
			num %= 10;
		}
		else if (num > 10 && num < 20)
		{
			list.Add($"{UnitsMap[num % 10]}toista");
		}
		if (num > 0 && num <= 10)
		{
			list.Add(UnitsMap[num]);
		}
		return string.Join("", list).Trim();
	}

	private string GetOrdinalUnit(int number, bool useExceptions)
	{
		if (useExceptions && OrdinalExceptions.ContainsKey(number))
		{
			return OrdinalExceptions[number];
		}
		return OrdinalUnitsMap[number];
	}

	private string ToOrdinal(int number, bool useExceptions)
	{
		if (number == 0)
		{
			return OrdinalUnitsMap[0];
		}
		List<string> list = new List<string>();
		if (number / 1000000000 > 0)
		{
			list.Add(string.Format("{0}miljardis", new object[1] { (number / 1000000000 == 1) ? "" : ToOrdinal(number / 1000000000, useExceptions: true) }));
			number %= 1000000000;
		}
		if (number / 1000000 > 0)
		{
			list.Add(string.Format("{0}miljoonas", new object[1] { (number / 1000000 == 1) ? "" : ToOrdinal(number / 1000000, useExceptions: true) }));
			number %= 1000000;
		}
		if (number / 1000 > 0)
		{
			list.Add(string.Format("{0}tuhannes", new object[1] { (number / 1000 == 1) ? "" : ToOrdinal(number / 1000, useExceptions: true) }));
			number %= 1000;
		}
		if (number / 100 > 0)
		{
			list.Add(string.Format("{0}sadas", new object[1] { (number / 100 == 1) ? "" : ToOrdinal(number / 100, useExceptions: true) }));
			number %= 100;
		}
		if (number >= 20 && number / 10 > 0)
		{
			list.Add($"{ToOrdinal(number / 10, useExceptions: true)}kymmenes");
			number %= 10;
		}
		else if (number > 10 && number < 20)
		{
			list.Add($"{GetOrdinalUnit(number % 10, useExceptions: true)}toista");
		}
		if (number > 0 && number <= 10)
		{
			list.Add(GetOrdinalUnit(number, useExceptions));
		}
		return string.Join("", list);
	}

	public override string ConvertToOrdinal(int number)
	{
		return ToOrdinal(number, useExceptions: false);
	}
}
