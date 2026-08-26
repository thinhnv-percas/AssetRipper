namespace ICSharpCode.Decompiler.FlowAnalysis;

public enum JumpType
{
	Normal,
	JumpToExceptionHandler,
	LeaveTry,
	EndFinally
}
