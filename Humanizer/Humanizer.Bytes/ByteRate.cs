using System;
using Humanizer.Localisation;

namespace Humanizer.Bytes;

public class ByteRate
{
	public ByteSize Size { get; private set; }

	public TimeSpan Interval { get; private set; }

	public ByteRate(ByteSize size, TimeSpan interval)
	{
		Size = size;
		Interval = interval;
	}

	public string Humanize(TimeUnit timeUnit = TimeUnit.Second)
	{
		return Humanize(null, timeUnit);
	}

	public string Humanize(string format, TimeUnit timeUnit = TimeUnit.Second)
	{
		TimeSpan timeSpan;
		string text;
		switch (timeUnit)
		{
		case TimeUnit.Second:
			timeSpan = TimeSpan.FromSeconds(1.0);
			text = "s";
			break;
		case TimeUnit.Minute:
			timeSpan = TimeSpan.FromMinutes(1.0);
			text = "min";
			break;
		case TimeUnit.Hour:
			timeSpan = TimeSpan.FromHours(1.0);
			text = "hour";
			break;
		default:
			throw new NotSupportedException("timeUnit must be Second, Minute, or Hour");
		}
		return new ByteSize(Size.Bytes / Interval.TotalSeconds * timeSpan.TotalSeconds).Humanize(format) + "/" + text;
	}
}
