namespace ImageMagick;

public sealed class DrawableFontPointSize : IDrawable, IDrawingWand
{
	public double PointSize { get; set; }

	public DrawableFontPointSize(double pointSize)
	{
		PointSize = pointSize;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.FontPointSize(PointSize);
	}
}
