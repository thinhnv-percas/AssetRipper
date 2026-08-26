using System.Windows;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class SphereVisual3D : MeshElement3D
{
	public static readonly DependencyProperty CenterProperty = DependencyProperty.Register("Center", typeof(Point3D), typeof(SphereVisual3D), new PropertyMetadata(new Point3D(0.0, 0.0, 0.0), MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty PhiDivProperty = DependencyProperty.Register("PhiDiv", typeof(int), typeof(SphereVisual3D), new PropertyMetadata(30, MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty RadiusProperty = DependencyProperty.Register("Radius", typeof(double), typeof(SphereVisual3D), new PropertyMetadata(1.0, MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty ThetaDivProperty = DependencyProperty.Register("ThetaDiv", typeof(int), typeof(SphereVisual3D), new PropertyMetadata(60, MeshElement3D.GeometryChanged));

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

	public double Radius
	{
		get
		{
			return (double)GetValue(RadiusProperty);
		}
		set
		{
			SetValue(RadiusProperty, value);
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
		MeshBuilder meshBuilder = new MeshBuilder(true, true, false);
		meshBuilder.AddSphere(Center, Radius, ThetaDiv, PhiDiv);
		return meshBuilder.ToMesh();
	}
}
