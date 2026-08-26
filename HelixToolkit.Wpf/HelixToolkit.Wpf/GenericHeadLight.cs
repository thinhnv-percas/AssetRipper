using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public abstract class GenericHeadLight<T> : LightSetup where T : Light, new()
{
	public static readonly DependencyProperty BrightnessProperty = DependencyProperty.Register("Brightness", typeof(double), typeof(GenericHeadLight<T>), new PropertyMetadata(1.0, Update));

	public static readonly DependencyProperty ColorProperty = DependencyProperty.Register("Color", typeof(Color), typeof(GenericHeadLight<T>), new PropertyMetadata(Colors.White, Update));

	public static readonly DependencyProperty PositionProperty = DependencyProperty.Register("Position", typeof(Point3D), typeof(GenericHeadLight<T>), new PropertyMetadata(new Point3D(0.0, 0.0, 3.0), Update));

	private T light;

	private Camera camera;

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

	public Color Color
	{
		get
		{
			return (Color)GetValue(ColorProperty);
		}
		set
		{
			SetValue(ColorProperty, value);
		}
	}

	public Point3D Position
	{
		get
		{
			return (Point3D)GetValue(PositionProperty);
		}
		set
		{
			SetValue(PositionProperty, value);
		}
	}

	protected override void OnVisualParentChanged(DependencyObject oldParent)
	{
		base.OnVisualParentChanged(oldParent);
		Viewport3D viewport3D = this.GetViewport3D();
		if (camera != null)
		{
			camera.Changed -= CameraChanged;
		}
		camera = viewport3D?.Camera;
		if (camera != null)
		{
			camera.Changed += CameraChanged;
		}
		Update();
	}

	protected override void AddLights(Model3DGroup lightGroup)
	{
		light = new T();
		lightGroup.Children.Add(light);
	}

	private static void Update(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((GenericHeadLight<T>)d).Update();
	}

	private void CameraChanged(object sender, EventArgs e)
	{
		Update();
	}

	private void Update()
	{
		if (!double.IsNaN(Brightness))
		{
			byte b = (byte)(Brightness * 255.0);
			light.Color = Color.FromArgb(byte.MaxValue, b, b, b);
		}
		else
		{
			light.Color = Color;
		}
		if (camera is ProjectionCamera { LookDirection: var lookDirection } projectionCamera)
		{
			Vector3D vector3D = Vector3D.CrossProduct(projectionCamera.LookDirection, projectionCamera.UpDirection);
			vector3D.Normalize();
			lookDirection.Normalize();
			Vector3D vector3D2 = Vector3D.CrossProduct(vector3D, lookDirection);
			Point3D point3D = projectionCamera.Position + Position.X * vector3D + Position.Y * lookDirection + Position.Z * vector3D2;
			Point3D point3D2 = projectionCamera.Position + projectionCamera.LookDirection;
			Vector3D direction = point3D2 - point3D;
			direction.Normalize();
			if (light is SpotLight spotLight)
			{
				spotLight.Position = point3D;
				spotLight.Direction = direction;
			}
			if (light is DirectionalLight directionalLight)
			{
				directionalLight.Direction = direction;
			}
		}
	}
}
