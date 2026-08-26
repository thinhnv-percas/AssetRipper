using System.Collections.Generic;
using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Text;

namespace ICSharpCode.Decompiler.ILAst;

public class ILWhileLoop : ILNode
{
	public ILExpression Condition;

	public ILBlock BodyBlock;

	internal override ILNode GetNext(ref int index)
	{
		if (index == 0)
		{
			index = 1;
			if (Condition != null)
			{
				return Condition;
			}
		}
		if (index == 1)
		{
			index = 2;
			if (BodyBlock != null)
			{
				return BodyBlock;
			}
		}
		return null;
	}

	public override void WriteTo(IDecompilerOutput output, MethodDebugInfoBuilder builder)
	{
		int nextPosition = output.NextPosition;
		output.Write("loop", BoxedTextColor.Keyword);
		output.Write(" ", BoxedTextColor.Text);
		int nextPosition2 = output.NextPosition;
		output.Write("(", BoxedTextColor.Punctuation);
		if (Condition != null)
		{
			Condition.WriteTo(output, null);
		}
		output.Write(")", BoxedTextColor.Punctuation);
		output.AddBracePair(new TextSpan(nextPosition2, 1), new TextSpan(output.Length - 1, 1), CodeBracesRangeFlags.BraceKind_Parentheses);
		List<ILSpan> list = new List<ILSpan>(ILSpans);
		if (Condition != null)
		{
			Condition.AddSelfAndChildrenRecursiveILSpans(list);
		}
		UpdateDebugInfo(builder, nextPosition, output.NextPosition, list);
		output.Write(" ", BoxedTextColor.Text);
		BodyBlock.WriteTo(output, builder);
	}
}
