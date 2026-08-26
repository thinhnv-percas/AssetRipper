#define DEBUG
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DecompTools.Decompiler.CSharp.Resolver;

internal static class Log
{
	private const bool logEnabled = false;

	[Conditional("LOG_DISABLED")]
	internal static void WriteLine(string text)
	{
		Debug.WriteLine(text);
	}

	[Conditional("LOG_DISABLED")]
	internal static void WriteLine(string format, params object[] args)
	{
		Debug.WriteLine(format, args);
	}

	[Conditional("LOG_DISABLED")]
	internal static void WriteCollection<T>(string text, IEnumerable<T> lines)
	{
		T[] array = Enumerable.ToArray<T>(lines);
		if (array.Length == 0)
		{
			Debug.WriteLine(text + "<empty collection>");
			return;
		}
		Debug.WriteLine(text + ((array[0] != null) ? array[0].ToString() : "<null>"));
		for (int i = 1; i < array.Length; i = checked(i + 1))
		{
			Debug.WriteLine(new string(' ', text.Length) + ((array[i] != null) ? array[i].ToString() : "<null>"));
		}
	}

	[Conditional("LOG_DISABLED")]
	public static void Indent()
	{
		Debug.Indent();
	}

	[Conditional("LOG_DISABLED")]
	public static void Unindent()
	{
		Debug.Unindent();
	}
}
