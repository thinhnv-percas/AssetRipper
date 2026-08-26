using System;
using System.Diagnostics;

namespace ImageMagick;

internal static class DebugThrow
{
	[Conditional("DEBUG")]
	public static void IfNull(IntPtr value)
	{
		if (value == IntPtr.Zero)
		{
			throw new InvalidOperationException("Value should not be null.");
		}
	}

	[Conditional("DEBUG")]
	public static void IfNull(object value)
	{
		if (value == null)
		{
			throw new InvalidOperationException("Value should not be null.");
		}
	}

	[Conditional("DEBUG")]
	public static void IfNull(string paramName, object value)
	{
		Throw.IfNull(paramName, value);
	}
}
