namespace ImageMagick;

public sealed class DrawableTextAntialias : IDrawable, IDrawingWand
{
	public bool IsEnabled { get; set; }

	public DrawableTextAntialias(bool isEnabled)
	{
		IsEnabled = isEnabled;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.TextAntialias(IsEnabled);
	}
}
