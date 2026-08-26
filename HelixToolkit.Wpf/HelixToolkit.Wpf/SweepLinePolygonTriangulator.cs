using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace HelixToolkit.Wpf;

public static class SweepLinePolygonTriangulator
{
	public static float Epsilon = 1E-07f;

	public static Int32Collection Triangulate(IList<Point> polygon, List<List<Point>> holes = null)
	{
		Int32Collection int32Collection = new Int32Collection();
		List<Point> list = polygon.ToList();
		if (list[0] == list[list.Count - 1])
		{
			list.RemoveAt(list.Count - 1);
		}
		int count = list.Count;
		bool flag = false;
		if (!IsCCW(polygon))
		{
			list.Reverse();
			flag = true;
		}
		if (count < 3)
		{
			return null;
		}
		if (count == 3)
		{
			if (!flag)
			{
				return new Int32Collection { 0, 1, 2 };
			}
			return new Int32Collection { 2, 1, 1 };
		}
		PolygonData polygonData = new PolygonData(list);
		if (holes != null)
		{
			foreach (List<Point> hole in holes)
			{
				polygonData.AddHole(hole);
			}
		}
		List<PolygonPoint> list2 = new List<PolygonPoint>(polygonData.Points);
		list2.Sort();
		List<Tuple<int, int>> list3 = CalculateDiagonals(list2);
		list2.Reverse();
		list3.AddRange(CalculateDiagonals(list2, sweepDown: false));
		list3 = list3.Distinct().ToList();
		List<PolygonData> source = SplitIntoPolygons(polygonData, list3);
		foreach (PolygonData item in source.Where((PolygonData m) => m != null))
		{
			Int32Collection int32Collection2 = TriangulateMonotone(item);
			foreach (int item2 in int32Collection2)
			{
				int32Collection.Add(item2);
			}
		}
		if (flag)
		{
			for (int num = 0; num < int32Collection.Count; num++)
			{
				int32Collection[num] = count - int32Collection[num] - 1;
			}
		}
		return int32Collection;
	}

	private static Int32Collection TriangulateMonotone(PolygonData monoton)
	{
		Int32Collection int32Collection = new Int32Collection();
		List<PolygonPoint> list = new List<PolygonPoint>(monoton.Points);
		list.Sort();
		Stack<PolygonPoint> stack = new Stack<PolygonPoint>();
		stack.Push(list[0]);
		stack.Push(list[1]);
		PolygonPoint polygonPoint = ((list[0].Next == list[1]) ? list[1] : list[0]);
		PolygonPoint polygonPoint2 = ((list[0].Last == list[1]) ? list[1] : list[0]);
		int count = monoton.Points.Count;
		for (int i = 2; i < count; i++)
		{
			PolygonPoint polygonPoint3 = list[i];
			PolygonPoint polygonPoint4 = stack.Peek();
			if (polygonPoint4.Last != polygonPoint3 && polygonPoint4.Next != polygonPoint3)
			{
				if (polygonPoint.Next == polygonPoint3)
				{
					polygonPoint = polygonPoint3;
				}
				else if (polygonPoint2.Last == polygonPoint3)
				{
					polygonPoint2 = polygonPoint3;
				}
				PolygonPoint polygonPoint5 = polygonPoint4;
				while (stack.Count != 0)
				{
					polygonPoint4 = stack.Pop();
					polygonPoint5 = polygonPoint4;
					if (stack.Count != 0)
					{
						polygonPoint4 = stack.Pop();
						if (polygonPoint == polygonPoint3)
						{
							int32Collection.Add(polygonPoint3.Index);
							int32Collection.Add(polygonPoint5.Index);
							int32Collection.Add(polygonPoint4.Index);
						}
						else
						{
							int32Collection.Add(polygonPoint3.Index);
							int32Collection.Add(polygonPoint4.Index);
							int32Collection.Add(polygonPoint5.Index);
						}
					}
					if (stack.Count != 0)
					{
						stack.Push(polygonPoint4);
					}
				}
				stack.Push(list[i - 1]);
				stack.Push(polygonPoint3);
				continue;
			}
			polygonPoint4 = stack.Pop();
			PolygonPoint polygonPoint6 = polygonPoint4;
			if (polygonPoint.Next == polygonPoint3 && polygonPoint2.Last == polygonPoint3)
			{
				if (polygonPoint4.Last == polygonPoint3)
				{
					polygonPoint2 = polygonPoint3;
				}
				else
				{
					if (polygonPoint4.Next != polygonPoint3)
					{
						throw new Exception("Triangulation error");
					}
					polygonPoint = polygonPoint3;
				}
			}
			else if (polygonPoint.Next == polygonPoint3)
			{
				polygonPoint = polygonPoint3;
			}
			else if (polygonPoint2.Last == polygonPoint3)
			{
				polygonPoint2 = polygonPoint3;
			}
			while (stack.Count != 0)
			{
				if (polygonPoint2 == polygonPoint3 && IsCCW(new List<Point>
				{
					polygonPoint3.Point,
					polygonPoint6.Point,
					stack.Peek().Point
				}))
				{
					polygonPoint4 = stack.Pop();
					int32Collection.Add(polygonPoint3.Index);
					int32Collection.Add(polygonPoint6.Index);
					int32Collection.Add(polygonPoint4.Index);
					polygonPoint6 = polygonPoint4;
					continue;
				}
				if (polygonPoint == polygonPoint3 && !IsCCW(new List<Point>
				{
					polygonPoint3.Point,
					polygonPoint6.Point,
					stack.Peek().Point
				}))
				{
					polygonPoint4 = stack.Pop();
					int32Collection.Add(polygonPoint3.Index);
					int32Collection.Add(polygonPoint4.Index);
					int32Collection.Add(polygonPoint6.Index);
					polygonPoint6 = polygonPoint4;
					continue;
				}
				break;
			}
			stack.Push(polygonPoint6);
			stack.Push(polygonPoint3);
		}
		return int32Collection;
	}

	private static List<Tuple<int, int>> CalculateDiagonals(List<PolygonPoint> events, bool sweepDown = true)
	{
		List<Tuple<int, int>> list = new List<Tuple<int, int>>();
		StatusHelper statusHelper = new StatusHelper();
		for (int i = 0; i < events.Count; i++)
		{
			PolygonPoint polygonPoint = events[i];
			PolygonPointClass polygonPointClass = polygonPoint.PointClass(!sweepDown);
			StatusHelperElement statusHelperElement = null;
			switch (polygonPointClass)
			{
			case PolygonPointClass.Start:
				statusHelper.Add(new StatusHelperElement(sweepDown ? polygonPoint.EdgeTwo : polygonPoint.EdgeOne, polygonPoint));
				break;
			case PolygonPointClass.Stop:
				statusHelper.Remove(sweepDown ? polygonPoint.EdgeOne : polygonPoint.EdgeTwo);
				break;
			case PolygonPointClass.Regular:
				if (polygonPoint.Last > polygonPoint.Next)
				{
					statusHelper.Remove(sweepDown ? polygonPoint.EdgeOne : polygonPoint.EdgeTwo);
					statusHelper.Add(new StatusHelperElement(sweepDown ? polygonPoint.EdgeTwo : polygonPoint.EdgeOne, polygonPoint));
				}
				else
				{
					statusHelperElement = statusHelper.SearchLeft(polygonPoint);
					statusHelperElement.Helper = polygonPoint;
				}
				break;
			case PolygonPointClass.Merge:
				statusHelper.Remove(sweepDown ? polygonPoint.EdgeOne : polygonPoint.EdgeTwo);
				statusHelperElement = statusHelper.SearchLeft(polygonPoint);
				statusHelperElement.Helper = polygonPoint;
				break;
			case PolygonPointClass.Split:
			{
				statusHelperElement = statusHelper.SearchLeft(polygonPoint);
				int item = Math.Min(statusHelperElement.Helper.Index, polygonPoint.Index);
				int item2 = Math.Max(statusHelperElement.Helper.Index, polygonPoint.Index);
				Tuple<int, int> item3 = new Tuple<int, int>(item, item2);
				list.Add(item3);
				statusHelperElement.Helper = polygonPoint;
				statusHelper.Add(new StatusHelperElement(sweepDown ? polygonPoint.EdgeTwo : polygonPoint.EdgeOne, polygonPoint));
				break;
			}
			}
		}
		return list;
	}

	private static List<PolygonData> SplitIntoPolygons(PolygonData poly, List<Tuple<int, int>> diagonals)
	{
		if (diagonals.Count == 0)
		{
			return new List<PolygonData> { poly };
		}
		diagonals = (from d in diagonals
			orderby d.Item1, d.Item2
			select d).ToList();
		SortedDictionary<int, List<PolygonEdge>> sortedDictionary = new SortedDictionary<int, List<PolygonEdge>>();
		foreach (PolygonEdge item in poly.Points.Select((PolygonPoint p) => p.EdgeTwo).Union(diagonals.Select((Tuple<int, int> d) => new PolygonEdge(poly.Points[d.Item1], poly.Points[d.Item2]))).Union(diagonals.Select((Tuple<int, int> d) => new PolygonEdge(poly.Points[d.Item2], poly.Points[d.Item1]))))
		{
			if (!sortedDictionary.ContainsKey(item.PointOne.Index))
			{
				sortedDictionary.Add(item.PointOne.Index, new List<PolygonEdge> { item });
			}
			else
			{
				sortedDictionary[item.PointOne.Index].Add(item);
			}
		}
		List<PolygonData> list = new List<PolygonData>();
		int num = 0;
		foreach (KeyValuePair<int, List<PolygonEdge>> item2 in sortedDictionary)
		{
			num += item2.Value.Count;
		}
		while (sortedDictionary.Count > 0)
		{
			PolygonPoint polygonPoint = sortedDictionary.First().Value.First().PointOne;
			PolygonEdge polygonEdge = new PolygonEdge(null, null);
			List<PolygonPoint> list2 = new List<PolygonPoint>();
			do
			{
				list2.Add(polygonPoint);
				List<PolygonEdge> possibleEdges = sortedDictionary[polygonPoint.Index].ToList();
				polygonEdge = BestEdge(polygonPoint, polygonEdge, possibleEdges);
				sortedDictionary[polygonPoint.Index].Remove(polygonEdge);
				if (sortedDictionary[polygonPoint.Index].Count == 0)
				{
					sortedDictionary.Remove(polygonPoint.Index);
				}
				polygonPoint = polygonEdge.PointTwo;
			}
			while (list2[0].Index != polygonPoint.Index);
			list.Add(new PolygonData(list2));
		}
		return list;
	}

	internal static PolygonEdge BestEdge(PolygonPoint point, PolygonEdge lastEdge, List<PolygonEdge> possibleEdges)
	{
		if ((lastEdge.PointOne == null && lastEdge.PointTwo == null) || possibleEdges.Count == 1)
		{
			return possibleEdges[0];
		}
		PolygonEdge result = possibleEdges[0];
		float num = (float)Math.PI * 2f;
		Vector vector = lastEdge.PointTwo.Point - lastEdge.PointOne.Point;
		vector.Normalize();
		Point point2 = new Point(0.0 - vector.Y, vector.X);
		foreach (PolygonEdge possibleEdge in possibleEdges)
		{
			Vector vector2 = possibleEdge.PointTwo.Point - possibleEdge.PointOne.Point;
			vector2.Normalize();
			double num2 = point2.X * vector2.X + point2.Y * vector2.Y;
			double d = vector.X * vector2.X + vector.Y * vector2.Y;
			float num3 = 0f;
			num3 = ((!(point2.X * vector2.X + point2.Y * vector2.Y > 0.0)) ? ((float)Math.PI + (float)Math.Acos(d)) : ((float)Math.PI - (float)Math.Acos(d)));
			if (num3 < num)
			{
				num = num3;
				result = possibleEdge;
			}
		}
		return result;
	}

	internal static bool IsCCW(IList<Point> polygon)
	{
		int count = polygon.Count;
		double num = 0.0;
		int index = count - 1;
		int num2 = 0;
		while (num2 < count)
		{
			num += polygon[index].X * polygon[num2].Y - polygon[num2].X * polygon[index].Y;
			index = num2++;
		}
		return num > 0.0;
	}
}
