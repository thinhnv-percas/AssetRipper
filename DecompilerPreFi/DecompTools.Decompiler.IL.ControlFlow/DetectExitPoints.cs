#define DEBUG
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using DecompTools.Decompiler.IL.Transforms;

namespace DecompTools.Decompiler.IL.ControlFlow;

public class DetectExitPoints : ILVisitor, IILTransform
{
	private static readonly Nop ExitNotYetDetermined = new Nop
	{
		Comment = "ExitNotYetDetermined"
	};

	private static readonly Nop NoExit = new Nop
	{
		Comment = "NoExit"
	};

	private bool canIntroduceExitForReturn;

	private CancellationToken cancellationToken;

	private BlockContainer currentContainer;

	private ILInstruction currentExit;

	private List<ILInstruction> potentialExits;

	private readonly List<Block> blocksPotentiallyMadeUnreachable = new List<Block>();

	public DetectExitPoints(bool canIntroduceExitForReturn)
	{
		this.canIntroduceExitForReturn = canIntroduceExitForReturn;
	}

	internal static ILInstruction GetExit(ILInstruction inst)
	{
		SlotInfo slotInfo = inst.SlotInfo;
		if (slotInfo == Block.InstructionSlot)
		{
			Block block = (Block)inst.Parent;
			return block.Instructions.ElementAtOrDefault(checked(inst.ChildIndex + 1)) ?? ExitNotYetDetermined;
		}
		if (slotInfo == TryInstruction.TryBlockSlot || slotInfo == TryCatchHandler.BodySlot || slotInfo == TryCatch.HandlerSlot || slotInfo == PinnedRegion.BodySlot)
		{
			return GetExit(inst.Parent);
		}
		return NoExit;
	}

	internal static bool CompatibleExitInstruction(ILInstruction exit1, ILInstruction exit2)
	{
		if (exit1 == null || exit2 == null || exit1.OpCode != exit2.OpCode)
		{
			return false;
		}
		switch (exit1.OpCode)
		{
		case OpCode.Branch:
		{
			Branch branch = (Branch)exit1;
			Branch branch2 = (Branch)exit2;
			return branch.TargetBlock == branch2.TargetBlock;
		}
		case OpCode.Leave:
		{
			Leave leave = (Leave)exit1;
			Leave leave2 = (Leave)exit2;
			return leave.TargetContainer == leave2.TargetContainer && leave.Value.MatchNop() && leave2.Value.MatchNop();
		}
		default:
			return false;
		}
	}

	public void Run(ILFunction function, ILTransformContext context)
	{
		cancellationToken = context.CancellationToken;
		currentExit = NoExit;
		blocksPotentiallyMadeUnreachable.Clear();
		function.AcceptVisitor(this);
		foreach (Block item in blocksPotentiallyMadeUnreachable)
		{
			if (item.IncomingEdgeCount == 0 || (item.IncomingEdgeCount == 1 && IsInfiniteLoop(item)))
			{
				item.Remove();
			}
		}
		blocksPotentiallyMadeUnreachable.Clear();
	}

	private static bool IsInfiniteLoop(Block block)
	{
		return block.Instructions.Count == 1 && block.Instructions[0] is Branch branch && branch.TargetBlock == block;
	}

	protected override void Default(ILInstruction inst)
	{
		foreach (ILInstruction child in inst.Children)
		{
			child.AcceptVisitor(this);
		}
	}

	protected internal override void VisitBlockContainer(BlockContainer container)
	{
		ILInstruction iLInstruction = currentExit;
		BlockContainer blockContainer = currentContainer;
		List<ILInstruction> list = potentialExits;
		ILInstruction iLInstruction2 = (currentExit = GetExit(container));
		currentContainer = container;
		potentialExits = ((iLInstruction2 == ExitNotYetDetermined) ? new List<ILInstruction>() : null);
		base.VisitBlockContainer(container);
		if (iLInstruction2 == ExitNotYetDetermined && potentialExits.Count > 0)
		{
			currentExit = ChooseExit(potentialExits);
			foreach (ILInstruction potentialExit in potentialExits)
			{
				if (CompatibleExitInstruction(currentExit, potentialExit))
				{
					potentialExit.ReplaceWith(new Leave(currentContainer).WithILRange(potentialExit));
				}
			}
			Debug.Assert(!currentExit.MatchLeave(currentContainer));
			ILInstruction iLInstruction3 = container;
			while (iLInstruction3.Parent.OpCode != OpCode.Block)
			{
				iLInstruction3 = iLInstruction3.Parent;
			}
			Block block = (Block)iLInstruction3.Parent;
			if (block.HasFlag(InstructionFlags.EndPointUnreachable))
			{
				if (currentExit is Branch branch)
				{
					blocksPotentiallyMadeUnreachable.Add(branch.TargetBlock);
				}
			}
			else
			{
				block.Instructions.Add(currentExit);
			}
		}
		else
		{
			Debug.Assert(iLInstruction2 == currentExit);
		}
		currentExit = iLInstruction;
		currentContainer = blockContainer;
		potentialExits = list;
	}

	private static ILInstruction ChooseExit(List<ILInstruction> potentialExits)
	{
		ILInstruction iLInstruction = potentialExits[0];
		if (iLInstruction is Leave { IsLeavingFunction: not false })
		{
			for (int i = 1; i < potentialExits.Count; i = checked(i + 1))
			{
				ILInstruction iLInstruction2 = potentialExits[i];
				if (!(iLInstruction2 is Leave { IsLeavingFunction: not false }))
				{
					return iLInstruction2;
				}
			}
		}
		return iLInstruction;
	}

	protected internal override void VisitBlock(Block block)
	{
		cancellationToken.ThrowIfCancellationRequested();
		for (int i = 0; i < block.Instructions.Count; i = checked(i + 1))
		{
			block.Instructions[i].AcceptVisitor(this);
		}
	}

	private void HandleExit(ILInstruction inst)
	{
		if (currentExit == ExitNotYetDetermined && CanIntroduceAsExit(inst))
		{
			potentialExits.Add(inst);
		}
		else if (CompatibleExitInstruction(inst, currentExit))
		{
			inst.ReplaceWith(new Leave(currentContainer).WithILRange(inst));
		}
	}

	private bool CanIntroduceAsExit(ILInstruction inst)
	{
		if (currentContainer.LeaveCount > 0)
		{
			return false;
		}
		if (inst is Leave { IsLeavingFunction: not false })
		{
			return canIntroduceExitForReturn;
		}
		return true;
	}

	protected internal override void VisitBranch(Branch inst)
	{
		if (!inst.TargetBlock.IsDescendantOf(currentContainer))
		{
			HandleExit(inst);
		}
	}

	protected internal override void VisitLeave(Leave inst)
	{
		base.VisitLeave(inst);
		if (inst.Value.MatchNop())
		{
			HandleExit(inst);
		}
	}
}
