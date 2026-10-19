using AssetRipperInjected;
using Cpp2ILInjected;

namespace EnhancedScrollerDemos.PullDownRefresh
{
	[Token(Token = "0x200004A")]
	public class Data
	{
		[Token(Token = "0x4000152")]
		[FieldOffset(Offset = "0x10")]
		public string someText;

		[Token(Token = "0x6000186")]
		[Address(RVA = "0x4029B88", Offset = "0x4029B88", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public Data()
		{
		}
	}
}
