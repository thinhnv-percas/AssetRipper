using System;
using System.Collections.Generic;
using System.Globalization;

namespace XnaGeometry
{
	public struct BoundingSphere : IEquatable<BoundingSphere>
	{
		public Vector3 Center;

		public double Radius;

		public BoundingSphere(Vector3 center, double radius)
		{
			Center = center;
			Radius = radius;
		}

		public BoundingSphere Transform(Matrix matrix)
		{
			BoundingSphere result = default(BoundingSphere);
			result.Center = Vector3.Transform(Center, matrix);
			result.Radius = Radius * Math.Sqrt(Math.Max(matrix.M11 * matrix.M11 + matrix.M12 * matrix.M12 + matrix.M13 * matrix.M13, Math.Max(matrix.M21 * matrix.M21 + matrix.M22 * matrix.M22 + matrix.M23 * matrix.M23, matrix.M31 * matrix.M31 + matrix.M32 * matrix.M32 + matrix.M33 * matrix.M33)));
			return result;
		}

		public void Transform(ref Matrix matrix, out BoundingSphere result)
		{
			result.Center = Vector3.Transform(Center, matrix);
			result.Radius = Radius * Math.Sqrt(Math.Max(matrix.M11 * matrix.M11 + matrix.M12 * matrix.M12 + matrix.M13 * matrix.M13, Math.Max(matrix.M21 * matrix.M21 + matrix.M22 * matrix.M22 + matrix.M23 * matrix.M23, matrix.M31 * matrix.M31 + matrix.M32 * matrix.M32 + matrix.M33 * matrix.M33)));
		}

		public ContainmentType Contains(BoundingBox box)
		{
			bool flag = true;
			Vector3[] corners = box.GetCorners();
			foreach (Vector3 point in corners)
			{
				if (Contains(point) == ContainmentType.Disjoint)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				return ContainmentType.Contains;
			}
			double num = 0.0;
			if (Center.X < box.Min.X)
			{
				num += (Center.X - box.Min.X) * (Center.X - box.Min.X);
			}
			else if (Center.X > box.Max.X)
			{
				num += (Center.X - box.Max.X) * (Center.X - box.Max.X);
			}
			if (Center.Y < box.Min.Y)
			{
				num += (Center.Y - box.Min.Y) * (Center.Y - box.Min.Y);
			}
			else if (Center.Y > box.Max.Y)
			{
				num += (Center.Y - box.Max.Y) * (Center.Y - box.Max.Y);
			}
			if (Center.Z < box.Min.Z)
			{
				num += (Center.Z - box.Min.Z) * (Center.Z - box.Min.Z);
			}
			else if (Center.Z > box.Max.Z)
			{
				num += (Center.Z - box.Max.Z) * (Center.Z - box.Max.Z);
			}
			if (num <= Radius * Radius)
			{
				return ContainmentType.Intersects;
			}
			return ContainmentType.Disjoint;
		}

		public void Contains(ref BoundingBox box, out ContainmentType result)
		{
			result = Contains(box);
		}

		public ContainmentType Contains(BoundingFrustum frustum)
		{
			bool flag = true;
			Vector3[] corners = frustum.GetCorners();
			foreach (Vector3 point in corners)
			{
				if (Contains(point) == ContainmentType.Disjoint)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				return ContainmentType.Contains;
			}
			if (0.0 <= Radius * Radius)
			{
				return ContainmentType.Intersects;
			}
			return ContainmentType.Disjoint;
		}

		public ContainmentType Contains(BoundingSphere sphere)
		{
			double num = Vector3.Distance(sphere.Center, Center);
			if (num > sphere.Radius + Radius)
			{
				return ContainmentType.Disjoint;
			}
			if (num <= Radius - sphere.Radius)
			{
				return ContainmentType.Contains;
			}
			return ContainmentType.Intersects;
		}

		public void Contains(ref BoundingSphere sphere, out ContainmentType result)
		{
			result = Contains(sphere);
		}

		public ContainmentType Contains(Vector3 point)
		{
			double num = Vector3.Distance(point, Center);
			if (num > Radius)
			{
				return ContainmentType.Disjoint;
			}
			if (num < Radius)
			{
				return ContainmentType.Contains;
			}
			return ContainmentType.Intersects;
		}

		public void Contains(ref Vector3 point, out ContainmentType result)
		{
			result = Contains(point);
		}

		public static BoundingSphere CreateFromBoundingBox(BoundingBox box)
		{
			Vector3 vector = new Vector3((box.Min.X + box.Max.X) / 2.0, (box.Min.Y + box.Max.Y) / 2.0, (box.Min.Z + box.Max.Z) / 2.0);
			double radius = Vector3.Distance(vector, box.Max);
			return new BoundingSphere(vector, radius);
		}

		public static void CreateFromBoundingBox(ref BoundingBox box, out BoundingSphere result)
		{
			result = CreateFromBoundingBox(box);
		}

		public static BoundingSphere CreateFromFrustum(BoundingFrustum frustum)
		{
			return CreateFromPoints(frustum.GetCorners());
		}

		public static BoundingSphere CreateFromPoints(IEnumerable<Vector3> points)
		{
			if (points == null)
			{
				throw new ArgumentNullException("points");
			}
			double num = 0.0;
			Vector3 vector = default(Vector3);
			int num2 = 0;
			foreach (Vector3 point in points)
			{
				vector += point;
				num2++;
			}
			vector /= num2;
			foreach (Vector3 point2 in points)
			{
				double num3 = (point2 - vector).Length();
				if (num3 > num)
				{
					num = num3;
				}
			}
			return new BoundingSphere(vector, num);
		}

		public static BoundingSphere CreateMerged(BoundingSphere original, BoundingSphere additional)
		{
			Vector3 vector = Vector3.Subtract(additional.Center, original.Center);
			double num = vector.Length();
			if (num <= original.Radius + additional.Radius)
			{
				if (num <= original.Radius - additional.Radius)
				{
					return original;
				}
				if (num <= additional.Radius - original.Radius)
				{
					return additional;
				}
			}
			double num2 = Math.Max(original.Radius - num, additional.Radius);
			double num3 = Math.Max(original.Radius + num, additional.Radius);
			vector += (num2 - num3) / (2.0 * vector.Length()) * vector;
			BoundingSphere result = default(BoundingSphere);
			result.Center = original.Center + vector;
			result.Radius = (num2 + num3) / 2.0;
			return result;
		}

		public static void CreateMerged(ref BoundingSphere original, ref BoundingSphere additional, out BoundingSphere result)
		{
			result = CreateMerged(original, additional);
		}

		public bool Equals(BoundingSphere other)
		{
			if (Center == other.Center)
			{
				return Radius == other.Radius;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is BoundingSphere)
			{
				return Equals((BoundingSphere)obj);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return Center.GetHashCode() + Radius.GetHashCode();
		}

		public bool Intersects(BoundingBox box)
		{
			return box.Intersects(this);
		}

		public void Intersects(ref BoundingBox box, out bool result)
		{
			result = Intersects(box);
		}

		public bool Intersects(BoundingFrustum frustum)
		{
			if (frustum == null)
			{
				throw new NullReferenceException();
			}
			throw new NotImplementedException();
		}

		public bool Intersects(BoundingSphere sphere)
		{
			if (Vector3.Distance(sphere.Center, Center) > sphere.Radius + Radius)
			{
				return false;
			}
			return true;
		}

		public void Intersects(ref BoundingSphere sphere, out bool result)
		{
			result = Intersects(sphere);
		}

		public PlaneIntersectionType Intersects(Plane plane)
		{
			double num = Vector3.Dot(plane.Normal, Center) + plane.D;
			if (num > Radius)
			{
				return PlaneIntersectionType.Front;
			}
			if (num < 0.0 - Radius)
			{
				return PlaneIntersectionType.Back;
			}
			return PlaneIntersectionType.Intersecting;
		}

		public void Intersects(ref Plane plane, out PlaneIntersectionType result)
		{
			result = Intersects(plane);
		}

		public double? Intersects(Ray ray)
		{
			return ray.Intersects(this);
		}

		public void Intersects(ref Ray ray, out double? result)
		{
			result = Intersects(ray);
		}

		public static bool operator ==(BoundingSphere a, BoundingSphere b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(BoundingSphere a, BoundingSphere b)
		{
			return !a.Equals(b);
		}

		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "{{Center:{0} Radius:{1}}}", new object[2]
			{
				Center.ToString(),
				Radius.ToString()
			});
		}
	}
}
