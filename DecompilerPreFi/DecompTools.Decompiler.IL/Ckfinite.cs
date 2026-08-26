using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class Ckfinite : UnaryInstruction
{
	public override StackType ResultType => StackType.Void;

	public override InstructionFlags DirectFlags => base.DirectFlags | InstructionFlags.MayThrow;

	public Ckfinite(ILInstruction argument)
		: base(OpCode.Ckfinite, argument)
	{
	}

	protected override InstructionFlags ComputeFlags()
	{
		return base.ComputeFlags() | InstructionFlags.MayThrow;
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitCkfinite(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitCkfinite(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitCkfinite(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is Ckfinite ckfinite && base.Argument.PerformMatch(ckfinite.Argument, ref match);
	}
}
