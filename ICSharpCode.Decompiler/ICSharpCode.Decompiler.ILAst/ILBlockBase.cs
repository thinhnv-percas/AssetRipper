using System.Collections.Generic;
using dnSpy.Contracts.Decompiler;

namespace ICSharpCode.Decompiler.ILAst;

public abstract class ILBlockBase : ILNode
{
	public List<ILNode> Body;

	public List<ILSpan> endILSpans = new List<ILSpan>(1);

	protected abstract CodeBracesRangeFlags CodeBracesRangeFlags { get; }

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

	public ILBlockBase()
	{
		Body = new List<ILNode>();
	}

	public ILBlockBase(params ILNode[] body)
	{
		Body = new List<ILNode>(body);
	}

	public ILBlockBase(List<ILNode> body)
	{
		Body = body;
	}

	internal override ILNode GetNext(ref int index)
	{
		if (index < Body.Count)
		{
			return Body[index++];
		}
		return null;
	}

	public override void WriteTo(IDecompilerOutput output, MethodDebugInfoBuilder builder)
	{
		WriteTo(output, builder, null);
	}

	internal void WriteTo(IDecompilerOutput output, MethodDebugInfoBuilder builder, IEnumerable<ILSpan> ilSpans)
	{
		BraceInfo info = WriteHiddenStart(output, builder, ilSpans);
		foreach (ILNode child in GetChildren())
		{
			child.WriteTo(output, builder);
			if (!child.WritesNewLine)
			{
				output.WriteLine();
			}
		}
		WriteHiddenEnd(output, builder, info, CodeBracesRangeFlags);
	}
}
