using System.Windows;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class EllipsoidVisual3D : MeshElement3D
{
	public static readonly DependencyProperty CenterProperty = DependencyProperty.Register("Center", typeof(Point3D), typeof(EllipsoidVisual3D), new PropertyMetadata(new Point3D(0.0, 0.0, 0.0), MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty PhiDivProperty = DependencyProperty.Register("PhiDiv", typeof(int), typeof(EllipsoidVisual3D), new PropertyMetadata(30, MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty RadiusXProperty = DependencyProperty.Register("RadiusX", typeof(double), typeof(EllipsoidVisual3D), new PropertyMetadata(1.0, MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty RadiusYProperty = DependencyProperty.Register("RadiusY", typeof(double), typeof(EllipsoidVisual3D), new PropertyMetadata(1.0, MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty RadiusZProperty = DependencyProperty.Register("RadiusZ", typeof(double), typeof(EllipsoidVisual3D), new PropertyMetadata(1.0, MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty ThetaDivProperty = DependencyProperty.Register("ThetaDiv", typeof(int), typeof(EllipsoidVisual3D), new PropertyMetadata(60, MeshElement3D.GeometryChanged));

	public Point3D Center
	{
		get
		{
			return (Point3D)GetValue(CenterProperty);
		}
		set
		{
			SetValue(CenterProperty, value);
		}
	}

	public int PhiDiv
	{
		get
		{
			return (int)GetValue(PhiDivProperty);
		}
		set
		{
			SetValue(PhiDivProperty, value);
		}
	}

	public double RadiusX
	{
		get
		{
			return (double)GetValue(RadiusXProperty);
		}
		set
		{
			SetValue(RadiusXProperty, value);
		}
	}

	public double RadiusY
	{
		get
		{
			return (double)GetValue(RadiusYProperty);
		}
		set
		{
			SetValue(RadiusYProperty, value);
		}
	}

	public double RadiusZ
	{
		get
		{
			return (double)GetValue(RadiusZProperty);
		}
		set
		{
			SetValue(RadiusZProperty, value);
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
		meshBuilder.AddEllipsoid(Center, RadiusX, RadiusY, RadiusZ, ThetaDiv, PhiDiv);
		return meshBuilder.ToMesh();
	}
}
