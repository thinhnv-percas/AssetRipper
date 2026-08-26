using System;

namespace ImageMagick;

internal abstract class NativeHelper
{
	private EventHandler<WarningEventArgs> _warningEvent;

	public event EventHandler<WarningEventArgs> Warning
	{
		add
		{
			_warningEvent = (EventHandler<WarningEventArgs>)Delegate.Combine(_warningEvent, value);
		}
		remove
		{
			_warningEvent = (EventHandler<WarningEventArgs>)Delegate.Remove(_warningEvent, value);
		}
	}

	protected void CheckException(IntPtr exception)
	{
		MagickException exception2 = MagickExceptionHelper.Check(exception);
		RaiseWarning(exception2);
	}

	protected void RaiseWarning(MagickException exception)
	{
		if (_warningEvent != null && exception is MagickWarningException exception2)
		{
			_warningEvent(this, new WarningEventArgs(exception2));
		}
	}
}
