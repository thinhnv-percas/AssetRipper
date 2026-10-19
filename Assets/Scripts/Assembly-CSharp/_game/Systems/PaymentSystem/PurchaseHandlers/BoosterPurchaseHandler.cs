using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.RewardSystem;
using _game.CoreGameKit.CoreSerivces.BoosterSystem.Core;

namespace _game.Systems.PaymentSystem.PurchaseHandlers
{
	[Token(Token = "0x2000740")]
	public class BoosterPurchaseHandler : IPurchaseHandler
	{
		[Inject(false)]
		[Token(Token = "0x400184A")]
		[FieldOffset(Offset = "0x10")]
		private IBoosterService _boosterService;

		[Token(Token = "0x6001E91")]
		[Address(RVA = "0x3D86DB0", Offset = "0x3D86DB0", Length = "0x134")]
		public void Handle(ShopItemData item)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BoosterPurchaseHandler::Handle");
		}

		[Token(Token = "0x6001E92")]
		[Address(RVA = "0x3D86C14", Offset = "0x3D86C14", Length = "0x8")]
		public BoosterPurchaseHandler()
		{
		}
	}
}
