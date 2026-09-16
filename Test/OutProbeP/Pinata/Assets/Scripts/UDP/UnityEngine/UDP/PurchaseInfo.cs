using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.UDP
{
	[Serializable]
	[Token(Token = "0x2000014")]
	public class PurchaseInfo
	{
		[Token(Token = "0x1700000F")]
		public string ItemType
		{
			[CompilerGenerated]
			[Token(Token = "0x600005E")]
			[Address(RVA = "0x15CB8DC", Offset = "0x15CB8DC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<ItemType>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ItemType;
			}
			[CompilerGenerated]
			[Token(Token = "0x600005F")]
			[Address(RVA = "0x15CB8E4", Offset = "0x15CB8E4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<ItemType>k__BackingField = value;\n\treturn;\n")]
			set
			{
				ItemType = value;
			}
		}

		[Token(Token = "0x17000010")]
		public string ProductId
		{
			[CompilerGenerated]
			[Token(Token = "0x6000060")]
			[Address(RVA = "0x15CB8EC", Offset = "0x15CB8EC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<ProductId>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ProductId;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000061")]
			[Address(RVA = "0x15CB8F4", Offset = "0x15CB8F4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<ProductId>k__BackingField = value;\n\treturn;\n")]
			set
			{
				ProductId = value;
			}
		}

		[Token(Token = "0x17000011")]
		public string GameOrderId
		{
			[CompilerGenerated]
			[Token(Token = "0x6000062")]
			[Address(RVA = "0x15CB8FC", Offset = "0x15CB8FC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<GameOrderId>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return GameOrderId;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000063")]
			[Address(RVA = "0x15CB904", Offset = "0x15CB904", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<GameOrderId>k__BackingField = value;\n\treturn;\n")]
			set
			{
				GameOrderId = value;
			}
		}

		[Token(Token = "0x17000012")]
		public string OrderQueryToken
		{
			[CompilerGenerated]
			[Token(Token = "0x6000064")]
			[Address(RVA = "0x15CB90C", Offset = "0x15CB90C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<OrderQueryToken>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return OrderQueryToken;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000065")]
			[Address(RVA = "0x15CB914", Offset = "0x15CB914", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<OrderQueryToken>k__BackingField = value;\n\treturn;\n")]
			set
			{
				OrderQueryToken = value;
			}
		}

		[Token(Token = "0x17000013")]
		public string DeveloperPayload
		{
			[CompilerGenerated]
			[Token(Token = "0x6000066")]
			[Address(RVA = "0x15CB91C", Offset = "0x15CB91C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<DeveloperPayload>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DeveloperPayload;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000067")]
			[Address(RVA = "0x15CB924", Offset = "0x15CB924", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<DeveloperPayload>k__BackingField = value;\n\treturn;\n")]
			set
			{
				DeveloperPayload = value;
			}
		}

		[Token(Token = "0x17000014")]
		public string StorePurchaseJsonString
		{
			[CompilerGenerated]
			[Token(Token = "0x6000068")]
			[Address(RVA = "0x15CB92C", Offset = "0x15CB92C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<StorePurchaseJsonString>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return StorePurchaseJsonString;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000069")]
			[Address(RVA = "0x15CB934", Offset = "0x15CB934", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<StorePurchaseJsonString>k__BackingField = value;\n\treturn;\n")]
			set
			{
				StorePurchaseJsonString = value;
			}
		}

		[Token(Token = "0x600006A")]
		[Address(RVA = "0x15C9170", Offset = "0x15C9170", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PurchaseInfo()
		{
		}
	}
}
