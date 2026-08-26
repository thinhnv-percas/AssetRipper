using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DecompTools.Decompiler.IL.ControlFlow;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.IL.Transforms;

internal class SwitchOnStringTransform : IILTransform
{
	public void Run(ILFunction function, ILTransformContext context)
	{
		//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
		if (!context.Settings.SwitchStatementOnString)
		{
			return;
		}
		BlockContainer blockContainer = (BlockContainer)function.Body;
		Dictionary<IField, (List<(string, int)>, IfInstruction, Block, Block, Block, bool)> dictionary = ScanHashtableInitializerBlocks(blockContainer.EntryPoint);
		HashSet<BlockContainer> val = new HashSet<BlockContainer>();
		checked
		{
			foreach (Block item in Enumerable.OfType<Block>((IEnumerable)function.Descendants))
			{
				bool flag = false;
				if (item.IncomingEdgeCount == 0)
				{
					continue;
				}
				for (int i = item.Instructions.Count - 1; i >= 0; i--)
				{
					if (SimplifyCascadingIfStatements(item.Instructions, ref i))
					{
						flag = true;
					}
					else if (SimplifyCSharp1CascadingIfStatements(item.Instructions, ref i))
					{
						flag = true;
					}
					else if (MatchLegacySwitchOnStringWithHashtable(item, dictionary, ref i))
					{
						flag = true;
					}
					else if (MatchLegacySwitchOnStringWithDict(item.Instructions, ref i))
					{
						flag = true;
					}
					else if (MatchRoslynSwitchOnString(item.Instructions, ref i))
					{
						flag = true;
					}
				}
				if (flag)
				{
					SwitchDetection.SimplifySwitchInstruction(item);
					if (item.Parent is BlockContainer blockContainer2)
					{
						val.Add(blockContainer2);
					}
				}
			}
			Dictionary<Block, Block> dictionary2 = new Dictionary<Block, Block>();
			foreach (KeyValuePair<IField, (List<(string, int)>, IfInstruction, Block, Block, Block, bool)> item2 in dictionary)
			{
				(List<(string, int)>, IfInstruction, Block, Block, Block, bool) value = item2.Value;
				var (list, ifInstruction, key, block, targetBlock, _) = value;
				if (value.Item6)
				{
					if (!dictionary2.TryGetValue(block, out var value2))
					{
						value2 = block;
					}
					if (ifInstruction != null)
					{
						value2.Instructions.SecondToLastOrDefault().ReplaceWith(ifInstruction);
					}
					value2.Instructions.LastOrDefault().ReplaceWith(new Branch(targetBlock));
					dictionary2.Add(key, block);
					val.Add(blockContainer);
				}
			}
			if (dictionary.Count > 0 && dictionary2.Count == dictionary.Count && blockContainer.EntryPoint.Instructions.Count == 2 && blockContainer.EntryPoint.Instructions[0] is IfInstruction ifInstruction2 && ifInstruction2.TrueInst.MatchBranch(out var targetBlock2) && blockContainer.EntryPoint.Instructions[1].MatchBranch(targetBlock2))
			{
				blockContainer.EntryPoint.Instructions.RemoveAt(0);
			}
			var enumerator3 = val.GetEnumerator();
			try
			{
				while (enumerator3.MoveNext())
				{
					BlockContainer current2 = enumerator3.Current;
					current2.SortBlocks(deleteUnreachableBlocks: true);
				}
			}
			finally
			{
				((IDisposable)enumerator3/*cast due to constrained. prefix*/).Dispose();
			}
		}
	}

	private Dictionary<IField, (List<(string, int)> Labels, IfInstruction JumpToNext, Block ContainingBlock, Block Previous, Block Next, bool Transformed)> ScanHashtableInitializerBlocks(Block entryPoint)
	{
		Dictionary<IField, (List<(string, int)>, IfInstruction, Block, Block, Block, bool)> dictionary = new Dictionary<IField, (List<(string, int)>, IfInstruction, Block, Block, Block, bool)>();
		if (entryPoint.Instructions.Count != 2)
		{
			return dictionary;
		}
		if (!entryPoint.Instructions[0].MatchIfInstruction(out var condition, out var trueInst))
		{
			return dictionary;
		}
		if (!entryPoint.Instructions[1].MatchBranch(out var targetBlock))
		{
			return dictionary;
		}
		if (!condition.MatchCompNotEquals(out var left, out var right) || !right.MatchLdNull() || !MatchDictionaryFieldLoad(left, IsNonGenericHashtable, out var dictField, out var dictionaryType))
		{
			return dictionary;
		}
		if (!trueInst.MatchBranch(out var targetBlock2))
		{
			return dictionary;
		}
		if (targetBlock.IncomingEdgeCount != 1 || targetBlock.Instructions.Count < 3)
		{
			return dictionary;
		}
		Block item = entryPoint;
		List<(string, int)> values;
		Block blockAfterInit;
		while (targetBlock != null && ExtractStringValuesFromInitBlock(targetBlock, out values, out blockAfterInit, dictionaryType, dictField, isHashtablePattern: true))
		{
			IfInstruction ifInstruction = targetBlock.Instructions.SecondToLastOrDefault() as IfInstruction;
			dictionary.Add(dictField, (values, ifInstruction, targetBlock, item, blockAfterInit, false));
			item = targetBlock;
			if (ifInstruction == null || !ifInstruction.Condition.MatchCompNotEquals(out left, out right) || !right.MatchLdNull() || !MatchDictionaryFieldLoad(left, IsNonGenericHashtable, out var dictField2, out var _) || !ifInstruction.TrueInst.MatchBranch(targetBlock2))
			{
				break;
			}
			targetBlock = blockAfterInit;
			dictField = dictField2;
		}
		return dictionary;
	}

	private bool SimplifyCascadingIfStatements(InstructionCollection<ILInstruction> instructions, ref int i)
	{
		if (i < 1)
		{
			return false;
		}
		if (!instructions[i].MatchIfInstruction(out var condition, out var trueInst))
		{
			return false;
		}
		if (!trueInst.MatchBranch(out var targetBlock))
		{
			return false;
		}
		List<(string, Block)> list = new List<(string, Block)>();
		ILInstruction value = null;
		if (!MatchStringEqualityComparison(condition, out var variable, out var stringValue))
		{
			return false;
		}
		list.Add((stringValue, targetBlock));
		bool flag = false;
		bool flag2 = false;
		checked
		{
			if (instructions[i - 1].MatchStLoc(variable, out value))
			{
				if (i >= 2 && value.MatchLdLoc(out var variable2) && variable2.IsSingleDefinition && variable2.LoadCount == 1 && instructions[i - 2].MatchStLoc(variable2, out value))
				{
					flag = true;
				}
			}
			else if (instructions[i - 1] is StLoc stLoc)
			{
				if (stLoc.Value.MatchLdLoc(variable))
				{
					ILVariable iLVariable = variable;
					variable = stLoc.Variable;
					if (i >= 2 && instructions[i - 2].MatchStLoc(iLVariable, out value) && iLVariable.IsSingleDefinition && iLVariable.LoadCount == 2)
					{
						flag = true;
					}
					else
					{
						value = new LdLoc(iLVariable);
					}
				}
				else
				{
					flag2 = true;
					value = new LdLoc(variable);
				}
			}
			else
			{
				value = new LdLoc(variable);
			}
			if (!(instructions.ElementAtOrDefault(i + 1) is Branch { TargetBlock: var block }))
			{
				return false;
			}
			Block block2;
			string value2;
			Block caseBlock;
			while ((block2 = MatchCaseBlock(block, variable, out value2, out caseBlock)) != null)
			{
				list.Add((value2, caseBlock));
				block = block2;
			}
			if (list.Count < 3)
			{
				return false;
			}
			if (variable.LoadCount > list.Count)
			{
				flag2 = true;
				value = new LdLoc(variable);
			}
			List<SwitchSection> list2 = new List<SwitchSection>(list.SelectWithIndex((int index, (string, Block) b) => new SwitchSection
			{
				Labels = new LongSet(index),
				Body = new Branch(b.Item2)
			}));
			list2.Add(new SwitchSection
			{
				Labels = new LongSet(new LongInterval(0L, list2.Count)).Invert(),
				Body = new Branch(block)
			});
			StringToInt value3 = new StringToInt(value, list.SelectArray(((string, Block) item) => item.Item1));
			SwitchInstruction switchInstruction = new SwitchInstruction(value3);
			switchInstruction.Sections.AddRange(list2);
			if (flag)
			{
				switchInstruction.AddILRange(instructions[i - 2]);
				instructions[i - 2].ReplaceWith(switchInstruction);
				instructions.RemoveRange(i - 1, 3);
				i -= 2;
			}
			else if (flag2)
			{
				switchInstruction.AddILRange(instructions[i]);
				instructions[i].ReplaceWith(switchInstruction);
				instructions.RemoveAt(i + 1);
			}
			else
			{
				switchInstruction.AddILRange(instructions[i - 1]);
				instructions[i - 1].ReplaceWith(switchInstruction);
				instructions.RemoveRange(i, 2);
				i--;
			}
			return true;
		}
	}

	private bool SimplifyCSharp1CascadingIfStatements(InstructionCollection<ILInstruction> instructions, ref int i)
	{
		if (i < 1)
		{
			return false;
		}
		if (!instructions[i].MatchIfInstruction(out var condition, out var trueInst))
		{
			return false;
		}
		checked
		{
			if (!instructions[i + 1].MatchBranch(out var targetBlock))
			{
				return false;
			}
			if (!trueInst.MatchBranch(out var targetBlock2))
			{
				return false;
			}
			if (!condition.MatchCompEqualsNull(out var arg) || !arg.MatchLdLoc(out var variable))
			{
				return false;
			}
			if (variable.Kind != VariableKind.StackSlot || variable.LoadCount != 2)
			{
				return false;
			}
			if (!instructions[i - 1].MatchStLoc(out var variable2, out var value) || !value.MatchLdLoc(variable))
			{
				return false;
			}
			if (targetBlock.IncomingEdgeCount != 1 || targetBlock.Instructions.Count != 3)
			{
				return false;
			}
			if (!targetBlock.Instructions[0].MatchStLoc(out var variable3, out var value2) || !IsIsInternedCall(value2 as Call, out value2) || !value2.MatchLdLoc(variable2))
			{
				return false;
			}
			variable2 = variable3;
			int num = 1;
			Block targetBlock3 = targetBlock;
			List<(string, ILInstruction)> list = new List<(string, ILInstruction)>();
			if (!variable3.IsSingleDefinition)
			{
				return false;
			}
			ILInstruction trueInst2;
			ILInstruction left;
			ILInstruction right;
			string value3;
			Block targetBlock4;
			while (targetBlock3.Instructions[num].MatchIfInstruction(out condition, out trueInst2) && targetBlock3.Instructions.Count == num + 2 && condition.MatchCompEquals(out left, out right) && left.MatchLdLoc(variable2) && right.MatchLdStr(out value3) && (trueInst2.MatchBranch(out targetBlock4) || trueInst2.MatchLeave((BlockContainer)targetBlock3.Parent)) && targetBlock3.Instructions[num + 1].MatchBranch(out targetBlock3))
			{
				num = 0;
				list.Add((value3, trueInst2.Clone()));
			}
			if (list.Count != variable3.LoadCount)
			{
				return false;
			}
			if (targetBlock3 != targetBlock2)
			{
				list.Add((null, new Branch(targetBlock2)));
			}
			List<SwitchSection> list2 = new List<SwitchSection>(list.SelectWithIndex((int index, (string, ILInstruction) b) => new SwitchSection
			{
				Labels = new LongSet(index),
				Body = b.Item2
			}));
			list2.Add(new SwitchSection
			{
				Labels = new LongSet(new LongInterval(0L, list2.Count)).Invert(),
				Body = new Branch(targetBlock3)
			});
			StringToInt value4 = new StringToInt(value, list.SelectArray(((string, ILInstruction) item) => item.Item1));
			SwitchInstruction switchInstruction = new SwitchInstruction(value4);
			switchInstruction.Sections.AddRange(list2);
			switchInstruction.AddILRange(instructions[i - 1]);
			instructions[i].ReplaceWith(switchInstruction);
			instructions.RemoveAt(i + 1);
			instructions.RemoveAt(i - 1);
			return true;
		}
	}

	private bool IsIsInternedCall(Call call, out ILInstruction argument)
	{
		if (call != null && call.Method.DeclaringType.IsKnownType(KnownTypeCode.String) && call.Method.IsStatic && call.Method.Name == "IsInterned" && call.Arguments.Count == 1)
		{
			argument = call.Arguments[0];
			return true;
		}
		argument = null;
		return false;
	}

	private Block MatchCaseBlock(Block currentBlock, ILVariable switchVariable, out string value, out Block caseBlock)
	{
		value = null;
		caseBlock = null;
		if (currentBlock.IncomingEdgeCount != 1 || currentBlock.Instructions.Count != 2)
		{
			return null;
		}
		if (!currentBlock.Instructions[0].MatchIfInstruction(out var condition, out var trueInst))
		{
			return null;
		}
		if (!trueInst.MatchBranch(out caseBlock))
		{
			return null;
		}
		Block targetBlock;
		if (condition.MatchLogicNot(out var arg))
		{
			condition = arg;
			targetBlock = caseBlock;
			if (!currentBlock.Instructions[1].MatchBranch(out caseBlock))
			{
				return null;
			}
		}
		else if (!currentBlock.Instructions[1].MatchBranch(out targetBlock))
		{
			return null;
		}
		if (!MatchStringEqualityComparison(condition, switchVariable, out value))
		{
			return null;
		}
		return targetBlock;
	}

	private bool MatchLegacySwitchOnStringWithDict(InstructionCollection<ILInstruction> instructions, ref int i)
	{
		if (!instructions[i].MatchIfInstruction(out var condition, out var trueInst))
		{
			return false;
		}
		if (!condition.MatchCompEquals(out var left, out var right) || !right.MatchLdNull())
		{
			return false;
		}
		checked
		{
			if (i > 0 && instructions[i - 1].MatchStLoc(out var variable, out var value))
			{
				if (!variable.IsSingleDefinition || ((!SemanticHelper.IsPure(value.Flags) || !left.Match(value).Success) && !left.MatchLdLoc(variable)))
				{
					return false;
				}
			}
			else
			{
				if (!left.MatchLdLoc(out variable))
				{
					return false;
				}
				value = null;
			}
			if (!variable.Type.IsKnownType(KnownTypeCode.String))
			{
				return false;
			}
			BlockContainer blockContainer = BlockContainer.FindClosestContainer(instructions[i]);
			if (blockContainer.Parent is TryInstruction)
			{
				blockContainer = BlockContainer.FindClosestContainer(blockContainer.Parent);
			}
			if (!trueInst.MatchBranch(out var targetBlock) && !trueInst.MatchLeave(blockContainer))
			{
				return false;
			}
			if (!(instructions.ElementAtOrDefault(i + 1) is Branch branch) || branch.TargetBlock.IncomingEdgeCount != 1)
			{
				return false;
			}
			Block targetBlock2 = branch.TargetBlock;
			if (targetBlock2.Instructions.Count != 2 || !targetBlock2.Instructions[0].MatchIfInstruction(out condition, out var trueInst2))
			{
				return false;
			}
			if (!trueInst2.MatchBranch(out var targetBlock3))
			{
				return false;
			}
			if (!targetBlock2.Instructions[1].MatchBranch(out var targetBlock4) || targetBlock4.IncomingEdgeCount != 1)
			{
				return false;
			}
			if (!condition.MatchCompNotEquals(out left, out right) || !right.MatchLdNull() || !MatchDictionaryFieldLoad(left, IsStringToIntDictionary, out var dictField, out var dictionaryType))
			{
				return false;
			}
			if (targetBlock4.IncomingEdgeCount != 1 || targetBlock4.Instructions.Count < 3)
			{
				return false;
			}
			if (!ExtractStringValuesFromInitBlock(targetBlock4, out var values, out var blockAfterInit, dictionaryType, dictField, isHashtablePattern: false))
			{
				return false;
			}
			if (targetBlock3 != blockAfterInit)
			{
				return false;
			}
			if (targetBlock3.IncomingEdgeCount != 2 || targetBlock3.Instructions.Count != 2)
			{
				return false;
			}
			if (!targetBlock3.Instructions[0].MatchIfInstruction(out condition, out var trueInst3))
			{
				return false;
			}
			if (!trueInst3.MatchBranch(out var targetBlock5) && !trueInst3.MatchLeave(blockContainer))
			{
				return false;
			}
			if (!condition.MatchLogicNot(out var arg) || !(arg is CallInstruction callInstruction) || !(callInstruction.Method.Name == "TryGetValue") || !MatchDictionaryFieldLoad(callInstruction.Arguments[0], IsStringToIntDictionary, out var dictField2, out var _) || !dictField2.Equals(dictField))
			{
				return false;
			}
			if (!callInstruction.Arguments[1].MatchLdLoc(variable) || !callInstruction.Arguments[2].MatchLdLoca(out var variable2))
			{
				return false;
			}
			if (!targetBlock3.Instructions[1].MatchBranch(out var targetBlock6))
			{
				return false;
			}
			if (targetBlock6.IncomingEdgeCount != 1 || targetBlock6.Instructions.Count == 0)
			{
				return false;
			}
			List<SwitchSection> list = new List<SwitchSection>();
			ILInstruction iLInstruction = targetBlock6.Instructions[0];
			ILInstruction iLInstruction2 = iLInstruction;
			if (iLInstruction2 != null)
			{
				if (!(iLInstruction2 is SwitchInstruction switchInstruction))
				{
					if (iLInstruction2 is IfInstruction ifInstruction)
					{
						IfInstruction ifInstruction2 = ifInstruction;
						if (targetBlock6.Instructions.Count != 2)
						{
							return false;
						}
						if (!ifInstruction2.Condition.MatchCompEquals(out left, out right))
						{
							return false;
						}
						if (!left.MatchLdLoc(variable2))
						{
							return false;
						}
						if (!right.MatchLdcI4(0))
						{
							return false;
						}
						list.Add(new SwitchSection
						{
							Body = ifInstruction2.TrueInst,
							Labels = new LongSet(0L)
						}.WithILRange(ifInstruction2));
						list.Add(new SwitchSection
						{
							Body = targetBlock6.Instructions[1],
							Labels = new LongSet(0L).Invert()
						}.WithILRange(targetBlock6.Instructions[1]));
					}
				}
				else
				{
					SwitchInstruction switchInstruction2 = switchInstruction;
					if (targetBlock6.Instructions.Count != 1)
					{
						return false;
					}
					if (!switchInstruction2.Value.MatchLdLoc(variable2))
					{
						return false;
					}
					list.AddRange(switchInstruction2.Sections);
				}
			}
			if (!FixCasesWithoutValue(list, values))
			{
				return false;
			}
			if (targetBlock != targetBlock5 && !AddNullSection(list, values, targetBlock))
			{
				return false;
			}
			bool flag = false;
			if (variable.LoadCount > 2 || value == null)
			{
				value = new LdLoc(variable);
				flag = true;
			}
			StringToInt value2 = new StringToInt(value, values);
			SwitchInstruction switchInstruction3 = new SwitchInstruction(value2);
			switchInstruction3.Sections.AddRange(list);
			instructions[i + 1].ReplaceWith(switchInstruction3);
			if (flag)
			{
				switchInstruction3.AddILRange(instructions[i]);
				instructions.RemoveAt(i);
				i--;
			}
			else
			{
				switchInstruction3.AddILRange(instructions[i - 1]);
				instructions.RemoveRange(i - 1, 2);
				i -= 2;
			}
			return true;
		}
	}

	private bool FixCasesWithoutValue(List<SwitchSection> sections, List<(string, int)> stringValues)
	{
		SwitchSection switchSection = Enumerable.First<SwitchSection>((IEnumerable<SwitchSection>)sections);
		List<SwitchSection> list = new List<SwitchSection>();
		foreach (SwitchSection section in sections)
		{
			if (section == switchSection)
			{
				continue;
			}
			if (section.Labels.Count() > switchSection.Labels.Count())
			{
				if (!HasLabel(switchSection))
				{
					list.Add(switchSection);
				}
				switchSection = section;
			}
			else if (!HasLabel(section))
			{
				list.Add(section);
			}
		}
		foreach (SwitchSection item in list)
		{
			if (!item.Body.Match(switchSection.Body).Success)
			{
				return false;
			}
			switchSection.Labels = switchSection.Labels.UnionWith(item.Labels);
			if (item.HasNullLabel)
			{
				switchSection.HasNullLabel = true;
			}
			sections.Remove(item);
		}
		return true;
		bool HasLabel(SwitchSection section)
		{
			return Enumerable.Any<long>(section.Labels.Values, (Func<long, bool>)((long i) => stringValues.Any(((string, int) value) => i == value.Item2)));
		}
	}

	private bool AddNullSection(List<SwitchSection> sections, List<(string, int)> stringValues, Block nullValueCaseBlock)
	{
		LongSet label = new LongSet(sections.Count);
		SwitchSection[] array = Enumerable.ToArray<SwitchSection>(Enumerable.Where<SwitchSection>((IEnumerable<SwitchSection>)sections, (Func<SwitchSection, bool>)((SwitchSection sec) => sec.Labels.Overlaps(label))));
		if (array.Length > 1)
		{
			return false;
		}
		if (array.Length == 1)
		{
			if (array[0].Labels.Count() == 1)
			{
				return false;
			}
			array[0].Labels = array[0].Labels.ExceptWith(label);
		}
		stringValues.Add((null, checked((int)Enumerable.First<long>(label.Values))));
		sections.Add(new SwitchSection
		{
			Labels = label,
			Body = new Branch(nullValueCaseBlock)
		});
		return true;
	}

	private bool MatchDictionaryFieldLoad(ILInstruction inst, Func<IType, bool> typeMatcher, out IField dictField, out IType dictionaryType)
	{
		dictField = null;
		dictionaryType = null;
		ILInstruction target;
		return inst.MatchLdObj(out target, out dictionaryType) && typeMatcher(dictionaryType) && target.MatchLdsFlda(out dictField) && (dictField.IsCompilerGeneratedOrIsInCompilerGeneratedClass() || dictField.Name.StartsWith("$$method", StringComparison.Ordinal));
	}

	private bool ExtractStringValuesFromInitBlock(Block block, out List<(string, int)> values, out Block blockAfterInit, IType dictionaryType, IField dictionaryField, bool isHashtablePattern)
	{
		values = null;
		blockAfterInit = null;
		if (!block.Instructions[0].MatchStLoc(out var variable, out var value) || !(value is NewObj newObj))
		{
			return false;
		}
		if (!newObj.Method.DeclaringType.Equals(dictionaryType))
		{
			return false;
		}
		int value2 = 0;
		if (newObj.Arguments.Count == 2)
		{
			if (!newObj.Arguments[0].MatchLdcI4(out value2))
			{
				return false;
			}
			if (!newObj.Arguments[1].MatchLdcF4(0.5f))
			{
				return false;
			}
		}
		else if (newObj.Arguments.Count == 1 && !newObj.Arguments[0].MatchLdcI4(out value2))
		{
			return false;
		}
		values = new List<(string, int)>(value2);
		checked
		{
			int i;
			int index;
			string value3;
			for (i = 0; MatchAddCall(dictionaryType, block.Instructions[i + 1], variable, out index, out value3); i++)
			{
				values.Add((value3, index));
			}
			if (!block.Instructions[i + 1].MatchStObj(out var target, out var value4, out var type) || !type.Equals(dictionaryType) || !target.MatchLdsFlda(out var field) || !field.Equals(dictionaryField) || !value4.MatchLdLoc(variable))
			{
				return false;
			}
			if (isHashtablePattern && block.Instructions[i + 2] is IfInstruction)
			{
				return block.Instructions[i + 3].MatchBranch(out blockAfterInit);
			}
			return block.Instructions[i + 2].MatchBranch(out blockAfterInit);
		}
	}

	private bool MatchAddCall(IType dictionaryType, ILInstruction inst, ILVariable dictVar, out int index, out string value)
	{
		value = null;
		index = -1;
		if (!(inst is CallInstruction callInstruction) || !(callInstruction.Method.Name == "Add") || callInstruction.Arguments.Count != 3)
		{
			return false;
		}
		if (!callInstruction.Arguments[0].MatchLdLoc(dictVar) || !callInstruction.Arguments[1].MatchLdStr(out value))
		{
			return false;
		}
		if (!callInstruction.Method.DeclaringType.Equals(dictionaryType) || callInstruction.Method.IsStatic)
		{
			return false;
		}
		ILInstruction argument;
		IType type;
		return callInstruction.Arguments[2].MatchLdcI4(out index) || (callInstruction.Arguments[2].MatchBox(out argument, out type) && argument.MatchLdcI4(out index));
	}

	private bool IsStringToIntDictionary(IType dictionaryType)
	{
		if (dictionaryType.FullName != "System.Collections.Generic.Dictionary")
		{
			return false;
		}
		if (dictionaryType.TypeArguments.Count != 2)
		{
			return false;
		}
		return dictionaryType.TypeArguments[0].IsKnownType(KnownTypeCode.String) && dictionaryType.TypeArguments[1].IsKnownType(KnownTypeCode.Int32);
	}

	private bool IsNonGenericHashtable(IType dictionaryType)
	{
		if (dictionaryType.FullName != "System.Collections.Hashtable")
		{
			return false;
		}
		if (dictionaryType.TypeArguments.Count != 0)
		{
			return false;
		}
		return true;
	}

	private bool MatchLegacySwitchOnStringWithHashtable(Block block, Dictionary<IField, (List<(string, int)> Labels, IfInstruction JumpToNext, Block ContainingBlock, Block Previous, Block Next, bool Transformed)> hashtableInitializers, ref int i)
	{
		checked
		{
			if (block.Instructions.Count != i + 4)
			{
				return false;
			}
			if (!block.Instructions[i].MatchStLoc(out var variable, out var value))
			{
				return false;
			}
			if (!block.Instructions[i + 1].MatchStLoc(out var variable2, out var value2) || !value2.MatchLdLoc(variable))
			{
				return false;
			}
			if (!block.Instructions[i + 2].MatchIfInstruction(out var condition, out var trueInst))
			{
				return false;
			}
			if (!block.Instructions[i + 3].MatchBranch(out var targetBlock) || (!trueInst.MatchBranch(out var targetBlock2) && !(trueInst is Leave)))
			{
				return false;
			}
			if (!condition.MatchCompEquals(out var left, out var right) || !right.MatchLdNull() || !left.MatchLdLoc(variable))
			{
				return false;
			}
			if (targetBlock.IncomingEdgeCount != 1 || targetBlock.Instructions.Count != 4)
			{
				return false;
			}
			if (!targetBlock.Instructions[0].MatchStLoc(out var variable3, out var value3) || !(value3 is Call call) || !(call.Method.Name == "get_Item"))
			{
				return false;
			}
			if (!targetBlock.Instructions[1].MatchStLoc(out var variable4, out var value4) || !value4.MatchLdLoc(variable3))
			{
				return false;
			}
			if (!ILVariableEqualityComparer.Instance.Equals(variable2, variable4))
			{
				return false;
			}
			if (!targetBlock.Instructions[2].MatchIfInstruction(out condition, out var trueInst2))
			{
				return false;
			}
			if (!targetBlock.Instructions[3].MatchBranch(out var targetBlock3) || (!trueInst2.MatchBranch(out var targetBlock4) && !(trueInst2 is Leave)))
			{
				return false;
			}
			if (!condition.MatchCompEquals(out left, out right) || !right.MatchLdNull() || !left.MatchLdLoc(variable3))
			{
				return false;
			}
			if (call.Arguments.Count != 2 || !MatchDictionaryFieldLoad(call.Arguments[0], IsNonGenericHashtable, out var dictField, out var _) || !call.Arguments[1].MatchLdLoc(variable2))
			{
				return false;
			}
			if (!hashtableInitializers.TryGetValue(dictField, out (List<(string, int)>, IfInstruction, Block, Block, Block, bool) value5))
			{
				return false;
			}
			var (list, _, _, _, _, _) = value5;
			if (targetBlock3.IncomingEdgeCount != 1 || targetBlock3.Instructions.Count != 1)
			{
				return false;
			}
			if (!(targetBlock3.Instructions[0] is SwitchInstruction switchInstruction) || !switchInstruction.Value.MatchLdObj(out var target, out var type) || !target.MatchUnbox(out var argument, out var type2) || !argument.MatchLdLoc(variable4) || !type.IsKnownType(KnownTypeCode.Int32) || !type2.Equals(type))
			{
				return false;
			}
			List<SwitchSection> list2 = new List<SwitchSection>(switchInstruction.Sections);
			if (!(trueInst is Leave) && targetBlock2 != targetBlock4 && !AddNullSection(list2, list, targetBlock2))
			{
				return false;
			}
			StringToInt value6 = new StringToInt(value, list);
			SwitchInstruction switchInstruction2 = new SwitchInstruction(value6);
			switchInstruction2.Sections.AddRange(list2);
			switchInstruction2.AddILRange(block.Instructions[i]);
			block.Instructions[i].ReplaceWith(switchInstruction2);
			block.Instructions.RemoveRange(i + 1, 3);
			value5.Item6 = true;
			hashtableInitializers[dictField] = value5;
			return true;
		}
	}

	private bool FindHashtableInitBlock(Block entryPoint, out List<(string, int)> stringValues, out IField dictField, out Block blockAfterThisInitBlock, out ILInstruction thisSwitchInitJumpInst, out ILInstruction nextSwitchInitJumpInst)
	{
		stringValues = null;
		dictField = null;
		blockAfterThisInitBlock = null;
		nextSwitchInitJumpInst = null;
		thisSwitchInitJumpInst = null;
		if (entryPoint.Instructions.Count != 2)
		{
			return false;
		}
		if (!entryPoint.Instructions[0].MatchIfInstruction(out var condition, out var trueInst))
		{
			return false;
		}
		if (!entryPoint.Instructions[1].MatchBranch(out var targetBlock))
		{
			return false;
		}
		if (!condition.MatchCompNotEquals(out var left, out var right) || !right.MatchLdNull() || !MatchDictionaryFieldLoad(left, IsNonGenericHashtable, out dictField, out var dictionaryType))
		{
			return false;
		}
		if (!trueInst.MatchBranch(out var targetBlock2))
		{
			return false;
		}
		thisSwitchInitJumpInst = entryPoint.Instructions[0];
		if (targetBlock.IncomingEdgeCount != 1 || targetBlock.Instructions.Count < 3)
		{
			return false;
		}
		if (!ExtractStringValuesFromInitBlock(targetBlock, out stringValues, out blockAfterThisInitBlock, dictionaryType, dictField, isHashtablePattern: true))
		{
			return false;
		}
		if (targetBlock.Instructions.SecondToLastOrDefault() is IfInstruction ifInstruction)
		{
			if (!ifInstruction.Condition.MatchCompNotEquals(out left, out right) || !right.MatchLdNull() || !MatchDictionaryFieldLoad(left, IsNonGenericHashtable, out var _, out var _))
			{
				return false;
			}
			if (!ifInstruction.TrueInst.MatchBranch(targetBlock2))
			{
				return false;
			}
			nextSwitchInitJumpInst = ifInstruction;
		}
		return true;
	}

	private bool MatchRoslynSwitchOnString(InstructionCollection<ILInstruction> instructions, ref int i)
	{
		List<(int, string, Block)> stringValues;
		int index;
		SwitchSection defaultSection;
		ILInstruction switchValueInst;
		checked
		{
			if (i >= instructions.Count - 1)
			{
				return false;
			}
			InstructionCollection<ILInstruction> instructionCollection = instructions;
			int num = i;
			Block targetBlock = null;
			if (instructions[i].MatchIfInstruction(out var condition, out var trueInst) && condition.MatchCompEquals(out var _, out var right) && right.MatchLdNull())
			{
				if (!(instructions[i + 1] is Branch branch) || branch.TargetBlock.IncomingEdgeCount != 1)
				{
					return false;
				}
				if (!trueInst.MatchBranch(out targetBlock))
				{
					return false;
				}
				instructionCollection = branch.TargetBlock.Instructions;
				num = 0;
			}
			if (num + 1 >= instructionCollection.Count || !(instructionCollection[num + 1] is SwitchInstruction switchInstruction) || !switchInstruction.Value.MatchLdLoc(out var variable) || !MatchComputeStringHashCall(instructionCollection[num], variable, out var switchValue))
			{
				return false;
			}
			stringValues = new List<(int, string, Block)>();
			index = 0;
			defaultSection = switchInstruction.Sections.MaxBy((SwitchSection s) => s.Labels.Count());
			Block block = null;
			foreach (SwitchSection section in switchInstruction.Sections)
			{
				if (section != defaultSection)
				{
					if (!section.Body.MatchBranch(out var targetBlock2))
					{
						return false;
					}
					if (!MatchRoslynCaseBlockHead(targetBlock2, switchValue.Variable, out var body, out var defaultOrExitBlock, out var stringValue))
					{
						return false;
					}
					if (block != null && block != defaultOrExitBlock)
					{
						return false;
					}
					block = defaultOrExitBlock;
					stringValues.Add((index++, stringValue, body));
				}
			}
			if (targetBlock != null && block != targetBlock)
			{
				stringValues.Add((index++, null, targetBlock));
			}
			switchValueInst = switchValue;
			if (instructions == instructionCollection)
			{
				bool flag;
				if (i >= 1 && instructions[i - 1].MatchStLoc(switchValue.Variable, out var value) && switchValue.Variable.IsSingleDefinition && switchValue.Variable.LoadCount == switchInstruction.Sections.Count)
				{
					switchValueInst = value;
					flag = false;
				}
				else
				{
					flag = true;
				}
				SwitchInstruction switchInstruction2 = ReplaceWithSwitchInstruction(i);
				switchInstruction2.AddILRange(instructions[i + 1]);
				instructions.RemoveAt(i + 1);
				if (!flag)
				{
					switchInstruction2.AddILRange(instructions[i - 1]);
					instructions.RemoveRange(i - 1, 1);
					i--;
				}
			}
			else
			{
				bool flag2;
				if (i >= 2 && instructions[i - 2].MatchStLoc(out var variable2, out var value2) && instructions[i - 1].MatchStLoc(switchValue.Variable, out var value3) && value3.MatchLdLoc(variable2))
				{
					switchValueInst = value2;
					flag2 = false;
				}
				else
				{
					flag2 = true;
				}
				SwitchInstruction switchInstruction3 = ReplaceWithSwitchInstruction(i);
				switchInstruction3.AddILRange(switchInstruction);
				switchInstruction3.AddILRange(instructions[i + 1]);
				instructions.RemoveAt(i + 1);
				if (!flag2)
				{
					switchInstruction3.AddILRange(instructions[i - 2]);
					instructions.RemoveRange(i - 2, 2);
					i -= 2;
				}
			}
			return true;
		}
		SwitchInstruction ReplaceWithSwitchInstruction(int offset)
		{
			LongSet labels = new LongSet(new LongInterval(0L, index)).Invert();
			SwitchInstruction switchInstruction4 = new SwitchInstruction(new StringToInt(switchValueInst, Enumerable.ToArray<string>(Enumerable.Select<(int, string, Block), string>((IEnumerable<(int, string, Block)>)stringValues, (Func<(int, string, Block), string>)(((int, string, Block) item) => item.Item2)))));
			switchInstruction4.Sections.AddRange(Enumerable.Select<(int, string, Block), SwitchSection>((IEnumerable<(int, string, Block)>)stringValues, (Func<(int, string, Block), SwitchSection>)(((int, string, Block) section) => new SwitchSection
			{
				Labels = new LongSet(section.Item1),
				Body = new Branch(section.Item3)
			})));
			switchInstruction4.Sections.Add(new SwitchSection
			{
				Labels = labels,
				Body = defaultSection.Body
			});
			instructions[offset].ReplaceWith(switchInstruction4);
			return switchInstruction4;
		}
	}

	private bool MatchRoslynCaseBlockHead(Block target, ILVariable switchValueVar, out Block body, out Block defaultOrExitBlock, out string stringValue)
	{
		body = null;
		defaultOrExitBlock = null;
		stringValue = null;
		if (target.Instructions.Count != 2)
		{
			return false;
		}
		if (!target.Instructions[0].MatchIfInstruction(out var condition, out var trueInst))
		{
			return false;
		}
		BlockContainer targetContainer;
		if (MatchStringEqualityComparison(condition, switchValueVar, out stringValue))
		{
			ILInstruction iLInstruction = target.Instructions[1];
			if (!iLInstruction.MatchBranch(out defaultOrExitBlock) && !iLInstruction.MatchLeave(out targetContainer))
			{
				return false;
			}
			return trueInst.MatchBranch(out body) && body != null;
		}
		if (condition.MatchLogicNot(out condition) && MatchStringEqualityComparison(condition, switchValueVar, out stringValue))
		{
			if (!trueInst.MatchBranch(out defaultOrExitBlock) && !trueInst.MatchLeave(out targetContainer))
			{
				return false;
			}
			return target.Instructions[1].MatchBranch(out body) && body != null;
		}
		return false;
	}

	internal static bool MatchComputeStringHashCall(ILInstruction inst, ILVariable targetVar, out LdLoc switchValue)
	{
		switchValue = null;
		if (!inst.MatchStLoc(targetVar, out var value))
		{
			return false;
		}
		if (!(value is Call call) || call.Arguments.Count != 1 || !(call.Method.Name == "ComputeStringHash") || !call.Method.IsCompilerGeneratedOrIsInCompilerGeneratedClass())
		{
			return false;
		}
		if (!(call.Arguments[0] is LdLoc))
		{
			return false;
		}
		switchValue = (LdLoc)call.Arguments[0];
		return true;
	}

	private bool MatchStringEqualityComparison(ILInstruction condition, ILVariable variable, out string stringValue)
	{
		ILVariable variable2;
		return MatchStringEqualityComparison(condition, out variable2, out stringValue) && variable2 == variable;
	}

	private bool MatchStringEqualityComparison(ILInstruction condition, out ILVariable variable, out string stringValue)
	{
		stringValue = null;
		variable = null;
		if (condition is Call call && call.Method.IsOperator && call.Method.Name == "op_Equality" && call.Method.DeclaringType.IsKnownType(KnownTypeCode.String) && call.Arguments.Count == 2)
		{
			ILInstruction iLInstruction = call.Arguments[0];
			ILInstruction iLInstruction2 = call.Arguments[1];
			return iLInstruction.MatchLdLoc(out variable) && iLInstruction2.MatchLdStr(out stringValue);
		}
		if (condition.MatchCompEqualsNull(out var arg))
		{
			stringValue = null;
			return arg.MatchLdLoc(out variable);
		}
		return false;
	}
}
