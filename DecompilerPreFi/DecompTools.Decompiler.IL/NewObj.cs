using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public sealed class NewObj : CallInstruction
{
	public override StackType ResultType => Method.DeclaringType.GetStackType();

	public NewObj(IMethod method)
		: base(OpCode.NewObj, method)
	{
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitNewObj(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitNewObj(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitNewObj(this, context);
	}
}
