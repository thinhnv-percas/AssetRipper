using System.Windows.Media;

namespace HelixToolkit.Wpf;

public class RenderingEventManager : WeakEventManagerBase<RenderingEventManager>
{
	protected override void StartListening()
	{
		CompositionTarget.Rendering += base.Handler;
	}

	protected override void StopListening()
	{
		CompositionTarget.Rendering -= base.Handler;
	}
}
