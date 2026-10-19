using AssetRipperInjected;
using Cpp2ILInjected;

namespace EnhancedScrollerDemos.CellEvents
{
	[Token(Token = "0x2000059")]
	public class Data
	{
		[Token(Token = "0x4000174")]
		[FieldOffset(Offset = "0x10")]
		public int hour;

		[Token(Token = "0x60001C3")]
		[Address(RVA = "0x402B9F4", Offset = "0x402B9F4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public Data()
		{
		}
	}
}
