using System;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public abstract class CompoundAssignmentInstruction : ILInstruction
{
	public static readonly SlotInfo TargetSlot = new SlotInfo("Target", canInlineInto: true);

	private ILInstruction target;

	public static readonly SlotInfo ValueSlot = new SlotInfo("Value", canInlineInto: true);

	private ILInstruction value;

	public readonly CompoundAssignmentType CompoundAssignmentType;

	public ILInstruction Target
	{
		get
		{
			return target;
		}
		set
		{
			ValidateChild(value);
			SetChildInstruction(ref target, value, 0);
		}
	}

	public ILInstruction Value
	{
		get
		{
			return value;
		}
		set
		{
			ValidateChild(value);
			SetChildInstruction(ref this.value, value, 1);
		}
	}

	public override InstructionFlags DirectFlags => InstructionFlags.None;

	protected sealed override int GetChildCount()
	{
		return 2;
	}

	protected sealed override ILInstruction GetChild(int index)
	{
		return index switch
		{
			0 => target, 
			1 => value, 
			_ => throw new IndexOutOfRangeException(), 
		};
	}

	protected sealed override void SetChild(int index, ILInstruction value)
	{
		switch (index)
		{
		case 0:
			Target = value;
			break;
		case 1:
			Value = value;
			break;
		default:
			throw new IndexOutOfRangeException();
		}
	}

	protected sealed override SlotInfo GetChildSlot(int index)
	{
		return index switch
		{
			0 => TargetSlot, 
			1 => ValueSlot, 
			_ => throw new IndexOutOfRangeException(), 
		};
	}

	public sealed override ILInstruction Clone()
	{
		CompoundAssignmentInstruction compoundAssignmentInstruction = (CompoundAssignmentInstruction)ShallowClone();
		compoundAssignmentInstruction.Target = target.Clone();
		compoundAssignmentInstruction.Value = value.Clone();
		return compoundAssignmentInstruction;
	}

	protected override InstructionFlags ComputeFlags()
	{
		return target.Flags | value.Flags;
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(OpCode);
		output.Write('(');
		target.WriteTo(output, options);
		output.Write(", ");
		value.WriteTo(output, options);
		output.Write(')');
	}

	public CompoundAssignmentInstruction(OpCode opCode, CompoundAssignmentType compoundAssignmentType, ILInstruction target, ILInstruction value)
		: base(opCode)
	{
		CompoundAssignmentType = compoundAssignmentType;
		Target = target;
		Value = value;
	}

	internal static bool IsValidCompoundAssignmentTarget(ILInstruction inst)
	{
		switch (inst.OpCode)
		{
		case OpCode.LdObj:
			return true;
		case OpCode.Call:
		case OpCode.CallVirt:
			return ((CallInstruction)inst).Method.AccessorOwner is IProperty property && property.CanSet;
		default:
			return false;
		}
	}
}
