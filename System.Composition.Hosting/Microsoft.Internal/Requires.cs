using System;
using System.Diagnostics;
using System.Globalization;

namespace Microsoft.Internal;

internal static class Requires
{
	[DebuggerStepThrough]
	public static void NotNull<T>(T value, string parameterName) where T : class
	{
		if (value == null)
		{
			throw new ArgumentNullException(parameterName);
		}
	}

	[DebuggerStepThrough]
	public static void NotNullOrEmpty(string value, string parameterName)
	{
		NotNull(value, parameterName);
		if (value.Length == 0)
		{
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, CommonStrings.ArgumentException_EmptyString, new object[1] { parameterName }), parameterName);
		}
	}
}
