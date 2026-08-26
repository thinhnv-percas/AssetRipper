namespace ImageMagick;

public sealed class PathSmoothQuadraticCurveToAbs : IPath, IDrawingWand
{
	private readonly PointD _end;

	public PathSmoothQuadraticCurveToAbs(double x, double y)
		: this(new PointD(x, y))
	{
	}

	public PathSmoothQuadraticCurveToAbs(PointD end)
	{
		_end = end;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.PathSmoothQuadraticCurveToAbs(_end);
	}
}
