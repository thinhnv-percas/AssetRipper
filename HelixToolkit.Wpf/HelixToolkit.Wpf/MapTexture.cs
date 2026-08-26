using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class MapTexture : TerrainTexture
{
	public double Bottom { get; set; }

	public double Left { get; set; }

	public double Right { get; set; }

	public double Top { get; set; }

	public MapTexture(string source)
	{
		base.Material = MaterialHelper.CreateImageMaterial(source);
	}

	public override void Calculate(TerrainModel model, MeshGeometry3D mesh)
	{
		PointCollection pointCollection = new PointCollection();
		foreach (Point3D position in mesh.Positions)
		{
			double num = position.X + model.Offset.X;
			double num2 = position.Y + model.Offset.Y;
			double x = (num - Left) / (Right - Left);
			double y = (num2 - Top) / (Bottom - Top);
			pointCollection.Add(new Point(x, y));
		}
		base.TextureCoordinates = pointCollection;
	}
}
