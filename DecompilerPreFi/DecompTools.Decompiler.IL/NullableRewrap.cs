#define DEBUG
using System.Diagnostics;
using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class NullableRewrap : UnaryInstruction
{
	public override InstructionFlags DirectFlags => InstructionFlags.ControlFlow;

	public override StackType ResultType
	{
		get
		{
			if (base.Argument.ResultType == StackType.Void)
			{
				return StackType.Void;
			}
			return StackType.O;
		}
	}

	internal override void CheckInvariant(ILPhase phase)
	{
		base.CheckInvariant(phase);
		Debug.Assert(base.Argument.HasFlag(InstructionFlags.MayUnwrapNull));
	}

	protected override InstructionFlags ComputeFlags()
	{
		return (base.Argument.Flags & ~(InstructionFlags.MayUnwrapNull | InstructionFlags.EndPointUnreachable)) | InstructionFlags.ControlFlow;
	}

	public NullableRewrap(ILInstruction argument)
		: base(OpCode.NullableRewrap, argument)
	{
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitNullableRewrap(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitNullableRewrap(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitNullableRewrap(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is NullableRewrap nullableRewrap && base.Argument.PerformMatch(nullableRewrap.Argument, ref match);
	}
}
