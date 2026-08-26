namespace ImageMagick;

public sealed class DrawableAlpha : IDrawable, IDrawingWand
{
	public PaintMethod PaintMethod { get; set; }

	public double X { get; set; }

	public double Y { get; set; }

	public DrawableAlpha(double x, double y, PaintMethod paintMethod)
	{
		X = x;
		Y = y;
		PaintMethod = paintMethod;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.Alpha(X, Y, PaintMethod);
	}
}
