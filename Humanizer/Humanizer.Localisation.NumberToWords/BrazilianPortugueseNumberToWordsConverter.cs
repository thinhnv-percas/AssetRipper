using System;
using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords;

internal class BrazilianPortugueseNumberToWordsConverter : GenderedNumberToWordsConverter
{
	private static readonly string[] PortugueseUnitsMap = new string[20]
	{
		"zero", "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove",
		"dez", "onze", "doze", "treze", "quatorze", "quinze", "dezesseis", "dezessete", "dezoito", "dezenove"
	};

	private static readonly string[] PortugueseTensMap = new string[10] { "zero", "dez", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa" };

	private static readonly string[] PortugueseHundredsMap = new string[10] { "zero", "cento", "duzentos", "trezentos", "quatrocentos", "quinhentos", "seiscentos", "setecentos", "oitocentos", "novecentos" };

	private static readonly string[] PortugueseOrdinalUnitsMap = new string[10] { "zero", "primeiro", "segundo", "terceiro", "quarto", "quinto", "sexto", "sétimo", "oitavo", "nono" };

	private static readonly string[] PortugueseOrdinalTensMap = new string[10] { "zero", "décimo", "vigésimo", "trigésimo", "quadragésimo", "quinquagésimo", "sexagésimo", "septuagésimo", "octogésimo", "nonagésimo" };

	private static readonly string[] PortugueseOrdinalHundredsMap = new string[10] { "zero", "centésimo", "ducentésimo", "trecentésimo", "quadringentésimo", "quingentésimo", "sexcentésimo", "septingentésimo", "octingentésimo", "noningentésimo" };

	public override string Convert(long input, GrammaticalGender gender)
	{
		if (input > int.MaxValue || input < int.MinValue)
		{
			throw new NotImplementedException();
		}
		int num = (int)input;
		if (num == 0)
		{
			return "zero";
		}
		if (num < 0)
		{
			return $"menos {Convert(Math.Abs(num), gender)}";
		}
		List<string> list = new List<string>();
		if (num / 1000000000 > 0)
		{
			list.Add((num / 1000000000 > 2) ? $"{Convert(num / 1000000000, GrammaticalGender.Masculine)} bilhões" : $"{Convert(num / 1000000000, GrammaticalGender.Masculine)} bilhão");
			num %= 1000000000;
		}
		if (num / 1000000 > 0)
		{
			list.Add((num / 1000000 > 2) ? $"{Convert(num / 1000000, GrammaticalGender.Masculine)} milhões" : $"{Convert(num / 1000000, GrammaticalGender.Masculine)} milhão");
			num %= 1000000;
		}
		if (num / 1000 > 0)
		{
			list.Add((num / 1000 == 1) ? "mil" : $"{Convert(num / 1000, GrammaticalGender.Masculine)} mil");
			num %= 1000;
		}
		if (num / 100 > 0)
		{
			if (num == 100)
			{
				list.Add((list.Count > 0) ? "e cem" : "cem");
			}
			else
			{
				list.Add(ApplyGender(PortugueseHundredsMap[num / 100], gender));
			}
			num %= 100;
		}
		if (num > 0)
		{
			if (list.Count != 0)
			{
				list.Add("e");
			}
			if (num < 20)
			{
				list.Add(ApplyGender(PortugueseUnitsMap[num], gender));
			}
			else
			{
				string text = PortugueseTensMap[num / 10];
				if (num % 10 > 0)
				{
					text += $" e {ApplyGender(PortugueseUnitsMap[num % 10], gender)}";
				}
				list.Add(text);
			}
		}
		return string.Join(" ", list.ToArray());
	}

	public override string ConvertToOrdinal(int number, GrammaticalGender gender)
	{
		if (number == 0)
		{
			return "zero";
		}
		List<string> list = new List<string>();
		if (number / 1000000000 > 0)
		{
			list.Add((number / 1000000000 == 1) ? ApplyOrdinalGender("bilionésimo", gender) : string.Format("{0} " + ApplyOrdinalGender("bilionésimo", gender), new object[1] { ConvertToOrdinal(number / 1000000000, gender) }));
			number %= 1000000000;
		}
		if (number / 1000000 > 0)
		{
			list.Add((number / 1000000 == 1) ? ApplyOrdinalGender("milionésimo", gender) : string.Format("{0}" + ApplyOrdinalGender("milionésimo", gender), new object[1] { ConvertToOrdinal(number / 1000000000, gender) }));
			number %= 1000000;
		}
		if (number / 1000 > 0)
		{
			list.Add((number / 1000 == 1) ? ApplyOrdinalGender("milésimo", gender) : string.Format("{0} " + ApplyOrdinalGender("milésimo", gender), new object[1] { ConvertToOrdinal(number / 1000, gender) }));
			number %= 1000;
		}
		if (number / 100 > 0)
		{
			list.Add(ApplyOrdinalGender(PortugueseOrdinalHundredsMap[number / 100], gender));
			number %= 100;
		}
		if (number / 10 > 0)
		{
			list.Add(ApplyOrdinalGender(PortugueseOrdinalTensMap[number / 10], gender));
			number %= 10;
		}
		if (number > 0)
		{
			list.Add(ApplyOrdinalGender(PortugueseOrdinalUnitsMap[number], gender));
		}
		return string.Join(" ", list.ToArray());
	}

	private static string ApplyGender(string toWords, GrammaticalGender gender)
	{
		if (gender != GrammaticalGender.Feminine)
		{
			return toWords;
		}
		if (toWords.EndsWith("os"))
		{
			return toWords.Substring(0, toWords.Length - 2) + "as";
		}
		if (toWords.EndsWith("um"))
		{
			return toWords.Substring(0, toWords.Length - 2) + "uma";
		}
		if (toWords.EndsWith("dois"))
		{
			return toWords.Substring(0, toWords.Length - 4) + "duas";
		}
		return toWords;
	}

	private static string ApplyOrdinalGender(string toWords, GrammaticalGender gender)
	{
		if (gender == GrammaticalGender.Feminine)
		{
			return toWords.TrimEnd(new char[1] { 'o' }) + "a";
		}
		return toWords;
	}
}
