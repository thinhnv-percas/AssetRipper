using System;
using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords;

internal class FarsiNumberToWordsConverter : GenderlessNumberToWordsConverter
{
	private static readonly string[] FarsiHundredsMap = new string[10] { "صفر", "صد", "دویست", "سیصد", "چهارصد", "پانصد", "ششصد", "هفتصد", "هشتصد", "نهصد" };

	private static readonly string[] FarsiTensMap = new string[10] { "صفر", "ده", "بیست", "سی", "چهل", "پنجاه", "شصت", "هفتاد", "هشتاد", "نود" };

	private static readonly string[] FarsiUnitsMap = new string[20]
	{
		"صفر", "یک", "دو", "سه", "چهار", "پنج", "شش", "هفت", "هشت", "نه",
		"ده", "یازده", "دوازده", "سیزده", "چهارده", "پانزده", "شانزده", "هفده", "هجده", "نوزده"
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
			return $"منفی {Convert(-num)}";
		}
		if (num == 0)
		{
			return "صفر";
		}
		Dictionary<int, Func<int, string>> dictionary = new Dictionary<int, Func<int, string>>
		{
			{
				(int)Math.Pow(10.0, 9.0),
				(int n) => $"{Convert(n)} میلیارد"
			},
			{
				(int)Math.Pow(10.0, 6.0),
				(int n) => $"{Convert(n)} میلیون"
			},
			{
				(int)Math.Pow(10.0, 3.0),
				(int n) => $"{Convert(n)} هزار"
			},
			{
				(int)Math.Pow(10.0, 2.0),
				(int n) => FarsiHundredsMap[n]
			}
		};
		List<string> list = new List<string>();
		foreach (int key in dictionary.Keys)
		{
			if (num / key > 0)
			{
				list.Add(dictionary[key](num / key));
				num %= key;
			}
		}
		if (num >= 20)
		{
			list.Add(FarsiTensMap[num / 10]);
			num %= 10;
		}
		if (num > 0)
		{
			list.Add(FarsiUnitsMap[num]);
		}
		return string.Join(" و ", list);
	}

	public override string ConvertToOrdinal(int number)
	{
		switch (number)
		{
		case 1:
			return "اول";
		case 3:
			return "سوم";
		default:
		{
			if (number % 10 == 3 && number != 13)
			{
				return Convert(number / 10 * 10) + " و سوم";
			}
			string text = Convert(number);
			return string.Format("{0}{1}", new object[2]
			{
				text,
				text.EndsWith("ی") ? " ام" : "م"
			});
		}
		}
	}
}
