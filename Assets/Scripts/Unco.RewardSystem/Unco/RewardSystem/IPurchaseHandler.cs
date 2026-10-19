using Cpp2ILInjected;

namespace Unco.RewardSystem
{
	[Token(Token = "0x200000A")]
	public interface IPurchaseHandler
	{
		[Token(Token = "0x600001A")]
		void Handle(ShopItemData item);
	}
}
