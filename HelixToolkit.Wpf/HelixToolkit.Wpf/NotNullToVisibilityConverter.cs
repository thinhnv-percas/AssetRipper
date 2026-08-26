using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace HelixToolkit.Wpf;

[ValueConversion(typeof(object), typeof(Visibility))]
public class NotNullToVisibilityConverter : IValueConverter
{
	public bool Inverted { get; set; }

	public NotNullToVisibilityConverter()
	{
		Inverted = false;
	}

	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		if (targetType == typeof(Visibility))
		{
			bool flag = value != null;
			if (flag != Inverted)
			{
				return Visibility.Visible;
			}
			return Visibility.Collapsed;
		}
		return null;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
