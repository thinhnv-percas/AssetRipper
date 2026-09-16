using System.Collections;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Obi
{
	[Token(Token = "0x2000051")]
	public class EditorCoroutine
	{
		[Token(Token = "0x6000380")]
		[Address(RVA = "0xE2EE60", Offset = "0xE2EE60", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void ShowCoroutineProgressBar(string title, ref IEnumerator coroutine)
		{
		}

		[Token(Token = "0x6000381")]
		[Address(RVA = "0xE2EE64", Offset = "0xE2EE64", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EditorCoroutine()
		{
		}
	}
}
