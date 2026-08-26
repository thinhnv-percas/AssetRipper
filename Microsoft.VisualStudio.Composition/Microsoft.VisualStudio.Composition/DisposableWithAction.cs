using System;

namespace Microsoft.VisualStudio.Composition;

internal class DisposableWithAction : IDisposable
{
	private readonly Action action;

	internal DisposableWithAction(Action action)
	{
		this.action = action;
	}

	public void Dispose()
	{
		if (action != null)
		{
			action();
		}
	}
}
