using System;
using System.Text;

namespace Humanizer.Localisation.NumberToWords;

internal class UzbekCyrlNumberToWordConverter : GenderlessNumberToWordsConverter
{
	private static readonly string[] UnitsMap = new string[10] { "нол", "бир", "икки", "уч", "тўрт", "беш", "олти", "етти", "саккиз", "тўққиз" };

	private static readonly string[] TensMap = new string[10] { "нол", "ўн", "йигирма", "ўттиз", "қирқ", "эллик", "олтмиш", "етмиш", "саксон", "тўқсон" };

	private static readonly string[] OrdinalSuffixes = new string[2] { "инчи", "нчи" };

	public override string Convert(long input)
	{
		if (input > int.MaxValue || input < int.MinValue)
		{
			throw new NotImplementedException();
		}
		int num = (int)input;
		if (num < 0)
		{
			return $"минус {Convert(-num, checkForHoundredRule: true)}";
		}
		return Convert(num, checkForHoundredRule: true);
	}

	private string Convert(int number, bool checkForHoundredRule)
	{
		if (number == 0)
		{
			return UnitsMap[0];
		}
		if (checkForHoundredRule && number == 100)
		{
			return "юз";
		}
		StringBuilder stringBuilder = new StringBuilder();
		if (number / 1000000000 > 0)
		{
			stringBuilder.AppendFormat("{0} миллиард ", new object[1] { Convert(number / 1000000000, checkForHoundredRule: false) });
			number %= 1000000000;
		}
		if (number / 1000000 > 0)
		{
			stringBuilder.AppendFormat("{0} миллион ", new object[1] { Convert(number / 1000000, checkForHoundredRule: true) });
			number %= 1000000;
		}
		int num = number / 1000;
		if (num > 0)
		{
			stringBuilder.AppendFormat("{0} минг ", new object[1] { Convert(num, checkForHoundredRule: true) });
			number %= 1000;
		}
		int num2 = number / 100;
		if (num2 > 0)
		{
			stringBuilder.AppendFormat("{0} юз ", new object[1] { Convert(num2, checkForHoundredRule: false) });
			number %= 100;
		}
		if (number / 10 > 0)
		{
			stringBuilder.AppendFormat("{0} ", new object[1] { TensMap[number / 10] });
			number %= 10;
		}
		if (number > 0)
		{
			stringBuilder.AppendFormat("{0} ", new object[1] { UnitsMap[number] });
		}
		return stringBuilder.ToString().Trim();
	}

	public override string ConvertToOrdinal(int number)
	{
		string text = Convert(number);
		int num = 0;
		if (string.IsNullOrEmpty(text))
		{
			return string.Empty;
		}
		char c = text[text.Length - 1];
		if (c == 'и' || c == 'а')
		{
			num = 1;
		}
		return string.Format("{0}{1}", new object[2]
		{
			text,
			OrdinalSuffixes[num]
		});
	}
}
