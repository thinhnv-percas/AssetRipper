using AssetRipperInjected;
using Cpp2ILInjected;

namespace EnhancedScrollerDemos.RefreshDemo
{
	[Token(Token = "0x200005F")]
	public class Data
	{
		[Token(Token = "0x4000183")]
		[FieldOffset(Offset = "0x10")]
		public string someText;

		[Token(Token = "0x60001DD")]
		[Address(RVA = "0x402D3C8", Offset = "0x402D3C8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public Data()
		{
		}
	}
}
