#define STEP
#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DecompTools.Decompiler.IL.ControlFlow;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.IL.Transforms;

public class HighLevelLoopTransform : IILTransform
{
	private ILTransformContext context;

	public void Run(ILFunction function, ILTransformContext context)
	{
		this.context = context;
		foreach (BlockContainer item in Enumerable.OfType<BlockContainer>((IEnumerable)function.Descendants))
		{
			if (item.Kind == ContainerKind.Loop)
			{
				if (MatchWhileLoop(item, out var condition, out var loopBody))
				{
					MatchForLoop(item, condition, loopBody);
				}
				else if (!MatchDoWhileLoop(item))
				{
				}
			}
		}
	}

	private bool MatchWhileLoop(BlockContainer loop, out IfInstruction condition, out Block loopBody)
	{
		condition = null;
		loopBody = loop.EntryPoint;
		if (!(loopBody.Instructions[0] is IfInstruction ifInstruction))
		{
			return false;
		}
		if (!ifInstruction.FalseInst.MatchNop())
		{
			return false;
		}
		if (UsesVariableCapturedInLoop(loop, ifInstruction.Condition))
		{
			return false;
		}
		condition = ifInstruction;
		if (!ifInstruction.TrueInst.MatchLeave(loop))
		{
			if (loopBody.Instructions.Count != 2 || !loop.EntryPoint.Instructions.Last().MatchLeave(loop))
			{
				return false;
			}
			if (!ifInstruction.TrueInst.HasFlag(InstructionFlags.EndPointUnreachable))
			{
				((Block)ifInstruction.TrueInst).Instructions.Add(new Leave(loop));
			}
			ConditionDetection.InvertIf(loopBody, ifInstruction, context);
		}
		context.Step("Transform to while (condition) loop: " + loop.EntryPoint.Label, loop);
		loop.Kind = ContainerKind.While;
		ifInstruction.Condition = Comp.LogicNot(ifInstruction.Condition);
		ifInstruction.FalseInst = ifInstruction.TrueInst;
		loopBody = ConditionDetection.ExtractBlock(loop.EntryPoint, 1, loop.EntryPoint.Instructions.Count);
		loop.Blocks.Insert(1, loopBody);
		if (!loopBody.HasFlag(InstructionFlags.EndPointUnreachable))
		{
			loopBody.Instructions.Add(new Leave(loop));
		}
		ifInstruction.TrueInst = new Branch(loopBody);
		ExpressionTransforms.RunOnSingleStatement(ifInstruction, context);
		return true;
	}

	private bool MightBeHeaderOfForEach(BlockContainer loop, List<ILInstruction> conditions)
	{
		if (conditions.Count <= 1)
		{
			return false;
		}
		if (!(conditions[0] is CallInstruction callInstruction) || !(callInstruction.Method.Name == "MoveNext") || !Enumerable.Any<ILInstruction>(conditions[1].Descendants, (Func<ILInstruction, bool>)IsGetCurrentCall))
		{
			return false;
		}
		return loop.Parent?.Parent?.Parent is UsingInstruction;
		static bool IsGetCurrentCall(ILInstruction inst)
		{
			return inst is CallInstruction callInstruction2 && callInstruction2.Method.IsAccessor && callInstruction2.Method.Name == "get_Current";
		}
	}

	private void SplitConditions(ILInstruction expression, List<ILInstruction> conditions)
	{
		if (expression.MatchLogicAnd(out var lhs, out var rhs))
		{
			SplitConditions(lhs, conditions);
			SplitConditions(rhs, conditions);
		}
		else
		{
			conditions.Add(expression);
		}
	}

	private bool MatchDoWhileLoop(BlockContainer loop)
	{
		var (list, iLInstruction, flag, flag2, flag3) = AnalyzeDoWhileConditions(loop);
		if (list == null || list.Count == 0)
		{
			return false;
		}
		context.Step("Transform to do-while loop: " + loop.EntryPoint.Label, loop);
		Block block = (Block)iLInstruction.Parent;
		checked
		{
			if (flag3)
			{
				Debug.Assert(block.Parent is IfInstruction);
				IfInstruction ifInstruction = (IfInstruction)block.Parent;
				Block block2 = (Block)ifInstruction.Parent;
				Debug.Assert(block2.Parent == loop);
				ILInstruction iLInstruction2 = block2.Instructions[ifInstruction.ChildIndex + 1];
				Debug.Assert(iLInstruction2.MatchReturn(out var _));
				ifInstruction.Condition = Comp.LogicNot(ifInstruction.Condition);
				ifInstruction.TrueInst = iLInstruction2;
				ExpressionTransforms.RunOnSingleStatement(ifInstruction, context);
				block2.Instructions.RemoveAt(ifInstruction.ChildIndex + 1);
				block2.Instructions.AddRange(block.Instructions);
				block = block2;
				flag2 = true;
			}
			block.Instructions.RemoveRange(block.Instructions.Count - list.Count - 1, list.Count + 1);
			Block block3;
			if (flag2)
			{
				block3 = new Block();
				loop.Blocks.Add(block3);
				block.Instructions.Add(new Branch(block3));
			}
			else
			{
				block3 = block;
				loop.Blocks.MoveElementToEnd(block);
			}
			IfInstruction ifInstruction2 = null;
			block3.AddILRange(iLInstruction);
			foreach (IfInstruction item in list)
			{
				block3.AddILRange(item);
				if (ifInstruction2 == null)
				{
					ifInstruction2 = item;
					if (flag)
					{
						ifInstruction2.Condition = Comp.LogicNot(ifInstruction2.Condition);
						ifInstruction2.FalseInst = ifInstruction2.TrueInst;
						ifInstruction2.TrueInst = iLInstruction;
					}
					else
					{
						ifInstruction2.FalseInst = iLInstruction;
					}
				}
				else if (flag)
				{
					ifInstruction2.Condition = IfInstruction.LogicAnd(Comp.LogicNot(item.Condition), ifInstruction2.Condition);
				}
				else
				{
					ifInstruction2.Condition = IfInstruction.LogicAnd(item.Condition, ifInstruction2.Condition);
				}
			}
			block3.Instructions.Add(ifInstruction2);
			ExpressionTransforms.RunOnSingleStatement(ifInstruction2, context);
			loop.Kind = ContainerKind.DoWhile;
			return true;
		}
	}

	private static (List<IfInstruction> conditions, ILInstruction exit, bool swap, bool split, bool unwrap) AnalyzeDoWhileConditions(BlockContainer loop)
	{
		foreach (Block item2 in Enumerable.Reverse<Block>((IEnumerable<Block>)loop.Blocks))
		{
			if (MatchDoWhileConditionBlock(loop, item2, out var swapBranches, out var unwrapCondtionBlock, out var conditionBlock))
			{
				List<IfInstruction> list = CollectConditions(loop, conditionBlock, swapBranches);
				bool item = conditionBlock == loop.EntryPoint || conditionBlock.Instructions.Count > checked(list.Count + 1);
				return (conditions: list, exit: conditionBlock.Instructions.Last(), swap: swapBranches, split: item, unwrap: unwrapCondtionBlock);
			}
		}
		return (conditions: null, exit: null, swap: false, split: false, unwrap: false);
	}

	private static List<IfInstruction> CollectConditions(BlockContainer loop, Block block, bool swap)
	{
		List<IfInstruction> list = new List<IfInstruction>();
		checked
		{
			int num = block.Instructions.Count - 2;
			while (num >= 0 && block.Instructions[num] is IfInstruction ifInstruction && ifInstruction.FalseInst.MatchNop() && !UsesVariableCapturedInLoop(loop, ifInstruction.Condition))
			{
				if (swap)
				{
					if (!ifInstruction.TrueInst.MatchLeave(loop))
					{
						break;
					}
					list.Add(ifInstruction);
				}
				else
				{
					if (!ifInstruction.TrueInst.MatchBranch(loop.EntryPoint))
					{
						break;
					}
					list.Add(ifInstruction);
				}
				num--;
			}
			return list;
		}
	}

	private static bool UsesVariableCapturedInLoop(BlockContainer loop, ILInstruction condition)
	{
		foreach (IInstructionWithVariableOperand item in Enumerable.OfType<IInstructionWithVariableOperand>((IEnumerable)condition.Descendants))
		{
			if (item.Variable.CaptureScope == loop)
			{
				return true;
			}
		}
		return false;
	}

	private static bool MatchDoWhileConditionBlock(BlockContainer loop, Block block, out bool swapBranches, out bool unwrapCondtionBlock, out Block conditionBlock)
	{
		swapBranches = false;
		unwrapCondtionBlock = false;
		conditionBlock = block;
		if (block.Instructions.Count < 2)
		{
			return false;
		}
		ILInstruction iLInstruction = block.Instructions.Last();
		IfInstruction ifInstruction = block.Instructions.SecondToLastOrDefault() as IfInstruction;
		if (ifInstruction == null || !ifInstruction.FalseInst.MatchNop())
		{
			return false;
		}
		if (iLInstruction.MatchReturn(out var _) && ifInstruction.TrueInst is Block block2)
		{
			if (block2.Instructions.Count < 2)
			{
				return false;
			}
			iLInstruction = block2.Instructions.Last();
			ifInstruction = block2.Instructions.SecondToLastOrDefault() as IfInstruction;
			if (ifInstruction == null || !ifInstruction.FalseInst.MatchNop())
			{
				return false;
			}
			unwrapCondtionBlock = true;
			conditionBlock = block2;
		}
		if (iLInstruction.MatchBranch(loop.EntryPoint))
		{
			swapBranches = true;
		}
		else
		{
			if (!iLInstruction.MatchLeave(loop))
			{
				return false;
			}
			swapBranches = false;
		}
		if (swapBranches)
		{
			if (!ifInstruction.TrueInst.MatchLeave(loop))
			{
				return false;
			}
		}
		else if (!ifInstruction.TrueInst.MatchBranch(loop.EntryPoint))
		{
			return false;
		}
		return true;
	}

	internal static bool MatchDoWhileConditionBlock(Block block, out Block target1, out Block target2)
	{
		target1 = (target2 = null);
		if (block.Instructions.Count < 2)
		{
			return false;
		}
		ILInstruction iLInstruction = block.Instructions.Last();
		if (!(block.Instructions.SecondToLastOrDefault() is IfInstruction ifInstruction) || !ifInstruction.FalseInst.MatchNop())
		{
			return false;
		}
		ILInstruction value;
		return (ifInstruction.TrueInst.MatchBranch(out target1) || ifInstruction.TrueInst.MatchReturn(out value)) && (iLInstruction.MatchBranch(out target2) || iLInstruction.MatchReturn(out value));
	}

	internal static Block GetIncrementBlock(BlockContainer loop, Block whileLoopBody)
	{
		return Enumerable.SingleOrDefault<Block>((IEnumerable<Block>)loop.Blocks, (Func<Block, bool>)((Block b) => b != whileLoopBody && b.Instructions.Last().MatchBranch(loop.EntryPoint) && Enumerable.All<ILInstruction>(b.Instructions.SkipLast(1), (Func<ILInstruction, bool>)IsSimpleStatement)));
	}

	internal static bool MatchIncrementBlock(Block block, out Block loopHead)
	{
		return block.Instructions.Last().MatchBranch(out loopHead) && Enumerable.All<ILInstruction>(block.Instructions.SkipLast(1), (Func<ILInstruction, bool>)IsSimpleStatement);
	}

	private bool MatchForLoop(BlockContainer loop, IfInstruction whileCondition, Block whileLoopBody)
	{
		if (loop.EntryPoint.IncomingEdgeCount != 2)
		{
			return false;
		}
		Block incrementBlock = GetIncrementBlock(loop, whileLoopBody);
		checked
		{
			if (incrementBlock != null)
			{
				if (incrementBlock.Instructions.Count <= 1 || loop.Blocks.Count < 3)
				{
					return false;
				}
				context.Step("Transform to for loop: " + loop.EntryPoint.Label, loop);
				loop.Blocks.MoveElementToEnd(incrementBlock);
				loop.Kind = ContainerKind.For;
			}
			else
			{
				ILInstruction iLInstruction = whileLoopBody.Instructions.LastOrDefault();
				ILInstruction iLInstruction2 = whileLoopBody.Instructions.SecondToLastOrDefault();
				if (iLInstruction == null || iLInstruction2 == null)
				{
					return false;
				}
				if (!iLInstruction.MatchBranch(loop.EntryPoint))
				{
					return false;
				}
				if (!MatchIncrement(iLInstruction2, out var incrementVariable))
				{
					return false;
				}
				if (incrementVariable.Kind == VariableKind.Parameter)
				{
					return false;
				}
				List<ILInstruction> list = new List<ILInstruction>();
				SplitConditions(whileCondition.Condition, list);
				IfInstruction ifInstruction = null;
				int num = 0;
				foreach (ILInstruction item in list)
				{
					if (!Enumerable.Any<ILInstruction>(item.Descendants, (Func<ILInstruction, bool>)((ILInstruction inst) => inst.MatchLdLoc(incrementVariable))) || Enumerable.Any<ILInstruction>(item.Descendants, (Func<ILInstruction, bool>)IsAssignment))
					{
						break;
					}
					if (ifInstruction == null)
					{
						ifInstruction = new IfInstruction(item, whileCondition.TrueInst, whileCondition.FalseInst);
					}
					else
					{
						ifInstruction.Condition = IfInstruction.LogicAnd(ifInstruction.Condition, item);
					}
					num++;
				}
				if (num == 0)
				{
					return false;
				}
				context.Step("Transform to for loop: " + loop.EntryPoint.Label, loop);
				whileCondition.ReplaceWith(ifInstruction);
				ExpressionTransforms.RunOnSingleStatement(ifInstruction, context);
				for (int num2 = list.Count - 1; num2 >= num; num2--)
				{
					IfInstruction statement;
					whileLoopBody.Instructions.Insert(0, statement = new IfInstruction(Comp.LogicNot(list[num2]), new Leave(loop)));
					ExpressionTransforms.RunOnSingleStatement(statement, context);
				}
				int childIndex = iLInstruction2.ChildIndex;
				Block block = new Block();
				loop.Blocks.Add(block);
				block.Instructions.Add(iLInstruction2);
				block.Instructions.Add(iLInstruction);
				block.AddILRange(iLInstruction2);
				whileLoopBody.Instructions.RemoveRange(childIndex, 2);
				whileLoopBody.Instructions.Add(new Branch(block));
				loop.Kind = ContainerKind.For;
			}
			return true;
		}
	}

	private bool IsAssignment(ILInstruction inst)
	{
		if (inst is StLoc)
		{
			return true;
		}
		if (inst is CompoundAssignmentInstruction)
		{
			return true;
		}
		return false;
	}

	public static bool MatchIncrement(ILInstruction inst, out ILVariable variable)
	{
		if (!inst.MatchStLoc(out variable, out var value))
		{
			return false;
		}
		if (!value.MatchBinaryNumericInstruction(BinaryNumericOperator.Add, out var left, out var _))
		{
			if (!(value is CompoundAssignmentInstruction compoundAssignmentInstruction))
			{
				return false;
			}
			left = compoundAssignmentInstruction.Target;
		}
		return left.MatchLdLoc(variable);
	}

	private static bool IsSimpleStatement(ILInstruction inst)
	{
		switch (inst.OpCode)
		{
		case OpCode.NumericCompoundAssign:
		case OpCode.UserDefinedCompoundAssign:
		case OpCode.Call:
		case OpCode.CallVirt:
		case OpCode.StLoc:
		case OpCode.StObj:
		case OpCode.NewObj:
			return true;
		default:
			return false;
		}
	}
}
