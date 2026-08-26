using System;
using System.Windows;

namespace HelixToolkit.Wpf;

public abstract class WeakEventManagerBase<TManager> : WeakEventManager where TManager : WeakEventManagerBase<TManager>, new()
{
	private static TManager CurrentManager
	{
		get
		{
			Type typeFromHandle = typeof(TManager);
			TManager val = (TManager)WeakEventManager.GetCurrentManager(typeFromHandle);
			if (val == null)
			{
				val = new TManager();
				WeakEventManager.SetCurrentManager(typeFromHandle, val);
			}
			return val;
		}
	}

	public static void AddListener(IWeakEventListener listener)
	{
		CurrentManager.ProtectedAddListener(null, listener);
	}

	public static void RemoveListener(IWeakEventListener listener)
	{
		CurrentManager.ProtectedRemoveListener(null, listener);
	}

	protected sealed override void StartListening(object source)
	{
		StartListening();
	}

	protected sealed override void StopListening(object source)
	{
		StopListening();
	}

	protected void Handler(object sender, EventArgs e)
	{
		DeliverEvent(null, e);
	}

	protected abstract void StartListening();

	protected abstract void StopListening();
}
