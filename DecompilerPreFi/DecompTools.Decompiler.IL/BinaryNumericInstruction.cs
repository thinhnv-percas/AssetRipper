#define DEBUG
using System;
using System.Diagnostics;
using DecompTools.Decompiler.IL.Patterns;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public sealed class BinaryNumericInstruction : BinaryInstruction, ILiftableInstruction
{
	public readonly bool CheckForOverflow;

	public readonly Sign Sign;

	public readonly StackType LeftInputType;

	public readonly StackType RightInputType;

	public readonly BinaryNumericOperator Operator;

	private readonly StackType resultType;

	public bool IsLifted { get; }

	public StackType UnderlyingResultType => resultType;

	public sealed override StackType ResultType => IsLifted ? StackType.O : resultType;

	public override InstructionFlags DirectFlags
	{
		get
		{
			if (CheckForOverflow || Operator == BinaryNumericOperator.Div || Operator == BinaryNumericOperator.Rem)
			{
				return base.DirectFlags | InstructionFlags.MayThrow;
			}
			return base.DirectFlags;
		}
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitBinaryNumericInstruction(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitBinaryNumericInstruction(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitBinaryNumericInstruction(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is BinaryNumericInstruction binaryNumericInstruction && base.Left.PerformMatch(binaryNumericInstruction.Left, ref match) && base.Right.PerformMatch(binaryNumericInstruction.Right, ref match) && CheckForOverflow == binaryNumericInstruction.CheckForOverflow && Sign == binaryNumericInstruction.Sign && Operator == binaryNumericInstruction.Operator && IsLifted == binaryNumericInstruction.IsLifted;
	}

	public BinaryNumericInstruction(BinaryNumericOperator op, ILInstruction left, ILInstruction right, bool checkForOverflow, Sign sign)
		: this(op, left, right, left.ResultType, right.ResultType, checkForOverflow, sign)
	{
	}

	public BinaryNumericInstruction(BinaryNumericOperator op, ILInstruction left, ILInstruction right, StackType leftInputType, StackType rightInputType, bool checkForOverflow, Sign sign, bool isLifted = false)
		: base(OpCode.BinaryNumericInstruction, left, right)
	{
		CheckForOverflow = checkForOverflow;
		Sign = sign;
		Operator = op;
		LeftInputType = leftInputType;
		RightInputType = rightInputType;
		IsLifted = isLifted;
		resultType = ComputeResultType(op, LeftInputType, RightInputType);
	}

	internal static StackType ComputeResultType(BinaryNumericOperator op, StackType left, StackType right)
	{
		if (left == right || op == BinaryNumericOperator.ShiftLeft || op == BinaryNumericOperator.ShiftRight)
		{
			return left;
		}
		if (left == StackType.Ref || right == StackType.Ref)
		{
			if (left == StackType.Ref && right == StackType.Ref)
			{
				Debug.Assert(op == BinaryNumericOperator.Sub);
				return StackType.I;
			}
			Debug.Assert(op == BinaryNumericOperator.Add || op == BinaryNumericOperator.Sub);
			return StackType.Ref;
		}
		return StackType.Unknown;
	}

	internal override void CheckInvariant(ILPhase phase)
	{
		base.CheckInvariant(phase);
		if (!IsLifted)
		{
			Debug.Assert(LeftInputType == base.Left.ResultType);
			Debug.Assert(RightInputType == base.Right.ResultType);
		}
	}

	protected override InstructionFlags ComputeFlags()
	{
		InstructionFlags instructionFlags = base.ComputeFlags();
		if (CheckForOverflow || Operator == BinaryNumericOperator.Div || Operator == BinaryNumericOperator.Rem)
		{
			instructionFlags |= InstructionFlags.MayThrow;
		}
		return instructionFlags;
	}

	internal static string GetOperatorName(BinaryNumericOperator @operator)
	{
		return @operator switch
		{
			BinaryNumericOperator.Add => "add", 
			BinaryNumericOperator.Sub => "sub", 
			BinaryNumericOperator.Mul => "mul", 
			BinaryNumericOperator.Div => "div", 
			BinaryNumericOperator.Rem => "rem", 
			BinaryNumericOperator.BitAnd => "bit.and", 
			BinaryNumericOperator.BitOr => "bit.or", 
			BinaryNumericOperator.BitXor => "bit.xor", 
			BinaryNumericOperator.ShiftLeft => "bit.shl", 
			BinaryNumericOperator.ShiftRight => "bit.shr", 
			_ => throw new ArgumentOutOfRangeException(), 
		};
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(OpCode);
		output.Write("." + GetOperatorName(Operator));
		if (CheckForOverflow)
		{
			output.Write(".ovf");
		}
		if (Sign == Sign.Unsigned)
		{
			output.Write(".unsigned");
		}
		else if (Sign == Sign.Signed)
		{
			output.Write(".signed");
		}
		output.Write('.');
		output.Write(resultType.ToString().ToLowerInvariant());
		if (IsLifted)
		{
			output.Write(".lifted");
		}
		output.Write('(');
		base.Left.WriteTo(output, options);
		output.Write(", ");
		base.Right.WriteTo(output, options);
		output.Write(')');
	}
}
