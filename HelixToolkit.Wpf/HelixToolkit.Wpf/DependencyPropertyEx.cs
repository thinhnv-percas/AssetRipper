using System;
using System.Windows;

namespace HelixToolkit.Wpf;

public static class DependencyPropertyEx
{
	public static DependencyProperty Register<TProperty, TOwner>(string name, TProperty defaultValue) where TOwner : DependencyObject
	{
		return DependencyProperty.Register(name, typeof(TProperty), typeof(TOwner), new FrameworkPropertyMetadata(defaultValue));
	}

	public static DependencyProperty Register<TProperty, TOwner>(string name, TProperty defaultValue, Action<TOwner, DependencyPropertyChangedEventArgs> callback) where TOwner : DependencyObject
	{
		return DependencyProperty.Register(name, typeof(TProperty), typeof(TOwner), new FrameworkPropertyMetadata(defaultValue, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			callback((TOwner)s, e);
		}));
	}
}
