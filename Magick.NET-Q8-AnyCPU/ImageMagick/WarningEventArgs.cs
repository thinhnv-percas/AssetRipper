using System;

namespace ImageMagick;

public sealed class WarningEventArgs : EventArgs
{
	public string Message => Exception.Message;

	public MagickWarningException Exception { get; private set; }

	public WarningEventArgs(MagickWarningException exception)
	{
		Exception = exception;
	}
}
