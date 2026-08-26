#define DEBUG
using System.Diagnostics;
using DecompTools.Decompiler.IL.Patterns;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public sealed class Conv : UnaryInstruction, ILiftableInstruction
{
	public readonly ConversionKind Kind;

	public readonly bool CheckForOverflow;

	public readonly StackType InputType;

	public readonly Sign InputSign;

	public readonly PrimitiveType TargetType;

	public bool IsLifted { get; }

	public override StackType ResultType => IsLifted ? StackType.O : TargetType.GetStackType();

	public StackType UnderlyingResultType => TargetType.GetStackType();

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitConv(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitConv(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitConv(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is Conv conv && base.Argument.PerformMatch(conv.Argument, ref match) && CheckForOverflow == conv.CheckForOverflow && Kind == conv.Kind && InputSign == conv.InputSign && TargetType == conv.TargetType && IsLifted == conv.IsLifted;
	}

	public Conv(ILInstruction argument, PrimitiveType targetType, bool checkForOverflow, Sign inputSign)
		: this(argument, argument.ResultType, inputSign, targetType, checkForOverflow)
	{
	}

	public Conv(ILInstruction argument, StackType inputType, Sign inputSign, PrimitiveType targetType, bool checkForOverflow, bool isLifted = false)
		: base(OpCode.Conv, argument)
	{
		bool flag = checkForOverflow || targetType == PrimitiveType.R4 || targetType == PrimitiveType.R8;
		Debug.Assert(!flag || inputSign != Sign.None);
		InputType = inputType;
		InputSign = (flag ? inputSign : Sign.None);
		TargetType = targetType;
		CheckForOverflow = checkForOverflow;
		Kind = GetConversionKind(targetType, InputType, InputSign);
		IsLifted = isLifted;
	}

	internal override void CheckInvariant(ILPhase phase)
	{
		base.CheckInvariant(phase);
		Debug.Assert(base.Argument.ResultType == (IsLifted ? StackType.O : InputType));
		Debug.Assert(!IsLifted || Kind != ConversionKind.StopGCTracking);
	}

	private static ConversionKind GetConversionKind(PrimitiveType targetType, StackType inputType, Sign inputSign)
	{
		switch (targetType)
		{
		case PrimitiveType.I1:
		case PrimitiveType.U1:
		case PrimitiveType.I2:
		case PrimitiveType.U2:
			switch (inputType)
			{
			case StackType.I4:
			case StackType.I:
			case StackType.I8:
				return ConversionKind.Truncate;
			case StackType.F4:
			case StackType.F8:
				return ConversionKind.FloatToInt;
			default:
				return ConversionKind.Invalid;
			}
		case PrimitiveType.I4:
		case PrimitiveType.U4:
			switch (inputType)
			{
			case StackType.I4:
				return ConversionKind.Nop;
			case StackType.I:
			case StackType.I8:
				return ConversionKind.Truncate;
			case StackType.F4:
			case StackType.F8:
				return ConversionKind.FloatToInt;
			default:
				return ConversionKind.Invalid;
			}
		case PrimitiveType.I8:
		case PrimitiveType.U8:
			switch (inputType)
			{
			case StackType.I4:
			case StackType.I:
			{
				int result2;
				switch (inputSign)
				{
				case Sign.None:
					return (targetType == PrimitiveType.I8) ? ConversionKind.SignExtend : ConversionKind.ZeroExtend;
				default:
					result2 = 6;
					break;
				case Sign.Signed:
					result2 = 5;
					break;
				}
				return (ConversionKind)result2;
			}
			case StackType.I8:
				return ConversionKind.Nop;
			case StackType.F4:
			case StackType.F8:
				return ConversionKind.FloatToInt;
			case StackType.O:
			case StackType.Ref:
				return ConversionKind.StopGCTracking;
			default:
				return ConversionKind.Invalid;
			}
		case PrimitiveType.I:
		case PrimitiveType.U:
			switch (inputType)
			{
			case StackType.I4:
			{
				int result;
				switch (inputSign)
				{
				case Sign.None:
					return (targetType == PrimitiveType.I) ? ConversionKind.SignExtend : ConversionKind.ZeroExtend;
				default:
					result = 6;
					break;
				case Sign.Signed:
					result = 5;
					break;
				}
				return (ConversionKind)result;
			}
			case StackType.I:
				return ConversionKind.Nop;
			case StackType.I8:
				return ConversionKind.Truncate;
			case StackType.F4:
			case StackType.F8:
				return ConversionKind.FloatToInt;
			case StackType.O:
			case StackType.Ref:
				return ConversionKind.StopGCTracking;
			default:
				return ConversionKind.Invalid;
			}
		case PrimitiveType.R4:
			switch (inputType)
			{
			case StackType.I4:
			case StackType.I:
			case StackType.I8:
				return ConversionKind.IntToFloat;
			case StackType.F4:
				return ConversionKind.Nop;
			case StackType.F8:
				return ConversionKind.FloatPrecisionChange;
			default:
				return ConversionKind.Invalid;
			}
		case PrimitiveType.R8:
			switch (inputType)
			{
			case StackType.I4:
			case StackType.I:
			case StackType.I8:
				return ConversionKind.IntToFloat;
			case StackType.F4:
				return ConversionKind.FloatPrecisionChange;
			case StackType.F8:
				return ConversionKind.Nop;
			default:
				return ConversionKind.Invalid;
			}
		case PrimitiveType.Ref:
			switch (inputType)
			{
			case StackType.I4:
			case StackType.I:
			case StackType.I8:
				return ConversionKind.StartGCTracking;
			case StackType.O:
				return ConversionKind.ObjectInterior;
			default:
				return ConversionKind.Invalid;
			}
		default:
			return ConversionKind.Invalid;
		}
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(OpCode);
		if (CheckForOverflow)
		{
			output.Write(".ovf");
		}
		if (InputSign == Sign.Unsigned)
		{
			output.Write(".unsigned");
		}
		else if (InputSign == Sign.Signed)
		{
			output.Write(".signed");
		}
		if (IsLifted)
		{
			output.Write(".lifted");
		}
		output.Write(' ');
		output.Write(InputType);
		output.Write("->");
		output.Write(TargetType);
		output.Write(' ');
		switch (Kind)
		{
		case ConversionKind.SignExtend:
			output.Write("<sign extend>");
			break;
		case ConversionKind.ZeroExtend:
			output.Write("<zero extend>");
			break;
		case ConversionKind.Invalid:
			output.Write("<invalid>");
			break;
		}
		output.Write('(');
		base.Argument.WriteTo(output, options);
		output.Write(')');
	}

	protected override InstructionFlags ComputeFlags()
	{
		InstructionFlags instructionFlags = base.ComputeFlags();
		if (CheckForOverflow)
		{
			instructionFlags |= InstructionFlags.MayThrow;
		}
		return instructionFlags;
	}

	public override ILInstruction UnwrapConv(ConversionKind kind)
	{
		if (Kind == kind && !IsLifted)
		{
			return base.Argument.UnwrapConv(kind);
		}
		return this;
	}
}
