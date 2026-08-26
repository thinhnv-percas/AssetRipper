using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class TubeVisual3D : ExtrudedVisual3D
{
	public static readonly DependencyProperty DiameterProperty;

	public static readonly DependencyProperty ThetaDivProperty;

	public static readonly DependencyProperty AddCapsProperty;

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

	public bool AddCaps
	{
		get
		{
			return (bool)GetValue(AddCapsProperty);
		}
		set
		{
			SetValue(AddCapsProperty, value);
		}
	}

	static TubeVisual3D()
	{
		DiameterProperty = DependencyProperty.Register("Diameter", typeof(double), typeof(TubeVisual3D), new UIPropertyMetadata(1.0, SectionChanged));
		ThetaDivProperty = DependencyProperty.Register("ThetaDiv", typeof(int), typeof(TubeVisual3D), new UIPropertyMetadata(36, SectionChanged));
		AddCapsProperty = DependencyProperty.Register("AddCaps", typeof(bool), typeof(TubeVisual3D), new UIPropertyMetadata(false, SectionChanged));
		ExtrudedVisual3D.DiametersProperty.OverrideMetadata(typeof(TubeVisual3D), new UIPropertyMetadata(null, SectionChanged));
	}

	public TubeVisual3D()
	{
		OnSectionChanged();
	}

	protected static void SectionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((TubeVisual3D)d).OnSectionChanged();
	}

	protected void OnSectionChanged()
	{
		PointCollection pointCollection = new PointCollection();
		IList<Point> circle = MeshBuilder.GetCircle(ThetaDiv);
		double num = ((base.Diameters != null) ? 1.0 : (Diameter / 2.0));
		for (int i = 0; i < ThetaDiv; i++)
		{
			pointCollection.Add(new Point(circle[i].X * num, circle[i].Y * num));
		}
		base.Section = pointCollection;
		OnGeometryChanged();
	}

	protected override MeshGeometry3D Tessellate()
	{
		if (base.Path == null || base.Path.Count < 2)
		{
			return null;
		}
		MeshBuilder meshBuilder = new MeshBuilder(generateNormals: false, base.TextureCoordinates != null);
		Vector3D vector3D = base.SectionXAxis;
		if (vector3D.Length < 1E-06)
		{
			vector3D = new Vector3D(1.0, 0.0, 0.0);
		}
		Vector3D vector3D2 = base.Path[1] - base.Path[0];
		if (Vector3D.CrossProduct(vector3D2, vector3D).LengthSquared < 1E-06)
		{
			vector3D = vector3D2.FindAnyPerpendicular();
		}
		meshBuilder.AddTube(base.Path, base.Angles, base.TextureCoordinates, base.Diameters, base.Section, vector3D, base.IsPathClosed, base.IsSectionClosed, AddCaps, AddCaps);
		return meshBuilder.ToMesh();
	}
}
