using System.Collections.Generic;

namespace ImageMagick;

public sealed class DrawablePolyline : IDrawable, IDrawingWand
{
	private readonly PointDCoordinates _coordinates;

	public DrawablePolyline(params PointD[] coordinates)
	{
		_coordinates = new PointDCoordinates(coordinates, 3);
	}

	public DrawablePolyline(IEnumerable<PointD> coordinates)
	{
		_coordinates = new PointDCoordinates(coordinates, 3);
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.Polyline(_coordinates.ToList());
	}
}
