#define DEBUG
using System.Diagnostics;
using System.Threading;
using DecompTools.Decompiler.IL;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.FlowAnalysis;

internal class DefiniteAssignmentVisitor : DataFlowVisitor<DefiniteAssignmentVisitor.State>
{
	[DebuggerDisplay("{bits}")]
	public struct State : IDataFlowState<State>
	{
		private readonly BitSet bits;

		public bool IsBottom => !bits.Any();

		public State(int variableCount)
		{
			bits = new BitSet(variableCount);
			bits.Set(0, variableCount);
		}

		private State(BitSet bits)
		{
			this.bits = bits;
		}

		public bool LessThanOrEqual(State otherState)
		{
			return bits.IsSubsetOf(otherState.bits);
		}

		public State Clone()
		{
			return new State(bits.Clone());
		}

		public void ReplaceWith(State newContent)
		{
			bits.ReplaceWith(newContent.bits);
		}

		public void JoinWith(State incomingState)
		{
			bits.UnionWith(incomingState.bits);
		}

		public void TriggerFinally(State finallyState)
		{
			bits.IntersectWith(finallyState.bits);
		}

		public void ReplaceWithBottom()
		{
			bits.ClearAll();
		}

		public void MarkVariableInitialized(int variableIndex)
		{
			bits.Clear(variableIndex);
		}

		public bool IsPotentiallyUninitialized(int variableIndex)
		{
			return bits[variableIndex];
		}
	}

	private readonly CancellationToken cancellationToken;

	private readonly ILFunction scope;

	private readonly BitSet variablesWithUninitializedUsage;

	public DefiniteAssignmentVisitor(ILFunction scope, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		this.cancellationToken = cancellationToken;
		this.scope = scope;
		variablesWithUninitializedUsage = new BitSet(scope.Variables.Count);
		flagsRequiringManualImpl |= InstructionFlags.MayReadLocals | InstructionFlags.MayWriteLocals;
		Initialize(new State(scope.Variables.Count));
	}

	public bool IsPotentiallyUsedUninitialized(ILVariable v)
	{
		Debug.Assert(v.Function == scope);
		return variablesWithUninitializedUsage[v.IndexInFunction];
	}

	private void HandleStore(ILVariable v)
	{
		CancellationToken cancellationToken = this.cancellationToken;
		cancellationToken.ThrowIfCancellationRequested();
		if (v.Function == scope)
		{
			state.MarkVariableInitialized(v.IndexInFunction);
		}
	}

	private void EnsureInitialized(ILVariable v)
	{
		if (v.Function == scope && state.IsPotentiallyUninitialized(v.IndexInFunction))
		{
			variablesWithUninitializedUsage.Set(v.IndexInFunction);
		}
	}

	protected internal override void VisitStLoc(StLoc inst)
	{
		inst.Value.AcceptVisitor(this);
		HandleStore(inst.Variable);
	}

	protected override void BeginTryCatchHandler(TryCatchHandler inst)
	{
		HandleStore(inst.Variable);
		base.BeginTryCatchHandler(inst);
	}

	protected internal override void VisitPinnedRegion(PinnedRegion inst)
	{
		inst.Init.AcceptVisitor(this);
		HandleStore(inst.Variable);
		inst.Body.AcceptVisitor(this);
	}

	protected internal override void VisitLdLoc(LdLoc inst)
	{
		EnsureInitialized(inst.Variable);
	}

	protected internal override void VisitLdLoca(LdLoca inst)
	{
		EnsureInitialized(inst.Variable);
	}

	protected internal override void VisitCall(Call inst)
	{
		HandleCall(inst);
	}

	protected internal override void VisitCallVirt(CallVirt inst)
	{
		HandleCall(inst);
	}

	protected internal override void VisitNewObj(NewObj inst)
	{
		HandleCall(inst);
	}

	private void HandleCall(CallInstruction call)
	{
		bool flag = false;
		foreach (ILInstruction argument in call.Arguments)
		{
			if (argument.MatchLdLoca(out var _))
			{
				IParameter parameter = call.GetParameter(argument.ChildIndex);
				if (parameter != null && parameter.IsOut)
				{
					flag = true;
					continue;
				}
			}
			argument.AcceptVisitor(this);
		}
		if (!flag)
		{
			return;
		}
		foreach (ILInstruction argument2 in call.Arguments)
		{
			if (argument2.MatchLdLoca(out var variable2))
			{
				IParameter parameter2 = call.GetParameter(argument2.ChildIndex);
				if (parameter2 != null && parameter2.IsOut)
				{
					HandleStore(variable2);
				}
			}
		}
	}
}
