using System;
using System.ComponentModel;
using System.Globalization;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class TextLocationConverter : TypeConverter
{
	public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
	{
		return sourceType == typeof(string) || ((TypeConverter)this).CanConvertFrom(context, sourceType);
	}

	public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
	{
		return destinationType == typeof(TextLocation) || ((TypeConverter)this).CanConvertTo(context, destinationType);
	}

	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		if (value is string)
		{
			string[] array = ((string)value).Split(';', ',');
			if (array.Length == 2)
			{
				return new TextLocation(int.Parse(array[0]), int.Parse(array[1]));
			}
		}
		return ((TypeConverter)this).ConvertFrom(context, culture, value);
	}

	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (value is TextLocation textLocation)
		{
			return textLocation.Line + ";" + textLocation.Column;
		}
		return ((TypeConverter)this).ConvertTo(context, culture, value, destinationType);
	}
}
