using AssetRipperInjected;
using Cpp2ILInjected;

namespace Systems.ShopSystem.Scripts.Core
{
	[Token(Token = "0x2000040")]
	public static class LimitedShopItemPrefExtensions
	{
		[Token(Token = "0x60000D6")]
		[Address(RVA = "0x3C67CF8", Offset = "0x3C67CF8", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv45.isEnabled = 1;\n\tv45.leftAmount = 0x7FFFFFFF;\n\tv45.lootDataId = lootDataId;\n\treturn v45;\nL_0017:\n\tv45 = new Systems.ShopSystem.Scripts.Core.LimitedShopItemPref();\n\tSystem.Object::.ctor(v45);\n")]
		public static LimitedShopItemPref Limitless(string lootDataId)
		{
			LimitedShopItemPref limitedShopItemPref = new LimitedShopItemPref();
			limitedShopItemPref.isEnabled = true;
			limitedShopItemPref.leftAmount = 2147483647;
			limitedShopItemPref.lootDataId = lootDataId;
			return limitedShopItemPref;
		}
	}
}
