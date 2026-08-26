using System;
using System.Text;

namespace XnaGeometry
{
	[Serializable]
	public struct Quaternion : IEquatable<Quaternion>
	{
		public double X;

		public double Y;

		public double Z;

		public double W;

		private static Quaternion identity = new Quaternion(0.0, 0.0, 0.0, 1.0);

		public static Quaternion Identity => identity;

		internal Vector3 Xyz
		{
			get
			{
				return new Vector3(X, Y, Z);
			}
			set
			{
				X = value.X;
				Y = value.Y;
				Z = value.Z;
			}
		}

		public Quaternion(double x, double y, double z, double w)
		{
			X = x;
			Y = y;
			Z = z;
			W = w;
		}

		public Quaternion(Vector3 vectorPart, double scalarPart)
		{
			X = vectorPart.X;
			Y = vectorPart.Y;
			Z = vectorPart.Z;
			W = scalarPart;
		}

		public static Quaternion Add(Quaternion quaternion1, Quaternion quaternion2)
		{
			Quaternion result = default(Quaternion);
			result.X = quaternion1.X + quaternion2.X;
			result.Y = quaternion1.Y + quaternion2.Y;
			result.Z = quaternion1.Z + quaternion2.Z;
			result.W = quaternion1.W + quaternion2.W;
			return result;
		}

		public static void Add(ref Quaternion quaternion1, ref Quaternion quaternion2, out Quaternion result)
		{
			result.X = quaternion1.X + quaternion2.X;
			result.Y = quaternion1.Y + quaternion2.Y;
			result.Z = quaternion1.Z + quaternion2.Z;
			result.W = quaternion1.W + quaternion2.W;
		}

		public static Quaternion Concatenate(Quaternion value1, Quaternion value2)
		{
			double x = value2.X;
			double y = value2.Y;
			double z = value2.Z;
			double w = value2.W;
			double x2 = value1.X;
			double y2 = value1.Y;
			double z2 = value1.Z;
			double w2 = value1.W;
			double num = y * z2 - z * y2;
			double num2 = z * x2 - x * z2;
			double num3 = x * y2 - y * x2;
			double num4 = x * x2 + y * y2 + z * z2;
			Quaternion result = default(Quaternion);
			result.X = x * w2 + x2 * w + num;
			result.Y = y * w2 + y2 * w + num2;
			result.Z = z * w2 + z2 * w + num3;
			result.W = w * w2 - num4;
			return result;
		}

		public static void Concatenate(ref Quaternion value1, ref Quaternion value2, out Quaternion result)
		{
			double x = value2.X;
			double y = value2.Y;
			double z = value2.Z;
			double w = value2.W;
			double x2 = value1.X;
			double y2 = value1.Y;
			double z2 = value1.Z;
			double w2 = value1.W;
			double num = y * z2 - z * y2;
			double num2 = z * x2 - x * z2;
			double num3 = x * y2 - y * x2;
			double num4 = x * x2 + y * y2 + z * z2;
			result.X = x * w2 + x2 * w + num;
			result.Y = y * w2 + y2 * w + num2;
			result.Z = z * w2 + z2 * w + num3;
			result.W = w * w2 - num4;
		}

		public void Conjugate()
		{
			X = 0.0 - X;
			Y = 0.0 - Y;
			Z = 0.0 - Z;
		}

		public static Quaternion Conjugate(Quaternion value)
		{
			Quaternion result = default(Quaternion);
			result.X = 0.0 - value.X;
			result.Y = 0.0 - value.Y;
			result.Z = 0.0 - value.Z;
			result.W = value.W;
			return result;
		}

		public static void Conjugate(ref Quaternion value, out Quaternion result)
		{
			result.X = 0.0 - value.X;
			result.Y = 0.0 - value.Y;
			result.Z = 0.0 - value.Z;
			result.W = value.W;
		}

		public static Quaternion CreateFromAxisAngle(Vector3 axis, double angle)
		{
			double num = angle * 0.5;
			double num2 = Math.Sin(num);
			double w = Math.Cos(num);
			Quaternion result = default(Quaternion);
			result.X = axis.X * num2;
			result.Y = axis.Y * num2;
			result.Z = axis.Z * num2;
			result.W = w;
			return result;
		}

		public static void CreateFromAxisAngle(ref Vector3 axis, double angle, out Quaternion result)
		{
			double num = angle * 0.5;
			double num2 = Math.Sin(num);
			double w = Math.Cos(num);
			result.X = axis.X * num2;
			result.Y = axis.Y * num2;
			result.Z = axis.Z * num2;
			result.W = w;
		}

		public static Quaternion CreateFromRotationMatrix(Matrix matrix)
		{
			double num = matrix.M11 + matrix.M22 + matrix.M33;
			Quaternion result = default(Quaternion);
			if (num > 0.0)
			{
				double num2 = Math.Sqrt(num + 1.0);
				result.W = num2 * 0.5;
				num2 = 0.5 / num2;
				result.X = (matrix.M23 - matrix.M32) * num2;
				result.Y = (matrix.M31 - matrix.M13) * num2;
				result.Z = (matrix.M12 - matrix.M21) * num2;
				return result;
			}
			if (matrix.M11 >= matrix.M22 && matrix.M11 >= matrix.M33)
			{
				double num3 = Math.Sqrt(1.0 + matrix.M11 - matrix.M22 - matrix.M33);
				double num4 = 0.5 / num3;
				result.X = 0.5 * num3;
				result.Y = (matrix.M12 + matrix.M21) * num4;
				result.Z = (matrix.M13 + matrix.M31) * num4;
				result.W = (matrix.M23 - matrix.M32) * num4;
				return result;
			}
			if (matrix.M22 > matrix.M33)
			{
				double num5 = Math.Sqrt(1.0 + matrix.M22 - matrix.M11 - matrix.M33);
				double num6 = 0.5 / num5;
				result.X = (matrix.M21 + matrix.M12) * num6;
				result.Y = 0.5 * num5;
				result.Z = (matrix.M32 + matrix.M23) * num6;
				result.W = (matrix.M31 - matrix.M13) * num6;
				return result;
			}
			double num7 = Math.Sqrt(1.0 + matrix.M33 - matrix.M11 - matrix.M22);
			double num8 = 0.5 / num7;
			result.X = (matrix.M31 + matrix.M13) * num8;
			result.Y = (matrix.M32 + matrix.M23) * num8;
			result.Z = 0.5 * num7;
			result.W = (matrix.M12 - matrix.M21) * num8;
			return result;
		}

		public static void CreateFromRotationMatrix(ref Matrix matrix, out Quaternion result)
		{
			double num = matrix.M11 + matrix.M22 + matrix.M33;
			if (num > 0.0)
			{
				double num2 = Math.Sqrt(num + 1.0);
				result.W = num2 * 0.5;
				num2 = 0.5 / num2;
				result.X = (matrix.M23 - matrix.M32) * num2;
				result.Y = (matrix.M31 - matrix.M13) * num2;
				result.Z = (matrix.M12 - matrix.M21) * num2;
			}
			else if (matrix.M11 >= matrix.M22 && matrix.M11 >= matrix.M33)
			{
				double num3 = Math.Sqrt(1.0 + matrix.M11 - matrix.M22 - matrix.M33);
				double num4 = 0.5 / num3;
				result.X = 0.5 * num3;
				result.Y = (matrix.M12 + matrix.M21) * num4;
				result.Z = (matrix.M13 + matrix.M31) * num4;
				result.W = (matrix.M23 - matrix.M32) * num4;
			}
			else if (matrix.M22 > matrix.M33)
			{
				double num5 = Math.Sqrt(1.0 + matrix.M22 - matrix.M11 - matrix.M33);
				double num6 = 0.5 / num5;
				result.X = (matrix.M21 + matrix.M12) * num6;
				result.Y = 0.5 * num5;
				result.Z = (matrix.M32 + matrix.M23) * num6;
				result.W = (matrix.M31 - matrix.M13) * num6;
			}
			else
			{
				double num7 = Math.Sqrt(1.0 + matrix.M33 - matrix.M11 - matrix.M22);
				double num8 = 0.5 / num7;
				result.X = (matrix.M31 + matrix.M13) * num8;
				result.Y = (matrix.M32 + matrix.M23) * num8;
				result.Z = 0.5 * num7;
				result.W = (matrix.M12 - matrix.M21) * num8;
			}
		}

		public static Quaternion CreateFromYawPitchRoll(double yaw, double pitch, double roll)
		{
			double num = roll * 0.5;
			double num2 = Math.Sin(num);
			double num3 = Math.Cos(num);
			double num4 = pitch * 0.5;
			double num5 = Math.Sin(num4);
			double num6 = Math.Cos(num4);
			double num7 = yaw * 0.5;
			double num8 = Math.Sin(num7);
			double num9 = Math.Cos(num7);
			Quaternion result = default(Quaternion);
			result.X = num9 * num5 * num3 + num8 * num6 * num2;
			result.Y = num8 * num6 * num3 - num9 * num5 * num2;
			result.Z = num9 * num6 * num2 - num8 * num5 * num3;
			result.W = num9 * num6 * num3 + num8 * num5 * num2;
			return result;
		}

		public static void CreateFromYawPitchRoll(double yaw, double pitch, double roll, out Quaternion result)
		{
			double num = roll * 0.5;
			double num2 = Math.Sin(num);
			double num3 = Math.Cos(num);
			double num4 = pitch * 0.5;
			double num5 = Math.Sin(num4);
			double num6 = Math.Cos(num4);
			double num7 = yaw * 0.5;
			double num8 = Math.Sin(num7);
			double num9 = Math.Cos(num7);
			result.X = num9 * num5 * num3 + num8 * num6 * num2;
			result.Y = num8 * num6 * num3 - num9 * num5 * num2;
			result.Z = num9 * num6 * num2 - num8 * num5 * num3;
			result.W = num9 * num6 * num3 + num8 * num5 * num2;
		}

		public static Quaternion Divide(Quaternion quaternion1, Quaternion quaternion2)
		{
			double x = quaternion1.X;
			double y = quaternion1.Y;
			double z = quaternion1.Z;
			double w = quaternion1.W;
			double num = quaternion2.X * quaternion2.X + quaternion2.Y * quaternion2.Y + quaternion2.Z * quaternion2.Z + quaternion2.W * quaternion2.W;
			double num2 = 1.0 / num;
			double num3 = (0.0 - quaternion2.X) * num2;
			double num4 = (0.0 - quaternion2.Y) * num2;
			double num5 = (0.0 - quaternion2.Z) * num2;
			double num6 = quaternion2.W * num2;
			double num7 = y * num5 - z * num4;
			double num8 = z * num3 - x * num5;
			double num9 = x * num4 - y * num3;
			double num10 = x * num3 + y * num4 + z * num5;
			Quaternion result = default(Quaternion);
			result.X = x * num6 + num3 * w + num7;
			result.Y = y * num6 + num4 * w + num8;
			result.Z = z * num6 + num5 * w + num9;
			result.W = w * num6 - num10;
			return result;
		}

		public static void Divide(ref Quaternion quaternion1, ref Quaternion quaternion2, out Quaternion result)
		{
			double x = quaternion1.X;
			double y = quaternion1.Y;
			double z = quaternion1.Z;
			double w = quaternion1.W;
			double num = quaternion2.X * quaternion2.X + quaternion2.Y * quaternion2.Y + quaternion2.Z * quaternion2.Z + quaternion2.W * quaternion2.W;
			double num2 = 1.0 / num;
			double num3 = (0.0 - quaternion2.X) * num2;
			double num4 = (0.0 - quaternion2.Y) * num2;
			double num5 = (0.0 - quaternion2.Z) * num2;
			double num6 = quaternion2.W * num2;
			double num7 = y * num5 - z * num4;
			double num8 = z * num3 - x * num5;
			double num9 = x * num4 - y * num3;
			double num10 = x * num3 + y * num4 + z * num5;
			result.X = x * num6 + num3 * w + num7;
			result.Y = y * num6 + num4 * w + num8;
			result.Z = z * num6 + num5 * w + num9;
			result.W = w * num6 - num10;
		}

		public static double Dot(Quaternion quaternion1, Quaternion quaternion2)
		{
			return quaternion1.X * quaternion2.X + quaternion1.Y * quaternion2.Y + quaternion1.Z * quaternion2.Z + quaternion1.W * quaternion2.W;
		}

		public static void Dot(ref Quaternion quaternion1, ref Quaternion quaternion2, out double result)
		{
			result = quaternion1.X * quaternion2.X + quaternion1.Y * quaternion2.Y + quaternion1.Z * quaternion2.Z + quaternion1.W * quaternion2.W;
		}

		public override bool Equals(object obj)
		{
			bool result = false;
			if (obj is Quaternion)
			{
				result = Equals((Quaternion)obj);
			}
			return result;
		}

		public bool Equals(Quaternion other)
		{
			if (X == other.X && Y == other.Y && Z == other.Z)
			{
				return W == other.W;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return X.GetHashCode() + Y.GetHashCode() + Z.GetHashCode() + W.GetHashCode();
		}

		public static Quaternion Inverse(Quaternion quaternion)
		{
			double num = quaternion.X * quaternion.X + quaternion.Y * quaternion.Y + quaternion.Z * quaternion.Z + quaternion.W * quaternion.W;
			double num2 = 1.0 / num;
			Quaternion result = default(Quaternion);
			result.X = (0.0 - quaternion.X) * num2;
			result.Y = (0.0 - quaternion.Y) * num2;
			result.Z = (0.0 - quaternion.Z) * num2;
			result.W = quaternion.W * num2;
			return result;
		}

		public static void Inverse(ref Quaternion quaternion, out Quaternion result)
		{
			double num = quaternion.X * quaternion.X + quaternion.Y * quaternion.Y + quaternion.Z * quaternion.Z + quaternion.W * quaternion.W;
			double num2 = 1.0 / num;
			result.X = (0.0 - quaternion.X) * num2;
			result.Y = (0.0 - quaternion.Y) * num2;
			result.Z = (0.0 - quaternion.Z) * num2;
			result.W = quaternion.W * num2;
		}

		public double Length()
		{
			return Math.Sqrt(X * X + Y * Y + Z * Z + W * W);
		}

		public double LengthSquared()
		{
			return X * X + Y * Y + Z * Z + W * W;
		}

		public static Quaternion Lerp(Quaternion quaternion1, Quaternion quaternion2, double amount)
		{
			double num = 1.0 - amount;
			Quaternion quaternion3 = default(Quaternion);
			if (quaternion1.X * quaternion2.X + quaternion1.Y * quaternion2.Y + quaternion1.Z * quaternion2.Z + quaternion1.W * quaternion2.W >= 0.0)
			{
				quaternion3.X = num * quaternion1.X + amount * quaternion2.X;
				quaternion3.Y = num * quaternion1.Y + amount * quaternion2.Y;
				quaternion3.Z = num * quaternion1.Z + amount * quaternion2.Z;
				quaternion3.W = num * quaternion1.W + amount * quaternion2.W;
			}
			else
			{
				quaternion3.X = num * quaternion1.X - amount * quaternion2.X;
				quaternion3.Y = num * quaternion1.Y - amount * quaternion2.Y;
				quaternion3.Z = num * quaternion1.Z - amount * quaternion2.Z;
				quaternion3.W = num * quaternion1.W - amount * quaternion2.W;
			}
			double num2 = quaternion3.X * quaternion3.X + quaternion3.Y * quaternion3.Y + quaternion3.Z * quaternion3.Z + quaternion3.W * quaternion3.W;
			double num3 = 1.0 / Math.Sqrt(num2);
			quaternion3.X *= num3;
			quaternion3.Y *= num3;
			quaternion3.Z *= num3;
			quaternion3.W *= num3;
			return quaternion3;
		}

		public static void Lerp(ref Quaternion quaternion1, ref Quaternion quaternion2, double amount, out Quaternion result)
		{
			double num = 1.0 - amount;
			if (quaternion1.X * quaternion2.X + quaternion1.Y * quaternion2.Y + quaternion1.Z * quaternion2.Z + quaternion1.W * quaternion2.W >= 0.0)
			{
				result.X = num * quaternion1.X + amount * quaternion2.X;
				result.Y = num * quaternion1.Y + amount * quaternion2.Y;
				result.Z = num * quaternion1.Z + amount * quaternion2.Z;
				result.W = num * quaternion1.W + amount * quaternion2.W;
			}
			else
			{
				result.X = num * quaternion1.X - amount * quaternion2.X;
				result.Y = num * quaternion1.Y - amount * quaternion2.Y;
				result.Z = num * quaternion1.Z - amount * quaternion2.Z;
				result.W = num * quaternion1.W - amount * quaternion2.W;
			}
			double num2 = result.X * result.X + result.Y * result.Y + result.Z * result.Z + result.W * result.W;
			double num3 = 1.0 / Math.Sqrt(num2);
			result.X *= num3;
			result.Y *= num3;
			result.Z *= num3;
			result.W *= num3;
		}

		public static Quaternion Slerp(Quaternion quaternion1, Quaternion quaternion2, double amount)
		{
			double num = quaternion1.X * quaternion2.X + quaternion1.Y * quaternion2.Y + quaternion1.Z * quaternion2.Z + quaternion1.W * quaternion2.W;
			bool flag = false;
			if (num < 0.0)
			{
				flag = true;
				num = 0.0 - num;
			}
			double num2;
			double num3;
			if (num > 0.99999898672103882)
			{
				num2 = 1.0 - amount;
				num3 = (flag ? (0.0 - amount) : amount);
			}
			else
			{
				double num4 = Math.Acos(num);
				double num5 = 1.0 / Math.Sin(num4);
				num2 = Math.Sin((1.0 - amount) * num4) * num5;
				num3 = (flag ? ((0.0 - Math.Sin(amount * num4)) * num5) : (Math.Sin(amount * num4) * num5));
			}
			Quaternion result = default(Quaternion);
			result.X = num2 * quaternion1.X + num3 * quaternion2.X;
			result.Y = num2 * quaternion1.Y + num3 * quaternion2.Y;
			result.Z = num2 * quaternion1.Z + num3 * quaternion2.Z;
			result.W = num2 * quaternion1.W + num3 * quaternion2.W;
			return result;
		}

		public static void Slerp(ref Quaternion quaternion1, ref Quaternion quaternion2, double amount, out Quaternion result)
		{
			double num = quaternion1.X * quaternion2.X + quaternion1.Y * quaternion2.Y + quaternion1.Z * quaternion2.Z + quaternion1.W * quaternion2.W;
			bool flag = false;
			if (num < 0.0)
			{
				flag = true;
				num = 0.0 - num;
			}
			double num2;
			double num3;
			if (num > 0.99999898672103882)
			{
				num2 = 1.0 - amount;
				num3 = (flag ? (0.0 - amount) : amount);
			}
			else
			{
				double num4 = Math.Acos(num);
				double num5 = 1.0 / Math.Sin(num4);
				num2 = Math.Sin((1.0 - amount) * num4) * num5;
				num3 = (flag ? ((0.0 - Math.Sin(amount * num4)) * num5) : (Math.Sin(amount * num4) * num5));
			}
			result.X = num2 * quaternion1.X + num3 * quaternion2.X;
			result.Y = num2 * quaternion1.Y + num3 * quaternion2.Y;
			result.Z = num2 * quaternion1.Z + num3 * quaternion2.Z;
			result.W = num2 * quaternion1.W + num3 * quaternion2.W;
		}

		public static Quaternion Subtract(Quaternion quaternion1, Quaternion quaternion2)
		{
			Quaternion result = default(Quaternion);
			result.X = quaternion1.X - quaternion2.X;
			result.Y = quaternion1.Y - quaternion2.Y;
			result.Z = quaternion1.Z - quaternion2.Z;
			result.W = quaternion1.W - quaternion2.W;
			return result;
		}

		public static void Subtract(ref Quaternion quaternion1, ref Quaternion quaternion2, out Quaternion result)
		{
			result.X = quaternion1.X - quaternion2.X;
			result.Y = quaternion1.Y - quaternion2.Y;
			result.Z = quaternion1.Z - quaternion2.Z;
			result.W = quaternion1.W - quaternion2.W;
		}

		public static Quaternion Multiply(Quaternion quaternion1, Quaternion quaternion2)
		{
			double x = quaternion1.X;
			double y = quaternion1.Y;
			double z = quaternion1.Z;
			double w = quaternion1.W;
			double x2 = quaternion2.X;
			double y2 = quaternion2.Y;
			double z2 = quaternion2.Z;
			double w2 = quaternion2.W;
			double num = y * z2 - z * y2;
			double num2 = z * x2 - x * z2;
			double num3 = x * y2 - y * x2;
			double num4 = x * x2 + y * y2 + z * z2;
			Quaternion result = default(Quaternion);
			result.X = x * w2 + x2 * w + num;
			result.Y = y * w2 + y2 * w + num2;
			result.Z = z * w2 + z2 * w + num3;
			result.W = w * w2 - num4;
			return result;
		}

		public static Quaternion Multiply(Quaternion quaternion1, double scaleFactor)
		{
			Quaternion result = default(Quaternion);
			result.X = quaternion1.X * scaleFactor;
			result.Y = quaternion1.Y * scaleFactor;
			result.Z = quaternion1.Z * scaleFactor;
			result.W = quaternion1.W * scaleFactor;
			return result;
		}

		public static void Multiply(ref Quaternion quaternion1, double scaleFactor, out Quaternion result)
		{
			result.X = quaternion1.X * scaleFactor;
			result.Y = quaternion1.Y * scaleFactor;
			result.Z = quaternion1.Z * scaleFactor;
			result.W = quaternion1.W * scaleFactor;
		}

		public static void Multiply(ref Quaternion quaternion1, ref Quaternion quaternion2, out Quaternion result)
		{
			double x = quaternion1.X;
			double y = quaternion1.Y;
			double z = quaternion1.Z;
			double w = quaternion1.W;
			double x2 = quaternion2.X;
			double y2 = quaternion2.Y;
			double z2 = quaternion2.Z;
			double w2 = quaternion2.W;
			double num = y * z2 - z * y2;
			double num2 = z * x2 - x * z2;
			double num3 = x * y2 - y * x2;
			double num4 = x * x2 + y * y2 + z * z2;
			result.X = x * w2 + x2 * w + num;
			result.Y = y * w2 + y2 * w + num2;
			result.Z = z * w2 + z2 * w + num3;
			result.W = w * w2 - num4;
		}

		public static Quaternion Negate(Quaternion quaternion)
		{
			Quaternion result = default(Quaternion);
			result.X = 0.0 - quaternion.X;
			result.Y = 0.0 - quaternion.Y;
			result.Z = 0.0 - quaternion.Z;
			result.W = 0.0 - quaternion.W;
			return result;
		}

		public static void Negate(ref Quaternion quaternion, out Quaternion result)
		{
			result.X = 0.0 - quaternion.X;
			result.Y = 0.0 - quaternion.Y;
			result.Z = 0.0 - quaternion.Z;
			result.W = 0.0 - quaternion.W;
		}

		public void Normalize()
		{
			double num = X * X + Y * Y + Z * Z + W * W;
			double num2 = 1.0 / Math.Sqrt(num);
			X *= num2;
			Y *= num2;
			Z *= num2;
			W *= num2;
		}

		public static Quaternion Normalize(Quaternion quaternion)
		{
			double num = quaternion.X * quaternion.X + quaternion.Y * quaternion.Y + quaternion.Z * quaternion.Z + quaternion.W * quaternion.W;
			double num2 = 1.0 / Math.Sqrt(num);
			Quaternion result = default(Quaternion);
			result.X = quaternion.X * num2;
			result.Y = quaternion.Y * num2;
			result.Z = quaternion.Z * num2;
			result.W = quaternion.W * num2;
			return result;
		}

		public static void Normalize(ref Quaternion quaternion, out Quaternion result)
		{
			double num = quaternion.X * quaternion.X + quaternion.Y * quaternion.Y + quaternion.Z * quaternion.Z + quaternion.W * quaternion.W;
			double num2 = 1.0 / Math.Sqrt(num);
			result.X = quaternion.X * num2;
			result.Y = quaternion.Y * num2;
			result.Z = quaternion.Z * num2;
			result.W = quaternion.W * num2;
		}

		public static Quaternion operator +(Quaternion quaternion1, Quaternion quaternion2)
		{
			Quaternion result = default(Quaternion);
			result.X = quaternion1.X + quaternion2.X;
			result.Y = quaternion1.Y + quaternion2.Y;
			result.Z = quaternion1.Z + quaternion2.Z;
			result.W = quaternion1.W + quaternion2.W;
			return result;
		}

		public static Quaternion operator /(Quaternion quaternion1, Quaternion quaternion2)
		{
			double x = quaternion1.X;
			double y = quaternion1.Y;
			double z = quaternion1.Z;
			double w = quaternion1.W;
			double num = quaternion2.X * quaternion2.X + quaternion2.Y * quaternion2.Y + quaternion2.Z * quaternion2.Z + quaternion2.W * quaternion2.W;
			double num2 = 1.0 / num;
			double num3 = (0.0 - quaternion2.X) * num2;
			double num4 = (0.0 - quaternion2.Y) * num2;
			double num5 = (0.0 - quaternion2.Z) * num2;
			double num6 = quaternion2.W * num2;
			double num7 = y * num5 - z * num4;
			double num8 = z * num3 - x * num5;
			double num9 = x * num4 - y * num3;
			double num10 = x * num3 + y * num4 + z * num5;
			Quaternion result = default(Quaternion);
			result.X = x * num6 + num3 * w + num7;
			result.Y = y * num6 + num4 * w + num8;
			result.Z = z * num6 + num5 * w + num9;
			result.W = w * num6 - num10;
			return result;
		}

		public static bool operator ==(Quaternion quaternion1, Quaternion quaternion2)
		{
			if (quaternion1.X == quaternion2.X && quaternion1.Y == quaternion2.Y && quaternion1.Z == quaternion2.Z)
			{
				return quaternion1.W == quaternion2.W;
			}
			return false;
		}

		public static bool operator !=(Quaternion quaternion1, Quaternion quaternion2)
		{
			if (quaternion1.X == quaternion2.X && quaternion1.Y == quaternion2.Y && quaternion1.Z == quaternion2.Z)
			{
				return quaternion1.W != quaternion2.W;
			}
			return true;
		}

		public static Quaternion operator *(Quaternion quaternion1, Quaternion quaternion2)
		{
			double x = quaternion1.X;
			double y = quaternion1.Y;
			double z = quaternion1.Z;
			double w = quaternion1.W;
			double x2 = quaternion2.X;
			double y2 = quaternion2.Y;
			double z2 = quaternion2.Z;
			double w2 = quaternion2.W;
			double num = y * z2 - z * y2;
			double num2 = z * x2 - x * z2;
			double num3 = x * y2 - y * x2;
			double num4 = x * x2 + y * y2 + z * z2;
			Quaternion result = default(Quaternion);
			result.X = x * w2 + x2 * w + num;
			result.Y = y * w2 + y2 * w + num2;
			result.Z = z * w2 + z2 * w + num3;
			result.W = w * w2 - num4;
			return result;
		}

		public static Quaternion operator *(Quaternion quaternion1, double scaleFactor)
		{
			Quaternion result = default(Quaternion);
			result.X = quaternion1.X * scaleFactor;
			result.Y = quaternion1.Y * scaleFactor;
			result.Z = quaternion1.Z * scaleFactor;
			result.W = quaternion1.W * scaleFactor;
			return result;
		}

		public static Quaternion operator -(Quaternion quaternion1, Quaternion quaternion2)
		{
			Quaternion result = default(Quaternion);
			result.X = quaternion1.X - quaternion2.X;
			result.Y = quaternion1.Y - quaternion2.Y;
			result.Z = quaternion1.Z - quaternion2.Z;
			result.W = quaternion1.W - quaternion2.W;
			return result;
		}

		public static Quaternion operator -(Quaternion quaternion)
		{
			Quaternion result = default(Quaternion);
			result.X = 0.0 - quaternion.X;
			result.Y = 0.0 - quaternion.Y;
			result.Z = 0.0 - quaternion.Z;
			result.W = 0.0 - quaternion.W;
			return result;
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

		internal Matrix ToMatrix()
		{
			Matrix matrix = Matrix.Identity;
			ToMatrix(out matrix);
			return matrix;
		}

		internal void ToMatrix(out Matrix matrix)
		{
			ToMatrix(this, out matrix);
		}

		internal static void ToMatrix(Quaternion quaternion, out Matrix matrix)
		{
			double num = quaternion.X * quaternion.X;
			double num2 = quaternion.Y * quaternion.Y;
			double num3 = quaternion.Z * quaternion.Z;
			double num4 = quaternion.X * quaternion.Y;
			double num5 = quaternion.X * quaternion.Z;
			double num6 = quaternion.Y * quaternion.Z;
			double num7 = quaternion.W * quaternion.X;
			double num8 = quaternion.W * quaternion.Y;
			double num9 = quaternion.W * quaternion.Z;
			matrix.M11 = 1.0 - 2.0 * (num2 + num3);
			matrix.M12 = 2.0 * (num4 - num9);
			matrix.M13 = 2.0 * (num5 + num8);
			matrix.M14 = 0.0;
			matrix.M21 = 2.0 * (num4 + num9);
			matrix.M22 = 1.0 - 2.0 * (num + num3);
			matrix.M23 = 2.0 * (num6 - num7);
			matrix.M24 = 0.0;
			matrix.M31 = 2.0 * (num5 - num8);
			matrix.M32 = 2.0 * (num6 + num7);
			matrix.M33 = 1.0 - 2.0 * (num + num2);
			matrix.M34 = 0.0;
			matrix.M41 = 2.0 * (num5 - num8);
			matrix.M42 = 2.0 * (num6 + num7);
			matrix.M43 = 1.0 - 2.0 * (num + num2);
			matrix.M44 = 0.0;
		}

		internal Vector3 calculateEuler()
		{
			Vector3 result = default(Vector3);
			double w = W;
			double x = X;
			double y = Y;
			double z = Z;
			double num = x * x;
			double num2 = y * y;
			double num3 = z * z;
			double num4 = x * y + z * w;
			if (num4 > 0.499)
			{
				result.Y = 360.0 / Math.PI * Math.Atan2(x, w);
				result.Z = 90.0;
				result.X = 0.0;
				return result;
			}
			if (num4 < -0.499)
			{
				result.Y = -360.0 / Math.PI * Math.Atan2(x, w);
				result.Z = -90.0;
				result.X = 0.0;
				return result;
			}
			double num5 = Math.Atan2(2.0 * y * w - 2.0 * x * z, 1.0 - 2.0 * num2 - 2.0 * num3);
			double num6 = Math.Asin(2.0 * x * y + 2.0 * z * w);
			double num7 = Math.Atan2(2.0 * x * w - 2.0 * y * z, 1.0 - 2.0 * num - 2.0 * num3);
			result.Y = num5 * 180.0 / Math.PI;
			result.Z = num6 * 180.0 / Math.PI;
			result.X = num7 * 180.0 / Math.PI;
			return result;
		}

		private double copysign(double _X, double _Y)
		{
			if (_Y < 0.0)
			{
				return 0.0 - Math.Abs(_X);
			}
			return Math.Abs(_X);
		}
	}
}
