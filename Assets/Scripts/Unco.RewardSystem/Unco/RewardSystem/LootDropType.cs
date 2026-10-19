using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.RewardSystem
{
	[Token(Token = "0x2000010")]
	public static class LootDropType
	{
		[Token(Token = "0x4000017")]
		public const string Resource = "resource";

		[Token(Token = "0x4000018")]
		public const string MultiPack = "multi_pack";

		[Token(Token = "0x4000019")]
		public const string Booster = "booster";

		[Token(Token = "0x400001A")]
		public const string Custom = "custom";

		[Token(Token = "0x400001B")]
		public const string Health = "health";

		[Token(Token = "0x400001C")]
		public const string IAP = "iap";

		[Token(Token = "0x6000034")]
		[Address(RVA = "0x81D5560", Offset = "0x81D5560", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\nL_0027:\n\t// 39 NewArr v42 @ X0_v3 (System.String[]), typeof(System.String[]), 6\n\tv42[0] = \"resource\";\n\tv42[1] = \"booster\";\n\tv42[2] = \"multi_pack\";\n\tv42[3] = \"custom\";\n\tv42[4] = \"health\";\n\tv42[5] = \"iap\";\n\treturn v42;\n")]
		public static string[] GetAllTypes()
		{
			return new string[6] { "resource", "booster", "multi_pack", "custom", "health", "iap" };
		}
	}
}
