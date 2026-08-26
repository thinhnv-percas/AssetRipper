#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using DecompTools.Decompiler.IL;

namespace DecompTools.Decompiler.FlowAnalysis;

public abstract class DataFlowVisitor<State> : ILVisitor where State : IDataFlowState<State>
{
	private State bottomState;

	protected State state;

	protected State currentStateOnException;

	private bool initialized;

	private readonly Dictionary<ILInstruction, State> debugInputState = new Dictionary<ILInstruction, State>();

	private readonly Dictionary<ILInstruction, State> debugOutputState = new Dictionary<ILInstruction, State>();

	protected InstructionFlags flagsRequiringManualImpl = InstructionFlags.MayBranch | InstructionFlags.MayUnwrapNull | InstructionFlags.EndPointUnreachable | InstructionFlags.ControlFlow;

	private readonly Dictionary<Block, State> stateOnBranch = new Dictionary<Block, State>();

	private readonly Dictionary<BlockContainer, State> stateOnLeave = new Dictionary<BlockContainer, State>();

	private readonly Dictionary<BlockContainer, SortedSet<int>> workLists = new Dictionary<BlockContainer, SortedSet<int>>();

	private readonly List<(IBranchOrLeaveInstruction, State)> branchesTriggeringFinally = new List<(IBranchOrLeaveInstruction, State)>();

	private readonly Dictionary<TryInstruction, State> stateOnException = new Dictionary<TryInstruction, State>();

	protected void Initialize(State initialState)
	{
		Debug.Assert(!initialized);
		initialized = true;
		state = initialState.Clone();
		bottomState = initialState.Clone();
		bottomState.ReplaceWithBottom();
		Debug.Assert(bottomState.IsBottom);
		currentStateOnException = state.Clone();
	}

	private void DebugPoint(Dictionary<ILInstruction, State> debugDict, ILInstruction inst)
	{
		Debug.Assert(initialized, "Initialize() was not called");
		if (debugDict.TryGetValue(inst, out var value))
		{
			State otherState = state;
			Debug.Assert(value.LessThanOrEqual(otherState));
		}
		else if (debugDict.Count < 1000)
		{
			debugDict.Add(inst, state.Clone());
		}
		ref State reference = ref state;
		State otherState2 = currentStateOnException;
		Debug.Assert(reference.LessThanOrEqual(otherState2));
	}

	[Conditional("DEBUG")]
	private void DebugStartPoint(ILInstruction inst)
	{
		DebugPoint(debugInputState, inst);
	}

	[Conditional("DEBUG")]
	private void DebugEndPoint(ILInstruction inst)
	{
		DebugPoint(debugOutputState, inst);
	}

	protected sealed override void Default(ILInstruction inst)
	{
		DebugStartPoint(inst);
		if ((inst.DirectFlags & flagsRequiringManualImpl) != InstructionFlags.None)
		{
			throw new NotImplementedException(GetType().Name + " is missing implementation for " + inst.GetType().Name);
		}
		foreach (ILInstruction child in inst.Children)
		{
			child.AcceptVisitor(this);
			Debug.Assert(state.IsBottom || !child.HasFlag(InstructionFlags.EndPointUnreachable), "Unreachable code must be in the bottom state.");
		}
		DebugEndPoint(inst);
	}

	protected void PropagateStateOnException()
	{
		ref State reference = ref currentStateOnException;
		State incomingState = state;
		reference.JoinWith(incomingState);
	}

	protected void MarkUnreachable()
	{
		state.ReplaceWithBottom();
	}

	private State GetBlockInputState(Block block)
	{
		if (stateOnBranch.TryGetValue(block, out var value))
		{
			return value;
		}
		value = bottomState.Clone();
		stateOnBranch.Add(block, value);
		return value;
	}

	protected internal override void VisitBlockContainer(BlockContainer container)
	{
		DebugStartPoint(container);
		SortedSet<int> val = new SortedSet<int>();
		workLists.Add(container, val);
		State blockInputState = GetBlockInputState(container.EntryPoint);
		ref State reference = ref state;
		State otherState = blockInputState;
		if (!reference.LessThanOrEqual(otherState))
		{
			blockInputState.JoinWith(state);
			val.Add(0);
		}
		while (val.Count > 0)
		{
			int min = val.Min;
			val.Remove(min);
			Block block = container.Blocks[min];
			ref State reference2 = ref state;
			State newContent = stateOnBranch[block];
			reference2.ReplaceWith(newContent);
			block.AcceptVisitor(this);
		}
		if (stateOnLeave.TryGetValue(container, out var value))
		{
			ref State reference3 = ref state;
			State newContent2 = value;
			reference3.ReplaceWith(newContent2);
		}
		else
		{
			MarkUnreachable();
		}
		DebugEndPoint(container);
		workLists.Remove(container);
	}

	protected internal override void VisitBranch(Branch inst)
	{
		if (inst.TriggersFinallyBlock)
		{
			ref State reference = ref state;
			State otherState = currentStateOnException;
			Debug.Assert(reference.LessThanOrEqual(otherState));
			branchesTriggeringFinally.Add((inst, state.Clone()));
		}
		else
		{
			MergeBranchStateIntoTargetBlock(inst, state);
		}
		MarkUnreachable();
	}

	private void MergeBranchStateIntoTargetBlock(Branch inst, State branchState)
	{
		Block targetBlock = inst.TargetBlock;
		State blockInputState = GetBlockInputState(targetBlock);
		if (!branchState.LessThanOrEqual(blockInputState))
		{
			blockInputState.JoinWith(branchState);
			BlockContainer key = (BlockContainer)targetBlock.Parent;
			workLists[key].Add(targetBlock.ChildIndex);
		}
	}

	protected internal override void VisitLeave(Leave inst)
	{
		inst.Value.AcceptVisitor(this);
		if (inst.TriggersFinallyBlock)
		{
			ref State reference = ref state;
			State otherState = currentStateOnException;
			Debug.Assert(reference.LessThanOrEqual(otherState));
			branchesTriggeringFinally.Add((inst, state.Clone()));
		}
		else
		{
			MergeBranchStateIntoStateOnLeave(inst, state);
		}
		MarkUnreachable();
	}

	private void MergeBranchStateIntoStateOnLeave(Leave inst, State branchState)
	{
		if (stateOnLeave.TryGetValue(inst.TargetContainer, out var value))
		{
			State incomingState = branchState;
			value.JoinWith(incomingState);
		}
		else
		{
			stateOnLeave.Add(inst.TargetContainer, branchState.Clone());
		}
	}

	protected internal override void VisitThrow(Throw inst)
	{
		inst.Argument.AcceptVisitor(this);
		MarkUnreachable();
	}

	protected internal override void VisitRethrow(Rethrow inst)
	{
		MarkUnreachable();
	}

	protected internal override void VisitInvalidBranch(InvalidBranch inst)
	{
		MarkUnreachable();
	}

	protected State HandleTryBlock(TryInstruction inst)
	{
		State val = currentStateOnException;
		if (stateOnException.TryGetValue(inst, out var value))
		{
			State incomingState = state;
			value.JoinWith(incomingState);
		}
		else
		{
			value = state.Clone();
			stateOnException.Add(inst, value);
		}
		currentStateOnException = value;
		inst.TryBlock.AcceptVisitor(this);
		currentStateOnException = val;
		val.JoinWith(value);
		return value;
	}

	protected internal override void VisitTryCatch(TryCatch inst)
	{
		DebugStartPoint(inst);
		State val = HandleTryBlock(inst);
		State val2 = state.Clone();
		foreach (TryCatchHandler handler in inst.Handlers)
		{
			ref State reference = ref state;
			State newContent = val;
			reference.ReplaceWith(newContent);
			BeginTryCatchHandler(handler);
			handler.Filter.AcceptVisitor(this);
			val.JoinWith(state);
			handler.Body.AcceptVisitor(this);
			val2.JoinWith(state);
		}
		state = val2;
		DebugEndPoint(inst);
	}

	protected virtual void BeginTryCatchHandler(TryCatchHandler inst)
	{
	}

	protected internal sealed override void VisitTryCatchHandler(TryCatchHandler inst)
	{
		throw new NotSupportedException();
	}

	protected internal override void VisitTryFinally(TryFinally inst)
	{
		DebugStartPoint(inst);
		int count = branchesTriggeringFinally.Count;
		State incomingState = HandleTryBlock(inst);
		State val = state.Clone();
		state.JoinWith(incomingState);
		inst.FinallyBlock.AcceptVisitor(this);
		ref State reference = ref state;
		State otherState = currentStateOnException;
		Debug.Assert(reference.LessThanOrEqual(otherState));
		ProcessBranchesLeavingTryFinally(inst, count);
		val.TriggerFinally(state);
		state = val;
		DebugEndPoint(inst);
	}

	private void ProcessBranchesLeavingTryFinally(TryFinally tryFinally, int branchesTriggeringFinallyOldCount)
	{
		int num = branchesTriggeringFinallyOldCount;
		checked
		{
			for (int i = branchesTriggeringFinallyOldCount; i < branchesTriggeringFinally.Count; i++)
			{
				var (branchOrLeaveInstruction, val) = branchesTriggeringFinally[i];
				Debug.Assert(((ILInstruction)branchOrLeaveInstruction).IsDescendantOf(tryFinally));
				Debug.Assert(tryFinally.IsDescendantOf(branchOrLeaveInstruction.TargetContainer));
				val.TriggerFinally(state);
				if (Branch.GetExecutesFinallyBlock(tryFinally, branchOrLeaveInstruction.TargetContainer))
				{
					branchesTriggeringFinally[num++] = (branchOrLeaveInstruction, val);
				}
				else if (branchOrLeaveInstruction is Leave)
				{
					MergeBranchStateIntoStateOnLeave((Leave)branchOrLeaveInstruction, val);
				}
				else
				{
					MergeBranchStateIntoTargetBlock((Branch)branchOrLeaveInstruction, val);
				}
			}
			branchesTriggeringFinally.RemoveRange(num, branchesTriggeringFinally.Count - num);
		}
	}

	protected internal override void VisitTryFault(TryFault inst)
	{
		DebugStartPoint(inst);
		State val = HandleTryBlock(inst);
		State val2 = state;
		state = val;
		inst.FaultBlock.AcceptVisitor(this);
		ref State reference = ref state;
		State otherState = currentStateOnException;
		Debug.Assert(reference.LessThanOrEqual(otherState));
		state = val2;
		DebugEndPoint(inst);
	}

	protected internal override void VisitIfInstruction(IfInstruction inst)
	{
		DebugStartPoint(inst);
		inst.Condition.AcceptVisitor(this);
		State val = state.Clone();
		inst.TrueInst.AcceptVisitor(this);
		State incomingState = state;
		state = val;
		inst.FalseInst.AcceptVisitor(this);
		state.JoinWith(incomingState);
		DebugEndPoint(inst);
	}

	protected internal override void VisitSwitchInstruction(SwitchInstruction inst)
	{
		DebugStartPoint(inst);
		inst.Value.AcceptVisitor(this);
		State newContent = state.Clone();
		inst.Sections[0].AcceptVisitor(this);
		State val = state.Clone();
		for (int i = 1; i < inst.Sections.Count; i = checked(i + 1))
		{
			state.ReplaceWith(newContent);
			inst.Sections[i].AcceptVisitor(this);
			val.JoinWith(state);
		}
		state = val;
		DebugEndPoint(inst);
	}

	protected internal override void VisitYieldReturn(YieldReturn inst)
	{
		DebugStartPoint(inst);
		inst.Value.AcceptVisitor(this);
		DebugEndPoint(inst);
	}

	protected internal override void VisitILFunction(ILFunction function)
	{
		throw new NotImplementedException();
	}
}
