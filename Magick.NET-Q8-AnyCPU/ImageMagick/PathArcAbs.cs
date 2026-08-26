using System.Collections.Generic;

namespace ImageMagick;

public sealed class PathArcAbs : IPath, IDrawingWand
{
	private readonly PathArcCoordinates _coordinates;

	public PathArcAbs(params PathArc[] pathArcs)
	{
		_coordinates = new PathArcCoordinates(pathArcs);
	}

	public PathArcAbs(IEnumerable<PathArc> pathArcs)
	{
		_coordinates = new PathArcCoordinates(pathArcs);
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.PathArcAbs(_coordinates.ToList());
	}
}
