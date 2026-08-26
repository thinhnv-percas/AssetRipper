using System;
using System.Collections.Generic;

namespace XnaGeometry
{
	[Serializable]
	public struct BoundingBox : IEquatable<BoundingBox>
	{
		public Vector3 Min;

		public Vector3 Max;

		public const int CornerCount = 8;

		public BoundingBox(Vector3 min, Vector3 max)
		{
			Min = min;
			Max = max;
		}

		public ContainmentType Contains(BoundingBox box)
		{
			if (box.Max.X < Min.X || box.Min.X > Max.X || box.Max.Y < Min.Y || box.Min.Y > Max.Y || box.Max.Z < Min.Z || box.Min.Z > Max.Z)
			{
				return ContainmentType.Disjoint;
			}
			if (box.Min.X >= Min.X && box.Max.X <= Max.X && box.Min.Y >= Min.Y && box.Max.Y <= Max.Y && box.Min.Z >= Min.Z && box.Max.Z <= Max.Z)
			{
				return ContainmentType.Contains;
			}
			return ContainmentType.Intersects;
		}

		public void Contains(ref BoundingBox box, out ContainmentType result)
		{
			result = Contains(box);
		}

		public ContainmentType Contains(BoundingFrustum frustum)
		{
			Vector3[] corners = frustum.GetCorners();
			ContainmentType result;
			int i;
			for (i = 0; i < corners.Length; i++)
			{
				Contains(ref corners[i], out result);
				if (result == ContainmentType.Disjoint)
				{
					break;
				}
			}
			if (i == corners.Length)
			{
				return ContainmentType.Contains;
			}
			if (i != 0)
			{
				return ContainmentType.Intersects;
			}
			for (i++; i < corners.Length; i++)
			{
				Contains(ref corners[i], out result);
				if (result != ContainmentType.Contains)
				{
					return ContainmentType.Intersects;
				}
			}
			return ContainmentType.Contains;
		}

		public ContainmentType Contains(BoundingSphere sphere)
		{
			if (sphere.Center.X - Min.X > sphere.Radius && sphere.Center.Y - Min.Y > sphere.Radius && sphere.Center.Z - Min.Z > sphere.Radius && Max.X - sphere.Center.X > sphere.Radius && Max.Y - sphere.Center.Y > sphere.Radius && Max.Z - sphere.Center.Z > sphere.Radius)
			{
				return ContainmentType.Contains;
			}
			double num = 0.0;
			if (sphere.Center.X - Min.X <= sphere.Radius)
			{
				num += (sphere.Center.X - Min.X) * (sphere.Center.X - Min.X);
			}
			else if (Max.X - sphere.Center.X <= sphere.Radius)
			{
				num += (sphere.Center.X - Max.X) * (sphere.Center.X - Max.X);
			}
			if (sphere.Center.Y - Min.Y <= sphere.Radius)
			{
				num += (sphere.Center.Y - Min.Y) * (sphere.Center.Y - Min.Y);
			}
			else if (Max.Y - sphere.Center.Y <= sphere.Radius)
			{
				num += (sphere.Center.Y - Max.Y) * (sphere.Center.Y - Max.Y);
			}
			if (sphere.Center.Z - Min.Z <= sphere.Radius)
			{
				num += (sphere.Center.Z - Min.Z) * (sphere.Center.Z - Min.Z);
			}
			else if (Max.Z - sphere.Center.Z <= sphere.Radius)
			{
				num += (sphere.Center.Z - Max.Z) * (sphere.Center.Z - Max.Z);
			}
			if (num <= sphere.Radius * sphere.Radius)
			{
				return ContainmentType.Intersects;
			}
			return ContainmentType.Disjoint;
		}

		public void Contains(ref BoundingSphere sphere, out ContainmentType result)
		{
			result = Contains(sphere);
		}

		public ContainmentType Contains(Vector3 point)
		{
			Contains(ref point, out ContainmentType result);
			return result;
		}

		public void Contains(ref Vector3 point, out ContainmentType result)
		{
			if (point.X < Min.X || point.X > Max.X || point.Y < Min.Y || point.Y > Max.Y || point.Z < Min.Z || point.Z > Max.Z)
			{
				result = ContainmentType.Disjoint;
			}
			else if (point.X == Min.X || point.X == Max.X || point.Y == Min.Y || point.Y == Max.Y || point.Z == Min.Z || point.Z == Max.Z)
			{
				result = ContainmentType.Intersects;
			}
			else
			{
				result = ContainmentType.Contains;
			}
		}

		public static BoundingBox CreateFromPoints(IEnumerable<Vector3> points)
		{
			if (points == null)
			{
				throw new ArgumentNullException();
			}
			bool flag = true;
			Vector3 vector = new Vector3(double.MaxValue);
			Vector3 vector2 = new Vector3(double.MinValue);
			foreach (Vector3 point in points)
			{
				vector = Vector3.Min(vector, point);
				vector2 = Vector3.Max(vector2, point);
				flag = false;
			}
			if (flag)
			{
				throw new ArgumentException();
			}
			return new BoundingBox(vector, vector2);
		}

		public static BoundingBox CreateFromSphere(BoundingSphere sphere)
		{
			Vector3 value = new Vector3(sphere.Radius);
			return new BoundingBox(sphere.Center - value, sphere.Center + value);
		}

		public static void CreateFromSphere(ref BoundingSphere sphere, out BoundingBox result)
		{
			result = CreateFromSphere(sphere);
		}

		public static BoundingBox CreateMerged(BoundingBox original, BoundingBox additional)
		{
			return new BoundingBox(Vector3.Min(original.Min, additional.Min), Vector3.Max(original.Max, additional.Max));
		}

		public static void CreateMerged(ref BoundingBox original, ref BoundingBox additional, out BoundingBox result)
		{
			result = CreateMerged(original, additional);
		}

		public bool Equals(BoundingBox other)
		{
			if (Min == other.Min)
			{
				return Max == other.Max;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is BoundingBox))
			{
				return false;
			}
			return Equals((BoundingBox)obj);
		}

		public Vector3[] GetCorners()
		{
			return new Vector3[8]
			{
				new Vector3(Min.X, Max.Y, Max.Z),
				new Vector3(Max.X, Max.Y, Max.Z),
				new Vector3(Max.X, Min.Y, Max.Z),
				new Vector3(Min.X, Min.Y, Max.Z),
				new Vector3(Min.X, Max.Y, Min.Z),
				new Vector3(Max.X, Max.Y, Min.Z),
				new Vector3(Max.X, Min.Y, Min.Z),
				new Vector3(Min.X, Min.Y, Min.Z)
			};
		}

		public void GetCorners(Vector3[] corners)
		{
			if (corners == null)
			{
				throw new ArgumentNullException("corners");
			}
			if (corners.Length < 8)
			{
				throw new ArgumentOutOfRangeException("corners", "Not Enought Corners");
			}
			corners[0].X = Min.X;
			corners[0].Y = Max.Y;
			corners[0].Z = Max.Z;
			corners[1].X = Max.X;
			corners[1].Y = Max.Y;
			corners[1].Z = Max.Z;
			corners[2].X = Max.X;
			corners[2].Y = Min.Y;
			corners[2].Z = Max.Z;
			corners[3].X = Min.X;
			corners[3].Y = Min.Y;
			corners[3].Z = Max.Z;
			corners[4].X = Min.X;
			corners[4].Y = Max.Y;
			corners[4].Z = Min.Z;
			corners[5].X = Max.X;
			corners[5].Y = Max.Y;
			corners[5].Z = Min.Z;
			corners[6].X = Max.X;
			corners[6].Y = Min.Y;
			corners[6].Z = Min.Z;
			corners[7].X = Min.X;
			corners[7].Y = Min.Y;
			corners[7].Z = Min.Z;
		}

		public override int GetHashCode()
		{
			return Min.GetHashCode() + Max.GetHashCode();
		}

		public bool Intersects(BoundingBox box)
		{
			Intersects(ref box, out bool result);
			return result;
		}

		public void Intersects(ref BoundingBox box, out bool result)
		{
			if (Max.X >= box.Min.X && Min.X <= box.Max.X)
			{
				if (Max.Y < box.Min.Y || Min.Y > box.Max.Y)
				{
					result = false;
				}
				else
				{
					result = (Max.Z >= box.Min.Z && Min.Z <= box.Max.Z);
				}
			}
			else
			{
				result = false;
			}
		}

		public bool Intersects(BoundingFrustum frustum)
		{
			return frustum.Intersects(this);
		}

		public bool Intersects(BoundingSphere sphere)
		{
			if (sphere.Center.X - Min.X > sphere.Radius && sphere.Center.Y - Min.Y > sphere.Radius && sphere.Center.Z - Min.Z > sphere.Radius && Max.X - sphere.Center.X > sphere.Radius && Max.Y - sphere.Center.Y > sphere.Radius && Max.Z - sphere.Center.Z > sphere.Radius)
			{
				return true;
			}
			double num = 0.0;
			if (sphere.Center.X - Min.X <= sphere.Radius)
			{
				num += (sphere.Center.X - Min.X) * (sphere.Center.X - Min.X);
			}
			else if (Max.X - sphere.Center.X <= sphere.Radius)
			{
				num += (sphere.Center.X - Max.X) * (sphere.Center.X - Max.X);
			}
			if (sphere.Center.Y - Min.Y <= sphere.Radius)
			{
				num += (sphere.Center.Y - Min.Y) * (sphere.Center.Y - Min.Y);
			}
			else if (Max.Y - sphere.Center.Y <= sphere.Radius)
			{
				num += (sphere.Center.Y - Max.Y) * (sphere.Center.Y - Max.Y);
			}
			if (sphere.Center.Z - Min.Z <= sphere.Radius)
			{
				num += (sphere.Center.Z - Min.Z) * (sphere.Center.Z - Min.Z);
			}
			else if (Max.Z - sphere.Center.Z <= sphere.Radius)
			{
				num += (sphere.Center.Z - Max.Z) * (sphere.Center.Z - Max.Z);
			}
			if (num <= sphere.Radius * sphere.Radius)
			{
				return true;
			}
			return false;
		}

		public void Intersects(ref BoundingSphere sphere, out bool result)
		{
			result = Intersects(sphere);
		}

		public PlaneIntersectionType Intersects(Plane plane)
		{
			Intersects(ref plane, out PlaneIntersectionType result);
			return result;
		}

		public void Intersects(ref Plane plane, out PlaneIntersectionType result)
		{
			Vector3 vector = default(Vector3);
			Vector3 vector2 = default(Vector3);
			if (plane.Normal.X >= 0.0)
			{
				vector.X = Max.X;
				vector2.X = Min.X;
			}
			else
			{
				vector.X = Min.X;
				vector2.X = Max.X;
			}
			if (plane.Normal.Y >= 0.0)
			{
				vector.Y = Max.Y;
				vector2.Y = Min.Y;
			}
			else
			{
				vector.Y = Min.Y;
				vector2.Y = Max.Y;
			}
			if (plane.Normal.Z >= 0.0)
			{
				vector.Z = Max.Z;
				vector2.Z = Min.Z;
			}
			else
			{
				vector.Z = Min.Z;
				vector2.Z = Max.Z;
			}
			if (Vector3.Dot(plane.Normal, vector2) + plane.D > 0.0)
			{
				result = PlaneIntersectionType.Front;
			}
			else if (Vector3.Dot(plane.Normal, vector) + plane.D < 0.0)
			{
				result = PlaneIntersectionType.Back;
			}
			else
			{
				result = PlaneIntersectionType.Intersecting;
			}
		}

		public double? Intersects(Ray ray)
		{
			return ray.Intersects(this);
		}

		public void Intersects(ref Ray ray, out double? result)
		{
			result = Intersects(ray);
		}

		public static bool operator ==(BoundingBox a, BoundingBox b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(BoundingBox a, BoundingBox b)
		{
			return !a.Equals(b);
		}

		public override string ToString()
		{
			return $"{{Min:{Min.ToString()} Max:{Max.ToString()}}}";
		}
	}
}
