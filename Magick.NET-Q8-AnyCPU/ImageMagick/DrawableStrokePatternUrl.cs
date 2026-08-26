namespace ImageMagick;

public sealed class DrawableStrokePatternUrl : IDrawable, IDrawingWand
{
	public string Url { get; set; }

	public DrawableStrokePatternUrl(string url)
	{
		Url = url;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.StrokePatternUrl(Url);
	}
}
