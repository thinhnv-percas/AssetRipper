using System.Collections.Generic;

namespace ImageMagick;

public sealed class DrawablePolygon : IDrawable, IDrawingWand
{
	private readonly PointDCoordinates _coordinates;

	public DrawablePolygon(params PointD[] coordinates)
	{
		_coordinates = new PointDCoordinates(coordinates, 3);
	}

	public DrawablePolygon(IEnumerable<PointD> coordinates)
	{
		_coordinates = new PointDCoordinates(coordinates, 3);
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.Polygon(_coordinates.ToList());
	}
}
