using System.Collections.Generic;

namespace ImageMagick;

internal class PathArcCoordinates : DrawableCoordinates<PathArc>
{
	public PathArcCoordinates(IEnumerable<PathArc> coordinates)
		: base(coordinates, 0)
	{
	}
}
