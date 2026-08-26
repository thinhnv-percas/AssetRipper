using DecompTools.Decompiler.IL;

namespace DecompTools.Decompiler.CSharp;

public class ForeachAnnotation
{
	public readonly ILInstruction GetEnumeratorCall;

	public readonly ILInstruction MoveNextCall;

	public readonly ILInstruction GetCurrentCall;

	public ForeachAnnotation(ILInstruction getEnumeratorCall, ILInstruction moveNextCall, ILInstruction getCurrentCall)
	{
		GetEnumeratorCall = getEnumeratorCall;
		MoveNextCall = moveNextCall;
		GetCurrentCall = getCurrentCall;
	}
}
