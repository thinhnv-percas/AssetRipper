namespace ImageMagick;

public sealed class PathSmoothQuadraticCurveToRel : IPath, IDrawingWand
{
	private readonly PointD _end;

	public PathSmoothQuadraticCurveToRel(double x, double y)
		: this(new PointD(x, y))
	{
	}

	public PathSmoothQuadraticCurveToRel(PointD end)
	{
		_end = end;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.PathSmoothQuadraticCurveToRel(_end);
	}
}
