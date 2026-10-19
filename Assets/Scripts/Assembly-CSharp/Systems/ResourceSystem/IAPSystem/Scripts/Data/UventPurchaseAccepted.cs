using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.EventBusSystem.Runtime;
using Unco.RewardSystem;

namespace Systems.ResourceSystem.IAPSystem.Scripts.Data
{
	[Token(Token = "0x2000034")]
	public struct UventPurchaseAccepted : IEvent
	{
		[Token(Token = "0x17000029")]
		[field: Token(Token = "0x400007B")]
		[field: FieldOffset(Offset = "0x0")]
		public IAPShopEventArgs Args
		{
			[Token(Token = "0x60000BA")]
			[Address(RVA = "0x3C677A0", Offset = "0x3C677A0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Args;\n")]
			get;
			[Token(Token = "0x60000BB")]
			[Address(RVA = "0x3C677A8", Offset = "0x3C677A8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Args = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x1700002A")]
		[field: Token(Token = "0x400007C")]
		[field: FieldOffset(Offset = "0x8")]
		public IEnumerable<LootDrop> purchasedProducts
		{
			[Token(Token = "0x60000BC")]
			[Address(RVA = "0x3C677B0", Offset = "0x3C677B0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.purchasedProducts;\n")]
			get;
			[Token(Token = "0x60000BD")]
			[Address(RVA = "0x3C677B8", Offset = "0x3C677B8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.purchasedProducts = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x60000BE")]
		[Address(RVA = "0x3C677C0", Offset = "0x3C677C0", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn v18;\n")]
		public static UventPurchaseAccepted Create(IAPShopEventArgs args, IEnumerable<LootDrop> purchasedProducts)
		{
			UventPurchaseAccepted result = default(UventPurchaseAccepted);
			return result;
		}
	}
}
