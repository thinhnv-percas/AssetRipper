using Microsoft.Internal;

namespace Microsoft.Composition.Diagnostics;

internal static class CompositionTraceSource
{
	private static readonly DebuggerTraceWriter s_source = new DebuggerTraceWriter();

	public static bool CanWriteInformation => s_source.CanWriteInformation;

	public static bool CanWriteWarning => s_source.CanWriteWarning;

	public static bool CanWriteError => s_source.CanWriteError;

	public static void WriteInformation(CompositionTraceId traceId, string format, params object[] arguments)
	{
		EnsureEnabled(CanWriteInformation);
		s_source.WriteInformation(traceId, format, arguments);
	}

	public static void WriteWarning(CompositionTraceId traceId, string format, params object[] arguments)
	{
		EnsureEnabled(CanWriteWarning);
		s_source.WriteWarning(traceId, format, arguments);
	}

	public static void WriteError(CompositionTraceId traceId, string format, params object[] arguments)
	{
		EnsureEnabled(CanWriteError);
		s_source.WriteError(traceId, format, arguments);
	}

	private static void EnsureEnabled(bool condition)
	{
		Microsoft.Internal.Assumes.IsTrue(condition, "To avoid unnecessary work when a trace level has not been enabled, check CanWriteXXX before calling this method.");
	}
}
