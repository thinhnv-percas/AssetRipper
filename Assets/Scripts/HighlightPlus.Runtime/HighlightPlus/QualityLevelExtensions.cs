using AssetRipperInjected;
using Cpp2ILInjected;

namespace HighlightPlus
{
	[Token(Token = "0x2000020")]
	public static class QualityLevelExtensions
	{
		[Token(Token = "0x600001B")]
		[Address(RVA = "0x772577C", Offset = "0x772577C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = qualityLevel & -3;\n\tv4 = v0 - 1;\n\tv6 = v4 == 0;\n\treturn v6;\n")]
		public static bool UsesMultipleOffsets(this QualityLevel qualityLevel)
		{
			int num = (int)(qualityLevel & (QualityLevel)(-3));
			int num2 = num - 1;
			return num2 == 0;
		}
	}
}
