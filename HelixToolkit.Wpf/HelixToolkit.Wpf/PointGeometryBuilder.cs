using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class PointGeometryBuilder : ScreenGeometryBuilder
{
	public PointGeometryBuilder(Visual3D visual)
		: base(visual)
	{
	}

	public Int32Collection CreateIndices(int n)
	{
		Int32Collection int32Collection = new Int32Collection(n * 6);
		for (int i = 0; i < n; i++)
		{
			int32Collection.Add(i * 4 + 2);
			int32Collection.Add(i * 4 + 1);
			int32Collection.Add(i * 4);
			int32Collection.Add(i * 4 + 2);
			int32Collection.Add(i * 4 + 3);
			int32Collection.Add(i * 4 + 1);
		}
		int32Collection.Freeze();
		return int32Collection;
	}

	public Point3DCollection CreatePositions(IList<Point3D> points, double size = 1.0, double depthOffset = 0.0)
	{
		double num = size / 2.0;
		int count = points.Count;
		Vector[] array = new Vector[4]
		{
			new Vector(0.0 - num, num),
			new Vector(0.0 - num, 0.0 - num),
			new Vector(num, num),
			new Vector(num, 0.0 - num)
		};
		Point3DCollection point3DCollection = new Point3DCollection(count * 4);
		for (int i = 0; i < count; i++)
		{
			Point4D point4D = (Point4D)points[i] * visualToScreen;
			double x = point4D.X;
			double y = point4D.Y;
			double num2 = point4D.Z;
			double w = point4D.W;
			if (!depthOffset.Equals(0.0))
			{
				num2 -= depthOffset * w;
			}
			double num3 = 1.0 / (new Point4D(x, y, num2, w) * screenToVisual).W;
			Vector[] array2 = array;
			for (int j = 0; j < array2.Length; j++)
			{
				Vector vector = array2[j];
				Point4D point4D2 = new Point4D(x + vector.X * w, y + vector.Y * w, num2, w) * screenToVisual;
				point3DCollection.Add(new Point3D(point4D2.X * num3, point4D2.Y * num3, point4D2.Z * num3));
			}
		}
		point3DCollection.Freeze();
		return point3DCollection;
	}
}
