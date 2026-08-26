using System;
using System.Collections.Generic;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public static class CanonicalSplineHelper
{
	public static List<Point3D> CreateSpline(IList<Point3D> points, double tension = 0.5, IList<double> tensions = null, bool isClosed = false, double tolerance = 0.25)
	{
		List<Point3D> list = new List<Point3D>();
		if (points == null)
		{
			return list;
		}
		int count = points.Count;
		if (count < 1)
		{
			return list;
		}
		if (count < 2)
		{
			list.AddRange(points);
			return list;
		}
		if (count == 2)
		{
			if (!isClosed)
			{
				Segment(list, points[0], points[0], points[1], points[1], tension, tension, tolerance);
			}
			else
			{
				Segment(list, points[1], points[0], points[1], points[0], tension, tension, tolerance);
				Segment(list, points[0], points[1], points[0], points[1], tension, tension, tolerance);
			}
		}
		else
		{
			bool flag = tensions != null && tensions.Count > 0;
			for (int i = 0; i < count; i++)
			{
				double t = (flag ? tensions[i % tensions.Count] : tension);
				double t2 = (flag ? tensions[(i + 1) % tensions.Count] : tension);
				if (i == 0)
				{
					Segment(list, isClosed ? points[count - 1] : points[0], points[0], points[1], points[2], t, t2, tolerance);
				}
				else if (i == count - 2)
				{
					Segment(list, points[i - 1], points[i], points[i + 1], isClosed ? points[0] : points[i + 1], t, t2, tolerance);
				}
				else if (i == count - 1)
				{
					if (isClosed)
					{
						Segment(list, points[i - 1], points[i], points[0], points[1], t, t2, tolerance);
					}
				}
				else
				{
					Segment(list, points[i - 1], points[i], points[i + 1], points[i + 2], t, t2, tolerance);
				}
			}
		}
		return list;
	}

	private static void Segment(IList<Point3D> points, Point3D pt0, Point3D pt1, Point3D pt2, Point3D pt3, double t1, double t2, double tolerance)
	{
		double num = t1 * (pt2.X - pt0.X);
		double num2 = t1 * (pt2.Y - pt0.Y);
		double num3 = t1 * (pt2.Z - pt0.Z);
		double num4 = t2 * (pt3.X - pt1.X);
		double num5 = t2 * (pt3.Y - pt1.Y);
		double num6 = t2 * (pt3.Z - pt1.Z);
		double num7 = num + num4 + 2.0 * pt1.X - 2.0 * pt2.X;
		double num8 = num2 + num5 + 2.0 * pt1.Y - 2.0 * pt2.Y;
		double num9 = num3 + num6 + 2.0 * pt1.Z - 2.0 * pt2.Z;
		double num10 = -2.0 * num - num4 - 3.0 * pt1.X + 3.0 * pt2.X;
		double num11 = -2.0 * num2 - num5 - 3.0 * pt1.Y + 3.0 * pt2.Y;
		double num12 = -2.0 * num3 - num6 - 3.0 * pt1.Z + 3.0 * pt2.Z;
		double num13 = num;
		double num14 = num2;
		double num15 = num3;
		double x = pt1.X;
		double y = pt1.Y;
		double z = pt1.Z;
		int num16 = (int)((Math.Abs(pt1.X - pt2.X) + Math.Abs(pt1.Y - pt2.Y) + Math.Abs(pt1.Z - pt2.Z)) / tolerance);
		for (int i = 1; i < num16; i++)
		{
			double num17 = (double)i / (double)(num16 - 1);
			Point3D item = new Point3D(num7 * num17 * num17 * num17 + num10 * num17 * num17 + num13 * num17 + x, num8 * num17 * num17 * num17 + num11 * num17 * num17 + num14 * num17 + y, num9 * num17 * num17 * num17 + num12 * num17 * num17 + num15 * num17 + z);
			points.Add(item);
		}
	}
}
