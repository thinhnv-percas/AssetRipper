using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class BillboardGeometryBuilder : ScreenGeometryBuilder
{
	public BillboardGeometryBuilder(Visual3D visual)
		: base(visual)
	{
	}

	public static Int32Collection CreateIndices(int n)
	{
		Int32Collection int32Collection = new Int32Collection(n * 6);
		for (int i = 0; i < n; i++)
		{
			int32Collection.Add(i * 4);
			int32Collection.Add(i * 4 + 1);
			int32Collection.Add(i * 4 + 2);
			int32Collection.Add(i * 4 + 2);
			int32Collection.Add(i * 4 + 3);
			int32Collection.Add(i * 4);
		}
		int32Collection.Freeze();
		return int32Collection;
	}

	public Point3DCollection GetPositions(IList<Billboard> billboards, Vector offset)
	{
		Point3DCollection point3DCollection = new Point3DCollection(billboards.Count * 4);
		foreach (Billboard billboard in billboards)
		{
			Point4D point4D2;
			if (!billboard.WorldDepthOffset.Equals(0.0))
			{
				Point4D point4D = (Point4D)billboard.Position * visualToProjection;
				point4D2 = new Point4D(point4D.X, point4D.Y, point4D.Z + billboard.WorldDepthOffset, point4D.W) * projectionToScreen;
			}
			else
			{
				point4D2 = (Point4D)billboard.Position * visualToScreen;
			}
			double w = point4D2.W;
			double x = point4D2.X;
			double y = point4D2.Y;
			double z = point4D2.Z - billboard.DepthOffset * w;
			Point4D point4D3 = new Point4D(x + (billboard.Left + offset.X) * w, y + (billboard.Bottom + offset.Y) * w, z, w) * screenToVisual;
			double num = 1.0 / point4D3.W;
			point3DCollection.Add(new Point3D(point4D3.X * num, point4D3.Y * num, point4D3.Z * num));
			point4D3 = new Point4D(x + (billboard.Right + offset.X) * w, y + (billboard.Bottom + offset.Y) * w, z, w) * screenToVisual;
			num = 1.0 / point4D3.W;
			point3DCollection.Add(new Point3D(point4D3.X * num, point4D3.Y * num, point4D3.Z * num));
			point4D3 = new Point4D(x + (billboard.Right + offset.X) * w, y + (billboard.Top + offset.Y) * w, z, w) * screenToVisual;
			num = 1.0 / point4D3.W;
			point3DCollection.Add(new Point3D(point4D3.X * num, point4D3.Y * num, point4D3.Z * num));
			point4D3 = new Point4D(x + (billboard.Left + offset.X) * w, y + (billboard.Top + offset.Y) * w, z, w) * screenToVisual;
			num = 1.0 / point4D3.W;
			point3DCollection.Add(new Point3D(point4D3.X * num, point4D3.Y * num, point4D3.Z * num));
		}
		point3DCollection.Freeze();
		return point3DCollection;
	}

	public Point3DCollection GetPinPositions(IList<Billboard> billboards, Vector offset, double pinWidth)
	{
		Point point = new Point(0.0, 0.0);
		Point point2 = point + offset * (1.0 + 2.0 * pinWidth / offset.Length);
		Vector vector = new Vector(point2.Y, 0.0 - point2.X);
		vector.Normalize();
		vector *= pinWidth * 0.5;
		Point[] array = new Point[4]
		{
			new Point(0.0, 0.0) + vector * 0.5,
			new Point(0.0, 0.0) - vector * 0.5,
			point2 - vector,
			point2 + vector
		};
		Point3DCollection point3DCollection = new Point3DCollection(billboards.Count * 4);
		foreach (Billboard billboard in billboards)
		{
			Point4D point4D2;
			if (!billboard.WorldDepthOffset.Equals(0.0))
			{
				Point4D point4D = (Point4D)billboard.Position * visualToProjection;
				point4D2 = new Point4D(point4D.X, point4D.Y, point4D.Z + billboard.WorldDepthOffset, point4D.W) * projectionToScreen;
			}
			else
			{
				point4D2 = (Point4D)billboard.Position * visualToScreen;
			}
			double w = point4D2.W;
			double x = point4D2.X;
			double y = point4D2.Y;
			double z = point4D2.Z - (billboard.DepthOffset - 1E-05) * w;
			Point[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				Point point3 = array2[i];
				Point4D point4D3 = new Point4D(x + point3.X * w, y + point3.Y * w, z, w) * screenToVisual;
				double num = 1.0 / point4D3.W;
				point3DCollection.Add(new Point3D(point4D3.X * num, point4D3.Y * num, point4D3.Z * num));
			}
		}
		point3DCollection.Freeze();
		return point3DCollection;
	}
}
