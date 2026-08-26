using System;

namespace XnaGeometry
{
	public struct Point : IEquatable<Point>
	{
		private static Point _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A;

		public int X;

		public int Y;

		public static Point Zero => _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A;

		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}

		public static bool operator ==(Point a, Point b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(Point a, Point b)
		{
			return !a.Equals(b);
		}

		public bool Equals(Point other)
		{
			if (X == other.X)
			{
				return Y == other.Y;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Point))
			{
				return false;
			}
			return Equals((Point)obj);
		}

		public override int GetHashCode()
		{
			return X ^ Y;
		}

		public override string ToString()
		{
			return $"{{X:{X} Y:{Y}}}";
		}
	}
}
