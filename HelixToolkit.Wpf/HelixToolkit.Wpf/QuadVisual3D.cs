using System.Windows;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class QuadVisual3D : MeshElement3D
{
	public static readonly DependencyProperty Point1Property = DependencyProperty.Register("Point1", typeof(Point3D), typeof(QuadVisual3D), new UIPropertyMetadata(new Point3D(0.0, 0.0, 0.0), MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty Point2Property = DependencyProperty.Register("Point2", typeof(Point3D), typeof(QuadVisual3D), new UIPropertyMetadata(new Point3D(1.0, 0.0, 0.0), MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty Point3Property = DependencyProperty.Register("Point3", typeof(Point3D), typeof(QuadVisual3D), new UIPropertyMetadata(new Point3D(1.0, 1.0, 0.0), MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty Point4Property = DependencyProperty.Register("Point4", typeof(Point3D), typeof(QuadVisual3D), new UIPropertyMetadata(new Point3D(0.0, 1.0, 0.0), MeshElement3D.GeometryChanged));

	public Point3D Point1
	{
		get
		{
			return (Point3D)GetValue(Point1Property);
		}
		set
		{
			SetValue(Point1Property, value);
		}
	}

	public Point3D Point2
	{
		get
		{
			return (Point3D)GetValue(Point2Property);
		}
		set
		{
			SetValue(Point2Property, value);
		}
	}

	public Point3D Point3
	{
		get
		{
			return (Point3D)GetValue(Point3Property);
		}
		set
		{
			SetValue(Point3Property, value);
		}
	}

	public Point3D Point4
	{
		get
		{
			return (Point3D)GetValue(Point4Property);
		}
		set
		{
			SetValue(Point4Property, value);
		}
	}

	protected override MeshGeometry3D Tessellate()
	{
		MeshBuilder meshBuilder = new MeshBuilder(generateNormals: false);
		meshBuilder.AddQuad(Point1, Point2, Point3, Point4, new Point(0.0, 1.0), new Point(1.0, 1.0), new Point(1.0, 0.0), new Point(0.0, 0.0));
		return meshBuilder.ToMesh();
	}
}
