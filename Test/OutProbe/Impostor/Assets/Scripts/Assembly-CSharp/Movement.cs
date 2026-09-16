using AssetRipperInjected;
using Cpp2ILInjected;

[Token(Token = "0x2000025")]
public class Movement
{
	[Token(Token = "0x4000080")]
	[FieldOffset(Offset = "0x10")]
	public Box currentBox;

	[Token(Token = "0x4000081")]
	[FieldOffset(Offset = "0x18")]
	public Box targetBox;

	[Token(Token = "0x4000082")]
	[FieldOffset(Offset = "0x20")]
	public Imposter imposter;

	[Token(Token = "0x60000E8")]
	[Address(RVA = "0xBFFDEC", Offset = "0xBFFDEC", Length = "0x3C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.currentBox = currentBox;\n\tthis.targetBox = targetBox;\n\tthis.imposter = imposter;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public Movement(Box currentBox, Box targetBox, Imposter imposter)
	{
		this.currentBox = currentBox;
		this.targetBox = targetBox;
		this.imposter = imposter;
	}
}
