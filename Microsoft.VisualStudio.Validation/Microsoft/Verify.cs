using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Microsoft;

public static class Verify
{
	[DebuggerStepThrough]
	public static void HResult(int hresult, bool ignorePreviousComCalls = false)
	{
		if (hresult < 0)
		{
			if (ignorePreviousComCalls)
			{
				Marshal.ThrowExceptionForHR(hresult, new IntPtr(-1));
			}
			else
			{
				Marshal.ThrowExceptionForHR(hresult);
			}
		}
	}

	[DebuggerStepThrough]
	public static void Operation(bool condition, string message)
	{
		if (!condition)
		{
			throw new InvalidOperationException(message);
		}
	}

	[DebuggerStepThrough]
	public static void Operation(bool condition, string unformattedMessage, object arg1)
	{
		if (!condition)
		{
			throw new InvalidOperationException(PrivateErrorHelpers.Format(unformattedMessage, arg1));
		}
	}

	[DebuggerStepThrough]
	public static void Operation(bool condition, string unformattedMessage, object arg1, object arg2)
	{
		if (!condition)
		{
			throw new InvalidOperationException(PrivateErrorHelpers.Format(unformattedMessage, arg1, arg2));
		}
	}

	[DebuggerStepThrough]
	public static void Operation(bool condition, string unformattedMessage, params object[] args)
	{
		if (!condition)
		{
			throw new InvalidOperationException(PrivateErrorHelpers.Format(unformattedMessage, args));
		}
	}

	[DebuggerStepThrough]
	public static void OperationWithHelp(bool condition, string message, string helpLink)
	{
		if (!condition)
		{
			throw new InvalidOperationException(message)
			{
				HelpLink = helpLink
			};
		}
	}

	[DebuggerStepThrough]
	public static Exception FailOperation(string message, params object[] args)
	{
		throw new InvalidOperationException(PrivateErrorHelpers.Format(message, args));
	}

	[DebuggerStepThrough]
	public static void NotDisposed(IDisposableObservable disposedValue, string message = null)
	{
		Requires.NotNull(disposedValue, "disposedValue");
		if (disposedValue.IsDisposed)
		{
			string objectName = ((disposedValue != null) ? disposedValue.GetType().FullName : string.Empty);
			if (message != null)
			{
				throw new ObjectDisposedException(objectName, message);
			}
			throw new ObjectDisposedException(objectName);
		}
	}

	[DebuggerStepThrough]
	public static void NotDisposed(bool condition, object disposedValue, string message = null)
	{
		if (!condition)
		{
			string objectName = ((disposedValue != null) ? disposedValue.GetType().FullName : string.Empty);
			if (message != null)
			{
				throw new ObjectDisposedException(objectName, message);
			}
			throw new ObjectDisposedException(objectName);
		}
	}

	[DebuggerStepThrough]
	public static void NotDisposed(bool condition, string message)
	{
		if (!condition)
		{
			throw new ObjectDisposedException(message);
		}
	}
}
