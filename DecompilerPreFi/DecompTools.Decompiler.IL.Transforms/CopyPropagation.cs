#define DEBUG
#define STEP
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.IL.Transforms;

public class CopyPropagation : IBlockTransform
{
	public static void Propagate(StLoc store, ILTransformContext context)
	{
		Debug.Assert(store.Variable.IsSingleDefinition);
		Block block = (Block)store.Parent;
		int i = store.ChildIndex;
		DoPropagate(store.Variable, store.Value, block, ref i, context);
	}

	public void Run(Block block, BlockTransformContext context)
	{
		checked
		{
			for (int i = 0; i < block.Instructions.Count; i++)
			{
				if (!block.Instructions[i].MatchStLoc(out var variable, out var value))
				{
					continue;
				}
				if (variable.IsSingleDefinition && variable.LoadCount == 0 && variable.Kind == VariableKind.StackSlot)
				{
					if (SemanticHelper.IsPure(value.Flags))
					{
						context.Step("remove dead store to stack: no-op -> delete", block.Instructions[i]);
						block.Instructions.RemoveAt(i--);
					}
					else
					{
						context.Step("remove dead store to stack: evaluate the value for its side-effects", block.Instructions[i]);
						value.AddILRange(block.Instructions[i]);
						block.Instructions[i] = value;
					}
				}
				else if (variable.IsSingleDefinition && CanPerformCopyPropagation(variable, value))
				{
					DoPropagate(variable, value, block, ref i, context);
				}
			}
		}
	}

	private static bool CanPerformCopyPropagation(ILVariable target, ILInstruction value)
	{
		Debug.Assert(target.StackType == value.ResultType);
		if (target.Type.IsSmallIntegerType())
		{
			return false;
		}
		switch (value.OpCode)
		{
		case OpCode.LdLoca:
		case OpCode.LdsFlda:
			return true;
		case OpCode.LdLoc:
		{
			ILVariable variable = ((LdLoc)value).Variable;
			switch (variable.Kind)
			{
			case VariableKind.Parameter:
				return variable.IsSingleDefinition;
			case VariableKind.ExceptionStackSlot:
			case VariableKind.StackSlot:
				return variable.IsSingleDefinition && target.Kind == VariableKind.StackSlot;
			default:
				return false;
			}
		}
		default:
			return value.Flags == InstructionFlags.None && value.Children.Count == 0 && target.Kind == VariableKind.StackSlot;
		}
	}

	private static void DoPropagate(ILVariable v, ILInstruction copiedExpr, Block block, ref int i, ILTransformContext context)
	{
		context.Step("Copy propagate " + v.Name, copiedExpr);
		ILVariable[] array = new ILVariable[copiedExpr.Children.Count];
		checked
		{
			for (int j = 0; j < array.Length; j++)
			{
				ILInstruction iLInstruction = copiedExpr.Children[j];
				IType type = context.TypeSystem.FindType(iLInstruction.ResultType.ToKnownTypeCode());
				array[j] = new ILVariable(VariableKind.StackSlot, type, iLInstruction.ResultType)
				{
					Name = "C_" + iLInstruction.StartILOffset,
					HasGeneratedName = true
				};
				block.Instructions.Insert(i++, new StLoc(array[j], iLInstruction));
			}
			v.Function.Variables.AddRange(array);
			LdLoc[] array2 = Enumerable.ToArray<LdLoc>((IEnumerable<LdLoc>)v.LoadInstructions);
			foreach (LdLoc ldLoc in array2)
			{
				ILInstruction iLInstruction2 = copiedExpr.Clone();
				for (int l = 0; l < array.Length; l++)
				{
					iLInstruction2.Children[l].ReplaceWith(new LdLoc(array[l]));
				}
				ldLoc.ReplaceWith(iLInstruction2);
			}
			block.Instructions.RemoveAt(i);
			int num = ILInlining.InlineInto(block, i, InliningOptions.None, context);
			i -= num + 1;
		}
	}
}
