namespace ImageMagick;

public sealed class DrawableEllipse : IDrawable, IDrawingWand
{
	public double EndDegrees { get; set; }

	public double OriginX { get; set; }

	public double OriginY { get; set; }

	public double RadiusX { get; set; }

	public double RadiusY { get; set; }

	public double StartDegrees { get; set; }

	public DrawableEllipse(double originX, double originY, double radiusX, double radiusY, double startDegrees, double endDegrees)
	{
		OriginX = originX;
		OriginY = originY;
		RadiusX = radiusX;
		RadiusY = radiusY;
		StartDegrees = startDegrees;
		EndDegrees = endDegrees;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.Ellipse(OriginX, OriginY, RadiusX, RadiusY, StartDegrees, EndDegrees);
	}
}
