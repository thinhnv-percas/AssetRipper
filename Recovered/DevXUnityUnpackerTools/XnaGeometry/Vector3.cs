using System;
using System.Text;

namespace XnaGeometry
{
	[Serializable]
	public struct Vector3 : IEquatable<Vector3>
	{
		internal static Vector3 zero = new Vector3(0.0, 0.0, 0.0);

		internal static Vector3 one = new Vector3(1.0, 1.0, 1.0);

		internal static Vector3 unitX = new Vector3(1.0, 0.0, 0.0);

		internal static Vector3 unitY = new Vector3(0.0, 1.0, 0.0);

		internal static Vector3 unitZ = new Vector3(0.0, 0.0, 1.0);

		internal static Vector3 up = new Vector3(0.0, 1.0, 0.0);

		internal static Vector3 down = new Vector3(0.0, -1.0, 0.0);

		internal static Vector3 right = new Vector3(1.0, 0.0, 0.0);

		internal static Vector3 left = new Vector3(-1.0, 0.0, 0.0);

		internal static Vector3 forward = new Vector3(0.0, 0.0, -1.0);

		internal static Vector3 backward = new Vector3(0.0, 0.0, 1.0);

		public double X;

		public double Y;

		public double Z;

		public static Vector3 Zero => zero;

		public static Vector3 One => one;

		public static Vector3 UnitX => unitX;

		public static Vector3 UnitY => unitY;

		public static Vector3 UnitZ => unitZ;

		public static Vector3 Up => up;

		public static Vector3 Down => down;

		public static Vector3 Right => right;

		public static Vector3 Left => left;

		public static Vector3 Forward => forward;

		public static Vector3 Backward => backward;

		public Vector3(double x, double y, double z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public Vector3(double value)
		{
			X = value;
			Y = value;
			Z = value;
		}

		public Vector3(Vector2 value, double z)
		{
			X = value.X;
			Y = value.Y;
			Z = z;
		}

		public static Vector3 Add(Vector3 value1, Vector3 value2)
		{
			value1.X += value2.X;
			value1.Y += value2.Y;
			value1.Z += value2.Z;
			return value1;
		}

		public static void Add(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
		{
			result.X = value1.X + value2.X;
			result.Y = value1.Y + value2.Y;
			result.Z = value1.Z + value2.Z;
		}

		public static Vector3 Barycentric(Vector3 value1, Vector3 value2, Vector3 value3, double amount1, double amount2)
		{
			return new Vector3(MathHelper.Barycentric(value1.X, value2.X, value3.X, amount1, amount2), MathHelper.Barycentric(value1.Y, value2.Y, value3.Y, amount1, amount2), MathHelper.Barycentric(value1.Z, value2.Z, value3.Z, amount1, amount2));
		}

		public static void Barycentric(ref Vector3 value1, ref Vector3 value2, ref Vector3 value3, double amount1, double amount2, out Vector3 result)
		{
			result = new Vector3(MathHelper.Barycentric(value1.X, value2.X, value3.X, amount1, amount2), MathHelper.Barycentric(value1.Y, value2.Y, value3.Y, amount1, amount2), MathHelper.Barycentric(value1.Z, value2.Z, value3.Z, amount1, amount2));
		}

		public static Vector3 CatmullRom(Vector3 value1, Vector3 value2, Vector3 value3, Vector3 value4, double amount)
		{
			return new Vector3(MathHelper.CatmullRom(value1.X, value2.X, value3.X, value4.X, amount), MathHelper.CatmullRom(value1.Y, value2.Y, value3.Y, value4.Y, amount), MathHelper.CatmullRom(value1.Z, value2.Z, value3.Z, value4.Z, amount));
		}

		public static void CatmullRom(ref Vector3 value1, ref Vector3 value2, ref Vector3 value3, ref Vector3 value4, double amount, out Vector3 result)
		{
			result = new Vector3(MathHelper.CatmullRom(value1.X, value2.X, value3.X, value4.X, amount), MathHelper.CatmullRom(value1.Y, value2.Y, value3.Y, value4.Y, amount), MathHelper.CatmullRom(value1.Z, value2.Z, value3.Z, value4.Z, amount));
		}

		public static Vector3 Clamp(Vector3 value1, Vector3 min, Vector3 max)
		{
			return new Vector3(MathHelper.Clamp(value1.X, min.X, max.X), MathHelper.Clamp(value1.Y, min.Y, max.Y), MathHelper.Clamp(value1.Z, min.Z, max.Z));
		}

		public static void Clamp(ref Vector3 value1, ref Vector3 min, ref Vector3 max, out Vector3 result)
		{
			result = new Vector3(MathHelper.Clamp(value1.X, min.X, max.X), MathHelper.Clamp(value1.Y, min.Y, max.Y), MathHelper.Clamp(value1.Z, min.Z, max.Z));
		}

		public static Vector3 Cross(Vector3 vector1, Vector3 vector2)
		{
			Cross(ref vector1, ref vector2, out vector1);
			return vector1;
		}

		public static void Cross(ref Vector3 vector1, ref Vector3 vector2, out Vector3 result)
		{
			result = new Vector3(vector1.Y * vector2.Z - vector2.Y * vector1.Z, 0.0 - (vector1.X * vector2.Z - vector2.X * vector1.Z), vector1.X * vector2.Y - vector2.X * vector1.Y);
		}

		public static double Distance(Vector3 vector1, Vector3 vector2)
		{
			DistanceSquared(ref vector1, ref vector2, out double result);
			return Math.Sqrt(result);
		}

		public static void Distance(ref Vector3 value1, ref Vector3 value2, out double result)
		{
			DistanceSquared(ref value1, ref value2, out result);
			result = Math.Sqrt(result);
		}

		public static double DistanceSquared(Vector3 value1, Vector3 value2)
		{
			DistanceSquared(ref value1, ref value2, out double result);
			return result;
		}

		public static void DistanceSquared(ref Vector3 value1, ref Vector3 value2, out double result)
		{
			result = (value1.X - value2.X) * (value1.X - value2.X) + (value1.Y - value2.Y) * (value1.Y - value2.Y) + (value1.Z - value2.Z) * (value1.Z - value2.Z);
		}

		public static Vector3 Divide(Vector3 value1, Vector3 value2)
		{
			value1.X /= value2.X;
			value1.Y /= value2.Y;
			value1.Z /= value2.Z;
			return value1;
		}

		public static Vector3 Divide(Vector3 value1, double value2)
		{
			double num = 1.0 / value2;
			value1.X *= num;
			value1.Y *= num;
			value1.Z *= num;
			return value1;
		}

		public static void Divide(ref Vector3 value1, double divisor, out Vector3 result)
		{
			double num = 1.0 / divisor;
			result.X = value1.X * num;
			result.Y = value1.Y * num;
			result.Z = value1.Z * num;
		}

		public static void Divide(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
		{
			result.X = value1.X / value2.X;
			result.Y = value1.Y / value2.Y;
			result.Z = value1.Z / value2.Z;
		}

		public static double Dot(Vector3 vector1, Vector3 vector2)
		{
			return vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z;
		}

		public static void Dot(ref Vector3 vector1, ref Vector3 vector2, out double result)
		{
			result = vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Vector3))
			{
				return false;
			}
			return this == (Vector3)obj;
		}

		public bool Equals(Vector3 other)
		{
			return this == other;
		}

		public override int GetHashCode()
		{
			return (int)(X + Y + Z);
		}

		public static Vector3 Hermite(Vector3 value1, Vector3 tangent1, Vector3 value2, Vector3 tangent2, double amount)
		{
			Vector3 result = default(Vector3);
			Hermite(ref value1, ref tangent1, ref value2, ref tangent2, amount, out result);
			return result;
		}

		public static void Hermite(ref Vector3 value1, ref Vector3 tangent1, ref Vector3 value2, ref Vector3 tangent2, double amount, out Vector3 result)
		{
			result.X = MathHelper.Hermite(value1.X, tangent1.X, value2.X, tangent2.X, amount);
			result.Y = MathHelper.Hermite(value1.Y, tangent1.Y, value2.Y, tangent2.Y, amount);
			result.Z = MathHelper.Hermite(value1.Z, tangent1.Z, value2.Z, tangent2.Z, amount);
		}

		public double Length()
		{
			DistanceSquared(ref this, ref zero, out double result);
			return Math.Sqrt(result);
		}

		public double LengthSquared()
		{
			DistanceSquared(ref this, ref zero, out double result);
			return result;
		}

		public static Vector3 Lerp(Vector3 value1, Vector3 value2, double amount)
		{
			return new Vector3(MathHelper.Lerp(value1.X, value2.X, amount), MathHelper.Lerp(value1.Y, value2.Y, amount), MathHelper.Lerp(value1.Z, value2.Z, amount));
		}

		public static void Lerp(ref Vector3 value1, ref Vector3 value2, double amount, out Vector3 result)
		{
			result = new Vector3(MathHelper.Lerp(value1.X, value2.X, amount), MathHelper.Lerp(value1.Y, value2.Y, amount), MathHelper.Lerp(value1.Z, value2.Z, amount));
		}

		public static Vector3 Max(Vector3 value1, Vector3 value2)
		{
			return new Vector3(MathHelper.Max(value1.X, value2.X), MathHelper.Max(value1.Y, value2.Y), MathHelper.Max(value1.Z, value2.Z));
		}

		public static void Max(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
		{
			result = new Vector3(MathHelper.Max(value1.X, value2.X), MathHelper.Max(value1.Y, value2.Y), MathHelper.Max(value1.Z, value2.Z));
		}

		public static Vector3 Min(Vector3 value1, Vector3 value2)
		{
			return new Vector3(MathHelper.Min(value1.X, value2.X), MathHelper.Min(value1.Y, value2.Y), MathHelper.Min(value1.Z, value2.Z));
		}

		public static void Min(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
		{
			result = new Vector3(MathHelper.Min(value1.X, value2.X), MathHelper.Min(value1.Y, value2.Y), MathHelper.Min(value1.Z, value2.Z));
		}

		public static Vector3 Multiply(Vector3 value1, Vector3 value2)
		{
			value1.X *= value2.X;
			value1.Y *= value2.Y;
			value1.Z *= value2.Z;
			return value1;
		}

		public static Vector3 Multiply(Vector3 value1, double scaleFactor)
		{
			value1.X *= scaleFactor;
			value1.Y *= scaleFactor;
			value1.Z *= scaleFactor;
			return value1;
		}

		public static void Multiply(ref Vector3 value1, double scaleFactor, out Vector3 result)
		{
			result.X = value1.X * scaleFactor;
			result.Y = value1.Y * scaleFactor;
			result.Z = value1.Z * scaleFactor;
		}

		public static void Multiply(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
		{
			result.X = value1.X * value2.X;
			result.Y = value1.Y * value2.Y;
			result.Z = value1.Z * value2.Z;
		}

		public static Vector3 Negate(Vector3 value)
		{
			value = new Vector3(0.0 - value.X, 0.0 - value.Y, 0.0 - value.Z);
			return value;
		}

		public static void Negate(ref Vector3 value, out Vector3 result)
		{
			result = new Vector3(0.0 - value.X, 0.0 - value.Y, 0.0 - value.Z);
		}

		public void Normalize()
		{
			Normalize(ref this, out this);
		}

		public static Vector3 Normalize(Vector3 vector)
		{
			Normalize(ref vector, out vector);
			return vector;
		}

		public static void Normalize(ref Vector3 value, out Vector3 result)
		{
			Distance(ref value, ref zero, out double result2);
			result2 = 1.0 / result2;
			result.X = value.X * result2;
			result.Y = value.Y * result2;
			result.Z = value.Z * result2;
		}

		public static Vector3 Reflect(Vector3 vector, Vector3 normal)
		{
			double num = vector.X * normal.X + vector.Y * normal.Y + vector.Z * normal.Z;
			Vector3 result = default(Vector3);
			result.X = vector.X - 2.0 * normal.X * num;
			result.Y = vector.Y - 2.0 * normal.Y * num;
			result.Z = vector.Z - 2.0 * normal.Z * num;
			return result;
		}

		public static void Reflect(ref Vector3 vector, ref Vector3 normal, out Vector3 result)
		{
			double num = vector.X * normal.X + vector.Y * normal.Y + vector.Z * normal.Z;
			result.X = vector.X - 2.0 * normal.X * num;
			result.Y = vector.Y - 2.0 * normal.Y * num;
			result.Z = vector.Z - 2.0 * normal.Z * num;
		}

		public static Vector3 SmoothStep(Vector3 value1, Vector3 value2, double amount)
		{
			return new Vector3(MathHelper.SmoothStep(value1.X, value2.X, amount), MathHelper.SmoothStep(value1.Y, value2.Y, amount), MathHelper.SmoothStep(value1.Z, value2.Z, amount));
		}

		public static void SmoothStep(ref Vector3 value1, ref Vector3 value2, double amount, out Vector3 result)
		{
			result = new Vector3(MathHelper.SmoothStep(value1.X, value2.X, amount), MathHelper.SmoothStep(value1.Y, value2.Y, amount), MathHelper.SmoothStep(value1.Z, value2.Z, amount));
		}

		public static Vector3 Subtract(Vector3 value1, Vector3 value2)
		{
			value1.X -= value2.X;
			value1.Y -= value2.Y;
			value1.Z -= value2.Z;
			return value1;
		}

		public static void Subtract(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
		{
			result.X = value1.X - value2.X;
			result.Y = value1.Y - value2.Y;
			result.Z = value1.Z - value2.Z;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(32);
			stringBuilder.Append("{X:");
			stringBuilder.Append(X);
			stringBuilder.Append(" Y:");
			stringBuilder.Append(Y);
			stringBuilder.Append(" Z:");
			stringBuilder.Append(Z);
			stringBuilder.Append("}");
			return stringBuilder.ToString();
		}

		public static Vector3 Transform(Vector3 position, Matrix matrix)
		{
			Transform(ref position, ref matrix, out position);
			return position;
		}

		public static void Transform(ref Vector3 position, ref Matrix matrix, out Vector3 result)
		{
			result = new Vector3(position.X * matrix.M11 + position.Y * matrix.M21 + position.Z * matrix.M31 + matrix.M41, position.X * matrix.M12 + position.Y * matrix.M22 + position.Z * matrix.M32 + matrix.M42, position.X * matrix.M13 + position.Y * matrix.M23 + position.Z * matrix.M33 + matrix.M43);
		}

		public static void Transform(Vector3[] sourceArray, ref Matrix matrix, Vector3[] destinationArray)
		{
			for (int i = 0; i < sourceArray.Length; i++)
			{
				Vector3 vector = sourceArray[i];
				destinationArray[i] = new Vector3(vector.X * matrix.M11 + vector.Y * matrix.M21 + vector.Z * matrix.M31 + matrix.M41, vector.X * matrix.M12 + vector.Y * matrix.M22 + vector.Z * matrix.M32 + matrix.M42, vector.X * matrix.M13 + vector.Y * matrix.M23 + vector.Z * matrix.M33 + matrix.M43);
			}
		}

		public static Vector3 Transform(Vector3 vec, Quaternion quat)
		{
			Transform(ref vec, ref quat, out Vector3 result);
			return result;
		}

		public static void Transform(ref Vector3 vec, ref Quaternion quat, out Vector3 result)
		{
			Matrix matrix = quat.ToMatrix();
			Transform(ref vec, ref matrix, out result);
		}

		public static Vector3 TransformNormal(Vector3 normal, Matrix matrix)
		{
			TransformNormal(ref normal, ref matrix, out normal);
			return normal;
		}

		public static void TransformNormal(ref Vector3 normal, ref Matrix matrix, out Vector3 result)
		{
			result = new Vector3(normal.X * matrix.M11 + normal.Y * matrix.M21 + normal.Z * matrix.M31, normal.X * matrix.M12 + normal.Y * matrix.M22 + normal.Z * matrix.M32, normal.X * matrix.M13 + normal.Y * matrix.M23 + normal.Z * matrix.M33);
		}

		public static bool operator ==(Vector3 value1, Vector3 value2)
		{
			if (value1.X == value2.X && value1.Y == value2.Y)
			{
				return value1.Z == value2.Z;
			}
			return false;
		}

		public static bool operator !=(Vector3 value1, Vector3 value2)
		{
			return !(value1 == value2);
		}

		public static Vector3 operator +(Vector3 value1, Vector3 value2)
		{
			value1.X += value2.X;
			value1.Y += value2.Y;
			value1.Z += value2.Z;
			return value1;
		}

		public static Vector3 operator -(Vector3 value)
		{
			value = new Vector3(0.0 - value.X, 0.0 - value.Y, 0.0 - value.Z);
			return value;
		}

		public static Vector3 operator -(Vector3 value1, Vector3 value2)
		{
			value1.X -= value2.X;
			value1.Y -= value2.Y;
			value1.Z -= value2.Z;
			return value1;
		}

		public static Vector3 operator *(Vector3 value1, Vector3 value2)
		{
			value1.X *= value2.X;
			value1.Y *= value2.Y;
			value1.Z *= value2.Z;
			return value1;
		}

		public static Vector3 operator *(Vector3 value, double scaleFactor)
		{
			value.X *= scaleFactor;
			value.Y *= scaleFactor;
			value.Z *= scaleFactor;
			return value;
		}

		public static Vector3 operator *(double scaleFactor, Vector3 value)
		{
			value.X *= scaleFactor;
			value.Y *= scaleFactor;
			value.Z *= scaleFactor;
			return value;
		}

		public static Vector3 operator /(Vector3 value1, Vector3 value2)
		{
			value1.X /= value2.X;
			value1.Y /= value2.Y;
			value1.Z /= value2.Z;
			return value1;
		}

		public static Vector3 operator /(Vector3 value, double divider)
		{
			double num = 1.0 / divider;
			value.X *= num;
			value.Y *= num;
			value.Z *= num;
			return value;
		}
	}
}
