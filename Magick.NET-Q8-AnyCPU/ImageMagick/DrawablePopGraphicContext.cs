namespace ImageMagick;

public sealed class DrawablePopGraphicContext : IDrawable, IDrawingWand
{
	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.PopGraphicContext();
	}
}
