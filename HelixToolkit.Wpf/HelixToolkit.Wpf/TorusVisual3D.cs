using System.Windows;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class TorusVisual3D : MeshElement3D
{
	public static readonly DependencyProperty TorusDiameterProperty = DependencyProperty.Register("TorusDiameter", typeof(double), typeof(TorusVisual3D), new UIPropertyMetadata(3.0, MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty TubeDiameterProperty = DependencyProperty.Register("TubeDiameter", typeof(double), typeof(TorusVisual3D), new UIPropertyMetadata(1.0, MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty ThetaDivProperty = DependencyProperty.Register("ThetaDiv", typeof(int), typeof(TorusVisual3D), new UIPropertyMetadata(36, MeshElement3D.GeometryChanged));

	public static readonly DependencyProperty PhiDivProperty = DependencyProperty.Register("PhiDiv", typeof(int), typeof(TorusVisual3D), new UIPropertyMetadata(24, MeshElement3D.GeometryChanged));

	public double TorusDiameter
	{
		get
		{
			return (double)GetValue(TorusDiameterProperty);
		}
		set
		{
			if (value >= 0.0)
			{
				SetValue(TorusDiameterProperty, value);
			}
		}
	}

	public double TubeDiameter
	{
		get
		{
			return (double)GetValue(TubeDiameterProperty);
		}
		set
		{
			if (value >= 0.0)
			{
				SetValue(TubeDiameterProperty, value);
			}
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
			if (value >= 3)
			{
				SetValue(ThetaDivProperty, value);
			}
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
			if (value >= 3)
			{
				SetValue(PhiDivProperty, value);
			}
		}
	}

	protected override MeshGeometry3D Tessellate()
	{
		MeshBuilder meshBuilder = new MeshBuilder(generateNormals: false);
		meshBuilder.AddTorus(TorusDiameter, TubeDiameter, ThetaDiv, PhiDiv);
		return meshBuilder.ToMesh();
	}
}
