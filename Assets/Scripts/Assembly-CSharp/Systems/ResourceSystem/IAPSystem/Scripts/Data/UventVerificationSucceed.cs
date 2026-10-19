using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.EventBusSystem.Runtime;
using Unco.RewardSystem;

namespace Systems.ResourceSystem.IAPSystem.Scripts.Data
{
	[Token(Token = "0x2000035")]
	public struct UventVerificationSucceed : IEvent
	{
		[Token(Token = "0x1700002B")]
		[field: Token(Token = "0x400007D")]
		[field: FieldOffset(Offset = "0x0")]
		public IAPShopEventArgs Args
		{
			[Token(Token = "0x60000BF")]
			[Address(RVA = "0x3C6780C", Offset = "0x3C6780C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Args;\n")]
			get;
			[Token(Token = "0x60000C0")]
			[Address(RVA = "0x3C67814", Offset = "0x3C67814", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Args = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x1700002C")]
		[field: Token(Token = "0x400007E")]
		[field: FieldOffset(Offset = "0x8")]
		public IEnumerable<LootDrop> purchasedProducts
		{
			[Token(Token = "0x60000C1")]
			[Address(RVA = "0x3C6781C", Offset = "0x3C6781C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.purchasedProducts;\n")]
			get;
			[Token(Token = "0x60000C2")]
			[Address(RVA = "0x3C67824", Offset = "0x3C67824", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.purchasedProducts = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x60000C3")]
		[Address(RVA = "0x3C6782C", Offset = "0x3C6782C", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn v18;\n")]
		public static UventVerificationSucceed Create(IAPShopEventArgs args, IEnumerable<LootDrop> purchasedProducts)
		{
			UventVerificationSucceed result = default(UventVerificationSucceed);
			return result;
		}
	}
}
