using System.Collections.Generic;
using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Text;

namespace ICSharpCode.Decompiler.ILAst;

public class ILFixedStatement : ILNode
{
	public List<ILExpression> Initializers = new List<ILExpression>();

	public ILBlock BodyBlock;

	internal override ILNode GetNext(ref int index)
	{
		if (index < Initializers.Count)
		{
			return Initializers[index++];
		}
		if (index == Initializers.Count)
		{
			index++;
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
		output.Write("fixed", BoxedTextColor.Keyword);
		output.Write(" ", BoxedTextColor.Text);
		int nextPosition2 = output.NextPosition;
		output.Write("(", BoxedTextColor.Punctuation);
		for (int i = 0; i < Initializers.Count; i++)
		{
			if (i > 0)
			{
				output.Write(",", BoxedTextColor.Punctuation);
				output.Write(" ", BoxedTextColor.Text);
			}
			Initializers[i].WriteTo(output, null);
		}
		output.Write(")", BoxedTextColor.Punctuation);
		output.AddBracePair(new TextSpan(nextPosition2, 1), new TextSpan(output.Length - 1, 1), CodeBracesRangeFlags.BraceKind_Parentheses);
		List<ILSpan> list = new List<ILSpan>(ILSpans);
		foreach (ILExpression initializer in Initializers)
		{
			initializer.AddSelfAndChildrenRecursiveILSpans(list);
		}
		UpdateDebugInfo(builder, nextPosition, output.NextPosition, list);
		output.Write(" ", BoxedTextColor.Text);
		BodyBlock.WriteTo(output, builder);
	}
}
