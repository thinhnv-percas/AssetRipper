using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class RefAnyType : UnaryInstruction
{
	public override StackType ResultType => StackType.O;

	public RefAnyType(ILInstruction argument)
		: base(OpCode.RefAnyType, argument)
	{
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitRefAnyType(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitRefAnyType(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitRefAnyType(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is RefAnyType refAnyType && base.Argument.PerformMatch(refAnyType.Argument, ref match);
	}
}
