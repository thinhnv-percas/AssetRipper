namespace ImageMagick;

public sealed class DrawableScaling : IDrawable, IDrawingWand
{
	public double X { get; set; }

	public double Y { get; set; }

	public DrawableScaling(double x, double y)
	{
		X = x;
		Y = y;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.Scaling(X, Y);
	}
}
