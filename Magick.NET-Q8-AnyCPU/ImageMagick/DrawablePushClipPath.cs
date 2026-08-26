namespace ImageMagick;

public sealed class DrawablePushClipPath : IDrawable, IDrawingWand
{
	public string ClipPath { get; set; }

	public DrawablePushClipPath(string clipPath)
	{
		ClipPath = clipPath;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.PushClipPath(ClipPath);
	}
}
