using System;
using Cpp2ILInjected;
using Unco.RewardSystem;

namespace _game.Systems.PaymentSystem.PurchaseHandlers
{
	[Token(Token = "0x2000742")]
	public class IAPPurchaseHandler : IPurchaseHandler
	{
		[Token(Token = "0x6001E95")]
		[Address(RVA = "0x3D86FE8", Offset = "0x3D86FE8", Length = "0xB4")]
		public void Handle(ShopItemData item)
		{
			if (item != null)
			{
				IAPShopItemData iAPShopItemData = item as IAPShopItemData;
				if (iAPShopItemData == null)
				{
					throw new InvalidCastException();
				}
			}
			IAPShopItemData.InvokeHandler((IAPShopItemData)item);
		}

		[Token(Token = "0x6001E96")]
		[Address(RVA = "0x3D86C24", Offset = "0x3D86C24", Length = "0x8")]
		public IAPPurchaseHandler()
		{
		}
	}
}
