using System;
using System.Windows;

namespace HelixToolkit.Wpf;

internal class PolygonPoint : IComparable<PolygonPoint>
{
	private Point mPoint;

	private PolygonEdge mEdgeOne;

	private PolygonEdge mEdgeTwo;

	private int mIndex;

	public Point Point
	{
		get
		{
			return mPoint;
		}
		set
		{
			mPoint = value;
		}
	}

	public double X
	{
		get
		{
			return mPoint.X;
		}
		set
		{
			mPoint.X = value;
		}
	}

	public double Y
	{
		get
		{
			return mPoint.Y;
		}
		set
		{
			mPoint.Y = value;
		}
	}

	public PolygonEdge EdgeOne
	{
		get
		{
			return mEdgeOne;
		}
		set
		{
			mEdgeOne = value;
		}
	}

	public PolygonEdge EdgeTwo
	{
		get
		{
			return mEdgeTwo;
		}
		set
		{
			mEdgeTwo = value;
		}
	}

	public int Index
	{
		get
		{
			return mIndex;
		}
		set
		{
			mIndex = value;
		}
	}

	public PolygonPoint Last
	{
		get
		{
			if (mEdgeOne != null && mEdgeOne.PointOne != null)
			{
				return mEdgeOne.PointOne;
			}
			return null;
		}
	}

	public PolygonPoint Next
	{
		get
		{
			if (mEdgeTwo != null && mEdgeTwo.PointTwo != null)
			{
				return mEdgeTwo.PointTwo;
			}
			return null;
		}
	}

	public static bool operator <(PolygonPoint first, PolygonPoint second)
	{
		return first.CompareTo(second) == 1;
	}

	public static bool operator >(PolygonPoint first, PolygonPoint second)
	{
		return first.CompareTo(second) == -1;
	}

	internal PolygonPoint(Point p)
	{
		mPoint = p;
		mIndex = -1;
	}

	internal PolygonPointClass PointClass(bool reverse = false)
	{
		if (Next == null || Last == null)
		{
			throw new Exception("No closed Polygon");
		}
		if (!reverse)
		{
			if (Last < this && Next < this && isConvexPoint())
			{
				return PolygonPointClass.Start;
			}
			if (Last > this && Next > this && isConvexPoint())
			{
				return PolygonPointClass.Stop;
			}
			if (Last < this && Next < this)
			{
				return PolygonPointClass.Split;
			}
			if (Last > this && Next > this)
			{
				return PolygonPointClass.Merge;
			}
			return PolygonPointClass.Regular;
		}
		if (Last < this && Next < this && isConvexPoint())
		{
			return PolygonPointClass.Stop;
		}
		if (Last > this && Next > this && isConvexPoint())
		{
			return PolygonPointClass.Start;
		}
		if (Last < this && Next < this)
		{
			return PolygonPointClass.Merge;
		}
		if (Last > this && Next > this)
		{
			return PolygonPointClass.Split;
		}
		return PolygonPointClass.Regular;
	}

	private bool isConvexPoint()
	{
		if (Next == null || Last == null)
		{
			throw new Exception("No closed Polygon");
		}
		Vector vector = Point - Last.Point;
		vector.Normalize();
		Point point = new Point(0.0 - vector.Y, vector.X);
		Vector vector2 = Next.Point - Point;
		vector2.Normalize();
		if (point.X * vector2.X + point.Y * vector2.Y >= 0.0)
		{
			return true;
		}
		return false;
	}

	public override string ToString()
	{
		return Index + " X:" + X + " Y:" + Y;
	}

	public int CompareTo(PolygonPoint second)
	{
		if (this == null || second == null)
		{
			return 0;
		}
		if (Y > second.Y || (Y == second.Y && X < second.X))
		{
			return -1;
		}
		if (Y == second.Y && X == second.X)
		{
			return 0;
		}
		return 1;
	}
}
