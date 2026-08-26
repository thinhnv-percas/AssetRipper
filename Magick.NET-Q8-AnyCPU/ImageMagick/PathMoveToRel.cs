namespace ImageMagick;

public sealed class PathMoveToRel : IPath, IDrawingWand
{
	private readonly PointD _coordinate;

	public PathMoveToRel(double x, double y)
		: this(new PointD(x, y))
	{
	}

	public PathMoveToRel(PointD coordinate)
	{
		_coordinate = coordinate;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.PathMoveToRel(_coordinate.X, _coordinate.Y);
	}
}
