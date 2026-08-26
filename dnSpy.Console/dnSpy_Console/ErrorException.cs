using System;

namespace dnSpy_Console;

[Serializable]
internal sealed class ErrorException : Exception
{
	public ErrorException(string s)
		: base(s)
	{
	}
}
