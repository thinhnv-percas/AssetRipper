using System;

namespace Microsoft;

public static class EventHandlerExtensions
{
	public static void Raise(this Delegate handler, object sender, EventArgs e)
	{
		Requires.NotNull(sender, "sender");
		Requires.NotNull(e, "e");
		handler?.DynamicInvoke(sender, e);
	}

	public static void Raise(this EventHandler handler, object sender, EventArgs e)
	{
		Requires.NotNull(sender, "sender");
		Requires.NotNull(e, "e");
		handler?.Invoke(sender, e);
	}

	public static void Raise<T>(this EventHandler<T> handler, object sender, T e) where T : EventArgs
	{
		Requires.NotNull(sender, "sender");
		Requires.NotNull(e, "e");
		handler?.Invoke(sender, e);
	}
}
