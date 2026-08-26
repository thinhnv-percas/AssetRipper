using System;

namespace Humanizer;

public class NoMatchFoundException : Exception
{
	public NoMatchFoundException()
	{
	}

	public NoMatchFoundException(string message)
		: base(message)
	{
	}

	public NoMatchFoundException(string message, Exception inner)
		: base(message, inner)
	{
	}
}
