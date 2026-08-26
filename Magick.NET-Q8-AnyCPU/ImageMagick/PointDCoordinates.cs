using System.Collections.Generic;

namespace ImageMagick;

internal class PointDCoordinates : DrawableCoordinates<PointD>
{
	public PointDCoordinates(IEnumerable<PointD> coordinates)
		: this(coordinates, 0)
	{
	}

	public PointDCoordinates(IEnumerable<PointD> coordinates, int minCount)
		: base(coordinates, minCount)
	{
	}

	public PointDCoordinates(params PointD[] coordinates)
		: this((IEnumerable<PointD>)coordinates)
	{
	}
}
