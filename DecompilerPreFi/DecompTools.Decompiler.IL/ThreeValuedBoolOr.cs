#define DEBUG
using System.Diagnostics;
using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class ThreeValuedBoolOr : BinaryInstruction, ILiftableInstruction
{
	bool ILiftableInstruction.IsLifted => true;

	StackType ILiftableInstruction.UnderlyingResultType => StackType.I4;

	public override StackType ResultType => StackType.O;

	internal override void CheckInvariant(ILPhase phase)
	{
		base.CheckInvariant(phase);
		Debug.Assert(base.Left.ResultType == StackType.I4 || base.Left.ResultType == StackType.O);
	}

	public ThreeValuedBoolOr(ILInstruction left, ILInstruction right)
		: base(OpCode.ThreeValuedBoolOr, left, right)
	{
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitThreeValuedBoolOr(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitThreeValuedBoolOr(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitThreeValuedBoolOr(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is ThreeValuedBoolOr threeValuedBoolOr && base.Left.PerformMatch(threeValuedBoolOr.Left, ref match) && base.Right.PerformMatch(threeValuedBoolOr.Right, ref match);
	}
}
