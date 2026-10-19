using AssetRipperInjected;
using Cpp2ILInjected;

namespace EnhancedScrollerDemos.Pagination
{
	[Token(Token = "0x2000032")]
	public class Data
	{
		[Token(Token = "0x4000125")]
		[FieldOffset(Offset = "0x10")]
		public string someText;

		[Token(Token = "0x6000137")]
		[Address(RVA = "0x4026FEC", Offset = "0x4026FEC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public Data()
		{
		}
	}
}
