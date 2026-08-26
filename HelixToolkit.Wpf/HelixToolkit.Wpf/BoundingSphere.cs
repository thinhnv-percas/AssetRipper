using System;
using System.Collections.Generic;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class BoundingSphere
{
	private Point3D center;

	private double radius;

	public Point3D Center
	{
		get
		{
			return center;
		}
		set
		{
			center = value;
		}
	}

	public double Radius
	{
		get
		{
			return radius;
		}
		set
		{
			radius = value;
		}
	}

	public BoundingSphere()
	{
	}

	public BoundingSphere(Point3D center, double diameter)
	{
		this.center = center;
		radius = diameter / 2.0;
	}

	public static BoundingSphere CreateFromPoints(IEnumerable<Point3D> points)
	{
		throw new NotImplementedException();
	}

	public static BoundingSphere CreateFromRect3D(Rect3D rect)
	{
		return new BoundingSphere
		{
			Center = new Point3D(rect.X + rect.SizeX * 0.5, rect.Y + rect.SizeY * 0.5, rect.Z + rect.SizeZ * 0.5),
			Radius = 0.5 * Math.Sqrt(rect.SizeX * rect.SizeX + rect.SizeY * rect.SizeY + rect.SizeZ * rect.SizeZ)
		};
	}

	public static BoundingSphere CreateMerged(BoundingSphere original, BoundingSphere additional)
	{
		Vector3D vector3D = additional.center - original.center;
		double length = vector3D.Length;
		if (original.radius + additional.radius >= length)
		{
			if (original.radius - additional.radius >= length)
			{
				return original;
			}
			if (additional.radius - original.radius >= length)
			{
				return additional;
			}
		}
		Vector3D vector3D2 = vector3D * (1.0 / length);
		double num = Math.Min(0.0 - original.radius, length - additional.radius);
		double num2 = (Math.Max(original.radius, length + additional.radius) - num) * 0.5;
		return new BoundingSphere
		{
			Center = original.Center + vector3D2 * (num2 + num),
			Radius = num2
		};
	}

	public bool Contains(Point3D point)
	{
		return point.DistanceToSquared(center) < radius * radius;
	}

	public double DistanceFrom(Point3D point)
	{
		return point.DistanceTo(center) - radius;
	}

	public bool Intersects(BoundingSphere sphere)
	{
		double num = center.DistanceToSquared(sphere.center);
		return radius * radius + 2.0 * radius * sphere.radius + sphere.radius * sphere.radius > num;
	}

	public bool RayIntersection(Ray3D ray, out Point3D[] result)
	{
		double x = center.X;
		double y = center.Y;
		double z = center.Z;
		double num = radius;
		double x2 = ray.Origin.X;
		double y2 = ray.Origin.Y;
		double z2 = ray.Origin.Z;
		double x3 = ray.Direction.X;
		double y3 = ray.Direction.Y;
		double z3 = ray.Direction.Z;
		double num2 = x3 * x3 + y3 * y3 + z3 * z3;
		double num3 = 2.0 * x3 * (x2 - x) + 2.0 * y3 * (y2 - y) + 2.0 * z3 * (z2 - z);
		double num4 = x2 * x2 + y2 * y2 + z2 * z2 + x * x + z * z + y * y - 2.0 * (y * y2 + z * z2 + x * x2) - num * num;
		double num5 = num3 * num3 - 4.0 * num2 * num4;
		if (num5 >= 0.0)
		{
			double num6 = Math.Sqrt(num3 * num3 - 4.0 * num2 * num4);
			double num7 = (0.0 - num3 + num6) / (2.0 * num2);
			double num8 = (0.0 - num3 - num6) / (2.0 * num2);
			if (num7 >= 0.0 && num8 >= 0.0 && !num7.Equals(num8))
			{
				Point3D point3D = new Point3D(x2 + x3 * num7, y2 + y3 * num7, z2 + z3 * num7);
				Point3D point3D2 = new Point3D(x2 + x3 * num8, y2 + y3 * num8, z2 + z3 * num8);
				result = ((!(num7 < num8)) ? new Point3D[2] { point3D2, point3D } : new Point3D[2] { point3D, point3D2 });
				return true;
			}
			if (num7 >= 0.0)
			{
				Point3D point3D3 = new Point3D(x2 + x3 * num7, y2 + y3 * num7, z2 + z3 * num7);
				result = new Point3D[1] { point3D3 };
				return true;
			}
			if (num8 >= 0.0)
			{
				Point3D point3D4 = new Point3D(x2 + x3 * num8, y2 + y3 * num8, z2 + z3 * num8);
				result = new Point3D[1] { point3D4 };
				return true;
			}
		}
		result = null;
		return false;
	}
}
