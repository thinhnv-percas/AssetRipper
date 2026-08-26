#define DEBUG
#define STEP
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DecompTools.Decompiler.Disassembler;
using DecompTools.Decompiler.IL.Patterns;
using DecompTools.Decompiler.IL.Transforms;

namespace DecompTools.Decompiler.IL;

public sealed class Block : ILInstruction
{
	public static readonly SlotInfo InstructionSlot = new SlotInfo("Instruction", canInlineInto: false, isCollection: true);

	public static readonly SlotInfo FinalInstructionSlot = new SlotInfo("FinalInstruction");

	public readonly BlockKind Kind;

	public readonly InstructionCollection<ILInstruction> Instructions;

	private ILInstruction finalInstruction;

	public int IncomingEdgeCount { get; internal set; }

	public ILInstruction FinalInstruction
	{
		get
		{
			return finalInstruction;
		}
		set
		{
			ValidateChild(value);
			SetChildInstruction(ref finalInstruction, value, Instructions.Count);
		}
	}

	public override StackType ResultType => finalInstruction.ResultType;

	public string Label => DisassemblerHelpers.OffsetToString(base.StartILOffset);

	public override InstructionFlags DirectFlags => InstructionFlags.None;

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitBlock(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitBlock(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitBlock(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is Block block && Kind == block.Kind && ListMatch.DoMatch(Instructions, block.Instructions, ref match) && FinalInstruction.PerformMatch(block.FinalInstruction, ref match);
	}

	protected internal override void InstructionCollectionUpdateComplete()
	{
		base.InstructionCollectionUpdateComplete();
		if (finalInstruction.Parent == this)
		{
			finalInstruction.ChildIndex = Instructions.Count;
		}
	}

	public Block(BlockKind kind = BlockKind.ControlFlow)
		: base(OpCode.Block)
	{
		Kind = kind;
		Instructions = new InstructionCollection<ILInstruction>(this, 0);
		FinalInstruction = new Nop();
	}

	public override ILInstruction Clone()
	{
		Block block = new Block(Kind);
		block.AddILRange(this);
		block.Instructions.AddRange(Enumerable.Select<ILInstruction, ILInstruction>((IEnumerable<ILInstruction>)Instructions, (Func<ILInstruction, ILInstruction>)((ILInstruction inst) => inst.Clone())));
		block.FinalInstruction = FinalInstruction.Clone();
		return block;
	}

	internal override void CheckInvariant(ILPhase phase)
	{
		base.CheckInvariant(phase);
		checked
		{
			for (int i = 0; i < Instructions.Count - 1; i++)
			{
				Debug.Assert(!Instructions[i].HasFlag(InstructionFlags.EndPointUnreachable));
			}
			switch (Kind)
			{
			case BlockKind.ControlFlow:
				Debug.Assert(finalInstruction.OpCode == OpCode.Nop);
				break;
			case BlockKind.CallInlineAssign:
			{
				Debug.Assert(MatchInlineAssignBlock(out var _, out var _));
				break;
			}
			case BlockKind.CallWithNamedArgs:
			{
				Debug.Assert(finalInstruction is CallInstruction);
				foreach (ILInstruction instruction in Instructions)
				{
					StLoc stLoc = instruction as StLoc;
					Debug.Assert(stLoc != null, "Instructions in CallWithNamedArgs must be assignments");
					Debug.Assert(stLoc.Variable.Kind == VariableKind.NamedArgument);
					Debug.Assert(stLoc.Variable.IsSingleDefinition && stLoc.Variable.LoadCount == 1);
					Debug.Assert(Enumerable.Single<LdLoc>((IEnumerable<LdLoc>)stLoc.Variable.LoadInstructions).Parent == finalInstruction);
				}
				CallInstruction callInstruction = (CallInstruction)finalInstruction;
				if (callInstruction.IsInstanceCall)
				{
					ILVariable variable = ((StLoc)Instructions[0]).Variable;
					Debug.Assert(callInstruction.Arguments[0].MatchLdLoc(variable));
				}
				break;
			}
			}
		}
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write("Block ");
		output.WriteLocalReference(Label, this, isDefinition: true);
		if (Kind != BlockKind.ControlFlow)
		{
			output.Write($" ({Kind})");
		}
		if (base.Parent is BlockContainer)
		{
			output.Write(" (incoming: {0})", IncomingEdgeCount);
		}
		output.Write(' ');
		output.MarkFoldStart("{...}");
		output.WriteLine("{");
		output.Indent();
		int num = 0;
		foreach (ILInstruction instruction in Instructions)
		{
			if (options.ShowChildIndexInBlock)
			{
				output.Write("[" + num + "] ");
				num = checked(num + 1);
			}
			instruction.WriteTo(output, options);
			output.WriteLine();
		}
		if (finalInstruction.OpCode != OpCode.Nop)
		{
			output.Write("final: ");
			finalInstruction.WriteTo(output, options);
			output.WriteLine();
		}
		output.Unindent();
		output.Write("}");
		output.MarkFoldEnd();
	}

	protected override int GetChildCount()
	{
		return checked(Instructions.Count + 1);
	}

	protected override ILInstruction GetChild(int index)
	{
		if (index == Instructions.Count)
		{
			return finalInstruction;
		}
		return Instructions[index];
	}

	protected override void SetChild(int index, ILInstruction value)
	{
		if (index == Instructions.Count)
		{
			FinalInstruction = value;
		}
		else
		{
			Instructions[index] = value;
		}
	}

	protected override SlotInfo GetChildSlot(int index)
	{
		if (index == Instructions.Count)
		{
			return FinalInstructionSlot;
		}
		return InstructionSlot;
	}

	protected override InstructionFlags ComputeFlags()
	{
		InstructionFlags instructionFlags = InstructionFlags.None;
		foreach (ILInstruction instruction in Instructions)
		{
			instructionFlags |= instruction.Flags;
		}
		return instructionFlags | FinalInstruction.Flags;
	}

	public void Remove()
	{
		Debug.Assert(base.ChildIndex > 0);
		BlockContainer blockContainer = (BlockContainer)base.Parent;
		Debug.Assert(blockContainer.Blocks[base.ChildIndex] == this);
		blockContainer.Blocks.SwapRemoveAt(base.ChildIndex);
	}

	public void RunTransforms(IEnumerable<IBlockTransform> transforms, BlockTransformContext context)
	{
		CheckInvariant(ILPhase.Normal);
		foreach (IBlockTransform transform in transforms)
		{
			context.CancellationToken.ThrowIfCancellationRequested();
			context.StepStartGroup(transform.GetType().Name);
			transform.Run(this, context);
			CheckInvariant(ILPhase.Normal);
			context.StepEndGroup();
		}
	}

	public static ILInstruction GetPredecessor(ILInstruction inst)
	{
		if (inst.Parent is Block block && inst.ChildIndex > 0)
		{
			return block.Instructions[checked(inst.ChildIndex - 1)];
		}
		return null;
	}

	public static ILInstruction Unwrap(ILInstruction inst)
	{
		if (inst is Block block && block.Instructions.Count == 1 && block.finalInstruction.MatchNop())
		{
			return block.Instructions[0];
		}
		return inst;
	}

	public bool MatchInlineAssignBlock(out CallInstruction call, out ILInstruction value)
	{
		call = null;
		value = null;
		if (Kind != BlockKind.CallInlineAssign)
		{
			return false;
		}
		if (Instructions.Count != 1)
		{
			return false;
		}
		call = Instructions[0] as CallInstruction;
		if (call == null || call.Arguments.Count == 0)
		{
			return false;
		}
		if (!call.Arguments.Last().MatchStLoc(out var variable, out value))
		{
			return false;
		}
		if (!variable.IsSingleDefinition || variable.LoadCount != 1)
		{
			return false;
		}
		return FinalInstruction.MatchLdLoc(variable);
	}
}
