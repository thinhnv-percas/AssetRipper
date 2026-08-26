namespace ImageMagick;

public sealed class DrawableFillOpacity : IDrawable, IDrawingWand
{
	public Percentage Opacity { get; set; }

	public DrawableFillOpacity(Percentage opacity)
	{
		Opacity = opacity;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.FillOpacity(Opacity.ToDouble() / 100.0);
	}
}
