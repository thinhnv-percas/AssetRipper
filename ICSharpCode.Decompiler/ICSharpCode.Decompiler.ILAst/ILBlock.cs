using System.Collections.Generic;
using dnSpy.Contracts.Decompiler;

namespace ICSharpCode.Decompiler.ILAst;

public class ILBlock : ILBlockBase
{
	private readonly CodeBracesRangeFlags codeBracesRangeFlags;

	public ILExpression EntryGoto;

	protected override CodeBracesRangeFlags CodeBracesRangeFlags => codeBracesRangeFlags;

	public ILBlock()
		: this(CodeBracesRangeFlags.OtherBlockBraces)
	{
	}

	public ILBlock(CodeBracesRangeFlags codeBracesRangeFlags)
	{
		this.codeBracesRangeFlags = codeBracesRangeFlags;
	}

	public ILBlock(List<ILNode> body)
		: this(body, CodeBracesRangeFlags.OtherBlockBraces)
	{
	}

	public ILBlock(List<ILNode> body, CodeBracesRangeFlags codeBracesRangeFlags)
		: base(body)
	{
		this.codeBracesRangeFlags = codeBracesRangeFlags;
	}

	internal override ILNode GetNext(ref int index)
	{
		if (index == 0)
		{
			index = 1;
			if (EntryGoto != null)
			{
				return EntryGoto;
			}
		}
		if (index <= Body.Count)
		{
			return Body[index++ - 1];
		}
		return null;
	}
}
