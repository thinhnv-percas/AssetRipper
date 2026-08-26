using System.Collections.Generic;
using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Text;

namespace ICSharpCode.Decompiler.ILAst;

public class ILCondition : ILNode
{
	public ILExpression Condition;

	public ILBlock TrueBlock;

	public ILBlock FalseBlock;

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
			if (TrueBlock != null)
			{
				return TrueBlock;
			}
		}
		if (index == 2)
		{
			index = 3;
			if (FalseBlock != null)
			{
				return FalseBlock;
			}
		}
		return null;
	}

	public override void WriteTo(IDecompilerOutput output, MethodDebugInfoBuilder builder)
	{
		int nextPosition = output.NextPosition;
		output.Write("if", BoxedTextColor.Keyword);
		output.Write(" ", BoxedTextColor.Text);
		int nextPosition2 = output.NextPosition;
		output.Write("(", BoxedTextColor.Punctuation);
		Condition.WriteTo(output, null);
		output.Write(")", BoxedTextColor.Punctuation);
		output.AddBracePair(new TextSpan(nextPosition2, 1), new TextSpan(output.Length - 1, 1), CodeBracesRangeFlags.BraceKind_Parentheses);
		List<ILSpan> list = new List<ILSpan>(ILSpans);
		Condition.AddSelfAndChildrenRecursiveILSpans(list);
		UpdateDebugInfo(builder, nextPosition, output.NextPosition, list);
		output.Write(" ", BoxedTextColor.Text);
		TrueBlock.WriteTo(output, builder);
		if (FalseBlock != null)
		{
			output.Write("else", BoxedTextColor.Keyword);
			output.Write(" ", BoxedTextColor.Text);
			FalseBlock.WriteTo(output, builder);
		}
	}
}
