#define STEP
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL.Transforms;

internal class LockTransform : IBlockTransform
{
	private BlockTransformContext context;

	void IBlockTransform.Run(Block block, BlockTransformContext context)
	{
		if (!context.Settings.LockStatement)
		{
			return;
		}
		this.context = context;
		checked
		{
			for (int num = block.Instructions.Count - 1; num >= 0; num--)
			{
				if (!TransformLockRoslyn(block, num) && !TransformLockV4(block, num) && !TransformLockV2(block, num))
				{
					TransformLockMCS(block, num);
				}
				if (num >= block.Instructions.Count)
				{
					num = block.Instructions.Count;
				}
			}
		}
	}

	private bool TransformLockMCS(Block block, int i)
	{
		if (i < 2)
		{
			return false;
		}
		checked
		{
			if (!(block.Instructions[i] is TryFinally tryFinally) || !(block.Instructions[i - 2] is StLoc stLoc) || !MatchCall(block.Instructions[i - 1] as Call, "Enter", stLoc.Variable))
			{
				return false;
			}
			if (!stLoc.Variable.IsSingleDefinition)
			{
				return false;
			}
			if (!(tryFinally.TryBlock is BlockContainer blockContainer) || blockContainer.EntryPoint.Instructions.Count == 0 || blockContainer.EntryPoint.IncomingEdgeCount != 1)
			{
				return false;
			}
			if (!(tryFinally.FinallyBlock is BlockContainer blockContainer2) || !MatchExitBlock(blockContainer2.EntryPoint, null, stLoc.Variable))
			{
				return false;
			}
			if (stLoc.Variable.LoadCount > 2)
			{
				return false;
			}
			context.Step("LockTransformMCS", block);
			block.Instructions.RemoveAt(i - 1);
			block.Instructions.RemoveAt(i - 2);
			tryFinally.ReplaceWith(new LockInstruction(stLoc.Value, tryFinally.TryBlock).WithILRange(stLoc));
			return true;
		}
	}

	private bool TransformLockV2(Block block, int i)
	{
		if (i < 2)
		{
			return false;
		}
		checked
		{
			if (!(block.Instructions[i] is TryFinally tryFinally) || !(block.Instructions[i - 2] is StLoc stLoc) || !stLoc.Value.MatchLdLoc(out var variable) || !MatchCall(block.Instructions[i - 1] as Call, "Enter", variable))
			{
				return false;
			}
			if (!stLoc.Variable.IsSingleDefinition)
			{
				return false;
			}
			if (!(tryFinally.TryBlock is BlockContainer blockContainer) || blockContainer.EntryPoint.Instructions.Count == 0 || blockContainer.EntryPoint.IncomingEdgeCount != 1)
			{
				return false;
			}
			if (!(tryFinally.FinallyBlock is BlockContainer blockContainer2) || !MatchExitBlock(blockContainer2.EntryPoint, null, stLoc.Variable))
			{
				return false;
			}
			if (stLoc.Variable.LoadCount > 1)
			{
				return false;
			}
			context.Step("LockTransformV2", block);
			block.Instructions.RemoveAt(i - 1);
			block.Instructions.RemoveAt(i - 2);
			tryFinally.ReplaceWith(new LockInstruction(stLoc.Value, tryFinally.TryBlock).WithILRange(stLoc));
			return true;
		}
	}

	private bool TransformLockV4(Block block, int i)
	{
		if (i < 1)
		{
			return false;
		}
		checked
		{
			if (!(block.Instructions[i] is TryFinally tryFinally) || !(block.Instructions[i - 1] is StLoc stLoc))
			{
				return false;
			}
			if (!stLoc.Variable.Type.IsKnownType(KnownTypeCode.Boolean) || !stLoc.Value.MatchLdcI4(0))
			{
				return false;
			}
			if (!(tryFinally.TryBlock is BlockContainer blockContainer) || !MatchLockEntryPoint(blockContainer.EntryPoint, stLoc.Variable, out var obj))
			{
				return false;
			}
			if (!(tryFinally.FinallyBlock is BlockContainer blockContainer2) || !MatchExitBlock(blockContainer2.EntryPoint, stLoc.Variable, obj.Variable))
			{
				return false;
			}
			if (obj.Variable.LoadCount > 1)
			{
				return false;
			}
			context.Step("LockTransformV4", block);
			block.Instructions.RemoveAt(i - 1);
			blockContainer.EntryPoint.Instructions.RemoveAt(0);
			tryFinally.ReplaceWith(new LockInstruction(obj.Value, tryFinally.TryBlock).WithILRange(obj));
			return true;
		}
	}

	private bool TransformLockRoslyn(Block block, int i)
	{
		if (i < 2)
		{
			return false;
		}
		checked
		{
			if (!(block.Instructions[i] is TryFinally tryFinally) || !(block.Instructions[i - 1] is StLoc stLoc) || !(block.Instructions[i - 2] is StLoc stLoc2))
			{
				return false;
			}
			if (!stLoc2.Variable.IsSingleDefinition || !stLoc.Variable.Type.IsKnownType(KnownTypeCode.Boolean) || !stLoc.Value.MatchLdcI4(0))
			{
				return false;
			}
			if (!(tryFinally.TryBlock is BlockContainer blockContainer) || !MatchLockEntryPoint(blockContainer.EntryPoint, stLoc.Variable, stLoc2.Variable))
			{
				return false;
			}
			if (!(tryFinally.FinallyBlock is BlockContainer blockContainer2) || !MatchExitBlock(blockContainer2.EntryPoint, stLoc.Variable, stLoc2.Variable))
			{
				return false;
			}
			if (stLoc2.Variable.LoadCount > 2)
			{
				return false;
			}
			context.Step("LockTransformRoslyn", block);
			block.Instructions.RemoveAt(i - 1);
			block.Instructions.RemoveAt(i - 2);
			blockContainer.EntryPoint.Instructions.RemoveAt(0);
			tryFinally.ReplaceWith(new LockInstruction(stLoc2.Value, tryFinally.TryBlock).WithILRange(stLoc2));
			return true;
		}
	}

	private bool MatchExitBlock(Block entryPoint, ILVariable flag, ILVariable obj)
	{
		if (entryPoint.Instructions.Count != 2 || entryPoint.IncomingEdgeCount != 1)
		{
			return false;
		}
		if (flag != null)
		{
			if (!entryPoint.Instructions[0].MatchIfInstruction(out var condition, out var trueInst) || !(trueInst is Block exitBlock))
			{
				return false;
			}
			if ((!condition.MatchLdLoc(flag) && (!condition.MatchCompNotEquals(out var left, out var right) || !left.MatchLdLoc(flag) || !right.MatchLdcI4(0))) || !MatchExitBlock(exitBlock, obj))
			{
				return false;
			}
		}
		else if (!MatchCall(entryPoint.Instructions[0] as Call, "Exit", obj))
		{
			return false;
		}
		if (!entryPoint.Instructions[1].MatchLeave((BlockContainer)entryPoint.Parent, out var value) || !value.MatchNop())
		{
			return false;
		}
		return true;
	}

	private bool MatchExitBlock(Block exitBlock, ILVariable obj)
	{
		if (exitBlock.Instructions.Count != 1)
		{
			return false;
		}
		if (!MatchCall(exitBlock.Instructions[0] as Call, "Exit", obj))
		{
			return false;
		}
		return true;
	}

	private bool MatchLockEntryPoint(Block entryPoint, ILVariable flag, ILVariable obj)
	{
		if (entryPoint.Instructions.Count == 0 || entryPoint.IncomingEdgeCount != 1)
		{
			return false;
		}
		if (!MatchCall(entryPoint.Instructions[0] as Call, "Enter", obj, flag))
		{
			return false;
		}
		return true;
	}

	private bool MatchLockEntryPoint(Block entryPoint, ILVariable flag, out StLoc obj)
	{
		obj = null;
		if (entryPoint.Instructions.Count == 0 || entryPoint.IncomingEdgeCount != 1)
		{
			return false;
		}
		if (!MatchCall(entryPoint.Instructions[0] as Call, "Enter", flag, out obj))
		{
			return false;
		}
		return true;
	}

	private bool MatchCall(Call call, string methodName, ILVariable flag, out StLoc obj)
	{
		obj = null;
		if (call == null || call.Method.Name != methodName || call.Method.DeclaringType.FullName != "System.Threading.Monitor" || call.Method.TypeArguments.Count != 0 || call.Arguments.Count != 2)
		{
			return false;
		}
		if (!call.Arguments[1].MatchLdLoca(flag) || !(call.Arguments[0] is StLoc stLoc))
		{
			return false;
		}
		obj = stLoc;
		return true;
	}

	private bool MatchCall(Call call, string methodName, params ILVariable[] variables)
	{
		if (call == null || call.Method.Name != methodName || call.Method.DeclaringType.FullName != "System.Threading.Monitor" || call.Method.TypeArguments.Count != 0 || call.Arguments.Count != variables.Length)
		{
			return false;
		}
		if (!call.Arguments[0].MatchLdLoc(variables[0]))
		{
			return false;
		}
		if (variables.Length == 2 && !call.Arguments[1].MatchLdLoca(variables[1]))
		{
			return false;
		}
		return true;
	}
}
