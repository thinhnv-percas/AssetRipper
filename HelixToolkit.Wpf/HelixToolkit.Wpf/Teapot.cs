using System;
using System.Windows;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class Teapot : MeshElement3D
{
	public static readonly DependencyProperty PositionProperty = DependencyProperty.Register("Position", typeof(Point3D), typeof(Teapot), new UIPropertyMetadata(new Point3D(0.0, 0.0, 1.0), TransformChanged));

	public static readonly DependencyProperty SpoutDirectionProperty = DependencyProperty.Register("SpoutDirection", typeof(Vector3D), typeof(Teapot), new UIPropertyMetadata(new Vector3D(1.0, 0.0, 0.0), TransformChanged));

	public static readonly DependencyProperty UpDirectionProperty = DependencyProperty.Register("UpDirection", typeof(Vector3D), typeof(Teapot), new UIPropertyMetadata(new Vector3D(0.0, 0.0, 1.0), TransformChanged));

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

	public Vector3D SpoutDirection
	{
		get
		{
			return (Vector3D)GetValue(SpoutDirectionProperty);
		}
		set
		{
			SetValue(SpoutDirectionProperty, value);
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

	protected override MeshGeometry3D Tessellate()
	{
		if (!(Application.LoadComponent(new Uri("HelixToolkit.Wpf;component/Resources/TeapotGeometry.xaml", UriKind.Relative)) is ResourceDictionary resourceDictionary))
		{
			return null;
		}
		OnTransformChanged();
		return resourceDictionary["TeapotGeometry"] as MeshGeometry3D;
	}

	private static void TransformChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((Teapot)d).OnTransformChanged();
	}

	private void OnTransformChanged()
	{
		Vector3D spoutDirection = SpoutDirection;
		Vector3D vector3D = Vector3D.CrossProduct(UpDirection, spoutDirection);
		Vector3D upDirection = UpDirection;
		base.Transform = new MatrixTransform3D(new Matrix3D(spoutDirection.X, spoutDirection.Y, spoutDirection.Z, 0.0, upDirection.X, upDirection.Y, upDirection.Z, 0.0, vector3D.X, vector3D.Y, vector3D.Z, 0.0, Position.X, Position.Y, Position.Z, 1.0));
	}
}
