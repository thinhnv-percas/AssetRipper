using System;

namespace DecompTools.Decompiler.IL;

public abstract class BinaryInstruction : ILInstruction
{
	public static readonly SlotInfo LeftSlot = new SlotInfo("Left", canInlineInto: true);

	private ILInstruction left;

	public static readonly SlotInfo RightSlot = new SlotInfo("Right", canInlineInto: true);

	private ILInstruction right;

	public ILInstruction Left
	{
		get
		{
			return left;
		}
		set
		{
			ValidateChild(value);
			SetChildInstruction(ref left, value, 0);
		}
	}

	public ILInstruction Right
	{
		get
		{
			return right;
		}
		set
		{
			ValidateChild(value);
			SetChildInstruction(ref right, value, 1);
		}
	}

	public override InstructionFlags DirectFlags => InstructionFlags.None;

	protected BinaryInstruction(OpCode opCode, ILInstruction left, ILInstruction right)
		: base(opCode)
	{
		Left = left;
		Right = right;
	}

	protected sealed override int GetChildCount()
	{
		return 2;
	}

	protected sealed override ILInstruction GetChild(int index)
	{
		return index switch
		{
			0 => left, 
			1 => right, 
			_ => throw new IndexOutOfRangeException(), 
		};
	}

	protected sealed override void SetChild(int index, ILInstruction value)
	{
		switch (index)
		{
		case 0:
			Left = value;
			break;
		case 1:
			Right = value;
			break;
		default:
			throw new IndexOutOfRangeException();
		}
	}

	protected sealed override SlotInfo GetChildSlot(int index)
	{
		return index switch
		{
			0 => LeftSlot, 
			1 => RightSlot, 
			_ => throw new IndexOutOfRangeException(), 
		};
	}

	public sealed override ILInstruction Clone()
	{
		BinaryInstruction binaryInstruction = (BinaryInstruction)ShallowClone();
		binaryInstruction.Left = left.Clone();
		binaryInstruction.Right = right.Clone();
		return binaryInstruction;
	}

	protected override InstructionFlags ComputeFlags()
	{
		return left.Flags | right.Flags | InstructionFlags.None;
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(OpCode);
		output.Write('(');
		left.WriteTo(output, options);
		output.Write(", ");
		right.WriteTo(output, options);
		output.Write(')');
	}
}
