#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Microsoft;

public static class Report
{
	[Conditional("DEBUG")]
	public static void IfNotPresent<T>(T part)
	{
		if (part == null)
		{
			Type type = PrivateErrorHelpers.TrimGenericWrapper(typeof(T), typeof(Lazy<>));
			if (Environment.GetEnvironmentVariable("CPSUnitTest") != "true")
			{
				Fail(Strings.ServiceMissing, type.FullName);
			}
		}
	}

	[Conditional("DEBUG")]
	public static void If(bool condition, [Localizable(false)] string message = null)
	{
		if (condition)
		{
			Fail(message);
		}
	}

	[Conditional("DEBUG")]
	public static void IfNot(bool condition, [Localizable(false)] string message = null)
	{
		if (!condition)
		{
			Fail(message);
		}
	}

	[Conditional("DEBUG")]
	public static void IfNot(bool condition, [Localizable(false)] string message, object arg1)
	{
		if (!condition)
		{
			Fail(PrivateErrorHelpers.Format(message, arg1));
		}
	}

	[Conditional("DEBUG")]
	public static void IfNot(bool condition, [Localizable(false)] string message, object arg1, object arg2)
	{
		if (!condition)
		{
			Fail(PrivateErrorHelpers.Format(message, arg1, arg2));
		}
	}

	[Conditional("DEBUG")]
	public static void IfNot(bool condition, [Localizable(false)] string message, params object[] args)
	{
		if (!condition)
		{
			Fail(PrivateErrorHelpers.Format(message, args));
		}
	}

	[Conditional("DEBUG")]
	public static void Fail([Localizable(false)] string message = null)
	{
		if (message == null)
		{
			message = "A recoverable error has been detected.";
		}
		Debug.WriteLine(message);
		Debug.Assert(condition: false, message);
	}

	[Conditional("DEBUG")]
	public static void Fail([Localizable(false)] string message, params object[] args)
	{
		Fail(PrivateErrorHelpers.Format(message, args));
	}
}
