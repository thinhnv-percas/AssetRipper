using System;

namespace ImageMagick;

public sealed class LogEventArgs : EventArgs
{
	public LogEvents EventType { get; private set; }

	public string Message { get; private set; }

	internal LogEventArgs(LogEvents eventType, string message)
	{
		EventType = eventType;
		Message = message;
	}
}
