using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace HelixToolkit.Wpf;

internal class ZoomRectangleHandler : MouseGestureHandler
{
	private Rect zoomRectangle;

	public ZoomRectangleHandler(CameraController controller)
		: base(controller)
	{
	}

	public override void Completed(ManipulationEventArgs e)
	{
		base.Completed(e);
		base.Controller.HideRectangle();
		ZoomRectangle(zoomRectangle);
	}

	public override void Delta(ManipulationEventArgs e)
	{
		base.Delta(e);
		double num = base.Controller.ActualHeight / base.Controller.ActualWidth;
		Vector vector = base.MouseDownPoint - e.CurrentPosition;
		if (Math.Abs(vector.Y / vector.X) < num)
		{
			vector.Y = (double)Math.Sign(vector.Y) * Math.Abs(vector.X * num);
		}
		else
		{
			vector.X = (double)Math.Sign(vector.X) * Math.Abs(vector.Y / num);
		}
		zoomRectangle = new Rect(base.MouseDownPoint, base.MouseDownPoint - vector);
		base.Controller.UpdateRectangle(zoomRectangle);
	}

	public override void Started(ManipulationEventArgs e)
	{
		base.Started(e);
		zoomRectangle = new Rect(base.MouseDownPoint, base.MouseDownPoint);
		base.Controller.ShowRectangle(zoomRectangle, Colors.LightGray, Colors.Black);
	}

	public void ZoomRectangle(Rect rectangle)
	{
		if (base.Controller.IsZoomEnabled && !(rectangle.Width < 10.0) && !(rectangle.Height < 10.0))
		{
			base.Camera.ZoomToRectangle(base.Viewport, rectangle);
			base.Controller.OnZoomedByRectangle();
		}
	}

	protected override bool CanExecute()
	{
		return base.Controller.IsZoomEnabled;
	}

	protected override Cursor GetCursor()
	{
		return base.Controller.ZoomRectangleCursor;
	}
}
