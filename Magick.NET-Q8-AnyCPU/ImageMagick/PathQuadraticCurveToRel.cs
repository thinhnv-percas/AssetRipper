namespace ImageMagick;

public sealed class PathQuadraticCurveToRel : IPath, IDrawingWand
{
	private readonly PointD _controlPoint;

	private readonly PointD _end;

	public PathQuadraticCurveToRel(double x1, double y1, double x, double y)
		: this(new PointD(x1, y1), new PointD(x, y))
	{
	}

	public PathQuadraticCurveToRel(PointD controlPoint, PointD end)
	{
		_controlPoint = controlPoint;
		_end = end;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.PathQuadraticCurveToRel(_controlPoint, _end);
	}
}
