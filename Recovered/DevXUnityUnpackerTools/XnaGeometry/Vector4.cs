using System;
using System.Text;

namespace XnaGeometry
{
	[Serializable]
	public struct Vector4 : IEquatable<Vector4>
	{
		internal static Vector4 zeroVector = default(Vector4);

		internal static Vector4 unitVector = new Vector4(1.0, 1.0, 1.0, 1.0);

		internal static Vector4 unitXVector = new Vector4(1.0, 0.0, 0.0, 0.0);

		internal static Vector4 unitYVector = new Vector4(0.0, 1.0, 0.0, 0.0);

		internal static Vector4 unitZVector = new Vector4(0.0, 0.0, 1.0, 0.0);

		internal static Vector4 unitWVector = new Vector4(0.0, 0.0, 0.0, 1.0);

		public double X;

		public double Y;

		public double Z;

		public double W;

		public static Vector4 Zero => zeroVector;

		public static Vector4 One => unitVector;

		public static Vector4 UnitX => unitXVector;

		public static Vector4 UnitY => unitYVector;

		public static Vector4 UnitZ => unitZVector;

		public static Vector4 UnitW => unitWVector;

		public Vector4(double x, double y, double z, double w)
		{
			X = x;
			Y = y;
			Z = z;
			W = w;
		}

		public Vector4(Vector2 value, double z, double w)
		{
			X = value.X;
			Y = value.Y;
			Z = z;
			W = w;
		}

		public Vector4(Vector3 value, double w)
		{
			X = value.X;
			Y = value.Y;
			Z = value.Z;
			W = w;
		}

		public Vector4(double value)
		{
			X = value;
			Y = value;
			Z = value;
			W = value;
		}

		public static Vector4 Add(Vector4 value1, Vector4 value2)
		{
			value1.W += value2.W;
			value1.X += value2.X;
			value1.Y += value2.Y;
			value1.Z += value2.Z;
			return value1;
		}

		public static void Add(ref Vector4 value1, ref Vector4 value2, out Vector4 result)
		{
			result.W = value1.W + value2.W;
			result.X = value1.X + value2.X;
			result.Y = value1.Y + value2.Y;
			result.Z = value1.Z + value2.Z;
		}

		public static Vector4 Barycentric(Vector4 value1, Vector4 value2, Vector4 value3, double amount1, double amount2)
		{
			return new Vector4(MathHelper.Barycentric(value1.X, value2.X, value3.X, amount1, amount2), MathHelper.Barycentric(value1.Y, value2.Y, value3.Y, amount1, amount2), MathHelper.Barycentric(value1.Z, value2.Z, value3.Z, amount1, amount2), MathHelper.Barycentric(value1.W, value2.W, value3.W, amount1, amount2));
		}

		public static void Barycentric(ref Vector4 value1, ref Vector4 value2, ref Vector4 value3, double amount1, double amount2, out Vector4 result)
		{
			result = new Vector4(MathHelper.Barycentric(value1.X, value2.X, value3.X, amount1, amount2), MathHelper.Barycentric(value1.Y, value2.Y, value3.Y, amount1, amount2), MathHelper.Barycentric(value1.Z, value2.Z, value3.Z, amount1, amount2), MathHelper.Barycentric(value1.W, value2.W, value3.W, amount1, amount2));
		}

		public static Vector4 CatmullRom(Vector4 value1, Vector4 value2, Vector4 value3, Vector4 value4, double amount)
		{
			return new Vector4(MathHelper.CatmullRom(value1.X, value2.X, value3.X, value4.X, amount), MathHelper.CatmullRom(value1.Y, value2.Y, value3.Y, value4.Y, amount), MathHelper.CatmullRom(value1.Z, value2.Z, value3.Z, value4.Z, amount), MathHelper.CatmullRom(value1.W, value2.W, value3.W, value4.W, amount));
		}

		public static void CatmullRom(ref Vector4 value1, ref Vector4 value2, ref Vector4 value3, ref Vector4 value4, double amount, out Vector4 result)
		{
			result = new Vector4(MathHelper.CatmullRom(value1.X, value2.X, value3.X, value4.X, amount), MathHelper.CatmullRom(value1.Y, value2.Y, value3.Y, value4.Y, amount), MathHelper.CatmullRom(value1.Z, value2.Z, value3.Z, value4.Z, amount), MathHelper.CatmullRom(value1.W, value2.W, value3.W, value4.W, amount));
		}

		public static Vector4 Clamp(Vector4 value1, Vector4 min, Vector4 max)
		{
			return new Vector4(MathHelper.Clamp(value1.X, min.X, max.X), MathHelper.Clamp(value1.Y, min.Y, max.Y), MathHelper.Clamp(value1.Z, min.Z, max.Z), MathHelper.Clamp(value1.W, min.W, max.W));
		}

		public static void Clamp(ref Vector4 value1, ref Vector4 min, ref Vector4 max, out Vector4 result)
		{
			result = new Vector4(MathHelper.Clamp(value1.X, min.X, max.X), MathHelper.Clamp(value1.Y, min.Y, max.Y), MathHelper.Clamp(value1.Z, min.Z, max.Z), MathHelper.Clamp(value1.W, min.W, max.W));
		}

		public static double Distance(Vector4 value1, Vector4 value2)
		{
			return Math.Sqrt(DistanceSquared(value1, value2));
		}

		public static void Distance(ref Vector4 value1, ref Vector4 value2, out double result)
		{
			result = Math.Sqrt(DistanceSquared(value1, value2));
		}

		public static double DistanceSquared(Vector4 value1, Vector4 value2)
		{
			DistanceSquared(ref value1, ref value2, out double result);
			return result;
		}

		public static void DistanceSquared(ref Vector4 value1, ref Vector4 value2, out double result)
		{
			result = (value1.W - value2.W) * (value1.W - value2.W) + (value1.X - value2.X) * (value1.X - value2.X) + (value1.Y - value2.Y) * (value1.Y - value2.Y) + (value1.Z - value2.Z) * (value1.Z - value2.Z);
		}

		public static Vector4 Divide(Vector4 value1, Vector4 value2)
		{
			value1.W /= value2.W;
			value1.X /= value2.X;
			value1.Y /= value2.Y;
			value1.Z /= value2.Z;
			return value1;
		}

		public static Vector4 Divide(Vector4 value1, double divider)
		{
			double num = 1.0 / divider;
			value1.W *= num;
			value1.X *= num;
			value1.Y *= num;
			value1.Z *= num;
			return value1;
		}

		public static void Divide(ref Vector4 value1, double divider, out Vector4 result)
		{
			double num = 1.0 / divider;
			result.W = value1.W * num;
			result.X = value1.X * num;
			result.Y = value1.Y * num;
			result.Z = value1.Z * num;
		}

		public static void Divide(ref Vector4 value1, ref Vector4 value2, out Vector4 result)
		{
			result.W = value1.W / value2.W;
			result.X = value1.X / value2.X;
			result.Y = value1.Y / value2.Y;
			result.Z = value1.Z / value2.Z;
		}

		public static double Dot(Vector4 vector1, Vector4 vector2)
		{
			return vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z + vector1.W * vector2.W;
		}

		public static void Dot(ref Vector4 vector1, ref Vector4 vector2, out double result)
		{
			result = vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z + vector1.W * vector2.W;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Vector4))
			{
				return false;
			}
			return this == (Vector4)obj;
		}

		public bool Equals(Vector4 other)
		{
			if (W == other.W && X == other.X && Y == other.Y)
			{
				return Z == other.Z;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (int)(W + X + Y + Y);
		}

		public static Vector4 Hermite(Vector4 value1, Vector4 tangent1, Vector4 value2, Vector4 tangent2, double amount)
		{
			Vector4 result = default(Vector4);
			Hermite(ref value1, ref tangent1, ref value2, ref tangent2, amount, out result);
			return result;
		}

		public static void Hermite(ref Vector4 value1, ref Vector4 tangent1, ref Vector4 value2, ref Vector4 tangent2, double amount, out Vector4 result)
		{
			result.W = MathHelper.Hermite(value1.W, tangent1.W, value2.W, tangent2.W, amount);
			result.X = MathHelper.Hermite(value1.X, tangent1.X, value2.X, tangent2.X, amount);
			result.Y = MathHelper.Hermite(value1.Y, tangent1.Y, value2.Y, tangent2.Y, amount);
			result.Z = MathHelper.Hermite(value1.Z, tangent1.Z, value2.Z, tangent2.Z, amount);
		}

		public double Length()
		{
			DistanceSquared(ref this, ref zeroVector, out double result);
			return Math.Sqrt(result);
		}

		public double LengthSquared()
		{
			DistanceSquared(ref this, ref zeroVector, out double result);
			return result;
		}

		public static Vector4 Lerp(Vector4 value1, Vector4 value2, double amount)
		{
			return new Vector4(MathHelper.Lerp(value1.X, value2.X, amount), MathHelper.Lerp(value1.Y, value2.Y, amount), MathHelper.Lerp(value1.Z, value2.Z, amount), MathHelper.Lerp(value1.W, value2.W, amount));
		}

		public static void Lerp(ref Vector4 value1, ref Vector4 value2, double amount, out Vector4 result)
		{
			result = new Vector4(MathHelper.Lerp(value1.X, value2.X, amount), MathHelper.Lerp(value1.Y, value2.Y, amount), MathHelper.Lerp(value1.Z, value2.Z, amount), MathHelper.Lerp(value1.W, value2.W, amount));
		}

		public static Vector4 Max(Vector4 value1, Vector4 value2)
		{
			return new Vector4(MathHelper.Max(value1.X, value2.X), MathHelper.Max(value1.Y, value2.Y), MathHelper.Max(value1.Z, value2.Z), MathHelper.Max(value1.W, value2.W));
		}

		public static void Max(ref Vector4 value1, ref Vector4 value2, out Vector4 result)
		{
			result = new Vector4(MathHelper.Max(value1.X, value2.X), MathHelper.Max(value1.Y, value2.Y), MathHelper.Max(value1.Z, value2.Z), MathHelper.Max(value1.W, value2.W));
		}

		public static Vector4 Min(Vector4 value1, Vector4 value2)
		{
			return new Vector4(MathHelper.Min(value1.X, value2.X), MathHelper.Min(value1.Y, value2.Y), MathHelper.Min(value1.Z, value2.Z), MathHelper.Min(value1.W, value2.W));
		}

		public static void Min(ref Vector4 value1, ref Vector4 value2, out Vector4 result)
		{
			result = new Vector4(MathHelper.Min(value1.X, value2.X), MathHelper.Min(value1.Y, value2.Y), MathHelper.Min(value1.Z, value2.Z), MathHelper.Min(value1.W, value2.W));
		}

		public static Vector4 Multiply(Vector4 value1, Vector4 value2)
		{
			value1.W *= value2.W;
			value1.X *= value2.X;
			value1.Y *= value2.Y;
			value1.Z *= value2.Z;
			return value1;
		}

		public static Vector4 Multiply(Vector4 value1, double scaleFactor)
		{
			value1.W *= scaleFactor;
			value1.X *= scaleFactor;
			value1.Y *= scaleFactor;
			value1.Z *= scaleFactor;
			return value1;
		}

		public static void Multiply(ref Vector4 value1, double scaleFactor, out Vector4 result)
		{
			result.W = value1.W * scaleFactor;
			result.X = value1.X * scaleFactor;
			result.Y = value1.Y * scaleFactor;
			result.Z = value1.Z * scaleFactor;
		}

		public static void Multiply(ref Vector4 value1, ref Vector4 value2, out Vector4 result)
		{
			result.W = value1.W * value2.W;
			result.X = value1.X * value2.X;
			result.Y = value1.Y * value2.Y;
			result.Z = value1.Z * value2.Z;
		}

		public static Vector4 Negate(Vector4 value)
		{
			value = new Vector4(0.0 - value.X, 0.0 - value.Y, 0.0 - value.Z, 0.0 - value.W);
			return value;
		}

		public static void Negate(ref Vector4 value, out Vector4 result)
		{
			result = new Vector4(0.0 - value.X, 0.0 - value.Y, 0.0 - value.Z, 0.0 - value.W);
		}

		public void Normalize()
		{
			Normalize(ref this, out this);
		}

		public static Vector4 Normalize(Vector4 vector)
		{
			Normalize(ref vector, out vector);
			return vector;
		}

		public static void Normalize(ref Vector4 vector, out Vector4 result)
		{
			DistanceSquared(ref vector, ref zeroVector, out double result2);
			result2 = 1.0 / Math.Sqrt(result2);
			result.W = vector.W * result2;
			result.X = vector.X * result2;
			result.Y = vector.Y * result2;
			result.Z = vector.Z * result2;
		}

		public static Vector4 SmoothStep(Vector4 value1, Vector4 value2, double amount)
		{
			return new Vector4(MathHelper.SmoothStep(value1.X, value2.X, amount), MathHelper.SmoothStep(value1.Y, value2.Y, amount), MathHelper.SmoothStep(value1.Z, value2.Z, amount), MathHelper.SmoothStep(value1.W, value2.W, amount));
		}

		public static void SmoothStep(ref Vector4 value1, ref Vector4 value2, double amount, out Vector4 result)
		{
			result = new Vector4(MathHelper.SmoothStep(value1.X, value2.X, amount), MathHelper.SmoothStep(value1.Y, value2.Y, amount), MathHelper.SmoothStep(value1.Z, value2.Z, amount), MathHelper.SmoothStep(value1.W, value2.W, amount));
		}

		public static Vector4 Subtract(Vector4 value1, Vector4 value2)
		{
			value1.W -= value2.W;
			value1.X -= value2.X;
			value1.Y -= value2.Y;
			value1.Z -= value2.Z;
			return value1;
		}

		public static void Subtract(ref Vector4 value1, ref Vector4 value2, out Vector4 result)
		{
			result.W = value1.W - value2.W;
			result.X = value1.X - value2.X;
			result.Y = value1.Y - value2.Y;
			result.Z = value1.Z - value2.Z;
		}

		public static Vector4 Transform(Vector2 position, Matrix matrix)
		{
			Transform(ref position, ref matrix, out Vector4 result);
			return result;
		}

		public static Vector4 Transform(Vector3 position, Matrix matrix)
		{
			Transform(ref position, ref matrix, out Vector4 result);
			return result;
		}

		public static Vector4 Transform(Vector4 vector, Matrix matrix)
		{
			Transform(ref vector, ref matrix, out vector);
			return vector;
		}

		public static void Transform(ref Vector2 position, ref Matrix matrix, out Vector4 result)
		{
			result = new Vector4(position.X * matrix.M11 + position.Y * matrix.M21 + matrix.M41, position.X * matrix.M12 + position.Y * matrix.M22 + matrix.M42, position.X * matrix.M13 + position.Y * matrix.M23 + matrix.M43, position.X * matrix.M14 + position.Y * matrix.M24 + matrix.M44);
		}

		public static void Transform(ref Vector3 position, ref Matrix matrix, out Vector4 result)
		{
			result = new Vector4(position.X * matrix.M11 + position.Y * matrix.M21 + position.Z * matrix.M31 + matrix.M41, position.X * matrix.M12 + position.Y * matrix.M22 + position.Z * matrix.M32 + matrix.M42, position.X * matrix.M13 + position.Y * matrix.M23 + position.Z * matrix.M33 + matrix.M43, position.X * matrix.M14 + position.Y * matrix.M24 + position.Z * matrix.M34 + matrix.M44);
		}

		public static void Transform(ref Vector4 vector, ref Matrix matrix, out Vector4 result)
		{
			result = new Vector4(vector.X * matrix.M11 + vector.Y * matrix.M21 + vector.Z * matrix.M31 + vector.W * matrix.M41, vector.X * matrix.M12 + vector.Y * matrix.M22 + vector.Z * matrix.M32 + vector.W * matrix.M42, vector.X * matrix.M13 + vector.Y * matrix.M23 + vector.Z * matrix.M33 + vector.W * matrix.M43, vector.X * matrix.M14 + vector.Y * matrix.M24 + vector.Z * matrix.M34 + vector.W * matrix.M44);
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
			stringBuilder.Append(" W:");
			stringBuilder.Append(W);
			stringBuilder.Append("}");
			return stringBuilder.ToString();
		}

		public static Vector4 operator -(Vector4 value)
		{
			return new Vector4(0.0 - value.X, 0.0 - value.Y, 0.0 - value.Z, 0.0 - value.W);
		}

		public static bool operator ==(Vector4 value1, Vector4 value2)
		{
			if (value1.W == value2.W && value1.X == value2.X && value1.Y == value2.Y)
			{
				return value1.Z == value2.Z;
			}
			return false;
		}

		public static bool operator !=(Vector4 value1, Vector4 value2)
		{
			return !(value1 == value2);
		}

		public static Vector4 operator +(Vector4 value1, Vector4 value2)
		{
			value1.W += value2.W;
			value1.X += value2.X;
			value1.Y += value2.Y;
			value1.Z += value2.Z;
			return value1;
		}

		public static Vector4 operator -(Vector4 value1, Vector4 value2)
		{
			value1.W -= value2.W;
			value1.X -= value2.X;
			value1.Y -= value2.Y;
			value1.Z -= value2.Z;
			return value1;
		}

		public static Vector4 operator *(Vector4 value1, Vector4 value2)
		{
			value1.W *= value2.W;
			value1.X *= value2.X;
			value1.Y *= value2.Y;
			value1.Z *= value2.Z;
			return value1;
		}

		public static Vector4 operator *(Vector4 value1, double scaleFactor)
		{
			value1.W *= scaleFactor;
			value1.X *= scaleFactor;
			value1.Y *= scaleFactor;
			value1.Z *= scaleFactor;
			return value1;
		}

		public static Vector4 operator *(double scaleFactor, Vector4 value1)
		{
			value1.W *= scaleFactor;
			value1.X *= scaleFactor;
			value1.Y *= scaleFactor;
			value1.Z *= scaleFactor;
			return value1;
		}

		public static Vector4 operator /(Vector4 value1, Vector4 value2)
		{
			value1.W /= value2.W;
			value1.X /= value2.X;
			value1.Y /= value2.Y;
			value1.Z /= value2.Z;
			return value1;
		}

		public static Vector4 operator /(Vector4 value1, double divider)
		{
			double num = 1.0 / divider;
			value1.W *= num;
			value1.X *= num;
			value1.Y *= num;
			value1.Z *= num;
			return value1;
		}
	}
}
