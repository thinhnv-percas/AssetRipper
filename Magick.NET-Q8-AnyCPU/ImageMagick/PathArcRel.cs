using System.Collections.Generic;

namespace ImageMagick;

public sealed class PathArcRel : IPath, IDrawingWand
{
	private readonly PathArcCoordinates _coordinates;

	public PathArcRel(params PathArc[] pathArcs)
	{
		_coordinates = new PathArcCoordinates(pathArcs);
	}

	public PathArcRel(IEnumerable<PathArc> pathArcs)
	{
		_coordinates = new PathArcCoordinates(pathArcs);
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.PathArcRel(_coordinates.ToList());
	}
}
