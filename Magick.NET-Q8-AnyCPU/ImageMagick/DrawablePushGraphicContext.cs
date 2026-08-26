namespace ImageMagick;

public sealed class DrawablePushGraphicContext : IDrawable, IDrawingWand
{
	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.PushGraphicContext();
	}
}
