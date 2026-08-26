using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

internal abstract class MouseGestureHandler
{
	public Point3D Origin
	{
		get
		{
			if (MouseDownNearestPoint3D.HasValue)
			{
				return MouseDownNearestPoint3D.Value;
			}
			if (MouseDownPoint3D.HasValue)
			{
				return MouseDownPoint3D.Value;
			}
			return default(Point3D);
		}
	}

	protected ProjectionCamera Camera => Viewport.Camera as ProjectionCamera;

	protected Vector3D CameraLookDirection
	{
		get
		{
			return Controller.CameraLookDirection;
		}
		set
		{
			Controller.CameraLookDirection = value;
		}
	}

	protected CameraMode CameraMode => Controller.CameraMode;

	protected Point3D CameraPosition
	{
		get
		{
			return Controller.CameraPosition;
		}
		set
		{
			Controller.CameraPosition = value;
		}
	}

	protected Point3D CameraTarget => CameraPosition + CameraLookDirection;

	protected Vector3D CameraUpDirection
	{
		get
		{
			return Controller.CameraUpDirection;
		}
		set
		{
			Controller.CameraUpDirection = value;
		}
	}

	protected CameraController Controller { get; set; }

	protected Point LastPoint { get; set; }

	protected Point3D? LastPoint3D { get; set; }

	protected Stopwatch ManipulationWatch { get; set; }

	protected Vector3D ModelUpDirection => Controller.ModelUpDirection;

	protected Point3D? MouseDownNearestPoint3D { get; set; }

	protected Point MouseDownPoint { get; set; }

	protected Point3D? MouseDownPoint3D { get; set; }

	protected double RotationSensitivity => Controller.RotationSensitivity;

	protected Viewport3D Viewport => Controller.Viewport;

	protected double ViewportHeight => Controller.ActualHeight;

	protected double ViewportWidth => Controller.ActualWidth;

	protected double ZoomSensitivity => Controller.ZoomSensitivity;

	protected MouseGestureHandler(CameraController controller)
	{
		Controller = controller;
		ManipulationWatch = new Stopwatch();
	}

	public virtual void Completed(ManipulationEventArgs e)
	{
		long elapsedMilliseconds = ManipulationWatch.ElapsedMilliseconds;
		if (elapsedMilliseconds > 0 && elapsedMilliseconds < Controller.SpinReleaseTime)
		{
			OnInertiaStarting((int)ManipulationWatch.ElapsedMilliseconds);
		}
	}

	public virtual void Delta(ManipulationEventArgs e)
	{
	}

	public void Execute(object sender, ExecutedRoutedEventArgs e)
	{
		if (CanExecute())
		{
			Controller.PushCameraSetting();
			OnMouseDown(sender, null);
			Controller.Focus();
			Controller.CaptureMouse();
			Controller.PushCameraSetting();
			e.Handled = true;
		}
	}

	public virtual void Started(ManipulationEventArgs e)
	{
		SetMouseDownPoint(e.CurrentPosition);
		LastPoint = MouseDownPoint;
		LastPoint3D = MouseDownPoint3D;
		ManipulationWatch.Restart();
	}

	public Point3D? UnProject(Point p, Point3D position, Vector3D normal)
	{
		Ray3D ray = GetRay(p);
		if (ray == null)
		{
			return null;
		}
		Point3D intersection;
		return ray.PlaneIntersection(position, normal, out intersection) ? new Point3D?(intersection) : ((Point3D?)null);
	}

	public Point3D? UnProject(Point p)
	{
		return UnProject(p, CameraTarget, CameraLookDirection);
	}

	protected virtual bool CanExecute()
	{
		return true;
	}

	protected abstract Cursor GetCursor();

	protected Ray3D GetRay(Point position)
	{
		if (!Viewport.Point2DtoPoint3D(position, out var pointNear, out var pointFar))
		{
			return null;
		}
		return new Ray3D
		{
			Origin = pointNear,
			Direction = pointFar - pointNear
		};
	}

	protected virtual void OnInertiaStarting(int elapsedTime)
	{
	}

	protected virtual void OnMouseDown(object sender, MouseButtonEventArgs e)
	{
		Controller.MouseUp += OnMouseUp;
		Controller.MouseMove += OnMouseMove;
		Controller.SetCursor(GetCursor());
		Started(new ManipulationEventArgs(Mouse.GetPosition(Controller)));
	}

	protected virtual void OnMouseMove(object sender, MouseEventArgs e)
	{
		Delta(new ManipulationEventArgs(Mouse.GetPosition(Controller)));
	}

	protected virtual void OnMouseUp(object sender, MouseButtonEventArgs e)
	{
		Controller.MouseMove -= OnMouseMove;
		Controller.MouseUp -= OnMouseUp;
		Controller.ReleaseMouseCapture();
		Controller.RestoreCursor();
		Completed(new ManipulationEventArgs(Mouse.GetPosition(Controller)));
	}

	protected Point Project(Point3D p)
	{
		return Viewport.Point3DtoPoint2D(p);
	}

	private void SetMouseDownPoint(Point position)
	{
		MouseDownPoint = position;
		MouseDownNearestPoint3D = null;
		if (Controller.Viewport.FindNearest(MouseDownPoint, out var point, out var _, out var _))
		{
			MouseDownNearestPoint3D = point;
		}
		else
		{
			Point3D? point3D = Viewport.UnProject(MouseDownPoint);
			if (point3D.HasValue)
			{
				MouseDownNearestPoint3D = point3D.Value;
			}
		}
		MouseDownPoint3D = UnProject(MouseDownPoint);
	}
}
