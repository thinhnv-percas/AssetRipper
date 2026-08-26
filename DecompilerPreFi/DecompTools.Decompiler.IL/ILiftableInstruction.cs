namespace DecompTools.Decompiler.IL;

public interface ILiftableInstruction
{
	bool IsLifted { get; }

	StackType UnderlyingResultType { get; }
}
