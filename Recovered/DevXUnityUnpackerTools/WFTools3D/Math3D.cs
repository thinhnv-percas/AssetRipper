using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace WFTools3D
{
	public static class Math3D
	{
		private static RayMeshGeometry3DHitTestResult _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A;

		public static readonly Matrix3D ZeroMatrix = new Matrix3D(0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);

		public static readonly Point3D Origin = new Point3D(0.0, 0.0, 0.0);

		public static readonly Vector3D UnitX = new Vector3D(1.0, 0.0, 0.0);

		public static readonly Vector3D UnitY = new Vector3D(0.0, 1.0, 0.0);

		public static readonly Vector3D UnitZ = new Vector3D(0.0, 0.0, 1.0);

		public static double Distance(this Point3D pt)
		{
			return Math.Sqrt(pt.X * pt.X + pt.Y * pt.Y + pt.Z * pt.Z);
		}

		public static double DistanceSquared(this Point3D pt)
		{
			return pt.X * pt.X + pt.Y * pt.Y + pt.Z * pt.Z;
		}

		public static Point3D Add(this Point3D pt, Point3D add)
		{
			return new Point3D(pt.X + add.X, pt.Y + add.Y, pt.Z + add.Z);
		}

		public static Point3D Subtract(this Point3D pt, Point3D add)
		{
			return new Point3D(pt.X - add.X, pt.Y - add.Y, pt.Z - add.Z);
		}

		public static Point3D Inverse(this Point3D pt)
		{
			return new Point3D(0.0 - pt.X, 0.0 - pt.Y, 0.0 - pt.Z);
		}

		public static bool IsValid(this Point3D pt)
		{
			if (!MathUtils.IsValidNumber(pt.X) || !MathUtils.IsValidNumber(pt.Y) || !MathUtils.IsValidNumber(pt.Z))
			{
				return false;
			}
			return true;
		}

		public static bool IsValid(this Vector3D dir)
		{
			if (!MathUtils.IsValidNumber(dir.X) || !MathUtils.IsValidNumber(dir.Y) || !MathUtils.IsValidNumber(dir.Z))
			{
				return false;
			}
			if (dir.LengthSquared < 1E-12)
			{
				return false;
			}
			return true;
		}

		public static Vector3D Transform(this Quaternion q, Vector3D v)
		{
			double num = q.X + q.X;
			double num2 = q.Y + q.Y;
			double num3 = q.Z + q.Z;
			double num4 = q.W * num;
			double num5 = q.W * num2;
			double num6 = q.W * num3;
			double num7 = q.X * num;
			double num8 = q.X * num2;
			double num9 = q.X * num3;
			double num10 = q.Y * num2;
			double num11 = q.Y * num3;
			double num12 = q.Z * num3;
			double x = v.X * (1.0 - num10 - num12) + v.Y * (num8 - num6) + v.Z * (num9 + num5);
			double y = v.X * (num8 + num6) + v.Y * (1.0 - num7 - num12) + v.Z * (num11 - num4);
			double z = v.X * (num9 - num5) + v.Y * (num11 + num4) + v.Z * (1.0 - num7 - num10);
			return new Vector3D(x, y, z);
		}

		public static Point3D Transform(this Quaternion q, Point3D p)
		{
			return (Point3D)q.Transform((Vector3D)p);
		}

		public static Vector3D Rotate(this Vector3D v, Vector3D rotationAxis, double angleInDegrees)
		{
			return new Quaternion(rotationAxis, angleInDegrees).Transform(v);
		}

		public static Vector3D Cross(this Vector3D v, Vector3D vector)
		{
			return Vector3D.CrossProduct(v, vector);
		}

		public static double Dot(this Vector3D v, Vector3D vector)
		{
			return Vector3D.DotProduct(v, vector);
		}

		public static double AngleTo(this Vector3D v, Vector3D vector)
		{
			return Vector3D.AngleBetween(v, vector);
		}

		public static Vector3D DirectionTo(this Point3D thisPoint, Point3D targetPoint)
		{
			Vector3D result = targetPoint - thisPoint;
			result.Normalize();
			return result;
		}

		public static double GetAspectRatio(Size size)
		{
			return size.Width / size.Height;
		}

		private static Matrix3D _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A(ProjectionCamera _0020)
		{
			Vector3D vector3D = -_0020.LookDirection;
			vector3D.Normalize();
			Vector3D vector3D2 = _0020.UpDirection.Cross(vector3D);
			vector3D2.Normalize();
			Vector3D v = vector3D.Cross(vector3D2);
			Vector3D vector = (Vector3D)_0020.Position;
			double offsetX = 0.0 - vector3D2.Dot(vector);
			double offsetY = 0.0 - v.Dot(vector);
			double offsetZ = 0.0 - vector3D.Dot(vector);
			return new Matrix3D(vector3D2.X, v.X, vector3D.X, 0.0, vector3D2.Y, v.Y, vector3D.Y, 0.0, vector3D2.Z, v.Z, vector3D.Z, 0.0, offsetX, offsetY, offsetZ, 1.0);
		}

		public static Matrix3D GetViewMatrix(Camera camera)
		{
			if (camera == null)
			{
				throw new ArgumentNullException("camera");
			}
			ProjectionCamera projectionCamera = camera as ProjectionCamera;
			if (projectionCamera != null)
			{
				return _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A(projectionCamera);
			}
			MatrixCamera matrixCamera = camera as MatrixCamera;
			if (matrixCamera != null)
			{
				return matrixCamera.ViewMatrix;
			}
			throw new ArgumentException($"Unsupported camera type '{camera.GetType().FullName}'.", "camera");
		}

		private static Matrix3D _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020(OrthographicCamera _0020, double _0020_000A)
		{
			double width = _0020.Width;
			double num = width / _0020_000A;
			double nearPlaneDistance = _0020.NearPlaneDistance;
			double farPlaneDistance = _0020.FarPlaneDistance;
			double num2 = 1.0 / (nearPlaneDistance - farPlaneDistance);
			double offsetZ = nearPlaneDistance * num2;
			return new Matrix3D(2.0 / width, 0.0, 0.0, 0.0, 0.0, 2.0 / num, 0.0, 0.0, 0.0, 0.0, num2, 0.0, 0.0, 0.0, offsetZ, 1.0);
		}

		private static Matrix3D _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020(PerspectiveCamera _0020, double _0020_000A)
		{
			double num = MathUtils.ToRadians(_0020.FieldOfView);
			double nearPlaneDistance = _0020.NearPlaneDistance;
			double farPlaneDistance = _0020.FarPlaneDistance;
			double num2 = 1.0 / Math.Tan(num / 2.0);
			double m = _0020_000A * num2;
			double num3 = (farPlaneDistance == double.PositiveInfinity) ? (-1.0) : (farPlaneDistance / (nearPlaneDistance - farPlaneDistance));
			double offsetZ = nearPlaneDistance * num3;
			return new Matrix3D(num2, 0.0, 0.0, 0.0, 0.0, m, 0.0, 0.0, 0.0, 0.0, num3, -1.0, 0.0, 0.0, offsetZ, 0.0);
		}

		public static Matrix3D GetProjectionMatrix(Camera camera, double aspectRatio)
		{
			if (camera == null)
			{
				throw new ArgumentNullException("camera");
			}
			PerspectiveCamera perspectiveCamera = camera as PerspectiveCamera;
			if (perspectiveCamera != null)
			{
				return _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020(perspectiveCamera, aspectRatio);
			}
			OrthographicCamera orthographicCamera = camera as OrthographicCamera;
			if (orthographicCamera != null)
			{
				return _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020(orthographicCamera, aspectRatio);
			}
			MatrixCamera matrixCamera = camera as MatrixCamera;
			if (matrixCamera != null)
			{
				return matrixCamera.ProjectionMatrix;
			}
			throw new ArgumentException($"Unsupported camera type '{camera.GetType().FullName}'.", "camera");
		}

		private static Matrix3D _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A(Rect _0020)
		{
			double num = _0020.Width / 2.0;
			double num2 = _0020.Height / 2.0;
			double offsetX = _0020.X + num;
			double offsetY = _0020.Y + num2;
			return new Matrix3D(num, 0.0, 0.0, 0.0, 0.0, 0.0 - num2, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, offsetX, offsetY, 0.0, 1.0);
		}

		public static Matrix3D TryWorldToViewportTransform(Viewport3DVisual visual, out bool success)
		{
			success = false;
			Matrix3D result = TryWorldToCameraTransform(visual, out success);
			if (success)
			{
				result.Append(GetProjectionMatrix(visual.Camera, GetAspectRatio(visual.Viewport.Size)));
				result.Append(_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A(visual.Viewport));
				success = true;
			}
			return result;
		}

		public static Matrix3D TryWorldToCameraTransform(Viewport3DVisual visual, out bool success)
		{
			success = false;
			if (visual == null)
			{
				return ZeroMatrix;
			}
			Matrix3D identity = Matrix3D.Identity;
			Camera camera = visual.Camera;
			if (camera == null)
			{
				return ZeroMatrix;
			}
			if (visual.Viewport == Rect.Empty)
			{
				return ZeroMatrix;
			}
			Transform3D transform = camera.Transform;
			if (transform != null)
			{
				Matrix3D value = transform.Value;
				if (!value.HasInverse)
				{
					return ZeroMatrix;
				}
				value.Invert();
				identity.Append(value);
			}
			identity.Append(GetViewMatrix(camera));
			success = true;
			return identity;
		}

		public static Matrix3D GetTransformationMatrix(DependencyObject visual, DependencyObject relativeTo = null)
		{
			Matrix3D identity = Matrix3D.Identity;
			while (visual is ModelVisual3D)
			{
				Transform3D transform3D = (Transform3D)visual.GetValue(ModelVisual3D.TransformProperty);
				if (transform3D != null)
				{
					identity.Append(transform3D.Value);
				}
				visual = VisualTreeHelper.GetParent(visual);
				if (visual == relativeTo)
				{
					break;
				}
			}
			return identity;
		}

		public static Matrix3D GetWorldTransformationMatrix(DependencyObject visual, out Viewport3DVisual viewport)
		{
			Matrix3D identity = Matrix3D.Identity;
			viewport = null;
			if (!(visual is Visual3D))
			{
				throw new ArgumentException("Must be of type Visual3D.", "visual");
			}
			while (visual != null && visual is ModelVisual3D)
			{
				Transform3D transform3D = (Transform3D)visual.GetValue(ModelVisual3D.TransformProperty);
				if (transform3D != null)
				{
					identity.Append(transform3D.Value);
				}
				visual = VisualTreeHelper.GetParent(visual);
			}
			viewport = (visual as Viewport3DVisual);
			if (viewport == null)
			{
				if (visual != null)
				{
					throw new ApplicationException($"Unsupported type: '{visual.GetType().FullName}'.  Expected tree of ModelVisual3Ds leading up to a Viewport3DVisual.");
				}
				return ZeroMatrix;
			}
			return identity;
		}

		public static Matrix3D TryTransformTo2DAncestor(DependencyObject visual, out Viewport3DVisual viewport, out bool success)
		{
			Matrix3D worldTransformationMatrix = GetWorldTransformationMatrix(visual, out viewport);
			worldTransformationMatrix.Append(TryWorldToViewportTransform(viewport, out success));
			if (!success)
			{
				return ZeroMatrix;
			}
			return worldTransformationMatrix;
		}

		public static Matrix3D TryTransformToCameraSpace(DependencyObject visual, out Viewport3DVisual viewport, out bool success)
		{
			Matrix3D worldTransformationMatrix = GetWorldTransformationMatrix(visual, out viewport);
			worldTransformationMatrix.Append(TryWorldToCameraTransform(viewport, out success));
			if (!success)
			{
				return ZeroMatrix;
			}
			return worldTransformationMatrix;
		}

		public static bool GetRay(Point ptPlot, ModelVisual3D mv3D, out Point3D ptNear, out Point3D ptFar)
		{
			Viewport3DVisual viewport;
			bool success;
			Matrix3D matrix3D = TryTransformTo2DAncestor(mv3D, out viewport, out success);
			if (!success || !matrix3D.HasInverse)
			{
				ptNear = (ptFar = default(Point3D));
				return false;
			}
			Matrix3D matrix3D2 = matrix3D;
			matrix3D2.Invert();
			Point3D point = new Point3D(ptPlot.X, ptPlot.Y, 0.0);
			ptNear = matrix3D2.Transform(point);
			point.Z = 1.0;
			ptFar = matrix3D2.Transform(point);
			return true;
		}

		public static RayMeshGeometry3DHitTestResult HitTest(object obj, Point pt)
		{
			_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A = null;
			Viewport3D viewport3D = obj as Viewport3D;
			if (viewport3D != null)
			{
				VisualTreeHelper.HitTest(viewport3D, null, _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020, new PointHitTestParameters(pt));
			}
			else
			{
				ModelVisual3D modelVisual3D = obj as ModelVisual3D;
				if (modelVisual3D != null && GetRay(pt, modelVisual3D, out Point3D ptNear, out Point3D ptFar))
				{
					RayHitTestParameters hitTestParameters = new RayHitTestParameters(ptNear, ptFar - ptNear);
					VisualTreeHelper.HitTest(modelVisual3D, null, _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020, hitTestParameters);
				}
			}
			return _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A;
		}

		private static HitTestResultBehavior _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020(HitTestResult _0020)
		{
			RayMeshGeometry3DHitTestResult rayMeshGeometry3DHitTestResult = _0020 as RayMeshGeometry3DHitTestResult;
			if (rayMeshGeometry3DHitTestResult != null)
			{
				if (_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A == null)
				{
					_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A = rayMeshGeometry3DHitTestResult;
				}
				else if (rayMeshGeometry3DHitTestResult.DistanceToRayOrigin < _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A.DistanceToRayOrigin)
				{
					_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A = rayMeshGeometry3DHitTestResult;
				}
			}
			return HitTestResultBehavior.Continue;
		}

		[Obsolete]
		public static List<double> RayMeshIntersections(Point3D orig, Vector3D dir, MeshGeometry3D mesh, bool frontFacesOnly)
		{
			List<double> list = new List<double>();
			if (mesh == null || !dir.IsValid())
			{
				return list;
			}
			double num = 1E-09;
			Int32Collection triangleIndices = mesh.TriangleIndices;
			Point3DCollection positions = mesh.Positions;
			for (int i = 0; i < triangleIndices.Count; i += 3)
			{
				Point3D point = positions[triangleIndices[i]];
				Point3D point2 = positions[triangleIndices[i + 1]];
				Point3D point3 = positions[triangleIndices[i + 2]];
				Vector3D vector3D = point2 - point;
				Vector3D vector3D2 = point3 - point;
				Vector3D vector = dir.Cross(vector3D2);
				double num2 = vector3D.Dot(vector);
				if (num2 < num && (frontFacesOnly || num2 > 0.0 - num))
				{
					continue;
				}
				double num3 = 1.0 / num2;
				Vector3D v = orig - point;
				double num4 = v.Dot(vector) * num3;
				if (!(num4 < 0.0) && !(num4 > 1.0))
				{
					Vector3D vector2 = v.Cross(vector3D);
					double num5 = dir.Dot(vector2) * num3;
					if (!(num5 < 0.0) && !(num4 + num5 > 1.0))
					{
						double item = vector3D2.Dot(vector2) * num3;
						list.Add(item);
					}
				}
			}
			return list;
		}

		public static Rect3D TransformBounds(Rect3D bounds, Matrix3D transform)
		{
			double x = bounds.X;
			double y = bounds.Y;
			double z = bounds.Z;
			double x2 = bounds.X + bounds.SizeX;
			double y2 = bounds.Y + bounds.SizeY;
			double z2 = bounds.Z + bounds.SizeZ;
			Point3D[] array = new Point3D[8]
			{
				new Point3D(x, y, z),
				new Point3D(x, y, z2),
				new Point3D(x, y2, z),
				new Point3D(x, y2, z2),
				new Point3D(x2, y, z),
				new Point3D(x2, y, z2),
				new Point3D(x2, y2, z),
				new Point3D(x2, y2, z2)
			};
			transform.Transform(array);
			Point3D point3D = array[0];
			x = (x2 = point3D.X);
			y = (y2 = point3D.Y);
			z = (z2 = point3D.Z);
			for (int i = 1; i < array.Length; i++)
			{
				point3D = array[i];
				x = Math.Min(x, point3D.X);
				y = Math.Min(y, point3D.Y);
				z = Math.Min(z, point3D.Z);
				x2 = Math.Max(x2, point3D.X);
				y2 = Math.Max(y2, point3D.Y);
				z2 = Math.Max(z2, point3D.Z);
			}
			return new Rect3D(x, y, z, x2 - x, y2 - y, z2 - z);
		}

		public static Point3D GetCenter(Rect3D box)
		{
			return new Point3D(box.X + box.SizeX / 2.0, box.Y + box.SizeY / 2.0, box.Z + box.SizeZ / 2.0);
		}

		public static Vector3D Lerp(Vector3D from, Vector3D to, double t)
		{
			Vector3D result = default(Vector3D);
			result.X = from.X * (1.0 - t) + to.X * t;
			result.Y = from.Y * (1.0 - t) + to.Y * t;
			result.Z = from.Z * (1.0 - t) + to.Z * t;
			return result;
		}

		public static Quaternion Lerp(Quaternion from, Quaternion to, double t)
		{
			double angleInDegrees = from.Angle * (1.0 - t) + to.Angle * t;
			return new Quaternion(Lerp(from.Axis, to.Axis, t), angleInDegrees);
		}

		public static Point3D Rotate(Point3D pt, Point3D ptAxis1, Point3D ptAxis2, double angle, bool isAngleInDegrees = true)
		{
			return (Point3D)Rotation(ptAxis2 - ptAxis1, angle, isAngleInDegrees).Transform(pt - ptAxis1) + (Vector3D)ptAxis1;
		}

		public static Quaternion Rotation(Vector3D rotationAxis, double angle, bool isAngleInDegrees = true)
		{
			if (!isAngleInDegrees)
			{
				angle = MathUtils.ToDegrees(angle);
			}
			angle %= 360.0;
			if (angle < 0.0)
			{
				angle += 360.0;
			}
			if (angle > 360.0)
			{
				angle -= 360.0;
			}
			return new Quaternion(rotationAxis, angle);
		}

		public static Quaternion RotationX(double angle, bool isAngleInDegrees = true)
		{
			return Rotation(UnitX, angle, isAngleInDegrees);
		}

		public static Quaternion RotationY(double angle, bool isAngleInDegrees = true)
		{
			return Rotation(UnitY, angle, isAngleInDegrees);
		}

		public static Quaternion RotationZ(double angle, bool isAngleInDegrees = true)
		{
			return Rotation(UnitZ, angle, isAngleInDegrees);
		}

		public static void LookAt(Point3D targetPoint, Point3D observerPosition, out Vector3D lookDirection, out Vector3D upDirection)
		{
			lookDirection = targetPoint - observerPosition;
			lookDirection.Normalize();
			double x = lookDirection.X;
			double y = lookDirection.Y;
			double z = lookDirection.Z;
			double num = x * x + y * y;
			if (num > 1E-12)
			{
				upDirection = new Vector3D((0.0 - z) * x / num, (0.0 - z) * y / num, 1.0);
				upDirection.Normalize();
			}
			else if (z > 0.0)
			{
				upDirection = UnitX;
			}
			else
			{
				upDirection = -UnitX;
			}
		}
	}
}
