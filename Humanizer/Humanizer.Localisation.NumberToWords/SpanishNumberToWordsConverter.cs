using System;
using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords;

internal class SpanishNumberToWordsConverter : GenderedNumberToWordsConverter
{
	private static readonly string[] UnitsMap = new string[30]
	{
		"cero", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve",
		"diez", "once", "doce", "trece", "catorce", "quince", "dieciséis", "diecisiete", "dieciocho", "diecinueve",
		"veinte", "veintiuno", "veintidós", "veintitrés", "veinticuatro", "veinticinco", "veintiséis", "veintisiete", "veintiocho", "veintinueve"
	};

	private const string Feminine1 = "una";

	private const string Feminine21 = "veintiuna";

	private static readonly string[] TensMap = new string[10] { "cero", "diez", "veinte", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa" };

	private static readonly string[] HundredsMap = new string[10] { "cero", "ciento", "doscientos", "trescientos", "cuatrocientos", "quinientos", "seiscientos", "setecientos", "ochocientos", "novecientos" };

	private static readonly string[] FeminineHundredsMap = new string[10] { "cero", "ciento", "doscientas", "trescientas", "cuatrocientas", "quinientas", "seiscientas", "setecientas", "ochocientas", "novecientas" };

	private static readonly Dictionary<int, string> Ordinals = new Dictionary<int, string>
	{
		{ 1, "primero" },
		{ 2, "segundo" },
		{ 3, "tercero" },
		{ 4, "quarto" },
		{ 5, "quinto" },
		{ 6, "sexto" },
		{ 7, "séptimo" },
		{ 8, "octavo" },
		{ 9, "noveno" },
		{ 10, "décimo" }
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
			return "cero";
		}
		if (num < 0)
		{
			return $"menos {Convert(Math.Abs(num))}";
		}
		List<string> list = new List<string>();
		if (num / 1000000000 > 0)
		{
			list.Add((num / 1000000000 == 1) ? "mil millones" : $"{Convert(num / 1000000000)} mil millones");
			num %= 1000000000;
		}
		if (num / 1000000 > 0)
		{
			list.Add((num / 1000000 == 1) ? "un millón" : $"{Convert(num / 1000000)} millones");
			num %= 1000000;
		}
		if (num / 1000 > 0)
		{
			list.Add((num / 1000 == 1) ? "mil" : $"{Convert(num / 1000, gender)} mil");
			num %= 1000;
		}
		if (num / 100 > 0)
		{
			list.Add((num == 100) ? "cien" : ((gender == GrammaticalGender.Feminine) ? FeminineHundredsMap[num / 100] : HundredsMap[num / 100]));
			num %= 100;
		}
		if (num > 0)
		{
			if (num < 30)
			{
				if (gender == GrammaticalGender.Feminine && (num == 1 || num == 21))
				{
					list.Add((num == 1) ? "una" : "veintiuna");
				}
				else
				{
					list.Add(UnitsMap[num]);
				}
			}
			else
			{
				string text = TensMap[num / 10];
				int num2 = num % 10;
				if (num2 == 1 && gender == GrammaticalGender.Feminine)
				{
					text += " y una";
				}
				else if (num2 > 0)
				{
					text += $" y {UnitsMap[num % 10]}";
				}
				list.Add(text);
			}
		}
		return string.Join(" ", list.ToArray());
	}

	public override string ConvertToOrdinal(int number, GrammaticalGender gender)
	{
		if (!Ordinals.TryGetValue(number, out var value))
		{
			value = Convert(number);
		}
		if (gender == GrammaticalGender.Feminine)
		{
			value = value.TrimEnd(new char[1] { 'o' }) + "a";
		}
		else if (number % 10 == 1 || number % 10 == 3)
		{
			value = value.TrimEnd(new char[1] { 'o' });
		}
		return value;
	}
}
