using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.EventBusSystem.Runtime;
using Unco.RewardSystem;

namespace Systems.ResourceSystem.IAPSystem.Scripts.Data
{
	[Token(Token = "0x2000036")]
	public struct UventVerificationFailed : IEvent
	{
		[Token(Token = "0x1700002D")]
		[field: Token(Token = "0x400007F")]
		[field: FieldOffset(Offset = "0x0")]
		public IAPShopEventArgs Args
		{
			[Token(Token = "0x60000C4")]
			[Address(RVA = "0x3C67878", Offset = "0x3C67878", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Args;\n")]
			get;
			[Token(Token = "0x60000C5")]
			[Address(RVA = "0x3C67880", Offset = "0x3C67880", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Args = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x1700002E")]
		[field: Token(Token = "0x4000080")]
		[field: FieldOffset(Offset = "0x8")]
		public IEnumerable<LootDrop> purchasedProducts
		{
			[Token(Token = "0x60000C6")]
			[Address(RVA = "0x3C67888", Offset = "0x3C67888", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.purchasedProducts;\n")]
			get;
			[Token(Token = "0x60000C7")]
			[Address(RVA = "0x3C67890", Offset = "0x3C67890", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.purchasedProducts = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x60000C8")]
		[Address(RVA = "0x3C67898", Offset = "0x3C67898", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn v18;\n")]
		public static UventVerificationFailed Create(IAPShopEventArgs args, IEnumerable<LootDrop> purchasedProducts)
		{
			UventVerificationFailed result = default(UventVerificationFailed);
			return result;
		}
	}
}
