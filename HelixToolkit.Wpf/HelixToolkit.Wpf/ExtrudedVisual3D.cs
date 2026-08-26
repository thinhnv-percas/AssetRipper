using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class ExtrudedVisual3D : MeshElement3D
{
	public static readonly DependencyProperty DiametersProperty = DependencyProperty.Register("Diameters", typeof(DoubleCollection), typeof(ExtrudedVisual3D), new UIPropertyMetadata(null, MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty SectionXAxisProperty = DependencyProperty.Register("SectionXAxis", typeof(Vector3D), typeof(ExtrudedVisual3D), new UIPropertyMetadata(MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty AnglesProperty = DependencyProperty.Register("Angles", typeof(DoubleCollection), typeof(ExtrudedVisual3D), new UIPropertyMetadata(null, MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty IsPathClosedProperty = DependencyProperty.Register("IsPathClosed", typeof(bool), typeof(ExtrudedVisual3D), new UIPropertyMetadata(false, MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty IsSectionClosedProperty = DependencyProperty.Register("IsSectionClosed", typeof(bool), typeof(ExtrudedVisual3D), new UIPropertyMetadata(true, MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty PathProperty = DependencyProperty.Register("Path", typeof(Point3DCollection), typeof(ExtrudedVisual3D), new UIPropertyMetadata(null, MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty SectionProperty = DependencyProperty.Register("Section", typeof(PointCollection), typeof(ExtrudedVisual3D), new UIPropertyMetadata(new PointCollection(), MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty TextureCoordinatesProperty = DependencyProperty.Register("TextureCoordinates", typeof(DoubleCollection), typeof(ExtrudedVisual3D), new UIPropertyMetadata(null, MeshElement3D.GeometryChanged));

	public DoubleCollection Diameters
	{
		get
		{
			return (DoubleCollection)GetValue(DiametersProperty);
		}
		set
		{
			SetValue(DiametersProperty, value);
		}
	}

	public DoubleCollection Angles
	{
		get
		{
			return (DoubleCollection)GetValue(AnglesProperty);
		}
		set
		{
			SetValue(AnglesProperty, value);
		}
	}

	public bool IsPathClosed
	{
		get
		{
			return (bool)GetValue(IsPathClosedProperty);
		}
		set
		{
			SetValue(IsPathClosedProperty, value);
		}
	}

	public bool IsSectionClosed
	{
		get
		{
			return (bool)GetValue(IsSectionClosedProperty);
		}
		set
		{
			SetValue(IsSectionClosedProperty, value);
		}
	}

	public Point3DCollection Path
	{
		get
		{
			return (Point3DCollection)GetValue(PathProperty);
		}
		set
		{
			SetValue(PathProperty, value);
		}
	}

	public PointCollection Section
	{
		get
		{
			return (PointCollection)GetValue(SectionProperty);
		}
		set
		{
			SetValue(SectionProperty, value);
		}
	}

	public Vector3D SectionXAxis
	{
		get
		{
			return (Vector3D)GetValue(SectionXAxisProperty);
		}
		set
		{
			SetValue(SectionXAxisProperty, value);
		}
	}

	public DoubleCollection TextureCoordinates
	{
		get
		{
			return (DoubleCollection)GetValue(TextureCoordinatesProperty);
		}
		set
		{
			SetValue(TextureCoordinatesProperty, value);
		}
	}

	public ExtrudedVisual3D()
	{
		Path = new Point3DCollection();
	}

	protected override MeshGeometry3D Tessellate()
	{
		if (Path == null || Path.Count < 2)
		{
			return null;
		}
		MeshBuilder meshBuilder = new MeshBuilder(generateNormals: false, TextureCoordinates != null);
		Vector3D vector3D = SectionXAxis;
		if (vector3D.Length < 1E-06)
		{
			vector3D = new Vector3D(1.0, 0.0, 0.0);
		}
		Vector3D vector3D2 = Path[1] - Path[0];
		if (Vector3D.CrossProduct(vector3D2, vector3D).LengthSquared < 1E-06)
		{
			vector3D = vector3D2.FindAnyPerpendicular();
		}
		meshBuilder.AddTube(Path, Angles, TextureCoordinates, Diameters, Section, vector3D, IsPathClosed, IsSectionClosed);
		return meshBuilder.ToMesh();
	}
}
