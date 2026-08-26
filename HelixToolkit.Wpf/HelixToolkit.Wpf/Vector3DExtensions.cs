using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public static class Vector3DExtensions
{
	public static Vector3D FindAnyPerpendicular(this Vector3D n)
	{
		n.Normalize();
		Vector3D result = Vector3D.CrossProduct(new Vector3D(0.0, 1.0, 0.0), n);
		if (result.LengthSquared < 0.001)
		{
			result = Vector3D.CrossProduct(new Vector3D(1.0, 0.0, 0.0), n);
		}
		return result;
	}

	public static bool IsUndefined(this Vector3D v)
	{
		return double.IsNaN(v.X) && double.IsNaN(v.Y) && double.IsNaN(v.Z);
	}

	public static Point3D ToPoint3D(this Vector3D n)
	{
		return new Point3D(n.X, n.Y, n.Z);
	}
}
