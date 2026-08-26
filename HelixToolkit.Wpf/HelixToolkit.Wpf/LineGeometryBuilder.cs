using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class LineGeometryBuilder : ScreenGeometryBuilder
{
	public LineGeometryBuilder(Visual3D visual)
		: base(visual)
	{
	}

	public Int32Collection CreateIndices(int n)
	{
		Int32Collection int32Collection = new Int32Collection(n * 3);
		for (int i = 0; i < n / 2; i++)
		{
			int num = i * 4;
			int32Collection.Add(num + 2);
			int32Collection.Add(num + 1);
			int32Collection.Add(num);
			int32Collection.Add(num + 2);
			int32Collection.Add(num + 3);
			int32Collection.Add(num + 1);
		}
		int32Collection.Freeze();
		return int32Collection;
	}

	public Point3DCollection CreatePositions(IList<Point3D> points, double thickness = 1.0, double depthOffset = 0.0, CohenSutherlandClipping clipping = null)
	{
		double num = thickness * 0.5;
		int num2 = points.Count / 2;
		Point3DCollection point3DCollection = new Point3DCollection(num2 * 4);
		for (int i = 0; i < num2; i++)
		{
			int num3 = i * 2;
			Point3D point3D = points[num3];
			Point3D point3D2 = points[num3 + 1];
			Point4D point4D = (Point4D)point3D * visualToScreen;
			Point4D point4D2 = (Point4D)point3D2 * visualToScreen;
			if (clipping != null)
			{
				double x = point4D.X / point4D.W;
				double y = point4D.Y / point4D.W;
				double x2 = point4D2.X / point4D2.W;
				double y2 = point4D2.Y / point4D2.W;
				if (!clipping.ClipLine(ref x, ref y, ref x2, ref y2))
				{
					continue;
				}
				point4D.X = x * point4D.W;
				point4D.Y = y * point4D.W;
				point4D2.X = x2 * point4D2.W;
				point4D2.Y = y2 * point4D2.W;
			}
			double num4 = point4D2.X / point4D2.W - point4D.X / point4D.W;
			double num5 = point4D2.Y / point4D2.W - point4D.Y / point4D.W;
			double d = num4 * num4 + num5 * num5;
			Point4D point4D3 = point4D;
			Point4D point4D4 = point4D;
			Point4D point4D5 = point4D2;
			Point4D point4D6 = point4D2;
			if (d.Equals(0.0))
			{
				double num6 = num;
				point4D3.X -= num6 * point4D3.W;
				point4D3.Y -= num6 * point4D3.W;
				point4D4.X -= num6 * point4D4.W;
				point4D4.Y += num6 * point4D4.W;
				point4D5.X += num6 * point4D5.W;
				point4D5.Y -= num6 * point4D5.W;
				point4D6.X += num6 * point4D6.W;
				point4D6.Y += num6 * point4D6.W;
			}
			else
			{
				double num7 = num / Math.Sqrt(d);
				double num8 = (0.0 - num5) * num7;
				double num9 = num4 * num7;
				point4D3.X += num8 * point4D3.W;
				point4D3.Y += num9 * point4D3.W;
				point4D4.X -= num8 * point4D4.W;
				point4D4.Y -= num9 * point4D4.W;
				point4D5.X += num8 * point4D5.W;
				point4D5.Y += num9 * point4D5.W;
				point4D6.X -= num8 * point4D6.W;
				point4D6.Y -= num9 * point4D6.W;
			}
			if (!depthOffset.Equals(0.0))
			{
				point4D3.Z -= depthOffset;
				point4D4.Z -= depthOffset;
				point4D5.Z -= depthOffset;
				point4D6.Z -= depthOffset;
				point4D3 *= screenToVisual;
				point4D4 *= screenToVisual;
				point4D5 *= screenToVisual;
				point4D6 *= screenToVisual;
				point3DCollection.Add(new Point3D(point4D3.X / point4D3.W, point4D3.Y / point4D3.W, point4D3.Z / point4D3.W));
				point3DCollection.Add(new Point3D(point4D4.X / point4D3.W, point4D4.Y / point4D4.W, point4D4.Z / point4D4.W));
				point3DCollection.Add(new Point3D(point4D5.X / point4D3.W, point4D5.Y / point4D5.W, point4D5.Z / point4D5.W));
				point3DCollection.Add(new Point3D(point4D6.X / point4D3.W, point4D6.Y / point4D6.W, point4D6.Z / point4D6.W));
			}
			else
			{
				point4D3 *= screenToVisual;
				point4D4 *= screenToVisual;
				point4D5 *= screenToVisual;
				point4D6 *= screenToVisual;
				point3DCollection.Add(new Point3D(point4D3.X, point4D3.Y, point4D3.Z));
				point3DCollection.Add(new Point3D(point4D4.X, point4D4.Y, point4D4.Z));
				point3DCollection.Add(new Point3D(point4D5.X, point4D5.Y, point4D5.Z));
				point3DCollection.Add(new Point3D(point4D6.X, point4D6.Y, point4D6.Z));
			}
		}
		point3DCollection.Freeze();
		return point3DCollection;
	}
}
