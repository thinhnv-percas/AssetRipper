using System;
using System.Collections.Generic;

namespace ImageMagick;

internal abstract class DrawableCoordinates<TCoordinateType>
{
	protected List<TCoordinateType> Coordinates { get; private set; }

	protected DrawableCoordinates(IEnumerable<TCoordinateType> coordinates, int minCount)
	{
		Throw.IfNull("coordinates", coordinates);
		CheckCoordinates(new List<TCoordinateType>(coordinates), minCount);
	}

	public IList<TCoordinateType> ToList()
	{
		return Coordinates;
	}

	private void CheckCoordinates(List<TCoordinateType> coordinates, int minCount)
	{
		if (coordinates.Count == 0)
		{
			throw new ArgumentException("Value cannot be empty", "coordinates");
		}
		foreach (TCoordinateType coordinate in coordinates)
		{
			if (coordinate == null)
			{
				throw new ArgumentNullException("coordinates", "Value should not contain null values");
			}
		}
		if (coordinates.Count < minCount)
		{
			throw new ArgumentException("Value should contain at least " + minCount + " coordinates.", "coordinates");
		}
		Coordinates = coordinates;
	}
}
