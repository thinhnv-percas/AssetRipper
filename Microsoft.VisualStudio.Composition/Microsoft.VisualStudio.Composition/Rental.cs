using System;
using System.Collections.Generic;

namespace Microsoft.VisualStudio.Composition;

internal struct Rental<T> : IDisposable where T : class
{
	private T value;

	private Stack<T> returnTo;

	private Action<T> cleanup;

	public T Value => value;

	internal Rental(Stack<T> returnTo, Func<int, T> create, Action<T> cleanup, int createArg)
	{
		value = ((returnTo != null && returnTo.Count > 0) ? returnTo.Pop() : create(createArg));
		this.returnTo = returnTo;
		this.cleanup = cleanup;
	}

	public void Dispose()
	{
		if (value != null)
		{
			T val = value;
			value = null;
			if (cleanup != null)
			{
				cleanup(val);
			}
			if (returnTo != null)
			{
				returnTo.Push(val);
			}
		}
	}
}
