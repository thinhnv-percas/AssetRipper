#define STEP
#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DecompTools.Decompiler.IL.Transforms;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL.ControlFlow;

public class DetectPinnedRegions : IILTransform
{
	private ILTransformContext context;

	public void Run(ILFunction function, ILTransformContext context)
	{
		this.context = context;
		foreach (BlockContainer item in Enumerable.OfType<BlockContainer>((IEnumerable)function.Descendants))
		{
			context.CancellationToken.ThrowIfCancellationRequested();
			DetectNullSafeArrayToPointer(item);
			SplitBlocksAtWritesToPinnedLocals(item);
			foreach (Block block in item.Blocks)
			{
				DetectPinnedRegion(block);
			}
			item.Blocks.RemoveAll((Block b) => b.Instructions.Count == 0);
		}
		checked
		{
			foreach (Block item2 in Enumerable.OfType<Block>((IEnumerable)function.Descendants))
			{
				context.CancellationToken.ThrowIfCancellationRequested();
				for (int num = 0; num < item2.Instructions.Count; num++)
				{
					if (item2.Instructions[num] is StLoc stLoc && stLoc.Variable.Kind == VariableKind.PinnedLocal && stLoc.Variable.LoadCount == 0 && stLoc.Variable.AddressCount == 0)
					{
						if (SemanticHelper.IsPure(stLoc.Value.Flags))
						{
							item2.Instructions.RemoveAt(num--);
						}
						else
						{
							stLoc.ReplaceWith(stLoc.Value);
						}
					}
				}
			}
			this.context = null;
		}
	}

	private void SplitBlocksAtWritesToPinnedLocals(BlockContainer container)
	{
		checked
		{
			for (int i = 0; i < container.Blocks.Count; i++)
			{
				Block block = container.Blocks[i];
				for (int j = 0; j < block.Instructions.Count - 1; j++)
				{
					ILInstruction iLInstruction = block.Instructions[j];
					if (iLInstruction.MatchStLoc(out var variable) && variable.Kind == VariableKind.PinnedLocal && block.Instructions[j + 1].OpCode != OpCode.Branch)
					{
						context.Step("Split block after pinned local write", iLInstruction);
						Block block2 = new Block();
						for (int k = j + 1; k < block.Instructions.Count; k++)
						{
							block2.Instructions.Add(block.Instructions[k]);
						}
						block2.AddILRange(block2.Instructions[0]);
						block.Instructions.RemoveRange(j + 1, block2.Instructions.Count);
						block.Instructions.Add(new Branch(block2));
						container.Blocks.Insert(i + 1, block2);
					}
				}
			}
		}
	}

	private void DetectNullSafeArrayToPointer(BlockContainer container)
	{
		bool flag = false;
		checked
		{
			for (int i = 0; i < container.Blocks.Count; i++)
			{
				Block block = container.Blocks[i];
				if (IsNullSafeArrayToPointerPattern(block, out var v, out var p, out var targetBlock))
				{
					context.Step("NullSafeArrayToPointerPattern", block);
					ILInstruction iLInstruction = new ArrayToPointer(new LdLoc(v));
					if (p.StackType != StackType.Ref)
					{
						iLInstruction = new Conv(iLInstruction, p.StackType.ToPrimitiveType(), checkForOverflow: false, Sign.None);
					}
					block.Instructions[block.Instructions.Count - 2] = new StLoc(p, iLInstruction).WithILRange(block.Instructions[block.Instructions.Count - 2]);
					((Branch)block.Instructions.Last()).TargetBlock = targetBlock;
					flag = true;
				}
			}
			if (flag)
			{
				container.Blocks.RemoveAll((Block b) => b.IncomingEdgeCount == 0);
			}
		}
	}

	private bool IsNullSafeArrayToPointerPattern(Block block, out ILVariable v, out ILVariable p, out Block targetBlock)
	{
		v = null;
		p = null;
		targetBlock = null;
		if (!(block.Instructions.SecondToLastOrDefault() is IfInstruction ifInstruction))
		{
			return false;
		}
		if (!(ifInstruction.Condition is Comp { Kind: ComparisonKind.Equality } comp) || !comp.Left.MatchLdLoc(out v) || !comp.Right.MatchLdNull())
		{
			return false;
		}
		bool flag = false;
		if (v.Kind == VariableKind.StackSlot && block.Instructions.ElementAtOrDefault(checked(block.Instructions.Count - 3)) is StLoc stLoc && stLoc.Value.MatchLdLoc(v))
		{
			v = stLoc.Variable;
			flag = true;
		}
		if (!ifInstruction.TrueInst.MatchBranch(out var targetBlock2))
		{
			return false;
		}
		if (!ifInstruction.FalseInst.MatchNop())
		{
			return false;
		}
		if (targetBlock2.Parent != block.Parent)
		{
			return false;
		}
		if (!IsNullSafeArrayToPointerNullOrEmptyBlock(targetBlock2, out p, out targetBlock))
		{
			return false;
		}
		if (p.Kind != VariableKind.PinnedLocal && (!flag || v.Kind != VariableKind.PinnedLocal))
		{
			return false;
		}
		if (!block.Instructions.Last().MatchBranch(out var targetBlock3))
		{
			return false;
		}
		if (targetBlock3.Parent != block.Parent)
		{
			return false;
		}
		return IsNullSafeArrayToPointerNotNullBlock(targetBlock3, v, p, targetBlock2, targetBlock);
	}

	private bool IsNullSafeArrayToPointerNotNullBlock(Block block, ILVariable v, ILVariable p, Block nullOrEmptyBlock, Block targetBlock)
	{
		if (block.Instructions.Count != 2)
		{
			return false;
		}
		if (!block.Instructions[0].MatchIfInstruction(out var condition, out var trueInst))
		{
			return false;
		}
		if (!condition.UnwrapConv(ConversionKind.Truncate).MatchLdLen(StackType.I, out var array))
		{
			return false;
		}
		if (!array.MatchLdLoc(v))
		{
			return false;
		}
		if (!trueInst.MatchBranch(out var targetBlock2))
		{
			return false;
		}
		if (targetBlock2.Parent != block.Parent)
		{
			return false;
		}
		if (!IsNullSafeArrayToPointerNotNullAndNotEmptyBlock(targetBlock2, v, p, targetBlock))
		{
			return false;
		}
		return block.Instructions[1].MatchBranch(nullOrEmptyBlock);
	}

	private bool IsNullSafeArrayToPointerNotNullAndNotEmptyBlock(Block block, ILVariable v, ILVariable p, Block targetBlock)
	{
		if (block.Instructions.Count != 2)
		{
			return false;
		}
		if (!block.Instructions[0].MatchStLoc(p, out var value))
		{
			return false;
		}
		if (v.Kind == VariableKind.PinnedLocal)
		{
			value = value.UnwrapConv(ConversionKind.StopGCTracking);
		}
		if (!(value is LdElema ldElema))
		{
			return false;
		}
		if (!ldElema.Array.MatchLdLoc(v))
		{
			return false;
		}
		if (!Enumerable.All<ILInstruction>((IEnumerable<ILInstruction>)ldElema.Indices, (Func<ILInstruction, bool>)((ILInstruction i) => i.MatchLdcI4(0))))
		{
			return false;
		}
		return block.Instructions[1].MatchBranch(targetBlock);
	}

	private bool IsNullSafeArrayToPointerNullOrEmptyBlock(Block block, out ILVariable p, out Block targetBlock)
	{
		p = null;
		targetBlock = null;
		ILInstruction value;
		return block.Instructions.Count == 2 && block.Instructions[0].MatchStLoc(out p, out value) && (p.Kind == VariableKind.PinnedLocal || p.Kind == VariableKind.Local) && IsNullOrZero(value) && block.Instructions[1].MatchBranch(out targetBlock);
	}

	private bool DetectPinnedRegion(Block block)
	{
		if (!(block.Instructions.SecondToLastOrDefault() is StLoc stLoc) || stLoc.Variable.Kind != VariableKind.PinnedLocal)
		{
			return false;
		}
		if (IsNullOrZero(stLoc.Value))
		{
			return false;
		}
		context.StepStartGroup("DetectPinnedRegion " + stLoc.Variable.Name, block);
		try
		{
			return CreatePinnedRegion(block, stLoc);
		}
		finally
		{
			context.StepEndGroup(keepIfEmpty: true);
		}
	}

	private bool CreatePinnedRegion(Block block, StLoc stLoc)
	{
		BlockContainer blockContainer = (BlockContainer)block.Parent;
		int[] array = new int[blockContainer.Blocks.Count];
		Queue<Block> queue = new Queue<Block>();
		Block targetBlock = ((Branch)block.Instructions.Last()).TargetBlock;
		if (targetBlock.Parent != blockContainer)
		{
			return false;
		}
		checked
		{
			array[targetBlock.ChildIndex]++;
			queue.Enqueue(targetBlock);
			while (queue.Count > 0)
			{
				Block block2 = queue.Dequeue();
				int num = ((!(block2.Instructions.SecondToLastOrDefault() is StLoc stLoc2) || stLoc2.Variable != stLoc.Variable || !IsNullOrZero(stLoc2.Value)) ? block2.Instructions.Count : stLoc2.ChildIndex);
				for (int i = 0; i < num; i++)
				{
					foreach (Branch item in Enumerable.OfType<Branch>((IEnumerable)block2.Instructions[i].Descendants))
					{
						if (item.TargetBlock.Parent == blockContainer)
						{
							if (item.TargetBlock == block)
							{
								return false;
							}
							if (array[item.TargetBlock.ChildIndex]++ == 0)
							{
								queue.Enqueue(item.TargetBlock);
							}
						}
					}
				}
			}
			for (int j = 0; j < blockContainer.Blocks.Count; j++)
			{
				if (array[j] != 0 && array[j] != blockContainer.Blocks[j].IncomingEdgeCount)
				{
					return false;
				}
			}
			context.Step("CreatePinnedRegion", block);
			BlockContainer blockContainer2 = new BlockContainer();
			for (int k = 0; k < blockContainer.Blocks.Count; k++)
			{
				if (array[k] > 0)
				{
					Block block3 = blockContainer.Blocks[k];
					if (block3.Instructions.LastOrDefault() is Branch branch && branch.TargetContainer == blockContainer && array[branch.TargetBlock.ChildIndex] == 0 && block3.Instructions.SecondToLastOrDefault() is StLoc stLoc3 && stLoc3.Variable == stLoc.Variable && IsNullOrZero(stLoc3.Value))
					{
						block3.Instructions.RemoveAt(block3.Instructions.Count - 2);
					}
					blockContainer2.Blocks.Add(block3);
					blockContainer.Blocks[k] = new Block();
				}
			}
			PinnedRegion pinnedRegion = new PinnedRegion(stLoc.Variable, stLoc.Value, blockContainer2).WithILRange(stLoc);
			stLoc.ReplaceWith(pinnedRegion);
			block.Instructions.RemoveAt(block.Instructions.Count - 1);
			ProcessPinnedRegion(pinnedRegion);
			return true;
		}
	}

	private static bool IsNullOrZero(ILInstruction inst)
	{
		while (inst is Conv conv)
		{
			inst = conv.Argument;
		}
		return inst.MatchLdcI4(0) || inst.MatchLdNull();
	}

	private void ProcessPinnedRegion(PinnedRegion pinnedRegion)
	{
		if (pinnedRegion.Variable.Type.Kind == TypeKind.ByReference)
		{
			context.Step("Replace pinned ref-local with native pointer", pinnedRegion);
			ILVariable variable = pinnedRegion.Variable;
			IType elementType = ((ByReferenceType)variable.Type).ElementType;
			if (elementType.Kind == TypeKind.Pointer && pinnedRegion.Init.MatchLdFlda(out var _, out var field) && ((PointerType)elementType).ElementType.Equals(field.Type))
			{
				elementType = ((PointerType)elementType).ElementType;
			}
			ILVariable iLVariable = new ILVariable(VariableKind.PinnedLocal, new PointerType(elementType), variable.Index);
			iLVariable.Name = variable.Name;
			iLVariable.HasGeneratedName = variable.HasGeneratedName;
			variable.Function.Variables.Add(iLVariable);
			ReplacePinnedVar(variable, iLVariable, pinnedRegion);
			UseExistingVariableForPinnedRegion(pinnedRegion);
		}
		else if (pinnedRegion.Variable.Type.Kind == TypeKind.Array)
		{
			context.Step("Replace pinned array with native pointer", pinnedRegion);
			MoveArrayToPointerToPinnedRegionInit(pinnedRegion);
			UseExistingVariableForPinnedRegion(pinnedRegion);
		}
		else if (pinnedRegion.Variable.Type.IsKnownType(KnownTypeCode.String))
		{
			HandleStringToPointer(pinnedRegion);
		}
		BlockContainer blockContainer = (BlockContainer)pinnedRegion.Body;
		foreach (Block block in blockContainer.Blocks)
		{
			DetectPinnedRegion(block);
		}
		blockContainer.Blocks.RemoveAll((Block b) => b.Instructions.Count == 0);
		blockContainer.SetILRange(blockContainer.EntryPoint);
	}

	private void MoveArrayToPointerToPinnedRegionInit(PinnedRegion pinnedRegion)
	{
		Debug.Assert(pinnedRegion.Variable.Type.Kind == TypeKind.Array);
		LdLoc ldLoc = null;
		foreach (IInstructionWithVariableOperand item in Enumerable.OfType<IInstructionWithVariableOperand>((IEnumerable)pinnedRegion.Descendants))
		{
			if (item.Variable == pinnedRegion.Variable && item != pinnedRegion)
			{
				if (ldLoc != null)
				{
					return;
				}
				ldLoc = item as LdLoc;
				if (ldLoc == null)
				{
					return;
				}
			}
		}
		if (ldLoc.Parent is ArrayToPointer { Parent: Conv { Kind: ConversionKind.StopGCTracking } parent } arrayToPointer)
		{
			Debug.Assert(arrayToPointer.IsDescendantOf(pinnedRegion));
			ILVariable variable = pinnedRegion.Variable;
			ILVariable iLVariable = new ILVariable(VariableKind.PinnedLocal, new PointerType(((ArrayType)variable.Type).ElementType), variable.Index);
			iLVariable.Name = variable.Name;
			iLVariable.HasGeneratedName = variable.HasGeneratedName;
			variable.Function.Variables.Add(iLVariable);
			pinnedRegion.Variable = iLVariable;
			pinnedRegion.Init = new ArrayToPointer(pinnedRegion.Init).WithILRange(arrayToPointer);
			parent.ReplaceWith(new LdLoc(iLVariable).WithILRange(parent));
		}
	}

	private void ReplacePinnedVar(ILVariable oldVar, ILVariable newVar, ILInstruction inst)
	{
		Debug.Assert(newVar.StackType == StackType.I);
		if (inst is Conv { Kind: ConversionKind.StopGCTracking } conv && conv.Argument.MatchLdLoc(oldVar) && conv.ResultType == newVar.StackType)
		{
			conv.AddILRange(conv.Argument);
			conv.ReplaceWith(new LdLoc(newVar).WithILRange(conv));
			return;
		}
		string value;
		if (inst is IInstructionWithVariableOperand instructionWithVariableOperand && instructionWithVariableOperand.Variable == oldVar)
		{
			instructionWithVariableOperand.Variable = newVar;
			if (inst is StLoc stLoc && oldVar.Type.Kind == TypeKind.ByReference)
			{
				stLoc.Value = new Conv(stLoc.Value, PrimitiveType.I, checkForOverflow: false, Sign.None);
			}
			if ((inst is LdLoc || inst is StLoc) && !IsSlotAcceptingBothManagedAndUnmanagedPointers(inst.SlotInfo) && oldVar.StackType != StackType.I)
			{
				ILInstruction.ChildrenCollection children = inst.Parent.Children;
				children[inst.ChildIndex] = new Conv(inst, oldVar.StackType.ToPrimitiveType(), checkForOverflow: false, Sign.None);
			}
		}
		else if (inst.MatchLdStr(out value) && value == "Is this ILSpy?")
		{
			inst.ReplaceWith(new LdStr("This is ILSpy!"));
			return;
		}
		foreach (ILInstruction child in inst.Children)
		{
			ReplacePinnedVar(oldVar, newVar, child);
		}
	}

	private bool IsSlotAcceptingBothManagedAndUnmanagedPointers(SlotInfo slotInfo)
	{
		return slotInfo == Block.InstructionSlot || slotInfo == LdObj.TargetSlot || slotInfo == StObj.TargetSlot;
	}

	private bool IsBranchOnNull(ILInstruction condBranch, ILVariable nativeVar, out Block targetBlock)
	{
		targetBlock = null;
		ILInstruction condition;
		ILInstruction trueInst;
		ILInstruction left;
		ILInstruction right;
		return condBranch.MatchIfInstruction(out condition, out trueInst) && condition.MatchCompEquals(out left, out right) && left.MatchLdLoc(nativeVar) && IsNullOrZero(right) && trueInst.MatchBranch(out targetBlock);
	}

	private void HandleStringToPointer(PinnedRegion pinnedRegion)
	{
		Debug.Assert(pinnedRegion.Variable.Type.IsKnownType(KnownTypeCode.String));
		BlockContainer blockContainer = (BlockContainer)pinnedRegion.Body;
		if (blockContainer.EntryPoint.IncomingEdgeCount != 1 || !blockContainer.EntryPoint.Instructions[0].MatchStLoc(out var variable, out var value))
		{
			return;
		}
		Block targetBlock;
		Block targetBlock2;
		if (blockContainer.EntryPoint.Instructions.Count != 3)
		{
			if (variable.IsSingleDefinition && variable.LoadCount == 0 && value.MatchLdLoc(pinnedRegion.Variable) && pinnedRegion.Variable.LoadCount == 1)
			{
				blockContainer.EntryPoint.Instructions.RemoveAt(0);
				PointerType type = new PointerType(context.TypeSystem.FindType(KnownTypeCode.Char));
				ILVariable iLVariable = new ILVariable(VariableKind.PinnedLocal, type, pinnedRegion.Variable.Index);
				iLVariable.Name = pinnedRegion.Variable.Name;
				iLVariable.HasGeneratedName = pinnedRegion.Variable.HasGeneratedName;
				variable.Function.Variables.Add(iLVariable);
				pinnedRegion.Variable = iLVariable;
				pinnedRegion.Init = new ArrayToPointer(pinnedRegion.Init);
			}
		}
		else if (variable.Type.GetStackType() == StackType.I && value.UnwrapConv(ConversionKind.StopGCTracking).MatchLdLoc(pinnedRegion.Variable) && IsBranchOnNull(blockContainer.EntryPoint.Instructions[1], variable, out targetBlock) && targetBlock.Parent == blockContainer && blockContainer.EntryPoint.Instructions[2].MatchBranch(out targetBlock2) && targetBlock2.Parent == blockContainer && targetBlock2.IncomingEdgeCount == 1 && IsOffsetToStringDataBlock(targetBlock2, variable, targetBlock))
		{
			context.Step("Handle pinned string (with adjustOffsetToStringData)", pinnedRegion);
			blockContainer.Blocks.RemoveAt(0);
			blockContainer.Blocks.RemoveAt(targetBlock2.ChildIndex);
			blockContainer.Blocks.RemoveAt(targetBlock.ChildIndex);
			blockContainer.Blocks.Insert(0, targetBlock);
			pinnedRegion.Init = new ArrayToPointer(pinnedRegion.Init);
			if (variable.Kind == VariableKind.StackSlot && variable.LoadCount == 1 && blockContainer.EntryPoint.Instructions[0].MatchStLoc(out var variable2, out var value2) && value2.MatchLdLoc(variable) && variable2.IsSingleDefinition)
			{
				blockContainer.EntryPoint.Instructions.RemoveAt(0);
				variable = variable2;
			}
			ILVariable iLVariable;
			if (variable.Kind == VariableKind.Local)
			{
				iLVariable = new ILVariable(VariableKind.PinnedLocal, variable.Type, variable.Index);
				iLVariable.Name = variable.Name;
				iLVariable.HasGeneratedName = variable.HasGeneratedName;
				variable.Function.Variables.Add(iLVariable);
				ReplacePinnedVar(variable, iLVariable, pinnedRegion);
			}
			else
			{
				iLVariable = variable;
			}
			ReplacePinnedVar(pinnedRegion.Variable, iLVariable, pinnedRegion);
		}
	}

	private bool IsOffsetToStringDataBlock(Block block, ILVariable nativeVar, Block targetBlock)
	{
		if (block.Instructions.Count != 2)
		{
			return false;
		}
		ILInstruction value;
		if (nativeVar.IsSingleDefinition && nativeVar.LoadCount == 2)
		{
			if (!block.Instructions[0].MatchStLoc(out var variable, out value))
			{
				return false;
			}
			if (!variable.IsSingleDefinition || variable.LoadCount != 0)
			{
				return false;
			}
		}
		else
		{
			if (nativeVar.StoreCount != 2)
			{
				return false;
			}
			if (!block.Instructions[0].MatchStLoc(nativeVar, out value))
			{
				return false;
			}
		}
		if (!value.MatchBinaryNumericInstruction(BinaryNumericOperator.Add, out var left, out var right))
		{
			return false;
		}
		if (!left.MatchLdLoc(nativeVar))
		{
			return false;
		}
		if (!IsOffsetToStringDataCall(right))
		{
			return false;
		}
		return block.Instructions[1].MatchBranch(targetBlock);
	}

	private bool IsOffsetToStringDataCall(ILInstruction inst)
	{
		return inst.UnwrapConv(ConversionKind.SignExtend) is Call call && call.Method.FullName == "System.Runtime.CompilerServices.RuntimeHelpers.get_OffsetToStringData";
	}

	private void UseExistingVariableForPinnedRegion(PinnedRegion pinnedRegion)
	{
		if (pinnedRegion.Body is BlockContainer blockContainer && pinnedRegion.Variable.LoadCount == 1 && blockContainer.EntryPoint.Instructions[0].MatchStLoc(out var variable, out var value) && value.MatchLdLoc(pinnedRegion.Variable) && variable.IsSingleDefinition && variable.Type.Equals(pinnedRegion.Variable.Type) && variable.Kind == VariableKind.Local)
		{
			variable.Kind = VariableKind.PinnedLocal;
			pinnedRegion.Variable = variable;
			blockContainer.EntryPoint.Instructions.RemoveAt(0);
		}
	}
}
