using System;
using System.Windows;

namespace HelixToolkit.Wpf;

internal class StatusHelperElement
{
	private double mFactor;

	public PolygonEdge Edge { get; set; }

	public PolygonPoint Helper { get; set; }

	public double Factor => mFactor;

	public double MinX { get; private set; }

	internal StatusHelperElement(PolygonEdge edge, PolygonPoint point)
	{
		Edge = edge;
		Helper = point;
		Vector vector = edge.PointTwo.Point - edge.PointOne.Point;
		mFactor = vector.X / vector.Y;
		MinX = Math.Min(edge.PointOne.X, edge.PointTwo.X);
	}
}
