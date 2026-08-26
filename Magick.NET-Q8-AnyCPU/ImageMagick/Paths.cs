using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ImageMagick;

[GeneratedCode("Magick.NET.FileGenerator", "")]
public sealed class Paths : IEnumerable<IPath>, IEnumerable
{
	private readonly Drawables _drawables;

	private readonly Collection<IPath> _paths;

	public Paths ArcAbs(params PathArc[] pathArcs)
	{
		_paths.Add(new PathArcAbs(pathArcs));
		return this;
	}

	public Paths ArcAbs(IEnumerable<PathArc> pathArcs)
	{
		_paths.Add(new PathArcAbs(pathArcs));
		return this;
	}

	public Paths ArcRel(params PathArc[] pathArcs)
	{
		_paths.Add(new PathArcRel(pathArcs));
		return this;
	}

	public Paths ArcRel(IEnumerable<PathArc> pathArcs)
	{
		_paths.Add(new PathArcRel(pathArcs));
		return this;
	}

	public Paths Close()
	{
		_paths.Add(new PathClose());
		return this;
	}

	public Paths CurveToAbs(PointD controlPointStart, PointD controlPointEnd, PointD end)
	{
		_paths.Add(new PathCurveToAbs(controlPointStart, controlPointEnd, end));
		return this;
	}

	public Paths CurveToAbs(double x1, double y1, double x2, double y2, double x, double y)
	{
		_paths.Add(new PathCurveToAbs(x1, y1, x2, y2, x, y));
		return this;
	}

	public Paths CurveToRel(PointD controlPointStart, PointD controlPointEnd, PointD end)
	{
		_paths.Add(new PathCurveToRel(controlPointStart, controlPointEnd, end));
		return this;
	}

	public Paths CurveToRel(double x1, double y1, double x2, double y2, double x, double y)
	{
		_paths.Add(new PathCurveToRel(x1, y1, x2, y2, x, y));
		return this;
	}

	public Paths LineToAbs(params PointD[] coordinates)
	{
		_paths.Add(new PathLineToAbs(coordinates));
		return this;
	}

	public Paths LineToAbs(IEnumerable<PointD> coordinates)
	{
		_paths.Add(new PathLineToAbs(coordinates));
		return this;
	}

	public Paths LineToAbs(double x, double y)
	{
		_paths.Add(new PathLineToAbs(x, y));
		return this;
	}

	public Paths LineToHorizontalAbs(double x)
	{
		_paths.Add(new PathLineToHorizontalAbs(x));
		return this;
	}

	public Paths LineToHorizontalRel(double x)
	{
		_paths.Add(new PathLineToHorizontalRel(x));
		return this;
	}

	public Paths LineToRel(params PointD[] coordinates)
	{
		_paths.Add(new PathLineToRel(coordinates));
		return this;
	}

	public Paths LineToRel(IEnumerable<PointD> coordinates)
	{
		_paths.Add(new PathLineToRel(coordinates));
		return this;
	}

	public Paths LineToRel(double x, double y)
	{
		_paths.Add(new PathLineToRel(x, y));
		return this;
	}

	public Paths LineToVerticalAbs(double y)
	{
		_paths.Add(new PathLineToVerticalAbs(y));
		return this;
	}

	public Paths LineToVerticalRel(double y)
	{
		_paths.Add(new PathLineToVerticalRel(y));
		return this;
	}

	public Paths MoveToAbs(PointD coordinate)
	{
		_paths.Add(new PathMoveToAbs(coordinate));
		return this;
	}

	public Paths MoveToAbs(double x, double y)
	{
		_paths.Add(new PathMoveToAbs(x, y));
		return this;
	}

	public Paths MoveToRel(PointD coordinate)
	{
		_paths.Add(new PathMoveToRel(coordinate));
		return this;
	}

	public Paths MoveToRel(double x, double y)
	{
		_paths.Add(new PathMoveToRel(x, y));
		return this;
	}

	public Paths QuadraticCurveToAbs(PointD controlPoint, PointD end)
	{
		_paths.Add(new PathQuadraticCurveToAbs(controlPoint, end));
		return this;
	}

	public Paths QuadraticCurveToAbs(double x1, double y1, double x, double y)
	{
		_paths.Add(new PathQuadraticCurveToAbs(x1, y1, x, y));
		return this;
	}

	public Paths QuadraticCurveToRel(PointD controlPoint, PointD end)
	{
		_paths.Add(new PathQuadraticCurveToRel(controlPoint, end));
		return this;
	}

	public Paths QuadraticCurveToRel(double x1, double y1, double x, double y)
	{
		_paths.Add(new PathQuadraticCurveToRel(x1, y1, x, y));
		return this;
	}

	public Paths SmoothCurveToAbs(PointD controlPoint, PointD end)
	{
		_paths.Add(new PathSmoothCurveToAbs(controlPoint, end));
		return this;
	}

	public Paths SmoothCurveToAbs(double x2, double y2, double x, double y)
	{
		_paths.Add(new PathSmoothCurveToAbs(x2, y2, x, y));
		return this;
	}

	public Paths SmoothCurveToRel(PointD controlPoint, PointD end)
	{
		_paths.Add(new PathSmoothCurveToRel(controlPoint, end));
		return this;
	}

	public Paths SmoothCurveToRel(double x2, double y2, double x, double y)
	{
		_paths.Add(new PathSmoothCurveToRel(x2, y2, x, y));
		return this;
	}

	public Paths SmoothQuadraticCurveToAbs(PointD end)
	{
		_paths.Add(new PathSmoothQuadraticCurveToAbs(end));
		return this;
	}

	public Paths SmoothQuadraticCurveToAbs(double x, double y)
	{
		_paths.Add(new PathSmoothQuadraticCurveToAbs(x, y));
		return this;
	}

	public Paths SmoothQuadraticCurveToRel(PointD end)
	{
		_paths.Add(new PathSmoothQuadraticCurveToRel(end));
		return this;
	}

	public Paths SmoothQuadraticCurveToRel(double x, double y)
	{
		_paths.Add(new PathSmoothQuadraticCurveToRel(x, y));
		return this;
	}

	public Paths()
	{
		_paths = new Collection<IPath>();
	}

	internal Paths(Drawables drawables)
		: this()
	{
		_drawables = drawables;
	}

	public static implicit operator Drawables(Paths paths)
	{
		if (paths == null)
		{
			return null;
		}
		if (paths._drawables == null)
		{
			return new Drawables().Path(paths);
		}
		return paths._drawables.Path(paths);
	}

	public IEnumerator<IPath> GetEnumerator()
	{
		return _paths.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
