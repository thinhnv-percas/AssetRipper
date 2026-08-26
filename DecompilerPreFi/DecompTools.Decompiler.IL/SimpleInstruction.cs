using System;

namespace DecompTools.Decompiler.IL;

public abstract class SimpleInstruction : ILInstruction
{
	public override InstructionFlags DirectFlags => InstructionFlags.None;

	protected SimpleInstruction(OpCode opCode)
		: base(opCode)
	{
	}

	protected sealed override int GetChildCount()
	{
		return 0;
	}

	protected sealed override ILInstruction GetChild(int index)
	{
		throw new IndexOutOfRangeException();
	}

	protected sealed override void SetChild(int index, ILInstruction value)
	{
		throw new IndexOutOfRangeException();
	}

	protected sealed override SlotInfo GetChildSlot(int index)
	{
		throw new IndexOutOfRangeException();
	}

	public sealed override ILInstruction Clone()
	{
		return (SimpleInstruction)ShallowClone();
	}

	protected override InstructionFlags ComputeFlags()
	{
		return InstructionFlags.None;
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(OpCode);
	}
}
