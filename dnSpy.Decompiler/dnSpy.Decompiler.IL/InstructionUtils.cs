using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace dnSpy.Decompiler.IL;

internal static class InstructionUtils
{
	public static void AddOpCode(IList<short> instrs, Code code)
	{
		if (code <= Code.Prefixref)
		{
			instrs.Add((byte)code);
			return;
		}
		if ((uint)code >> 8 == 254)
		{
			instrs.Add((byte)((uint)code >> 8));
			instrs.Add((byte)code);
			return;
		}
		switch (code)
		{
		case Code.UNKNOWN1:
			instrs.AddUnknownByte();
			break;
		case Code.UNKNOWN2:
			instrs.AddUnknownInt16();
			break;
		default:
			throw new InvalidOperationException();
		}
	}

	private static void AddUnknownByte(this IList<short> instrs)
	{
		instrs.Add(-1);
	}

	private static void AddUnknownInt16(this IList<short> instrs)
	{
		instrs.Add(-1);
		instrs.Add(-1);
	}

	private static void AddUnknownInt32(this IList<short> instrs)
	{
		instrs.Add(-1);
		instrs.Add(-1);
		instrs.Add(-1);
		instrs.Add(-1);
	}

	private static void AddUnknownInt64(this IList<short> instrs)
	{
		instrs.AddUnknownInt32();
		instrs.AddUnknownInt32();
	}

	private static void AddInt16(this IList<short> instrs, short val)
	{
		instrs.Add((byte)val);
		instrs.Add((byte)(val >> 8));
	}

	private static void AddInt32(this IList<short> instrs, int val)
	{
		instrs.Add((byte)val);
		instrs.Add((byte)(val >> 8));
		instrs.Add((byte)(val >> 16));
		instrs.Add((byte)(val >> 24));
	}

	private static void AddInt64(this IList<short> instrs, long val)
	{
		instrs.Add((byte)val);
		instrs.Add((byte)(val >> 8));
		instrs.Add((byte)(val >> 16));
		instrs.Add((byte)(val >> 24));
		instrs.Add((byte)(val >> 32));
		instrs.Add((byte)(val >> 40));
		instrs.Add((byte)(val >> 48));
		instrs.Add((byte)(val >> 56));
	}

	private static void AddSingle(this IList<short> instrs, float val)
	{
		byte[] bytes = BitConverter.GetBytes(val);
		foreach (byte item in bytes)
		{
			instrs.Add(item);
		}
	}

	private static void AddDouble(this IList<short> instrs, double val)
	{
		byte[] bytes = BitConverter.GetBytes(val);
		foreach (byte item in bytes)
		{
			instrs.Add(item);
		}
	}

	private static void AddToken(this IList<short> instrs, ITokenResolver resolver, uint token)
	{
		if (resolver == null || resolver.ResolveToken(token) == null)
		{
			instrs.AddUnknownInt32();
		}
		else
		{
			instrs.AddInt32((int)token);
		}
	}

	public static void AddOperand(IList<short> instrs, ITokenResolver resolver, uint offset, OpCode opCode, object operand)
	{
		switch (opCode.OperandType)
		{
		case OperandType.InlineBrTarget:
			if (!(operand is Instruction instruction2))
			{
				instrs.AddUnknownInt32();
			}
			else
			{
				instrs.AddInt32((int)(instruction2.Offset - (offset + 4)));
			}
			break;
		case OperandType.InlineField:
		case OperandType.InlineMethod:
		case OperandType.InlineTok:
		case OperandType.InlineType:
			instrs.AddToken(resolver, (operand as ITokenOperand)?.MDToken.Raw ?? 0);
			break;
		case OperandType.InlineSig:
			instrs.AddToken(resolver, (operand as MethodSig)?.OriginalToken ?? 0);
			break;
		case OperandType.InlineString:
			instrs.AddUnknownInt32();
			break;
		case OperandType.InlineI:
			if (operand is int)
			{
				instrs.AddInt32((int)operand);
			}
			else
			{
				instrs.AddUnknownInt32();
			}
			break;
		case OperandType.InlineI8:
			if (operand is long)
			{
				instrs.AddInt64((long)operand);
			}
			else
			{
				instrs.AddUnknownInt64();
			}
			break;
		case OperandType.InlineR:
			if (operand is double)
			{
				instrs.AddDouble((double)operand);
			}
			else
			{
				instrs.AddUnknownInt64();
			}
			break;
		case OperandType.ShortInlineR:
			if (operand is float)
			{
				instrs.AddSingle((float)operand);
			}
			else
			{
				instrs.AddUnknownInt32();
			}
			break;
		case OperandType.InlineSwitch:
		{
			if (!(operand is IList<Instruction> list))
			{
				instrs.AddUnknownInt32();
				break;
			}
			uint num = offset + 4 + (uint)(list.Count * 4);
			instrs.AddInt32(list.Count);
			{
				foreach (Instruction item in list)
				{
					if (item == null)
					{
						instrs.AddUnknownInt32();
					}
					else
					{
						instrs.AddInt32((int)(item.Offset - num));
					}
				}
				break;
			}
		}
		case OperandType.InlineVar:
			if (!(operand is IVariable variable))
			{
				instrs.AddUnknownInt16();
			}
			else if (0 <= variable.Index && variable.Index <= 65535)
			{
				instrs.AddInt16((short)variable.Index);
			}
			else
			{
				instrs.AddUnknownInt16();
			}
			break;
		case OperandType.ShortInlineVar:
			if (!(operand is IVariable variable2))
			{
				instrs.AddUnknownByte();
			}
			else if (0 <= variable2.Index && variable2.Index <= 255)
			{
				instrs.Add((byte)variable2.Index);
			}
			else
			{
				instrs.AddUnknownByte();
			}
			break;
		case OperandType.ShortInlineBrTarget:
		{
			if (!(operand is Instruction instruction))
			{
				instrs.AddUnknownByte();
				break;
			}
			int num2 = (int)(instruction.Offset - (offset + 1));
			if (-128 <= num2 && num2 <= 127)
			{
				instrs.Add((short)(num2 & 0xFF));
			}
			else
			{
				instrs.AddUnknownByte();
			}
			break;
		}
		case OperandType.ShortInlineI:
			if (operand is sbyte)
			{
				instrs.Add((short)((sbyte)operand & 0xFF));
			}
			else if (operand is byte)
			{
				instrs.Add((short)((byte)operand & 0xFF));
			}
			else
			{
				instrs.AddUnknownByte();
			}
			break;
		case OperandType.InlineNone:
		case OperandType.InlinePhi:
			break;
		default:
			throw new InvalidOperationException();
		}
	}
}
