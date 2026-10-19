using AssetRipperInjected;
using Cpp2ILInjected;

namespace EnhancedScrollerDemos.ViewDrivenCellSizes
{
	[Token(Token = "0x200005C")]
	public class Data
	{
		[Token(Token = "0x400017C")]
		[FieldOffset(Offset = "0x10")]
		public string someText;

		[Token(Token = "0x400017D")]
		[FieldOffset(Offset = "0x18")]
		public float cellSize;

		[Token(Token = "0x60001CE")]
		[Address(RVA = "0x402CF58", Offset = "0x402CF58", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public Data()
		{
		}
	}
}
