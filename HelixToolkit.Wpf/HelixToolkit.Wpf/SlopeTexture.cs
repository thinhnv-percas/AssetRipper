using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class SlopeTexture : TerrainTexture
{
	public Brush Brush { get; set; }

	public SlopeTexture(int gradientSteps)
	{
		if (gradientSteps > 0)
		{
			Brush = BrushHelper.CreateSteppedGradientBrush(GradientBrushes.BlueWhiteRed, gradientSteps);
		}
		else
		{
			Brush = GradientBrushes.BlueWhiteRed;
		}
	}

	public override void Calculate(TerrainModel model, MeshGeometry3D mesh)
	{
		Vector3DCollection vector3DCollection = mesh.CalculateNormals();
		PointCollection pointCollection = new PointCollection();
		Vector3D vector = new Vector3D(0.0, 0.0, 1.0);
		for (int i = 0; i < vector3DCollection.Count; i++)
		{
			double num = Math.Acos(Vector3D.DotProduct(vector3DCollection[i], vector)) * 180.0 / Math.PI;
			double num2 = num / 40.0;
			if (num2 > 1.0)
			{
				num2 = 1.0;
			}
			if (num2 < 0.0)
			{
				num2 = 0.0;
			}
			pointCollection.Add(new Point(num2, num2));
		}
		base.TextureCoordinates = pointCollection;
		base.Material = MaterialHelper.CreateMaterial(Brush);
	}
}
