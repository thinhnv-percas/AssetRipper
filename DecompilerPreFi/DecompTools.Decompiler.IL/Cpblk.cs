#define DEBUG
using System;
using System.Diagnostics;
using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class Cpblk : ILInstruction, ISupportsVolatilePrefix, ISupportsUnalignedPrefix
{
	public static readonly SlotInfo DestAddressSlot = new SlotInfo("DestAddress", canInlineInto: true);

	private ILInstruction destAddress;

	public static readonly SlotInfo SourceAddressSlot = new SlotInfo("SourceAddress", canInlineInto: true);

	private ILInstruction sourceAddress;

	public static readonly SlotInfo SizeSlot = new SlotInfo("Size", canInlineInto: true);

	private ILInstruction size;

	public ILInstruction DestAddress
	{
		get
		{
			return destAddress;
		}
		set
		{
			ValidateChild(value);
			SetChildInstruction(ref destAddress, value, 0);
		}
	}

	public ILInstruction SourceAddress
	{
		get
		{
			return sourceAddress;
		}
		set
		{
			ValidateChild(value);
			SetChildInstruction(ref sourceAddress, value, 1);
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

	public Cpblk(ILInstruction destAddress, ILInstruction sourceAddress, ILInstruction size)
		: base(OpCode.Cpblk)
	{
		DestAddress = destAddress;
		SourceAddress = sourceAddress;
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
			0 => destAddress, 
			1 => sourceAddress, 
			2 => size, 
			_ => throw new IndexOutOfRangeException(), 
		};
	}

	protected sealed override void SetChild(int index, ILInstruction value)
	{
		switch (index)
		{
		case 0:
			DestAddress = value;
			break;
		case 1:
			SourceAddress = value;
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
			0 => DestAddressSlot, 
			1 => SourceAddressSlot, 
			2 => SizeSlot, 
			_ => throw new IndexOutOfRangeException(), 
		};
	}

	public sealed override ILInstruction Clone()
	{
		Cpblk cpblk = (Cpblk)ShallowClone();
		cpblk.DestAddress = destAddress.Clone();
		cpblk.SourceAddress = sourceAddress.Clone();
		cpblk.Size = size.Clone();
		return cpblk;
	}

	protected override InstructionFlags ComputeFlags()
	{
		return destAddress.Flags | sourceAddress.Flags | size.Flags | InstructionFlags.MayThrow | InstructionFlags.SideEffect;
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
		destAddress.WriteTo(output, options);
		output.Write(", ");
		sourceAddress.WriteTo(output, options);
		output.Write(", ");
		size.WriteTo(output, options);
		output.Write(')');
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitCpblk(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitCpblk(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitCpblk(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is Cpblk cpblk && destAddress.PerformMatch(cpblk.destAddress, ref match) && sourceAddress.PerformMatch(cpblk.sourceAddress, ref match) && size.PerformMatch(cpblk.size, ref match) && IsVolatile == cpblk.IsVolatile && UnalignedPrefix == cpblk.UnalignedPrefix;
	}

	internal override void CheckInvariant(ILPhase phase)
	{
		base.CheckInvariant(phase);
		Debug.Assert(destAddress.ResultType == StackType.I || destAddress.ResultType == StackType.Ref);
		Debug.Assert(sourceAddress.ResultType == StackType.I || sourceAddress.ResultType == StackType.Ref);
		Debug.Assert(size.ResultType == StackType.I4);
	}
}
