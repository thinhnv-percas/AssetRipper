using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class ThreePointLights : LightSetup
{
	public static readonly DependencyProperty DistanceProperty = DependencyProperty.Register("Distance", typeof(double), typeof(ThreePointLights), new UIPropertyMetadata(10.0, LightSetup.SetupChanged));

	public static readonly DependencyProperty FillLightAngleProperty = DependencyProperty.Register("FillLightAngle", typeof(double), typeof(ThreePointLights), new UIPropertyMetadata(45.0, LightSetup.SetupChanged));

	public static readonly DependencyProperty FillLightSideAngleProperty = DependencyProperty.Register("FillLightSideAngle", typeof(double), typeof(ThreePointLights), new UIPropertyMetadata(-20.0, LightSetup.SetupChanged));

	public static readonly DependencyProperty FrontDirectionProperty = DependencyProperty.Register("FrontDirection", typeof(Vector3D), typeof(ThreePointLights), new UIPropertyMetadata(new Vector3D(0.0, 1.0, 0.0), LightSetup.SetupChanged));

	public static readonly DependencyProperty KeyLightAngleProperty = DependencyProperty.Register("KeyLightAngle", typeof(double), typeof(ThreePointLights), new UIPropertyMetadata(30.0, LightSetup.SetupChanged));

	public static readonly DependencyProperty KeyLightBrightnessProperty = DependencyProperty.Register("KeyLightBrightness", typeof(double), typeof(ThreePointLights), new UIPropertyMetadata(1.0, LightSetup.SetupChanged));

	public static readonly DependencyProperty KeyLightSideAngleProperty = DependencyProperty.Register("KeyLightSideAngle", typeof(double), typeof(ThreePointLights), new UIPropertyMetadata(45.0, LightSetup.SetupChanged));

	public static readonly DependencyProperty KeyToFillLightRatioProperty = DependencyProperty.Register("KeyToFillLightRatio", typeof(double), typeof(ThreePointLights), new UIPropertyMetadata(2.0, LightSetup.SetupChanged));

	public static readonly DependencyProperty KeyToRimLightRatioProperty = DependencyProperty.Register("KeyToRimLightRatio", typeof(double), typeof(ThreePointLights), new UIPropertyMetadata(1.0, LightSetup.SetupChanged));

	public static readonly DependencyProperty RimLightAngleProperty = DependencyProperty.Register("RimLightAngle", typeof(double), typeof(ThreePointLights), new UIPropertyMetadata(20.0, LightSetup.SetupChanged));

	public static readonly DependencyProperty TargetProperty = DependencyProperty.Register("Target", typeof(Point3D), typeof(ThreePointLights), new UIPropertyMetadata(new Point3D(0.0, 0.0, 0.0), LightSetup.SetupChanged));

	public static readonly DependencyProperty UpDirectionProperty = DependencyProperty.Register("UpDirection", typeof(Vector3D), typeof(ThreePointLights), new UIPropertyMetadata(new Vector3D(0.0, 0.0, 1.0), LightSetup.SetupChanged));

	public double Distance
	{
		get
		{
			return (double)GetValue(DistanceProperty);
		}
		set
		{
			SetValue(DistanceProperty, value);
		}
	}

	public double FillLightAngle
	{
		get
		{
			return (double)GetValue(FillLightAngleProperty);
		}
		set
		{
			SetValue(FillLightAngleProperty, value);
		}
	}

	public double FillLightSideAngle
	{
		get
		{
			return (double)GetValue(FillLightSideAngleProperty);
		}
		set
		{
			SetValue(FillLightSideAngleProperty, value);
		}
	}

	public Vector3D FrontDirection
	{
		get
		{
			return (Vector3D)GetValue(FrontDirectionProperty);
		}
		set
		{
			SetValue(FrontDirectionProperty, value);
		}
	}

	public double KeyLightAngle
	{
		get
		{
			return (double)GetValue(KeyLightAngleProperty);
		}
		set
		{
			SetValue(KeyLightAngleProperty, value);
		}
	}

	public double KeyLightBrightness
	{
		get
		{
			return (double)GetValue(KeyLightBrightnessProperty);
		}
		set
		{
			SetValue(KeyLightBrightnessProperty, value);
		}
	}

	public double KeyLightSideAngle
	{
		get
		{
			return (double)GetValue(KeyLightSideAngleProperty);
		}
		set
		{
			SetValue(KeyLightSideAngleProperty, value);
		}
	}

	public double KeyToFillLightRatio
	{
		get
		{
			return (double)GetValue(KeyToFillLightRatioProperty);
		}
		set
		{
			SetValue(KeyToFillLightRatioProperty, value);
		}
	}

	public double KeyToRimLightRatio
	{
		get
		{
			return (double)GetValue(KeyToRimLightRatioProperty);
		}
		set
		{
			SetValue(KeyToRimLightRatioProperty, value);
		}
	}

	public double RimLightAngle
	{
		get
		{
			return (double)GetValue(RimLightAngleProperty);
		}
		set
		{
			SetValue(RimLightAngleProperty, value);
		}
	}

	public Point3D Target
	{
		get
		{
			return (Point3D)GetValue(TargetProperty);
		}
		set
		{
			SetValue(TargetProperty, value);
		}
	}

	public Vector3D UpDirection
	{
		get
		{
			return (Vector3D)GetValue(UpDirectionProperty);
		}
		set
		{
			SetValue(UpDirectionProperty, value);
		}
	}

	protected override void AddLights(Model3DGroup lightGroup)
	{
		Vector3D upDirection = UpDirection;
		Vector3D frontDirection = FrontDirection;
		upDirection.Normalize();
		frontDirection.Normalize();
		Vector3D axis = Vector3D.CrossProduct(UpDirection, FrontDirection);
		RotateTransform3D rotateTransform3D = new RotateTransform3D(new AxisAngleRotation3D(upDirection, KeyLightSideAngle));
		RotateTransform3D rotateTransform3D2 = new RotateTransform3D(new AxisAngleRotation3D(axis, KeyLightAngle));
		Vector3D vector = frontDirection * Distance;
		vector = rotateTransform3D.Transform(vector);
		vector = rotateTransform3D2.Transform(vector);
		byte b = (byte)(255.0 * KeyLightBrightness);
		lightGroup.Children.Add(new PointLight(Color.FromRgb(b, b, b), Target - vector));
		RotateTransform3D rotateTransform3D3 = new RotateTransform3D(new AxisAngleRotation3D(upDirection, FillLightSideAngle));
		RotateTransform3D rotateTransform3D4 = new RotateTransform3D(new AxisAngleRotation3D(axis, FillLightAngle));
		Vector3D vector2 = frontDirection * Distance;
		vector2 = rotateTransform3D3.Transform(vector2);
		vector2 = rotateTransform3D4.Transform(vector2);
		byte b2 = (byte)Math.Round((double)(int)b / KeyToFillLightRatio);
		lightGroup.Children.Add(new PointLight(Color.FromRgb(b2, b2, b2), Target - vector2));
		RotateTransform3D rotateTransform3D5 = new RotateTransform3D(new AxisAngleRotation3D(axis, 0.0 - RimLightAngle));
		Vector3D vector3 = -frontDirection * Distance;
		vector3 = rotateTransform3D5.Transform(vector3);
		byte b3 = (byte)Math.Round((double)(int)b / KeyToRimLightRatio);
		lightGroup.Children.Add(new PointLight(Color.FromRgb(b3, b3, b3), Target - vector3));
	}
}
