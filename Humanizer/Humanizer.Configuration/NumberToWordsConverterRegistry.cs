using System;
using System.Globalization;
using Humanizer.Localisation.NumberToWords;

namespace Humanizer.Configuration;

internal class NumberToWordsConverterRegistry : LocaliserRegistry<INumberToWordsConverter>
{
	public NumberToWordsConverterRegistry()
		: base((Func<CultureInfo, INumberToWordsConverter>)((CultureInfo culture) => new DefaultNumberToWordsConverter(culture)))
	{
		Register("af", new AfrikaansNumberToWordsConverter());
		Register("en", new EnglishNumberToWordsConverter());
		Register("ar", new ArabicNumberToWordsConverter());
		Register("fa", new FarsiNumberToWordsConverter());
		Register("es", new SpanishNumberToWordsConverter());
		Register("pl", (CultureInfo culture) => new PolishNumberToWordsConverter(culture));
		Register("pt-BR", new BrazilianPortugueseNumberToWordsConverter());
		Register("ro", new RomanianNumberToWordsConverter());
		Register("ru", new RussianNumberToWordsConverter());
		Register("fi", new FinnishNumberToWordsConverter());
		Register("fr-BE", new FrenchBelgianNumberToWordsConverter());
		Register("fr-CH", new FrenchSwissNumberToWordsConverter());
		Register("fr", new FrenchNumberToWordsConverter());
		Register("nl", new DutchNumberToWordsConverter());
		Register("he", (CultureInfo culture) => new HebrewNumberToWordsConverter(culture));
		Register("sl", (CultureInfo culture) => new SlovenianNumberToWordsConverter(culture));
		Register("de", new GermanNumberToWordsConverter());
		Register("bn-BD", new BanglaNumberToWordsConverter());
		Register("tr", new TurkishNumberToWordConverter());
		Register("it", new ItalianNumberToWordsConverter());
		Register("uk", new UkrainianNumberToWordsConverter());
		Register("uz-Latn-UZ", new UzbekLatnNumberToWordConverter());
		Register("uz-Cyrl-UZ", new UzbekCyrlNumberToWordConverter());
		Register("sr", (CultureInfo culture) => new SerbianCyrlNumberToWordsConverter(culture));
		Register("sr-Latn", (CultureInfo culture) => new SerbianNumberToWordsConverter(culture));
		Register("nb", new NorwegianBokmalNumberToWordsConverter());
	}
}
