using System.Windows;

namespace HelixToolkit.Wpf;

public static class AttachedProperties
{
	public static readonly DependencyProperty NameProperty = DependencyProperty.RegisterAttached("Name", typeof(string), typeof(DependencyObject), new PropertyMetadata(null));

	public static string GetName(this DependencyObject obj)
	{
		return (string)obj.GetValue(NameProperty);
	}

	public static void SetName(this DependencyObject obj, string value)
	{
		obj.SetValue(NameProperty, value);
	}
}
