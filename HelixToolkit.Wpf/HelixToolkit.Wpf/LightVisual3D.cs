using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class LightVisual3D : ModelVisual3D
{
	public static readonly DependencyProperty LightProperty = DependencyProperty.Register("Light", typeof(Light), typeof(LightVisual3D), new UIPropertyMetadata(null, LightChanged));

	public Light Light
	{
		get
		{
			return (Light)GetValue(LightProperty);
		}
		set
		{
			SetValue(LightProperty, value);
		}
	}

	protected static void LightChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
	{
		((LightVisual3D)obj).OnLightChanged();
	}

	protected virtual void OnLightChanged()
	{
		base.Children.Clear();
		if (Light != null)
		{
			if (Light is DirectionalLight directionalLight)
			{
				ArrowVisual3D arrowVisual3D = new ArrowVisual3D();
				double num = 10.0;
				double num2 = 5.0;
				arrowVisual3D.BeginEdit();
				arrowVisual3D.Point1 = default(Point3D) + directionalLight.Direction * num;
				arrowVisual3D.Point2 = arrowVisual3D.Point1 - directionalLight.Direction * num2;
				arrowVisual3D.Diameter = 0.1 * num2;
				arrowVisual3D.Fill = new SolidColorBrush(directionalLight.Color);
				arrowVisual3D.EndEdit();
				base.Children.Add(arrowVisual3D);
			}
			if (Light is SpotLight spotLight)
			{
				SphereVisual3D sphereVisual3D = new SphereVisual3D();
				sphereVisual3D.BeginEdit();
				sphereVisual3D.Center = spotLight.Position;
				sphereVisual3D.Fill = new SolidColorBrush(spotLight.Color);
				sphereVisual3D.EndEdit();
				base.Children.Add(sphereVisual3D);
				ArrowVisual3D arrowVisual3D2 = new ArrowVisual3D();
				arrowVisual3D2.BeginEdit();
				arrowVisual3D2.Point1 = spotLight.Position;
				arrowVisual3D2.Point2 = spotLight.Position + spotLight.Direction;
				arrowVisual3D2.Diameter = 0.1;
				arrowVisual3D2.EndEdit();
				base.Children.Add(arrowVisual3D2);
			}
			if (Light is PointLight pointLight)
			{
				SphereVisual3D sphereVisual3D2 = new SphereVisual3D();
				sphereVisual3D2.BeginEdit();
				sphereVisual3D2.Center = pointLight.Position;
				sphereVisual3D2.Fill = new SolidColorBrush(pointLight.Color);
				sphereVisual3D2.EndEdit();
				base.Children.Add(sphereVisual3D2);
			}
			AmbientLight ambientLight = Light as AmbientLight;
		}
	}
}
