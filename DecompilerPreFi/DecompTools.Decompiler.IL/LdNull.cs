using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class LdNull : SimpleInstruction
{
	public override StackType ResultType => StackType.O;

	public LdNull()
		: base(OpCode.LdNull)
	{
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitLdNull(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitLdNull(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitLdNull(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		LdNull ldNull = other as LdNull;
		return ldNull != null;
	}
}
