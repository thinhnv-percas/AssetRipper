namespace ImageMagick;

public sealed class DrawableStrokeOpacity : IDrawable, IDrawingWand
{
	public Percentage Opacity { get; set; }

	public DrawableStrokeOpacity(Percentage opacity)
	{
		Opacity = opacity;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.StrokeOpacity((double)Opacity / 100.0);
	}
}
