using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DecompTools.Decompiler.IL.ControlFlow;

namespace DecompTools.Decompiler.IL.Transforms;

internal class SwitchOnNullableTransform : IILTransform
{
	public void Run(ILFunction function, ILTransformContext context)
	{
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		if (!context.Settings.LiftNullables)
		{
			return;
		}
		HashSet<BlockContainer> val = new HashSet<BlockContainer>();
		checked
		{
			foreach (Block item in Enumerable.OfType<Block>((IEnumerable)function.Descendants))
			{
				bool flag = false;
				for (int num = item.Instructions.Count - 1; num >= 0; num--)
				{
					if (MatchSwitchOnNullable(item.Instructions, num, out var newSwitch))
					{
						newSwitch.AddILRange(item.Instructions[num - 2]);
						item.Instructions[num + 1].ReplaceWith(newSwitch);
						item.Instructions.RemoveRange(num - 2, 3);
						num -= 2;
						flag = true;
					}
					else if (MatchRoslynSwitchOnNullable(item.Instructions, num, out newSwitch))
					{
						newSwitch.AddILRange(item.Instructions[num]);
						newSwitch.AddILRange(item.Instructions[num + 1]);
						item.Instructions[num].ReplaceWith(newSwitch);
						item.Instructions.RemoveAt(num + 1);
						flag = true;
					}
				}
				if (flag)
				{
					SwitchDetection.SimplifySwitchInstruction(item);
					if (item.Parent is BlockContainer blockContainer)
					{
						val.Add(blockContainer);
					}
				}
			}
			Enumerator<BlockContainer> enumerator2 = val.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					BlockContainer current2 = enumerator2.Current;
					current2.SortBlocks(deleteUnreachableBlocks: true);
				}
			}
			finally
			{
				((IDisposable)enumerator2/*cast due to constrained. prefix*/).Dispose();
			}
		}
	}

	private bool MatchSwitchOnNullable(InstructionCollection<ILInstruction> instructions, int i, out SwitchInstruction newSwitch)
	{
		newSwitch = null;
		if (i < 2)
		{
			return false;
		}
		checked
		{
			if (!instructions[i - 2].MatchStLoc(out var variable, out var value) || !instructions[i - 1].MatchStLoc(out var variable2, out var value2) || !instructions[i].MatchIfInstruction(out var condition, out var trueInst))
			{
				return false;
			}
			if (!variable.IsSingleDefinition || variable.LoadCount != 2)
			{
				return false;
			}
			if (!variable2.IsSingleDefinition || variable2.LoadCount != 1)
			{
				return false;
			}
			if (!instructions[i + 1].MatchBranch(out var targetBlock) || !trueInst.MatchBranch(out var targetBlock2))
			{
				return false;
			}
			if (!value.MatchLdLoca(out var variable3))
			{
				return false;
			}
			if (!condition.MatchLogicNot(out var arg))
			{
				return false;
			}
			if (!NullableLiftingTransform.MatchGetValueOrDefault(value2, out ILInstruction arg2))
			{
				return false;
			}
			if (!NullableLiftingTransform.MatchHasValueCall(arg, out ILInstruction arg3))
			{
				return false;
			}
			if (!arg3.MatchLdLoc(variable) || !arg2.MatchLdLoc(variable))
			{
				return false;
			}
			if (targetBlock.Instructions.Count != 1 || targetBlock.IncomingEdgeCount != 1)
			{
				return false;
			}
			if (!(targetBlock.Instructions[0] is SwitchInstruction switchInst))
			{
				return false;
			}
			newSwitch = BuildLiftedSwitch(targetBlock2, switchInst, new LdLoc(variable3));
			return true;
		}
	}

	private static SwitchInstruction BuildLiftedSwitch(Block nullCaseBlock, SwitchInstruction switchInst, ILInstruction switchValue)
	{
		SwitchInstruction switchInstruction = new SwitchInstruction(switchValue);
		switchInstruction.IsLifted = true;
		switchInstruction.Sections.AddRange(switchInst.Sections);
		switchInstruction.Sections.Add(new SwitchSection
		{
			Body = new Branch(nullCaseBlock),
			HasNullLabel = true
		});
		return switchInstruction;
	}

	private bool MatchRoslynSwitchOnNullable(InstructionCollection<ILInstruction> instructions, int i, out SwitchInstruction newSwitch)
	{
		newSwitch = null;
		try
		{
			if (!instructions[i].MatchIfInstruction(out var condition, out var trueInst))
			{
				return false;
			}
			if (!instructions[checked(i + 1)].MatchBranch(out var targetBlock) || !trueInst.MatchBranch(out var targetBlock2))
			{
				return false;
			}
			if (!condition.MatchLogicNot(out var arg) || !NullableLiftingTransform.MatchHasValueCall(arg, out ILInstruction arg2) || !SemanticHelper.IsPure(arg2.Flags))
			{
				return false;
			}
			if (targetBlock.IncomingEdgeCount != 1)
			{
				return false;
			}
			SwitchInstruction switchInst;
			switch (targetBlock.Instructions.Count)
			{
			case 2:
			{
				if (!targetBlock.Instructions[0].MatchStLoc(out var variable, out var value))
				{
					return false;
				}
				if (!variable.IsSingleDefinition || variable.LoadCount != 1)
				{
					return false;
				}
				if (!NullableLiftingTransform.MatchGetValueOrDefault(value, out ILInstruction arg4) && arg4.Match(arg2).Success)
				{
					return false;
				}
				if (!(targetBlock.Instructions[1] is SwitchInstruction switchInstruction2))
				{
					return false;
				}
				switchInst = switchInstruction2;
				break;
			}
			case 1:
			{
				if (!(targetBlock.Instructions[0] is SwitchInstruction switchInstruction))
				{
					return false;
				}
				if (!NullableLiftingTransform.MatchGetValueOrDefault(switchInstruction.Value, out ILInstruction arg3) && arg3.Match(arg2).Success)
				{
					return false;
				}
				switchInst = switchInstruction;
				break;
			}
			default:
				return false;
			}
			newSwitch = BuildLiftedSwitch(switchValue: (!arg2.MatchLdLoca(out var variable2)) ? ((ILInstruction)new LdObj(arg2, ((CallInstruction)arg).Method.DeclaringType)) : ((ILInstruction)new LdLoc(variable2).WithILRange(arg2)), nullCaseBlock: targetBlock2, switchInst: switchInst);
			return true;
		}
		catch (Exception ex)
		{
			Console.WriteLine(string.Concat(ex));
			return false;
		}
	}
}
