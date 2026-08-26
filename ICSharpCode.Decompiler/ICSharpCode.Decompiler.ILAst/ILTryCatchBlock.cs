using System.Collections.Generic;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Text;
using ICSharpCode.Decompiler.Disassembler;

namespace ICSharpCode.Decompiler.ILAst;

public class ILTryCatchBlock : ILNode
{
	public abstract class CatchBlockBase : ILBlock
	{
		public TypeSig ExceptionType;

		public ILVariable ExceptionVariable;

		public List<ILSpan> StlocILSpans = new List<ILSpan>(1);

		protected CatchBlockBase(bool calculateILSpans, List<ILNode> body)
		{
			Body = body;
			if (calculateILSpans && body.Count > 0 && body[0].Match(ILCode.Pop))
			{
				body[0].AddSelfAndChildrenRecursiveILSpans(StlocILSpans);
			}
		}

		public override ILSpan GetAllILSpans(ref long index, ref bool done)
		{
			if (index < ILSpans.Count)
			{
				return ILSpans[(int)index++];
			}
			int num = (int)index - ILSpans.Count;
			if (num < StlocILSpans.Count)
			{
				index++;
				return StlocILSpans[num];
			}
			done = true;
			return default(ILSpan);
		}
	}

	public class CatchBlock : CatchBlockBase
	{
		public FilterILBlock FilterBlock;

		protected override CodeBracesRangeFlags CodeBracesRangeFlags => CodeBracesRangeFlags.CatchBraces;

		public CatchBlock(bool calculateILSpans, List<ILNode> body)
			: base(calculateILSpans, body)
		{
		}

		public override void WriteTo(IDecompilerOutput output, MethodDebugInfoBuilder builder)
		{
			FilterBlock?.WriteTo(output, builder);
			int nextPosition = output.NextPosition;
			if (ExceptionType != null)
			{
				output.Write("catch", BoxedTextColor.Keyword);
				output.Write(" ", BoxedTextColor.Text);
				ExceptionType.WriteTo(output, ILNameSyntax.TypeName);
				if (ExceptionVariable != null)
				{
					output.Write(" ", BoxedTextColor.Text);
					output.Write(ExceptionVariable.Name, ExceptionVariable.GetTextReferenceObject(), DecompilerReferenceFlags.Definition | DecompilerReferenceFlags.Local, BoxedTextColor.Local);
				}
			}
			else
			{
				output.Write("handler", BoxedTextColor.Keyword);
				if (ExceptionVariable != null)
				{
					output.Write(" ", BoxedTextColor.Text);
					output.Write(ExceptionVariable.Name, ExceptionVariable.GetTextReferenceObject(), DecompilerReferenceFlags.Definition | DecompilerReferenceFlags.Local, BoxedTextColor.Local);
				}
			}
			UpdateDebugInfo(builder, nextPosition, output.NextPosition, StlocILSpans);
			output.Write(" ", BoxedTextColor.Text);
			base.WriteTo(output, builder);
		}
	}

	public class FilterILBlock : CatchBlockBase
	{
		protected override CodeBracesRangeFlags CodeBracesRangeFlags => CodeBracesRangeFlags.FilterBraces;

		public FilterILBlock(bool calculateILSpans, List<ILNode> body)
			: base(calculateILSpans, body)
		{
		}

		public override void WriteTo(IDecompilerOutput output, MethodDebugInfoBuilder builder)
		{
			output.Write("filter", BoxedTextColor.Keyword);
			if (ExceptionVariable != null)
			{
				output.Write(" ", BoxedTextColor.Text);
				output.Write(ExceptionVariable.Name, ExceptionVariable.GetTextReferenceObject(), DecompilerReferenceFlags.Definition | DecompilerReferenceFlags.Local, BoxedTextColor.Local);
				output.Write(" ", BoxedTextColor.Text);
			}
			base.WriteTo(output, builder);
		}
	}

	public ILBlock TryBlock;

	public List<CatchBlock> CatchBlocks;

	public ILBlock FinallyBlock;

	public ILBlock FaultBlock;

	internal override ILNode GetNext(ref int index)
	{
		if (index == 0)
		{
			index = 1;
			if (TryBlock != null)
			{
				return TryBlock;
			}
		}
		int num = 1 + CatchBlocks.Count * 2;
		if (index < num)
		{
			CatchBlock catchBlock = CatchBlocks[(index - 1) / 2];
			index++;
			if ((index & 1) == 0)
			{
				if (catchBlock.FilterBlock != null)
				{
					return catchBlock.FilterBlock;
				}
				index++;
			}
			return catchBlock;
		}
		if (index == num)
		{
			index++;
			if (FaultBlock != null)
			{
				return FaultBlock;
			}
		}
		if (index == num + 1)
		{
			index++;
			if (FinallyBlock != null)
			{
				return FinallyBlock;
			}
		}
		return null;
	}

	public override void WriteTo(IDecompilerOutput output, MethodDebugInfoBuilder builder)
	{
		output.Write(".try", BoxedTextColor.Keyword);
		output.Write(" ", BoxedTextColor.Text);
		TryBlock.WriteTo(output, builder, ILSpans);
		foreach (CatchBlock catchBlock in CatchBlocks)
		{
			catchBlock.WriteTo(output, builder);
		}
		if (FaultBlock != null)
		{
			output.Write("fault", BoxedTextColor.Keyword);
			output.Write(" ", BoxedTextColor.Text);
			FaultBlock.WriteTo(output, builder);
		}
		if (FinallyBlock != null)
		{
			output.Write("finally", BoxedTextColor.Keyword);
			output.Write(" ", BoxedTextColor.Text);
			FinallyBlock.WriteTo(output, builder);
		}
	}
}
