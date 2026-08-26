using System;
using System.Globalization;

namespace ImageMagick;

internal static class MagickConverter
{
	public static T Convert<T>(object value)
	{
		if (value == null)
		{
			return default(T);
		}
		Type typeFromHandle = typeof(T);
		Type type = value.GetType();
		if (type == typeFromHandle)
		{
			return (T)value;
		}
		if (type == typeof(string))
		{
			return Convert<T>((string)value);
		}
		if (typeFromHandle == typeof(Percentage))
		{
			if (type == typeof(int))
			{
				return (T)(object)new Percentage((int)value);
			}
			if (type == typeof(double))
			{
				return (T)(object)new Percentage((double)value);
			}
		}
		return (T)System.Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
	}

	public static T Convert<T>(string value)
	{
		Type type = typeof(T);
		if (type == typeof(string))
		{
			return (T)(object)value;
		}
		if (string.IsNullOrEmpty(value))
		{
			return default(T);
		}
		if (TypeHelper.IsGeneric(type) && TypeHelper.IsNullable(type))
		{
			type = TypeHelper.GetGenericArguments(type)[0];
		}
		if (TypeHelper.IsEnum(type))
		{
			return (T)EnumHelper.Parse(type, value);
		}
		if (type == typeof(bool))
		{
			return (T)(object)(value == "1" || value == "true");
		}
		if (type == typeof(Density))
		{
			return (T)(object)new Density(value);
		}
		if (type == typeof(MagickColor))
		{
			return (T)(object)new MagickColor(value);
		}
		if (type == typeof(MagickGeometry))
		{
			return (T)(object)new MagickGeometry(value);
		}
		if (type == typeof(Percentage))
		{
			return (T)(object)new Percentage((double)System.Convert.ChangeType(value, typeof(double), CultureInfo.InvariantCulture));
		}
		if (type == typeof(PointD))
		{
			return (T)(object)new PointD(value);
		}
		return (T)System.Convert.ChangeType(value, type, CultureInfo.InvariantCulture);
	}
}
