using System;
using System.Collections.Generic;
using System.Linq;

namespace Humanizer.Localisation.NumberToWords;

internal class ArabicNumberToWordsConverter : GenderedNumberToWordsConverter
{
	private static readonly string[] Groups = new string[8] { "مئة", "ألف", "مليون", "مليار", "تريليون", "كوادريليون", "كوينتليون", "سكستيليون" };

	private static readonly string[] AppendedGroups = new string[8] { "", "ألفا\u064b", "مليونا\u064b", "مليارا\u064b", "تريليونا\u064b", "كوادريليونا\u064b", "كوينتليونا\u064b", "سكستيليونا\u064b" };

	private static readonly string[] PluralGroups = new string[8] { "", "آلاف", "ملايين", "مليارات", "تريليونات", "كوادريليونات", "كوينتليونات", "سكستيليونات" };

	private static readonly string[] OnesGroup = new string[20]
	{
		"", "واحد", "اثنان", "ثلاثة", "أربعة", "خمسة", "ستة", "سبعة", "ثمانية", "تسعة",
		"عشرة", "أحد عشر", "اثنا عشر", "ثلاثة عشر", "أربعة عشر", "خمسة عشر", "ستة عشر", "سبعة عشر", "ثمانية عشر", "تسعة عشر"
	};

	private static readonly string[] TensGroup = new string[10] { "", "عشرة", "عشرون", "ثلاثون", "أربعون", "خمسون", "ستون", "سبعون", "ثمانون", "تسعون" };

	private static readonly string[] HundredsGroup = new string[10] { "", "مئة", "مئتان", "ثلاث مئة", "أربع مئة", "خمس مئة", "ست مئة", "سبع مئة", "ثمان مئة", "تسع مئة" };

	private static readonly string[] AppendedTwos = new string[8] { "مئتان", "ألفان", "مليونان", "ملياران", "تريليونان", "كوادريليونان", "كوينتليونان", "سكستيليونلن" };

	private static readonly string[] Twos = new string[8] { "مئتان", "ألفان", "مليونان", "ملياران", "تريليونان", "كوادريليونان", "كوينتليونان", "سكستيليونان" };

	private static readonly string[] FeminineOnesGroup = new string[20]
	{
		"", "واحدة", "اثنتان", "ثلاث", "أربع", "خمس", "ست", "سبع", "ثمان", "تسع",
		"عشر", "إحدى عشرة", "اثنتا عشرة", "ثلاث عشرة", "أربع عشرة", "خمس عشرة", "ست عشرة", "سبع عشرة", "ثمان عشرة", "تسع عشرة"
	};

	private static readonly Dictionary<string, string> OrdinalExceptions = new Dictionary<string, string>
	{
		{ "واحد", "الحادي" },
		{ "أحد", "الحادي" },
		{ "اثنان", "الثاني" },
		{ "اثنا", "الثاني" },
		{ "ثلاثة", "الثالث" },
		{ "أربعة", "الرابع" },
		{ "خمسة", "الخامس" },
		{ "ستة", "السادس" },
		{ "سبعة", "السابع" },
		{ "ثمانية", "الثامن" },
		{ "تسعة", "التاسع" },
		{ "عشرة", "العاشر" }
	};

	private static readonly Dictionary<string, string> FeminineOrdinalExceptions = new Dictionary<string, string>
	{
		{ "واحدة", "الحادية" },
		{ "إحدى", "الحادية" },
		{ "اثنتان", "الثانية" },
		{ "اثنتا", "الثانية" },
		{ "ثلاث", "الثالثة" },
		{ "أربع", "الرابعة" },
		{ "خمس", "الخامسة" },
		{ "ست", "السادسة" },
		{ "سبع", "السابعة" },
		{ "ثمان", "الثامنة" },
		{ "تسع", "التاسعة" },
		{ "عشر", "العاشرة" }
	};

	public override string Convert(long input, GrammaticalGender gender)
	{
		if (input > int.MaxValue || input < int.MinValue)
		{
			throw new NotImplementedException();
		}
		int num = (int)input;
		if (num == 0)
		{
			return "صفر";
		}
		string text = string.Empty;
		int num2 = 0;
		while (num >= 1)
		{
			int num3 = num % 1000;
			num /= 1000;
			int num4 = num3 % 100;
			int num5 = num3 / 100;
			string text2 = string.Empty;
			if (num5 > 0)
			{
				text2 = ((num4 != 0 || num5 != 2) ? HundredsGroup[num5] : AppendedTwos[0]);
			}
			if (num4 > 0)
			{
				if (num4 < 20)
				{
					if (num4 == 2 && num5 == 0 && num2 > 0)
					{
						text2 = ((num != 2000 && num != 2000000 && num != 2000000000) ? Twos[num2] : AppendedTwos[num2]);
					}
					else
					{
						if (text2 != string.Empty)
						{
							text2 += " و ";
						}
						text2 = ((num4 != 1 || num2 <= 0 || num5 != 0) ? (text2 + ((gender == GrammaticalGender.Feminine && num2 == 0) ? FeminineOnesGroup[num4] : OnesGroup[num4])) : (text2 + " "));
					}
				}
				else
				{
					int num6 = num4 % 10;
					num4 /= 10;
					if (num6 > 0)
					{
						if (text2 != string.Empty)
						{
							text2 += " و ";
						}
						text2 += ((gender == GrammaticalGender.Feminine) ? FeminineOnesGroup[num6] : OnesGroup[num6]);
					}
					if (text2 != string.Empty)
					{
						text2 += " و ";
					}
					text2 += TensGroup[num4];
				}
			}
			if (text2 != string.Empty)
			{
				if (num2 > 0)
				{
					if (text != string.Empty)
					{
						text = string.Format("{0} {1}", new object[2] { "و", text });
					}
					if (num3 != 2)
					{
						text = ((num3 % 100 == 1) ? string.Format("{0} {1}", new object[2]
						{
							Groups[num2],
							text
						}) : ((num3 < 3 || num3 > 10) ? string.Format("{0} {1}", new object[2]
						{
							(text != string.Empty) ? AppendedGroups[num2] : Groups[num2],
							text
						}) : string.Format("{0} {1}", new object[2]
						{
							PluralGroups[num2],
							text
						})));
					}
				}
				text = string.Format("{0} {1}", new object[2] { text2, text });
			}
			num2++;
		}
		return text.Trim();
	}

	public override string ConvertToOrdinal(int number, GrammaticalGender gender)
	{
		if (number == 0)
		{
			return "الصفر";
		}
		int num = number % 100;
		int num2 = number / 100 * 100;
		string text = string.Empty;
		string text2 = string.Empty;
		if (num > 0)
		{
			text = Convert(num, gender);
			text = ParseNumber(text, num, gender);
		}
		if (num2 > 0)
		{
			text2 = Convert(num2);
			text2 = ParseNumber(text2, num2, gender);
		}
		return (text + ((num2 > 0) ? ((string.IsNullOrWhiteSpace(text) ? string.Empty : " بعد ") + text2) : string.Empty)).Trim();
	}

	private static string ParseNumber(string word, int number, GrammaticalGender gender)
	{
		if (number == 1)
		{
			if (gender != GrammaticalGender.Feminine)
			{
				return "الأول";
			}
			return "الأولى";
		}
		if (number <= 10)
		{
			using IEnumerator<KeyValuePair<string, string>> enumerator = Enumerable.Where<KeyValuePair<string, string>>((IEnumerable<KeyValuePair<string, string>>)((gender == GrammaticalGender.Feminine) ? FeminineOrdinalExceptions : OrdinalExceptions), (Func<KeyValuePair<string, string>, bool>)((KeyValuePair<string, string> kv) => word.EndsWith(kv.Key))).GetEnumerator();
			if (enumerator.MoveNext())
			{
				KeyValuePair<string, string> current = enumerator.Current;
				return word.Substring(0, word.Length - current.Key.Length) + current.Value;
			}
		}
		else if (number > 10 && number < 100)
		{
			string[] array = word.Split(new char[1] { ' ' });
			string[] array2 = new string[array.Length];
			int num = 0;
			string[] array3 = array;
			foreach (string text in array3)
			{
				string text2 = text;
				string oldPart = text;
				foreach (KeyValuePair<string, string> item in Enumerable.Where<KeyValuePair<string, string>>((IEnumerable<KeyValuePair<string, string>>)((gender == GrammaticalGender.Feminine) ? FeminineOrdinalExceptions : OrdinalExceptions), (Func<KeyValuePair<string, string>, bool>)((KeyValuePair<string, string> kv) => oldPart.EndsWith(kv.Key))))
				{
					text2 = oldPart.Substring(0, oldPart.Length - item.Key.Length) + item.Value;
				}
				if (number > 19 && text2 == oldPart && oldPart.Length > 1)
				{
					text2 = "ال" + oldPart;
				}
				array2[num++] = text2;
			}
			word = string.Join(" ", array2);
		}
		else
		{
			word = "ال" + word;
		}
		return word;
	}
}
