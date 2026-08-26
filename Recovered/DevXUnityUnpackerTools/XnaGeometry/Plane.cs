using System;

namespace XnaGeometry
{
	public struct Plane : IEquatable<Plane>
	{
		public double D;

		public Vector3 Normal;

		public Plane(Vector4 value)
		{
			this = new Plane(new Vector3(value.X, value.Y, value.Z), value.W);
		}

		public Plane(Vector3 normal, double d)
		{
			Normal = normal;
			D = d;
		}

		public Plane(Vector3 a, Vector3 b, Vector3 c)
		{
			Vector3 vector = b - a;
			Vector3 vector2 = c - a;
			Vector3 vector3 = Vector3.Cross(vector, vector2);
			Normal = Vector3.Normalize(vector3);
			D = 0.0 - Vector3.Dot(Normal, a);
		}

		public Plane(double a, double b, double c, double d)
		{
			this = new Plane(new Vector3(a, b, c), d);
		}

		public double Dot(Vector4 value)
		{
			return Normal.X * value.X + Normal.Y * value.Y + Normal.Z * value.Z + D * value.W;
		}

		public void Dot(ref Vector4 value, out double result)
		{
			result = Normal.X * value.X + Normal.Y * value.Y + Normal.Z * value.Z + D * value.W;
		}

		public double DotCoordinate(Vector3 value)
		{
			return Normal.X * value.X + Normal.Y * value.Y + Normal.Z * value.Z + D;
		}

		public void DotCoordinate(ref Vector3 value, out double result)
		{
			result = Normal.X * value.X + Normal.Y * value.Y + Normal.Z * value.Z + D;
		}

		public double DotNormal(Vector3 value)
		{
			return Normal.X * value.X + Normal.Y * value.Y + Normal.Z * value.Z;
		}

		public void DotNormal(ref Vector3 value, out double result)
		{
			result = Normal.X * value.X + Normal.Y * value.Y + Normal.Z * value.Z;
		}

		public static void Transform(ref Plane plane, ref Quaternion rotation, out Plane result)
		{
			throw new NotImplementedException();
		}

		public static void Transform(ref Plane plane, ref Matrix matrix, out Plane result)
		{
			throw new NotImplementedException();
		}

		public static Plane Transform(Plane plane, Quaternion rotation)
		{
			throw new NotImplementedException();
		}

		public static Plane Transform(Plane plane, Matrix matrix)
		{
			throw new NotImplementedException();
		}

		public void Normalize()
		{
			Vector3 normal = Normal;
			Normal = Vector3.Normalize(Normal);
			double num = Math.Sqrt(Normal.X * Normal.X + Normal.Y * Normal.Y + Normal.Z * Normal.Z) / Math.Sqrt(normal.X * normal.X + normal.Y * normal.Y + normal.Z * normal.Z);
			D *= num;
		}

		public static Plane Normalize(Plane value)
		{
			Normalize(ref value, out Plane result);
			return result;
		}

		public static void Normalize(ref Plane value, out Plane result)
		{
			result.Normal = Vector3.Normalize(value.Normal);
			double num = Math.Sqrt(result.Normal.X * result.Normal.X + result.Normal.Y * result.Normal.Y + result.Normal.Z * result.Normal.Z) / Math.Sqrt(value.Normal.X * value.Normal.X + value.Normal.Y * value.Normal.Y + value.Normal.Z * value.Normal.Z);
			result.D = value.D * num;
		}

		public static bool operator !=(Plane plane1, Plane plane2)
		{
			return !plane1.Equals(plane2);
		}

		public static bool operator ==(Plane plane1, Plane plane2)
		{
			return plane1.Equals(plane2);
		}

		public override bool Equals(object other)
		{
			if (!(other is Plane))
			{
				return false;
			}
			return Equals((Plane)other);
		}

		public bool Equals(Plane other)
		{
			if (Normal == other.Normal)
			{
				return D == other.D;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return Normal.GetHashCode() ^ D.GetHashCode();
		}

		public PlaneIntersectionType Intersects(BoundingBox box)
		{
			return box.Intersects(this);
		}

		public void Intersects(ref BoundingBox box, out PlaneIntersectionType result)
		{
			result = Intersects(box);
		}

		public PlaneIntersectionType Intersects(BoundingFrustum frustum)
		{
			return frustum.Intersects(this);
		}

		public PlaneIntersectionType Intersects(BoundingSphere sphere)
		{
			return sphere.Intersects(this);
		}

		public void Intersects(ref BoundingSphere sphere, out PlaneIntersectionType result)
		{
			result = Intersects(sphere);
		}

		public override string ToString()
		{
			return $"{{Normal:{Normal} D:{D}}}";
		}
	}
}
