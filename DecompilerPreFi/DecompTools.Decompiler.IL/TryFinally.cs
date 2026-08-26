using System;
using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class TryFinally : TryInstruction
{
	public static readonly SlotInfo FinallyBlockSlot = new SlotInfo("FinallyBlock");

	private ILInstruction finallyBlock;

	public ILInstruction FinallyBlock
	{
		get
		{
			return finallyBlock;
		}
		set
		{
			ValidateChild(value);
			SetChildInstruction(ref finallyBlock, value, 1);
		}
	}

	public override StackType ResultType => base.TryBlock.ResultType;

	public override InstructionFlags DirectFlags => InstructionFlags.ControlFlow;

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitTryFinally(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitTryFinally(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitTryFinally(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is TryFinally tryFinally && base.TryBlock.PerformMatch(tryFinally.TryBlock, ref match) && finallyBlock.PerformMatch(tryFinally.finallyBlock, ref match);
	}

	public TryFinally(ILInstruction tryBlock, ILInstruction finallyBlock)
		: base(OpCode.TryFinally, tryBlock)
	{
		FinallyBlock = finallyBlock;
	}

	public override ILInstruction Clone()
	{
		return new TryFinally(base.TryBlock.Clone(), finallyBlock.Clone()).WithILRange(this);
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(".try ");
		base.TryBlock.WriteTo(output, options);
		output.Write(" finally ");
		finallyBlock.WriteTo(output, options);
	}

	protected override InstructionFlags ComputeFlags()
	{
		return base.TryBlock.Flags | finallyBlock.Flags | InstructionFlags.ControlFlow;
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
			1 => finallyBlock, 
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
			FinallyBlock = value;
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
			1 => FinallyBlockSlot, 
			_ => throw new IndexOutOfRangeException(), 
		};
	}
}
