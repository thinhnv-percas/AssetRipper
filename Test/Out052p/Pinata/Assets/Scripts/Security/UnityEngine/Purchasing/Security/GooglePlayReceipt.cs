using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing.Security
{
	[Token(Token = "0x200001E")]
	public class GooglePlayReceipt : IPurchaseReceipt
	{
		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x725200", Offset = "0x725200")]
		[CompilerGenerated]
		[Token(Token = "0x400003A")]
		[FieldOffset(Offset = "0x10")]
		internal string _003CproductID_003Ek__BackingField;

		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72523C", Offset = "0x72523C")]
		[CompilerGenerated]
		[Token(Token = "0x400003B")]
		[FieldOffset(Offset = "0x18")]
		internal string _003CtransactionID_003Ek__BackingField;

		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x725278", Offset = "0x725278")]
		[CompilerGenerated]
		[Token(Token = "0x400003C")]
		[FieldOffset(Offset = "0x20")]
		internal string _003CpackageName_003Ek__BackingField;

		[CompilerGenerated]
		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x7252B4", Offset = "0x7252B4")]
		[Token(Token = "0x400003D")]
		[FieldOffset(Offset = "0x28")]
		internal string _003CpurchaseToken_003Ek__BackingField;

		[CompilerGenerated]
		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x7252F0", Offset = "0x7252F0")]
		[Token(Token = "0x400003E")]
		[FieldOffset(Offset = "0x30")]
		internal DateTime _003CpurchaseDate_003Ek__BackingField;

		[CompilerGenerated]
		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72532C", Offset = "0x72532C")]
		[Token(Token = "0x400003F")]
		[FieldOffset(Offset = "0x38")]
		internal GooglePurchaseState _003CpurchaseState_003Ek__BackingField;

		[Token(Token = "0x1700002B")]
		public string productID
		{
			[CompilerGenerated]
			[Token(Token = "0x6000080")]
			[Address(RVA = "0x15D4C08", Offset = "0x15D4C08", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<productID>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return productID;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000081")]
			[Address(RVA = "0x15D4C10", Offset = "0x15D4C10", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<productID>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CproductID_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700002C")]
		public string transactionID
		{
			[CompilerGenerated]
			[Token(Token = "0x6000082")]
			[Address(RVA = "0x15D4C18", Offset = "0x15D4C18", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<transactionID>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return transactionID;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000083")]
			[Address(RVA = "0x15D4C20", Offset = "0x15D4C20", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<transactionID>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CtransactionID_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700002D")]
		public string packageName
		{
			[CompilerGenerated]
			[Token(Token = "0x6000084")]
			[Address(RVA = "0x15D4C28", Offset = "0x15D4C28", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<packageName>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return packageName;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000085")]
			[Address(RVA = "0x15D4C30", Offset = "0x15D4C30", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<packageName>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CpackageName_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700002E")]
		private string purchaseToken
		{
			[CompilerGenerated]
			[Token(Token = "0x6000086")]
			[Address(RVA = "0x15D4C38", Offset = "0x15D4C38", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<purchaseToken>k__BackingField = value;\n\treturn;\n")]
			set
			{
				_003CpurchaseToken_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700002F")]
		public DateTime purchaseDate
		{
			[CompilerGenerated]
			[Token(Token = "0x6000087")]
			[Address(RVA = "0x15D4C40", Offset = "0x15D4C40", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<purchaseDate>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return purchaseDate;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000088")]
			[Address(RVA = "0x15D4C48", Offset = "0x15D4C48", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<purchaseDate>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CpurchaseDate_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000030")]
		private GooglePurchaseState purchaseState
		{
			[CompilerGenerated]
			[Token(Token = "0x6000089")]
			[Address(RVA = "0x15D4C50", Offset = "0x15D4C50", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<purchaseState>k__BackingField = value;\n\treturn;\n")]
			set
			{
				_003CpurchaseState_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x600008A")]
		[Address(RVA = "0x15D4C58", Offset = "0x15D4C58", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<productID>k__BackingField = productID;\n\tthis.<transactionID>k__BackingField = transactionID;\n\tthis.<packageName>k__BackingField = packageName;\n\tthis.<purchaseToken>k__BackingField = purchaseToken;\n\tthis.<purchaseDate>k__BackingField = purchaseTime;\n\tthis.<purchaseState>k__BackingField = purchaseState;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GooglePlayReceipt(string productID, string transactionID, string packageName, string purchaseToken, DateTime purchaseTime, GooglePurchaseState purchaseState)
		{
			this.productID = productID;
			this.transactionID = transactionID;
			this.packageName = packageName;
			this._003CpurchaseToken_003Ek__BackingField = purchaseToken;
			purchaseDate = purchaseTime;
			this._003CpurchaseState_003Ek__BackingField = purchaseState;
		}
	}
}
