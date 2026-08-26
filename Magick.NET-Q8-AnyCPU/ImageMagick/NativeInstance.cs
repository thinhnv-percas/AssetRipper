using System;

namespace ImageMagick;

internal abstract class NativeInstance : NativeHelper, INativeInstance, IDisposable
{
	private class ZeroInstance : INativeInstance, IDisposable
	{
		public IntPtr Instance => IntPtr.Zero;

		public void Dispose()
		{
		}
	}

	private IntPtr _instance = IntPtr.Zero;

	public static INativeInstance Zero => new ZeroInstance();

	public IntPtr Instance
	{
		get
		{
			if (_instance == IntPtr.Zero)
			{
				throw new ObjectDisposedException(TypeName);
			}
			return _instance;
		}
		set
		{
			if (_instance != IntPtr.Zero)
			{
				Dispose(_instance);
			}
			_instance = value;
		}
	}

	protected abstract string TypeName { get; }

	public void Dispose()
	{
		Instance = IntPtr.Zero;
		GC.SuppressFinalize(this);
	}

	protected abstract void Dispose(IntPtr instance);

	protected void CheckException(IntPtr exception, IntPtr result)
	{
		MagickException ex = MagickExceptionHelper.Create(exception);
		if (MagickExceptionHelper.IsError(ex))
		{
			if (result != IntPtr.Zero)
			{
				Dispose(result);
			}
			throw ex;
		}
		RaiseWarning(ex);
	}
}
