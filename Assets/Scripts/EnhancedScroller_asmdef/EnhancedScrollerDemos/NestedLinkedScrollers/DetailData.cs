using AssetRipperInjected;
using Cpp2ILInjected;

namespace EnhancedScrollerDemos.NestedLinkedScrollers
{
	[Token(Token = "0x2000036")]
	public class DetailData
	{
		[Token(Token = "0x400012B")]
		[FieldOffset(Offset = "0x10")]
		public string someText;

		[Token(Token = "0x6000144")]
		[Address(RVA = "0x4027874", Offset = "0x4027874", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public DetailData()
		{
		}
	}
}
