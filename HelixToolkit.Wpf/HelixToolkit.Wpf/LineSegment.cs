using System.Windows;

namespace HelixToolkit.Wpf;

public class LineSegment
{
	private readonly Point p1;

	private readonly Point p2;

	public Point P1 => p1;

	public Point P2 => p2;

	public LineSegment(Point p1, Point p2)
	{
		this.p1 = p1;
		this.p2 = p2;
	}

	public static bool AreLineSegmentsIntersecting(Point a1, Point a2, Point b1, Point b2)
	{
		if (b1 == b2 || a1 == a2)
		{
			return false;
		}
		if (((a2.X - a1.X) * (b1.Y - a1.Y) - (b1.X - a1.X) * (a2.Y - a1.Y)) * ((a2.X - a1.X) * (b2.Y - a1.Y) - (b2.X - a1.X) * (a2.Y - a1.Y)) > 0.0)
		{
			return false;
		}
		if (((b2.X - b1.X) * (a1.Y - b1.Y) - (a1.X - b1.X) * (b2.Y - b1.Y)) * ((b2.X - b1.X) * (a2.Y - b1.Y) - (a2.X - b1.X) * (b2.Y - b1.Y)) > 0.0)
		{
			return false;
		}
		return true;
	}

	public bool IntersectsWith(LineSegment other)
	{
		return AreLineSegmentsIntersecting(p1, p2, other.p1, other.p2);
	}
}
