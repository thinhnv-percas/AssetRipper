using System.Windows;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class BoxVisual3D : MeshElement3D
{
	public static readonly DependencyProperty BottomFaceProperty = DependencyProperty.Register("BottomFace", typeof(bool), typeof(BoxVisual3D), new UIPropertyMetadata(true, MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty CenterProperty = DependencyProperty.Register("Center", typeof(Point3D), typeof(BoxVisual3D), new UIPropertyMetadata(default(Point3D), MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty HeightProperty = DependencyProperty.Register("Height", typeof(double), typeof(BoxVisual3D), new UIPropertyMetadata(1.0, MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty LengthProperty = DependencyProperty.Register("Length", typeof(double), typeof(BoxVisual3D), new UIPropertyMetadata(1.0, MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty TopFaceProperty = DependencyProperty.Register("TopFace", typeof(bool), typeof(BoxVisual3D), new UIPropertyMetadata(true, MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty WidthProperty = DependencyProperty.Register("Width", typeof(double), typeof(BoxVisual3D), new UIPropertyMetadata(1.0, MeshElement3D.GeometryChanged));

	public bool BottomFace
	{
		get
		{
			return (bool)GetValue(BottomFaceProperty);
		}
		set
		{
			SetValue(BottomFaceProperty, value);
		}
	}

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

	public double Height
	{
		get
		{
			return (double)GetValue(HeightProperty);
		}
		set
		{
			SetValue(HeightProperty, value);
		}
	}

	public double Length
	{
		get
		{
			return (double)GetValue(LengthProperty);
		}
		set
		{
			SetValue(LengthProperty, value);
		}
	}

	public bool TopFace
	{
		get
		{
			return (bool)GetValue(TopFaceProperty);
		}
		set
		{
			SetValue(TopFaceProperty, value);
		}
	}

	public double Width
	{
		get
		{
			return (double)GetValue(WidthProperty);
		}
		set
		{
			SetValue(WidthProperty, value);
		}
	}

	protected override MeshGeometry3D Tessellate()
	{
		MeshBuilder meshBuilder = new MeshBuilder(generateNormals: false);
		meshBuilder.AddCubeFace(Center, new Vector3D(-1.0, 0.0, 0.0), new Vector3D(0.0, 0.0, 1.0), Length, Width, Height);
		meshBuilder.AddCubeFace(Center, new Vector3D(1.0, 0.0, 0.0), new Vector3D(0.0, 0.0, -1.0), Length, Width, Height);
		meshBuilder.AddCubeFace(Center, new Vector3D(0.0, -1.0, 0.0), new Vector3D(0.0, 0.0, 1.0), Width, Length, Height);
		meshBuilder.AddCubeFace(Center, new Vector3D(0.0, 1.0, 0.0), new Vector3D(0.0, 0.0, -1.0), Width, Length, Height);
		if (TopFace)
		{
			meshBuilder.AddCubeFace(Center, new Vector3D(0.0, 0.0, 1.0), new Vector3D(0.0, -1.0, 0.0), Height, Length, Width);
		}
		if (BottomFace)
		{
			meshBuilder.AddCubeFace(Center, new Vector3D(0.0, 0.0, -1.0), new Vector3D(0.0, 1.0, 0.0), Height, Length, Width);
		}
		return meshBuilder.ToMesh();
	}
}
