using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public static class Point3DExtensions
{
	public static double DistanceTo(this Point3D p1, Point3D p2)
	{
		return (p2 - p1).Length;
	}

	public static double DistanceToSquared(this Point3D p1, Point3D p2)
	{
		return (p2 - p1).LengthSquared;
	}

	public static Vector3D ToVector3D(this Point3D n)
	{
		return new Vector3D(n.X, n.Y, n.Z);
	}

	public static Point3D Multiply(this Point3D p, double d)
	{
		return new Point3D(p.X * d, p.Y * d, p.Z * d);
	}

	public static Point3D Sum(params Point3D[] points)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		for (int i = 0; i < points.Length; i++)
		{
			Point3D point3D = points[i];
			num += point3D.X;
			num2 += point3D.Y;
			num3 += point3D.Z;
		}
		return new Point3D(num, num2, num3);
	}
}
