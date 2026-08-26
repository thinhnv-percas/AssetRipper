using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords.Romanian;

internal class RomanianOrdinalNumberConverter
{
	private readonly Dictionary<int, string> _ordinalsUnder10 = new Dictionary<int, string>
	{
		{ 1, "primul|prima" },
		{ 2, "doilea|doua" },
		{ 3, "treilea|treia" },
		{ 4, "patrulea|patra" },
		{ 5, "cincilea|cincea" },
		{ 6, "șaselea|șasea" },
		{ 7, "șaptelea|șaptea" },
		{ 8, "optulea|opta" },
		{ 9, "nouălea|noua" }
	};

	private readonly string _femininePrefix = "a";

	private readonly string _masculinePrefix = "al";

	private readonly string _feminineSuffix = "a";

	private readonly string _masculineSuffix = "lea";

	public string Convert(int number, GrammaticalGender gender)
	{
		if (number == 0)
		{
			return "zero";
		}
		if (number == 1)
		{
			return getPartByGender(_ordinalsUnder10[number], gender);
		}
		if (number <= 9)
		{
			return string.Format("{0} {1}", new object[2]
			{
				(gender == GrammaticalGender.Feminine) ? _femininePrefix : _masculinePrefix,
				getPartByGender(_ordinalsUnder10[number], gender)
			});
		}
		string text = new RomanianCardinalNumberConverter().Convert(number, gender);
		text = text.Replace(" de ", " ");
		if (gender == GrammaticalGender.Feminine && text.EndsWith("zeci"))
		{
			text = text.Substring(0, text.Length - 4) + "zece";
		}
		else if (gender == GrammaticalGender.Feminine && text.Contains("zeci") && (text.Contains("milioane") || text.Contains("miliarde")))
		{
			text = text.Replace("zeci", "zecea");
		}
		if (gender == GrammaticalGender.Feminine && text.StartsWith("un "))
		{
			text = text.Substring(2).TrimStart(new char[0]);
		}
		if (text.EndsWith("milioane") && gender == GrammaticalGender.Feminine)
		{
			text = text.Substring(0, text.Length - 8) + "milioana";
		}
		string text2 = _masculineSuffix;
		if (text.EndsWith("milion"))
		{
			if (gender == GrammaticalGender.Feminine)
			{
				text = text.Substring(0, text.Length - 6) + "milioana";
			}
			else
			{
				text2 = "u" + _masculineSuffix;
			}
		}
		else if (text.EndsWith("miliard") && gender == GrammaticalGender.Masculine)
		{
			text2 = "u" + _masculineSuffix;
		}
		if (gender == GrammaticalGender.Feminine && !text.EndsWith("zece") && (text.EndsWith("a") || text.EndsWith("ă") || text.EndsWith("e") || text.EndsWith("i")))
		{
			text = text.Substring(0, text.Length - 1);
		}
		return string.Format("{0} {1}{2}", new object[3]
		{
			(gender == GrammaticalGender.Feminine) ? _femininePrefix : _masculinePrefix,
			text,
			(gender == GrammaticalGender.Feminine) ? _feminineSuffix : text2
		});
	}

	private string getPartByGender(string multiGenderPart, GrammaticalGender gender)
	{
		if (multiGenderPart.Contains("|"))
		{
			string[] array = multiGenderPart.Split(new char[1] { '|' });
			if (gender == GrammaticalGender.Feminine)
			{
				return array[1];
			}
			return array[0];
		}
		return multiGenderPart;
	}
}
