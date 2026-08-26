namespace ImageMagick;

public sealed class DrawableCircle : IDrawable, IDrawingWand
{
	public double OriginX { get; set; }

	public double OriginY { get; set; }

	public double PerimeterX { get; set; }

	public double PerimeterY { get; set; }

	public DrawableCircle(double originX, double originY, double perimeterX, double perimeterY)
	{
		OriginX = originX;
		OriginY = originY;
		PerimeterX = perimeterX;
		PerimeterY = perimeterY;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.Circle(OriginX, OriginY, PerimeterX, PerimeterY);
	}
}
