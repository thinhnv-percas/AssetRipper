using System.Collections.Generic;

namespace HelixToolkit.Wpf;

internal class StatusHelper
{
	internal List<StatusHelperElement> EdgesHelpers { get; set; }

	internal StatusHelper()
	{
		EdgesHelpers = new List<StatusHelperElement>();
	}

	internal void Add(StatusHelperElement element)
	{
		EdgesHelpers.Add(element);
	}

	internal void Remove(PolygonEdge edge)
	{
		EdgesHelpers.RemoveAll((StatusHelperElement she) => she.Edge == edge);
	}

	internal StatusHelperElement SearchLeft(PolygonPoint point)
	{
		StatusHelperElement result = null;
		double num = double.PositiveInfinity;
		double x = point.X;
		double y = point.Y;
		foreach (StatusHelperElement edgesHelper in EdgesHelpers)
		{
			if (edgesHelper.MinX > x)
			{
				continue;
			}
			double num2 = edgesHelper.Edge.PointOne.X + (y - edgesHelper.Edge.PointOne.Y) * edgesHelper.Factor;
			if (num2 <= x + (double)SweepLinePolygonTriangulator.Epsilon)
			{
				double num3 = x - num2;
				if (num3 < num)
				{
					num = num3;
					result = edgesHelper;
				}
			}
		}
		return result;
	}
}
