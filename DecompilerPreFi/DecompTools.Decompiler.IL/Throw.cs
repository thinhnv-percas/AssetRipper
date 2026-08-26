using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class Throw : UnaryInstruction
{
	public override StackType ResultType => StackType.Void;

	public override InstructionFlags DirectFlags => base.DirectFlags | InstructionFlags.MayThrow | InstructionFlags.EndPointUnreachable;

	public Throw(ILInstruction argument)
		: base(OpCode.Throw, argument)
	{
	}

	protected override InstructionFlags ComputeFlags()
	{
		return base.ComputeFlags() | InstructionFlags.MayThrow | InstructionFlags.EndPointUnreachable;
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitThrow(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitThrow(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitThrow(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is Throw obj && base.Argument.PerformMatch(obj.Argument, ref match);
	}
}
