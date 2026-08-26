using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Text;

namespace ICSharpCode.Decompiler.ILAst;

public class ILLabel : ILNode
{
	public string Name;

	public uint Offset = uint.MaxValue;

	private object o;

	public object Reference => o ?? (o = new object());

	public override bool SafeToAddToEndILSpans => true;

	public override void WriteTo(IDecompilerOutput output, MethodDebugInfoBuilder builder)
	{
		int nextPosition = output.NextPosition;
		output.Write(Name, Reference, DecompilerReferenceFlags.Definition | DecompilerReferenceFlags.Local, BoxedTextColor.Label);
		output.Write(":", BoxedTextColor.Punctuation);
		UpdateDebugInfo(builder, nextPosition, output.NextPosition, ILSpans);
	}
}
