using System;

namespace ImageMagick;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
internal sealed class ExifTagDescriptionAttribute : Attribute
{
	private object _value;

	private string _description;

	public ExifTagDescriptionAttribute(object value, string description)
	{
		_value = value;
		_description = description;
	}

	public static string GetDescription(ExifTag tag, object value)
	{
		ExifTagDescriptionAttribute[] customAttributes = TypeHelper.GetCustomAttributes<ExifTagDescriptionAttribute>(tag);
		if (customAttributes == null || customAttributes.Length == 0)
		{
			return null;
		}
		ExifTagDescriptionAttribute[] array = customAttributes;
		foreach (ExifTagDescriptionAttribute exifTagDescriptionAttribute in array)
		{
			if (object.Equals(exifTagDescriptionAttribute._value, value))
			{
				return exifTagDescriptionAttribute._description;
			}
		}
		return null;
	}
}
