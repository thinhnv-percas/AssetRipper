using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Systems.WinStreakBonusSystem.Data
{
	[Token(Token = "0x2000021")]
	public class WinStreakBonusDatabase : ScriptableObject
	{
		[Token(Token = "0x6000085")]
		[Address(RVA = "0x3C66398", Offset = "0x3C66398", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tv40 = new Systems.WinStreakBonusSystem.Data.WinStreakBonusUIConfig();\n\tSystem.Object::.ctor(v40);\n\treturn v40;\n")]
		public WinStreakBonusUIConfig GetUIConfig(WinStreakBonusType bonusType)
		{
			return new WinStreakBonusUIConfig();
		}

		[Token(Token = "0x6000086")]
		[Address(RVA = "0x3C664F0", Offset = "0x3C664F0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n")]
		public WinStreakBonusDatabase()
		{
		}
	}
}
