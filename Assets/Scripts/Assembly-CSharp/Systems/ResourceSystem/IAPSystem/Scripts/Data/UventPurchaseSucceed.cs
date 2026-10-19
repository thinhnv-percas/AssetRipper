using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.EventBusSystem.Runtime;
using Unco.RewardSystem;

namespace Systems.ResourceSystem.IAPSystem.Scripts.Data
{
	[Token(Token = "0x2000033")]
	public struct UventPurchaseSucceed : IEvent
	{
		[Token(Token = "0x17000027")]
		[field: Token(Token = "0x4000079")]
		[field: FieldOffset(Offset = "0x0")]
		public IAPShopEventArgs Args
		{
			[Token(Token = "0x60000B5")]
			[Address(RVA = "0x3C67734", Offset = "0x3C67734", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Args;\n")]
			get;
			[Token(Token = "0x60000B6")]
			[Address(RVA = "0x3C6773C", Offset = "0x3C6773C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Args = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x17000028")]
		[field: Token(Token = "0x400007A")]
		[field: FieldOffset(Offset = "0x8")]
		public IEnumerable<LootDrop> purchasedProducts
		{
			[Token(Token = "0x60000B7")]
			[Address(RVA = "0x3C67744", Offset = "0x3C67744", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.purchasedProducts;\n")]
			get;
			[Token(Token = "0x60000B8")]
			[Address(RVA = "0x3C6774C", Offset = "0x3C6774C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.purchasedProducts = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x60000B9")]
		[Address(RVA = "0x3C67754", Offset = "0x3C67754", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn v18;\n")]
		public static UventPurchaseSucceed Create(IAPShopEventArgs args, IEnumerable<LootDrop> purchasedProducts)
		{
			UventPurchaseSucceed result = default(UventPurchaseSucceed);
			return result;
		}
	}
}
