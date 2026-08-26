using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public abstract class RenderingModelVisual3D : ModelVisual3D
{
	private readonly RenderingEventListener renderingEventListener;

	protected RenderingModelVisual3D()
	{
		renderingEventListener = new RenderingEventListener(OnCompositionTargetRendering);
	}

	protected void SubscribeToRenderingEvent()
	{
		WeakEventManagerBase<RenderingEventManager>.AddListener(renderingEventListener);
	}

	protected void UnsubscribeRenderingEvent()
	{
		WeakEventManagerBase<RenderingEventManager>.RemoveListener(renderingEventListener);
	}

	protected abstract void OnCompositionTargetRendering(object sender, RenderingEventArgs eventArgs);
}
