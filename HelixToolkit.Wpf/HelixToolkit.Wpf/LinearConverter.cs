using System;
using System.Globalization;
using System.Windows.Data;

namespace HelixToolkit.Wpf;

public class LinearConverter : IValueConverter
{
	public double B { get; set; }

	public double M { get; set; }

	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		double doubleValue = GetDoubleValue(parameter, M);
		double doubleValue2 = GetDoubleValue(value, 0.0);
		return doubleValue * doubleValue2 + B;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		double doubleValue = GetDoubleValue(parameter, M);
		double doubleValue2 = GetDoubleValue(value, 0.0);
		return (doubleValue2 - B) / doubleValue;
	}

	private double GetDoubleValue(object parameter, double defaultValue)
	{
		if (parameter != null)
		{
			try
			{
				return System.Convert.ToDouble(parameter, CultureInfo.InvariantCulture);
			}
			catch
			{
				return defaultValue;
			}
		}
		return defaultValue;
	}
}
