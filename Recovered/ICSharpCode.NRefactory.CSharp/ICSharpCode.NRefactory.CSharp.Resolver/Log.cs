using System.Collections.Generic;
using System.Diagnostics;

namespace ICSharpCode.NRefactory.CSharp.Resolver
{
	internal static class Log
	{
		private const bool logEnabled = false;

		[Conditional("LOG_DISABLED")]
		internal static void WriteLine(string text)
		{
		}

		[Conditional("LOG_DISABLED")]
		internal static void WriteLine(string format, params object[] args)
		{
		}

		[Conditional("LOG_DISABLED")]
		internal static void WriteCollection<T>(string text, IEnumerable<T> lines)
		{
		}

		[Conditional("LOG_DISABLED")]
		public static void Indent()
		{
		}

		[Conditional("LOG_DISABLED")]
		public static void Unindent()
		{
		}
	}
}
