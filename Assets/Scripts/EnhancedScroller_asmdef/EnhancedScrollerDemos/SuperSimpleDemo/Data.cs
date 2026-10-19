using AssetRipperInjected;
using Cpp2ILInjected;

namespace EnhancedScrollerDemos.SuperSimpleDemo
{
	[Token(Token = "0x2000082")]
	public class Data
	{
		[Token(Token = "0x4000203")]
		[FieldOffset(Offset = "0x10")]
		public string someText;

		[Token(Token = "0x600025C")]
		[Address(RVA = "0x4032A64", Offset = "0x4032A64", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public Data()
		{
		}
	}
}
