using AssetRipperInjected;
using Cpp2ILInjected;

namespace AlmostEngine
{
	[Token(Token = "0x200000D")]
	public class UnityVersion
	{
		[Token(Token = "0x6000029")]
		[Address(RVA = "0x3C45FAC", Offset = "0x3C45FAC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n")]
		public static bool HasPro()
		{
			return true;
		}

		[Token(Token = "0x600002A")]
		[Address(RVA = "0x3C45FB4", Offset = "0x3C45FB4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public UnityVersion()
		{
		}
	}
}
