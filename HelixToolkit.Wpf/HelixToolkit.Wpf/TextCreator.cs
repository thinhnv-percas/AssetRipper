using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public static class TextCreator
{
	public static ModelVisual3D CreateTextLabel3D(string text, Brush textColor, bool isDoubleSided, double height, Point3D center, Vector3D textDirection, Vector3D updirection)
	{
		return new ModelVisual3D
		{
			Content = CreateTextLabelModel3D(text, textColor, isDoubleSided, height, center, textDirection, updirection)
		};
	}

	public static GeometryModel3D CreateTextLabelModel3D(string text, Brush textColor, bool isDoubleSided, double height, Point3D center, Vector3D textDirection, Vector3D updirection)
	{
		TextBlock visual = new TextBlock(new Run(text))
		{
			Foreground = textColor,
			FontFamily = new FontFamily("Arial")
		};
		DiffuseMaterial material = new DiffuseMaterial
		{
			Brush = new VisualBrush(visual)
		};
		double num = (double)text.Length * height;
		Point3D point3D = center - num / 2.0 * textDirection - height / 2.0 * updirection;
		Point3D value = point3D + updirection * 1.0 * height;
		Point3D value2 = point3D + textDirection * num;
		Point3D value3 = point3D + updirection * 1.0 * height + textDirection * num;
		MeshGeometry3D meshGeometry3D = new MeshGeometry3D
		{
			Positions = new Point3DCollection { point3D, value, value2, value3 }
		};
		if (isDoubleSided)
		{
			meshGeometry3D.Positions.Add(point3D);
			meshGeometry3D.Positions.Add(value);
			meshGeometry3D.Positions.Add(value2);
			meshGeometry3D.Positions.Add(value3);
		}
		meshGeometry3D.TriangleIndices.Add(0);
		meshGeometry3D.TriangleIndices.Add(3);
		meshGeometry3D.TriangleIndices.Add(1);
		meshGeometry3D.TriangleIndices.Add(0);
		meshGeometry3D.TriangleIndices.Add(2);
		meshGeometry3D.TriangleIndices.Add(3);
		if (isDoubleSided)
		{
			meshGeometry3D.TriangleIndices.Add(4);
			meshGeometry3D.TriangleIndices.Add(5);
			meshGeometry3D.TriangleIndices.Add(7);
			meshGeometry3D.TriangleIndices.Add(4);
			meshGeometry3D.TriangleIndices.Add(7);
			meshGeometry3D.TriangleIndices.Add(6);
		}
		meshGeometry3D.TextureCoordinates.Add(new Point(0.0, 1.0));
		meshGeometry3D.TextureCoordinates.Add(new Point(0.0, 0.0));
		meshGeometry3D.TextureCoordinates.Add(new Point(1.0, 1.0));
		meshGeometry3D.TextureCoordinates.Add(new Point(1.0, 0.0));
		if (isDoubleSided)
		{
			meshGeometry3D.TextureCoordinates.Add(new Point(1.0, 1.0));
			meshGeometry3D.TextureCoordinates.Add(new Point(1.0, 0.0));
			meshGeometry3D.TextureCoordinates.Add(new Point(0.0, 1.0));
			meshGeometry3D.TextureCoordinates.Add(new Point(0.0, 0.0));
		}
		return new GeometryModel3D(meshGeometry3D, material);
	}
}
