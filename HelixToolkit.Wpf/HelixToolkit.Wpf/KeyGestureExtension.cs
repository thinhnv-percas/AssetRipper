using System;
using System.Windows.Input;
using System.Windows.Markup;

namespace HelixToolkit.Wpf;

public class KeyGestureExtension : MarkupExtension
{
	private KeyGesture gesture;

	public KeyGestureExtension(string gesture)
	{
		KeyGestureConverter keyGestureConverter = new KeyGestureConverter();
		this.gesture = keyGestureConverter.ConvertFromString(gesture) as KeyGesture;
	}

	public override object ProvideValue(IServiceProvider service)
	{
		return gesture;
	}
}
