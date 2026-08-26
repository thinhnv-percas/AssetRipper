using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public abstract class TerrainTexture
{
	public Material Material { get; set; }

	public PointCollection TextureCoordinates { get; set; }

	public TerrainTexture()
	{
		Material = Materials.Green;
	}

	public virtual void Calculate(TerrainModel model, MeshGeometry3D mesh)
	{
	}
}
