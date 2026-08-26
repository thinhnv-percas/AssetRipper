using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class Arglist : SimpleInstruction
{
	public override StackType ResultType => StackType.O;

	public Arglist()
		: base(OpCode.Arglist)
	{
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitArglist(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitArglist(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitArglist(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		Arglist arglist = other as Arglist;
		return arglist != null;
	}
}
