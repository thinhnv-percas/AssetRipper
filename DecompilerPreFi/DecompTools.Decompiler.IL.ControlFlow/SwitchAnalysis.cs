#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.IL.ControlFlow;

internal class SwitchAnalysis
{
	private ILVariable switchVar;

	public readonly List<KeyValuePair<LongSet, ILInstruction>> Sections = new List<KeyValuePair<LongSet, ILInstruction>>();

	private readonly Dictionary<Block, int> targetBlockToSectionIndex = new Dictionary<Block, int>();

	private readonly Dictionary<BlockContainer, int> targetContainerToSectionIndex = new Dictionary<BlockContainer, int>();

	public readonly List<Block> InnerBlocks = new List<Block>();

	public ILVariable SwitchVariable => switchVar;

	public bool ContainsILSwitch { get; private set; }

	public Block RootBlock { get; private set; }

	public bool AnalyzeBlock(Block block)
	{
		switchVar = null;
		RootBlock = block;
		targetBlockToSectionIndex.Clear();
		targetContainerToSectionIndex.Clear();
		Sections.Clear();
		InnerBlocks.Clear();
		ContainsILSwitch = false;
		return AnalyzeBlock(block, LongSet.Universe, tailOnly: true);
	}

	private bool AnalyzeBlock(Block block, LongSet inputValues, bool tailOnly = false)
	{
		if (block.Instructions.Count == 0)
		{
			return false;
		}
		if (tailOnly)
		{
			Debug.Assert(block == RootBlock);
		}
		else
		{
			Debug.Assert(switchVar != null);
			if (block.IncomingEdgeCount != 1 || block == RootBlock)
			{
				return false;
			}
			if (block.Parent != RootBlock.Parent)
			{
				return false;
			}
		}
		if (block.Instructions.Count >= 2 && block.Instructions[checked(block.Instructions.Count - 2)].MatchIfInstruction(out var condition, out var trueInst) && AnalyzeCondition(condition, out var trueValues))
		{
			if (!tailOnly && block.Instructions.Count != 2)
			{
				return false;
			}
			trueValues = trueValues.IntersectWith(inputValues);
			if (trueValues.SetEquals(inputValues) || trueValues.IsEmpty)
			{
				return false;
			}
			if (trueInst.MatchBranch(out var targetBlock) && AnalyzeBlock(targetBlock, trueValues))
			{
				InnerBlocks.Add(targetBlock);
			}
			else
			{
				AddSection(trueValues, trueInst);
			}
			LongSet longSet = inputValues.ExceptWith(trueValues);
			ILInstruction iLInstruction = block.Instructions.Last();
			if (iLInstruction.MatchBranch(out var targetBlock2) && AnalyzeBlock(targetBlock2, longSet))
			{
				InnerBlocks.Add(targetBlock2);
			}
			else
			{
				AddSection(longSet, iLInstruction);
			}
			return true;
		}
		if (block.Instructions.Last() is SwitchInstruction inst)
		{
			if (!tailOnly && block.Instructions.Count != 1)
			{
				return false;
			}
			if (AnalyzeSwitch(inst, inputValues))
			{
				ContainsILSwitch = true;
				return true;
			}
			return false;
		}
		return false;
	}

	private bool AnalyzeSwitch(SwitchInstruction inst, LongSet inputValues)
	{
		Debug.Assert(!inst.IsLifted);
		long val;
		if (MatchSwitchVar(inst.Value))
		{
			val = 0L;
		}
		else
		{
			if (!(inst.Value is BinaryNumericInstruction binaryNumericInstruction))
			{
				return false;
			}
			if (binaryNumericInstruction.CheckForOverflow)
			{
				return false;
			}
			if (!MatchSwitchVar(binaryNumericInstruction.Left) || !binaryNumericInstruction.Right.MatchLdcI(out var val2))
			{
				return false;
			}
			switch (binaryNumericInstruction.Operator)
			{
			case BinaryNumericOperator.Add:
				val = -val2;
				break;
			case BinaryNumericOperator.Sub:
				val = val2;
				break;
			default:
				return false;
			}
		}
		foreach (SwitchSection section in inst.Sections)
		{
			LongSet longSet = section.Labels.AddOffset(val).IntersectWith(inputValues);
			if (longSet.Count() > 1 && section.Body.MatchBranch(out var targetBlock) && AnalyzeBlock(targetBlock, longSet))
			{
				InnerBlocks.Add(targetBlock);
			}
			else
			{
				AddSection(longSet, section.Body);
			}
		}
		return true;
	}

	private void AddSection(LongSet values, ILInstruction inst)
	{
		if (values.IsEmpty)
		{
			return;
		}
		BlockContainer targetContainer;
		if (inst.MatchBranch(out var targetBlock))
		{
			if (targetBlockToSectionIndex.TryGetValue(targetBlock, out var value))
			{
				Sections[value] = new KeyValuePair<LongSet, ILInstruction>(Sections[value].Key.UnionWith(values), inst);
				return;
			}
			targetBlockToSectionIndex.Add(targetBlock, Sections.Count);
			Sections.Add(new KeyValuePair<LongSet, ILInstruction>(values, inst));
		}
		else if (inst.MatchLeave(out targetContainer))
		{
			if (targetContainerToSectionIndex.TryGetValue(targetContainer, out var value2))
			{
				Sections[value2] = new KeyValuePair<LongSet, ILInstruction>(Sections[value2].Key.UnionWith(values), inst);
				return;
			}
			targetContainerToSectionIndex.Add(targetContainer, Sections.Count);
			Sections.Add(new KeyValuePair<LongSet, ILInstruction>(values, inst));
		}
		else
		{
			Sections.Add(new KeyValuePair<LongSet, ILInstruction>(values, inst));
		}
	}

	private bool MatchSwitchVar(ILInstruction inst)
	{
		if (switchVar != null)
		{
			return inst.MatchLdLoc(switchVar);
		}
		return inst.MatchLdLoc(out switchVar);
	}

	private bool MatchSwitchVar(ILInstruction inst, out long sub)
	{
		if (inst is BinaryNumericInstruction { Operator: BinaryNumericOperator.Sub, CheckForOverflow: false, IsLifted: false } binaryNumericInstruction && binaryNumericInstruction.Right.MatchLdcI(out sub))
		{
			return MatchSwitchVar(binaryNumericInstruction.Left);
		}
		sub = 0L;
		return MatchSwitchVar(inst);
	}

	private bool AnalyzeCondition(ILInstruction condition, out LongSet trueValues)
	{
		if (condition is Comp comp && MatchSwitchVar(comp.Left, out var sub) && comp.Right.MatchLdcI(out var val))
		{
			trueValues = MakeSetWhereComparisonIsTrue(comp.Kind, val, comp.Sign);
			trueValues = trueValues.AddOffset(sub);
			return true;
		}
		if (MatchSwitchVar(condition))
		{
			trueValues = new LongSet(0L).Invert();
			return true;
		}
		if (condition.MatchLogicNot(out var arg))
		{
			bool result = AnalyzeCondition(arg, out var trueValues2);
			trueValues = trueValues2.Invert();
			return result;
		}
		trueValues = LongSet.Empty;
		return false;
	}

	internal static LongSet MakeSetWhereComparisonIsTrue(ComparisonKind kind, long val, Sign sign)
	{
		return kind switch
		{
			ComparisonKind.Equality => new LongSet(val), 
			ComparisonKind.Inequality => new LongSet(val).Invert(), 
			ComparisonKind.LessThan => MakeGreaterThanOrEqualSet(val, sign).Invert(), 
			ComparisonKind.LessThanOrEqual => MakeLessThanOrEqualSet(val, sign), 
			ComparisonKind.GreaterThan => MakeLessThanOrEqualSet(val, sign).Invert(), 
			ComparisonKind.GreaterThanOrEqual => MakeGreaterThanOrEqualSet(val, sign), 
			_ => throw new ArgumentException("Invalid ComparisonKind"), 
		};
	}

	private static LongSet MakeGreaterThanOrEqualSet(long val, Sign sign)
	{
		if (sign == Sign.Signed)
		{
			return new LongSet(LongInterval.Inclusive(val, long.MaxValue));
		}
		Debug.Assert(sign == Sign.Unsigned);
		if (val >= 0)
		{
			return new LongSet(LongInterval.Inclusive(val, long.MaxValue)).UnionWith(new LongSet(new LongInterval(long.MinValue, 0L)));
		}
		return new LongSet(new LongInterval(val, 0L));
	}

	private static LongSet MakeLessThanOrEqualSet(long val, Sign sign)
	{
		if (sign == Sign.Signed)
		{
			return new LongSet(LongInterval.Inclusive(long.MinValue, val));
		}
		Debug.Assert(sign == Sign.Unsigned);
		if (val >= 0)
		{
			return new LongSet(LongInterval.Inclusive(0L, val));
		}
		return new LongSet(LongInterval.Inclusive(0L, long.MaxValue)).UnionWith(new LongSet(LongInterval.Inclusive(long.MinValue, val)));
	}
}
