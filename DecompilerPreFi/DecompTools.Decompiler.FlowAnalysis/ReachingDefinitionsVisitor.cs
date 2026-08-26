#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using DecompTools.Decompiler.IL;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.FlowAnalysis;

internal class ReachingDefinitionsVisitor : DataFlowVisitor<ReachingDefinitionsVisitor.State>
{
	[DebuggerDisplay("{bits}")]
	public struct State : IDataFlowState<State>
	{
		private readonly BitSet bits;

		public bool IsBottom => !bits[0];

		public bool IsReachable => bits[0];

		public State(BitSet bits)
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
			if (IsReachable)
			{
				ReplaceWith(finallyState);
			}
		}

		public void ReplaceWithBottom()
		{
			bits.ClearAll();
		}

		public void KillStores(int startStoreIndex, int endStoreIndex)
		{
			Debug.Assert(startStoreIndex >= 1);
			Debug.Assert(endStoreIndex >= startStoreIndex);
			bits.Clear(startStoreIndex, endStoreIndex);
		}

		public bool IsReachingStore(int storeIndex)
		{
			return bits[storeIndex];
		}

		public void SetStore(int storeIndex)
		{
			Debug.Assert(storeIndex >= 1);
			bits.Set(storeIndex);
		}
	}

	private const int ReachableBit = 0;

	private const int FirstStoreIndex = 1;

	protected readonly CancellationToken cancellationToken;

	protected readonly ILFunction scope;

	private readonly ILInstruction[] allStores;

	private readonly Dictionary<ILInstruction, int> storeIndexMap = new Dictionary<ILInstruction, int>();

	private readonly int[] firstStoreIndexForVariable;

	private readonly BitSet analyzedVariables;

	public ReachingDefinitionsVisitor(ILFunction scope, Predicate<ILVariable> pred, CancellationToken cancellationToken)
		: this(scope, GetActiveVariableBitSet(scope, pred), cancellationToken)
	{
		this.cancellationToken = cancellationToken;
	}

	private static BitSet GetActiveVariableBitSet(ILFunction scope, Predicate<ILVariable> pred)
	{
		if (scope == null)
		{
			throw new ArgumentNullException("scope");
		}
		BitSet bitSet = new BitSet(scope.Variables.Count);
		for (int i = 0; i < scope.Variables.Count; i = checked(i + 1))
		{
			bitSet[i] = pred(scope.Variables[i]);
		}
		return bitSet;
	}

	public ReachingDefinitionsVisitor(ILFunction scope, BitSet analyzedVariables, CancellationToken cancellationToken)
	{
		if (scope == null)
		{
			throw new ArgumentNullException("scope");
		}
		if (analyzedVariables == null)
		{
			throw new ArgumentNullException("analyzedVariables");
		}
		this.scope = scope;
		this.analyzedVariables = analyzedVariables;
		flagsRequiringManualImpl |= InstructionFlags.MayWriteLocals;
		List<ILInstruction>[] array = FindAllStoresByVariable(scope, analyzedVariables, cancellationToken);
		checked
		{
			allStores = new ILInstruction[1 + Enumerable.Sum<List<ILInstruction>>((IEnumerable<List<ILInstruction>>)array, (Func<List<ILInstruction>, int>)((List<ILInstruction> l) => l?.Count ?? 0))];
			firstStoreIndexForVariable = new int[scope.Variables.Count + 1];
			int num = 1;
			for (int num2 = 0; num2 < array.Length; num2++)
			{
				cancellationToken.ThrowIfCancellationRequested();
				firstStoreIndexForVariable[num2] = num;
				List<ILInstruction> list = array[num2];
				if (list != null)
				{
					int num3 = scope.Variables[num2].StoreCount;
					if (!scope.Variables[num2].HasInitialValue)
					{
						num3++;
					}
					Debug.Assert(list.Count == num3);
					list.CopyTo(allStores, num);
					for (int num4 = 1; num4 < list.Count; num4++)
					{
						storeIndexMap.Add(list[num4], num + num4);
					}
					num += list.Count;
				}
			}
			firstStoreIndexForVariable[scope.Variables.Count] = num;
			Debug.Assert(num == allStores.Length);
			Initialize(CreateInitialState());
		}
	}

	private static List<ILInstruction>[] FindAllStoresByVariable(ILFunction scope, BitSet activeVariables, CancellationToken cancellationToken)
	{
		List<ILInstruction>[] array = new List<ILInstruction>[scope.Variables.Count];
		for (int i = 0; i < array.Length; i = checked(i + 1))
		{
			if (activeVariables[i])
			{
				array[i] = new List<ILInstruction> { null };
			}
		}
		foreach (ILInstruction descendant in scope.Descendants)
		{
			if (descendant.HasDirectFlag(InstructionFlags.MayWriteLocals))
			{
				cancellationToken.ThrowIfCancellationRequested();
				ILVariable variable = ((IInstructionWithVariableOperand)descendant).Variable;
				if (variable.Function == scope && activeVariables[variable.IndexInFunction])
				{
					array[variable.IndexInFunction].Add(descendant);
				}
			}
		}
		return array;
	}

	private State CreateInitialState()
	{
		BitSet bitSet = new BitSet(allStores.Length);
		bitSet.Set(0);
		for (int i = 0; i < scope.Variables.Count; i = checked(i + 1))
		{
			if (analyzedVariables[i])
			{
				Debug.Assert(allStores[firstStoreIndexForVariable[i]] == null);
				bitSet.Set(firstStoreIndexForVariable[i]);
			}
		}
		return new State(bitSet);
	}

	private void HandleStore(ILInstruction inst, ILVariable v)
	{
		CancellationToken cancellationToken = this.cancellationToken;
		cancellationToken.ThrowIfCancellationRequested();
		if (v.Function == scope && analyzedVariables[v.IndexInFunction] && state.IsReachable)
		{
			state.KillStores(firstStoreIndexForVariable[v.IndexInFunction], firstStoreIndexForVariable[checked(v.IndexInFunction + 1)]);
			int store = storeIndexMap[inst];
			state.SetStore(store);
			currentStateOnException.SetStore(store);
		}
	}

	protected internal override void VisitStLoc(StLoc inst)
	{
		inst.Value.AcceptVisitor(this);
		HandleStore(inst, inst.Variable);
	}

	protected override void BeginTryCatchHandler(TryCatchHandler inst)
	{
		base.BeginTryCatchHandler(inst);
		HandleStore(inst, inst.Variable);
	}

	protected internal override void VisitPinnedRegion(PinnedRegion inst)
	{
		inst.Init.AcceptVisitor(this);
		HandleStore(inst, inst.Variable);
		inst.Body.AcceptVisitor(this);
	}

	public bool IsAnalyzedVariable(ILVariable v)
	{
		return v.Function == scope && analyzedVariables[v.IndexInFunction];
	}

	protected IEnumerable<ILInstruction> GetStores(State state, ILVariable v)
	{
		Debug.Assert(v.Function == scope && analyzedVariables[v.IndexInFunction]);
		checked
		{
			int endIndex = firstStoreIndexForVariable[v.IndexInFunction + 1];
			for (int si = firstStoreIndexForVariable[v.IndexInFunction] + 1; si < endIndex; si++)
			{
				if (state.IsReachingStore(si))
				{
					Debug.Assert(((IInstructionWithVariableOperand)allStores[si]).Variable == v);
					yield return allStores[si];
				}
			}
		}
	}

	protected bool IsPotentiallyUninitialized(State state, ILVariable v)
	{
		Debug.Assert(v.Function == scope && analyzedVariables[v.IndexInFunction]);
		return state.IsReachingStore(firstStoreIndexForVariable[v.IndexInFunction]);
	}
}
