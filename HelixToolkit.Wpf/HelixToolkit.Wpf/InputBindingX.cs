using System.Windows;
using System.Windows.Input;

namespace HelixToolkit.Wpf;

public class InputBindingX : InputBinding
{
	public static readonly DependencyProperty GeztureProperty = DependencyProperty.Register("Gezture", typeof(InputGesture), typeof(InputBindingX), new UIPropertyMetadata(null, GeztureChanged));

	public InputGesture Gezture
	{
		get
		{
			return (InputGesture)GetValue(GeztureProperty);
		}
		set
		{
			SetValue(GeztureProperty, value);
		}
	}

	private static void GeztureChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((InputBindingX)d).OnGeztureChanged();
	}

	protected virtual void OnGeztureChanged()
	{
		Gesture = Gezture;
	}
}
