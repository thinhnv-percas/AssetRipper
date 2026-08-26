using System;

namespace Microsoft;

public interface IDisposableObservable : IDisposable
{
	bool IsDisposed { get; }
}
