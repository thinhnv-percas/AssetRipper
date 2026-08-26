using System;
using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords;

internal class TurkishNumberToWordConverter : GenderlessNumberToWordsConverter
{
	private static readonly string[] UnitsMap = new string[10] { "sıfır", "bir", "iki", "üç", "dört", "beş", "altı", "yedi", "sekiz", "dokuz" };

	private static readonly string[] TensMap = new string[10] { "sıfır", "on", "yirmi", "otuz", "kırk", "elli", "altmış", "yetmiş", "seksen", "doksan" };

	private static readonly Dictionary<char, string> OrdinalSuffix = new Dictionary<char, string>
	{
		{ 'ı', "ıncı" },
		{ 'i', "inci" },
		{ 'u', "uncu" },
		{ 'ü', "üncü" },
		{ 'o', "uncu" },
		{ 'ö', "üncü" },
		{ 'e', "inci" },
		{ 'a', "ıncı" }
	};

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
			return $"eksi {Convert(-num)}";
		}
		List<string> list = new List<string>();
		if (num / 1000000000 > 0)
		{
			list.Add($"{Convert(num / 1000000000)} milyar");
			num %= 1000000000;
		}
		if (num / 1000000 > 0)
		{
			list.Add($"{Convert(num / 1000000)} milyon");
			num %= 1000000;
		}
		int num2 = num / 1000;
		if (num2 > 0)
		{
			list.Add(string.Format("{0} bin", new object[1] { (num2 > 1) ? Convert(num2) : "" }).Trim());
			num %= 1000;
		}
		int num3 = num / 100;
		if (num3 > 0)
		{
			list.Add(string.Format("{0} yüz", new object[1] { (num3 > 1) ? Convert(num3) : "" }).Trim());
			num %= 100;
		}
		if (num / 10 > 0)
		{
			list.Add(TensMap[num / 10]);
			num %= 10;
		}
		if (num > 0)
		{
			list.Add(UnitsMap[num]);
		}
		return string.Join(" ", list.ToArray());
	}

	public override string ConvertToOrdinal(int number)
	{
		string text = Convert(number);
		string value = string.Empty;
		bool flag = false;
		for (int num = text.Length - 1; num >= 0; num--)
		{
			if (OrdinalSuffix.TryGetValue(text[num], out value))
			{
				flag = num == text.Length - 1;
				break;
			}
		}
		if (text[text.Length - 1] == 't')
		{
			text = text.Substring(0, text.Length - 1) + "d";
		}
		if (flag)
		{
			text = text.Substring(0, text.Length - 1);
		}
		return string.Format("{0}{1}", new object[2] { text, value });
	}
}
