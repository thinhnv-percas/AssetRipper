#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DecompTools.Decompiler.IL.Patterns;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.IL;

public sealed class BlockContainer : ILInstruction
{
	public static readonly SlotInfo BlockSlot = new SlotInfo("Block", canInlineInto: false, isCollection: true);

	public readonly InstructionCollection<Block> Blocks;

	private int leaveCount;

	private Block entryPoint;

	public override StackType ResultType => ExpectedResultType;

	public ContainerKind Kind { get; set; }

	public StackType ExpectedResultType { get; set; }

	public int LeaveCount
	{
		get
		{
			return leaveCount;
		}
		internal set
		{
			leaveCount = value;
			InvalidateFlags();
		}
	}

	public Block EntryPoint
	{
		get
		{
			return entryPoint;
		}
		private set
		{
			checked
			{
				if (entryPoint != null && base.IsConnected)
				{
					entryPoint.IncomingEdgeCount--;
				}
				entryPoint = value;
				if (entryPoint != null && base.IsConnected)
				{
					entryPoint.IncomingEdgeCount++;
				}
			}
		}
	}

	public override InstructionFlags DirectFlags => InstructionFlags.ControlFlow;

	public override void AcceptVisitor(ILVisitor visitor)
	{
		visitor.VisitBlockContainer(this);
	}

	public override T AcceptVisitor<T>(ILVisitor<T> visitor)
	{
		return visitor.VisitBlockContainer(this);
	}

	public override T AcceptVisitor<C, T>(ILVisitor<C, T> visitor, C context)
	{
		return visitor.VisitBlockContainer(this, context);
	}

	protected internal override bool PerformMatch(ILInstruction other, ref Match match)
	{
		return other is BlockContainer blockContainer && ListMatch.DoMatch(Blocks, blockContainer.Blocks, ref match);
	}

	public BlockContainer(ContainerKind kind = ContainerKind.Normal, StackType expectedResultType = StackType.Void)
		: base(OpCode.BlockContainer)
	{
		Kind = kind;
		Blocks = new InstructionCollection<Block>(this, 0);
		ExpectedResultType = expectedResultType;
	}

	public override ILInstruction Clone()
	{
		BlockContainer blockContainer = new BlockContainer();
		blockContainer.AddILRange(this);
		blockContainer.Blocks.AddRange(Enumerable.Select<Block, Block>((IEnumerable<Block>)Blocks, (Func<Block, Block>)((Block block) => (Block)block.Clone())));
		foreach (Branch item in Enumerable.OfType<Branch>((IEnumerable)blockContainer.Descendants))
		{
			if (item.TargetBlock != null && item.TargetBlock.Parent == this)
			{
				item.TargetBlock = blockContainer.Blocks[item.TargetBlock.ChildIndex];
			}
		}
		foreach (Leave item2 in Enumerable.OfType<Leave>((IEnumerable)blockContainer.Descendants))
		{
			if (item2.TargetContainer == this)
			{
				item2.TargetContainer = blockContainer;
			}
		}
		return blockContainer;
	}

	protected internal override void InstructionCollectionUpdateComplete()
	{
		base.InstructionCollectionUpdateComplete();
		EntryPoint = Blocks.FirstOrDefault();
	}

	protected override void Connected()
	{
		base.Connected();
		checked
		{
			if (entryPoint != null)
			{
				entryPoint.IncomingEdgeCount++;
			}
		}
	}

	protected override void Disconnected()
	{
		base.Disconnected();
		checked
		{
			if (entryPoint != null)
			{
				entryPoint.IncomingEdgeCount--;
			}
		}
	}

	public override void WriteTo(ITextOutput output, ILAstWritingOptions options)
	{
		WriteILRange(output, options);
		output.WriteLocalReference("BlockContainer", this, isDefinition: true);
		output.Write(' ');
		switch (Kind)
		{
		case ContainerKind.Loop:
			output.Write("(while-true) ");
			break;
		case ContainerKind.Switch:
			output.Write("(switch) ");
			break;
		case ContainerKind.While:
			output.Write("(while) ");
			break;
		case ContainerKind.DoWhile:
			output.Write("(do-while) ");
			break;
		case ContainerKind.For:
			output.Write("(for) ");
			break;
		}
		output.MarkFoldStart("{...}");
		output.WriteLine("{");
		output.Indent();
		foreach (Block block in Blocks)
		{
			if (block.Parent == this)
			{
				block.WriteTo(output, options);
			}
			else
			{
				output.Write("stale reference to ");
				output.WriteLocalReference(block.Label, block);
			}
			output.WriteLine();
			output.WriteLine();
		}
		output.Unindent();
		output.Write("}");
		output.MarkFoldEnd();
	}

	protected override int GetChildCount()
	{
		return Blocks.Count;
	}

	protected override ILInstruction GetChild(int index)
	{
		return Blocks[index];
	}

	protected override void SetChild(int index, ILInstruction value)
	{
		if (Blocks[index] != value)
		{
			throw new InvalidOperationException("Cannot replace blocks in BlockContainer");
		}
	}

	protected override SlotInfo GetChildSlot(int index)
	{
		return BlockSlot;
	}

	internal override void CheckInvariant(ILPhase phase)
	{
		base.CheckInvariant(phase);
		Debug.Assert(Blocks.Count > 0 && EntryPoint == Blocks[0]);
		int condition;
		if (base.IsConnected)
		{
			Block block = EntryPoint;
			condition = ((block != null && block.IncomingEdgeCount >= 1) ? 1 : 0);
		}
		else
		{
			condition = 1;
		}
		Debug.Assert((byte)condition != 0);
		Debug.Assert(EntryPoint == null || base.Parent is ILFunction || !base.HasILRange);
		Debug.Assert(Enumerable.All<Block>((IEnumerable<Block>)Blocks, (Func<Block, bool>)((Block b) => b.HasFlag(InstructionFlags.EndPointUnreachable))));
		Debug.Assert(Enumerable.All<Block>((IEnumerable<Block>)Blocks, (Func<Block, bool>)((Block b) => b.Kind == BlockKind.ControlFlow)));
		ILInstruction condition2;
		Block bodyStartBlock;
		switch (Kind)
		{
		case ContainerKind.Normal:
			break;
		case ContainerKind.Loop:
			Debug.Assert(EntryPoint.IncomingEdgeCount > 1);
			break;
		case ContainerKind.Switch:
			Debug.Assert(EntryPoint.Instructions.Count == 1);
			Debug.Assert(EntryPoint.Instructions[0] is SwitchInstruction);
			Debug.Assert(EntryPoint.IncomingEdgeCount == 1);
			break;
		case ContainerKind.While:
			Debug.Assert(EntryPoint.IncomingEdgeCount > 1);
			Debug.Assert(Blocks.Count >= 2);
			Debug.Assert(MatchConditionBlock(EntryPoint, out condition2, out bodyStartBlock));
			Debug.Assert(bodyStartBlock == Blocks[1]);
			break;
		case ContainerKind.DoWhile:
			Debug.Assert(EntryPoint.IncomingEdgeCount > 1);
			Debug.Assert(Blocks.Count >= 2);
			Debug.Assert(MatchConditionBlock(Blocks.Last(), out condition2, out bodyStartBlock));
			Debug.Assert(bodyStartBlock == EntryPoint);
			break;
		case ContainerKind.For:
			Debug.Assert(EntryPoint.IncomingEdgeCount == 2);
			Debug.Assert(Blocks.Count >= 3);
			Debug.Assert(MatchConditionBlock(EntryPoint, out condition2, out bodyStartBlock));
			Debug.Assert(MatchIncrementBlock(Blocks.Last()));
			Debug.Assert(bodyStartBlock == Blocks[1]);
			break;
		}
	}

	protected override InstructionFlags ComputeFlags()
	{
		InstructionFlags instructionFlags = InstructionFlags.ControlFlow;
		foreach (Block block in Blocks)
		{
			instructionFlags |= block.Flags;
		}
		if (LeaveCount == 0)
		{
			return instructionFlags | InstructionFlags.EndPointUnreachable;
		}
		return instructionFlags & ~InstructionFlags.EndPointUnreachable;
	}

	public void SortBlocks(bool deleteUnreachableBlocks = false)
	{
		if (Blocks.Count < 2)
		{
			return;
		}
		BitSet visited = new BitSet(Blocks.Count);
		List<Block> postOrder = new List<Block>();
		Action<Block> visit = null;
		visit = delegate(Block block)
		{
			Debug.Assert(block.Parent == this);
			if (!visited[block.ChildIndex])
			{
				visited[block.ChildIndex] = true;
				foreach (Branch item in Enumerable.OfType<Branch>((IEnumerable)block.Descendants))
				{
					if (item.TargetBlock.Parent == this)
					{
						visit(item.TargetBlock);
					}
				}
				postOrder.Add(block);
			}
		};
		visit(EntryPoint);
		postOrder.Reverse();
		if (!deleteUnreachableBlocks)
		{
			for (int num = 0; num < Blocks.Count; num = checked(num + 1))
			{
				if (!visited[num])
				{
					postOrder.Add(Blocks[num]);
				}
			}
		}
		Debug.Assert(postOrder[0] == Blocks[0]);
		Blocks.ReplaceList(postOrder);
	}

	public static BlockContainer FindClosestContainer(ILInstruction inst)
	{
		while (inst != null)
		{
			if (inst is BlockContainer result)
			{
				return result;
			}
			inst = inst.Parent;
		}
		return null;
	}

	public static BlockContainer FindClosestSwitchContainer(ILInstruction inst)
	{
		while (inst != null)
		{
			if (inst is BlockContainer blockContainer && blockContainer.entryPoint.Instructions.FirstOrDefault() is SwitchInstruction)
			{
				return blockContainer;
			}
			inst = inst.Parent;
		}
		return null;
	}

	public bool MatchConditionBlock(Block block, out ILInstruction condition, out Block bodyStartBlock)
	{
		condition = null;
		bodyStartBlock = null;
		if (block.Instructions.Count != 1)
		{
			return false;
		}
		if (!block.Instructions[0].MatchIfInstruction(out condition, out var trueInst, out var falseInst))
		{
			return false;
		}
		return falseInst.MatchLeave(this) && trueInst.MatchBranch(out bodyStartBlock);
	}

	public bool MatchIncrementBlock(Block block)
	{
		if (block.Instructions.Count == 0)
		{
			return false;
		}
		if (!block.Instructions.Last().MatchBranch(EntryPoint))
		{
			return false;
		}
		return true;
	}

	public ILInstruction SingleInstruction()
	{
		if (Blocks.Count != 1)
		{
			return this;
		}
		if (Blocks[0].Instructions.Count != 1)
		{
			return Blocks[0];
		}
		return Blocks[0].Instructions[0];
	}
}
