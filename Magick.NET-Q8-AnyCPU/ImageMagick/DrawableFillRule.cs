namespace ImageMagick;

public sealed class DrawableFillRule : IDrawable, IDrawingWand
{
	public FillRule FillRule { get; set; }

	public DrawableFillRule(FillRule fillRule)
	{
		FillRule = fillRule;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.FillRule(FillRule);
	}
}
