using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.RewardSystem;

namespace Systems.WinStreakBonusSystem.Data
{
	[Token(Token = "0x2000022")]
	public class WinStreakBonusShopItemData : ShopItemData
	{
		[Token(Token = "0x4000046")]
		[FieldOffset(Offset = "0x40")]
		public WinStreakBonusType BonusType;

		[Token(Token = "0x6000087")]
		[Address(RVA = "0x3C664F8", Offset = "0x3C664F8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.RewardSystem.ShopItemData::.ctor(this);\n\treturn;\n")]
		public WinStreakBonusShopItemData()
		{
		}
	}
}
