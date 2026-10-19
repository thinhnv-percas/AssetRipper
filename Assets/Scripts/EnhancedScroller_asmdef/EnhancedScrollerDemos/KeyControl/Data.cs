using AssetRipperInjected;
using Cpp2ILInjected;

namespace EnhancedScrollerDemos.KeyControl
{
	[Token(Token = "0x200002E")]
	public class Data
	{
		[Token(Token = "0x4000118")]
		[FieldOffset(Offset = "0x10")]
		public bool isSelected;

		[Token(Token = "0x4000119")]
		[FieldOffset(Offset = "0x18")]
		public string someText;

		[Token(Token = "0x6000126")]
		[Address(RVA = "0x4026B58", Offset = "0x4026B58", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public Data()
		{
		}
	}
}
