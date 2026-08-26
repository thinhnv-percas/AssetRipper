using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class MeshNormalsVisual3D : ModelVisual3D
{
	public static readonly DependencyProperty ColorProperty = DependencyProperty.Register("Color", typeof(Color), typeof(MeshNormalsVisual3D), new UIPropertyMetadata(Colors.Blue, MeshChanged));

	public static readonly DependencyProperty DiameterProperty = DependencyProperty.Register("Diameter", typeof(double), typeof(MeshNormalsVisual3D), new UIPropertyMetadata(0.1, MeshChanged));

	public static readonly DependencyProperty MeshProperty = DependencyProperty.Register("Mesh", typeof(MeshGeometry3D), typeof(MeshNormalsVisual3D), new UIPropertyMetadata(null, MeshChanged));

	public Color Color
	{
		get
		{
			return (Color)GetValue(ColorProperty);
		}
		set
		{
			SetValue(ColorProperty, value);
		}
	}

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

	public MeshGeometry3D Mesh
	{
		get
		{
			return (MeshGeometry3D)GetValue(MeshProperty);
		}
		set
		{
			SetValue(MeshProperty, value);
		}
	}

	protected static void MeshChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
	{
		((MeshNormalsVisual3D)obj).OnMeshChanged();
	}

	protected virtual void OnMeshChanged()
	{
		base.Children.Clear();
		MeshBuilder meshBuilder = new MeshBuilder();
		for (int i = 0; i < Mesh.Positions.Count; i++)
		{
			meshBuilder.AddArrow(Mesh.Positions[i], Mesh.Positions[i] + Mesh.Normals[i], Diameter, 3.0, 10);
		}
		base.Content = new GeometryModel3D
		{
			Geometry = meshBuilder.ToMesh(freeze: true),
			Material = MaterialHelper.CreateMaterial(Color)
		};
	}
}
