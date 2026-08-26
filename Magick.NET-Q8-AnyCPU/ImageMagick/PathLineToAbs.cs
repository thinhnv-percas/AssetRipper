using System.Collections.Generic;

namespace ImageMagick;

public sealed class PathLineToAbs : IPath, IDrawingWand
{
	private readonly PointDCoordinates _coordinates;

	public PathLineToAbs(double x, double y)
		: this(new PointD(x, y))
	{
	}

	public PathLineToAbs(params PointD[] coordinates)
	{
		_coordinates = new PointDCoordinates(coordinates);
	}

	public PathLineToAbs(IEnumerable<PointD> coordinates)
	{
		_coordinates = new PointDCoordinates(coordinates);
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.PathLineToAbs(_coordinates.ToList());
	}
}
