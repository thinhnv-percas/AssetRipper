using System;
using Humanizer.Configuration;

namespace Humanizer;

public static class DateToOrdinalWordsExtensions
{
	public static string ToOrdinalWords(this DateTime input)
	{
		return Configurator.DateToOrdinalWordsConverter.Convert(input);
	}

	public static string ToOrdinalWords(this DateTime input, GrammaticalCase grammaticalCase)
	{
		return Configurator.DateToOrdinalWordsConverter.Convert(input, grammaticalCase);
	}
}
