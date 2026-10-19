using Systems.WinStreakBonusSystem.Data;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Systems.WinStreakBonusSystem.Core
{
	[Token(Token = "0x2000025")]
	public class WinStreakBonusService
	{
		[Token(Token = "0x6000089")]
		[Address(RVA = "0x3C664AC", Offset = "0x3C664AC", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = 0xB7D5000 + 0x538;\n\tv10 = *([v9 @ X8_v2 (System.Int32)+90]);\n\tv11 = *([v10 @ X8_v3+B8]);\n\t*([reason @ X2 (System.String&)]) = *([v11 @ X8_v4]);\n\treturn 1;\n")]
		public bool IsBonusEnabled(WinStreakBonusType bonusType, out string reason)
		{
			//IL_0029: Expected O, but got I
			//IL_0039: Expected O, but got I
			reason = null;
			int num = 192761856 + 1336;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ X8_v2 (System.Int32)+90]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X8_v3+B8]");
			object obj2 = 0;
			reason = (string)obj2;
			return true;
		}

		[Token(Token = "0x600008A")]
		[Address(RVA = "0x3C66194", Offset = "0x3C66194", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public WinStreakBonusService()
		{
		}
	}
}
