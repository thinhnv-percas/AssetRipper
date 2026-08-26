using System.Windows;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class TruncatedConeVisual3D : MeshElement3D
{
	public static readonly DependencyProperty BaseCapProperty = DependencyProperty.Register("BaseCap", typeof(bool), typeof(TruncatedConeVisual3D), new UIPropertyMetadata(true, MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty BaseRadiusProperty = DependencyProperty.Register("BaseRadius", typeof(double), typeof(TruncatedConeVisual3D), new PropertyMetadata(1.0, MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty HeightProperty = DependencyProperty.Register("Height", typeof(double), typeof(TruncatedConeVisual3D), new PropertyMetadata(2.0, MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty NormalProperty = DependencyProperty.Register("Normal", typeof(Vector3D), typeof(TruncatedConeVisual3D), new PropertyMetadata(new Vector3D(0.0, 0.0, 1.0), MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty OriginProperty = DependencyProperty.Register("Origin", typeof(Point3D), typeof(TruncatedConeVisual3D), new PropertyMetadata(new Point3D(0.0, 0.0, 0.0), MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty ThetaDivProperty = DependencyProperty.Register("ThetaDiv", typeof(int), typeof(TruncatedConeVisual3D), new PropertyMetadata(35, MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty TopCapProperty = DependencyProperty.Register("TopCap", typeof(bool), typeof(TruncatedConeVisual3D), new UIPropertyMetadata(true, MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty TopRadiusProperty = DependencyProperty.Register("TopRadius", typeof(double), typeof(TruncatedConeVisual3D), new PropertyMetadata(0.0, MeshElement3D.GeometryChanged));

	public bool BaseCap
	{
		get
		{
			return (bool)GetValue(BaseCapProperty);
		}
		set
		{
			SetValue(BaseCapProperty, value);
		}
	}

	public double BaseRadius
	{
		get
		{
			return (double)GetValue(BaseRadiusProperty);
		}
		set
		{
			SetValue(BaseRadiusProperty, value);
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

	public Vector3D Normal
	{
		get
		{
			return (Vector3D)GetValue(NormalProperty);
		}
		set
		{
			SetValue(NormalProperty, value);
		}
	}

	public Point3D Origin
	{
		get
		{
			return (Point3D)GetValue(OriginProperty);
		}
		set
		{
			SetValue(OriginProperty, value);
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

	public bool TopCap
	{
		get
		{
			return (bool)GetValue(TopCapProperty);
		}
		set
		{
			SetValue(TopCapProperty, value);
		}
	}

	public double TopRadius
	{
		get
		{
			return (double)GetValue(TopRadiusProperty);
		}
		set
		{
			SetValue(TopRadiusProperty, value);
		}
	}

	protected override MeshGeometry3D Tessellate()
	{
		MeshBuilder meshBuilder = new MeshBuilder(generateNormals: false);
		meshBuilder.AddCone(Origin, Normal, BaseRadius, TopRadius, Height, BaseCap, TopCap, ThetaDiv);
		return meshBuilder.ToMesh();
	}
}
