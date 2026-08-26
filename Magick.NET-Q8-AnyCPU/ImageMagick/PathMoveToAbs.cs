namespace ImageMagick;

public sealed class PathMoveToAbs : IPath, IDrawingWand
{
	private readonly PointD _coordinate;

	public PathMoveToAbs(double x, double y)
		: this(new PointD(x, y))
	{
	}

	public PathMoveToAbs(PointD coordinate)
	{
		_coordinate = coordinate;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.PathMoveToAbs(_coordinate.X, _coordinate.Y);
	}
}
