using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class LocAlloc : UnaryInstruction
{
	public override StackType ResultType => StackType.I;

	public override InstructionFlags DirectFlags => base.DirectFlags | InstructionFlags.MayThrow;

	public LocAlloc(ILInstruction argument)
		: base(OpCode.LocAlloc, argument)
	{
	}

	protected override InstructionFlags ComputeFlags()
	{
		return base.ComputeFlags() | InstructionFlags.MayThrow;
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitLocAlloc(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitLocAlloc(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitLocAlloc(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is LocAlloc locAlloc && base.Argument.PerformMatch(locAlloc.Argument, ref match);
	}
}
