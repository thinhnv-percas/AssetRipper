using System.Windows;

namespace HelixToolkit.Wpf;

public class PointsVisual3D : ScreenSpaceVisual3D
{
	public static readonly DependencyProperty SizeProperty = DependencyProperty.Register("Size", typeof(double), typeof(PointsVisual3D), new UIPropertyMetadata(1.0, ScreenSpaceVisual3D.GeometryChanged));

	private readonly PointGeometryBuilder builder;

	public double Size
	{
		get
		{
			return (double)GetValue(SizeProperty);
		}
		set
		{
			SetValue(SizeProperty, value);
		}
	}

	public PointsVisual3D()
	{
		builder = new PointGeometryBuilder(this);
	}

	protected override void UpdateGeometry()
	{
		base.Mesh.Positions = null;
		if (base.Points == null)
		{
			return;
		}
		int count = base.Points.Count;
		if (count > 0)
		{
			if (base.Mesh.TriangleIndices.Count != count * 6)
			{
				base.Mesh.TriangleIndices = builder.CreateIndices(count);
			}
			base.Mesh.Positions = builder.CreatePositions(base.Points, Size, base.DepthOffset);
		}
	}

	protected override bool UpdateTransforms()
	{
		return builder.UpdateTransforms();
	}
}
