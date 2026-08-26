using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class SunLight : LightSetup
{
	public static readonly DependencyProperty AltitudeProperty = DependencyProperty.Register("Altitude", typeof(double), typeof(SunLight), new UIPropertyMetadata(60.0, LightSetup.SetupChanged));

	public static readonly DependencyProperty AmbientProperty = DependencyProperty.Register("Ambient", typeof(double), typeof(SunLight), new UIPropertyMetadata(0.4, LightSetup.SetupChanged));

	public static readonly DependencyProperty AzimuthProperty = DependencyProperty.Register("Azimuth", typeof(double), typeof(SunLight), new UIPropertyMetadata(130.0, LightSetup.SetupChanged));

	public static readonly DependencyProperty BrightnessProperty = DependencyProperty.Register("Brightness", typeof(double), typeof(SunLight), new UIPropertyMetadata(0.6, LightSetup.SetupChanged));

	private readonly Vector3D altitudeAxis = new Vector3D(0.0, 1.0, 0.0);

	private readonly Vector3D azimuthAxis = new Vector3D(0.0, 0.0, 1.0);

	public double Altitude
	{
		get
		{
			return (double)GetValue(AltitudeProperty);
		}
		set
		{
			SetValue(AltitudeProperty, value);
		}
	}

	public double Ambient
	{
		get
		{
			return (double)GetValue(AmbientProperty);
		}
		set
		{
			SetValue(AmbientProperty, value);
		}
	}

	public double Azimuth
	{
		get
		{
			return (double)GetValue(AzimuthProperty);
		}
		set
		{
			SetValue(AzimuthProperty, value);
		}
	}

	public double Brightness
	{
		get
		{
			return (double)GetValue(BrightnessProperty);
		}
		set
		{
			SetValue(BrightnessProperty, value);
		}
	}

	protected override void AddLights(Model3DGroup lightGroup)
	{
		RotateTransform3D rotateTransform3D = new RotateTransform3D(new AxisAngleRotation3D(azimuthAxis, Azimuth));
		RotateTransform3D rotateTransform3D2 = new RotateTransform3D(new AxisAngleRotation3D(altitudeAxis, Altitude));
		Vector3D direction = rotateTransform3D.Transform(rotateTransform3D2.Transform(new Vector3D(1.0, 0.0, 0.0)));
		byte b = (byte)(255.0 * Brightness);
		lightGroup.Children.Add(new DirectionalLight(Color.FromRgb(b, b, b), direction));
		byte b2 = (byte)(255.0 * Ambient);
		lightGroup.Children.Add(new AmbientLight(Color.FromRgb(b2, b2, b2)));
	}
}
