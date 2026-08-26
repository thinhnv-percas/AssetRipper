namespace ImageMagick;

public sealed class DrawableStrokeLineJoin : IDrawable, IDrawingWand
{
	public LineJoin LineJoin { get; set; }

	public DrawableStrokeLineJoin(LineJoin lineJoin)
	{
		LineJoin = lineJoin;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.StrokeLineJoin(LineJoin);
	}
}
