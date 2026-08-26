namespace ImageMagick;

public sealed class DrawableDensity : IDrawable, IDrawingWand
{
	public PointD Density { get; set; }

	public DrawableDensity(double density)
	{
		Density = new PointD(density);
	}

	public DrawableDensity(PointD pointDensity)
	{
		Density = pointDensity;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.Density(Density);
	}
}
