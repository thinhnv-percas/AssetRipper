using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.EventBusSystem.Runtime;
using _game.CoreGameKit.Tracking;

namespace Systems.ResourceSystem.IAPSystem.Scripts.Data
{
	[Token(Token = "0x200003B")]
	public struct UventShopItemPurchased : IEvent
	{
		[Token(Token = "0x4000084")]
		[FieldOffset(Offset = "0x0")]
		public TrackingKey trackingKey;

		[Token(Token = "0x60000CD")]
		[Address(RVA = "0x3C67954", Offset = "0x3C67954", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn eventKey;\n")]
		public static UventShopItemPurchased Create(TrackingKey eventKey)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UventShopItemPurchased::Create");
			return default;
		}
	}
}
