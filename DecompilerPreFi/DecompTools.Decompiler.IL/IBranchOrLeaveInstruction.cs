namespace DecompTools.Decompiler.IL;

internal interface IBranchOrLeaveInstruction
{
	BlockContainer TargetContainer { get; }
}
