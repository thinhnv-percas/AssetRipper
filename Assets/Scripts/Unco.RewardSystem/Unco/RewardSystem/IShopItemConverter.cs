using Cpp2ILInjected;

namespace Unco.RewardSystem
{
	[Token(Token = "0x200000B")]
	public interface IShopItemConverter
	{
		[Token(Token = "0x17000005")]
		string ConvertTargetLootType
		{
			[Token(Token = "0x600001B")]
			get;
		}

		[Token(Token = "0x600001C")]
		bool ConvertShopItemData<T>(LootDrop lootDrop, string sourceType, out T drop, string customTransactionData = "") where T : ShopItemData;
	}
}
