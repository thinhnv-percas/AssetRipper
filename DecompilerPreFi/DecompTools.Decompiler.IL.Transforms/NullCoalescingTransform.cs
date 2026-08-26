#define STEP
namespace DecompTools.Decompiler.IL.Transforms;

internal class NullCoalescingTransform : IStatementTransform
{
	public void Run(Block block, int pos, StatementTransformContext context)
	{
		TransformRefTypes(block, pos, context);
	}

	private bool TransformRefTypes(Block block, int pos, StatementTransformContext context)
	{
		if (!(block.Instructions[pos] is StLoc stLoc))
		{
			return false;
		}
		if (stLoc.Variable.Kind != VariableKind.StackSlot)
		{
			return false;
		}
		checked
		{
			if (!block.Instructions[pos + 1].MatchIfInstruction(out var condition, out var trueInst))
			{
				return false;
			}
			if (!condition.MatchCompEquals(out var left, out var right) || !left.MatchLdLoc(stLoc.Variable) || !right.MatchLdNull())
			{
				return false;
			}
			trueInst = Block.Unwrap(trueInst);
			if (trueInst.MatchStLoc(stLoc.Variable, out var value))
			{
				context.Step("NullCoalescingTransform: simple (reference types)", stLoc);
				stLoc.Value = new NullCoalescingInstruction(NullCoalescingKind.Ref, stLoc.Value, value);
				block.Instructions.RemoveAt(pos + 1);
				ILInlining.InlineOneIfPossible(block, pos, InliningOptions.None, context);
				return true;
			}
			if (trueInst is Block block2 && block2.Instructions.Count == 2 && block2.Instructions[0].MatchStLoc(out var variable, out value) && variable.IsSingleDefinition && variable.LoadCount == 1 && block2.Instructions[1].MatchStLoc(stLoc.Variable, out var value2) && value2.MatchLdLoc(variable))
			{
				context.Step("NullCoalescingTransform: with temporary variable (reference types)", stLoc);
				stLoc.Value = new NullCoalescingInstruction(NullCoalescingKind.Ref, stLoc.Value, value);
				block.Instructions.RemoveAt(pos + 1);
				ILInlining.InlineOneIfPossible(block, pos, InliningOptions.None, context);
				return true;
			}
			return false;
		}
	}
}
