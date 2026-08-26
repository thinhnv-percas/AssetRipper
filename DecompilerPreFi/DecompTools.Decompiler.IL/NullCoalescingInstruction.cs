#define DEBUG
using System;
using System.Diagnostics;
using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class NullCoalescingInstruction : ILInstruction
{
	public readonly NullCoalescingKind Kind;

	public StackType UnderlyingResultType = StackType.O;

	public static readonly SlotInfo ValueInstSlot = new SlotInfo("ValueInst", canInlineInto: true);

	private ILInstruction valueInst;

	public static readonly SlotInfo FallbackInstSlot = new SlotInfo("FallbackInst");

	private ILInstruction fallbackInst;

	public override StackType ResultType => fallbackInst.ResultType;

	public override InstructionFlags DirectFlags => InstructionFlags.ControlFlow;

	public ILInstruction ValueInst
	{
		get
		{
			return valueInst;
		}
		set
		{
			ValidateChild(value);
			SetChildInstruction(ref valueInst, value, 0);
		}
	}

	public ILInstruction FallbackInst
	{
		get
		{
			return fallbackInst;
		}
		set
		{
			ValidateChild(value);
			SetChildInstruction(ref fallbackInst, value, 1);
		}
	}

	public NullCoalescingInstruction(NullCoalescingKind kind, ILInstruction valueInst, ILInstruction fallbackInst)
		: base(OpCode.NullCoalescingInstruction)
	{
		Kind = kind;
		ValueInst = valueInst;
		FallbackInst = fallbackInst;
	}

	internal override void CheckInvariant(ILPhase phase)
	{
		base.CheckInvariant(phase);
		Debug.Assert(valueInst.ResultType == StackType.O);
		Debug.Assert(fallbackInst.ResultType == StackType.O || Kind == NullCoalescingKind.NullableWithValueFallback);
		Debug.Assert(ResultType == UnderlyingResultType || Kind == NullCoalescingKind.Nullable);
	}

	protected override InstructionFlags ComputeFlags()
	{
		return InstructionFlags.ControlFlow | valueInst.Flags | SemanticHelper.CombineBranches(InstructionFlags.None, fallbackInst.Flags);
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(OpCode);
		output.Write("(");
		valueInst.WriteTo(output, options);
		output.Write(", ");
		fallbackInst.WriteTo(output, options);
		output.Write(")");
	}

	protected sealed override int GetChildCount()
	{
		return 2;
	}

	protected sealed override ILInstruction GetChild(int index)
	{
		return index switch
		{
			0 => valueInst, 
			1 => fallbackInst, 
			_ => throw new IndexOutOfRangeException(), 
		};
	}

	protected sealed override void SetChild(int index, ILInstruction value)
	{
		switch (index)
		{
		case 0:
			ValueInst = value;
			break;
		case 1:
			FallbackInst = value;
			break;
		default:
			throw new IndexOutOfRangeException();
		}
	}

	protected sealed override SlotInfo GetChildSlot(int index)
	{
		return index switch
		{
			0 => ValueInstSlot, 
			1 => FallbackInstSlot, 
			_ => throw new IndexOutOfRangeException(), 
		};
	}

	public sealed override ILInstruction Clone()
	{
		NullCoalescingInstruction nullCoalescingInstruction = (NullCoalescingInstruction)ShallowClone();
		nullCoalescingInstruction.ValueInst = valueInst.Clone();
		nullCoalescingInstruction.FallbackInst = fallbackInst.Clone();
		return nullCoalescingInstruction;
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitNullCoalescingInstruction(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitNullCoalescingInstruction(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitNullCoalescingInstruction(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is NullCoalescingInstruction nullCoalescingInstruction && valueInst.PerformMatch(nullCoalescingInstruction.valueInst, ref match) && fallbackInst.PerformMatch(nullCoalescingInstruction.fallbackInst, ref match);
	}
}
