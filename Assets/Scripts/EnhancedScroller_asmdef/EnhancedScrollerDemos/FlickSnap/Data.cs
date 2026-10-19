using AssetRipperInjected;
using Cpp2ILInjected;

namespace EnhancedScrollerDemos.FlickSnap
{
	[Token(Token = "0x200001E")]
	public class Data
	{
		[Token(Token = "0x40000C8")]
		[FieldOffset(Offset = "0x10")]
		public string someText;

		[Token(Token = "0x60000E1")]
		[Address(RVA = "0x4023A5C", Offset = "0x4023A5C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public Data()
		{
		}
	}
}
