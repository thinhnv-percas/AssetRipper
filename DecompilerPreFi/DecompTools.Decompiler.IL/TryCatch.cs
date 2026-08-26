using System;
using System.Collections.Generic;
using System.Linq;
using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class TryCatch : TryInstruction
{
	public static readonly SlotInfo HandlerSlot = new SlotInfo("Handler", canInlineInto: false, isCollection: true);

	public readonly InstructionCollection<TryCatchHandler> Handlers;

	public override StackType ResultType => StackType.Void;

	public override InstructionFlags DirectFlags => InstructionFlags.ControlFlow;

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitTryCatch(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitTryCatch(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitTryCatch(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is TryCatch tryCatch && base.TryBlock.PerformMatch(tryCatch.TryBlock, ref match) && ListMatch.DoMatch(Handlers, tryCatch.Handlers, ref match);
	}

	public TryCatch(ILInstruction tryBlock)
		: base(OpCode.TryCatch, tryBlock)
	{
		Handlers = new InstructionCollection<TryCatchHandler>(this, 1);
	}

	public override ILInstruction Clone()
	{
		TryCatch tryCatch = new TryCatch(base.TryBlock.Clone());
		tryCatch.AddILRange(this);
		tryCatch.Handlers.AddRange(Enumerable.Select<TryCatchHandler, TryCatchHandler>((IEnumerable<TryCatchHandler>)Handlers, (Func<TryCatchHandler, TryCatchHandler>)((TryCatchHandler h) => (TryCatchHandler)h.Clone())));
		return tryCatch;
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(".try ");
		base.TryBlock.WriteTo(output, options);
		foreach (TryCatchHandler handler in Handlers)
		{
			output.Write(' ');
			handler.WriteTo(output, options);
		}
	}

	protected override InstructionFlags ComputeFlags()
	{
		InstructionFlags instructionFlags = base.TryBlock.Flags;
		foreach (TryCatchHandler handler in Handlers)
		{
			instructionFlags = SemanticHelper.CombineBranches(instructionFlags, handler.Flags);
		}
		return instructionFlags | InstructionFlags.ControlFlow;
	}

	protected override int GetChildCount()
	{
		return checked(1 + Handlers.Count);
	}

	protected override ILInstruction GetChild(int index)
	{
		if (index == 0)
		{
			return base.TryBlock;
		}
		return Handlers[checked(index - 1)];
	}

	protected override void SetChild(int index, ILInstruction value)
	{
		if (index == 0)
		{
			base.TryBlock = value;
		}
		else
		{
			Handlers[checked(index - 1)] = (TryCatchHandler)value;
		}
	}

	protected override SlotInfo GetChildSlot(int index)
	{
		if (index == 0)
		{
			return TryInstruction.TryBlockSlot;
		}
		return HandlerSlot;
	}
}
