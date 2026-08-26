using System;

namespace Mon3;

internal class ArgumentNullOrEmptyException : ArgumentException
{
	public ArgumentNullOrEmptyException(string paramName)
		: base("Argument null or empty", paramName)
	{
	}
}
