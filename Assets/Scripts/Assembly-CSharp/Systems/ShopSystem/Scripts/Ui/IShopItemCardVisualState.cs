using Systems.ShopSystem.Scripts.Core;
using Cpp2ILInjected;

namespace Systems.ShopSystem.Scripts.Ui
{
	[Token(Token = "0x200004C")]
	public interface IShopItemCardVisualState
	{
		[Token(Token = "0x60000E8")]
		void Init(ShopItemVisualData visualData);
	}
}
