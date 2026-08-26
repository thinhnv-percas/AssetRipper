namespace ImageMagick;

public sealed class PathSmoothCurveToAbs : IPath, IDrawingWand
{
	private readonly PointD _controlPoint;

	private readonly PointD _end;

	public PathSmoothCurveToAbs(double x2, double y2, double x, double y)
		: this(new PointD(x2, y2), new PointD(x, y))
	{
	}

	public PathSmoothCurveToAbs(PointD controlPoint, PointD end)
	{
		_controlPoint = controlPoint;
		_end = end;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.PathSmoothCurveToAbs(_controlPoint, _end);
	}
}
