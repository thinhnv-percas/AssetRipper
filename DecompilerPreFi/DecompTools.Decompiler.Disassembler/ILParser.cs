using System;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using DecompTools.Decompiler.Metadata;

namespace DecompTools.Decompiler.Disassembler;

public static class ILParser
{
	public static ILOpCode DecodeOpCode(this ref BlobReader blob)
	{
		byte b = blob.ReadByte();
		return (ILOpCode)checked((ushort)((b == 254) ? (65024 + blob.ReadByte()) : b));
	}

	public static void SkipOperand(this ref BlobReader blob, ILOpCode opCode)
	{
		checked
		{
			switch (opCode.GetOperandType())
			{
			case OperandType.I8:
			case OperandType.R:
				blob.Offset += 8;
				break;
			case OperandType.BrTarget:
			case OperandType.Field:
			case OperandType.I:
			case OperandType.Method:
			case OperandType.Sig:
			case OperandType.String:
			case OperandType.Tok:
			case OperandType.Type:
			case OperandType.ShortR:
				blob.Offset += 4;
				break;
			case OperandType.Switch:
			{
				uint num = blob.ReadUInt32();
				blob.Offset += (int)(num * 4);
				break;
			}
			case OperandType.Variable:
				blob.Offset += 2;
				break;
			case OperandType.ShortBrTarget:
			case OperandType.ShortI:
			case OperandType.ShortVariable:
				blob.Offset++;
				break;
			case OperandType.None:
			case (OperandType)6:
			case (OperandType)8:
				break;
			}
		}
	}

	public static int DecodeBranchTarget(this ref BlobReader blob, ILOpCode opCode)
	{
		return checked(((opCode.GetBranchOperandSize() == 4) ? blob.ReadInt32() : blob.ReadSByte()) + blob.Offset);
	}

	public static int[] DecodeSwitchTargets(this ref BlobReader blob)
	{
		int[] array = new int[blob.ReadUInt32()];
		checked
		{
			int num = blob.Offset + 4 * array.Length;
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = blob.ReadInt32() + num;
			}
			return array;
		}
	}

	public static string DecodeUserString(this ref BlobReader blob, MetadataReader metadata)
	{
		return metadata.GetUserString(MetadataTokens.UserStringHandle(blob.ReadInt32()));
	}

	public static int DecodeIndex(this ref BlobReader blob, ILOpCode opCode)
	{
		return opCode.GetOperandType() switch
		{
			OperandType.ShortVariable => blob.ReadByte(), 
			OperandType.Variable => blob.ReadUInt16(), 
			_ => throw new ArgumentException($"{opCode} not supported!"), 
		};
	}

	public static bool IsReturn(this ILOpCode opCode)
	{
		return opCode == ILOpCode.Ret || opCode == ILOpCode.Endfilter || opCode == ILOpCode.Endfinally;
	}
}
