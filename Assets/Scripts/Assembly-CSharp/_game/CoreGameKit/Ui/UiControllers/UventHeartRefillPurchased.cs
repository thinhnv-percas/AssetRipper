using Cpp2ILInjected;
using Unco.EventBusSystem.Runtime;
using _game.CoreSystem.HealthSystem;

namespace _game.CoreGameKit.Ui.UiControllers
{
	[Token(Token = "0x2000552")]
	public readonly struct UventHeartRefillPurchased : IEvent
	{
		[Token(Token = "0x40011F4")]
		[FieldOffset(Offset = "0x0")]
		public readonly RefillHeartConfig.PurchaseOption PurchaseOption;

		[Token(Token = "0x600163B")]
		[Address(RVA = "0x3D1A198", Offset = "0x3D1A198", Length = "0x14")]
		public UventHeartRefillPurchased(RefillHeartConfig.PurchaseOption purchaseOption)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UventHeartRefillPurchased::.ctor");
			this = default;
		}
	}
}
