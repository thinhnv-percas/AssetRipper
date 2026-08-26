using System;

namespace DecompTools.Decompiler.IL;

public abstract class UnaryInstruction : ILInstruction
{
	public static readonly SlotInfo ArgumentSlot = new SlotInfo("Argument", canInlineInto: true);

	private ILInstruction argument;

	public ILInstruction Argument
	{
		get
		{
			return argument;
		}
		set
		{
			ValidateChild(value);
			SetChildInstruction(ref argument, value, 0);
		}
	}

	public override InstructionFlags DirectFlags => InstructionFlags.None;

	protected UnaryInstruction(OpCode opCode, ILInstruction argument)
		: base(opCode)
	{
		Argument = argument;
	}

	protected sealed override int GetChildCount()
	{
		return 1;
	}

	protected sealed override ILInstruction GetChild(int index)
	{
		if (index == 0)
		{
			return argument;
		}
		throw new IndexOutOfRangeException();
	}

	protected sealed override void SetChild(int index, ILInstruction value)
	{
		if (index == 0)
		{
			Argument = value;
			return;
		}
		throw new IndexOutOfRangeException();
	}

	protected sealed override SlotInfo GetChildSlot(int index)
	{
		if (index == 0)
		{
			return ArgumentSlot;
		}
		throw new IndexOutOfRangeException();
	}

	public sealed override ILInstruction Clone()
	{
		UnaryInstruction unaryInstruction = (UnaryInstruction)ShallowClone();
		unaryInstruction.Argument = argument.Clone();
		return unaryInstruction;
	}

	protected override InstructionFlags ComputeFlags()
	{
		return argument.Flags | InstructionFlags.None;
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(OpCode);
		output.Write('(');
		argument.WriteTo(output, options);
		output.Write(')');
	}
}
