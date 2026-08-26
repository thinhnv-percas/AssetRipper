namespace ImageMagick;

public sealed class DrawableStrokeDashOffset : IDrawable, IDrawingWand
{
	public double Offset { get; set; }

	public DrawableStrokeDashOffset(double offset)
	{
		Offset = offset;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.StrokeDashOffset(Offset);
	}
}
