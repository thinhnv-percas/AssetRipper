using Cpp2ILInjected;
using Unco.RewardSystem;

namespace _game.Systems.ShopSystem.Scripts.Core
{
	[Token(Token = "0x2000725")]
	public class ShopResourceItemData : ResourceItemData
	{
		[Token(Token = "0x40017F3")]
		[FieldOffset(Offset = "0x48")]
		public string VisualKey;

		[Token(Token = "0x6001E24")]
		[Address(RVA = "0x3D823BC", Offset = "0x3D823BC", Length = "0xAC")]
		public override ShopItemData Copy()
		{
			ShopResourceItemData shopResourceItemData = (ShopResourceItemData)new ResourceItemData();
			shopResourceItemData.ResourceType = ResourceType;
			shopResourceItemData.sourceType = sourceType;
			shopResourceItemData.Amount = Amount;
			shopResourceItemData.customTransactionData = customTransactionData;
			shopResourceItemData.VisualKey = VisualKey;
			return shopResourceItemData;
		}

		[Token(Token = "0x6001E25")]
		[Address(RVA = "0x3D82468", Offset = "0x3D82468", Length = "0x8")]
		public ShopResourceItemData()
		{
		}
	}
}
