using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.UDP
{
	[Serializable]
	[Token(Token = "0x200000D")]
	public class ProductInfo
	{
		[Token(Token = "0x17000003")]
		public string ItemType
		{
			[CompilerGenerated]
			[Token(Token = "0x6000037")]
			[Address(RVA = "0x15CA58C", Offset = "0x15CA58C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<ItemType>k__BackingField = value;\n\treturn;\n")]
			set
			{
				ItemType = value;
			}
		}

		[Token(Token = "0x17000004")]
		public string ProductId
		{
			[CompilerGenerated]
			[Token(Token = "0x6000038")]
			[Address(RVA = "0x15CA594", Offset = "0x15CA594", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<ProductId>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ProductId;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000039")]
			[Address(RVA = "0x15CA59C", Offset = "0x15CA59C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<ProductId>k__BackingField = value;\n\treturn;\n")]
			set
			{
				ProductId = value;
			}
		}

		[Token(Token = "0x17000005")]
		public bool? Consumable
		{
			[CompilerGenerated]
			[Token(Token = "0x600003A")]
			[Address(RVA = "0x15CA5A4", Offset = "0x15CA5A4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Consumable>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Consumable = value;
			}
		}

		[Token(Token = "0x17000006")]
		public string Price
		{
			[CompilerGenerated]
			[Token(Token = "0x600003B")]
			[Address(RVA = "0x15CA5AC", Offset = "0x15CA5AC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Price>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Price;
			}
			[CompilerGenerated]
			[Token(Token = "0x600003C")]
			[Address(RVA = "0x15CA5B4", Offset = "0x15CA5B4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Price>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Price = value;
			}
		}

		[Token(Token = "0x17000007")]
		public long PriceAmountMicros
		{
			[CompilerGenerated]
			[Token(Token = "0x600003D")]
			[Address(RVA = "0x15CA5BC", Offset = "0x15CA5BC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<PriceAmountMicros>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return PriceAmountMicros;
			}
			[CompilerGenerated]
			[Token(Token = "0x600003E")]
			[Address(RVA = "0x15CA5C4", Offset = "0x15CA5C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<PriceAmountMicros>k__BackingField = value;\n\treturn;\n")]
			set
			{
				PriceAmountMicros = value;
			}
		}

		[Token(Token = "0x17000008")]
		public string Currency
		{
			[CompilerGenerated]
			[Token(Token = "0x600003F")]
			[Address(RVA = "0x15CA5CC", Offset = "0x15CA5CC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Currency>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Currency;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000040")]
			[Address(RVA = "0x15CA5D4", Offset = "0x15CA5D4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Currency>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Currency = value;
			}
		}

		[Token(Token = "0x17000009")]
		public string Title
		{
			[CompilerGenerated]
			[Token(Token = "0x6000041")]
			[Address(RVA = "0x15CA5DC", Offset = "0x15CA5DC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Title>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Title;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000042")]
			[Address(RVA = "0x15CA5E4", Offset = "0x15CA5E4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Title>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Title = value;
			}
		}

		[Token(Token = "0x1700000A")]
		public string Description
		{
			[CompilerGenerated]
			[Token(Token = "0x6000043")]
			[Address(RVA = "0x15CA5EC", Offset = "0x15CA5EC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Description>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Description;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000044")]
			[Address(RVA = "0x15CA5F4", Offset = "0x15CA5F4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Description>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Description = value;
			}
		}

		[Token(Token = "0x6000045")]
		[Address(RVA = "0x15CA5FC", Offset = "0x15CA5FC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ProductInfo()
		{
		}
	}
}
