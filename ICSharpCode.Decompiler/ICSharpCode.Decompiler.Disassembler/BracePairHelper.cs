using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Text;

namespace ICSharpCode.Decompiler.Disassembler;

internal struct BracePairHelper
{
	private readonly IDecompilerOutput output;

	private readonly CodeBracesRangeFlags flags;

	private int leftStart;

	private int leftEnd;

	private BracePairHelper(IDecompilerOutput output, int leftStart, int leftEnd, CodeBracesRangeFlags flags)
	{
		this.output = output;
		this.leftStart = leftStart;
		this.leftEnd = leftEnd;
		this.flags = flags;
	}

	public static BracePairHelper Create(IDecompilerOutput output, string s, CodeBracesRangeFlags flags)
	{
		int nextPosition = output.NextPosition;
		output.Write(s, BoxedTextColor.Punctuation);
		return new BracePairHelper(output, nextPosition, output.NextPosition, flags);
	}

	public void Write(string s)
	{
		int nextPosition = output.NextPosition;
		output.Write(s, BoxedTextColor.Punctuation);
		output.AddBracePair(new TextSpan(leftStart, leftEnd - leftStart), new TextSpan(nextPosition, output.NextPosition - nextPosition), flags);
	}
}
