namespace ImageMagick;

public sealed class PathCurveToAbs : IPath, IDrawingWand
{
	private readonly PointD _controlPointStart;

	private readonly PointD _controlPointEnd;

	private readonly PointD _end;

	public PathCurveToAbs(double x1, double y1, double x2, double y2, double x, double y)
		: this(new PointD(x1, y1), new PointD(x2, y2), new PointD(x, y))
	{
	}

	public PathCurveToAbs(PointD controlPointStart, PointD controlPointEnd, PointD end)
	{
		_controlPointStart = controlPointStart;
		_controlPointEnd = controlPointEnd;
		_end = end;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.PathCurveToAbs(_controlPointStart, _controlPointEnd, _end);
	}
}
