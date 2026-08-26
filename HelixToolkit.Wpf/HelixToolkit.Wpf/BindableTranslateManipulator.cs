using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class BindableTranslateManipulator : Manipulator
{
	public static readonly DependencyProperty DiameterProperty = DependencyProperty.Register("Diameter", typeof(double), typeof(BindableTranslateManipulator), new UIPropertyMetadata(0.2, Manipulator.UpdateGeometry));

	public static readonly DependencyProperty DirectionProperty = DependencyProperty.Register("Direction", typeof(Vector3D), typeof(BindableTranslateManipulator), new UIPropertyMetadata(new Vector3D(0.0, 0.0, 1.0), Manipulator.UpdateGeometry));

	public static readonly DependencyProperty LengthProperty = DependencyProperty.Register("Length", typeof(double), typeof(BindableTranslateManipulator), new UIPropertyMetadata(2.0, Manipulator.UpdateGeometry));

	private Point3D lastPoint;

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

	public Vector3D Direction
	{
		get
		{
			return (Vector3D)GetValue(DirectionProperty);
		}
		set
		{
			SetValue(DirectionProperty, value);
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

	protected override void UpdateGeometry()
	{
		MeshBuilder meshBuilder = new MeshBuilder(generateNormals: false, generateTexCoords: false);
		Point3D point3D = new Point3D(0.0, 0.0, 0.0);
		Vector3D direction = Direction;
		direction.Normalize();
		Point3D point = point3D + direction * Length;
		meshBuilder.AddArrow(point3D, point, Diameter);
		base.Model.Geometry = meshBuilder.ToMesh();
	}

	protected override void OnMouseDown(MouseButtonEventArgs e)
	{
		base.OnMouseDown(e);
		Vector3D vector = ToWorld(Direction);
		Vector3D vector2 = Vector3D.CrossProduct(base.Camera.LookDirection, vector);
		Point3D hitPlaneOrigin = ToWorld(base.Position);
		base.HitPlaneNormal = Vector3D.CrossProduct(vector2, vector);
		Point position = e.GetPosition(base.ParentViewport);
		Point3D? nearestPoint = GetNearestPoint(position, hitPlaneOrigin, base.HitPlaneNormal);
		if (nearestPoint.HasValue)
		{
			Point3D point3D = ToLocal(nearestPoint.Value);
			lastPoint = point3D;
			CaptureMouse();
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
		Point position = e.GetPosition(base.ParentViewport);
		Point3D? nearestPoint = GetNearestPoint(position, hitPlaneOrigin, base.HitPlaneNormal);
		if (nearestPoint.HasValue)
		{
			Vector3D vector = ToLocal(nearestPoint.Value) - lastPoint;
			base.Value += Vector3D.DotProduct(vector, Direction);
			nearestPoint = GetNearestPoint(position, hitPlaneOrigin, base.HitPlaneNormal);
			if (nearestPoint.HasValue)
			{
				lastPoint = ToLocal(nearestPoint.Value);
			}
		}
	}

	protected override void PositionChanged(DependencyPropertyChangedEventArgs e)
	{
		base.PositionChanged(e);
		if (base.TargetTransform != null)
		{
			Vector3D offset = (Point3D)e.NewValue - (Point3D)e.OldValue;
			TranslateTransform3D t = new TranslateTransform3D(offset);
			base.TargetTransform = Transform3DHelper.CombineTransform(t, base.TargetTransform);
		}
	}

	protected override void ValueChanged(DependencyPropertyChangedEventArgs e)
	{
		double num = (double)e.OldValue;
		double num2 = (double)e.NewValue;
		double num3 = num2 - num;
		Vector3D vector3D = new Vector3D(Direction.X, Direction.Y, Direction.Z);
		vector3D.Normalize();
		vector3D *= num3;
		base.Position += vector3D;
	}

	private Point3D? GetNearestPoint(Point position, Point3D hitPlaneOrigin, Vector3D hitPlaneNormal)
	{
		Point3D? hitPlanePoint = GetHitPlanePoint(position, hitPlaneOrigin, hitPlaneNormal);
		if (!hitPlanePoint.HasValue)
		{
			return null;
		}
		Ray3D ray3D = new Ray3D(ToWorld(base.Position), ToWorld(Direction));
		return ray3D.GetNearest(hitPlanePoint.Value);
	}
}
