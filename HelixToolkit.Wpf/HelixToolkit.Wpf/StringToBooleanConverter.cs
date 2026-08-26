using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace HelixToolkit.Wpf;

[ValueConversion(typeof(string), typeof(bool))]
public class StringToBooleanConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		if (value == null || parameter == null)
		{
			return DependencyProperty.UnsetValue;
		}
		string text = value.ToString();
		string value2 = parameter.ToString();
		return text.Equals(value2, StringComparison.OrdinalIgnoreCase);
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		if ((bool)value)
		{
			return parameter;
		}
		return DependencyProperty.UnsetValue;
	}
}
