namespace ImageMagick;

public sealed class DrawableClipRule : IDrawable, IDrawingWand
{
	public FillRule FillRule { get; set; }

	public DrawableClipRule(FillRule fillRule)
	{
		FillRule = fillRule;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.ClipRule(FillRule);
	}
}
