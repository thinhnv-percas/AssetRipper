using System.Collections.Generic;
using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Text;

namespace ICSharpCode.Decompiler.ILAst;

public class ILSwitch : ILNode
{
	public class CaseBlock : ILBlock
	{
		public List<int> Values;

		protected override CodeBracesRangeFlags CodeBracesRangeFlags => CodeBracesRangeFlags.CaseBraces;

		public override void WriteTo(IDecompilerOutput output, MethodDebugInfoBuilder builder)
		{
			if (Values != null)
			{
				foreach (int value in Values)
				{
					output.Write("case", BoxedTextColor.Keyword);
					output.Write(" ", BoxedTextColor.Text);
					output.Write($"{value}", BoxedTextColor.Number);
					output.WriteLine(":", BoxedTextColor.Punctuation);
				}
			}
			else
			{
				output.Write("default", BoxedTextColor.Keyword);
				output.WriteLine(":", BoxedTextColor.Punctuation);
			}
			output.IncreaseIndent();
			base.WriteTo(output, builder);
			output.DecreaseIndent();
		}
	}

	public ILExpression Condition;

	public List<CaseBlock> CaseBlocks = new List<CaseBlock>();

	public List<ILSpan> endILSpans = new List<ILSpan>(1);

	public override List<ILSpan> EndILSpans => endILSpans;

	public override bool SafeToAddToEndILSpans => true;

	public override ILSpan GetAllILSpans(ref long index, ref bool done)
	{
		if (index < ILSpans.Count)
		{
			return ILSpans[(int)index++];
		}
		int num = (int)index - ILSpans.Count;
		if (num < endILSpans.Count)
		{
			index++;
			return endILSpans[num];
		}
		done = true;
		return default(ILSpan);
	}

	internal override ILNode GetNext(ref int index)
	{
		if (index == 0)
		{
			index = 1;
			return Condition;
		}
		if (index <= CaseBlocks.Count)
		{
			return CaseBlocks[index++ - 1];
		}
		return null;
	}

	public override void WriteTo(IDecompilerOutput output, MethodDebugInfoBuilder builder)
	{
		int nextPosition = output.NextPosition;
		output.Write("switch", BoxedTextColor.Keyword);
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
		BraceInfo info = WriteHiddenStart(output, builder);
		foreach (CaseBlock caseBlock in CaseBlocks)
		{
			caseBlock.WriteTo(output, builder);
		}
		WriteHiddenEnd(output, builder, info, CodeBracesRangeFlags.SwitchBraces);
	}
}
