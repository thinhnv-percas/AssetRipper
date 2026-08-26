using System.Globalization;
using System.Text;

namespace Microsoft.Composition.Diagnostics;

internal sealed class DebuggerTraceWriter : TraceWriter
{
	internal enum TraceEventType
	{
		Error = 2,
		Warning = 4,
		Information = 8
	}

	private static readonly string s_sourceName = "System.Composition";

	public override bool CanWriteInformation => false;

	public override bool CanWriteWarning => false;

	public override bool CanWriteError => false;

	public override void WriteInformation(CompositionTraceId traceId, string format, params object[] arguments)
	{
		WriteEvent(TraceEventType.Information, traceId, format, arguments);
	}

	public override void WriteWarning(CompositionTraceId traceId, string format, params object[] arguments)
	{
		WriteEvent(TraceEventType.Warning, traceId, format, arguments);
	}

	public override void WriteError(CompositionTraceId traceId, string format, params object[] arguments)
	{
		WriteEvent(TraceEventType.Error, traceId, format, arguments);
	}

	private static void WriteEvent(TraceEventType eventType, CompositionTraceId traceId, string format, params object[] arguments)
	{
	}

	internal static string CreateLogMessage(TraceEventType eventType, CompositionTraceId traceId, string format, params object[] arguments)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0} {1}: {2} : ", new object[3]
		{
			s_sourceName,
			eventType.ToString(),
			(int)traceId
		});
		if (arguments == null)
		{
			stringBuilder.Append(format);
		}
		else
		{
			stringBuilder.AppendFormat(CultureInfo.InvariantCulture, format, arguments);
		}
		stringBuilder.AppendLine();
		return stringBuilder.ToString();
	}
}
