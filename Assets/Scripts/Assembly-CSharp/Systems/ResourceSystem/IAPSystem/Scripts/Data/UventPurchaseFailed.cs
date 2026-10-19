using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.EventBusSystem.Runtime;
using Unco.RewardSystem;

namespace Systems.ResourceSystem.IAPSystem.Scripts.Data
{
	[Token(Token = "0x2000032")]
	public struct UventPurchaseFailed : IEvent
	{
		[Token(Token = "0x17000025")]
		[field: Token(Token = "0x4000077")]
		[field: FieldOffset(Offset = "0x0")]
		public IAPShopEventArgs Args
		{
			[Token(Token = "0x60000B0")]
			[Address(RVA = "0x3C676C8", Offset = "0x3C676C8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Args;\n")]
			get;
			[Token(Token = "0x60000B1")]
			[Address(RVA = "0x3C676D0", Offset = "0x3C676D0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Args = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x17000026")]
		[field: Token(Token = "0x4000078")]
		[field: FieldOffset(Offset = "0x8")]
		public IEnumerable<LootDrop> purchasedProducts
		{
			[Token(Token = "0x60000B2")]
			[Address(RVA = "0x3C676D8", Offset = "0x3C676D8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.purchasedProducts;\n")]
			get;
			[Token(Token = "0x60000B3")]
			[Address(RVA = "0x3C676E0", Offset = "0x3C676E0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.purchasedProducts = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x60000B4")]
		[Address(RVA = "0x3C676E8", Offset = "0x3C676E8", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn v18;\n")]
		public static UventPurchaseFailed Create(IAPShopEventArgs args, IEnumerable<LootDrop> purchasedProducts)
		{
			UventPurchaseFailed result = default(UventPurchaseFailed);
			return result;
		}
	}
}
