using System;

namespace XnaGeometry
{
	public struct Matrix : IEquatable<Matrix>
	{
		public double M11;

		public double M12;

		public double M13;

		public double M14;

		public double M21;

		public double M22;

		public double M23;

		public double M24;

		public double M31;

		public double M32;

		public double M33;

		public double M34;

		public double M41;

		public double M42;

		public double M43;

		public double M44;

		internal static Matrix _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020 = new Matrix(1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0);

		public Vector3 Backward
		{
			get
			{
				return new Vector3(M31, M32, M33);
			}
			set
			{
				M31 = value.X;
				M32 = value.Y;
				M33 = value.Z;
			}
		}

		public Vector3 Down
		{
			get
			{
				return new Vector3(0.0 - M21, 0.0 - M22, 0.0 - M23);
			}
			set
			{
				M21 = 0.0 - value.X;
				M22 = 0.0 - value.Y;
				M23 = 0.0 - value.Z;
			}
		}

		public Vector3 Forward
		{
			get
			{
				return new Vector3(0.0 - M31, 0.0 - M32, 0.0 - M33);
			}
			set
			{
				M31 = 0.0 - value.X;
				M32 = 0.0 - value.Y;
				M33 = 0.0 - value.Z;
			}
		}

		public static Matrix Identity => _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020;

		public Vector3 Left
		{
			get
			{
				return new Vector3(0.0 - M11, 0.0 - M12, 0.0 - M13);
			}
			set
			{
				M11 = 0.0 - value.X;
				M12 = 0.0 - value.Y;
				M13 = 0.0 - value.Z;
			}
		}

		public Vector3 Right
		{
			get
			{
				return new Vector3(M11, M12, M13);
			}
			set
			{
				M11 = value.X;
				M12 = value.Y;
				M13 = value.Z;
			}
		}

		public Vector3 Translation
		{
			get
			{
				return new Vector3(M41, M42, M43);
			}
			set
			{
				M41 = value.X;
				M42 = value.Y;
				M43 = value.Z;
			}
		}

		public Vector3 Up
		{
			get
			{
				return new Vector3(M21, M22, M23);
			}
			set
			{
				M21 = value.X;
				M22 = value.Y;
				M23 = value.Z;
			}
		}

		public Matrix(double m11, double m12, double m13, double m14, double m21, double m22, double m23, double m24, double m31, double m32, double m33, double m34, double m41, double m42, double m43, double m44)
		{
			M11 = m11;
			M12 = m12;
			M13 = m13;
			M14 = m14;
			M21 = m21;
			M22 = m22;
			M23 = m23;
			M24 = m24;
			M31 = m31;
			M32 = m32;
			M33 = m33;
			M34 = m34;
			M41 = m41;
			M42 = m42;
			M43 = m43;
			M44 = m44;
		}

		public static double[] ToFloatArray(Matrix mat)
		{
			return new double[16]
			{
				mat.M11,
				mat.M12,
				mat.M13,
				mat.M14,
				mat.M21,
				mat.M22,
				mat.M23,
				mat.M24,
				mat.M31,
				mat.M32,
				mat.M33,
				mat.M34,
				mat.M41,
				mat.M42,
				mat.M43,
				mat.M44
			};
		}

		public static Matrix Add(Matrix matrix1, Matrix matrix2)
		{
			matrix1.M11 += matrix2.M11;
			matrix1.M12 += matrix2.M12;
			matrix1.M13 += matrix2.M13;
			matrix1.M14 += matrix2.M14;
			matrix1.M21 += matrix2.M21;
			matrix1.M22 += matrix2.M22;
			matrix1.M23 += matrix2.M23;
			matrix1.M24 += matrix2.M24;
			matrix1.M31 += matrix2.M31;
			matrix1.M32 += matrix2.M32;
			matrix1.M33 += matrix2.M33;
			matrix1.M34 += matrix2.M34;
			matrix1.M41 += matrix2.M41;
			matrix1.M42 += matrix2.M42;
			matrix1.M43 += matrix2.M43;
			matrix1.M44 += matrix2.M44;
			return matrix1;
		}

		public static void Add(ref Matrix matrix1, ref Matrix matrix2, out Matrix result)
		{
			result.M11 = matrix1.M11 + matrix2.M11;
			result.M12 = matrix1.M12 + matrix2.M12;
			result.M13 = matrix1.M13 + matrix2.M13;
			result.M14 = matrix1.M14 + matrix2.M14;
			result.M21 = matrix1.M21 + matrix2.M21;
			result.M22 = matrix1.M22 + matrix2.M22;
			result.M23 = matrix1.M23 + matrix2.M23;
			result.M24 = matrix1.M24 + matrix2.M24;
			result.M31 = matrix1.M31 + matrix2.M31;
			result.M32 = matrix1.M32 + matrix2.M32;
			result.M33 = matrix1.M33 + matrix2.M33;
			result.M34 = matrix1.M34 + matrix2.M34;
			result.M41 = matrix1.M41 + matrix2.M41;
			result.M42 = matrix1.M42 + matrix2.M42;
			result.M43 = matrix1.M43 + matrix2.M43;
			result.M44 = matrix1.M44 + matrix2.M44;
		}

		public static Matrix CreateBillboard(Vector3 objectPosition, Vector3 cameraPosition, Vector3 cameraUpVector, Vector3? cameraForwardVector)
		{
			Vector3 vector = cameraPosition - objectPosition;
			Matrix identity = Identity;
			vector.Normalize();
			identity.Forward = vector;
			identity.Left = Vector3.Cross(vector, cameraUpVector);
			identity.Up = cameraUpVector;
			identity.Translation = objectPosition;
			return identity;
		}

		public static void CreateBillboard(ref Vector3 objectPosition, ref Vector3 cameraPosition, ref Vector3 cameraUpVector, Vector3? cameraForwardVector, out Matrix result)
		{
			Vector3 vector = default(Vector3);
			vector.X = objectPosition.X - cameraPosition.X;
			vector.Y = objectPosition.Y - cameraPosition.Y;
			vector.Z = objectPosition.Z - cameraPosition.Z;
			double num = vector.LengthSquared();
			if (num < 9.9999997473787516E-05)
			{
				vector = (cameraForwardVector.HasValue ? (-cameraForwardVector.Value) : Vector3.Forward);
			}
			else
			{
				Vector3.Multiply(ref vector, 1.0 / Math.Sqrt(num), out vector);
			}
			Vector3.Cross(ref cameraUpVector, ref vector, out Vector3 result2);
			result2.Normalize();
			Vector3.Cross(ref vector, ref result2, out Vector3 result3);
			result.M11 = result2.X;
			result.M12 = result2.Y;
			result.M13 = result2.Z;
			result.M14 = 0.0;
			result.M21 = result3.X;
			result.M22 = result3.Y;
			result.M23 = result3.Z;
			result.M24 = 0.0;
			result.M31 = vector.X;
			result.M32 = vector.Y;
			result.M33 = vector.Z;
			result.M34 = 0.0;
			result.M41 = objectPosition.X;
			result.M42 = objectPosition.Y;
			result.M43 = objectPosition.Z;
			result.M44 = 1.0;
		}

		public static Matrix CreateConstrainedBillboard(Vector3 objectPosition, Vector3 cameraPosition, Vector3 rotateAxis, Vector3? cameraForwardVector, Vector3? objectForwardVector)
		{
			Vector3 vector = default(Vector3);
			vector.X = objectPosition.X - cameraPosition.X;
			vector.Y = objectPosition.Y - cameraPosition.Y;
			vector.Z = objectPosition.Z - cameraPosition.Z;
			double num = vector.LengthSquared();
			if (num < 9.9999997473787516E-05)
			{
				vector = (cameraForwardVector.HasValue ? (-cameraForwardVector.Value) : Vector3.Forward);
			}
			else
			{
				Vector3.Multiply(ref vector, 1.0 / Math.Sqrt(num), out vector);
			}
			Vector3 vector2 = rotateAxis;
			Vector3.Dot(ref rotateAxis, ref vector, out double result);
			Vector3 vector3;
			Vector3 result2;
			if (Math.Abs(result) > 0.99825471639633179)
			{
				if (objectForwardVector.HasValue)
				{
					vector3 = objectForwardVector.Value;
					Vector3.Dot(ref rotateAxis, ref vector3, out result);
					if (Math.Abs(result) > 0.99825471639633179)
					{
						result = rotateAxis.X * Vector3.Forward.X + rotateAxis.Y * Vector3.Forward.Y + rotateAxis.Z * Vector3.Forward.Z;
						vector3 = ((Math.Abs(result) > 0.99825471639633179) ? Vector3.Right : Vector3.Forward);
					}
				}
				else
				{
					result = rotateAxis.X * Vector3.Forward.X + rotateAxis.Y * Vector3.Forward.Y + rotateAxis.Z * Vector3.Forward.Z;
					vector3 = ((Math.Abs(result) > 0.99825471639633179) ? Vector3.Right : Vector3.Forward);
				}
				Vector3.Cross(ref rotateAxis, ref vector3, out result2);
				result2.Normalize();
				Vector3.Cross(ref result2, ref rotateAxis, out vector3);
				vector3.Normalize();
			}
			else
			{
				Vector3.Cross(ref rotateAxis, ref vector, out result2);
				result2.Normalize();
				Vector3.Cross(ref result2, ref vector2, out vector3);
				vector3.Normalize();
			}
			Matrix result3 = default(Matrix);
			result3.M11 = result2.X;
			result3.M12 = result2.Y;
			result3.M13 = result2.Z;
			result3.M14 = 0.0;
			result3.M21 = vector2.X;
			result3.M22 = vector2.Y;
			result3.M23 = vector2.Z;
			result3.M24 = 0.0;
			result3.M31 = vector3.X;
			result3.M32 = vector3.Y;
			result3.M33 = vector3.Z;
			result3.M34 = 0.0;
			result3.M41 = objectPosition.X;
			result3.M42 = objectPosition.Y;
			result3.M43 = objectPosition.Z;
			result3.M44 = 1.0;
			return result3;
		}

		public static void CreateConstrainedBillboard(ref Vector3 objectPosition, ref Vector3 cameraPosition, ref Vector3 rotateAxis, Vector3? cameraForwardVector, Vector3? objectForwardVector, out Matrix result)
		{
			Vector3 vector = default(Vector3);
			vector.X = objectPosition.X - cameraPosition.X;
			vector.Y = objectPosition.Y - cameraPosition.Y;
			vector.Z = objectPosition.Z - cameraPosition.Z;
			double num = vector.LengthSquared();
			if (num < 9.9999997473787516E-05)
			{
				vector = (cameraForwardVector.HasValue ? (-cameraForwardVector.Value) : Vector3.Forward);
			}
			else
			{
				Vector3.Multiply(ref vector, 1.0 / Math.Sqrt(num), out vector);
			}
			Vector3 vector2 = rotateAxis;
			Vector3.Dot(ref rotateAxis, ref vector, out double result2);
			Vector3 vector3;
			Vector3 result3;
			if (Math.Abs(result2) > 0.99825471639633179)
			{
				if (objectForwardVector.HasValue)
				{
					vector3 = objectForwardVector.Value;
					Vector3.Dot(ref rotateAxis, ref vector3, out result2);
					if (Math.Abs(result2) > 0.99825471639633179)
					{
						result2 = rotateAxis.X * Vector3.Forward.X + rotateAxis.Y * Vector3.Forward.Y + rotateAxis.Z * Vector3.Forward.Z;
						vector3 = ((Math.Abs(result2) > 0.99825471639633179) ? Vector3.Right : Vector3.Forward);
					}
				}
				else
				{
					result2 = rotateAxis.X * Vector3.Forward.X + rotateAxis.Y * Vector3.Forward.Y + rotateAxis.Z * Vector3.Forward.Z;
					vector3 = ((Math.Abs(result2) > 0.99825471639633179) ? Vector3.Right : Vector3.Forward);
				}
				Vector3.Cross(ref rotateAxis, ref vector3, out result3);
				result3.Normalize();
				Vector3.Cross(ref result3, ref rotateAxis, out vector3);
				vector3.Normalize();
			}
			else
			{
				Vector3.Cross(ref rotateAxis, ref vector, out result3);
				result3.Normalize();
				Vector3.Cross(ref result3, ref vector2, out vector3);
				vector3.Normalize();
			}
			result.M11 = result3.X;
			result.M12 = result3.Y;
			result.M13 = result3.Z;
			result.M14 = 0.0;
			result.M21 = vector2.X;
			result.M22 = vector2.Y;
			result.M23 = vector2.Z;
			result.M24 = 0.0;
			result.M31 = vector3.X;
			result.M32 = vector3.Y;
			result.M33 = vector3.Z;
			result.M34 = 0.0;
			result.M41 = objectPosition.X;
			result.M42 = objectPosition.Y;
			result.M43 = objectPosition.Z;
			result.M44 = 1.0;
		}

		public static Matrix CreateFromAxisAngle(Vector3 axis, double angle)
		{
			double x = axis.X;
			double y = axis.Y;
			double z = axis.Z;
			double num = Math.Sin(angle);
			double num2 = Math.Cos(angle);
			double num3 = x * x;
			double num4 = y * y;
			double num5 = z * z;
			double num6 = x * y;
			double num7 = x * z;
			double num8 = y * z;
			Matrix result = default(Matrix);
			result.M11 = num3 + num2 * (1.0 - num3);
			result.M12 = num6 - num2 * num6 + num * z;
			result.M13 = num7 - num2 * num7 - num * y;
			result.M14 = 0.0;
			result.M21 = num6 - num2 * num6 - num * z;
			result.M22 = num4 + num2 * (1.0 - num4);
			result.M23 = num8 - num2 * num8 + num * x;
			result.M24 = 0.0;
			result.M31 = num7 - num2 * num7 + num * y;
			result.M32 = num8 - num2 * num8 - num * x;
			result.M33 = num5 + num2 * (1.0 - num5);
			result.M34 = 0.0;
			result.M41 = 0.0;
			result.M42 = 0.0;
			result.M43 = 0.0;
			result.M44 = 1.0;
			return result;
		}

		public static void CreateFromAxisAngle(ref Vector3 axis, double angle, out Matrix result)
		{
			double x = axis.X;
			double y = axis.Y;
			double z = axis.Z;
			double num = Math.Sin(angle);
			double num2 = Math.Cos(angle);
			double num3 = x * x;
			double num4 = y * y;
			double num5 = z * z;
			double num6 = x * y;
			double num7 = x * z;
			double num8 = y * z;
			result.M11 = num3 + num2 * (1.0 - num3);
			result.M12 = num6 - num2 * num6 + num * z;
			result.M13 = num7 - num2 * num7 - num * y;
			result.M14 = 0.0;
			result.M21 = num6 - num2 * num6 - num * z;
			result.M22 = num4 + num2 * (1.0 - num4);
			result.M23 = num8 - num2 * num8 + num * x;
			result.M24 = 0.0;
			result.M31 = num7 - num2 * num7 + num * y;
			result.M32 = num8 - num2 * num8 - num * x;
			result.M33 = num5 + num2 * (1.0 - num5);
			result.M34 = 0.0;
			result.M41 = 0.0;
			result.M42 = 0.0;
			result.M43 = 0.0;
			result.M44 = 1.0;
		}

		public static Matrix CreateFromQuaternion(Quaternion quaternion)
		{
			double num = quaternion.X * quaternion.X;
			double num2 = quaternion.Y * quaternion.Y;
			double num3 = quaternion.Z * quaternion.Z;
			double num4 = quaternion.X * quaternion.Y;
			double num5 = quaternion.Z * quaternion.W;
			double num6 = quaternion.Z * quaternion.X;
			double num7 = quaternion.Y * quaternion.W;
			double num8 = quaternion.Y * quaternion.Z;
			double num9 = quaternion.X * quaternion.W;
			Matrix result = default(Matrix);
			result.M11 = 1.0 - 2.0 * (num2 + num3);
			result.M12 = 2.0 * (num4 + num5);
			result.M13 = 2.0 * (num6 - num7);
			result.M14 = 0.0;
			result.M21 = 2.0 * (num4 - num5);
			result.M22 = 1.0 - 2.0 * (num3 + num);
			result.M23 = 2.0 * (num8 + num9);
			result.M24 = 0.0;
			result.M31 = 2.0 * (num6 + num7);
			result.M32 = 2.0 * (num8 - num9);
			result.M33 = 1.0 - 2.0 * (num2 + num);
			result.M34 = 0.0;
			result.M41 = 0.0;
			result.M42 = 0.0;
			result.M43 = 0.0;
			result.M44 = 1.0;
			return result;
		}

		public static void CreateFromQuaternion(ref Quaternion quaternion, out Matrix result)
		{
			double num = quaternion.X * quaternion.X;
			double num2 = quaternion.Y * quaternion.Y;
			double num3 = quaternion.Z * quaternion.Z;
			double num4 = quaternion.X * quaternion.Y;
			double num5 = quaternion.Z * quaternion.W;
			double num6 = quaternion.Z * quaternion.X;
			double num7 = quaternion.Y * quaternion.W;
			double num8 = quaternion.Y * quaternion.Z;
			double num9 = quaternion.X * quaternion.W;
			result.M11 = 1.0 - 2.0 * (num2 + num3);
			result.M12 = 2.0 * (num4 + num5);
			result.M13 = 2.0 * (num6 - num7);
			result.M14 = 0.0;
			result.M21 = 2.0 * (num4 - num5);
			result.M22 = 1.0 - 2.0 * (num3 + num);
			result.M23 = 2.0 * (num8 + num9);
			result.M24 = 0.0;
			result.M31 = 2.0 * (num6 + num7);
			result.M32 = 2.0 * (num8 - num9);
			result.M33 = 1.0 - 2.0 * (num2 + num);
			result.M34 = 0.0;
			result.M41 = 0.0;
			result.M42 = 0.0;
			result.M43 = 0.0;
			result.M44 = 1.0;
		}

		public static Matrix CreateFromYawPitchRoll(double yaw, double pitch, double roll)
		{
			Quaternion.CreateFromYawPitchRoll(yaw, pitch, roll, out Quaternion result);
			CreateFromQuaternion(ref result, out Matrix result2);
			return result2;
		}

		public static void CreateFromYawPitchRoll(double yaw, double pitch, double roll, out Matrix result)
		{
			Quaternion.CreateFromYawPitchRoll(yaw, pitch, roll, out Quaternion result2);
			CreateFromQuaternion(ref result2, out result);
		}

		public static Matrix CreateLookAt(Vector3 cameraPosition, Vector3 cameraTarget, Vector3 cameraUpVector)
		{
			Vector3 vector = Vector3.Normalize(cameraPosition - cameraTarget);
			Vector3 vector2 = Vector3.Normalize(Vector3.Cross(cameraUpVector, vector));
			Vector3 vector3 = Vector3.Cross(vector, vector2);
			Matrix result = default(Matrix);
			result.M11 = vector2.X;
			result.M12 = vector3.X;
			result.M13 = vector.X;
			result.M14 = 0.0;
			result.M21 = vector2.Y;
			result.M22 = vector3.Y;
			result.M23 = vector.Y;
			result.M24 = 0.0;
			result.M31 = vector2.Z;
			result.M32 = vector3.Z;
			result.M33 = vector.Z;
			result.M34 = 0.0;
			result.M41 = 0.0 - Vector3.Dot(vector2, cameraPosition);
			result.M42 = 0.0 - Vector3.Dot(vector3, cameraPosition);
			result.M43 = 0.0 - Vector3.Dot(vector, cameraPosition);
			result.M44 = 1.0;
			return result;
		}

		public static void CreateLookAt(ref Vector3 cameraPosition, ref Vector3 cameraTarget, ref Vector3 cameraUpVector, out Matrix result)
		{
			Vector3 vector = Vector3.Normalize(cameraPosition - cameraTarget);
			Vector3 vector2 = Vector3.Normalize(Vector3.Cross(cameraUpVector, vector));
			Vector3 vector3 = Vector3.Cross(vector, vector2);
			result.M11 = vector2.X;
			result.M12 = vector3.X;
			result.M13 = vector.X;
			result.M14 = 0.0;
			result.M21 = vector2.Y;
			result.M22 = vector3.Y;
			result.M23 = vector.Y;
			result.M24 = 0.0;
			result.M31 = vector2.Z;
			result.M32 = vector3.Z;
			result.M33 = vector.Z;
			result.M34 = 0.0;
			result.M41 = 0.0 - Vector3.Dot(vector2, cameraPosition);
			result.M42 = 0.0 - Vector3.Dot(vector3, cameraPosition);
			result.M43 = 0.0 - Vector3.Dot(vector, cameraPosition);
			result.M44 = 1.0;
		}

		public static Matrix CreateOrthographic(double width, double height, double zNearPlane, double zFarPlane)
		{
			Matrix result = default(Matrix);
			result.M11 = 2.0 / width;
			result.M12 = (result.M13 = (result.M14 = 0.0));
			result.M22 = 2.0 / height;
			result.M21 = (result.M23 = (result.M24 = 0.0));
			result.M33 = 1.0 / (zNearPlane - zFarPlane);
			result.M31 = (result.M32 = (result.M34 = 0.0));
			result.M41 = (result.M42 = 0.0);
			result.M43 = zNearPlane / (zNearPlane - zFarPlane);
			result.M44 = 1.0;
			return result;
		}

		public static void CreateOrthographic(double width, double height, double zNearPlane, double zFarPlane, out Matrix result)
		{
			result.M11 = 2.0 / width;
			result.M12 = (result.M13 = (result.M14 = 0.0));
			result.M22 = 2.0 / height;
			result.M21 = (result.M23 = (result.M24 = 0.0));
			result.M33 = 1.0 / (zNearPlane - zFarPlane);
			result.M31 = (result.M32 = (result.M34 = 0.0));
			result.M41 = (result.M42 = 0.0);
			result.M43 = zNearPlane / (zNearPlane - zFarPlane);
			result.M44 = 1.0;
		}

		public static Matrix CreateOrthographicOffCenter(double left, double right, double bottom, double top, double zNearPlane, double zFarPlane)
		{
			Matrix result = default(Matrix);
			result.M11 = 2.0 / (right - left);
			result.M12 = 0.0;
			result.M13 = 0.0;
			result.M14 = 0.0;
			result.M21 = 0.0;
			result.M22 = 2.0 / (top - bottom);
			result.M23 = 0.0;
			result.M24 = 0.0;
			result.M31 = 0.0;
			result.M32 = 0.0;
			result.M33 = 1.0 / (zNearPlane - zFarPlane);
			result.M34 = 0.0;
			result.M41 = (left + right) / (left - right);
			result.M42 = (top + bottom) / (bottom - top);
			result.M43 = zNearPlane / (zNearPlane - zFarPlane);
			result.M44 = 1.0;
			return result;
		}

		public static void CreateOrthographicOffCenter(double left, double right, double bottom, double top, double zNearPlane, double zFarPlane, out Matrix result)
		{
			result.M11 = 2.0 / (right - left);
			result.M12 = 0.0;
			result.M13 = 0.0;
			result.M14 = 0.0;
			result.M21 = 0.0;
			result.M22 = 2.0 / (top - bottom);
			result.M23 = 0.0;
			result.M24 = 0.0;
			result.M31 = 0.0;
			result.M32 = 0.0;
			result.M33 = 1.0 / (zNearPlane - zFarPlane);
			result.M34 = 0.0;
			result.M41 = (left + right) / (left - right);
			result.M42 = (top + bottom) / (bottom - top);
			result.M43 = zNearPlane / (zNearPlane - zFarPlane);
			result.M44 = 1.0;
		}

		public static Matrix CreatePerspective(double width, double height, double nearPlaneDistance, double farPlaneDistance)
		{
			if (nearPlaneDistance <= 0.0)
			{
				throw new ArgumentException("nearPlaneDistance <= 0");
			}
			if (farPlaneDistance <= 0.0)
			{
				throw new ArgumentException("farPlaneDistance <= 0");
			}
			if (nearPlaneDistance >= farPlaneDistance)
			{
				throw new ArgumentException("nearPlaneDistance >= farPlaneDistance");
			}
			Matrix result = default(Matrix);
			result.M11 = 2.0 * nearPlaneDistance / width;
			result.M12 = (result.M13 = (result.M14 = 0.0));
			result.M22 = 2.0 * nearPlaneDistance / height;
			result.M21 = (result.M23 = (result.M24 = 0.0));
			result.M33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
			result.M31 = (result.M32 = 0.0);
			result.M34 = -1.0;
			result.M41 = (result.M42 = (result.M44 = 0.0));
			result.M43 = nearPlaneDistance * farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
			return result;
		}

		public static void CreatePerspective(double width, double height, double nearPlaneDistance, double farPlaneDistance, out Matrix result)
		{
			if (nearPlaneDistance <= 0.0)
			{
				throw new ArgumentException("nearPlaneDistance <= 0");
			}
			if (farPlaneDistance <= 0.0)
			{
				throw new ArgumentException("farPlaneDistance <= 0");
			}
			if (nearPlaneDistance >= farPlaneDistance)
			{
				throw new ArgumentException("nearPlaneDistance >= farPlaneDistance");
			}
			result.M11 = 2.0 * nearPlaneDistance / width;
			result.M12 = (result.M13 = (result.M14 = 0.0));
			result.M22 = 2.0 * nearPlaneDistance / height;
			result.M21 = (result.M23 = (result.M24 = 0.0));
			result.M33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
			result.M31 = (result.M32 = 0.0);
			result.M34 = -1.0;
			result.M41 = (result.M42 = (result.M44 = 0.0));
			result.M43 = nearPlaneDistance * farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
		}

		public static Matrix CreatePerspectiveFieldOfView(double fieldOfView, double aspectRatio, double nearPlaneDistance, double farPlaneDistance)
		{
			if (fieldOfView <= 0.0 || fieldOfView >= 3.1415929794311523)
			{
				throw new ArgumentException("fieldOfView <= 0 O >= PI");
			}
			if (nearPlaneDistance <= 0.0)
			{
				throw new ArgumentException("nearPlaneDistance <= 0");
			}
			if (farPlaneDistance <= 0.0)
			{
				throw new ArgumentException("farPlaneDistance <= 0");
			}
			if (nearPlaneDistance >= farPlaneDistance)
			{
				throw new ArgumentException("nearPlaneDistance >= farPlaneDistance");
			}
			double num = 1.0 / Math.Tan(fieldOfView * 0.5);
			Matrix result = default(Matrix);
			double num2 = result.M11 = num / aspectRatio;
			result.M12 = (result.M13 = (result.M14 = 0.0));
			result.M22 = num;
			result.M21 = (result.M23 = (result.M24 = 0.0));
			result.M31 = (result.M32 = 0.0);
			result.M33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
			result.M34 = -1.0;
			result.M41 = (result.M42 = (result.M44 = 0.0));
			result.M43 = nearPlaneDistance * farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
			return result;
		}

		public static void CreatePerspectiveFieldOfView(double fieldOfView, double aspectRatio, double nearPlaneDistance, double farPlaneDistance, out Matrix result)
		{
			if (fieldOfView <= 0.0 || fieldOfView >= 3.1415929794311523)
			{
				throw new ArgumentException("fieldOfView <= 0 or >= PI");
			}
			if (nearPlaneDistance <= 0.0)
			{
				throw new ArgumentException("nearPlaneDistance <= 0");
			}
			if (farPlaneDistance <= 0.0)
			{
				throw new ArgumentException("farPlaneDistance <= 0");
			}
			if (nearPlaneDistance >= farPlaneDistance)
			{
				throw new ArgumentException("nearPlaneDistance >= farPlaneDistance");
			}
			double num = 1.0 / Math.Tan(fieldOfView * 0.5);
			double num2 = result.M11 = num / aspectRatio;
			result.M12 = (result.M13 = (result.M14 = 0.0));
			result.M22 = num;
			result.M21 = (result.M23 = (result.M24 = 0.0));
			result.M31 = (result.M32 = 0.0);
			result.M33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
			result.M34 = -1.0;
			result.M41 = (result.M42 = (result.M44 = 0.0));
			result.M43 = nearPlaneDistance * farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
		}

		public static Matrix CreatePerspectiveOffCenter(double left, double right, double bottom, double top, double nearPlaneDistance, double farPlaneDistance)
		{
			if (nearPlaneDistance <= 0.0)
			{
				throw new ArgumentException("nearPlaneDistance <= 0");
			}
			if (farPlaneDistance <= 0.0)
			{
				throw new ArgumentException("farPlaneDistance <= 0");
			}
			if (nearPlaneDistance >= farPlaneDistance)
			{
				throw new ArgumentException("nearPlaneDistance >= farPlaneDistance");
			}
			Matrix result = default(Matrix);
			result.M11 = 2.0 * nearPlaneDistance / (right - left);
			result.M12 = (result.M13 = (result.M14 = 0.0));
			result.M22 = 2.0 * nearPlaneDistance / (top - bottom);
			result.M21 = (result.M23 = (result.M24 = 0.0));
			result.M31 = (left + right) / (right - left);
			result.M32 = (top + bottom) / (top - bottom);
			result.M33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
			result.M34 = -1.0;
			result.M43 = nearPlaneDistance * farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
			result.M41 = (result.M42 = (result.M44 = 0.0));
			return result;
		}

		public static void CreatePerspectiveOffCenter(double left, double right, double bottom, double top, double nearPlaneDistance, double farPlaneDistance, out Matrix result)
		{
			if (nearPlaneDistance <= 0.0)
			{
				throw new ArgumentException("nearPlaneDistance <= 0");
			}
			if (farPlaneDistance <= 0.0)
			{
				throw new ArgumentException("farPlaneDistance <= 0");
			}
			if (nearPlaneDistance >= farPlaneDistance)
			{
				throw new ArgumentException("nearPlaneDistance >= farPlaneDistance");
			}
			result.M11 = 2.0 * nearPlaneDistance / (right - left);
			result.M12 = (result.M13 = (result.M14 = 0.0));
			result.M22 = 2.0 * nearPlaneDistance / (top - bottom);
			result.M21 = (result.M23 = (result.M24 = 0.0));
			result.M31 = (left + right) / (right - left);
			result.M32 = (top + bottom) / (top - bottom);
			result.M33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
			result.M34 = -1.0;
			result.M43 = nearPlaneDistance * farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
			result.M41 = (result.M42 = (result.M44 = 0.0));
		}

		public static Matrix CreateRotationX(double radians)
		{
			Matrix identity = Identity;
			double num = Math.Cos(radians);
			double num2 = Math.Sin(radians);
			identity.M22 = num;
			identity.M23 = num2;
			identity.M32 = 0.0 - num2;
			identity.M33 = num;
			return identity;
		}

		public static void CreateRotationX(double radians, out Matrix result)
		{
			result = Identity;
			double num = Math.Cos(radians);
			double num2 = Math.Sin(radians);
			result.M22 = num;
			result.M23 = num2;
			result.M32 = 0.0 - num2;
			result.M33 = num;
		}

		public static Matrix CreateRotationY(double radians)
		{
			Matrix identity = Identity;
			double num = Math.Cos(radians);
			double num2 = Math.Sin(radians);
			identity.M11 = num;
			identity.M13 = 0.0 - num2;
			identity.M31 = num2;
			identity.M33 = num;
			return identity;
		}

		public static void CreateRotationY(double radians, out Matrix result)
		{
			result = Identity;
			double num = Math.Cos(radians);
			double num2 = Math.Sin(radians);
			result.M11 = num;
			result.M13 = 0.0 - num2;
			result.M31 = num2;
			result.M33 = num;
		}

		public static Matrix CreateRotationZ(double radians)
		{
			Matrix identity = Identity;
			double num = Math.Cos(radians);
			double num2 = Math.Sin(radians);
			identity.M11 = num;
			identity.M12 = num2;
			identity.M21 = 0.0 - num2;
			identity.M22 = num;
			return identity;
		}

		public static void CreateRotationZ(double radians, out Matrix result)
		{
			result = Identity;
			double num = Math.Cos(radians);
			double num2 = Math.Sin(radians);
			result.M11 = num;
			result.M12 = num2;
			result.M21 = 0.0 - num2;
			result.M22 = num;
		}

		public static Matrix CreateScale(double scale)
		{
			Matrix result = default(Matrix);
			result.M11 = scale;
			result.M12 = 0.0;
			result.M13 = 0.0;
			result.M14 = 0.0;
			result.M21 = 0.0;
			result.M22 = scale;
			result.M23 = 0.0;
			result.M24 = 0.0;
			result.M31 = 0.0;
			result.M32 = 0.0;
			result.M33 = scale;
			result.M34 = 0.0;
			result.M41 = 0.0;
			result.M42 = 0.0;
			result.M43 = 0.0;
			result.M44 = 1.0;
			return result;
		}

		public static void CreateScale(double scale, out Matrix result)
		{
			result.M11 = scale;
			result.M12 = 0.0;
			result.M13 = 0.0;
			result.M14 = 0.0;
			result.M21 = 0.0;
			result.M22 = scale;
			result.M23 = 0.0;
			result.M24 = 0.0;
			result.M31 = 0.0;
			result.M32 = 0.0;
			result.M33 = scale;
			result.M34 = 0.0;
			result.M41 = 0.0;
			result.M42 = 0.0;
			result.M43 = 0.0;
			result.M44 = 1.0;
		}

		public static Matrix CreateScale(double xScale, double yScale, double zScale)
		{
			Matrix result = default(Matrix);
			result.M11 = xScale;
			result.M12 = 0.0;
			result.M13 = 0.0;
			result.M14 = 0.0;
			result.M21 = 0.0;
			result.M22 = yScale;
			result.M23 = 0.0;
			result.M24 = 0.0;
			result.M31 = 0.0;
			result.M32 = 0.0;
			result.M33 = zScale;
			result.M34 = 0.0;
			result.M41 = 0.0;
			result.M42 = 0.0;
			result.M43 = 0.0;
			result.M44 = 1.0;
			return result;
		}

		public static void CreateScale(double xScale, double yScale, double zScale, out Matrix result)
		{
			result.M11 = xScale;
			result.M12 = 0.0;
			result.M13 = 0.0;
			result.M14 = 0.0;
			result.M21 = 0.0;
			result.M22 = yScale;
			result.M23 = 0.0;
			result.M24 = 0.0;
			result.M31 = 0.0;
			result.M32 = 0.0;
			result.M33 = zScale;
			result.M34 = 0.0;
			result.M41 = 0.0;
			result.M42 = 0.0;
			result.M43 = 0.0;
			result.M44 = 1.0;
		}

		public static Matrix CreateScale(Vector3 scales)
		{
			Matrix result = default(Matrix);
			result.M11 = scales.X;
			result.M12 = 0.0;
			result.M13 = 0.0;
			result.M14 = 0.0;
			result.M21 = 0.0;
			result.M22 = scales.Y;
			result.M23 = 0.0;
			result.M24 = 0.0;
			result.M31 = 0.0;
			result.M32 = 0.0;
			result.M33 = scales.Z;
			result.M34 = 0.0;
			result.M41 = 0.0;
			result.M42 = 0.0;
			result.M43 = 0.0;
			result.M44 = 1.0;
			return result;
		}

		public static void CreateScale(ref Vector3 scales, out Matrix result)
		{
			result.M11 = scales.X;
			result.M12 = 0.0;
			result.M13 = 0.0;
			result.M14 = 0.0;
			result.M21 = 0.0;
			result.M22 = scales.Y;
			result.M23 = 0.0;
			result.M24 = 0.0;
			result.M31 = 0.0;
			result.M32 = 0.0;
			result.M33 = scales.Z;
			result.M34 = 0.0;
			result.M41 = 0.0;
			result.M42 = 0.0;
			result.M43 = 0.0;
			result.M44 = 1.0;
		}

		public static Matrix CreateTranslation(double xPosition, double yPosition, double zPosition)
		{
			Matrix result = default(Matrix);
			result.M11 = 1.0;
			result.M12 = 0.0;
			result.M13 = 0.0;
			result.M14 = 0.0;
			result.M21 = 0.0;
			result.M22 = 1.0;
			result.M23 = 0.0;
			result.M24 = 0.0;
			result.M31 = 0.0;
			result.M32 = 0.0;
			result.M33 = 1.0;
			result.M34 = 0.0;
			result.M41 = xPosition;
			result.M42 = yPosition;
			result.M43 = zPosition;
			result.M44 = 1.0;
			return result;
		}

		public static void CreateTranslation(ref Vector3 position, out Matrix result)
		{
			result.M11 = 1.0;
			result.M12 = 0.0;
			result.M13 = 0.0;
			result.M14 = 0.0;
			result.M21 = 0.0;
			result.M22 = 1.0;
			result.M23 = 0.0;
			result.M24 = 0.0;
			result.M31 = 0.0;
			result.M32 = 0.0;
			result.M33 = 1.0;
			result.M34 = 0.0;
			result.M41 = position.X;
			result.M42 = position.Y;
			result.M43 = position.Z;
			result.M44 = 1.0;
		}

		public static Matrix CreateTranslation(Vector3 position)
		{
			Matrix result = default(Matrix);
			result.M11 = 1.0;
			result.M12 = 0.0;
			result.M13 = 0.0;
			result.M14 = 0.0;
			result.M21 = 0.0;
			result.M22 = 1.0;
			result.M23 = 0.0;
			result.M24 = 0.0;
			result.M31 = 0.0;
			result.M32 = 0.0;
			result.M33 = 1.0;
			result.M34 = 0.0;
			result.M41 = position.X;
			result.M42 = position.Y;
			result.M43 = position.Z;
			result.M44 = 1.0;
			return result;
		}

		public static void CreateTranslation(double xPosition, double yPosition, double zPosition, out Matrix result)
		{
			result.M11 = 1.0;
			result.M12 = 0.0;
			result.M13 = 0.0;
			result.M14 = 0.0;
			result.M21 = 0.0;
			result.M22 = 1.0;
			result.M23 = 0.0;
			result.M24 = 0.0;
			result.M31 = 0.0;
			result.M32 = 0.0;
			result.M33 = 1.0;
			result.M34 = 0.0;
			result.M41 = xPosition;
			result.M42 = yPosition;
			result.M43 = zPosition;
			result.M44 = 1.0;
		}

		public static Matrix CreateWorld(Vector3 position, Vector3 forward, Vector3 up)
		{
			CreateWorld(ref position, ref forward, ref up, out Matrix result);
			return result;
		}

		public static void CreateWorld(ref Vector3 position, ref Vector3 forward, ref Vector3 up, out Matrix result)
		{
			Vector3.Normalize(ref forward, out Vector3 result2);
			Vector3.Cross(ref forward, ref up, out Vector3 result3);
			Vector3.Cross(ref result3, ref forward, out Vector3 result4);
			result3.Normalize();
			result4.Normalize();
			result = default(Matrix);
			result.Right = result3;
			result.Up = result4;
			result.Forward = result2;
			result.Translation = position;
			result.M44 = 1.0;
		}

		public double Determinant()
		{
			double m = M11;
			double m2 = M12;
			double m3 = M13;
			double m4 = M14;
			double m5 = M21;
			double m6 = M22;
			double m7 = M23;
			double m8 = M24;
			double m9 = M31;
			double m10 = M32;
			double m11 = M33;
			double m12 = M34;
			double m13 = M41;
			double m14 = M42;
			double m15 = M43;
			double m16 = M44;
			double num = m11 * m16 - m12 * m15;
			double num2 = m10 * m16 - m12 * m14;
			double num3 = m10 * m15 - m11 * m14;
			double num4 = m9 * m16 - m12 * m13;
			double num5 = m9 * m15 - m11 * m13;
			double num6 = m9 * m14 - m10 * m13;
			return m * (m6 * num - m7 * num2 + m8 * num3) - m2 * (m5 * num - m7 * num4 + m8 * num5) + m3 * (m5 * num2 - m6 * num4 + m8 * num6) - m4 * (m5 * num3 - m6 * num5 + m7 * num6);
		}

		public static Matrix Divide(Matrix matrix1, Matrix matrix2)
		{
			matrix1.M11 /= matrix2.M11;
			matrix1.M12 /= matrix2.M12;
			matrix1.M13 /= matrix2.M13;
			matrix1.M14 /= matrix2.M14;
			matrix1.M21 /= matrix2.M21;
			matrix1.M22 /= matrix2.M22;
			matrix1.M23 /= matrix2.M23;
			matrix1.M24 /= matrix2.M24;
			matrix1.M31 /= matrix2.M31;
			matrix1.M32 /= matrix2.M32;
			matrix1.M33 /= matrix2.M33;
			matrix1.M34 /= matrix2.M34;
			matrix1.M41 /= matrix2.M41;
			matrix1.M42 /= matrix2.M42;
			matrix1.M43 /= matrix2.M43;
			matrix1.M44 /= matrix2.M44;
			return matrix1;
		}

		public static void Divide(ref Matrix matrix1, ref Matrix matrix2, out Matrix result)
		{
			result.M11 = matrix1.M11 / matrix2.M11;
			result.M12 = matrix1.M12 / matrix2.M12;
			result.M13 = matrix1.M13 / matrix2.M13;
			result.M14 = matrix1.M14 / matrix2.M14;
			result.M21 = matrix1.M21 / matrix2.M21;
			result.M22 = matrix1.M22 / matrix2.M22;
			result.M23 = matrix1.M23 / matrix2.M23;
			result.M24 = matrix1.M24 / matrix2.M24;
			result.M31 = matrix1.M31 / matrix2.M31;
			result.M32 = matrix1.M32 / matrix2.M32;
			result.M33 = matrix1.M33 / matrix2.M33;
			result.M34 = matrix1.M34 / matrix2.M34;
			result.M41 = matrix1.M41 / matrix2.M41;
			result.M42 = matrix1.M42 / matrix2.M42;
			result.M43 = matrix1.M43 / matrix2.M43;
			result.M44 = matrix1.M44 / matrix2.M44;
		}

		public static Matrix Divide(Matrix matrix1, double divider)
		{
			double num = 1.0 / divider;
			matrix1.M11 *= num;
			matrix1.M12 *= num;
			matrix1.M13 *= num;
			matrix1.M14 *= num;
			matrix1.M21 *= num;
			matrix1.M22 *= num;
			matrix1.M23 *= num;
			matrix1.M24 *= num;
			matrix1.M31 *= num;
			matrix1.M32 *= num;
			matrix1.M33 *= num;
			matrix1.M34 *= num;
			matrix1.M41 *= num;
			matrix1.M42 *= num;
			matrix1.M43 *= num;
			matrix1.M44 *= num;
			return matrix1;
		}

		public static void Divide(ref Matrix matrix1, double divider, out Matrix result)
		{
			double num = 1.0 / divider;
			result.M11 = matrix1.M11 * num;
			result.M12 = matrix1.M12 * num;
			result.M13 = matrix1.M13 * num;
			result.M14 = matrix1.M14 * num;
			result.M21 = matrix1.M21 * num;
			result.M22 = matrix1.M22 * num;
			result.M23 = matrix1.M23 * num;
			result.M24 = matrix1.M24 * num;
			result.M31 = matrix1.M31 * num;
			result.M32 = matrix1.M32 * num;
			result.M33 = matrix1.M33 * num;
			result.M34 = matrix1.M34 * num;
			result.M41 = matrix1.M41 * num;
			result.M42 = matrix1.M42 * num;
			result.M43 = matrix1.M43 * num;
			result.M44 = matrix1.M44 * num;
		}

		public bool Equals(Matrix other)
		{
			if (M11 == other.M11 && M22 == other.M22 && M33 == other.M33 && M44 == other.M44 && M12 == other.M12 && M13 == other.M13 && M14 == other.M14 && M21 == other.M21 && M23 == other.M23 && M24 == other.M24 && M31 == other.M31 && M32 == other.M32 && M34 == other.M34 && M41 == other.M41 && M42 == other.M42)
			{
				return M43 == other.M43;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			bool result = false;
			if (obj is Matrix)
			{
				result = Equals((Matrix)obj);
			}
			return result;
		}

		public override int GetHashCode()
		{
			return M11.GetHashCode() + M12.GetHashCode() + M13.GetHashCode() + M14.GetHashCode() + M21.GetHashCode() + M22.GetHashCode() + M23.GetHashCode() + M24.GetHashCode() + M31.GetHashCode() + M32.GetHashCode() + M33.GetHashCode() + M34.GetHashCode() + M41.GetHashCode() + M42.GetHashCode() + M43.GetHashCode() + M44.GetHashCode();
		}

		public static Matrix Invert(Matrix matrix)
		{
			Invert(ref matrix, out matrix);
			return matrix;
		}

		public static void Invert(ref Matrix matrix, out Matrix result)
		{
			double m = matrix.M11;
			double m2 = matrix.M12;
			double m3 = matrix.M13;
			double m4 = matrix.M14;
			double m5 = matrix.M21;
			double m6 = matrix.M22;
			double m7 = matrix.M23;
			double m8 = matrix.M24;
			double m9 = matrix.M31;
			double m10 = matrix.M32;
			double m11 = matrix.M33;
			double m12 = matrix.M34;
			double m13 = matrix.M41;
			double m14 = matrix.M42;
			double m15 = matrix.M43;
			double m16 = matrix.M44;
			double num = m11 * m16 - m12 * m15;
			double num2 = m10 * m16 - m12 * m14;
			double num3 = m10 * m15 - m11 * m14;
			double num4 = m9 * m16 - m12 * m13;
			double num5 = m9 * m15 - m11 * m13;
			double num6 = m9 * m14 - m10 * m13;
			double num7 = m6 * num - m7 * num2 + m8 * num3;
			double num8 = 0.0 - (m5 * num - m7 * num4 + m8 * num5);
			double num9 = m5 * num2 - m6 * num4 + m8 * num6;
			double num10 = 0.0 - (m5 * num3 - m6 * num5 + m7 * num6);
			double num11 = 1.0 / (m * num7 + m2 * num8 + m3 * num9 + m4 * num10);
			result.M11 = num7 * num11;
			result.M21 = num8 * num11;
			result.M31 = num9 * num11;
			result.M41 = num10 * num11;
			result.M12 = (0.0 - (m2 * num - m3 * num2 + m4 * num3)) * num11;
			result.M22 = (m * num - m3 * num4 + m4 * num5) * num11;
			result.M32 = (0.0 - (m * num2 - m2 * num4 + m4 * num6)) * num11;
			result.M42 = (m * num3 - m2 * num5 + m3 * num6) * num11;
			double num12 = m7 * m16 - m8 * m15;
			double num13 = m6 * m16 - m8 * m14;
			double num14 = m6 * m15 - m7 * m14;
			double num15 = m5 * m16 - m8 * m13;
			double num16 = m5 * m15 - m7 * m13;
			double num17 = m5 * m14 - m6 * m13;
			result.M13 = (m2 * num12 - m3 * num13 + m4 * num14) * num11;
			result.M23 = (0.0 - (m * num12 - m3 * num15 + m4 * num16)) * num11;
			result.M33 = (m * num13 - m2 * num15 + m4 * num17) * num11;
			result.M43 = (0.0 - (m * num14 - m2 * num16 + m3 * num17)) * num11;
			double num18 = m7 * m12 - m8 * m11;
			double num19 = m6 * m12 - m8 * m10;
			double num20 = m6 * m11 - m7 * m10;
			double num21 = m5 * m12 - m8 * m9;
			double num22 = m5 * m11 - m7 * m9;
			double num23 = m5 * m10 - m6 * m9;
			result.M14 = (0.0 - (m2 * num18 - m3 * num19 + m4 * num20)) * num11;
			result.M24 = (m * num18 - m3 * num21 + m4 * num22) * num11;
			result.M34 = (0.0 - (m * num19 - m2 * num21 + m4 * num23)) * num11;
			result.M44 = (m * num20 - m2 * num22 + m3 * num23) * num11;
		}

		public static Matrix Lerp(Matrix matrix1, Matrix matrix2, double amount)
		{
			matrix1.M11 += (matrix2.M11 - matrix1.M11) * amount;
			matrix1.M12 += (matrix2.M12 - matrix1.M12) * amount;
			matrix1.M13 += (matrix2.M13 - matrix1.M13) * amount;
			matrix1.M14 += (matrix2.M14 - matrix1.M14) * amount;
			matrix1.M21 += (matrix2.M21 - matrix1.M21) * amount;
			matrix1.M22 += (matrix2.M22 - matrix1.M22) * amount;
			matrix1.M23 += (matrix2.M23 - matrix1.M23) * amount;
			matrix1.M24 += (matrix2.M24 - matrix1.M24) * amount;
			matrix1.M31 += (matrix2.M31 - matrix1.M31) * amount;
			matrix1.M32 += (matrix2.M32 - matrix1.M32) * amount;
			matrix1.M33 += (matrix2.M33 - matrix1.M33) * amount;
			matrix1.M34 += (matrix2.M34 - matrix1.M34) * amount;
			matrix1.M41 += (matrix2.M41 - matrix1.M41) * amount;
			matrix1.M42 += (matrix2.M42 - matrix1.M42) * amount;
			matrix1.M43 += (matrix2.M43 - matrix1.M43) * amount;
			matrix1.M44 += (matrix2.M44 - matrix1.M44) * amount;
			return matrix1;
		}

		public static void Lerp(ref Matrix matrix1, ref Matrix matrix2, double amount, out Matrix result)
		{
			result.M11 = matrix1.M11 + (matrix2.M11 - matrix1.M11) * amount;
			result.M12 = matrix1.M12 + (matrix2.M12 - matrix1.M12) * amount;
			result.M13 = matrix1.M13 + (matrix2.M13 - matrix1.M13) * amount;
			result.M14 = matrix1.M14 + (matrix2.M14 - matrix1.M14) * amount;
			result.M21 = matrix1.M21 + (matrix2.M21 - matrix1.M21) * amount;
			result.M22 = matrix1.M22 + (matrix2.M22 - matrix1.M22) * amount;
			result.M23 = matrix1.M23 + (matrix2.M23 - matrix1.M23) * amount;
			result.M24 = matrix1.M24 + (matrix2.M24 - matrix1.M24) * amount;
			result.M31 = matrix1.M31 + (matrix2.M31 - matrix1.M31) * amount;
			result.M32 = matrix1.M32 + (matrix2.M32 - matrix1.M32) * amount;
			result.M33 = matrix1.M33 + (matrix2.M33 - matrix1.M33) * amount;
			result.M34 = matrix1.M34 + (matrix2.M34 - matrix1.M34) * amount;
			result.M41 = matrix1.M41 + (matrix2.M41 - matrix1.M41) * amount;
			result.M42 = matrix1.M42 + (matrix2.M42 - matrix1.M42) * amount;
			result.M43 = matrix1.M43 + (matrix2.M43 - matrix1.M43) * amount;
			result.M44 = matrix1.M44 + (matrix2.M44 - matrix1.M44) * amount;
		}

		public static Matrix Multiply(Matrix matrix1, Matrix matrix2)
		{
			double m = matrix1.M11 * matrix2.M11 + matrix1.M12 * matrix2.M21 + matrix1.M13 * matrix2.M31 + matrix1.M14 * matrix2.M41;
			double m2 = matrix1.M11 * matrix2.M12 + matrix1.M12 * matrix2.M22 + matrix1.M13 * matrix2.M32 + matrix1.M14 * matrix2.M42;
			double m3 = matrix1.M11 * matrix2.M13 + matrix1.M12 * matrix2.M23 + matrix1.M13 * matrix2.M33 + matrix1.M14 * matrix2.M43;
			double m4 = matrix1.M11 * matrix2.M14 + matrix1.M12 * matrix2.M24 + matrix1.M13 * matrix2.M34 + matrix1.M14 * matrix2.M44;
			double m5 = matrix1.M21 * matrix2.M11 + matrix1.M22 * matrix2.M21 + matrix1.M23 * matrix2.M31 + matrix1.M24 * matrix2.M41;
			double m6 = matrix1.M21 * matrix2.M12 + matrix1.M22 * matrix2.M22 + matrix1.M23 * matrix2.M32 + matrix1.M24 * matrix2.M42;
			double m7 = matrix1.M21 * matrix2.M13 + matrix1.M22 * matrix2.M23 + matrix1.M23 * matrix2.M33 + matrix1.M24 * matrix2.M43;
			double m8 = matrix1.M21 * matrix2.M14 + matrix1.M22 * matrix2.M24 + matrix1.M23 * matrix2.M34 + matrix1.M24 * matrix2.M44;
			double m9 = matrix1.M31 * matrix2.M11 + matrix1.M32 * matrix2.M21 + matrix1.M33 * matrix2.M31 + matrix1.M34 * matrix2.M41;
			double m10 = matrix1.M31 * matrix2.M12 + matrix1.M32 * matrix2.M22 + matrix1.M33 * matrix2.M32 + matrix1.M34 * matrix2.M42;
			double m11 = matrix1.M31 * matrix2.M13 + matrix1.M32 * matrix2.M23 + matrix1.M33 * matrix2.M33 + matrix1.M34 * matrix2.M43;
			double m12 = matrix1.M31 * matrix2.M14 + matrix1.M32 * matrix2.M24 + matrix1.M33 * matrix2.M34 + matrix1.M34 * matrix2.M44;
			double m13 = matrix1.M41 * matrix2.M11 + matrix1.M42 * matrix2.M21 + matrix1.M43 * matrix2.M31 + matrix1.M44 * matrix2.M41;
			double m14 = matrix1.M41 * matrix2.M12 + matrix1.M42 * matrix2.M22 + matrix1.M43 * matrix2.M32 + matrix1.M44 * matrix2.M42;
			double m15 = matrix1.M41 * matrix2.M13 + matrix1.M42 * matrix2.M23 + matrix1.M43 * matrix2.M33 + matrix1.M44 * matrix2.M43;
			double m16 = matrix1.M41 * matrix2.M14 + matrix1.M42 * matrix2.M24 + matrix1.M43 * matrix2.M34 + matrix1.M44 * matrix2.M44;
			matrix1.M11 = m;
			matrix1.M12 = m2;
			matrix1.M13 = m3;
			matrix1.M14 = m4;
			matrix1.M21 = m5;
			matrix1.M22 = m6;
			matrix1.M23 = m7;
			matrix1.M24 = m8;
			matrix1.M31 = m9;
			matrix1.M32 = m10;
			matrix1.M33 = m11;
			matrix1.M34 = m12;
			matrix1.M41 = m13;
			matrix1.M42 = m14;
			matrix1.M43 = m15;
			matrix1.M44 = m16;
			return matrix1;
		}

		public static void Multiply(ref Matrix matrix1, ref Matrix matrix2, out Matrix result)
		{
			double m = matrix1.M11 * matrix2.M11 + matrix1.M12 * matrix2.M21 + matrix1.M13 * matrix2.M31 + matrix1.M14 * matrix2.M41;
			double m2 = matrix1.M11 * matrix2.M12 + matrix1.M12 * matrix2.M22 + matrix1.M13 * matrix2.M32 + matrix1.M14 * matrix2.M42;
			double m3 = matrix1.M11 * matrix2.M13 + matrix1.M12 * matrix2.M23 + matrix1.M13 * matrix2.M33 + matrix1.M14 * matrix2.M43;
			double m4 = matrix1.M11 * matrix2.M14 + matrix1.M12 * matrix2.M24 + matrix1.M13 * matrix2.M34 + matrix1.M14 * matrix2.M44;
			double m5 = matrix1.M21 * matrix2.M11 + matrix1.M22 * matrix2.M21 + matrix1.M23 * matrix2.M31 + matrix1.M24 * matrix2.M41;
			double m6 = matrix1.M21 * matrix2.M12 + matrix1.M22 * matrix2.M22 + matrix1.M23 * matrix2.M32 + matrix1.M24 * matrix2.M42;
			double m7 = matrix1.M21 * matrix2.M13 + matrix1.M22 * matrix2.M23 + matrix1.M23 * matrix2.M33 + matrix1.M24 * matrix2.M43;
			double m8 = matrix1.M21 * matrix2.M14 + matrix1.M22 * matrix2.M24 + matrix1.M23 * matrix2.M34 + matrix1.M24 * matrix2.M44;
			double m9 = matrix1.M31 * matrix2.M11 + matrix1.M32 * matrix2.M21 + matrix1.M33 * matrix2.M31 + matrix1.M34 * matrix2.M41;
			double m10 = matrix1.M31 * matrix2.M12 + matrix1.M32 * matrix2.M22 + matrix1.M33 * matrix2.M32 + matrix1.M34 * matrix2.M42;
			double m11 = matrix1.M31 * matrix2.M13 + matrix1.M32 * matrix2.M23 + matrix1.M33 * matrix2.M33 + matrix1.M34 * matrix2.M43;
			double m12 = matrix1.M31 * matrix2.M14 + matrix1.M32 * matrix2.M24 + matrix1.M33 * matrix2.M34 + matrix1.M34 * matrix2.M44;
			double m13 = matrix1.M41 * matrix2.M11 + matrix1.M42 * matrix2.M21 + matrix1.M43 * matrix2.M31 + matrix1.M44 * matrix2.M41;
			double m14 = matrix1.M41 * matrix2.M12 + matrix1.M42 * matrix2.M22 + matrix1.M43 * matrix2.M32 + matrix1.M44 * matrix2.M42;
			double m15 = matrix1.M41 * matrix2.M13 + matrix1.M42 * matrix2.M23 + matrix1.M43 * matrix2.M33 + matrix1.M44 * matrix2.M43;
			double m16 = matrix1.M41 * matrix2.M14 + matrix1.M42 * matrix2.M24 + matrix1.M43 * matrix2.M34 + matrix1.M44 * matrix2.M44;
			result.M11 = m;
			result.M12 = m2;
			result.M13 = m3;
			result.M14 = m4;
			result.M21 = m5;
			result.M22 = m6;
			result.M23 = m7;
			result.M24 = m8;
			result.M31 = m9;
			result.M32 = m10;
			result.M33 = m11;
			result.M34 = m12;
			result.M41 = m13;
			result.M42 = m14;
			result.M43 = m15;
			result.M44 = m16;
		}

		public static Matrix Multiply(Matrix matrix1, double factor)
		{
			matrix1.M11 *= factor;
			matrix1.M12 *= factor;
			matrix1.M13 *= factor;
			matrix1.M14 *= factor;
			matrix1.M21 *= factor;
			matrix1.M22 *= factor;
			matrix1.M23 *= factor;
			matrix1.M24 *= factor;
			matrix1.M31 *= factor;
			matrix1.M32 *= factor;
			matrix1.M33 *= factor;
			matrix1.M34 *= factor;
			matrix1.M41 *= factor;
			matrix1.M42 *= factor;
			matrix1.M43 *= factor;
			matrix1.M44 *= factor;
			return matrix1;
		}

		public static void Multiply(ref Matrix matrix1, double factor, out Matrix result)
		{
			result.M11 = matrix1.M11 * factor;
			result.M12 = matrix1.M12 * factor;
			result.M13 = matrix1.M13 * factor;
			result.M14 = matrix1.M14 * factor;
			result.M21 = matrix1.M21 * factor;
			result.M22 = matrix1.M22 * factor;
			result.M23 = matrix1.M23 * factor;
			result.M24 = matrix1.M24 * factor;
			result.M31 = matrix1.M31 * factor;
			result.M32 = matrix1.M32 * factor;
			result.M33 = matrix1.M33 * factor;
			result.M34 = matrix1.M34 * factor;
			result.M41 = matrix1.M41 * factor;
			result.M42 = matrix1.M42 * factor;
			result.M43 = matrix1.M43 * factor;
			result.M44 = matrix1.M44 * factor;
		}

		public static Matrix Negate(Matrix matrix)
		{
			matrix.M11 = 0.0 - matrix.M11;
			matrix.M12 = 0.0 - matrix.M12;
			matrix.M13 = 0.0 - matrix.M13;
			matrix.M14 = 0.0 - matrix.M14;
			matrix.M21 = 0.0 - matrix.M21;
			matrix.M22 = 0.0 - matrix.M22;
			matrix.M23 = 0.0 - matrix.M23;
			matrix.M24 = 0.0 - matrix.M24;
			matrix.M31 = 0.0 - matrix.M31;
			matrix.M32 = 0.0 - matrix.M32;
			matrix.M33 = 0.0 - matrix.M33;
			matrix.M34 = 0.0 - matrix.M34;
			matrix.M41 = 0.0 - matrix.M41;
			matrix.M42 = 0.0 - matrix.M42;
			matrix.M43 = 0.0 - matrix.M43;
			matrix.M44 = 0.0 - matrix.M44;
			return matrix;
		}

		public static void Negate(ref Matrix matrix, out Matrix result)
		{
			result.M11 = 0.0 - matrix.M11;
			result.M12 = 0.0 - matrix.M12;
			result.M13 = 0.0 - matrix.M13;
			result.M14 = 0.0 - matrix.M14;
			result.M21 = 0.0 - matrix.M21;
			result.M22 = 0.0 - matrix.M22;
			result.M23 = 0.0 - matrix.M23;
			result.M24 = 0.0 - matrix.M24;
			result.M31 = 0.0 - matrix.M31;
			result.M32 = 0.0 - matrix.M32;
			result.M33 = 0.0 - matrix.M33;
			result.M34 = 0.0 - matrix.M34;
			result.M41 = 0.0 - matrix.M41;
			result.M42 = 0.0 - matrix.M42;
			result.M43 = 0.0 - matrix.M43;
			result.M44 = 0.0 - matrix.M44;
		}

		public static Matrix operator +(Matrix matrix1, Matrix matrix2)
		{
			Add(ref matrix1, ref matrix2, out matrix1);
			return matrix1;
		}

		public static Matrix operator /(Matrix matrix1, Matrix matrix2)
		{
			matrix1.M11 /= matrix2.M11;
			matrix1.M12 /= matrix2.M12;
			matrix1.M13 /= matrix2.M13;
			matrix1.M14 /= matrix2.M14;
			matrix1.M21 /= matrix2.M21;
			matrix1.M22 /= matrix2.M22;
			matrix1.M23 /= matrix2.M23;
			matrix1.M24 /= matrix2.M24;
			matrix1.M31 /= matrix2.M31;
			matrix1.M32 /= matrix2.M32;
			matrix1.M33 /= matrix2.M33;
			matrix1.M34 /= matrix2.M34;
			matrix1.M41 /= matrix2.M41;
			matrix1.M42 /= matrix2.M42;
			matrix1.M43 /= matrix2.M43;
			matrix1.M44 /= matrix2.M44;
			return matrix1;
		}

		public static Matrix operator /(Matrix matrix, double divider)
		{
			double num = 1.0 / divider;
			matrix.M11 *= num;
			matrix.M12 *= num;
			matrix.M13 *= num;
			matrix.M14 *= num;
			matrix.M21 *= num;
			matrix.M22 *= num;
			matrix.M23 *= num;
			matrix.M24 *= num;
			matrix.M31 *= num;
			matrix.M32 *= num;
			matrix.M33 *= num;
			matrix.M34 *= num;
			matrix.M41 *= num;
			matrix.M42 *= num;
			matrix.M43 *= num;
			matrix.M44 *= num;
			return matrix;
		}

		public static bool operator ==(Matrix matrix1, Matrix matrix2)
		{
			if (matrix1.M11 == matrix2.M11 && matrix1.M12 == matrix2.M12 && matrix1.M13 == matrix2.M13 && matrix1.M14 == matrix2.M14 && matrix1.M21 == matrix2.M21 && matrix1.M22 == matrix2.M22 && matrix1.M23 == matrix2.M23 && matrix1.M24 == matrix2.M24 && matrix1.M31 == matrix2.M31 && matrix1.M32 == matrix2.M32 && matrix1.M33 == matrix2.M33 && matrix1.M34 == matrix2.M34 && matrix1.M41 == matrix2.M41 && matrix1.M42 == matrix2.M42 && matrix1.M43 == matrix2.M43)
			{
				return matrix1.M44 == matrix2.M44;
			}
			return false;
		}

		public static bool operator !=(Matrix matrix1, Matrix matrix2)
		{
			if (matrix1.M11 == matrix2.M11 && matrix1.M12 == matrix2.M12 && matrix1.M13 == matrix2.M13 && matrix1.M14 == matrix2.M14 && matrix1.M21 == matrix2.M21 && matrix1.M22 == matrix2.M22 && matrix1.M23 == matrix2.M23 && matrix1.M24 == matrix2.M24 && matrix1.M31 == matrix2.M31 && matrix1.M32 == matrix2.M32 && matrix1.M33 == matrix2.M33 && matrix1.M34 == matrix2.M34 && matrix1.M41 == matrix2.M41 && matrix1.M42 == matrix2.M42 && matrix1.M43 == matrix2.M43)
			{
				return matrix1.M44 != matrix2.M44;
			}
			return true;
		}

		public static Matrix operator *(Matrix matrix1, Matrix matrix2)
		{
			double m = matrix1.M11 * matrix2.M11 + matrix1.M12 * matrix2.M21 + matrix1.M13 * matrix2.M31 + matrix1.M14 * matrix2.M41;
			double m2 = matrix1.M11 * matrix2.M12 + matrix1.M12 * matrix2.M22 + matrix1.M13 * matrix2.M32 + matrix1.M14 * matrix2.M42;
			double m3 = matrix1.M11 * matrix2.M13 + matrix1.M12 * matrix2.M23 + matrix1.M13 * matrix2.M33 + matrix1.M14 * matrix2.M43;
			double m4 = matrix1.M11 * matrix2.M14 + matrix1.M12 * matrix2.M24 + matrix1.M13 * matrix2.M34 + matrix1.M14 * matrix2.M44;
			double m5 = matrix1.M21 * matrix2.M11 + matrix1.M22 * matrix2.M21 + matrix1.M23 * matrix2.M31 + matrix1.M24 * matrix2.M41;
			double m6 = matrix1.M21 * matrix2.M12 + matrix1.M22 * matrix2.M22 + matrix1.M23 * matrix2.M32 + matrix1.M24 * matrix2.M42;
			double m7 = matrix1.M21 * matrix2.M13 + matrix1.M22 * matrix2.M23 + matrix1.M23 * matrix2.M33 + matrix1.M24 * matrix2.M43;
			double m8 = matrix1.M21 * matrix2.M14 + matrix1.M22 * matrix2.M24 + matrix1.M23 * matrix2.M34 + matrix1.M24 * matrix2.M44;
			double m9 = matrix1.M31 * matrix2.M11 + matrix1.M32 * matrix2.M21 + matrix1.M33 * matrix2.M31 + matrix1.M34 * matrix2.M41;
			double m10 = matrix1.M31 * matrix2.M12 + matrix1.M32 * matrix2.M22 + matrix1.M33 * matrix2.M32 + matrix1.M34 * matrix2.M42;
			double m11 = matrix1.M31 * matrix2.M13 + matrix1.M32 * matrix2.M23 + matrix1.M33 * matrix2.M33 + matrix1.M34 * matrix2.M43;
			double m12 = matrix1.M31 * matrix2.M14 + matrix1.M32 * matrix2.M24 + matrix1.M33 * matrix2.M34 + matrix1.M34 * matrix2.M44;
			double m13 = matrix1.M41 * matrix2.M11 + matrix1.M42 * matrix2.M21 + matrix1.M43 * matrix2.M31 + matrix1.M44 * matrix2.M41;
			double m14 = matrix1.M41 * matrix2.M12 + matrix1.M42 * matrix2.M22 + matrix1.M43 * matrix2.M32 + matrix1.M44 * matrix2.M42;
			double m15 = matrix1.M41 * matrix2.M13 + matrix1.M42 * matrix2.M23 + matrix1.M43 * matrix2.M33 + matrix1.M44 * matrix2.M43;
			double m16 = matrix1.M41 * matrix2.M14 + matrix1.M42 * matrix2.M24 + matrix1.M43 * matrix2.M34 + matrix1.M44 * matrix2.M44;
			matrix1.M11 = m;
			matrix1.M12 = m2;
			matrix1.M13 = m3;
			matrix1.M14 = m4;
			matrix1.M21 = m5;
			matrix1.M22 = m6;
			matrix1.M23 = m7;
			matrix1.M24 = m8;
			matrix1.M31 = m9;
			matrix1.M32 = m10;
			matrix1.M33 = m11;
			matrix1.M34 = m12;
			matrix1.M41 = m13;
			matrix1.M42 = m14;
			matrix1.M43 = m15;
			matrix1.M44 = m16;
			return matrix1;
		}

		public static Matrix operator *(Matrix matrix, double scaleFactor)
		{
			matrix.M11 *= scaleFactor;
			matrix.M12 *= scaleFactor;
			matrix.M13 *= scaleFactor;
			matrix.M14 *= scaleFactor;
			matrix.M21 *= scaleFactor;
			matrix.M22 *= scaleFactor;
			matrix.M23 *= scaleFactor;
			matrix.M24 *= scaleFactor;
			matrix.M31 *= scaleFactor;
			matrix.M32 *= scaleFactor;
			matrix.M33 *= scaleFactor;
			matrix.M34 *= scaleFactor;
			matrix.M41 *= scaleFactor;
			matrix.M42 *= scaleFactor;
			matrix.M43 *= scaleFactor;
			matrix.M44 *= scaleFactor;
			return matrix;
		}

		public static Matrix operator -(Matrix matrix1, Matrix matrix2)
		{
			matrix1.M11 -= matrix2.M11;
			matrix1.M12 -= matrix2.M12;
			matrix1.M13 -= matrix2.M13;
			matrix1.M14 -= matrix2.M14;
			matrix1.M21 -= matrix2.M21;
			matrix1.M22 -= matrix2.M22;
			matrix1.M23 -= matrix2.M23;
			matrix1.M24 -= matrix2.M24;
			matrix1.M31 -= matrix2.M31;
			matrix1.M32 -= matrix2.M32;
			matrix1.M33 -= matrix2.M33;
			matrix1.M34 -= matrix2.M34;
			matrix1.M41 -= matrix2.M41;
			matrix1.M42 -= matrix2.M42;
			matrix1.M43 -= matrix2.M43;
			matrix1.M44 -= matrix2.M44;
			return matrix1;
		}

		public static Matrix operator -(Matrix matrix)
		{
			matrix.M11 = 0.0 - matrix.M11;
			matrix.M12 = 0.0 - matrix.M12;
			matrix.M13 = 0.0 - matrix.M13;
			matrix.M14 = 0.0 - matrix.M14;
			matrix.M21 = 0.0 - matrix.M21;
			matrix.M22 = 0.0 - matrix.M22;
			matrix.M23 = 0.0 - matrix.M23;
			matrix.M24 = 0.0 - matrix.M24;
			matrix.M31 = 0.0 - matrix.M31;
			matrix.M32 = 0.0 - matrix.M32;
			matrix.M33 = 0.0 - matrix.M33;
			matrix.M34 = 0.0 - matrix.M34;
			matrix.M41 = 0.0 - matrix.M41;
			matrix.M42 = 0.0 - matrix.M42;
			matrix.M43 = 0.0 - matrix.M43;
			matrix.M44 = 0.0 - matrix.M44;
			return matrix;
		}

		public static Matrix Subtract(Matrix matrix1, Matrix matrix2)
		{
			matrix1.M11 -= matrix2.M11;
			matrix1.M12 -= matrix2.M12;
			matrix1.M13 -= matrix2.M13;
			matrix1.M14 -= matrix2.M14;
			matrix1.M21 -= matrix2.M21;
			matrix1.M22 -= matrix2.M22;
			matrix1.M23 -= matrix2.M23;
			matrix1.M24 -= matrix2.M24;
			matrix1.M31 -= matrix2.M31;
			matrix1.M32 -= matrix2.M32;
			matrix1.M33 -= matrix2.M33;
			matrix1.M34 -= matrix2.M34;
			matrix1.M41 -= matrix2.M41;
			matrix1.M42 -= matrix2.M42;
			matrix1.M43 -= matrix2.M43;
			matrix1.M44 -= matrix2.M44;
			return matrix1;
		}

		public static void Subtract(ref Matrix matrix1, ref Matrix matrix2, out Matrix result)
		{
			result.M11 = matrix1.M11 - matrix2.M11;
			result.M12 = matrix1.M12 - matrix2.M12;
			result.M13 = matrix1.M13 - matrix2.M13;
			result.M14 = matrix1.M14 - matrix2.M14;
			result.M21 = matrix1.M21 - matrix2.M21;
			result.M22 = matrix1.M22 - matrix2.M22;
			result.M23 = matrix1.M23 - matrix2.M23;
			result.M24 = matrix1.M24 - matrix2.M24;
			result.M31 = matrix1.M31 - matrix2.M31;
			result.M32 = matrix1.M32 - matrix2.M32;
			result.M33 = matrix1.M33 - matrix2.M33;
			result.M34 = matrix1.M34 - matrix2.M34;
			result.M41 = matrix1.M41 - matrix2.M41;
			result.M42 = matrix1.M42 - matrix2.M42;
			result.M43 = matrix1.M43 - matrix2.M43;
			result.M44 = matrix1.M44 - matrix2.M44;
		}

		public override string ToString()
		{
			return "{" + $"M11:{M11} M12:{M12} M13:{M13} M14:{M14}" + "} {" + $"M21:{M21} M22:{M22} M23:{M23} M24:{M24}" + "} {" + $"M31:{M31} M32:{M32} M33:{M33} M34:{M34}" + "} {" + $"M41:{M41} M42:{M42} M43:{M43} M44:{M44}" + "}";
		}

		public static Matrix Transpose(Matrix matrix)
		{
			Transpose(ref matrix, out Matrix result);
			return result;
		}

		public static void Transpose(ref Matrix matrix, out Matrix result)
		{
			result.M11 = matrix.M11;
			result.M12 = matrix.M21;
			result.M13 = matrix.M31;
			result.M14 = matrix.M41;
			result.M21 = matrix.M12;
			result.M22 = matrix.M22;
			result.M23 = matrix.M32;
			result.M24 = matrix.M42;
			result.M31 = matrix.M13;
			result.M32 = matrix.M23;
			result.M33 = matrix.M33;
			result.M34 = matrix.M43;
			result.M41 = matrix.M14;
			result.M42 = matrix.M24;
			result.M43 = matrix.M34;
			result.M44 = matrix.M44;
		}

		internal static void _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A(ref Matrix _0020, out double _0020_000A, out double _0020_0020, out double _0020_000A_000A, out double _0020_000A_0020, out double _0020_0020_000A, out double _0020_0020_0020, out double _0020_000A_000A_000A, out double _0020_000A_000A_0020, out double _0020_000A_0020_000A, out double _0020_000A_0020_0020, out double _0020_0020_000A_000A, out double _0020_0020_000A_0020, out double _0020_0020_0020_000A)
		{
			double num = _0020.M11 * _0020.M22 - _0020.M12 * _0020.M21;
			double num2 = _0020.M11 * _0020.M23 - _0020.M13 * _0020.M21;
			double num3 = _0020.M11 * _0020.M24 - _0020.M14 * _0020.M21;
			double num4 = _0020.M12 * _0020.M23 - _0020.M13 * _0020.M22;
			double num5 = _0020.M12 * _0020.M24 - _0020.M14 * _0020.M22;
			double num6 = _0020.M13 * _0020.M24 - _0020.M14 * _0020.M23;
			double num7 = _0020.M31 * _0020.M42 - _0020.M32 * _0020.M41;
			double num8 = _0020.M31 * _0020.M43 - _0020.M33 * _0020.M41;
			double num9 = _0020.M31 * _0020.M44 - _0020.M34 * _0020.M41;
			double num10 = _0020.M32 * _0020.M43 - _0020.M33 * _0020.M42;
			double num11 = _0020.M32 * _0020.M44 - _0020.M34 * _0020.M42;
			double num12 = _0020.M33 * _0020.M44 - _0020.M34 * _0020.M43;
			_0020_000A = num * num12 - num2 * num11 + num3 * num10 + num4 * num9 - num5 * num8 + num6 * num7;
			_0020_0020 = num;
			_0020_000A_000A = num2;
			_0020_000A_0020 = num3;
			_0020_0020_000A = num4;
			_0020_0020_0020 = num5;
			_0020_000A_000A_000A = num6;
			_0020_000A_000A_0020 = num7;
			_0020_000A_0020_000A = num8;
			_0020_000A_0020_0020 = num9;
			_0020_0020_000A_000A = num10;
			_0020_0020_000A_0020 = num11;
			_0020_0020_0020_000A = num12;
		}

		public bool Decompose(out Vector3 scale, out Quaternion rotation, out Vector3 translation)
		{
			translation.X = M41;
			translation.Y = M42;
			translation.Z = M43;
			double num = (Math.Sign(M11 * M12 * M13 * M14) < 0) ? (-1f) : 1f;
			double num2 = (Math.Sign(M21 * M22 * M23 * M24) < 0) ? (-1f) : 1f;
			double num3 = (Math.Sign(M31 * M32 * M33 * M34) < 0) ? (-1f) : 1f;
			scale.X = num * Math.Sqrt(M11 * M11 + M12 * M12 + M13 * M13);
			scale.Y = num2 * Math.Sqrt(M21 * M21 + M22 * M22 + M23 * M23);
			scale.Z = num3 * Math.Sqrt(M31 * M31 + M32 * M32 + M33 * M33);
			if (scale.X == 0.0 || scale.Y == 0.0 || scale.Z == 0.0)
			{
				rotation = Quaternion.Identity;
				return false;
			}
			Matrix matrix = new Matrix(M11 / scale.X, M12 / scale.X, M13 / scale.X, 0.0, M21 / scale.Y, M22 / scale.Y, M23 / scale.Y, 0.0, M31 / scale.Z, M32 / scale.Z, M33 / scale.Z, 0.0, 0.0, 0.0, 0.0, 1.0);
			rotation = Quaternion.CreateFromRotationMatrix(matrix);
			return true;
		}
	}
}
