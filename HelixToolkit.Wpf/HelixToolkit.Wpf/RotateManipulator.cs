using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class RotateManipulator : Manipulator
{
	public static readonly DependencyProperty AxisProperty = DependencyProperty.Register("Axis", typeof(Vector3D), typeof(RotateManipulator), new UIPropertyMetadata(new Vector3D(0.0, 0.0, 1.0), Manipulator.UpdateGeometry));

	public static readonly DependencyProperty DiameterProperty = DependencyProperty.Register("Diameter", typeof(double), typeof(RotateManipulator), new UIPropertyMetadata(3.0, Manipulator.UpdateGeometry));

	public static readonly DependencyProperty InnerDiameterProperty = DependencyProperty.Register("InnerDiameter", typeof(double), typeof(RotateManipulator), new UIPropertyMetadata(2.5, Manipulator.UpdateGeometry));

	public static readonly DependencyProperty LengthProperty = DependencyProperty.Register("Length", typeof(double), typeof(RotateManipulator), new UIPropertyMetadata(0.1, Manipulator.UpdateGeometry));

	public static readonly DependencyProperty PivotProperty = DependencyProperty.Register("Pivot", typeof(Point3D), typeof(Manipulator), new PropertyMetadata(default(Point3D)));

	private Point3D lastPoint;

	public Vector3D Axis
	{
		get
		{
			return (Vector3D)GetValue(AxisProperty);
		}
		set
		{
			SetValue(AxisProperty, value);
		}
	}

	public double Diameter
	{
		get
		{
			return (double)GetValue(DiameterProperty);
		}
		set
		{
			SetValue(DiameterProperty, value);
		}
	}

	public double InnerDiameter
	{
		get
		{
			return (double)GetValue(InnerDiameterProperty);
		}
		set
		{
			SetValue(InnerDiameterProperty, value);
		}
	}

	public double Length
	{
		get
		{
			return (double)GetValue(LengthProperty);
		}
		set
		{
			SetValue(LengthProperty, value);
		}
	}

	public Point3D Pivot
	{
		get
		{
			return (Point3D)GetValue(PivotProperty);
		}
		set
		{
			SetValue(PivotProperty, value);
		}
	}

	protected override void UpdateGeometry()
	{
		MeshBuilder meshBuilder = new MeshBuilder(generateNormals: false, generateTexCoords: false);
		Point3D point3D = new Point3D(0.0, 0.0, 0.0);
		Vector3D axis = Axis;
		axis.Normalize();
		Point3D point = point3D - axis * Length * 0.5;
		Point3D point2 = point3D + axis * Length * 0.5;
		meshBuilder.AddPipe(point, point2, InnerDiameter, Diameter, 60);
		base.Model.Geometry = meshBuilder.ToMesh();
	}

	protected override void OnMouseDown(MouseButtonEventArgs e)
	{
		base.OnMouseDown(e);
		Point3D hitPlaneOrigin = ToWorld(base.Position);
		Vector3D hitPlaneNormal = ToWorld(Axis);
		Point position = e.GetPosition(base.ParentViewport);
		Point3D? hitPlanePoint = GetHitPlanePoint(position, hitPlaneOrigin, hitPlaneNormal);
		if (hitPlanePoint.HasValue)
		{
			lastPoint = ToLocal(hitPlanePoint.Value);
		}
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		base.OnMouseMove(e);
		if (!base.IsMouseCaptured)
		{
			return;
		}
		Point3D hitPlaneOrigin = ToWorld(base.Position);
		Vector3D hitPlaneNormal = ToWorld(Axis);
		Point position = e.GetPosition(base.ParentViewport);
		Point3D? hitPlanePoint = GetHitPlanePoint(position, hitPlaneOrigin, hitPlaneNormal);
		if (hitPlanePoint.HasValue)
		{
			Point3D point3D = ToLocal(hitPlanePoint.Value);
			Vector3D vector = lastPoint - base.Position;
			Vector3D vector2 = point3D - base.Position;
			vector.Normalize();
			vector2.Normalize();
			Vector3D vector3 = Vector3D.CrossProduct(vector2, vector);
			double value = 0.0 - Vector3D.DotProduct(Axis, vector3);
			double num = (double)Math.Sign(value) * Math.Asin(vector3.Length) / Math.PI * 180.0;
			base.Value += num;
			if (base.TargetTransform != null)
			{
				RotateTransform3D t = new RotateTransform3D(new AxisAngleRotation3D(Axis, num), Pivot);
				base.TargetTransform = Transform3DHelper.CombineTransform(t, base.TargetTransform);
			}
			hitPlanePoint = GetHitPlanePoint(position, hitPlaneOrigin, hitPlaneNormal);
			if (hitPlanePoint.HasValue)
			{
				lastPoint = ToLocal(hitPlanePoint.Value);
			}
		}
	}
}
