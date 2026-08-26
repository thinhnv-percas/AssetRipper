#define DEBUG
#define STEP
using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL.Transforms;

public class ILInlining : IILTransform, IBlockTransform, IStatementTransform
{
	internal enum FindResultType
	{
		Found,
		Stop,
		Continue,
		NamedArgument
	}

	internal readonly struct FindResult
	{
		public readonly FindResultType Type;

		public readonly ILInstruction LoadInst;

		public readonly ILInstruction CallArgument;

		public static readonly FindResult Stop = new FindResult(FindResultType.Stop, null, null);

		public static readonly FindResult Continue = new FindResult(FindResultType.Continue, null, null);

		private FindResult(FindResultType type, ILInstruction loadInst, ILInstruction callArg)
		{
			Type = type;
			LoadInst = loadInst;
			CallArgument = callArg;
		}

		public static FindResult Found(ILInstruction loadInst)
		{
			Debug.Assert(loadInst.OpCode == OpCode.LdLoc || loadInst.OpCode == OpCode.LdLoca);
			return new FindResult(FindResultType.Found, loadInst, null);
		}

		public static FindResult NamedArgument(ILInstruction loadInst, ILInstruction callArg)
		{
			Debug.Assert(loadInst.OpCode == OpCode.LdLoc || loadInst.OpCode == OpCode.LdLoca);
			Debug.Assert(callArg.Parent is CallInstruction);
			return new FindResult(FindResultType.NamedArgument, loadInst, callArg);
		}
	}

	public void Run(ILFunction function, ILTransformContext context)
	{
		int? ctorCallStart = null;
		foreach (Block item in Enumerable.OfType<Block>((IEnumerable)function.Descendants))
		{
			InlineAllInBlock(function, item, context, ref ctorCallStart);
		}
		function.Variables.RemoveDead();
	}

	public void Run(Block block, BlockTransformContext context)
	{
		InlineAllInBlock(context.Function, block, context);
	}

	public void Run(Block block, int pos, StatementTransformContext context)
	{
		InlineOneIfPossible(block, pos, OptionsForBlock(block, pos), context);
	}

	internal static InliningOptions OptionsForBlock(Block block, int pos)
	{
		InliningOptions inliningOptions = InliningOptions.None;
		if (IsCatchWhenBlock(block))
		{
			inliningOptions |= InliningOptions.Aggressive;
		}
		else
		{
			ILFunction function = Enumerable.FirstOrDefault<ILFunction>(Enumerable.OfType<ILFunction>((IEnumerable)block.Ancestors));
			ILInstruction inst = block.Instructions[pos];
			int? ctorCallStart = null;
			if (IsInConstructorInitializer(function, inst, ref ctorCallStart))
			{
				inliningOptions |= InliningOptions.Aggressive;
			}
		}
		return inliningOptions;
	}

	public static bool InlineAllInBlock(ILFunction function, Block block, ILTransformContext context)
	{
		int? ctorCallStart = null;
		return InlineAllInBlock(function, block, context, ref ctorCallStart);
	}

	private static bool InlineAllInBlock(ILFunction function, Block block, ILTransformContext context, ref int? ctorCallStart)
	{
		bool result = false;
		InstructionCollection<ILInstruction> instructions = block.Instructions;
		checked
		{
			for (int num = instructions.Count - 1; num >= 0; num--)
			{
				if (instructions[num] is StLoc inst)
				{
					InliningOptions options = InliningOptions.None;
					if (IsCatchWhenBlock(block) || IsInConstructorInitializer(function, inst, ref ctorCallStart))
					{
						options = InliningOptions.Aggressive;
					}
					if (InlineOneIfPossible(block, num, options, context))
					{
						result = true;
					}
				}
			}
			return result;
		}
	}

	internal static bool IsInConstructorInitializer(ILFunction function, ILInstruction inst, ref int? ctorCallStart)
	{
		if (!ctorCallStart.HasValue)
		{
			if (function == null || !function.Method.IsConstructor)
			{
				ctorCallStart = -1;
			}
			else
			{
				ctorCallStart = Enumerable.FirstOrDefault<ILInstruction>(function.Descendants, (Func<ILInstruction, bool>)((ILInstruction d) => d is CallInstruction callInstruction && !(callInstruction is NewObj) && callInstruction.Method.IsConstructor && callInstruction.Method.DeclaringType.IsReferenceType == true && callInstruction.Parent is Block))?.StartILOffset ?? (-1);
			}
		}
		if (inst.EndILOffset > ctorCallStart.GetValueOrDefault())
		{
			return false;
		}
		ILInstruction iLInstruction = Enumerable.LastOrDefault<ILInstruction>(inst.Ancestors, (Func<ILInstruction, bool>)((ILInstruction instr) => instr.Parent is Block));
		if (iLInstruction == null)
		{
			return false;
		}
		return iLInstruction.EndILOffset <= ctorCallStart.GetValueOrDefault();
	}

	internal static bool IsCatchWhenBlock(Block block)
	{
		BlockContainer blockContainer = BlockContainer.FindClosestContainer(block);
		return blockContainer?.Parent is TryCatchHandler tryCatchHandler && tryCatchHandler.Filter == blockContainer;
	}

	public static int InlineInto(Block block, int pos, InliningOptions options, ILTransformContext context)
	{
		if (pos >= block.Instructions.Count)
		{
			return 0;
		}
		int num = 0;
		checked
		{
			while (--pos >= 0 && InlineOneIfPossible(block, pos, options, context))
			{
				num++;
			}
			return num;
		}
	}

	public static bool InlineIfPossible(Block block, int pos, ILTransformContext context)
	{
		return InlineOneIfPossible(block, pos, InliningOptions.Aggressive, context);
	}

	public static bool InlineOneIfPossible(Block block, int pos, InliningOptions options, ILTransformContext context)
	{
		context.CancellationToken.ThrowIfCancellationRequested();
		if (!(block.Instructions[pos] is StLoc stLoc) || stLoc.Variable.Kind == VariableKind.PinnedLocal)
		{
			return false;
		}
		ILVariable variable = stLoc.Variable;
		if (variable.StoreCount != 1)
		{
			return false;
		}
		if (variable.LoadCount > 1 || checked(variable.LoadCount + variable.AddressCount) != 1)
		{
			return false;
		}
		return InlineOne(stLoc, options, context);
	}

	public static bool InlineOne(StLoc stloc, InliningOptions options, ILTransformContext context)
	{
		ILVariable variable = stloc.Variable;
		Block block = (Block)stloc.Parent;
		int childIndex = stloc.ChildIndex;
		if (DoInline(variable, stloc.Value, block.Instructions.ElementAtOrDefault(checked(childIndex + 1)), options, context))
		{
			stloc.Value.AddILRange(stloc);
			Debug.Assert(block.Instructions[childIndex] == stloc);
			block.Instructions.RemoveAt(childIndex);
			return true;
		}
		if (variable.LoadCount == 0 && variable.AddressCount == 0)
		{
			if (SemanticHelper.IsPure(stloc.Value.Flags))
			{
				context.Step("Remove dead store without side effects", stloc);
				block.Instructions.RemoveAt(childIndex);
				return true;
			}
			if (variable.Kind == VariableKind.StackSlot)
			{
				context.Step("Remove dead store, but keep expression", stloc);
				stloc.Value.AddILRange(stloc);
				stloc.ReplaceWith(stloc.Value);
				return true;
			}
		}
		return false;
	}

	private static bool DoInline(ILVariable v, ILInstruction inlinedExpression, ILInstruction next, InliningOptions options, ILTransformContext context)
	{
		FindResult findResult = FindLoadInNext(next, v, inlinedExpression, options);
		if (findResult.Type == FindResultType.Found || findResult.Type == FindResultType.NamedArgument)
		{
			ILInstruction loadInst = findResult.LoadInst;
			if (loadInst.OpCode == OpCode.LdLoca)
			{
				if (!IsGeneratedValueTypeTemporary((LdLoca)loadInst, v, inlinedExpression))
				{
					return false;
				}
			}
			else
			{
				Debug.Assert(loadInst.OpCode == OpCode.LdLoc);
				if ((options & InliningOptions.Aggressive) == 0 && v.Kind != VariableKind.StackSlot && !NonAggressiveInlineInto(next, findResult, inlinedExpression, v))
				{
					return false;
				}
			}
			if (findResult.Type == FindResultType.NamedArgument)
			{
				NamedArgumentTransform.IntroduceNamedArgument(findResult.CallArgument, context);
			}
			context.Step("Inline variable '" + v.Name + "'", inlinedExpression);
			inlinedExpression.AddILRange(loadInst);
			if (loadInst.OpCode == OpCode.LdLoca)
			{
				loadInst.ReplaceWith(new AddressOf(inlinedExpression));
			}
			else
			{
				loadInst.ReplaceWith(inlinedExpression);
			}
			return true;
		}
		return false;
	}

	private static bool IsGeneratedValueTypeTemporary(LdLoca loadInst, ILVariable v, ILInstruction inlinedExpression)
	{
		Debug.Assert(loadInst.Variable == v);
		return IsUsedAsThisPointerInCall(loadInst) && !IsLValue(inlinedExpression);
	}

	internal static bool IsUsedAsThisPointerInCall(LdLoca ldloca)
	{
		if (ldloca.ChildIndex != 0)
		{
			return false;
		}
		if (!((!ldloca.Variable.Type.IsReferenceType) ?? true))
		{
			return false;
		}
		switch (ldloca.Parent.OpCode)
		{
		case OpCode.Call:
		case OpCode.CallVirt:
			return !((CallInstruction)ldloca.Parent).Method.IsStatic;
		case OpCode.Await:
			return true;
		default:
			return false;
		}
	}

	private static bool IsLValue(ILInstruction inst)
	{
		switch (inst.OpCode)
		{
		case OpCode.LdLoc:
		case OpCode.StLoc:
			return true;
		case OpCode.LdObj:
		{
			IField field = (((LdObj)inst).Target as IInstructionWithFieldOperand)?.Field;
			return field == null || !field.IsReadOnly;
		}
		case OpCode.StObj:
		{
			IField field = (((StObj)inst).Target as IInstructionWithFieldOperand)?.Field;
			return field == null || !field.IsReadOnly;
		}
		case OpCode.Call:
		{
			IMethod method = ((CallInstruction)inst).Method;
			return method.DeclaringType.Kind == TypeKind.Array;
		}
		default:
			return false;
		}
	}

	private static bool NonAggressiveInlineInto(ILInstruction next, FindResult findResult, ILInstruction inlinedExpression, ILVariable v)
	{
		if (findResult.Type == FindResultType.NamedArgument)
		{
			StLoc stLoc = (StLoc)inlinedExpression.Parent;
			return !stLoc.ILStackWasEmpty;
		}
		Debug.Assert(findResult.Type == FindResultType.Found);
		ILInstruction loadInst = findResult.LoadInst;
		Debug.Assert(loadInst.IsDescendantOf(next));
		switch (inlinedExpression.OpCode)
		{
		case OpCode.NumericCompoundAssign:
		case OpCode.UserDefinedCompoundAssign:
		case OpCode.StObj:
		case OpCode.DefaultValue:
		case OpCode.Await:
			return true;
		case OpCode.LdLoc:
			if (v.StateMachineField == null && ((LdLoc)inlinedExpression).Variable.StateMachineField != null)
			{
				return true;
			}
			break;
		}
		ILInstruction parent = loadInst.Parent;
		if (NullableLiftingTransform.MatchNullableCtor(parent, out var _, out var arg))
		{
			parent = parent.Parent;
		}
		if (parent is ILiftableInstruction { IsLifted: not false })
		{
			return true;
		}
		switch (parent.OpCode)
		{
		case OpCode.NullCoalescingInstruction:
			if (NullableType.IsNullable(v.Type))
			{
				return true;
			}
			break;
		case OpCode.NullableUnwrap:
			return true;
		case OpCode.UserDefinedLogicOperator:
		case OpCode.DynamicLogicOperatorInstruction:
			return true;
		case OpCode.LdObj:
		case OpCode.DynamicGetMemberInstruction:
		case OpCode.DynamicGetIndexInstruction:
			if (parent.Parent.OpCode == OpCode.DynamicCompoundAssign)
			{
				return true;
			}
			break;
		case OpCode.LocAllocSpan:
		case OpCode.ArrayToPointer:
			return true;
		}
		switch (next.OpCode)
		{
		case OpCode.Leave:
		case OpCode.YieldReturn:
			return parent == next;
		case OpCode.IfInstruction:
			while (parent.MatchLogicNot(out arg))
			{
				parent = parent.Parent;
			}
			return parent == next;
		case OpCode.BlockContainer:
			if (((BlockContainer)next).EntryPoint.Instructions[0] is SwitchInstruction switchInstruction)
			{
				next = switchInstruction;
				goto case OpCode.SwitchInstruction;
			}
			return false;
		case OpCode.SwitchInstruction:
			if (parent == next)
			{
				return true;
			}
			if (parent.MatchBinaryNumericInstruction(BinaryNumericOperator.Sub) && parent.Parent == next)
			{
				return true;
			}
			if (parent is StringToInt stringToInt && stringToInt.Parent == next)
			{
				return true;
			}
			return false;
		default:
			return false;
		}
	}

	public static bool CanInlineInto(ILInstruction expr, ILVariable v, ILInstruction expressionBeingMoved)
	{
		return FindLoadInNext(expr, v, expressionBeingMoved, InliningOptions.None).Type == FindResultType.Found;
	}

	internal static FindResult FindLoadInNext(ILInstruction expr, ILVariable v, ILInstruction expressionBeingMoved, InliningOptions options)
	{
		if (expr == null)
		{
			return FindResult.Stop;
		}
		if (expr.MatchLdLoc(v) || expr.MatchLdLoca(v))
		{
			return FindResult.Found(expr);
		}
		if (expr is Block block)
		{
			switch (block.Kind)
			{
			case BlockKind.ArrayInitializer:
			case BlockKind.CollectionInitializer:
			case BlockKind.ObjectInitializer:
			case BlockKind.CallInlineAssign:
				if (block.Instructions.Count == 0)
				{
					return FindResult.Stop;
				}
				return NoContinue(FindLoadInNext(block.Instructions[0], v, expressionBeingMoved, options));
			case BlockKind.CallWithNamedArgs:
				return NamedArgumentTransform.CanExtendNamedArgument(block, v, expressionBeingMoved);
			default:
				return FindResult.Stop;
			}
		}
		if (expr is BlockContainer blockContainer && blockContainer.EntryPoint.IncomingEdgeCount == 1)
		{
			return NoContinue(FindLoadInNext(blockContainer.EntryPoint.Instructions[0], v, expressionBeingMoved, options));
		}
		if (expr is NullableRewrap && expressionBeingMoved.HasFlag(InstructionFlags.MayUnwrapNull))
		{
			return FindResult.Stop;
		}
		foreach (ILInstruction child in expr.Children)
		{
			if (!child.SlotInfo.CanInlineInto)
			{
				return FindResult.Stop;
			}
			FindResult result = FindLoadInNext(child, v, expressionBeingMoved, options);
			if (result.Type != FindResultType.Continue)
			{
				if (result.Type == FindResultType.Stop && (options & InliningOptions.IntroduceNamedArguments) != InliningOptions.None && expr is CallInstruction call)
				{
					return NamedArgumentTransform.CanIntroduceNamedArgument(call, child, v, expressionBeingMoved);
				}
				return result;
			}
		}
		if (IsSafeForInlineOver(expr, expressionBeingMoved))
		{
			return FindResult.Continue;
		}
		return FindResult.Stop;
	}

	private static FindResult NoContinue(FindResult findResult)
	{
		if (findResult.Type == FindResultType.Continue)
		{
			return FindResult.Stop;
		}
		return findResult;
	}

	private static bool IsSafeForInlineOver(ILInstruction expr, ILInstruction expressionBeingMoved)
	{
		return SemanticHelper.MayReorder(expressionBeingMoved, expr);
	}

	internal static CallInstruction FindFirstInlinedCall(ILInstruction inst)
	{
		foreach (ILInstruction child in inst.Children)
		{
			if (!child.SlotInfo.CanInlineInto)
			{
				break;
			}
			CallInstruction callInstruction = FindFirstInlinedCall(child);
			if (callInstruction != null)
			{
				return callInstruction;
			}
		}
		return inst as CallInstruction;
	}

	internal static bool CanUninline(ILInstruction arg, ILInstruction stmt)
	{
		Debug.Assert(arg.IsDescendantOf(stmt));
		for (ILInstruction iLInstruction = arg; iLInstruction != stmt; iLInstruction = iLInstruction.Parent)
		{
			if (!iLInstruction.SlotInfo.CanInlineInto)
			{
				return false;
			}
			int childIndex = iLInstruction.ChildIndex;
			for (int i = 0; i < childIndex; i = checked(i + 1))
			{
				ILInstruction inst = iLInstruction.Parent.Children[i];
				if (!SemanticHelper.MayReorder(arg, inst))
				{
					return false;
				}
			}
		}
		return true;
	}
}
