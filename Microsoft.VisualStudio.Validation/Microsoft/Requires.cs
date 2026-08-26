using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime;
using System.Threading.Tasks;

namespace Microsoft;

public static class Requires
{
	[DebuggerStepThrough]
	[TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
	public static T NotNull<T>([ValidatedNotNull] T value, string parameterName) where T : class
	{
		if (value == null)
		{
			throw new ArgumentNullException(parameterName);
		}
		return value;
	}

	[DebuggerStepThrough]
	[TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
	public static IntPtr NotNull(IntPtr value, string parameterName)
	{
		if (value == IntPtr.Zero)
		{
			throw new ArgumentNullException(parameterName);
		}
		return value;
	}

	[DebuggerStepThrough]
	[TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
	public static void NotNull([ValidatedNotNull] Task value, string parameterName)
	{
		if (value == null)
		{
			throw new ArgumentNullException(parameterName);
		}
	}

	[DebuggerStepThrough]
	[TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
	public static void NotNull<T>([ValidatedNotNull] Task<T> value, string parameterName)
	{
		if (value == null)
		{
			throw new ArgumentNullException(parameterName);
		}
	}

	[DebuggerStepThrough]
	public static T NotNullAllowStructs<T>([ValidatedNotNull] T value, string parameterName)
	{
		if (value == null)
		{
			throw new ArgumentNullException(parameterName);
		}
		return value;
	}

	[DebuggerStepThrough]
	public static void NotNullOrEmpty([ValidatedNotNull] string value, string parameterName)
	{
		if (value == null)
		{
			throw new ArgumentNullException(parameterName);
		}
		if (value.Length == 0 || value[0] == '\0')
		{
			throw new ArgumentException(Format(Strings.Argument_EmptyString, parameterName), parameterName);
		}
	}

	[DebuggerStepThrough]
	public static void NotNullOrWhiteSpace([ValidatedNotNull] string value, string parameterName)
	{
		if (value == null)
		{
			throw new ArgumentNullException(parameterName);
		}
		if (value.Length == 0 || value[0] == '\0')
		{
			throw new ArgumentException(Format(Strings.Argument_EmptyString, parameterName), parameterName);
		}
		if (string.IsNullOrWhiteSpace(value))
		{
			throw new ArgumentException(Format(Strings.Argument_Whitespace, parameterName));
		}
	}

	[DebuggerStepThrough]
	public static void NotNullOrEmpty([ValidatedNotNull] IEnumerable values, string parameterName)
	{
		if (values == null)
		{
			throw new ArgumentNullException(parameterName);
		}
		bool flag = false;
		IEnumerator enumerator = values.GetEnumerator();
		try
		{
			if (enumerator.MoveNext())
			{
				_ = enumerator.Current;
				flag = true;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		if (!flag)
		{
			throw new ArgumentException(Format(Strings.Argument_EmptyArray, parameterName), parameterName);
		}
	}

	[DebuggerStepThrough]
	public static void NotNullEmptyOrNullElements<T>([ValidatedNotNull] IEnumerable<T> values, string parameterName) where T : class
	{
		NotNull(values, parameterName);
		bool flag = false;
		foreach (T value in values)
		{
			flag = true;
			if (value == null)
			{
				throw new ArgumentException(Format(Strings.Argument_NullElement, parameterName), parameterName);
			}
		}
		if (!flag)
		{
			throw new ArgumentException(Format(Strings.Argument_EmptyArray, parameterName), parameterName);
		}
	}

	[DebuggerStepThrough]
	public static void NullOrNotNullElements<T>(IEnumerable<T> values, string parameterName)
	{
		if (values == null)
		{
			return;
		}
		foreach (T value in values)
		{
			if (value == null)
			{
				throw new ArgumentException(Format(Strings.Argument_NullElement, parameterName), parameterName);
			}
		}
	}

	[DebuggerStepThrough]
	public static void NotEmpty(Guid value, string parameterName)
	{
		if (value == Guid.Empty)
		{
			throw new ArgumentException(Format(Strings.Argument_EmptyGuid, parameterName), parameterName);
		}
	}

	[DebuggerStepThrough]
	public static void Range(bool condition, string parameterName, string message = null)
	{
		if (!condition)
		{
			FailRange(parameterName, message);
		}
	}

	[DebuggerStepThrough]
	public static Exception FailRange(string parameterName, string message = null)
	{
		if (string.IsNullOrEmpty(message))
		{
			throw new ArgumentOutOfRangeException(parameterName);
		}
		throw new ArgumentOutOfRangeException(parameterName, message);
	}

	[DebuggerStepThrough]
	public static void Argument(bool condition, string parameterName, string message)
	{
		if (!condition)
		{
			throw new ArgumentException(message, parameterName);
		}
	}

	[DebuggerStepThrough]
	public static void Argument(bool condition, string parameterName, string message, object arg1)
	{
		if (!condition)
		{
			throw new ArgumentException(Format(message, arg1), parameterName);
		}
	}

	[DebuggerStepThrough]
	public static void Argument(bool condition, string parameterName, string message, object arg1, object arg2)
	{
		if (!condition)
		{
			throw new ArgumentException(Format(message, arg1, arg2), parameterName);
		}
	}

	[DebuggerStepThrough]
	public static void Argument(bool condition, string parameterName, string message, params object[] args)
	{
		if (!condition)
		{
			throw new ArgumentException(Format(message, args), parameterName);
		}
	}

	[DebuggerStepThrough]
	public static Exception Fail(string message)
	{
		throw new ArgumentException(message);
	}

	[DebuggerStepThrough]
	public static Exception Fail(string unformattedMessage, params object[] args)
	{
		throw Fail(Format(unformattedMessage, args));
	}

	[DebuggerStepThrough]
	public static Exception Fail(Exception innerException, string unformattedMessage, params object[] args)
	{
		throw new ArgumentException(Format(unformattedMessage, args), innerException);
	}

	private static string Format(string format, params object[] arguments)
	{
		return PrivateErrorHelpers.Format(format, arguments);
	}
}
