namespace ImageMagick;

public sealed class DrawableStrokeLineCap : IDrawable, IDrawingWand
{
	public LineCap LineCap { get; set; }

	public DrawableStrokeLineCap(LineCap lineCap)
	{
		LineCap = lineCap;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.StrokeLineCap(LineCap);
	}
}
