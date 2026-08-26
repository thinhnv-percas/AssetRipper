using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnSpy.Contracts.Decompiler;

namespace dnSpy.Decompiler.IL;

internal sealed class ModifiedInstructionBytesReader : IInstructionBytesReader
{
	private readonly ITokenResolver resolver;

	private readonly IList<Instruction> instrs;

	private int instrIndex;

	private readonly List<short> instrBytes = new List<short>(10);

	private int byteIndex;

	public bool IsOriginalBytes => false;

	public ModifiedInstructionBytesReader(MethodDef method)
	{
		resolver = method.Module;
		instrs = method.Body.Instructions;
	}

	public int ReadByte()
	{
		if (byteIndex >= instrBytes.Count)
		{
			InitializeNextInstruction();
		}
		return instrBytes[byteIndex++];
	}

	private void InitializeNextInstruction()
	{
		if (instrIndex >= instrs.Count)
		{
			throw new InvalidOperationException();
		}
		Instruction instruction = instrs[instrIndex++];
		byteIndex = 0;
		instrBytes.Clear();
		InstructionUtils.AddOpCode(instrBytes, instruction.OpCode.Code);
		InstructionUtils.AddOperand(instrBytes, resolver, instruction.Offset + (uint)instruction.OpCode.Size, instruction.OpCode, instruction.Operand);
	}

	public void SetInstruction(int index, uint offset)
	{
		instrIndex = index;
		InitializeNextInstruction();
	}
}
