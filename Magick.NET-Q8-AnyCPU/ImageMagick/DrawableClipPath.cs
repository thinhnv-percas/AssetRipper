namespace ImageMagick;

public sealed class DrawableClipPath : IDrawable, IDrawingWand
{
	public string ClipPath { get; set; }

	public DrawableClipPath(string clipPath)
	{
		Throw.IfNullOrEmpty("clipPath", clipPath);
		ClipPath = clipPath;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.ClipPath(ClipPath);
	}
}
