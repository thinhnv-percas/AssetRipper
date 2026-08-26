using System.Windows;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class MeshGeometryVisual3D : MeshElement3D
{
	public static readonly DependencyProperty GeometryProperty = DependencyProperty.Register("MeshGeometry", typeof(MeshGeometry3D), typeof(MeshGeometryVisual3D), new PropertyMetadata(null, MeshElement3D.GeometryChanged));

	public MeshGeometry3D MeshGeometry
	{
		get
		{
			return (MeshGeometry3D)GetValue(GeometryProperty);
		}
		set
		{
			SetValue(GeometryProperty, value);
		}
	}

	protected override MeshGeometry3D Tessellate()
	{
		return MeshGeometry;
	}
}
