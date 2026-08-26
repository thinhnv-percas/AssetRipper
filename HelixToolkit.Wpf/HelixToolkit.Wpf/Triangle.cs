using System.Windows;

namespace HelixToolkit.Wpf;

public class Triangle
{
	private readonly Point p1;

	private readonly Point p2;

	private readonly Point p3;

	public Point P1 => p1;

	public Point P2 => p2;

	public Point P3 => p3;

	public Triangle(Point a, Point b, Point c)
	{
		p1 = a;
		p2 = b;
		p3 = c;
	}

	public bool IsCompletelyInside(Rect rect)
	{
		return rect.Contains(p2) && rect.Contains(p3) && rect.Contains(P3);
	}

	public bool IsRectCompletelyInside(Rect rect)
	{
		return IsPointInside(rect.TopLeft) && IsPointInside(rect.TopRight) && IsPointInside(rect.BottomLeft) && IsPointInside(rect.BottomRight);
	}

	public bool IsPointInside(Point p)
	{
		double num = p1.Y * p3.X - p1.X * p3.Y + (p3.Y - p1.Y) * p.X + (p1.X - p3.X) * p.Y;
		double num2 = p1.X * p2.Y - p1.Y * p2.X + (p1.Y - p2.Y) * p.X + (p2.X - p1.X) * p.Y;
		if (num < 0.0 != num2 < 0.0)
		{
			return false;
		}
		double num3 = (0.0 - p2.Y) * p3.X + p1.Y * (p3.X - p2.X) + p1.X * (p2.Y - p3.Y) + p2.X * p3.Y;
		if (num3 < 0.0)
		{
			num = 0.0 - num;
			num2 = 0.0 - num2;
			num3 = 0.0 - num3;
		}
		return num > 0.0 && num2 > 0.0 && num + num2 < num3;
	}

	public bool IntersectsWith(Rect rect)
	{
		return LineSegment.AreLineSegmentsIntersecting(p1, p2, rect.BottomLeft, rect.BottomRight) || LineSegment.AreLineSegmentsIntersecting(p1, p2, rect.BottomLeft, rect.TopLeft) || LineSegment.AreLineSegmentsIntersecting(p1, p2, rect.TopLeft, rect.TopRight) || LineSegment.AreLineSegmentsIntersecting(p1, p2, rect.TopRight, rect.BottomRight) || LineSegment.AreLineSegmentsIntersecting(p2, p3, rect.BottomLeft, rect.BottomRight) || LineSegment.AreLineSegmentsIntersecting(p2, p3, rect.BottomLeft, rect.TopLeft) || LineSegment.AreLineSegmentsIntersecting(p2, p3, rect.TopLeft, rect.TopRight) || LineSegment.AreLineSegmentsIntersecting(p2, p3, rect.TopRight, rect.BottomRight) || LineSegment.AreLineSegmentsIntersecting(p3, p1, rect.BottomLeft, rect.BottomRight) || LineSegment.AreLineSegmentsIntersecting(p3, p1, rect.BottomLeft, rect.TopLeft) || LineSegment.AreLineSegmentsIntersecting(p3, p1, rect.TopLeft, rect.TopRight) || LineSegment.AreLineSegmentsIntersecting(p3, p1, rect.TopRight, rect.BottomRight);
	}
}
