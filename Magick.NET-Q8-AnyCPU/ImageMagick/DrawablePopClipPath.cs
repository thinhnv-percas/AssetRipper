namespace ImageMagick;

public sealed class DrawablePopClipPath : IDrawable, IDrawingWand
{
	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.PopClipPath();
	}
}
