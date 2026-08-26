using System;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

internal static class SharedFunctions
{
	public static Vector3D CrossProduct(ref Vector3D first, ref Vector3D second)
	{
		return Vector3D.CrossProduct(first, second);
	}

	public static Vector3D CrossProduct(Vector3D first, Vector3D second)
	{
		return Vector3D.CrossProduct(first, second);
	}

	public static double DotProduct(ref Vector3D first, ref Vector3D second)
	{
		return first.X * second.X + first.Y * second.Y + first.Z * second.Z;
	}

	public static double LengthSquared(ref Vector3D vector)
	{
		return vector.X * vector.X + vector.Y * vector.Y + vector.Z * vector.Z;
	}

	public static double Length(ref Vector3D vector)
	{
		return Math.Sqrt(LengthSquared(ref vector));
	}

	public static Point3D ToPoint3D(ref Vector3D vector)
	{
		return new Point3D(vector.X, vector.Y, vector.Z);
	}

	public static Vector3D ToVector3D(ref Vector3D vector)
	{
		return new Vector3D(vector.X, vector.Y, vector.Z);
	}
}
