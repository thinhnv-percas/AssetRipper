#define DEBUG
using System.Diagnostics;
using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class BitNot : UnaryInstruction, ILiftableInstruction
{
	public bool IsLifted { get; }

	public StackType UnderlyingResultType { get; }

	public override StackType ResultType => base.Argument.ResultType;

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitBitNot(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitBitNot(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitBitNot(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is BitNot bitNot && base.Argument.PerformMatch(bitNot.Argument, ref match) && IsLifted == bitNot.IsLifted && UnderlyingResultType == bitNot.UnderlyingResultType;
	}

	public BitNot(ILInstruction arg)
		: base(OpCode.BitNot, arg)
	{
		UnderlyingResultType = arg.ResultType;
	}

	public BitNot(ILInstruction arg, bool isLifted, StackType stackType)
		: base(OpCode.BitNot, arg)
	{
		IsLifted = isLifted;
		UnderlyingResultType = stackType;
	}

	internal override void CheckInvariant(ILPhase phase)
	{
		base.CheckInvariant(phase);
		Debug.Assert(IsLifted == (ResultType == StackType.O));
		Debug.Assert(IsLifted || ResultType == UnderlyingResultType);
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(OpCode);
		if (IsLifted)
		{
			output.Write(".lifted");
		}
		output.Write('(');
		base.Argument.WriteTo(output, options);
		output.Write(')');
	}
}
