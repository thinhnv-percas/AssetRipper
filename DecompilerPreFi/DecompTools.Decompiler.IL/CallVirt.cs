using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public sealed class CallVirt : CallInstruction
{
	public CallVirt(IMethod method)
		: base(OpCode.CallVirt, method)
	{
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitCallVirt(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitCallVirt(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitCallVirt(this, context);
	}
}
