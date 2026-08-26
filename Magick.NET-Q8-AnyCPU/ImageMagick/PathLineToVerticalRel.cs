namespace ImageMagick;

public sealed class PathLineToVerticalRel : IPath, IDrawingWand
{
	public double Y { get; set; }

	public PathLineToVerticalRel(double y)
	{
		Y = y;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.PathLineToVerticalRel(Y);
	}
}
