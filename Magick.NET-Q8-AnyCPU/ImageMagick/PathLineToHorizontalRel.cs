namespace ImageMagick;

public sealed class PathLineToHorizontalRel : IPath, IDrawingWand
{
	public double X { get; set; }

	public PathLineToHorizontalRel(double x)
	{
		X = x;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.PathLineToHorizontalRel(X);
	}
}
