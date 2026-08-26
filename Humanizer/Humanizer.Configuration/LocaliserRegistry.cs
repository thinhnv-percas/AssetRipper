using System;
using System.Collections.Generic;
using System.Globalization;

namespace Humanizer.Configuration;

public class LocaliserRegistry<TLocaliser> where TLocaliser : class
{
	private readonly IDictionary<string, Func<CultureInfo, TLocaliser>> _localisers = new Dictionary<string, Func<CultureInfo, TLocaliser>>();

	private readonly Func<CultureInfo, TLocaliser> _defaultLocaliser;

	public LocaliserRegistry(TLocaliser defaultLocaliser)
	{
		_defaultLocaliser = (CultureInfo culture) => defaultLocaliser;
	}

	public LocaliserRegistry(Func<CultureInfo, TLocaliser> defaultLocaliser)
	{
		_defaultLocaliser = defaultLocaliser;
	}

	public TLocaliser ResolveForUiCulture()
	{
		return ResolveForCulture(null);
	}

	public TLocaliser ResolveForCulture(CultureInfo culture)
	{
		return FindLocaliser(culture ?? CultureInfo.CurrentUICulture)(culture);
	}

	public void Register(string localeCode, TLocaliser localiser)
	{
		_localisers[localeCode] = (CultureInfo culture) => localiser;
	}

	public void Register(string localeCode, Func<CultureInfo, TLocaliser> localiser)
	{
		_localisers[localeCode] = localiser;
	}

	private Func<CultureInfo, TLocaliser> FindLocaliser(CultureInfo culture)
	{
		if (_localisers.TryGetValue(culture.Name, out var value))
		{
			return value;
		}
		if (_localisers.TryGetValue(culture.TwoLetterISOLanguageName, out value))
		{
			return value;
		}
		return _defaultLocaliser;
	}
}
