using System;
using System.Collections.Generic;
using System.Globalization;

namespace Humanizer.Localisation.NumberToWords;

internal class HebrewNumberToWordsConverter : GenderedNumberToWordsConverter
{
	private class DescriptionAttribute : Attribute
	{
		public string Description { get; set; }

		public DescriptionAttribute(string description)
		{
			Description = description;
		}
	}

	private enum Group
	{
		Hundreds = 100,
		Thousands = 1000,
		[Description("מיליון")]
		Millions = 1000000,
		[Description("מיליארד")]
		Billions = 1000000000
	}

	private static readonly string[] UnitsFeminine = new string[11]
	{
		"אפס", "אחת", "שתיים", "שלוש", "ארבע", "חמש", "שש", "שבע", "שמונה", "תשע",
		"עשר"
	};

	private static readonly string[] UnitsMasculine = new string[11]
	{
		"אפס", "אחד", "שניים", "שלושה", "ארבעה", "חמישה", "שישה", "שבעה", "שמונה", "תשעה",
		"עשרה"
	};

	private static readonly string[] TensUnit = new string[9] { "עשר", "עשרים", "שלושים", "ארבעים", "חמישים", "שישים", "שבעים", "שמונים", "תשעים" };

	private readonly CultureInfo _culture;

	public HebrewNumberToWordsConverter(CultureInfo culture)
		: base(GrammaticalGender.Feminine)
	{
		_culture = culture;
	}

	public override string Convert(long input, GrammaticalGender gender)
	{
		if (input > int.MaxValue || input < int.MinValue)
		{
			throw new NotImplementedException();
		}
		int num = (int)input;
		if (num < 0)
		{
			return $"מינוס {Convert(-num, gender)}";
		}
		if (num == 0)
		{
			return UnitsFeminine[0];
		}
		List<string> list = new List<string>();
		if (num >= 1000000000)
		{
			ToBigNumber(num, Group.Billions, list);
			num %= 1000000000;
		}
		if (num >= 1000000)
		{
			ToBigNumber(num, Group.Millions, list);
			num %= 1000000;
		}
		if (num >= 1000)
		{
			ToThousands(num, list);
			num %= 1000;
		}
		if (num >= 100)
		{
			ToHundreds(num, list);
			num %= 100;
		}
		if (num > 0)
		{
			bool flag = list.Count != 0;
			if (num <= 10)
			{
				string text = ((gender == GrammaticalGender.Masculine) ? UnitsMasculine[num] : UnitsFeminine[num]);
				if (flag)
				{
					text = "ו" + text;
				}
				list.Add(text);
			}
			else if (num < 20)
			{
				string text2 = Convert(num % 10, gender);
				text2 = text2.Replace("יי", "י");
				text2 = string.Format("{0} {1}", new object[2]
				{
					text2,
					(gender == GrammaticalGender.Masculine) ? "עשר" : "עשרה"
				});
				if (flag)
				{
					text2 = "ו" + text2;
				}
				list.Add(text2);
			}
			else
			{
				string text3 = TensUnit[num / 10 - 1];
				if (num % 10 == 0)
				{
					list.Add(text3);
				}
				else
				{
					string text4 = Convert(num % 10, gender);
					list.Add(string.Format("{0} ו{1}", new object[2] { text3, text4 }));
				}
			}
		}
		return string.Join(" ", list);
	}

	public override string ConvertToOrdinal(int number, GrammaticalGender gender)
	{
		return number.ToString(_culture);
	}

	private void ToBigNumber(int number, Group group, List<string> parts)
	{
		int num = number / (int)group;
		if (num == 2)
		{
			parts.Add("שני");
		}
		else if (num > 2)
		{
			parts.Add(Convert(num, GrammaticalGender.Masculine));
		}
		parts.Add(group.Humanize());
	}

	private void ToThousands(int number, List<string> parts)
	{
		int num = number / 1000;
		if (num == 1)
		{
			parts.Add("אלף");
		}
		else if (num == 2)
		{
			parts.Add("אלפיים");
		}
		else if (num <= 10)
		{
			parts.Add(UnitsFeminine[num] + "ת אלפים");
		}
		else
		{
			parts.Add(Convert(num) + " אלף");
		}
	}

	private static void ToHundreds(int number, List<string> parts)
	{
		int num = number / 100;
		switch (num)
		{
		case 1:
			parts.Add("מאה");
			break;
		case 2:
			parts.Add("מאתיים");
			break;
		default:
			parts.Add(UnitsFeminine[num] + " מאות");
			break;
		}
	}
}
