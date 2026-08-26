using System.Collections.Generic;

namespace ImageMagick;

public sealed class DrawableBezier : IDrawable, IDrawingWand
{
	private readonly PointDCoordinates _coordinates;

	public IEnumerable<PointD> Coordinates => _coordinates.ToList();

	public DrawableBezier(params PointD[] coordinates)
	{
		_coordinates = new PointDCoordinates(coordinates, 3);
	}

	public DrawableBezier(IEnumerable<PointD> coordinates)
	{
		_coordinates = new PointDCoordinates(coordinates, 3);
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.Bezier(_coordinates.ToList());
	}
}
