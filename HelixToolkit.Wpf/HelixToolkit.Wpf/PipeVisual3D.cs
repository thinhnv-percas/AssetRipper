using System.Windows;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class PipeVisual3D : MeshElement3D
{
	public static readonly DependencyProperty DiameterProperty = DependencyProperty.Register("Diameter", typeof(double), typeof(PipeVisual3D), new UIPropertyMetadata(1.0, MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty InnerDiameterProperty = DependencyProperty.Register("InnerDiameter", typeof(double), typeof(PipeVisual3D), new UIPropertyMetadata(0.0, MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty Point1Property = DependencyProperty.Register("Point1", typeof(Point3D), typeof(PipeVisual3D), new UIPropertyMetadata(new Point3D(0.0, 0.0, 0.0), MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty Point2Property = DependencyProperty.Register("Point2", typeof(Point3D), typeof(PipeVisual3D), new UIPropertyMetadata(new Point3D(0.0, 0.0, 10.0), MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty ThetaDivProperty = DependencyProperty.Register("ThetaDiv", typeof(int), typeof(PipeVisual3D), new UIPropertyMetadata(36, MeshElement3D.GeometryChanged));

	public double Diameter
	{
		get
		{
			return (double)GetValue(DiameterProperty);
		}
		set
		{
			SetValue(DiameterProperty, value);
		}
	}

	public double InnerDiameter
	{
		get
		{
			return (double)GetValue(InnerDiameterProperty);
		}
		set
		{
			SetValue(InnerDiameterProperty, value);
		}
	}

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

	public int ThetaDiv
	{
		get
		{
			return (int)GetValue(ThetaDivProperty);
		}
		set
		{
			SetValue(ThetaDivProperty, value);
		}
	}

	protected override MeshGeometry3D Tessellate()
	{
		MeshBuilder meshBuilder = new MeshBuilder(generateNormals: false);
		meshBuilder.AddPipe(Point1, Point2, InnerDiameter, Diameter, ThetaDiv);
		return meshBuilder.ToMesh();
	}
}
