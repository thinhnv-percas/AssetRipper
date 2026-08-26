using System;
using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class TryFault : TryInstruction
{
	public static readonly SlotInfo FaultBlockSlot = new SlotInfo("FaultBlock");

	private ILInstruction faultBlock;

	public ILInstruction FaultBlock
	{
		get
		{
			return faultBlock;
		}
		set
		{
			ValidateChild(value);
			SetChildInstruction(ref faultBlock, value, 1);
		}
	}

	public override StackType ResultType => base.TryBlock.ResultType;

	public override InstructionFlags DirectFlags => InstructionFlags.ControlFlow;

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitTryFault(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitTryFault(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitTryFault(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is TryFault tryFault && base.TryBlock.PerformMatch(tryFault.TryBlock, ref match) && faultBlock.PerformMatch(tryFault.faultBlock, ref match);
	}

	public TryFault(ILInstruction tryBlock, ILInstruction faultBlock)
		: base(OpCode.TryFinally, tryBlock)
	{
		FaultBlock = faultBlock;
	}

	public override ILInstruction Clone()
	{
		return new TryFault(base.TryBlock.Clone(), faultBlock.Clone()).WithILRange(this);
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(".try ");
		base.TryBlock.WriteTo(output, options);
		output.Write(" fault ");
		faultBlock.WriteTo(output, options);
	}

	protected override InstructionFlags ComputeFlags()
	{
		return base.TryBlock.Flags | (faultBlock.Flags & ~InstructionFlags.EndPointUnreachable) | InstructionFlags.ControlFlow;
	}

	protected override int GetChildCount()
	{
		return 2;
	}

	protected override ILInstruction GetChild(int index)
	{
		return index switch
		{
			0 => base.TryBlock, 
			1 => faultBlock, 
			_ => throw new IndexOutOfRangeException(), 
		};
	}

	protected override void SetChild(int index, ILInstruction value)
	{
		switch (index)
		{
		case 0:
			base.TryBlock = value;
			break;
		case 1:
			FaultBlock = value;
			break;
		default:
			throw new IndexOutOfRangeException();
		}
	}

	protected override SlotInfo GetChildSlot(int index)
	{
		return index switch
		{
			0 => TryInstruction.TryBlockSlot, 
			1 => FaultBlockSlot, 
			_ => throw new IndexOutOfRangeException(), 
		};
	}
}
