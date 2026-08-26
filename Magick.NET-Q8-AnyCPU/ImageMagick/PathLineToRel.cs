using System.Collections.Generic;

namespace ImageMagick;

public sealed class PathLineToRel : IPath, IDrawingWand
{
	private readonly PointDCoordinates _coordinates;

	public PathLineToRel(double x, double y)
		: this(new PointD(x, y))
	{
	}

	public PathLineToRel(params PointD[] coordinates)
	{
		_coordinates = new PointDCoordinates(coordinates);
	}

	public PathLineToRel(IEnumerable<PointD> coordinates)
	{
		_coordinates = new PointDCoordinates(coordinates);
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.PathLineToRel(_coordinates.ToList());
	}
}
