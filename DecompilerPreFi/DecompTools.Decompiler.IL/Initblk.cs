#define DEBUG
using System;
using System.Diagnostics;
using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class Initblk : ILInstruction, ISupportsVolatilePrefix, ISupportsUnalignedPrefix
{
	public static readonly SlotInfo AddressSlot = new SlotInfo("Address", canInlineInto: true);

	private ILInstruction address;

	public static readonly SlotInfo ValueSlot = new SlotInfo("Value", canInlineInto: true);

	private ILInstruction value;

	public static readonly SlotInfo SizeSlot = new SlotInfo("Size", canInlineInto: true);

	private ILInstruction size;

	public ILInstruction Address
	{
		get
		{
			return address;
		}
		set
		{
			ValidateChild(value);
			SetChildInstruction(ref address, value, 0);
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

	public ILInstruction Size
	{
		get
		{
			return size;
		}
		set
		{
			ValidateChild(value);
			SetChildInstruction(ref size, value, 2);
		}
	}

	public bool IsVolatile { get; set; }

	public byte UnalignedPrefix { get; set; }

	public override StackType ResultType => StackType.Void;

	public override InstructionFlags DirectFlags => InstructionFlags.SideEffect | InstructionFlags.MayThrow;

	public Initblk(ILInstruction address, ILInstruction value, ILInstruction size)
		: base(OpCode.Initblk)
	{
		Address = address;
		Value = value;
		Size = size;
	}

	protected sealed override int GetChildCount()
	{
		return 3;
	}

	protected sealed override ILInstruction GetChild(int index)
	{
		return index switch
		{
			0 => address, 
			1 => value, 
			2 => size, 
			_ => throw new IndexOutOfRangeException(), 
		};
	}

	protected sealed override void SetChild(int index, ILInstruction value)
	{
		switch (index)
		{
		case 0:
			Address = value;
			break;
		case 1:
			Value = value;
			break;
		case 2:
			Size = value;
			break;
		default:
			throw new IndexOutOfRangeException();
		}
	}

	protected sealed override SlotInfo GetChildSlot(int index)
	{
		return index switch
		{
			0 => AddressSlot, 
			1 => ValueSlot, 
			2 => SizeSlot, 
			_ => throw new IndexOutOfRangeException(), 
		};
	}

	public sealed override ILInstruction Clone()
	{
		Initblk initblk = (Initblk)ShallowClone();
		initblk.Address = address.Clone();
		initblk.Value = value.Clone();
		initblk.Size = size.Clone();
		return initblk;
	}

	protected override InstructionFlags ComputeFlags()
	{
		return address.Flags | value.Flags | size.Flags | InstructionFlags.MayThrow | InstructionFlags.SideEffect;
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		if (IsVolatile)
		{
			output.Write("volatile.");
		}
		if (UnalignedPrefix > 0)
		{
			output.Write("unaligned(" + UnalignedPrefix + ").");
		}
		output.Write(OpCode);
		output.Write('(');
		address.WriteTo(output, options);
		output.Write(", ");
		value.WriteTo(output, options);
		output.Write(", ");
		size.WriteTo(output, options);
		output.Write(')');
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitInitblk(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitInitblk(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitInitblk(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is Initblk initblk && address.PerformMatch(initblk.address, ref match) && value.PerformMatch(initblk.value, ref match) && size.PerformMatch(initblk.size, ref match) && IsVolatile == initblk.IsVolatile && UnalignedPrefix == initblk.UnalignedPrefix;
	}

	internal override void CheckInvariant(ILPhase phase)
	{
		base.CheckInvariant(phase);
		Debug.Assert(address.ResultType == StackType.I || address.ResultType == StackType.Ref);
		Debug.Assert(value.ResultType == StackType.I4);
		Debug.Assert(size.ResultType == StackType.I4);
	}
}
