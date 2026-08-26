using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace HelixToolkit.Wpf;

internal class PolygonData
{
	private List<PolygonPoint> mPoints;

	private List<List<PolygonPoint>> mHoles;

	private int mNumBoundaryPoints;

	public List<PolygonPoint> Points
	{
		get
		{
			return mPoints;
		}
		set
		{
			mPoints = value;
		}
	}

	public bool HasHoles => mHoles.Count > 0;

	public List<List<PolygonPoint>> Holes => mHoles;

	public PolygonData(List<Point> points, List<int> indices = null)
	{
		mPoints = new List<PolygonPoint>(points.Select((Point p) => new PolygonPoint(p)));
		mHoles = new List<List<PolygonPoint>>();
		mNumBoundaryPoints = mPoints.Count;
		if (indices == null)
		{
			for (int num = 0; num < mPoints.Count; num++)
			{
				mPoints[num].Index = num;
			}
		}
		else
		{
			for (int num2 = 0; num2 < mPoints.Count; num2++)
			{
				mPoints[num2].Index = indices[num2];
			}
		}
		int count = mPoints.Count;
		for (int num3 = 0; num3 < count; num3++)
		{
			int index = (num3 + count - 1) % count;
			PolygonEdge polygonEdge = new PolygonEdge(mPoints[index], mPoints[num3]);
			mPoints[index].EdgeTwo = polygonEdge;
			mPoints[num3].EdgeOne = polygonEdge;
		}
	}

	public PolygonData(List<PolygonPoint> points)
		: this(points.Select((PolygonPoint p) => p.Point).ToList(), points.Select((PolygonPoint p) => p.Index).ToList())
	{
	}

	internal void AddHole(List<Point> points)
	{
		if (SweepLinePolygonTriangulator.IsCCW(points))
		{
			points.Reverse();
		}
		List<PolygonPoint> list = points.Select((Point p) => new PolygonPoint(p)).ToList();
		if (list[0].Equals(list[list.Count - 1]))
		{
			list.RemoveAt(list.Count - 1);
		}
		mHoles.Add(list);
		int count = mPoints.Count;
		int count2 = points.Count;
		mPoints.AddRange(list);
		for (int num = count; num < mPoints.Count; num++)
		{
			list[num - count].Index = num;
		}
		int count3 = mPoints.Count;
		for (int num2 = 0; num2 < count2; num2++)
		{
			int index = (num2 + count2 - 1) % count2;
			PolygonEdge polygonEdge = new PolygonEdge(list[index], list[num2]);
			list[index].EdgeTwo = polygonEdge;
			list[num2].EdgeOne = polygonEdge;
		}
	}
}
