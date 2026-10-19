using AssetRipperInjected;
using Cpp2ILInjected;

namespace EnhancedScrollerDemos.NestedScrollers
{
	[Token(Token = "0x2000040")]
	public class DetailData
	{
		[Token(Token = "0x400013D")]
		[FieldOffset(Offset = "0x10")]
		public string someText;

		[Token(Token = "0x6000164")]
		[Address(RVA = "0x4028C34", Offset = "0x4028C34", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public DetailData()
		{
		}
	}
}
