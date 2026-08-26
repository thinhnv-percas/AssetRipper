namespace ImageMagick;

public sealed class DrawableStrokeAntialias : IDrawable, IDrawingWand
{
	public bool IsEnabled { get; set; }

	public DrawableStrokeAntialias(bool isEnabled)
	{
		IsEnabled = isEnabled;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.StrokeAntialias(IsEnabled);
	}
}
