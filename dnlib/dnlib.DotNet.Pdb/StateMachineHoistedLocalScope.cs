using dnlib.DotNet.Emit;

namespace dnlib.DotNet.Pdb;

public struct StateMachineHoistedLocalScope
{
	public Instruction Start;

	public Instruction End;

	public bool IsSynthesizedLocal => Start == null && End == null;

	public StateMachineHoistedLocalScope(Instruction start, Instruction end)
	{
		Start = start;
		End = end;
	}
}
