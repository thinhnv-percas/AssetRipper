using System;
using System.Windows.Media;

namespace HelixToolkit.Wpf;

public class RenderingEventListener : WeakEventListener<RenderingEventManager, RenderingEventArgs>
{
	public RenderingEventListener(EventHandler<RenderingEventArgs> handler)
		: base(handler)
	{
	}
}
