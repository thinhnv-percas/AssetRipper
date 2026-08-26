using DecompTools.Decompiler.CSharp.Resolver;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public sealed class Call : CallInstruction, ILiftableInstruction
{
	public bool IsLifted => Method is ILiftedOperator;

	public StackType UnderlyingResultType
	{
		get
		{
			if (Method is ILiftedOperator liftedOperator)
			{
				return liftedOperator.NonLiftedReturnType.GetStackType();
			}
			return Method.ReturnType.GetStackType();
		}
	}

	public Call(IMethod method)
		: base(OpCode.Call, method)
	{
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitCall(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitCall(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitCall(this, context);
	}
}
