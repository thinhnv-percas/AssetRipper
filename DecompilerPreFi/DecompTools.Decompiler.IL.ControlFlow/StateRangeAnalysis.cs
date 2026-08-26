#define DEBUG
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.IL.ControlFlow;

internal class StateRangeAnalysis
{
	public CancellationToken CancellationToken;

	private readonly StateRangeAnalysisMode mode;

	private readonly IField stateField;

	private readonly SymbolicEvaluationContext evalContext;

	private readonly Dictionary<Block, LongSet> ranges = new Dictionary<Block, LongSet>();

	internal readonly Dictionary<IMethod, LongSet> finallyMethodToStateRange;

	internal ILVariable doFinallyBodies;

	internal ILVariable skipFinallyBodies;

	public IEnumerable<ILVariable> CachedStateVars => evalContext.StateVariables;

	public StateRangeAnalysis(StateRangeAnalysisMode mode, IField stateField, ILVariable cachedStateVar = null)
	{
		this.mode = mode;
		this.stateField = stateField;
		if (mode == StateRangeAnalysisMode.IteratorDispose)
		{
			finallyMethodToStateRange = new Dictionary<IMethod, LongSet>();
		}
		evalContext = new SymbolicEvaluationContext(stateField);
		if (cachedStateVar != null)
		{
			evalContext.AddStateVariable(cachedStateVar);
		}
	}

	internal StateRangeAnalysis CreateNestedAnalysis()
	{
		StateRangeAnalysis stateRangeAnalysis = new StateRangeAnalysis(mode, stateField);
		stateRangeAnalysis.doFinallyBodies = doFinallyBodies;
		stateRangeAnalysis.skipFinallyBodies = skipFinallyBodies;
		foreach (ILVariable stateVariable in evalContext.StateVariables)
		{
			stateRangeAnalysis.evalContext.AddStateVariable(stateVariable);
		}
		return stateRangeAnalysis;
	}

	public LongSet AssignStateRanges(ILInstruction inst, LongSet stateRange)
	{
		CancellationToken.ThrowIfCancellationRequested();
		if (inst != null)
		{
			if (inst is BlockContainer blockContainer)
			{
				BlockContainer blockContainer2 = blockContainer;
				AddStateRange(blockContainer2.EntryPoint, stateRange);
				foreach (Block block3 in blockContainer2.Blocks)
				{
					if (ranges.TryGetValue(block3, out stateRange))
					{
						AssignStateRanges(block3, stateRange);
					}
				}
				return LongSet.Empty;
			}
			if (inst is Block block)
			{
				Block block2 = block;
				foreach (ILInstruction instruction in block2.Instructions)
				{
					if (stateRange.IsEmpty)
					{
						break;
					}
					LongSet other = stateRange;
					stateRange = AssignStateRanges(instruction, stateRange);
					Debug.Assert(stateRange.IsSubsetOf(other));
					Debug.Assert(stateRange.IsEmpty || !instruction.HasFlag(InstructionFlags.EndPointUnreachable));
				}
				return stateRange;
			}
			if (inst is TryFinally tryFinally)
			{
				TryFinally tryFinally2 = tryFinally;
				if (mode == StateRangeAnalysisMode.IteratorDispose)
				{
					LongSet longSet = AssignStateRanges(tryFinally2.TryBlock, stateRange);
					Debug.Assert(longSet.IsSubsetOf(stateRange));
					LongSet other2 = AssignStateRanges(tryFinally2.FinallyBlock, stateRange);
					return longSet.IntersectWith(other2);
				}
			}
			if (!(inst is SwitchInstruction switchInstruction))
			{
				if (!(inst is IfInstruction ifInstruction))
				{
					if (inst is Branch branch)
					{
						Branch branch2 = branch;
						AddStateRange(branch2.TargetBlock, stateRange);
						return LongSet.Empty;
					}
					if (inst is Nop nop)
					{
						Nop nop2 = nop;
						return stateRange;
					}
					if (!(inst is StLoc stLoc))
					{
						if (inst is Call call)
						{
							Call call2 = call;
							if (mode == StateRangeAnalysisMode.IteratorDispose)
							{
								finallyMethodToStateRange.Add((IMethod)call2.Method.MemberDefinition, stateRange);
								return LongSet.Empty;
							}
						}
						if (inst is StObj stObj)
						{
							StObj stObj2 = stObj;
							if (mode == StateRangeAnalysisMode.IteratorMoveNext && stObj2.MatchStFld(out var target, out var field, out var value) && target.MatchLdThis() && field.MemberDefinition == stateField && value.MatchLdcI4(-1))
							{
								return stateRange;
							}
						}
					}
					else
					{
						StLoc stLoc2 = stLoc;
						if (stLoc2.Variable == doFinallyBodies || stLoc2.Variable == skipFinallyBodies)
						{
							return stateRange;
						}
						StLoc stLoc3 = stLoc;
						SymbolicValue symbolicValue = evalContext.Eval(stLoc3.Value);
						if (symbolicValue.Type == SymbolicValueType.State && symbolicValue.Constant == 0)
						{
							evalContext.AddStateVariable(stLoc3.Variable);
							return stateRange;
						}
					}
				}
				else
				{
					IfInstruction ifInstruction2 = ifInstruction;
					SymbolicValue symbolicValue = evalContext.Eval(ifInstruction2.Condition).AsBool();
					if (symbolicValue.Type == SymbolicValueType.StateInSet)
					{
						LongSet valueSet = symbolicValue.ValueSet;
						LongSet longSet2 = AssignStateRanges(ifInstruction2.TrueInst, stateRange.IntersectWith(valueSet));
						LongSet other3 = AssignStateRanges(ifInstruction2.FalseInst, stateRange.ExceptWith(valueSet));
						return longSet2.UnionWith(other3);
					}
				}
			}
			else
			{
				SwitchInstruction switchInstruction2 = switchInstruction;
				SymbolicValue symbolicValue = evalContext.Eval(switchInstruction2.Value);
				if (symbolicValue.Type == SymbolicValueType.State)
				{
					List<LongInterval> list = new List<LongInterval>();
					foreach (SwitchSection section in switchInstruction2.Sections)
					{
						LongSet other4 = section.Labels.AddOffset(-symbolicValue.Constant);
						list.AddRange(AssignStateRanges(section.Body, stateRange.IntersectWith(other4)).Intervals);
					}
					return new LongSet(list);
				}
			}
		}
		if (mode == StateRangeAnalysisMode.IteratorDispose && !(inst is Leave { IsLeavingFunction: not false }))
		{
			throw new SymbolicAnalysisFailedException("Unexpected instruction in Iterator.Dispose()");
		}
		return LongSet.Empty;
	}

	private void AddStateRange(Block block, LongSet stateRange)
	{
		if (ranges.TryGetValue(block, out var value))
		{
			ranges[block] = stateRange.UnionWith(value);
		}
		else
		{
			ranges.Add(block, stateRange);
		}
	}

	public LongDict<Block> GetBlockStateSetMapping(BlockContainer container)
	{
		return LongDict.Create(GetMapping());
		IEnumerable<(LongSet, Block)> GetMapping()
		{
			foreach (var (block2, states) in ranges)
			{
				if (block2.Parent != container)
				{
					yield return (states, block2);
				}
			}
			foreach (Block block3 in Enumerable.Reverse<Block>((IEnumerable<Block>)container.Blocks))
			{
				if (ranges.TryGetValue(block3, out var states2))
				{
					yield return (states2, block3);
				}
				states2 = default(LongSet);
			}
		}
	}
}
