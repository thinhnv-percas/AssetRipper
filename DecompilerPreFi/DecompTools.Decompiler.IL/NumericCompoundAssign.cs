#define DEBUG
using System.Diagnostics;
using DecompTools.Decompiler.IL.Patterns;
using DecompTools.Decompiler.IL.Transforms;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public sealed class NumericCompoundAssign : CompoundAssignmentInstruction, ILiftableInstruction
{
	private IType type;

	public readonly bool CheckForOverflow;

	public readonly Sign Sign;

	public readonly StackType LeftInputType;

	public readonly StackType RightInputType;

	public readonly BinaryNumericOperator Operator;

	public IType Type
	{
		get
		{
			return type;
		}
		set
		{
			type = value;
			InvalidateFlags();
		}
	}

	public override StackType ResultType => type.GetStackType();

	public StackType UnderlyingResultType { get; }

	public bool IsLifted { get; }

	public override InstructionFlags DirectFlags
	{
		get
		{
			InstructionFlags instructionFlags = InstructionFlags.SideEffect;
			if (CheckForOverflow || Operator == BinaryNumericOperator.Div || Operator == BinaryNumericOperator.Rem)
			{
				instructionFlags |= InstructionFlags.MayThrow;
			}
			return instructionFlags;
		}
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitNumericCompoundAssign(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitNumericCompoundAssign(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitNumericCompoundAssign(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is NumericCompoundAssign numericCompoundAssign && type.Equals(numericCompoundAssign.type) && CheckForOverflow == numericCompoundAssign.CheckForOverflow && Sign == numericCompoundAssign.Sign && Operator == numericCompoundAssign.Operator && base.Target.PerformMatch(numericCompoundAssign.Target, ref match) && base.Value.PerformMatch(numericCompoundAssign.Value, ref match);
	}

	public NumericCompoundAssign(BinaryNumericInstruction binary, ILInstruction target, ILInstruction value, IType type, CompoundAssignmentType compoundAssignmentType)
		: base(OpCode.NumericCompoundAssign, compoundAssignmentType, target, value)
	{
		Debug.Assert(IsBinaryCompatibleWithType(binary, type));
		CheckForOverflow = binary.CheckForOverflow;
		Sign = binary.Sign;
		LeftInputType = binary.LeftInputType;
		RightInputType = binary.RightInputType;
		UnderlyingResultType = binary.UnderlyingResultType;
		Operator = binary.Operator;
		IsLifted = binary.IsLifted;
		this.type = type;
		AddILRange(binary);
		Debug.Assert(compoundAssignmentType == CompoundAssignmentType.EvaluatesToNewValue || Operator == BinaryNumericOperator.Add || Operator == BinaryNumericOperator.Sub);
		Debug.Assert(CompoundAssignmentInstruction.IsValidCompoundAssignmentTarget(base.Target));
	}

	internal static bool IsBinaryCompatibleWithType(BinaryNumericInstruction binary, IType type)
	{
		if (binary.IsLifted)
		{
			if (!NullableType.IsNullable(type))
			{
				return false;
			}
			type = NullableType.GetUnderlyingType(type);
		}
		if (type.Kind == TypeKind.Unknown)
		{
			return false;
		}
		if (type.Kind == TypeKind.Enum)
		{
			BinaryNumericOperator binaryNumericOperator = binary.Operator;
			if (binaryNumericOperator - 1 > BinaryNumericOperator.Add && binaryNumericOperator - 6 > BinaryNumericOperator.Sub)
			{
				return false;
			}
		}
		else if (type.Kind == TypeKind.Pointer)
		{
			BinaryNumericOperator binaryNumericOperator2 = binary.Operator;
			if (binaryNumericOperator2 - 1 <= BinaryNumericOperator.Add)
			{
				return PointerArithmeticOffset.Detect(binary.Right, (PointerType)type, binary.CheckForOverflow) != null;
			}
			return false;
		}
		if (binary.Sign != Sign.None)
		{
			if (type.IsCSharpSmallIntegerType())
			{
				if (binary.Sign != Sign.Signed)
				{
					return false;
				}
			}
			else if (type.GetSign() != binary.Sign)
			{
				return false;
			}
		}
		if (TransformAssignment.IsImplicitTruncation(binary.Right, type, null, binary.IsLifted))
		{
			return false;
		}
		return true;
	}

	protected override InstructionFlags ComputeFlags()
	{
		InstructionFlags instructionFlags = base.Target.Flags | base.Value.Flags | InstructionFlags.SideEffect;
		if (CheckForOverflow || Operator == BinaryNumericOperator.Div || Operator == BinaryNumericOperator.Rem)
		{
			instructionFlags |= InstructionFlags.MayThrow;
		}
		return instructionFlags;
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(OpCode);
		output.Write("." + BinaryNumericInstruction.GetOperatorName(Operator));
		if (CompoundAssignmentType == CompoundAssignmentType.EvaluatesToNewValue)
		{
			output.Write(".new");
		}
		else
		{
			output.Write(".old");
		}
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
		output.Write('(');
		base.Target.WriteTo(output, options);
		output.Write(", ");
		base.Value.WriteTo(output, options);
		output.Write(')');
	}
}
