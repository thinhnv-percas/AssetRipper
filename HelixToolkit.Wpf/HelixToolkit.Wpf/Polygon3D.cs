using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class Polygon3D
{
	private IList<Point3D> points;

	public IList<Point3D> Points
	{
		get
		{
			return points;
		}
		set
		{
			points = value;
		}
	}

	public Polygon3D()
	{
		points = new List<Point3D>();
	}

	public Polygon3D(IList<Point3D> pts)
	{
		points = pts;
	}

	public Polygon Flatten()
	{
		Vector3D normal = GetNormal();
		normal.Normalize();
		Vector3D vector = Vector3D.CrossProduct(normal, (Math.Abs(normal.X) > Math.Abs(normal.Z)) ? new Vector3D(0.0, 0.0, 1.0) : new Vector3D(1.0, 0.0, 0.0));
		Vector3D vector3D = Vector3D.CrossProduct(vector, normal);
		Matrix3D matrix3D = new Matrix3D(vector3D.X, vector.X, normal.X, 0.0, vector3D.Y, vector.Y, normal.Y, 0.0, vector3D.Z, vector.Z, normal.Z, 0.0, 0.0, 0.0, 0.0, 1.0);
		Point3D point3D = matrix3D.Transform(Points[0]);
		matrix3D.OffsetX = 0.0 - point3D.X;
		matrix3D.OffsetY = 0.0 - point3D.Y;
		Polygon polygon = new Polygon
		{
			Points = new PointCollection(Points.Count)
		};
		foreach (Point3D point in Points)
		{
			Point3D point3D2 = matrix3D.Transform(point);
			polygon.Points.Add(new Point(point3D2.X, point3D2.Y));
		}
		return polygon;
	}

	public Vector3D GetNormal()
	{
		if (Points.Count < 3)
		{
			throw new InvalidOperationException("At least three points required in the polygon to find a normal.");
		}
		Vector3D vector = Points[1] - Points[0];
		for (int i = 2; i < Points.Count; i++)
		{
			Vector3D result = Vector3D.CrossProduct(vector, Points[i] - Points[0]);
			if (result.LengthSquared > 1E-10)
			{
				result.Normalize();
				return result;
			}
		}
		Vector3D result2 = Vector3D.CrossProduct(vector, Points[2] - Points[0]);
		result2.Normalize();
		return result2;
	}

	public bool IsPlanar()
	{
		Vector3D vector = Points[1] - Points[0];
		Vector3D vector2 = default(Vector3D);
		for (int i = 2; i < Points.Count; i++)
		{
			Vector3D vector3D = Vector3D.CrossProduct(vector, Points[i] - Points[0]);
			vector3D.Normalize();
			if (i == 2)
			{
				vector2 = vector3D;
			}
			else if (Math.Abs(Vector3D.DotProduct(vector3D, vector2) - 1.0) > 1E-08)
			{
				return false;
			}
		}
		return true;
	}
}
