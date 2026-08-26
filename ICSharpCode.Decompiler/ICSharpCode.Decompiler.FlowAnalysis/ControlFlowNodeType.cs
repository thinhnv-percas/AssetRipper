namespace ICSharpCode.Decompiler.FlowAnalysis;

public enum ControlFlowNodeType
{
	Normal,
	EntryPoint,
	RegularExit,
	ExceptionalExit,
	CatchHandler,
	FinallyOrFaultHandler,
	EndFinallyOrFault
}
