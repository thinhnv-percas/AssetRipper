using dnSpy.Contracts.Decompiler;

namespace ICSharpCode.Decompiler.ILAst;

public class ILBasicBlock : ILBlockBase
{
	protected override CodeBracesRangeFlags CodeBracesRangeFlags => CodeBracesRangeFlags.OtherBlockBraces;
}
