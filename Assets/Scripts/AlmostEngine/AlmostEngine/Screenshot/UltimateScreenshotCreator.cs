using AssetRipperInjected;
using Cpp2ILInjected;

namespace AlmostEngine.Screenshot
{
	[Token(Token = "0x2000047")]
	public class UltimateScreenshotCreator
	{
		[Token(Token = "0x40001D5")]
		public static string VERSION = "Ultimate Screenshot Creator v1.11.4";

		[Token(Token = "0x40001D6")]
		public static string AUTHOR = "(c)Arnaud Emilien - support@wildmagegames.com";

		[Token(Token = "0x6000161")]
		[Address(RVA = "0x3C420E0", Offset = "0x3C420E0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public UltimateScreenshotCreator()
		{
		}
	}
}
