namespace ImageMagick;

public sealed class DrawablePopPattern : IDrawable, IDrawingWand
{
	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.PopPattern();
	}
}
