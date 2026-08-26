namespace ImageMagick;

public sealed class DrawableStrokeWidth : IDrawable, IDrawingWand
{
	public double Width { get; set; }

	public DrawableStrokeWidth(double width)
	{
		Width = width;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.StrokeWidth(Width);
	}
}
