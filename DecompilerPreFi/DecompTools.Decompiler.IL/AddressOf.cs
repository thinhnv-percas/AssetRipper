using System;
using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class AddressOf : ILInstruction
{
	public static readonly SlotInfo ValueSlot = new SlotInfo("Value", canInlineInto: true);

	private ILInstruction value;

	public ILInstruction Value
	{
		get
		{
			return value;
		}
		set
		{
			ValidateChild(value);
			SetChildInstruction(ref this.value, value, 0);
		}
	}

	public override StackType ResultType => StackType.Ref;

	public override InstructionFlags DirectFlags => InstructionFlags.None;

	public AddressOf(ILInstruction value)
		: base(OpCode.AddressOf)
	{
		Value = value;
	}

	protected sealed override int GetChildCount()
	{
		return 1;
	}

	protected sealed override ILInstruction GetChild(int index)
	{
		if (index == 0)
		{
			return value;
		}
		throw new IndexOutOfRangeException();
	}

	protected sealed override void SetChild(int index, ILInstruction value)
	{
		if (index == 0)
		{
			Value = value;
			return;
		}
		throw new IndexOutOfRangeException();
	}

	protected sealed override SlotInfo GetChildSlot(int index)
	{
		if (index == 0)
		{
			return ValueSlot;
		}
		throw new IndexOutOfRangeException();
	}

	public sealed override ILInstruction Clone()
	{
		AddressOf addressOf = (AddressOf)ShallowClone();
		addressOf.Value = value.Clone();
		return addressOf;
	}

	protected override InstructionFlags ComputeFlags()
	{
		return value.Flags;
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(OpCode);
		output.Write('(');
		value.WriteTo(output, options);
		output.Write(')');
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitAddressOf(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitAddressOf(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitAddressOf(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is AddressOf addressOf && value.PerformMatch(addressOf.value, ref match);
	}
}
