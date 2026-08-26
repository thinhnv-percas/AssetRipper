namespace ImageMagick;

public sealed class PathLineToHorizontalAbs : IPath, IDrawingWand
{
	public double X { get; set; }

	public PathLineToHorizontalAbs(double x)
	{
		X = x;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.PathLineToHorizontalAbs(X);
	}
}
