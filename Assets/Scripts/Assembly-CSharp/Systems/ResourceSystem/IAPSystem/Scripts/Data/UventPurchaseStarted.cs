using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.EventBusSystem.Runtime;
using Unco.RewardSystem;

namespace Systems.ResourceSystem.IAPSystem.Scripts.Data
{
	[Token(Token = "0x2000031")]
	public struct UventPurchaseStarted : IEvent
	{
		[Token(Token = "0x17000023")]
		[field: Token(Token = "0x4000075")]
		[field: FieldOffset(Offset = "0x0")]
		public IAPShopEventArgs Args
		{
			[Token(Token = "0x60000AB")]
			[Address(RVA = "0x3C6765C", Offset = "0x3C6765C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Args;\n")]
			get;
			[Token(Token = "0x60000AC")]
			[Address(RVA = "0x3C67664", Offset = "0x3C67664", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Args = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x17000024")]
		[field: Token(Token = "0x4000076")]
		[field: FieldOffset(Offset = "0x8")]
		public IEnumerable<LootDrop> purchasedProducts
		{
			[Token(Token = "0x60000AD")]
			[Address(RVA = "0x3C6766C", Offset = "0x3C6766C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.purchasedProducts;\n")]
			get;
			[Token(Token = "0x60000AE")]
			[Address(RVA = "0x3C67674", Offset = "0x3C67674", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.purchasedProducts = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x60000AF")]
		[Address(RVA = "0x3C6767C", Offset = "0x3C6767C", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn v18;\n")]
		public static UventPurchaseStarted Create(IAPShopEventArgs args, IEnumerable<LootDrop> purchasedProducts)
		{
			UventPurchaseStarted result = default(UventPurchaseStarted);
			return result;
		}
	}
}
