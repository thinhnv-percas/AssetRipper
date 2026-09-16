using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[Token(Token = "0x200007B")]
	public class UpdateHelper
	{
		[Token(Token = "0x40002CB")]
		private static bool editorPrefLoaded;

		[Token(Token = "0x6000366")]
		[Address(RVA = "0x98CF40", Offset = "0x98CF40", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void SetDirty(Fsm fsm)
		{
		}

		[Token(Token = "0x6000367")]
		[Address(RVA = "0x98CF44", Offset = "0x98CF44", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public UpdateHelper()
		{
		}
	}
}
