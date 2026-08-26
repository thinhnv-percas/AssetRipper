using System;

namespace XnaGeometry
{
	[Serializable]
	public struct Ray : IEquatable<Ray>
	{
		public Vector3 Direction;

		public Vector3 Position;

		public Ray(Vector3 position, Vector3 direction)
		{
			Position = position;
			Direction = direction;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Ray))
			{
				return false;
			}
			return Equals((Ray)obj);
		}

		public bool Equals(Ray other)
		{
			if (Position.Equals(other.Position))
			{
				return Direction.Equals(other.Direction);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return Position.GetHashCode() ^ Direction.GetHashCode();
		}

		public double? Intersects(BoundingBox box)
		{
			if (Position.X >= box.Min.X && Position.X <= box.Max.X && Position.Y >= box.Min.Y && Position.Y <= box.Max.Y && Position.Z >= box.Min.Z && Position.Z <= box.Max.Z)
			{
				return 0.0;
			}
			Vector3 vector = new Vector3(-1.0);
			if (Position.X < box.Min.X && Direction.X != 0.0)
			{
				vector.X = (box.Min.X - Position.X) / Direction.X;
			}
			else if (Position.X > box.Max.X && Direction.X != 0.0)
			{
				vector.X = (box.Max.X - Position.X) / Direction.X;
			}
			if (Position.Y < box.Min.Y && Direction.Y != 0.0)
			{
				vector.Y = (box.Min.Y - Position.Y) / Direction.Y;
			}
			else if (Position.Y > box.Max.Y && Direction.Y != 0.0)
			{
				vector.Y = (box.Max.Y - Position.Y) / Direction.Y;
			}
			if (Position.Z < box.Min.Z && Direction.Z != 0.0)
			{
				vector.Z = (box.Min.Z - Position.Z) / Direction.Z;
			}
			else if (Position.Z > box.Max.Z && Direction.Z != 0.0)
			{
				vector.Z = (box.Max.Z - Position.Z) / Direction.Z;
			}
			if (vector.X > vector.Y && vector.X > vector.Z)
			{
				if (vector.X < 0.0)
				{
					return null;
				}
				double num = Position.Z + vector.X * Direction.Z;
				if (num < box.Min.Z || num > box.Max.Z)
				{
					return null;
				}
				num = Position.Y + vector.X * Direction.Y;
				if (num < box.Min.Y || num > box.Max.Y)
				{
					return null;
				}
				return vector.X;
			}
			if (vector.Y > vector.X && vector.Y > vector.Z)
			{
				if (vector.Y < 0.0)
				{
					return null;
				}
				double num2 = Position.Z + vector.Y * Direction.Z;
				if (num2 < box.Min.Z || num2 > box.Max.Z)
				{
					return null;
				}
				num2 = Position.X + vector.Y * Direction.X;
				if (num2 < box.Min.X || num2 > box.Max.X)
				{
					return null;
				}
				return vector.Y;
			}
			if (vector.Z < 0.0)
			{
				return null;
			}
			double num3 = Position.X + vector.Z * Direction.X;
			if (num3 < box.Min.X || num3 > box.Max.X)
			{
				return null;
			}
			num3 = Position.Y + vector.Z * Direction.Y;
			if (num3 < box.Min.Y || num3 > box.Max.Y)
			{
				return null;
			}
			return vector.Z;
		}

		public void Intersects(ref BoundingBox box, out double? result)
		{
			result = Intersects(box);
		}

		public double? Intersects(BoundingFrustum frustum)
		{
			if (frustum == null)
			{
				throw new ArgumentNullException("frustum");
			}
			return frustum.Intersects(this);
		}

		public double? Intersects(BoundingSphere sphere)
		{
			Intersects(ref sphere, out double? result);
			return result;
		}

		public double? Intersects(Plane plane)
		{
			Intersects(ref plane, out double? result);
			return result;
		}

		public void Intersects(ref Plane plane, out double? result)
		{
			double num = Vector3.Dot(Direction, plane.Normal);
			if (Math.Abs(num) < 9.9999997473787516E-06)
			{
				result = null;
				return;
			}
			result = (0.0 - plane.D - Vector3.Dot(plane.Normal, Position)) / num;
			if (result < 0.0)
			{
				if (result < -9.9999997473787516E-06)
				{
					result = null;
				}
				else
				{
					result = 0.0;
				}
			}
		}

		public void Intersects(ref BoundingSphere sphere, out double? result)
		{
			Vector3 vector = sphere.Center - Position;
			double num = vector.LengthSquared();
			double num2 = sphere.Radius * sphere.Radius;
			if (num < num2)
			{
				result = 0.0;
				return;
			}
			Vector3.Dot(ref Direction, ref vector, out double result2);
			if (result2 < 0.0)
			{
				result = null;
				return;
			}
			double num3 = num2 + result2 * result2 - num;
			result = ((num3 < 0.0) ? null : new double?(result2 - Math.Sqrt(num3)));
		}

		public static bool operator !=(Ray a, Ray b)
		{
			return !a.Equals(b);
		}

		public static bool operator ==(Ray a, Ray b)
		{
			return a.Equals(b);
		}

		public override string ToString()
		{
			return $"{{Position:{Position.ToString()} Direction:{Direction.ToString()}}}";
		}
	}
}
