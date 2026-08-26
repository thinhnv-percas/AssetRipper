using System.Runtime.InteropServices;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct PointerArithmeticOffset
{
	public static ILInstruction Detect(ILInstruction byteOffsetInst, PointerType pointerType, bool checkForOverflow, bool unwrapZeroExtension = false)
	{
		if (byteOffsetInst is Conv { InputType: StackType.I8, ResultType: StackType.I } conv)
		{
			byteOffsetInst = conv.Argument;
		}
		int? num = ComputeSizeOf(pointerType.ElementType);
		if (num == 1)
		{
			return byteOffsetInst;
		}
		if (byteOffsetInst is BinaryNumericInstruction { Operator: BinaryNumericOperator.Mul } binaryNumericInstruction)
		{
			if (binaryNumericInstruction.IsLifted)
			{
				return null;
			}
			if (binaryNumericInstruction.CheckForOverflow != checkForOverflow)
			{
				return null;
			}
			if ((num > 0 && binaryNumericInstruction.Right.MatchLdcI(num.Value)) || (binaryNumericInstruction.Right.UnwrapConv(ConversionKind.SignExtend) is SizeOf sizeOf && sizeOf.Type.Equals(pointerType.ElementType)))
			{
				ILInstruction iLInstruction = binaryNumericInstruction.Left;
				if (unwrapZeroExtension)
				{
					iLInstruction = iLInstruction.UnwrapConv(ConversionKind.ZeroExtend);
				}
				return iLInstruction;
			}
		}
		else
		{
			if (byteOffsetInst.UnwrapConv(ConversionKind.SignExtend) is SizeOf sizeOf2 && sizeOf2.Type.Equals(pointerType.ElementType))
			{
				return new LdcI4(1).WithILRange(byteOffsetInst);
			}
			if (byteOffsetInst.MatchLdcI(out var val) && num > 0 && val % num == 0 && val > 0)
			{
				val /= num.Value;
				if (val <= int.MaxValue)
				{
					return new LdcI4(checked((int)val)).WithILRange(byteOffsetInst);
				}
			}
		}
		return null;
	}

	public static int? ComputeSizeOf(IType type)
	{
		switch (type.GetEnumUnderlyingType().GetDefinition()?.KnownTypeCode)
		{
		case KnownTypeCode.Boolean:
		case KnownTypeCode.SByte:
		case KnownTypeCode.Byte:
			return 1;
		case KnownTypeCode.Char:
		case KnownTypeCode.Int16:
		case KnownTypeCode.UInt16:
			return 2;
		case KnownTypeCode.Int32:
		case KnownTypeCode.UInt32:
		case KnownTypeCode.Single:
			return 4;
		case KnownTypeCode.Int64:
		case KnownTypeCode.UInt64:
		case KnownTypeCode.Double:
			return 8;
		default:
			return null;
		}
	}
}
