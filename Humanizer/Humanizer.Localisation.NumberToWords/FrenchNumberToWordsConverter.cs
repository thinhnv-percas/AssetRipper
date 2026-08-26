using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords;

internal class FrenchNumberToWordsConverter : FrenchNumberToWordsConverterBase
{
	protected override void CollectPartsUnderAHundred(ICollection<string> parts, ref int number, GrammaticalGender gender, bool pluralize)
	{
		if (number == 71)
		{
			parts.Add("soixante et onze");
		}
		else if (number == 80)
		{
			parts.Add(pluralize ? "quatre-vingts" : "quatre-vingt");
		}
		else if (number >= 70)
		{
			int num = ((number < 80) ? 60 : 80);
			int number2 = number - num;
			int tens = num / 10;
			parts.Add(string.Format("{0}-{1}", new object[2]
			{
				GetTens(tens),
				FrenchNumberToWordsConverterBase.GetUnits(number2, gender)
			}));
		}
		else
		{
			base.CollectPartsUnderAHundred(parts, ref number, gender, pluralize);
		}
	}

	protected override string GetTens(int tens)
	{
		if (tens == 8)
		{
			return "quatre-vingt";
		}
		return base.GetTens(tens);
	}
}
