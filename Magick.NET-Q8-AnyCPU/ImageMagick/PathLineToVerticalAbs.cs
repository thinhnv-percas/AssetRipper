namespace ImageMagick;

public sealed class PathLineToVerticalAbs : IPath, IDrawingWand
{
	public double Y { get; set; }

	public PathLineToVerticalAbs(double y)
	{
		Y = y;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.PathLineToVerticalAbs(Y);
	}
}
