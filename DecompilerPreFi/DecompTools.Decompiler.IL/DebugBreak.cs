using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class DebugBreak : SimpleInstruction
{
	public override StackType ResultType => StackType.Void;

	public override InstructionFlags DirectFlags => InstructionFlags.SideEffect;

	public DebugBreak()
		: base(OpCode.DebugBreak)
	{
	}

	protected override InstructionFlags ComputeFlags()
	{
		return InstructionFlags.SideEffect;
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitDebugBreak(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitDebugBreak(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitDebugBreak(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		DebugBreak debugBreak = other as DebugBreak;
		return debugBreak != null;
	}
}
