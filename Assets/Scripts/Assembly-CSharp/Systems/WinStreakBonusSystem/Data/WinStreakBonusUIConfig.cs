using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Systems.WinStreakBonusSystem.Data
{
	[Token(Token = "0x2000024")]
	public class WinStreakBonusUIConfig
	{
		[Token(Token = "0x4000049")]
		[FieldOffset(Offset = "0x10")]
		public Sprite icon;

		[Token(Token = "0x6000088")]
		[Address(RVA = "0x3C664E8", Offset = "0x3C664E8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public WinStreakBonusUIConfig()
		{
		}
	}
}
