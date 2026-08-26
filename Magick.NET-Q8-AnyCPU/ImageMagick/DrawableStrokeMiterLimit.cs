namespace ImageMagick;

public sealed class DrawableStrokeMiterLimit : IDrawable, IDrawingWand
{
	public int Miterlimit { get; set; }

	public DrawableStrokeMiterLimit(int miterlimit)
	{
		Miterlimit = miterlimit;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.StrokeMiterLimit(Miterlimit);
	}
}
