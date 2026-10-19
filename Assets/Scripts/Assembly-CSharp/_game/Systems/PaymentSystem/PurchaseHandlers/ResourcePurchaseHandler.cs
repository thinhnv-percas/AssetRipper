using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.ResourceSystem;
using Unco.RewardSystem;

namespace _game.Systems.PaymentSystem.PurchaseHandlers
{
	[Token(Token = "0x2000743")]
	public class ResourcePurchaseHandler : IPurchaseHandler
	{
		[Inject(false)]
		[Token(Token = "0x400184C")]
		[FieldOffset(Offset = "0x10")]
		private IResourceService _resourceService;

		[Inject(false)]
		[Token(Token = "0x400184D")]
		[FieldOffset(Offset = "0x18")]
		private TransactionContextFactory _ctxFactory;

		[Token(Token = "0x6001E97")]
		[Address(RVA = "0x3D8709C", Offset = "0x3D8709C", Length = "0x164")]
		public unsafe void Handle(ShopItemData item)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ResourcePurchaseHandler::Handle");
		}

		[Token(Token = "0x6001E98")]
		[Address(RVA = "0x3D86C0C", Offset = "0x3D86C0C", Length = "0x8")]
		public ResourcePurchaseHandler()
		{
		}
	}
}
