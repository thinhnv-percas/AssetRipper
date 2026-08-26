using System;
using System.Globalization;

namespace Humanizer.Localisation.Formatters;

public class DefaultFormatter : IFormatter
{
	private readonly CultureInfo _culture;

	public DefaultFormatter(string localeCode)
	{
		_culture = new CultureInfo(localeCode);
	}

	public virtual string DateHumanize_Now()
	{
		return GetResourceForDate(TimeUnit.Millisecond, Tense.Past, 0);
	}

	public virtual string DateHumanize_Never()
	{
		return Format("DateHumanize_Never");
	}

	public virtual string DateHumanize(TimeUnit timeUnit, Tense timeUnitTense, int unit)
	{
		return GetResourceForDate(timeUnit, timeUnitTense, unit);
	}

	public virtual string TimeSpanHumanize_Zero()
	{
		return GetResourceForTimeSpan(TimeUnit.Millisecond, 0);
	}

	public virtual string TimeSpanHumanize(TimeUnit timeUnit, int unit)
	{
		return GetResourceForTimeSpan(timeUnit, unit);
	}

	private string GetResourceForDate(TimeUnit unit, Tense timeUnitTense, int count)
	{
		string resourceKey = ResourceKeys.DateHumanize.GetResourceKey(unit, timeUnitTense, count);
		if (count != 1)
		{
			return Format(resourceKey, count);
		}
		return Format(resourceKey);
	}

	private string GetResourceForTimeSpan(TimeUnit unit, int count)
	{
		string resourceKey = ResourceKeys.TimeSpanHumanize.GetResourceKey(unit, count);
		if (count != 1)
		{
			return Format(resourceKey, count);
		}
		return Format(resourceKey);
	}

	protected virtual string Format(string resourceKey)
	{
		string resource = Resources.GetResource(GetResourceKey(resourceKey), _culture);
		if (string.IsNullOrEmpty(resource))
		{
			throw new ArgumentException($"The resource object with key '{resourceKey}' was not found", "resourceKey");
		}
		return resource;
	}

	protected virtual string Format(string resourceKey, int number)
	{
		string resource = Resources.GetResource(GetResourceKey(resourceKey, number), _culture);
		if (string.IsNullOrEmpty(resource))
		{
			throw new ArgumentException($"The resource object with key '{resourceKey}' was not found", "resourceKey");
		}
		return resource.FormatWith(number);
	}

	protected virtual string GetResourceKey(string resourceKey, int number)
	{
		return resourceKey;
	}

	protected virtual string GetResourceKey(string resourceKey)
	{
		return resourceKey;
	}
}
