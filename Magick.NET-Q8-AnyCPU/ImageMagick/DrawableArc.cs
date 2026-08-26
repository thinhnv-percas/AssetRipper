namespace ImageMagick;

public sealed class DrawableArc : IDrawable, IDrawingWand
{
	public double EndDegrees { get; set; }

	public double EndX { get; set; }

	public double EndY { get; set; }

	public double StartDegrees { get; set; }

	public double StartX { get; set; }

	public double StartY { get; set; }

	public DrawableArc(double startX, double startY, double endX, double endY, double startDegrees, double endDegrees)
	{
		StartX = startX;
		StartY = startY;
		EndX = endX;
		EndY = endY;
		StartDegrees = startDegrees;
		EndDegrees = endDegrees;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.Arc(StartX, StartY, EndX, EndY, StartDegrees, EndDegrees);
	}
}
