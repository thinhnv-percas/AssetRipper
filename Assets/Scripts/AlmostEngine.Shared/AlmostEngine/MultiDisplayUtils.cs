using AssetRipperInjected;
using Cpp2ILInjected;

namespace AlmostEngine
{
	[Token(Token = "0x2000008")]
	public static class MultiDisplayUtils
	{
		[Token(Token = "0x6000015")]
		[Address(RVA = "0x3C4574C", Offset = "0x3C4574C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n")]
		public static bool IsMultiDisplay()
		{
			return false;
		}
	}
}
