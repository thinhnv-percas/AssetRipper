using AssetRipperInjected;
using Cpp2ILInjected;

namespace EnhancedScrollerDemos.JumpToDemo
{
	[Token(Token = "0x2000072")]
	public class Data
	{
		[Token(Token = "0x40001D2")]
		[FieldOffset(Offset = "0x10")]
		public string cellText;

		[Token(Token = "0x600022C")]
		[Address(RVA = "0x402F7F8", Offset = "0x402F7F8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public Data()
		{
		}
	}
}
