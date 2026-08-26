namespace ImageMagick;

public sealed class DrawableTranslation : IDrawable, IDrawingWand
{
	public double X { get; set; }

	public double Y { get; set; }

	public DrawableTranslation(double x, double y)
	{
		X = x;
		Y = y;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.Translation(X, Y);
	}
}
