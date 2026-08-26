using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

internal class RotateHandler : MouseGestureHandler
{
	private readonly bool changeLookAt;

	private Vector3D rotationAxisX;

	private Vector3D rotationAxisY;

	private Point rotationPoint;

	private Point3D rotationPoint3D;

	public RotateHandler(CameraController controller, bool changeLookAt = false)
		: base(controller)
	{
		this.changeLookAt = changeLookAt;
	}

	public override void Completed(ManipulationEventArgs e)
	{
		base.Completed(e);
		base.Controller.HideTargetAdorner();
	}

	public override void Delta(ManipulationEventArgs e)
	{
		base.Delta(e);
		Rotate(base.LastPoint, e.CurrentPosition, rotationPoint3D);
		base.LastPoint = e.CurrentPosition;
	}

	public void LookAt(Point3D target, double animationTime)
	{
		if (base.Controller.IsPanEnabled)
		{
			base.Camera.LookAt(target, animationTime);
			base.Controller.OnLookAtChanged();
		}
	}

	public void Rotate(Point p0, Point p1, Point3D rotateAround)
	{
		if (base.Controller.IsRotationEnabled)
		{
			switch (base.Controller.CameraRotationMode)
			{
			case CameraRotationMode.Trackball:
				RotateTrackball(p0, p1, rotateAround);
				break;
			case CameraRotationMode.Turntable:
				RotateTurntable(p1 - p0, rotateAround);
				break;
			case CameraRotationMode.Turnball:
				RotateTurnball(p0, p1, rotateAround);
				break;
			}
			if (Math.Abs(base.Controller.CameraUpDirection.Length - 1.0) > 1E-08)
			{
				base.Controller.CameraUpDirection.Normalize();
			}
		}
	}

	public void Rotate(Vector delta)
	{
		Point lastPoint = base.LastPoint;
		Point p = lastPoint + delta;
		if (base.MouseDownPoint3D.HasValue)
		{
			Rotate(lastPoint, p, base.MouseDownPoint3D.Value);
		}
		base.LastPoint = lastPoint;
	}

	public void RotateTurnball(Point p1, Point p2, Point3D rotateAround)
	{
		InitTurnballRotationAxes(p1);
		Vector vector = p2 - p1;
		Vector3D vector2 = rotateAround - base.CameraTarget;
		Vector3D vector3 = rotateAround - base.CameraPosition;
		double num = -1.0;
		if (base.CameraMode != CameraMode.Inspect)
		{
			num = 0.2;
		}
		num *= base.RotationSensitivity;
		Quaternion quaternion = new Quaternion(rotationAxisX, num * vector.X);
		Quaternion quaternion2 = new Quaternion(rotationAxisY, num * vector.Y);
		Quaternion quaternion3 = quaternion * quaternion2;
		Matrix3D matrix3D = default(Matrix3D);
		matrix3D.Rotate(quaternion3);
		Vector3D vector3D = matrix3D.Transform(base.CameraLookDirection);
		Vector3D vector3D2 = matrix3D.Transform(base.CameraUpDirection);
		Vector3D vector3D3 = matrix3D.Transform(vector2);
		Vector3D vector3D4 = matrix3D.Transform(vector3);
		Vector3D vector4 = Vector3D.CrossProduct(vector3D, vector3D2);
		vector4.Normalize();
		Vector3D vector3D5 = Vector3D.CrossProduct(vector4, vector3D);
		vector3D5.Normalize();
		if ((vector3D2 - vector3D5).Length > 1E-08)
		{
			vector3D2 = vector3D5;
		}
		Point3D point3D = rotateAround - vector3D3;
		Point3D point3D2 = rotateAround - vector3D4;
		Vector3D cameraLookDirection = point3D - point3D2;
		base.CameraLookDirection = cameraLookDirection;
		if (base.CameraMode == CameraMode.Inspect)
		{
			base.CameraPosition = point3D2;
		}
		base.CameraUpDirection = vector3D2;
	}

	public void RotateTurntable(Vector delta, Point3D rotateAround)
	{
		Vector3D vector = rotateAround - base.CameraTarget;
		Vector3D vector2 = rotateAround - base.CameraPosition;
		Vector3D modelUpDirection = base.ModelUpDirection;
		Vector3D cameraLookDirection = base.CameraLookDirection;
		cameraLookDirection.Normalize();
		Vector3D axisOfRotation = Vector3D.CrossProduct(cameraLookDirection, base.CameraUpDirection);
		axisOfRotation.Normalize();
		double num = -0.5;
		if (base.CameraMode != CameraMode.Inspect)
		{
			num *= -0.2;
		}
		num *= base.RotationSensitivity;
		Quaternion quaternion = new Quaternion(modelUpDirection, num * delta.X);
		Quaternion quaternion2 = new Quaternion(axisOfRotation, num * delta.Y);
		Quaternion quaternion3 = quaternion * quaternion2;
		Matrix3D matrix3D = default(Matrix3D);
		matrix3D.Rotate(quaternion3);
		Vector3D cameraUpDirection = matrix3D.Transform(base.CameraUpDirection);
		Vector3D vector3D = matrix3D.Transform(vector);
		Vector3D vector3D2 = matrix3D.Transform(vector2);
		Point3D point3D = rotateAround - vector3D;
		Point3D point3D2 = rotateAround - vector3D2;
		base.CameraLookDirection = point3D - point3D2;
		if (base.CameraMode == CameraMode.Inspect)
		{
			base.CameraPosition = point3D2;
		}
		base.CameraUpDirection = cameraUpDirection;
	}

	public override void Started(ManipulationEventArgs e)
	{
		base.Started(e);
		rotationPoint = new Point(base.Controller.Viewport.ActualWidth / 2.0, base.Controller.Viewport.ActualHeight / 2.0);
		rotationPoint3D = base.Controller.CameraTarget;
		CameraMode cameraMode = base.Controller.CameraMode;
		if (cameraMode == CameraMode.WalkAround)
		{
			rotationPoint = base.MouseDownPoint;
			rotationPoint3D = base.Controller.CameraPosition;
		}
		else if (changeLookAt && base.MouseDownNearestPoint3D.HasValue)
		{
			LookAt(base.MouseDownNearestPoint3D.Value, 0.0);
			rotationPoint3D = base.Controller.CameraTarget;
		}
		else if (base.Controller.RotateAroundMouseDownPoint && base.MouseDownNearestPoint3D.HasValue)
		{
			rotationPoint = base.MouseDownPoint;
			rotationPoint3D = base.MouseDownNearestPoint3D.Value;
		}
		if (base.Controller.CameraMode == CameraMode.Inspect)
		{
			base.Controller.ShowTargetAdorner(rotationPoint);
		}
		switch (base.Controller.CameraRotationMode)
		{
		case CameraRotationMode.Turnball:
			InitTurnballRotationAxes(e.CurrentPosition);
			break;
		}
		base.Controller.StopSpin();
	}

	protected override bool CanExecute()
	{
		if (changeLookAt)
		{
			return base.Controller.CameraMode != CameraMode.FixedPosition && base.Controller.IsPanEnabled;
		}
		return base.Controller.IsRotationEnabled;
	}

	protected override Cursor GetCursor()
	{
		return base.Controller.RotateCursor;
	}

	protected override void OnInertiaStarting(int elapsedTime)
	{
		Vector vector = base.LastPoint - base.MouseDownPoint;
		base.Controller.StartSpin(4.0 * vector * ((double)base.Controller.SpinReleaseTime / (double)elapsedTime), base.MouseDownPoint, rotationPoint3D);
	}

	private static Vector3D ProjectToTrackball(Point point, double w, double h)
	{
		double num = Math.Sqrt(w * w + h * h) / 2.0;
		double num2 = (point.X - w / 2.0) / num;
		double num3 = (h / 2.0 - point.Y) / num;
		double num4 = 1.0 - num2 * num2 - num3 * num3;
		double z = ((num4 > 0.0) ? Math.Sqrt(num4) : 0.0);
		return new Vector3D(num2, num3, z);
	}

	private void InitTurnballRotationAxes(Point p1)
	{
		double num = p1.X / base.ViewportWidth;
		double num2 = p1.Y / base.ViewportHeight;
		Vector3D cameraUpDirection = base.CameraUpDirection;
		Vector3D cameraLookDirection = base.CameraLookDirection;
		cameraLookDirection.Normalize();
		Vector3D vector3D = Vector3D.CrossProduct(cameraLookDirection, base.CameraUpDirection);
		vector3D.Normalize();
		rotationAxisX = cameraUpDirection;
		rotationAxisY = vector3D;
		if (num2 > 0.8 || num2 < 0.2)
		{
		}
		if (num > 0.8)
		{
			rotationAxisY = cameraLookDirection;
		}
		if (num < 0.2)
		{
			rotationAxisY = -cameraLookDirection;
		}
	}

	private void RotateAroundUpAndRight(Point p1, Point p2, Point3D rotateAround)
	{
		Vector vector = p2 - p1;
		Quaternion quaternion = new Quaternion(base.CameraUpDirection, (0.0 - vector.X) * base.RotationSensitivity);
		Quaternion quaternion2 = new Quaternion(Vector3D.CrossProduct(base.CameraUpDirection, base.CameraLookDirection), vector.Y * base.RotationSensitivity);
		Quaternion quaternion3 = quaternion * quaternion2;
		RotateTransform3D rotateTransform3D = new RotateTransform3D(new QuaternionRotation3D(quaternion3));
		Vector3D vector2 = rotateAround - base.CameraTarget;
		Vector3D vector3 = rotateAround - base.CameraPosition;
		Vector3D vector3D = rotateTransform3D.Transform(vector2);
		Vector3D vector3D2 = rotateTransform3D.Transform(vector3);
		Vector3D cameraUpDirection = rotateTransform3D.Transform(base.CameraUpDirection);
		Point3D point3D = rotateAround - vector3D;
		Point3D point3D2 = rotateAround - vector3D2;
		base.CameraLookDirection = point3D - point3D2;
		if (base.CameraMode == CameraMode.Inspect)
		{
			base.CameraPosition = point3D2;
		}
		base.CameraUpDirection = cameraUpDirection;
	}

	private void RotateTrackball(Point p1, Point p2, Point3D rotateAround)
	{
		Vector3D vector3D = ProjectToTrackball(p1, base.ViewportWidth, base.ViewportHeight);
		Vector3D vector3D2 = ProjectToTrackball(p2, base.ViewportWidth, base.ViewportHeight);
		Vector3D cameraLookDirection = base.CameraLookDirection;
		Vector3D vector3D3 = Vector3D.CrossProduct(base.CameraUpDirection, cameraLookDirection);
		Vector3D vector3D4 = Vector3D.CrossProduct(vector3D3, cameraLookDirection);
		vector3D3.Normalize();
		vector3D4.Normalize();
		cameraLookDirection.Normalize();
		Vector3D vector = cameraLookDirection * vector3D.Z + vector3D3 * vector3D.X + vector3D4 * vector3D.Y;
		Vector3D vector2 = cameraLookDirection * vector3D2.Z + vector3D3 * vector3D2.X + vector3D4 * vector3D2.Y;
		Vector3D axisOfRotation = Vector3D.CrossProduct(vector, vector2);
		if (!(axisOfRotation.LengthSquared < 1E-08))
		{
			double num = Vector3D.AngleBetween(vector, vector2);
			Quaternion quaternion = new Quaternion(axisOfRotation, (0.0 - num) * base.RotationSensitivity * 5.0);
			RotateTransform3D rotateTransform3D = new RotateTransform3D(new QuaternionRotation3D(quaternion));
			Vector3D vector3 = rotateAround - base.CameraTarget;
			Vector3D vector4 = rotateAround - base.CameraPosition;
			Vector3D vector3D5 = rotateTransform3D.Transform(vector3);
			Vector3D vector3D6 = rotateTransform3D.Transform(vector4);
			Vector3D cameraUpDirection = rotateTransform3D.Transform(base.CameraUpDirection);
			Point3D point3D = rotateAround - vector3D5;
			Point3D point3D2 = rotateAround - vector3D6;
			base.CameraLookDirection = point3D - point3D2;
			if (base.CameraMode == CameraMode.Inspect)
			{
				base.CameraPosition = point3D2;
			}
			base.CameraUpDirection = cameraUpDirection;
		}
	}
}
