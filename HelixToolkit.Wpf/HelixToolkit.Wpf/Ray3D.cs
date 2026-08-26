using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class Ray3D
{
	private Vector3D direction;

	private Point3D origin;

	public Vector3D Direction
	{
		get
		{
			return direction;
		}
		set
		{
			direction = value;
		}
	}

	public Point3D Origin
	{
		get
		{
			return origin;
		}
		set
		{
			origin = value;
		}
	}

	public Ray3D()
	{
	}

	public Ray3D(Point3D o, Vector3D d)
	{
		Origin = o;
		Direction = d;
	}

	public Ray3D(Point3D p0, Point3D p1)
	{
		Origin = p0;
		Direction = p1 - p0;
	}

	public Point3D GetNearest(Point3D p3)
	{
		return origin + Vector3D.DotProduct(p3 - origin, direction) / direction.LengthSquared * direction;
	}

	public Point3D? PlaneIntersection(Point3D position, Vector3D normal)
	{
		if (PlaneIntersection(position, normal, out var intersection))
		{
			return intersection;
		}
		return null;
	}

	public bool PlaneIntersection(Point3D position, Vector3D normal, out Point3D intersection)
	{
		double num = Vector3D.DotProduct(normal, Direction);
		if (num.Equals(0.0))
		{
			intersection = default(Point3D);
			return false;
		}
		double num2 = Vector3D.DotProduct(normal, position - origin) / num;
		intersection = Origin + num2 * direction;
		return true;
	}
}
