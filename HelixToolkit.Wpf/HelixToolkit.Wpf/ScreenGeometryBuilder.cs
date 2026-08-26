using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public abstract class ScreenGeometryBuilder
{
	protected readonly Visual3D visual;

	protected Matrix3D screenToVisual;

	protected Matrix3D visualToScreen;

	protected Matrix3D visualToProjection;

	protected Matrix3D projectionToScreen;

	private Viewport3D viewport;

	protected ScreenGeometryBuilder(Visual3D visual)
	{
		this.visual = visual;
	}

	public bool UpdateTransforms()
	{
		Matrix3D viewportTransform = visual.GetViewportTransform();
		if (double.IsNaN(viewportTransform.M11))
		{
			return false;
		}
		if (!viewportTransform.HasInverse)
		{
			return false;
		}
		if (viewportTransform == visualToScreen)
		{
			return false;
		}
		if (viewport == null)
		{
			viewport = visual.GetViewport3D();
		}
		Matrix3D m = viewport.GetProjectionMatrix() * viewport.GetViewportTransform();
		if (!m.HasInverse)
		{
			return false;
		}
		Matrix3D matrix3D = viewportTransform * m.Inverse();
		visualToScreen = viewportTransform;
		screenToVisual = viewportTransform.Inverse();
		projectionToScreen = m;
		visualToProjection = matrix3D;
		return true;
	}
}
