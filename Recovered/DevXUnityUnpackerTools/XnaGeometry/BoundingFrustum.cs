using System;
using System.Text;

namespace XnaGeometry
{
	public class BoundingFrustum : IEquatable<BoundingFrustum>
	{
		private Matrix _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020;

		private Plane _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A;

		private Plane _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020;

		private Plane _0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020;

		private Plane _0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A;

		private Plane _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A;

		private Plane _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020;

		private Vector3[] _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A;

		public const int CornerCount = 8;

		public Plane Bottom => _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A;

		public Plane Far => _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020;

		public Plane Left => _0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020;

		public Matrix Matrix
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020;
			}
			set
			{
				_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020 = value;
				_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020();
				_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A();
			}
		}

		public Plane Near => _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A;

		public Plane Right => _0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A;

		public Plane Top => _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020;

		public BoundingFrustum(Matrix value)
		{
			_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020 = value;
			_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020();
			_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A();
		}

		public static bool operator ==(BoundingFrustum a, BoundingFrustum b)
		{
			if (object.Equals(a, null))
			{
				return object.Equals(b, null);
			}
			if (object.Equals(b, null))
			{
				return object.Equals(a, null);
			}
			return a._0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020 == b._0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020;
		}

		public static bool operator !=(BoundingFrustum a, BoundingFrustum b)
		{
			return !(a == b);
		}

		public ContainmentType Contains(BoundingBox box)
		{
			Contains(ref box, out ContainmentType result);
			return result;
		}

		public void Contains(ref BoundingBox box, out ContainmentType result)
		{
			bool flag = false;
			box.Intersects(ref _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A, out PlaneIntersectionType result2);
			switch (result2)
			{
			case PlaneIntersectionType.Front:
				result = ContainmentType.Disjoint;
				return;
			case PlaneIntersectionType.Intersecting:
				flag = true;
				break;
			}
			box.Intersects(ref _0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020, out result2);
			switch (result2)
			{
			case PlaneIntersectionType.Front:
				result = ContainmentType.Disjoint;
				return;
			case PlaneIntersectionType.Intersecting:
				flag = true;
				break;
			}
			box.Intersects(ref _0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A, out result2);
			switch (result2)
			{
			case PlaneIntersectionType.Front:
				result = ContainmentType.Disjoint;
				return;
			case PlaneIntersectionType.Intersecting:
				flag = true;
				break;
			}
			box.Intersects(ref _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020, out result2);
			switch (result2)
			{
			case PlaneIntersectionType.Front:
				result = ContainmentType.Disjoint;
				return;
			case PlaneIntersectionType.Intersecting:
				flag = true;
				break;
			}
			box.Intersects(ref _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A, out result2);
			switch (result2)
			{
			case PlaneIntersectionType.Front:
				result = ContainmentType.Disjoint;
				return;
			case PlaneIntersectionType.Intersecting:
				flag = true;
				break;
			}
			box.Intersects(ref _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020, out result2);
			switch (result2)
			{
			case PlaneIntersectionType.Front:
				result = ContainmentType.Disjoint;
				return;
			case PlaneIntersectionType.Intersecting:
				flag = true;
				break;
			}
			result = ((!flag) ? ContainmentType.Contains : ContainmentType.Intersects);
		}

		public ContainmentType Contains(BoundingFrustum frustum)
		{
			if (this == frustum)
			{
				return ContainmentType.Contains;
			}
			throw new NotImplementedException();
		}

		public ContainmentType Contains(BoundingSphere sphere)
		{
			Contains(ref sphere, out ContainmentType result);
			return result;
		}

		public void Contains(ref BoundingSphere sphere, out ContainmentType result)
		{
			result = ContainmentType.Contains;
			Vector3.Dot(ref _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A.Normal, ref sphere.Center, out double result2);
			result2 += _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A.D;
			if (result2 > sphere.Radius)
			{
				result = ContainmentType.Disjoint;
				return;
			}
			if (Math.Abs(result2) < sphere.Radius)
			{
				result = ContainmentType.Intersects;
			}
			Vector3.Dot(ref _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020.Normal, ref sphere.Center, out result2);
			result2 += _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020.D;
			if (result2 > sphere.Radius)
			{
				result = ContainmentType.Disjoint;
				return;
			}
			if (Math.Abs(result2) < sphere.Radius)
			{
				result = ContainmentType.Intersects;
			}
			Vector3.Dot(ref _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A.Normal, ref sphere.Center, out result2);
			result2 += _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A.D;
			if (result2 > sphere.Radius)
			{
				result = ContainmentType.Disjoint;
				return;
			}
			if (Math.Abs(result2) < sphere.Radius)
			{
				result = ContainmentType.Intersects;
			}
			Vector3.Dot(ref _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020.Normal, ref sphere.Center, out result2);
			result2 += _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020.D;
			if (result2 > sphere.Radius)
			{
				result = ContainmentType.Disjoint;
				return;
			}
			if (Math.Abs(result2) < sphere.Radius)
			{
				result = ContainmentType.Intersects;
			}
			Vector3.Dot(ref _0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020.Normal, ref sphere.Center, out result2);
			result2 += _0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020.D;
			if (result2 > sphere.Radius)
			{
				result = ContainmentType.Disjoint;
				return;
			}
			if (Math.Abs(result2) < sphere.Radius)
			{
				result = ContainmentType.Intersects;
			}
			Vector3.Dot(ref _0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A.Normal, ref sphere.Center, out result2);
			result2 += _0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A.D;
			if (result2 > sphere.Radius)
			{
				result = ContainmentType.Disjoint;
			}
			else if (Math.Abs(result2) < sphere.Radius)
			{
				result = ContainmentType.Intersects;
			}
		}

		public ContainmentType Contains(Vector3 point)
		{
			Contains(ref point, out ContainmentType result);
			return result;
		}

		public void Contains(ref Vector3 point, out ContainmentType result)
		{
			if (_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020.ClassifyPoint(ref point, ref _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020) > 0.0)
			{
				result = ContainmentType.Disjoint;
			}
			else if (_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020.ClassifyPoint(ref point, ref _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A) > 0.0)
			{
				result = ContainmentType.Disjoint;
			}
			else if (_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020.ClassifyPoint(ref point, ref _0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020) > 0.0)
			{
				result = ContainmentType.Disjoint;
			}
			else if (_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020.ClassifyPoint(ref point, ref _0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A) > 0.0)
			{
				result = ContainmentType.Disjoint;
			}
			else if (_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020.ClassifyPoint(ref point, ref _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A) > 0.0)
			{
				result = ContainmentType.Disjoint;
			}
			else if (_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020.ClassifyPoint(ref point, ref _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020) > 0.0)
			{
				result = ContainmentType.Disjoint;
			}
			else
			{
				result = ContainmentType.Contains;
			}
		}

		public bool Equals(BoundingFrustum other)
		{
			return this == other;
		}

		public override bool Equals(object obj)
		{
			BoundingFrustum boundingFrustum = obj as BoundingFrustum;
			if (!object.Equals(boundingFrustum, null))
			{
				return this == boundingFrustum;
			}
			return false;
		}

		public Vector3[] GetCorners()
		{
			return (Vector3[])_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A.Clone();
		}

		public void GetCorners(Vector3[] corners)
		{
			if (corners == null)
			{
				throw new ArgumentNullException("corners");
			}
			if (corners.Length < 8)
			{
				throw new ArgumentOutOfRangeException("corners");
			}
			_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A.CopyTo(corners, 0);
		}

		public override int GetHashCode()
		{
			return _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.GetHashCode();
		}

		public bool Intersects(BoundingBox box)
		{
			bool result = false;
			Intersects(ref box, out result);
			return result;
		}

		public void Intersects(ref BoundingBox box, out bool result)
		{
			ContainmentType result2 = ContainmentType.Disjoint;
			Contains(ref box, out result2);
			result = (result2 != ContainmentType.Disjoint);
		}

		public bool Intersects(BoundingFrustum frustum)
		{
			throw new NotImplementedException();
		}

		public bool Intersects(BoundingSphere sphere)
		{
			throw new NotImplementedException();
		}

		public void Intersects(ref BoundingSphere sphere, out bool result)
		{
			throw new NotImplementedException();
		}

		public PlaneIntersectionType Intersects(Plane plane)
		{
			throw new NotImplementedException();
		}

		public void Intersects(ref Plane plane, out PlaneIntersectionType result)
		{
			throw new NotImplementedException();
		}

		public double? Intersects(Ray ray)
		{
			throw new NotImplementedException();
		}

		public void Intersects(ref Ray ray, out double? result)
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(256);
			stringBuilder.Append("{Near:");
			stringBuilder.Append(_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A.ToString());
			stringBuilder.Append(" Far:");
			stringBuilder.Append(_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020.ToString());
			stringBuilder.Append(" Left:");
			stringBuilder.Append(_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020.ToString());
			stringBuilder.Append(" Right:");
			stringBuilder.Append(_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A.ToString());
			stringBuilder.Append(" Top:");
			stringBuilder.Append(_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020.ToString());
			stringBuilder.Append(" Bottom:");
			stringBuilder.Append(_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A.ToString());
			stringBuilder.Append("}");
			return stringBuilder.ToString();
		}

		private void _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A()
		{
			_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A = new Vector3[8];
			_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A[0] = _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A(ref _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A, ref _0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020, ref _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020);
			_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A[1] = _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A(ref _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A, ref _0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A, ref _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020);
			_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A[2] = _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A(ref _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A, ref _0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A, ref _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A);
			_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A[3] = _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A(ref _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A, ref _0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020, ref _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A);
			_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A[4] = _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A(ref _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020, ref _0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020, ref _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020);
			_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A[5] = _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A(ref _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020, ref _0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A, ref _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020);
			_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A[6] = _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A(ref _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020, ref _0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A, ref _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A);
			_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A[7] = _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A(ref _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020, ref _0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020, ref _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A);
		}

		private void _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020()
		{
			_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020 = new Plane(0.0 - _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M14 - _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M11, 0.0 - _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M24 - _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M21, 0.0 - _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M34 - _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M31, 0.0 - _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M44 - _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M41);
			_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A = new Plane(_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M11 - _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M14, _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M21 - _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M24, _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M31 - _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M34, _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M41 - _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M44);
			_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020 = new Plane(_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M12 - _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M14, _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M22 - _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M24, _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M32 - _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M34, _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M42 - _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M44);
			_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A = new Plane(0.0 - _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M14 - _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M12, 0.0 - _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M24 - _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M22, 0.0 - _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M34 - _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M32, 0.0 - _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M44 - _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M42);
			_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A = new Plane(0.0 - _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M13, 0.0 - _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M23, 0.0 - _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M33, 0.0 - _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M43);
			_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020 = new Plane(_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M13 - _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M14, _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M23 - _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M24, _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M33 - _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M34, _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M43 - _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020.M44);
			_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020(ref _0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020);
			_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020(ref _0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A);
			_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020(ref _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020);
			_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020(ref _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A);
			_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020(ref _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A);
			_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020(ref _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020);
		}

		private static Vector3 _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A(ref Plane _0020, ref Plane _0020_000A, ref Plane _0020_0020)
		{
			double divider = 0.0 - Vector3.Dot(_0020.Normal, Vector3.Cross(_0020_000A.Normal, _0020_0020.Normal));
			Vector3 vector = _0020.D * Vector3.Cross(_0020_000A.Normal, _0020_0020.Normal);
			Vector3 vector2 = _0020_000A.D * Vector3.Cross(_0020_0020.Normal, _0020.Normal);
			Vector3 vector3 = _0020_0020.D * Vector3.Cross(_0020.Normal, _0020_000A.Normal);
			return new Vector3(vector.X + vector2.X + vector3.X, vector.Y + vector2.Y + vector3.Y, vector.Z + vector2.Z + vector3.Z) / divider;
		}

		private void _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020(ref Plane _0020)
		{
			double num = 1.0 / _0020.Normal.Length();
			_0020.Normal.X *= num;
			_0020.Normal.Y *= num;
			_0020.Normal.Z *= num;
			_0020.D *= num;
		}
	}
}
