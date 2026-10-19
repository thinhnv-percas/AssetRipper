using AssetRipperInjected;
using Cpp2ILInjected;

namespace EnhancedScrollerDemos.MultipleCellTypesDemo
{
	[Token(Token = "0x200007D")]
	public class HeaderData : Data
	{
		[Token(Token = "0x40001F8")]
		[FieldOffset(Offset = "0x10")]
		public string category;

		[Token(Token = "0x6000251")]
		[Address(RVA = "0x4031AAC", Offset = "0x4031AAC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public HeaderData()
		{
		}
	}
}
