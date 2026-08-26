using System;
using System.Globalization;
using System.Reflection;
using Humanizer.DateTimeHumanizeStrategy;
using Humanizer.Localisation.CollectionFormatters;
using Humanizer.Localisation.DateToOrdinalWords;
using Humanizer.Localisation.Formatters;
using Humanizer.Localisation.NumberToWords;
using Humanizer.Localisation.Ordinalizers;

namespace Humanizer.Configuration;

public static class Configurator
{
	private static readonly LocaliserRegistry<ICollectionFormatter> _collectionFormatters = new CollectionFormatterRegistry();

	private static readonly LocaliserRegistry<IFormatter> _formatters = new FormatterRegistry();

	private static readonly LocaliserRegistry<INumberToWordsConverter> _numberToWordsConverters = new NumberToWordsConverterRegistry();

	private static readonly LocaliserRegistry<IOrdinalizer> _ordinalizers = new OrdinalizerRegistry();

	private static readonly LocaliserRegistry<IDateToOrdinalWordConverter> _dateToOrdinalWordConverters = new DateToOrdinalWordsConverterRegistry();

	private static IDateTimeHumanizeStrategy _dateTimeHumanizeStrategy = new DefaultDateTimeHumanizeStrategy();

	private static IDateTimeOffsetHumanizeStrategy _dateTimeOffsetHumanizeStrategy = new DefaultDateTimeOffsetHumanizeStrategy();

	private static readonly Func<PropertyInfo, bool> DefaultEnumDescriptionPropertyLocator = (PropertyInfo p) => p.Name == "Description";

	private static Func<PropertyInfo, bool> _enumDescriptionPropertyLocator = DefaultEnumDescriptionPropertyLocator;

	public static LocaliserRegistry<ICollectionFormatter> CollectionFormatters => _collectionFormatters;

	public static LocaliserRegistry<IFormatter> Formatters => _formatters;

	public static LocaliserRegistry<INumberToWordsConverter> NumberToWordsConverters => _numberToWordsConverters;

	public static LocaliserRegistry<IOrdinalizer> Ordinalizers => _ordinalizers;

	public static LocaliserRegistry<IDateToOrdinalWordConverter> DateToOrdinalWordsConverters => _dateToOrdinalWordConverters;

	internal static ICollectionFormatter CollectionFormatter => CollectionFormatters.ResolveForUiCulture();

	internal static IOrdinalizer Ordinalizer => Ordinalizers.ResolveForUiCulture();

	internal static IDateToOrdinalWordConverter DateToOrdinalWordsConverter => DateToOrdinalWordsConverters.ResolveForUiCulture();

	public static IDateTimeHumanizeStrategy DateTimeHumanizeStrategy
	{
		get
		{
			return _dateTimeHumanizeStrategy;
		}
		set
		{
			_dateTimeHumanizeStrategy = value;
		}
	}

	public static IDateTimeOffsetHumanizeStrategy DateTimeOffsetHumanizeStrategy
	{
		get
		{
			return _dateTimeOffsetHumanizeStrategy;
		}
		set
		{
			_dateTimeOffsetHumanizeStrategy = value;
		}
	}

	public static Func<PropertyInfo, bool> EnumDescriptionPropertyLocator
	{
		get
		{
			return _enumDescriptionPropertyLocator;
		}
		set
		{
			_enumDescriptionPropertyLocator = value ?? DefaultEnumDescriptionPropertyLocator;
		}
	}

	internal static IFormatter GetFormatter(CultureInfo culture)
	{
		return Formatters.ResolveForCulture(culture);
	}

	internal static INumberToWordsConverter GetNumberToWordsConverter(CultureInfo culture)
	{
		return NumberToWordsConverters.ResolveForCulture(culture);
	}
}
