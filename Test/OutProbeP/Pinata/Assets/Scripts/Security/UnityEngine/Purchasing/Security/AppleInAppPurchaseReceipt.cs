using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing.Security
{
	[Token(Token = "0x2000012")]
	public class AppleInAppPurchaseReceipt : IPurchaseReceipt
	{
		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x724F6C", Offset = "0x724F6C")]
		[CompilerGenerated]
		[Token(Token = "0x4000026")]
		[FieldOffset(Offset = "0x10")]
		private int _003Cquantity_003Ek__BackingField;

		[CompilerGenerated]
		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x724FA8", Offset = "0x724FA8")]
		[Token(Token = "0x4000027")]
		[FieldOffset(Offset = "0x18")]
		private string _003CproductID_003Ek__BackingField;

		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x724FE4", Offset = "0x724FE4")]
		[CompilerGenerated]
		[Token(Token = "0x4000028")]
		[FieldOffset(Offset = "0x20")]
		private string _003CtransactionID_003Ek__BackingField;

		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x725020", Offset = "0x725020")]
		[CompilerGenerated]
		[Token(Token = "0x4000029")]
		[FieldOffset(Offset = "0x28")]
		private string _003CoriginalTransactionIdentifier_003Ek__BackingField;

		[CompilerGenerated]
		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72505C", Offset = "0x72505C")]
		[Token(Token = "0x400002A")]
		[FieldOffset(Offset = "0x30")]
		private DateTime _003CpurchaseDate_003Ek__BackingField;

		[CompilerGenerated]
		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x725098", Offset = "0x725098")]
		[Token(Token = "0x400002B")]
		[FieldOffset(Offset = "0x38")]
		private DateTime _003CoriginalPurchaseDate_003Ek__BackingField;

		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x7250D4", Offset = "0x7250D4")]
		[CompilerGenerated]
		[Token(Token = "0x400002C")]
		[FieldOffset(Offset = "0x40")]
		private DateTime _003CsubscriptionExpirationDate_003Ek__BackingField;

		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x725110", Offset = "0x725110")]
		[CompilerGenerated]
		[Token(Token = "0x400002D")]
		[FieldOffset(Offset = "0x48")]
		private DateTime _003CcancellationDate_003Ek__BackingField;

		[CompilerGenerated]
		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72514C", Offset = "0x72514C")]
		[Token(Token = "0x400002E")]
		[FieldOffset(Offset = "0x50")]
		private int _003CisFreeTrial_003Ek__BackingField;

		[CompilerGenerated]
		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x725188", Offset = "0x725188")]
		[Token(Token = "0x400002F")]
		[FieldOffset(Offset = "0x54")]
		private int _003CproductType_003Ek__BackingField;

		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x7251C4", Offset = "0x7251C4")]
		[CompilerGenerated]
		[Token(Token = "0x4000030")]
		[FieldOffset(Offset = "0x58")]
		private int _003CisIntroductoryPricePeriod_003Ek__BackingField;

		[Token(Token = "0x1700001D")]
		internal int quantity
		{
			[CompilerGenerated]
			[Token(Token = "0x600005B")]
			[Address(RVA = "0x15D2134", Offset = "0x15D2134", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<quantity>k__BackingField = value;\n\treturn;\n")]
			set
			{
				_003Cquantity_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700001E")]
		public string productID
		{
			[CompilerGenerated]
			[Token(Token = "0x600005C")]
			[Address(RVA = "0x15D213C", Offset = "0x15D213C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<productID>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return productID;
			}
			[CompilerGenerated]
			[Token(Token = "0x600005D")]
			[Address(RVA = "0x15D2144", Offset = "0x15D2144", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<productID>k__BackingField = value;\n\treturn;\n")]
			internal set
			{
				_003CproductID_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700001F")]
		public string transactionID
		{
			[CompilerGenerated]
			[Token(Token = "0x600005E")]
			[Address(RVA = "0x15D214C", Offset = "0x15D214C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<transactionID>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return transactionID;
			}
			[CompilerGenerated]
			[Token(Token = "0x600005F")]
			[Address(RVA = "0x15D2154", Offset = "0x15D2154", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<transactionID>k__BackingField = value;\n\treturn;\n")]
			internal set
			{
				_003CtransactionID_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000020")]
		public string originalTransactionIdentifier
		{
			[CompilerGenerated]
			[Token(Token = "0x6000060")]
			[Address(RVA = "0x15D215C", Offset = "0x15D215C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<originalTransactionIdentifier>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return originalTransactionIdentifier;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000061")]
			[Address(RVA = "0x15D2164", Offset = "0x15D2164", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<originalTransactionIdentifier>k__BackingField = value;\n\treturn;\n")]
			internal set
			{
				_003CoriginalTransactionIdentifier_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000021")]
		public DateTime purchaseDate
		{
			[CompilerGenerated]
			[Token(Token = "0x6000062")]
			[Address(RVA = "0x15D216C", Offset = "0x15D216C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<purchaseDate>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return purchaseDate;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000063")]
			[Address(RVA = "0x15D2174", Offset = "0x15D2174", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<purchaseDate>k__BackingField = value;\n\treturn;\n")]
			internal set
			{
				_003CpurchaseDate_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000022")]
		public DateTime originalPurchaseDate
		{
			[CompilerGenerated]
			[Token(Token = "0x6000064")]
			[Address(RVA = "0x15D217C", Offset = "0x15D217C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<originalPurchaseDate>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return originalPurchaseDate;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000065")]
			[Address(RVA = "0x15D2184", Offset = "0x15D2184", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<originalPurchaseDate>k__BackingField = value;\n\treturn;\n")]
			internal set
			{
				_003CoriginalPurchaseDate_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000023")]
		public DateTime subscriptionExpirationDate
		{
			[CompilerGenerated]
			[Token(Token = "0x6000066")]
			[Address(RVA = "0x15D218C", Offset = "0x15D218C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<subscriptionExpirationDate>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return subscriptionExpirationDate;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000067")]
			[Address(RVA = "0x15D2194", Offset = "0x15D2194", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<subscriptionExpirationDate>k__BackingField = value;\n\treturn;\n")]
			internal set
			{
				_003CsubscriptionExpirationDate_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000024")]
		public DateTime cancellationDate
		{
			[CompilerGenerated]
			[Token(Token = "0x6000068")]
			[Address(RVA = "0x15D219C", Offset = "0x15D219C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<cancellationDate>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return cancellationDate;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000069")]
			[Address(RVA = "0x15D21A4", Offset = "0x15D21A4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<cancellationDate>k__BackingField = value;\n\treturn;\n")]
			internal set
			{
				_003CcancellationDate_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000025")]
		public int isFreeTrial
		{
			[CompilerGenerated]
			[Token(Token = "0x600006A")]
			[Address(RVA = "0x15D21AC", Offset = "0x15D21AC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<isFreeTrial>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return isFreeTrial;
			}
			[CompilerGenerated]
			[Token(Token = "0x600006B")]
			[Address(RVA = "0x15D21B4", Offset = "0x15D21B4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<isFreeTrial>k__BackingField = value;\n\treturn;\n")]
			internal set
			{
				_003CisFreeTrial_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000026")]
		public int productType
		{
			[CompilerGenerated]
			[Token(Token = "0x600006C")]
			[Address(RVA = "0x15D21BC", Offset = "0x15D21BC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<productType>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return productType;
			}
			[CompilerGenerated]
			[Token(Token = "0x600006D")]
			[Address(RVA = "0x15D21C4", Offset = "0x15D21C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<productType>k__BackingField = value;\n\treturn;\n")]
			internal set
			{
				_003CproductType_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000027")]
		public int isIntroductoryPricePeriod
		{
			[CompilerGenerated]
			[Token(Token = "0x600006E")]
			[Address(RVA = "0x15D21CC", Offset = "0x15D21CC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<isIntroductoryPricePeriod>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return isIntroductoryPricePeriod;
			}
			[CompilerGenerated]
			[Token(Token = "0x600006F")]
			[Address(RVA = "0x15D21D4", Offset = "0x15D21D4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<isIntroductoryPricePeriod>k__BackingField = value;\n\treturn;\n")]
			internal set
			{
				_003CisIntroductoryPricePeriod_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x6000070")]
		[Address(RVA = "0x15D21DC", Offset = "0x15D21DC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AppleInAppPurchaseReceipt()
		{
		}
	}
}
