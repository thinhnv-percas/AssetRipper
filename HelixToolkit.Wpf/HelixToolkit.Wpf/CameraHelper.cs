using System;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public static class CameraHelper
{
	public static void AnimateTo(this ProjectionCamera camera, Point3D newPosition, Vector3D newDirection, Vector3D newUpDirection, double animationTime)
	{
		Point3D position = camera.Position;
		Vector3D lookDirection = camera.LookDirection;
		Vector3D upDirection = camera.UpDirection;
		camera.Position = newPosition;
		camera.LookDirection = newDirection;
		camera.UpDirection = newUpDirection;
		if (animationTime > 0.0)
		{
			Point3DAnimation point3DAnimation = new Point3DAnimation(position, newPosition, new Duration(TimeSpan.FromMilliseconds(animationTime)))
			{
				AccelerationRatio = 0.3,
				DecelerationRatio = 0.5,
				FillBehavior = FillBehavior.Stop
			};
			point3DAnimation.Completed += delegate
			{
				camera.BeginAnimation(ProjectionCamera.PositionProperty, null);
			};
			camera.BeginAnimation(ProjectionCamera.PositionProperty, point3DAnimation);
			Vector3DAnimation vector3DAnimation = new Vector3DAnimation(lookDirection, newDirection, new Duration(TimeSpan.FromMilliseconds(animationTime)))
			{
				AccelerationRatio = 0.3,
				DecelerationRatio = 0.5,
				FillBehavior = FillBehavior.Stop
			};
			vector3DAnimation.Completed += delegate
			{
				camera.BeginAnimation(ProjectionCamera.LookDirectionProperty, null);
			};
			camera.BeginAnimation(ProjectionCamera.LookDirectionProperty, vector3DAnimation);
			Vector3DAnimation vector3DAnimation2 = new Vector3DAnimation(upDirection, newUpDirection, new Duration(TimeSpan.FromMilliseconds(animationTime)))
			{
				AccelerationRatio = 0.3,
				DecelerationRatio = 0.5,
				FillBehavior = FillBehavior.Stop
			};
			vector3DAnimation2.Completed += delegate
			{
				camera.BeginAnimation(ProjectionCamera.UpDirectionProperty, null);
			};
			camera.BeginAnimation(ProjectionCamera.UpDirectionProperty, vector3DAnimation2);
		}
	}

	public static void AnimateWidth(this OrthographicCamera camera, double newWidth, double animationTime)
	{
		double width = camera.Width;
		camera.Width = newWidth;
		if (animationTime > 0.0)
		{
			DoubleAnimation animation = new DoubleAnimation(width, newWidth, new Duration(TimeSpan.FromMilliseconds(animationTime)))
			{
				AccelerationRatio = 0.3,
				DecelerationRatio = 0.5,
				FillBehavior = FillBehavior.Stop
			};
			camera.BeginAnimation(OrthographicCamera.WidthProperty, animation);
		}
	}

	public static void ChangeDirection(this ProjectionCamera camera, Vector3D newLookDirection, Vector3D newUpDirection, double animationTime)
	{
		Point3D target = camera.Position + camera.LookDirection;
		double length = camera.LookDirection.Length;
		newLookDirection.Normalize();
		camera.LookAt(target, newLookDirection * length, newUpDirection, animationTime);
	}

	public static void Copy(this ProjectionCamera source, ProjectionCamera dest, bool copyNearFarPlaneDistances = true)
	{
		if (source == null || dest == null)
		{
			return;
		}
		dest.LookDirection = source.LookDirection;
		dest.Position = source.Position;
		dest.UpDirection = source.UpDirection;
		if (copyNearFarPlaneDistances)
		{
			dest.NearPlaneDistance = source.NearPlaneDistance;
			dest.FarPlaneDistance = source.FarPlaneDistance;
		}
		PerspectiveCamera perspectiveCamera = source as PerspectiveCamera;
		OrthographicCamera orthographicCamera = source as OrthographicCamera;
		PerspectiveCamera perspectiveCamera2 = dest as PerspectiveCamera;
		OrthographicCamera orthographicCamera2 = dest as OrthographicCamera;
		if (perspectiveCamera2 != null)
		{
			double fieldOfView = 45.0;
			if (perspectiveCamera != null)
			{
				fieldOfView = perspectiveCamera.FieldOfView;
			}
			if (orthographicCamera != null)
			{
				double length = source.LookDirection.Length;
				fieldOfView = Math.Atan(orthographicCamera.Width / 2.0 / length) * 180.0 / Math.PI * 2.0;
			}
			perspectiveCamera2.FieldOfView = fieldOfView;
		}
		if (orthographicCamera2 != null)
		{
			double width = 100.0;
			if (perspectiveCamera != null)
			{
				double length2 = source.LookDirection.Length;
				width = Math.Tan(perspectiveCamera.FieldOfView / 180.0 * Math.PI / 2.0) * length2 * 2.0;
			}
			if (orthographicCamera != null)
			{
				width = orthographicCamera.Width;
			}
			orthographicCamera2.Width = width;
		}
	}

	public static void CopyDirectionOnly(this ProjectionCamera source, ProjectionCamera dest, double distance)
	{
		if (source != null && dest != null)
		{
			Vector3D lookDirection = source.LookDirection;
			lookDirection.Normalize();
			lookDirection *= distance;
			dest.LookDirection = lookDirection;
			dest.Position = new Point3D(0.0 - dest.LookDirection.X, 0.0 - dest.LookDirection.Y, 0.0 - dest.LookDirection.Z);
			dest.UpDirection = source.UpDirection;
		}
	}

	public static PerspectiveCamera CreateDefaultCamera()
	{
		PerspectiveCamera perspectiveCamera = new PerspectiveCamera();
		perspectiveCamera.Reset();
		return perspectiveCamera;
	}

	public static string GetInfo(this Camera camera)
	{
		MatrixCamera matrixCamera = camera as MatrixCamera;
		PerspectiveCamera perspectiveCamera = camera as PerspectiveCamera;
		ProjectionCamera projectionCamera = camera as ProjectionCamera;
		OrthographicCamera orthographicCamera = camera as OrthographicCamera;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(camera.GetType().Name);
		if (projectionCamera != null)
		{
			stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "LookDirection:\t{0:0.000},{1:0.000},{2:0.000}", new object[3]
			{
				projectionCamera.LookDirection.X,
				projectionCamera.LookDirection.Y,
				projectionCamera.LookDirection.Z
			}));
			stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "UpDirection:\t{0:0.000},{1:0.000},{2:0.000}", new object[3]
			{
				projectionCamera.UpDirection.X,
				projectionCamera.UpDirection.Y,
				projectionCamera.UpDirection.Z
			}));
			stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "Position:\t\t{0:0.000},{1:0.000},{2:0.000}", new object[3]
			{
				projectionCamera.Position.X,
				projectionCamera.Position.Y,
				projectionCamera.Position.Z
			}));
			Point3D point3D = projectionCamera.Position + projectionCamera.LookDirection;
			stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "Target:\t\t{0:0.000},{1:0.000},{2:0.000}", new object[3] { point3D.X, point3D.Y, point3D.Z }));
			stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "NearPlaneDist:\t{0}", new object[1] { projectionCamera.NearPlaneDistance }));
			stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "FarPlaneDist:\t{0}", new object[1] { projectionCamera.FarPlaneDistance }));
		}
		if (perspectiveCamera != null)
		{
			stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "FieldOfView:\t{0:0.#}°", new object[1] { perspectiveCamera.FieldOfView }));
		}
		if (orthographicCamera != null)
		{
			stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "Width:\t{0:0.###}", new object[1] { orthographicCamera.Width }));
		}
		if (matrixCamera != null)
		{
			stringBuilder.AppendLine("ProjectionMatrix:");
			stringBuilder.AppendLine(matrixCamera.ProjectionMatrix.ToString(CultureInfo.InvariantCulture));
			stringBuilder.AppendLine("ViewMatrix:");
			stringBuilder.AppendLine(matrixCamera.ViewMatrix.ToString(CultureInfo.InvariantCulture));
		}
		return stringBuilder.ToString().Trim();
	}

	public static void LookAt(this ProjectionCamera camera, Point3D target, double animationTime)
	{
		camera.LookAt(target, camera.LookDirection, animationTime);
	}

	public static void LookAt(this ProjectionCamera camera, Point3D target, Vector3D newLookDirection, double animationTime)
	{
		camera.LookAt(target, newLookDirection, camera.UpDirection, animationTime);
	}

	public static void LookAt(this ProjectionCamera camera, Point3D target, Vector3D newLookDirection, Vector3D newUpDirection, double animationTime)
	{
		Point3D newPosition = target - newLookDirection;
		if (camera is PerspectiveCamera camera2)
		{
			camera2.AnimateTo(newPosition, newLookDirection, newUpDirection, animationTime);
		}
		else if (camera is OrthographicCamera camera3)
		{
			camera3.AnimateTo(newPosition, newLookDirection, newUpDirection, animationTime);
		}
	}

	public static void LookAt(this ProjectionCamera camera, Point3D target, double distance, double animationTime)
	{
		Vector3D lookDirection = camera.LookDirection;
		lookDirection.Normalize();
		camera.LookAt(target, lookDirection * distance, animationTime);
	}

	public static void Reset(this Camera camera)
	{
		if (camera is PerspectiveCamera camera2)
		{
			camera2.Reset();
		}
		if (camera is OrthographicCamera camera3)
		{
			camera3.Reset();
		}
	}

	public static void Reset(this PerspectiveCamera camera)
	{
		if (camera != null)
		{
			camera.Position = new Point3D(2.0, 16.0, 20.0);
			camera.LookDirection = new Vector3D(-2.0, -16.0, -20.0);
			camera.UpDirection = new Vector3D(0.0, 0.0, 1.0);
			camera.FieldOfView = 45.0;
			camera.NearPlaneDistance = 0.1;
			camera.FarPlaneDistance = double.PositiveInfinity;
		}
	}

	public static void Reset(this OrthographicCamera camera)
	{
		if (camera != null)
		{
			camera.Position = new Point3D(2.0, 16.0, 20.0);
			camera.LookDirection = new Vector3D(-2.0, -16.0, -20.0);
			camera.UpDirection = new Vector3D(0.0, 0.0, 1.0);
			camera.Width = 40.0;
			camera.NearPlaneDistance = 0.1;
			camera.FarPlaneDistance = double.PositiveInfinity;
		}
	}

	public static Matrix3D GetViewMatrix(this Camera camera)
	{
		if (camera == null)
		{
			throw new ArgumentNullException("camera");
		}
		if (!(camera is MatrixCamera { ViewMatrix: var viewMatrix }))
		{
			if (camera is ProjectionCamera projectionCamera)
			{
				Vector3D vector3D = -projectionCamera.LookDirection;
				vector3D.Normalize();
				Vector3D vector3D2 = Vector3D.CrossProduct(projectionCamera.UpDirection, vector3D);
				vector3D2.Normalize();
				Vector3D vector = Vector3D.CrossProduct(vector3D, vector3D2);
				Vector3D vector2 = (Vector3D)projectionCamera.Position;
				return new Matrix3D(vector3D2.X, vector.X, vector3D.X, 0.0, vector3D2.Y, vector.Y, vector3D.Y, 0.0, vector3D2.Z, vector.Z, vector3D.Z, 0.0, 0.0 - Vector3D.DotProduct(vector3D2, vector2), 0.0 - Vector3D.DotProduct(vector, vector2), 0.0 - Vector3D.DotProduct(vector3D, vector2), 1.0);
			}
			throw new HelixToolkitException("Unknown camera type.");
		}
		return viewMatrix;
	}

	public static Matrix3D GetProjectionMatrix(this Camera camera, double aspectRatio)
	{
		if (camera == null)
		{
			throw new ArgumentNullException("camera");
		}
		if (camera is PerspectiveCamera perspectiveCamera)
		{
			double num = 1.0 / Math.Tan(Math.PI * perspectiveCamera.FieldOfView / 360.0);
			double m = num * aspectRatio;
			double nearPlaneDistance = perspectiveCamera.NearPlaneDistance;
			double farPlaneDistance = perspectiveCamera.FarPlaneDistance;
			double num2 = (double.IsPositiveInfinity(farPlaneDistance) ? (-1.0) : (farPlaneDistance / (nearPlaneDistance - farPlaneDistance)));
			double offsetZ = nearPlaneDistance * num2;
			return new Matrix3D(num, 0.0, 0.0, 0.0, 0.0, m, 0.0, 0.0, 0.0, 0.0, num2, -1.0, 0.0, 0.0, offsetZ, 0.0);
		}
		if (camera is OrthographicCamera orthographicCamera)
		{
			double num3 = 2.0 / orthographicCamera.Width;
			double m2 = num3 * aspectRatio;
			double nearPlaneDistance2 = orthographicCamera.NearPlaneDistance;
			double num4 = orthographicCamera.FarPlaneDistance;
			if (double.IsPositiveInfinity(num4))
			{
				num4 = nearPlaneDistance2 * 100000.0;
			}
			double num5 = 1.0 / (nearPlaneDistance2 - num4);
			return new Matrix3D(num3, 0.0, 0.0, 0.0, 0.0, m2, 0.0, 0.0, 0.0, 0.0, num5, 0.0, 0.0, 0.0, nearPlaneDistance2 * num5, 1.0);
		}
		if (!(camera is MatrixCamera { ProjectionMatrix: var projectionMatrix }))
		{
			throw new HelixToolkitException("Unknown camera type.");
		}
		return projectionMatrix;
	}

	public static Matrix3D GetTotalTransform(this Camera camera, double aspectRatio)
	{
		Matrix3D identity = Matrix3D.Identity;
		if (camera == null)
		{
			throw new ArgumentNullException("camera");
		}
		if (camera.Transform != null)
		{
			Matrix3D value = camera.Transform.Value;
			if (!value.HasInverse)
			{
				throw new HelixToolkitException("Camera transform has no inverse.");
			}
			value.Invert();
			identity.Append(value);
		}
		identity.Append(camera.GetViewMatrix());
		identity.Append(camera.GetProjectionMatrix(aspectRatio));
		return identity;
	}

	public static Matrix3D GetInverseTransform(this Camera camera, double aspectRatio)
	{
		Matrix3D totalTransform = camera.GetTotalTransform(aspectRatio);
		if (!totalTransform.HasInverse)
		{
			throw new HelixToolkitException("Camera transform has no inverse.");
		}
		totalTransform.Invert();
		return totalTransform;
	}

	public static void FitView(this ProjectionCamera camera, Viewport3D viewport, double animationTime = 0.0)
	{
		if (camera is PerspectiveCamera perspectiveCamera)
		{
			camera.FitView(viewport, perspectiveCamera.LookDirection, perspectiveCamera.UpDirection, animationTime);
		}
		else if (camera is OrthographicCamera orthographicCamera)
		{
			camera.FitView(viewport, orthographicCamera.LookDirection, orthographicCamera.UpDirection, animationTime);
		}
	}

	public static void FitView(this ProjectionCamera camera, Viewport3D viewport, Vector3D lookDirection, Vector3D upDirection, double animationTime = 0.0)
	{
		Rect3D bounds = viewport.Children.FindBounds();
		Vector3D vector3D = new Vector3D(bounds.SizeX, bounds.SizeY, bounds.SizeZ);
		if (!bounds.IsEmpty && !(vector3D.LengthSquared < double.Epsilon))
		{
			camera.FitView(viewport, bounds, lookDirection, upDirection, animationTime);
		}
	}

	public static void ZoomExtents(this ProjectionCamera camera, Viewport3D viewport, double animationTime = 0.0)
	{
		Rect3D bounds = viewport.Children.FindBounds();
		Vector3D vector3D = new Vector3D(bounds.SizeX, bounds.SizeY, bounds.SizeZ);
		if (!bounds.IsEmpty && !(vector3D.LengthSquared < double.Epsilon))
		{
			camera.ZoomExtents(viewport, bounds, animationTime);
		}
	}

	public static void ZoomExtents(this ProjectionCamera camera, Viewport3D viewport, Rect3D bounds, double animationTime = 0.0)
	{
		if (camera is PerspectiveCamera perspectiveCamera)
		{
			camera.FitView(viewport, bounds, perspectiveCamera.LookDirection, perspectiveCamera.UpDirection, animationTime);
		}
		else if (camera is OrthographicCamera orthographicCamera)
		{
			camera.FitView(viewport, bounds, orthographicCamera.LookDirection, orthographicCamera.UpDirection, animationTime);
		}
	}

	public static void FitView(this ProjectionCamera camera, Viewport3D viewport, Rect3D bounds, Vector3D lookDirection, Vector3D upDirection, double animationTime = 0.0)
	{
		Vector3D vector3D = new Vector3D(bounds.SizeX, bounds.SizeY, bounds.SizeZ);
		Point3D center = bounds.Location + vector3D * 0.5;
		double radius = vector3D.Length * 0.5;
		FitView(camera, viewport, center, radius, lookDirection, upDirection, animationTime);
	}

	public static void ZoomExtents(ProjectionCamera camera, Viewport3D viewport, Point3D center, double radius, double animationTime = 0.0)
	{
		if (camera is PerspectiveCamera perspectiveCamera)
		{
			FitView(camera, viewport, center, radius, perspectiveCamera.LookDirection, perspectiveCamera.UpDirection, animationTime);
		}
		else if (camera is OrthographicCamera orthographicCamera)
		{
			FitView(camera, viewport, center, radius, orthographicCamera.LookDirection, orthographicCamera.UpDirection, animationTime);
		}
	}

	public static void FitView(ProjectionCamera camera, Viewport3D viewport, Point3D center, double radius, Vector3D lookDirection, Vector3D upDirection, double animationTime = 0.0)
	{
		if (camera is PerspectiveCamera perspectiveCamera)
		{
			PerspectiveCamera perspectiveCamera2 = perspectiveCamera;
			double val = radius / Math.Tan(0.5 * perspectiveCamera2.FieldOfView * Math.PI / 180.0);
			double num = perspectiveCamera2.FieldOfView;
			if (viewport.ActualWidth > 0.0 && viewport.ActualHeight > 0.0)
			{
				num *= viewport.ActualHeight / viewport.ActualWidth;
			}
			double val2 = radius / Math.Tan(0.5 * num * Math.PI / 180.0);
			double num2 = Math.Max(val, val2);
			Vector3D vector3D = lookDirection;
			vector3D.Normalize();
			perspectiveCamera.LookAt(center, vector3D * num2, upDirection, animationTime);
		}
		else if (camera is OrthographicCamera camera2)
		{
			camera2.LookAt(center, lookDirection, upDirection, animationTime);
			double newWidth = radius * 2.0;
			if (viewport.ActualWidth > viewport.ActualHeight)
			{
				newWidth = radius * 2.0 * viewport.ActualWidth / viewport.ActualHeight;
			}
			camera2.AnimateWidth(newWidth, animationTime);
		}
	}

	public static void ZoomToRectangle(this ProjectionCamera camera, Viewport3D viewport, Rect zoomRectangle)
	{
		Ray3D ray3D = viewport.Point2DtoRay3D(zoomRectangle.TopLeft);
		Ray3D ray3D2 = viewport.Point2DtoRay3D(zoomRectangle.TopRight);
		Ray3D ray3D3 = viewport.Point2DtoRay3D(new Point((zoomRectangle.Left + zoomRectangle.Right) * 0.5, (zoomRectangle.Top + zoomRectangle.Bottom) * 0.5));
		if (ray3D == null || ray3D2 == null || ray3D3 == null)
		{
			return;
		}
		Vector3D direction = ray3D.Direction;
		Vector3D direction2 = ray3D2.Direction;
		Vector3D direction3 = ray3D3.Direction;
		direction.Normalize();
		direction2.Normalize();
		direction3.Normalize();
		if (camera is PerspectiveCamera perspectiveCamera)
		{
			double length = camera.LookDirection.Length;
			double num = length * zoomRectangle.Width / viewport.ActualWidth;
			Vector3D vector3D = num * direction3;
			Point3D point3D = perspectiveCamera.Position + (length - num) * direction3;
			Point3D target = point3D + vector3D;
			camera.LookAt(target, vector3D, 200.0);
		}
		if (camera is OrthographicCamera orthographicCamera)
		{
			orthographicCamera.Width *= zoomRectangle.Width / viewport.ActualWidth;
			Point3D position = camera.Position + camera.LookDirection;
			double length2 = camera.LookDirection.Length;
			if (ray3D3.PlaneIntersection(position, direction3, out var intersection))
			{
				orthographicCamera.LookDirection = direction3 * length2;
				orthographicCamera.Position = intersection - orthographicCamera.LookDirection;
			}
		}
	}
}
