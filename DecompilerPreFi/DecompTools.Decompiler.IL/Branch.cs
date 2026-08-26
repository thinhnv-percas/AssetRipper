#define DEBUG
using System;
using System.Diagnostics;
using DecompTools.Decompiler.IL.Patterns;

namespace DecompTools.Decompiler.IL;

public sealed class Branch : SimpleInstruction, IBranchOrLeaveInstruction
{
	private readonly int targetILOffset;

	private Block targetBlock;

	public override StackType ResultType => StackType.Void;

	public override InstructionFlags DirectFlags => InstructionFlags.MayBranch | InstructionFlags.EndPointUnreachable;

	public int TargetILOffset => (targetBlock != null) ? targetBlock.StartILOffset : targetILOffset;

	public Block TargetBlock
	{
		get
		{
			return targetBlock;
		}
		set
		{
			checked
			{
				if (targetBlock != null && base.IsConnected)
				{
					targetBlock.IncomingEdgeCount--;
				}
				targetBlock = value;
				if (targetBlock != null && base.IsConnected)
				{
					targetBlock.IncomingEdgeCount++;
				}
			}
		}
	}

	public BlockContainer TargetContainer => (BlockContainer)(targetBlock?.Parent);

	public string TargetLabel => (targetBlock != null) ? targetBlock.Label : $"IL_{TargetILOffset:x4}";

	public bool TriggersFinallyBlock => GetExecutesFinallyBlock(this, TargetContainer);

	protected override InstructionFlags ComputeFlags()
	{
		return InstructionFlags.MayBranch | InstructionFlags.EndPointUnreachable;
	}

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitBranch(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitBranch(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitBranch(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is Branch branch && TargetBlock == branch.TargetBlock;
	}

	public Branch(int targetILOffset)
		: base(OpCode.Branch)
	{
		this.targetILOffset = targetILOffset;
	}

	public Branch(Block targetBlock)
		: base(OpCode.Branch)
	{
		this.targetBlock = targetBlock ?? throw new ArgumentNullException("targetBlock");
		targetILOffset = targetBlock.StartILOffset;
	}

	protected override void Connected()
	{
		base.Connected();
		checked
		{
			if (targetBlock != null)
			{
				targetBlock.IncomingEdgeCount++;
			}
		}
	}

	protected override void Disconnected()
	{
		base.Disconnected();
		checked
		{
			if (targetBlock != null)
			{
				targetBlock.IncomingEdgeCount--;
			}
		}
	}

	internal static bool GetExecutesFinallyBlock(ILInstruction inst, BlockContainer container)
	{
		while (inst != container)
		{
			if (inst.Parent is TryFinally && inst.SlotInfo == TryInstruction.TryBlockSlot)
			{
				return true;
			}
			inst = inst.Parent;
		}
		return false;
	}

	internal override void CheckInvariant(ILPhase phase)
	{
		base.CheckInvariant(phase);
		if (phase > ILPhase.InILReader)
		{
			Debug.Assert(targetBlock.Parent is BlockContainer);
			Debug.Assert(IsDescendantOf(targetBlock.Parent));
			Debug.Assert(targetBlock.Parent.Children[targetBlock.ChildIndex] == targetBlock);
		}
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.Write(OpCode);
		output.Write(' ');
		output.WriteLocalReference(TargetLabel, targetBlock ?? ((object)TargetILOffset));
	}
}
