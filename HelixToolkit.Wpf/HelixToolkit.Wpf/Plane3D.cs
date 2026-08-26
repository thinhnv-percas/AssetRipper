using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class Plane3D
{
	private Vector3D normal;

	private Point3D position;

	public Vector3D Normal
	{
		get
		{
			return normal;
		}
		set
		{
			normal = value;
		}
	}

	public Point3D Position
	{
		get
		{
			return position;
		}
		set
		{
			position = value;
		}
	}

	public Plane3D()
	{
	}

	public Plane3D(Point3D p0, Vector3D n)
	{
		Position = p0;
		Normal = n;
	}

	public Point3D? LineIntersection(Point3D la, Point3D lb)
	{
		Vector3D vector3D = lb - la;
		double num = Vector3D.DotProduct(position - la, normal);
		double num2 = Vector3D.DotProduct(vector3D, normal);
		if (num.Equals(0.0) && num2.Equals(0.0))
		{
			return null;
		}
		if (num2.Equals(0.0))
		{
			return null;
		}
		return la + num / num2 * vector3D;
	}
}
