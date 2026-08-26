namespace ImageMagick;

public sealed class DrawableLine : IDrawable, IDrawingWand
{
	public double EndX { get; set; }

	public double EndY { get; set; }

	public double StartX { get; set; }

	public double StartY { get; set; }

	public DrawableLine(double startX, double startY, double endX, double endY)
	{
		StartX = startX;
		StartY = startY;
		EndX = endX;
		EndY = endY;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.Line(StartX, StartY, EndX, EndY);
	}
}
