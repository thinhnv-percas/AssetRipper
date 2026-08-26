using System.Windows;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class Exploder3D : ModelVisual3D
{
	public static readonly DependencyProperty IsExplodingProperty = DependencyProperty.Register("IsExploding", typeof(bool), typeof(Exploder3D), new UIPropertyMetadata(false, IsExplodingChanged));

	public bool IsExploding
	{
		get
		{
			return (bool)GetValue(IsExplodingProperty);
		}
		set
		{
			SetValue(IsExplodingProperty, value);
		}
	}

	private static void IsExplodingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((Exploder3D)d).OnIsExplodingChanged();
	}

	protected virtual void OnIsExplodingChanged()
	{
	}
}
