using System;

namespace XnaGeometry
{
	public struct Rectangle : IEquatable<Rectangle>
	{
		internal static Rectangle _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A;

		public int X;

		public int Y;

		public int Width;

		public int Height;

		public static Rectangle Empty => _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A;

		public int Left => X;

		public int Right => X + Width;

		public int Top => Y;

		public int Bottom => Y + Height;

		public Point Location
		{
			get
			{
				return new Point(X, Y);
			}
			set
			{
				X = value.X;
				Y = value.Y;
			}
		}

		public Point Center => new Point(X + Width / 2, Y + Height / 2);

		public bool IsEmpty
		{
			get
			{
				if (Width == 0 && Height == 0 && X == 0)
				{
					return Y == 0;
				}
				return false;
			}
		}

		public Rectangle(int x, int y, int width, int height)
		{
			X = x;
			Y = y;
			Width = width;
			Height = height;
		}

		public static bool operator ==(Rectangle a, Rectangle b)
		{
			if (a.X == b.X && a.Y == b.Y && a.Width == b.Width)
			{
				return a.Height == b.Height;
			}
			return false;
		}

		public bool Contains(int x, int y)
		{
			if (X <= x && x < X + Width && Y <= y)
			{
				return y < Y + Height;
			}
			return false;
		}

		public bool Contains(Point value)
		{
			if (X <= value.X && value.X < X + Width && Y <= value.Y)
			{
				return value.Y < Y + Height;
			}
			return false;
		}

		public bool Contains(Rectangle value)
		{
			if (X <= value.X && value.X + value.Width <= X + Width && Y <= value.Y)
			{
				return value.Y + value.Height <= Y + Height;
			}
			return false;
		}

		public static bool operator !=(Rectangle a, Rectangle b)
		{
			return !(a == b);
		}

		public void Offset(Point offset)
		{
			X += offset.X;
			Y += offset.Y;
		}

		public void Offset(int offsetX, int offsetY)
		{
			X += offsetX;
			Y += offsetY;
		}

		public void Inflate(int horizontalValue, int verticalValue)
		{
			X -= horizontalValue;
			Y -= verticalValue;
			Width += horizontalValue * 2;
			Height += verticalValue * 2;
		}

		public bool Equals(Rectangle other)
		{
			return this == other;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Rectangle))
			{
				return false;
			}
			return this == (Rectangle)obj;
		}

		public override string ToString()
		{
			return $"{{X:{X} Y:{Y} Width:{Width} Height:{Height}}}";
		}

		public override int GetHashCode()
		{
			return X ^ Y ^ Width ^ Height;
		}

		public bool Intersects(Rectangle value)
		{
			if (value.Left < Right && Left < value.Right && value.Top < Bottom)
			{
				return Top < value.Bottom;
			}
			return false;
		}

		public void Intersects(ref Rectangle value, out bool result)
		{
			result = (value.Left < Right && Left < value.Right && value.Top < Bottom && Top < value.Bottom);
		}

		public static Rectangle Intersect(Rectangle value1, Rectangle value2)
		{
			Intersect(ref value1, ref value2, out Rectangle result);
			return result;
		}

		public static void Intersect(ref Rectangle value1, ref Rectangle value2, out Rectangle result)
		{
			if (value1.Intersects(value2))
			{
				int num = Math.Min(value1.X + value1.Width, value2.X + value2.Width);
				int num2 = Math.Max(value1.X, value2.X);
				int num3 = Math.Max(value1.Y, value2.Y);
				int num4 = Math.Min(value1.Y + value1.Height, value2.Y + value2.Height);
				result = new Rectangle(num2, num3, num - num2, num4 - num3);
			}
			else
			{
				result = new Rectangle(0, 0, 0, 0);
			}
		}

		public static Rectangle Union(Rectangle value1, Rectangle value2)
		{
			int num = Math.Min(value1.X, value2.X);
			int num2 = Math.Min(value1.Y, value2.Y);
			return new Rectangle(num, num2, Math.Max(value1.Right, value2.Right) - num, Math.Max(value1.Bottom, value2.Bottom) - num2);
		}

		public static void Union(ref Rectangle value1, ref Rectangle value2, out Rectangle result)
		{
			result.X = Math.Min(value1.X, value2.X);
			result.Y = Math.Min(value1.Y, value2.Y);
			result.Width = Math.Max(value1.Right, value2.Right) - result.X;
			result.Height = Math.Max(value1.Bottom, value2.Bottom) - result.Y;
		}
	}
}
