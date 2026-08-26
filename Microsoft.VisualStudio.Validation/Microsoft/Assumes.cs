using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime;
using System.Runtime.Serialization;

namespace Microsoft;

public static class Assumes
{
	[Serializable]
	private sealed class InternalErrorException : Exception
	{
		[DebuggerStepThrough]
		public InternalErrorException(string message = null, bool showAssert = true)
			: base(message ?? Strings.InternalExceptionMessage)
		{
			ShowAssertDialog(showAssert);
		}

		[DebuggerStepThrough]
		public InternalErrorException(string message, Exception innerException, bool showAssert = true)
			: base(message ?? Strings.InternalExceptionMessage, innerException)
		{
			ShowAssertDialog(showAssert);
		}

		[DebuggerStepThrough]
		private InternalErrorException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		[DebuggerStepThrough]
		private void ShowAssertDialog(bool showAssert)
		{
			if (showAssert)
			{
				string message = Message;
				if (base.InnerException != null)
				{
					message = message + " " + base.InnerException;
				}
			}
		}
	}

	[DebuggerStepThrough]
	[TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
	public static void NotNull<T>([ValidatedNotNull] T value) where T : class
	{
		True(value != null);
	}

	[DebuggerStepThrough]
	public static void NotNullOrEmpty([ValidatedNotNull] string value)
	{
		NotNull(value);
		True(value.Length > 0);
		True(value[0] != '\0');
	}

	[DebuggerStepThrough]
	public static void NotNullOrEmpty<T>([ValidatedNotNull] ICollection<T> values)
	{
		NotNull(values);
		True(values.Count > 0);
	}

	[DebuggerStepThrough]
	public static void NotNullOrEmpty<T>([ValidatedNotNull] IEnumerable<T> values)
	{
		NotNull(values);
		True(values.Any());
	}

	[DebuggerStepThrough]
	[TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
	public static void Null<T>(T value) where T : class
	{
		True(value == null);
	}

	[DebuggerStepThrough]
	[TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
	public static void Is<T>(object value)
	{
		True(value is T);
	}

	[DebuggerStepThrough]
	[TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
	public static void False(bool condition, [Localizable(false)] string message = null)
	{
		if (condition)
		{
			Fail(message);
		}
	}

	[DebuggerStepThrough]
	[TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
	public static void False(bool condition, [Localizable(false)] string unformattedMessage, object arg1)
	{
		if (condition)
		{
			Fail(Format(unformattedMessage, arg1));
		}
	}

	[DebuggerStepThrough]
	[TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
	public static void False(bool condition, [Localizable(false)] string unformattedMessage, params object[] args)
	{
		if (condition)
		{
			Fail(Format(unformattedMessage, args));
		}
	}

	[DebuggerStepThrough]
	[TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
	public static void True(bool condition, [Localizable(false)] string message = null)
	{
		if (!condition)
		{
			Fail(message);
		}
	}

	[DebuggerStepThrough]
	[TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
	public static void True(bool condition, [Localizable(false)] string unformattedMessage, object arg1)
	{
		if (!condition)
		{
			Fail(Format(unformattedMessage, arg1));
		}
	}

	[DebuggerStepThrough]
	[TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
	public static void True(bool condition, [Localizable(false)] string unformattedMessage, params object[] args)
	{
		if (!condition)
		{
			Fail(Format(unformattedMessage, args));
		}
	}

	[DebuggerStepThrough]
	public static Exception NotReachable()
	{
		InternalErrorException ex = new InternalErrorException();
		if (true)
		{
			throw ex;
		}
		return null;
	}

	[DebuggerStepThrough]
	public static void Present<T>(T component)
	{
		if (component == null)
		{
			Type type = PrivateErrorHelpers.TrimGenericWrapper(typeof(T), typeof(Lazy<>));
			Fail(string.Format(CultureInfo.CurrentCulture, Strings.ServiceMissing, new object[1] { type.FullName }));
		}
	}

	[DebuggerStepThrough]
	public static Exception Fail([Localizable(false)] string message = null, bool showAssert = true)
	{
		InternalErrorException ex = new InternalErrorException(message, showAssert);
		if (true)
		{
			throw ex;
		}
		return null;
	}

	public static Exception Fail([Localizable(false)] string message, Exception innerException, bool showAssert = true)
	{
		InternalErrorException ex = new InternalErrorException(message, innerException, showAssert);
		if (true)
		{
			throw ex;
		}
		return null;
	}

	private static string Format(string format, params object[] arguments)
	{
		return PrivateErrorHelpers.Format(format, arguments);
	}
}
