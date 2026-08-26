using System;
using System.Collections.Generic;
using System.Globalization;

namespace ImageMagick.Defines;

public abstract class DefinesCreator : IDefines
{
	public abstract IEnumerable<IDefine> Defines { get; }

	protected MagickFormat Format { get; private set; }

	protected DefinesCreator(MagickFormat format)
	{
		Format = format;
	}

	protected MagickDefine CreateDefine(string name, bool value)
	{
		return new MagickDefine(Format, name, value.ToString());
	}

	protected MagickDefine CreateDefine(string name, int value)
	{
		return new MagickDefine(Format, name, value.ToString(CultureInfo.InvariantCulture));
	}

	protected MagickDefine CreateDefine(string name, MagickGeometry value)
	{
		if (value == null)
		{
			return null;
		}
		return new MagickDefine(Format, name, value.ToString());
	}

	protected MagickDefine CreateDefine(string name, string value)
	{
		return new MagickDefine(Format, name, value);
	}

	protected MagickDefine CreateDefine<TEnum>(string name, TEnum value) where TEnum : struct
	{
		return new MagickDefine(Format, name, Enum.GetName(typeof(TEnum), value));
	}

	protected MagickDefine CreateDefine<T>(string name, IEnumerable<T> value)
	{
		if (value == null)
		{
			return null;
		}
		List<string> list = new List<string>();
		foreach (T item in value)
		{
			list.Add(item.ToString());
		}
		if (list.Count == 0)
		{
			return null;
		}
		return new MagickDefine(Format, name, string.Join(",", list.ToArray()));
	}
}
