using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

internal class PanHandler : MouseGestureHandler
{
	private Point3D panPoint3D;

	public PanHandler(CameraController controller)
		: base(controller)
	{
	}

	public override void Delta(ManipulationEventArgs e)
	{
		base.Delta(e);
		Point3D? point3D = UnProject(e.CurrentPosition, panPoint3D, base.Controller.CameraLookDirection);
		if (base.LastPoint3D.HasValue && point3D.HasValue)
		{
			Vector3D delta = base.LastPoint3D.Value - point3D.Value;
			Pan(delta);
			base.LastPoint = e.CurrentPosition;
			base.LastPoint3D = UnProject(e.CurrentPosition, panPoint3D, base.Controller.CameraLookDirection);
		}
	}

	public void Pan(Vector3D delta)
	{
		if (base.Controller.IsPanEnabled && base.CameraMode != CameraMode.FixedPosition)
		{
			base.CameraPosition += delta;
		}
	}

	public void Pan(Vector delta)
	{
		Point point = base.LastPoint + delta;
		Point3D? point3D = UnProject(point, panPoint3D, base.Controller.CameraLookDirection);
		if (base.LastPoint3D.HasValue && point3D.HasValue)
		{
			Vector3D delta2 = base.LastPoint3D.Value - point3D.Value;
			Pan(delta2);
			base.LastPoint3D = UnProject(point, panPoint3D, base.Controller.CameraLookDirection);
			base.LastPoint = point;
		}
	}

	public override void Started(ManipulationEventArgs e)
	{
		base.Started(e);
		panPoint3D = base.Controller.CameraTarget;
		if (base.MouseDownNearestPoint3D.HasValue)
		{
			panPoint3D = base.MouseDownNearestPoint3D.Value;
		}
		base.LastPoint3D = UnProject(base.MouseDownPoint, panPoint3D, base.Controller.CameraLookDirection);
	}

	protected override bool CanExecute()
	{
		return base.Controller.IsPanEnabled && base.Controller.CameraMode != CameraMode.FixedPosition;
	}

	protected override Cursor GetCursor()
	{
		return base.Controller.PanCursor;
	}

	protected override void OnInertiaStarting(int elapsedTime)
	{
		Vector vector = (base.LastPoint - base.MouseDownPoint) * (40.0 / (double)elapsedTime);
		base.Controller.AddPanForce(vector.X, vector.Y);
	}
}
