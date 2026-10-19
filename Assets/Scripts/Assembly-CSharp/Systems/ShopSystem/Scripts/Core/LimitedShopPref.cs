using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Systems.ShopSystem.Scripts.Core
{
	[Token(Token = "0x200003F")]
	public class LimitedShopPref
	{
		[Token(Token = "0x400008F")]
		[FieldOffset(Offset = "0x10")]
		public List<LimitedShopItemPref> dailyShopItems;

		[Token(Token = "0x60000D5")]
		[Address(RVA = "0x3C67C6C", Offset = "0x3C67C6C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.List`1<Systems.ShopSystem.Scripts.Core.LimitedShopItemPref>();\n\tSystem.Collections.Generic.List`1<Systems.ShopSystem.Scripts.Core.LimitedShopItemPref>::.ctor(v48);\n\tthis.dailyShopItems = v48;\n")]
		public LimitedShopPref()
		{
			List<LimitedShopItemPref> list = new List<LimitedShopItemPref>();
			dailyShopItems = list;
		}
	}
}
