namespace DecompTools.Decompiler.IL.Transforms;

internal class CombineExitsTransform : IILTransform
{
	public void Run(ILFunction function, ILTransformContext context)
	{
		if (function.Body is BlockContainer blockContainer && blockContainer.Blocks.Count == 1)
		{
			CombineExits(blockContainer.EntryPoint);
		}
	}

	private static Leave CombineExits(Block block)
	{
		if (!(block.Instructions.SecondToLastOrDefault() is IfInstruction ifInstruction) || !(block.Instructions.LastOrDefault() is Leave leave))
		{
			return null;
		}
		if (!ifInstruction.FalseInst.MatchNop())
		{
			return null;
		}
		ILInstruction iLInstruction = Block.Unwrap(ifInstruction.TrueInst);
		if (iLInstruction is Block block2 && block2.Instructions.Count == 2)
		{
			iLInstruction = CombineExits(block2);
		}
		if (!(iLInstruction is Leave leave2))
		{
			return null;
		}
		if (!leave2.IsLeavingFunction || !leave.IsLeavingFunction)
		{
			return null;
		}
		if (leave2.Value.MatchNop() || leave.Value.MatchNop())
		{
			return null;
		}
		IfInstruction ifInstruction2 = new IfInstruction(ifInstruction.Condition, leave2.Value, leave.Value);
		ifInstruction2.AddILRange(ifInstruction);
		Leave leave3 = new Leave(leave2.TargetContainer, ifInstruction2);
		leave3.AddILRange(leave);
		leave3.AddILRange(leave2);
		ifInstruction.ReplaceWith(leave3);
		block.Instructions.RemoveAt(checked(leave3.ChildIndex + 1));
		return leave3;
	}
}
