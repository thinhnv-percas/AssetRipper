using System.Windows;

namespace HelixToolkit.Wpf;

public class LinesVisual3D : ScreenSpaceVisual3D
{
	public static readonly DependencyProperty ThicknessProperty = DependencyProperty.Register("Thickness", typeof(double), typeof(LinesVisual3D), new UIPropertyMetadata(1.0, ScreenSpaceVisual3D.GeometryChanged));

	private readonly LineGeometryBuilder builder;

	public double Thickness
	{
		get
		{
			return (double)GetValue(ThicknessProperty);
		}
		set
		{
			SetValue(ThicknessProperty, value);
		}
	}

	public LinesVisual3D()
	{
		builder = new LineGeometryBuilder(this);
	}

	protected override void UpdateGeometry()
	{
		if (base.Points == null)
		{
			base.Mesh.Positions = null;
			return;
		}
		int count = base.Points.Count;
		if (count > 0)
		{
			if (base.Mesh.TriangleIndices.Count != count * 3)
			{
				base.Mesh.TriangleIndices = builder.CreateIndices(count);
			}
			base.Mesh.Positions = builder.CreatePositions(base.Points, Thickness, base.DepthOffset);
		}
		else
		{
			base.Mesh.Positions = null;
		}
	}

	protected override bool UpdateTransforms()
	{
		return builder.UpdateTransforms();
	}
}
