using System;
using System.Windows;

namespace HelixToolkit.Wpf;

public class WeakEventListener<TEventManager, TEventArgs> : IWeakEventListener where TEventArgs : EventArgs
{
	private readonly EventHandler<TEventArgs> realHandler;

	public WeakEventListener(EventHandler<TEventArgs> handler)
	{
		realHandler = handler;
	}

	bool IWeakEventListener.ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
	{
		if (managerType == typeof(TEventManager))
		{
			realHandler(sender, e as TEventArgs);
			return true;
		}
		return false;
	}
}
