namespace ImageMagick;

public sealed class PathClose : IPath, IDrawingWand
{
	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.PathClose();
	}
}
