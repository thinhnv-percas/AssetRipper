using System;
using System.Collections.Generic;
using System.Globalization;

namespace ImageMagick;

internal static class EnumHelper
{
	public static string ConvertFlags<TEnum>(TEnum value) where TEnum : struct, IConvertible
	{
		List<string> list = new List<string>();
		foreach (TEnum value2 in Enum.GetValues(typeof(TEnum)))
		{
			if (HasFlag(value, value2))
			{
				list.Add(Enum.GetName(typeof(TEnum), value2));
			}
		}
		return string.Join(",", list.ToArray());
	}

	public static string GetName<TEnum>(TEnum value) where TEnum : struct, IConvertible
	{
		return Enum.GetName(typeof(TEnum), value);
	}

	public static bool HasFlag<TEnum>(TEnum value, TEnum flag) where TEnum : struct, IConvertible
	{
		uint num = flag.ToUInt32(CultureInfo.InvariantCulture);
		return (value.ToUInt32(CultureInfo.InvariantCulture) & num) == num;
	}

	public static TEnum Parse<TEnum>(int value, TEnum defaultValue) where TEnum : struct, IConvertible
	{
		foreach (TEnum value2 in Enum.GetValues(typeof(TEnum)))
		{
			if (value == value2.ToInt32(CultureInfo.InvariantCulture))
			{
				return value2;
			}
		}
		return defaultValue;
	}

	public static TEnum Parse<TEnum>(string value, TEnum defaultValue) where TEnum : struct, IConvertible
	{
		if (string.IsNullOrEmpty(value))
		{
			return defaultValue;
		}
		string[] names = Enum.GetNames(typeof(TEnum));
		foreach (string text in names)
		{
			if (text.Equals(value, StringComparison.OrdinalIgnoreCase))
			{
				return (TEnum)Enum.Parse(typeof(TEnum), text);
			}
		}
		return defaultValue;
	}

	public static TEnum? Parse<TEnum>(string value) where TEnum : struct, IConvertible
	{
		string[] names = Enum.GetNames(typeof(TEnum));
		foreach (string text in names)
		{
			if (text.Equals(value, StringComparison.OrdinalIgnoreCase))
			{
				return (TEnum?)Enum.Parse(typeof(TEnum), text);
			}
		}
		return null;
	}

	public static object Parse(Type enumType, string value)
	{
		string[] names = Enum.GetNames(enumType);
		foreach (string text in names)
		{
			if (text.Equals(value, StringComparison.OrdinalIgnoreCase))
			{
				return Enum.Parse(enumType, text);
			}
		}
		return null;
	}
}
