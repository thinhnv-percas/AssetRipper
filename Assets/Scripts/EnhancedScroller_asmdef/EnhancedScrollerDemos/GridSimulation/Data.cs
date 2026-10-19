using AssetRipperInjected;
using Cpp2ILInjected;

namespace EnhancedScrollerDemos.GridSimulation
{
	[Token(Token = "0x2000053")]
	public class Data
	{
		[Token(Token = "0x4000168")]
		[FieldOffset(Offset = "0x10")]
		public string someText;

		[Token(Token = "0x60001AA")]
		[Address(RVA = "0x402B228", Offset = "0x402B228", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public Data()
		{
		}
	}
}
