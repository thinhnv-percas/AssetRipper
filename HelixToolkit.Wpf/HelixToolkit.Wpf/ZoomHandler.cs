using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

internal class ZoomHandler : MouseGestureHandler
{
	private readonly bool changeFieldOfView;

	private Point zoomPoint;

	private Point3D zoomPoint3D;

	public ZoomHandler(CameraController controller, bool changeFieldOfView = false)
		: base(controller)
	{
		this.changeFieldOfView = changeFieldOfView;
	}

	public void ZoomByChangingCameraPosition(double delta, Point3D zoomAround)
	{
		if (delta < -0.5)
		{
			delta = -0.5;
		}
		delta *= base.ZoomSensitivity;
		switch (base.CameraMode)
		{
		case CameraMode.Inspect:
			ChangeCameraDistance(delta, zoomAround);
			break;
		case CameraMode.WalkAround:
			base.CameraPosition -= base.CameraLookDirection * delta;
			break;
		}
	}

	public void MoveCameraPosition(Vector3D delta)
	{
		Vector3D cameraLookDirection = base.CameraLookDirection;
		cameraLookDirection.Normalize();
		Vector3D vector = Vector3D.CrossProduct(base.CameraLookDirection, base.CameraUpDirection);
		Vector3D vector3D = Vector3D.CrossProduct(vector, cameraLookDirection);
		vector3D.Normalize();
		vector = Vector3D.CrossProduct(cameraLookDirection, vector3D);
		CameraMode cameraMode = base.CameraMode;
		if (cameraMode == CameraMode.Inspect || cameraMode == CameraMode.WalkAround)
		{
			base.CameraPosition += vector * delta.X + vector3D * delta.Y + cameraLookDirection * delta.Z;
		}
	}

	public void ZoomByChangingCameraWidth(double delta, Point3D zoomAround)
	{
		if (delta < -0.5)
		{
			delta = -0.5;
		}
		switch (base.CameraMode)
		{
		case CameraMode.Inspect:
		case CameraMode.WalkAround:
		case CameraMode.FixedPosition:
			ChangeCameraDistance(delta, zoomAround);
			if (base.Camera is OrthographicCamera orthographicCamera)
			{
				orthographicCamera.Width *= 1.0 + delta;
			}
			break;
		}
	}

	public void ZoomByChangingFieldOfView(double delta)
	{
		if (base.Camera is PerspectiveCamera perspectiveCamera && base.Controller.IsChangeFieldOfViewEnabled)
		{
			double fieldOfView = perspectiveCamera.FieldOfView;
			double length = base.CameraLookDirection.Length;
			double num = length * Math.Tan(0.5 * fieldOfView / 180.0 * Math.PI);
			fieldOfView *= 1.0 + delta * 0.5;
			if (fieldOfView < base.Controller.MinimumFieldOfView)
			{
				fieldOfView = base.Controller.MinimumFieldOfView;
			}
			if (fieldOfView > base.Controller.MaximumFieldOfView)
			{
				fieldOfView = base.Controller.MaximumFieldOfView;
			}
			perspectiveCamera.FieldOfView = fieldOfView;
			double num2 = num / Math.Tan(0.5 * fieldOfView / 180.0 * Math.PI);
			Vector3D cameraLookDirection = base.CameraLookDirection;
			cameraLookDirection.Normalize();
			cameraLookDirection *= num2;
			Point3D point3D = base.CameraPosition + base.CameraLookDirection;
			base.CameraPosition = point3D - cameraLookDirection;
			base.CameraLookDirection = cameraLookDirection;
		}
	}

	public override void Completed(ManipulationEventArgs e)
	{
		base.Completed(e);
		base.Controller.HideTargetAdorner();
	}

	public override void Delta(ManipulationEventArgs e)
	{
		Vector vector = e.CurrentPosition - base.LastPoint;
		base.LastPoint = e.CurrentPosition;
		Zoom(vector.Y * 0.01, zoomPoint3D);
	}

	public override void Started(ManipulationEventArgs e)
	{
		base.Started(e);
		zoomPoint = new Point(base.Controller.Viewport.ActualWidth / 2.0, base.Controller.Viewport.ActualHeight / 2.0);
		zoomPoint3D = base.Controller.CameraTarget;
		if (base.Controller.ZoomAroundMouseDownPoint && base.MouseDownNearestPoint3D.HasValue)
		{
			zoomPoint = base.MouseDownPoint;
			zoomPoint3D = base.MouseDownNearestPoint3D.Value;
		}
		if (!changeFieldOfView)
		{
			base.Controller.ShowTargetAdorner(zoomPoint);
		}
	}

	public void Zoom(double delta)
	{
		Zoom(delta, base.CameraTarget);
	}

	public void Zoom(double delta, Point3D zoomAround)
	{
		if (!base.Controller.IsZoomEnabled)
		{
			return;
		}
		if (base.Camera is PerspectiveCamera)
		{
			if (base.CameraMode == CameraMode.FixedPosition || changeFieldOfView)
			{
				ZoomByChangingFieldOfView(delta);
			}
			else
			{
				ZoomByChangingCameraPosition(delta, zoomAround);
			}
		}
		else if (base.Camera is OrthographicCamera)
		{
			ZoomByChangingCameraWidth(delta, zoomAround);
		}
	}

	protected override bool CanExecute()
	{
		if (changeFieldOfView)
		{
			return base.Controller.IsChangeFieldOfViewEnabled && base.Controller.ActualCamera is PerspectiveCamera;
		}
		return base.Controller.IsZoomEnabled;
	}

	protected override Cursor GetCursor()
	{
		return base.Controller.ZoomCursor;
	}

	private void ChangeCameraDistance(double delta, Point3D zoomAround)
	{
		Point3D point3D = base.CameraPosition + base.CameraLookDirection;
		Vector3D vector3D = zoomAround - point3D;
		Vector3D vector3D2 = zoomAround - base.CameraPosition;
		double num = Math.Pow(2.5, delta);
		Vector3D vector3D3 = vector3D2 * num;
		Vector3D vector3D4 = vector3D * num;
		Point3D point3D2 = zoomAround - vector3D4;
		Point3D point3D3 = zoomAround - vector3D3;
		Vector3D cameraLookDirection = point3D2 - point3D3;
		base.CameraLookDirection = cameraLookDirection;
		base.CameraPosition = point3D3;
	}
}
