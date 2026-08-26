using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class SlopeDirectionTexture : TerrainTexture
{
	public Brush Brush { get; set; }

	public SlopeDirectionTexture(int gradientSteps)
	{
		if (gradientSteps > 0)
		{
			Brush = BrushHelper.CreateSteppedGradientBrush(GradientBrushes.Hue, gradientSteps);
		}
		else
		{
			Brush = GradientBrushes.Hue;
		}
	}

	public override void Calculate(TerrainModel model, MeshGeometry3D mesh)
	{
		Vector3DCollection vector3DCollection = mesh.CalculateNormals();
		PointCollection pointCollection = new PointCollection();
		for (int i = 0; i < vector3DCollection.Count; i++)
		{
			double num = Math.Atan2(vector3DCollection[i].Y, vector3DCollection[i].X) * 180.0 / Math.PI;
			if (num < 0.0)
			{
				num += 360.0;
			}
			double num2 = num / 360.0;
			pointCollection.Add(new Point(num2, num2));
		}
		base.TextureCoordinates = pointCollection;
		base.Material = MaterialHelper.CreateMaterial(Brush);
	}
}
