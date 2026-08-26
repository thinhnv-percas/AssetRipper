namespace ImageMagick;

public sealed class DrawableFillPatternUrl : IDrawable, IDrawingWand
{
	public string Url { get; set; }

	public DrawableFillPatternUrl(string url)
	{
		Url = url;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.FillPatternUrl(Url);
	}
}
