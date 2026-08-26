namespace ImageMagick;

public sealed class DrawablePoint : IDrawable, IDrawingWand
{
	public double X { get; set; }

	public double Y { get; set; }

	public DrawablePoint(double x, double y)
	{
		X = x;
		Y = y;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.Point(X, Y);
	}
}
