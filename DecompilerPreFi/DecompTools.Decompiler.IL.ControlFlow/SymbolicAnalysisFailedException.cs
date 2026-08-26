using System;

namespace DecompTools.Decompiler.IL.ControlFlow;

internal class SymbolicAnalysisFailedException : Exception
{
	public SymbolicAnalysisFailedException()
	{
	}

	public SymbolicAnalysisFailedException(string message)
		: base(message)
	{
	}
}
