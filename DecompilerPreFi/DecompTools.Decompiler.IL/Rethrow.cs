using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class Rethrow : SimpleInstruction
{
	public override StackType ResultType => StackType.Void;

	public override InstructionFlags DirectFlags => InstructionFlags.MayThrow | InstructionFlags.EndPointUnreachable;

	public Rethrow()
		: base(OpCode.Rethrow)
	{
	}

	protected override InstructionFlags ComputeFlags()
	{
		return InstructionFlags.MayThrow | InstructionFlags.EndPointUnreachable;
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitRethrow(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitRethrow(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitRethrow(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		Rethrow rethrow = other as Rethrow;
		return rethrow != null;
	}
}
