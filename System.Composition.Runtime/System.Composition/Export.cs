namespace System.Composition;

public sealed class Export<T> : IDisposable
{
	private readonly T _value;

	private readonly Action _disposeAction;

	public T Value => _value;

	public Export(T value, Action disposeAction)
	{
		_value = value;
		_disposeAction = disposeAction;
	}

	public void Dispose()
	{
		if (_disposeAction != null)
		{
			_disposeAction();
		}
	}
}
