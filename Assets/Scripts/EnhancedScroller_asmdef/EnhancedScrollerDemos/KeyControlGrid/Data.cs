using AssetRipperInjected;
using Cpp2ILInjected;

namespace EnhancedScrollerDemos.KeyControlGrid
{
	[Token(Token = "0x200002A")]
	public class Data
	{
		[Token(Token = "0x4000107")]
		[FieldOffset(Offset = "0x10")]
		public bool isSelected;

		[Token(Token = "0x4000108")]
		[FieldOffset(Offset = "0x18")]
		public string someText;

		[Token(Token = "0x6000118")]
		[Address(RVA = "0x4026474", Offset = "0x4026474", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public Data()
		{
		}
	}
}
