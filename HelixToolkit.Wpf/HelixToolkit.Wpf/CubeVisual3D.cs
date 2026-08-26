using System.Windows;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class CubeVisual3D : MeshElement3D
{
	public static readonly DependencyProperty CenterProperty = DependencyProperty.Register("Center", typeof(Point3D), typeof(CubeVisual3D), new UIPropertyMetadata(default(Point3D), MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty SideLengthProperty = DependencyProperty.Register("SideLength", typeof(double), typeof(CubeVisual3D), new UIPropertyMetadata(1.0, MeshElement3D.GeometryChanged));

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

	public double SideLength
	{
		get
		{
			return (double)GetValue(SideLengthProperty);
		}
		set
		{
			SetValue(SideLengthProperty, value);
		}
	}

	protected override MeshGeometry3D Tessellate()
	{
		MeshBuilder meshBuilder = new MeshBuilder(generateNormals: false);
		meshBuilder.AddCubeFace(Center, new Vector3D(-1.0, 0.0, 0.0), new Vector3D(0.0, 0.0, 1.0), SideLength, SideLength, SideLength);
		meshBuilder.AddCubeFace(Center, new Vector3D(1.0, 0.0, 0.0), new Vector3D(0.0, 0.0, -1.0), SideLength, SideLength, SideLength);
		meshBuilder.AddCubeFace(Center, new Vector3D(0.0, -1.0, 0.0), new Vector3D(0.0, 0.0, 1.0), SideLength, SideLength, SideLength);
		meshBuilder.AddCubeFace(Center, new Vector3D(0.0, 1.0, 0.0), new Vector3D(0.0, 0.0, -1.0), SideLength, SideLength, SideLength);
		meshBuilder.AddCubeFace(Center, new Vector3D(0.0, 0.0, 1.0), new Vector3D(0.0, -1.0, 0.0), SideLength, SideLength, SideLength);
		meshBuilder.AddCubeFace(Center, new Vector3D(0.0, 0.0, -1.0), new Vector3D(0.0, 1.0, 0.0), SideLength, SideLength, SideLength);
		return meshBuilder.ToMesh();
	}
}
