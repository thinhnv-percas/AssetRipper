using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing.Security
{
	[Token(Token = "0x2000011")]
	public class AppleReceipt
	{
		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x724E04", Offset = "0x724E04")]
		[CompilerGenerated]
		[Token(Token = "0x400001F")]
		[FieldOffset(Offset = "0x10")]
		private string _003CbundleID_003Ek__BackingField;

		[CompilerGenerated]
		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x724E40", Offset = "0x724E40")]
		[Token(Token = "0x4000020")]
		[FieldOffset(Offset = "0x18")]
		private string _003CappVersion_003Ek__BackingField;

		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x724E7C", Offset = "0x724E7C")]
		[CompilerGenerated]
		[Token(Token = "0x4000021")]
		[FieldOffset(Offset = "0x20")]
		private byte[] _003Copaque_003Ek__BackingField;

		[CompilerGenerated]
		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x724EB8", Offset = "0x724EB8")]
		[Token(Token = "0x4000022")]
		[FieldOffset(Offset = "0x28")]
		private byte[] _003Chash_003Ek__BackingField;

		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x724EF4", Offset = "0x724EF4")]
		[CompilerGenerated]
		[Token(Token = "0x4000023")]
		[FieldOffset(Offset = "0x30")]
		private string _003CoriginalApplicationVersion_003Ek__BackingField;

		[CompilerGenerated]
		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x724F30", Offset = "0x724F30")]
		[Token(Token = "0x4000024")]
		[FieldOffset(Offset = "0x38")]
		private DateTime _003CreceiptCreationDate_003Ek__BackingField;

		[Token(Token = "0x4000025")]
		[FieldOffset(Offset = "0x40")]
		public AppleInAppPurchaseReceipt[] inAppPurchaseReceipts;

		[Token(Token = "0x17000017")]
		public string bundleID
		{
			[CompilerGenerated]
			[Token(Token = "0x6000052")]
			[Address(RVA = "0x15D21E4", Offset = "0x15D21E4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<bundleID>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return bundleID;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000053")]
			[Address(RVA = "0x15D21EC", Offset = "0x15D21EC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<bundleID>k__BackingField = value;\n\treturn;\n")]
			internal set
			{
				_003CbundleID_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000018")]
		internal string appVersion
		{
			[CompilerGenerated]
			[Token(Token = "0x6000054")]
			[Address(RVA = "0x15D21F4", Offset = "0x15D21F4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<appVersion>k__BackingField = value;\n\treturn;\n")]
			set
			{
				_003CappVersion_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000019")]
		internal byte[] opaque
		{
			[CompilerGenerated]
			[Token(Token = "0x6000055")]
			[Address(RVA = "0x15D21FC", Offset = "0x15D21FC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<opaque>k__BackingField = value;\n\treturn;\n")]
			set
			{
				_003Copaque_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700001A")]
		internal byte[] hash
		{
			[CompilerGenerated]
			[Token(Token = "0x6000056")]
			[Address(RVA = "0x15D2204", Offset = "0x15D2204", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<hash>k__BackingField = value;\n\treturn;\n")]
			set
			{
				_003Chash_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700001B")]
		internal string originalApplicationVersion
		{
			[CompilerGenerated]
			[Token(Token = "0x6000057")]
			[Address(RVA = "0x15D220C", Offset = "0x15D220C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<originalApplicationVersion>k__BackingField = value;\n\treturn;\n")]
			set
			{
				_003CoriginalApplicationVersion_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700001C")]
		public DateTime receiptCreationDate
		{
			[CompilerGenerated]
			[Token(Token = "0x6000058")]
			[Address(RVA = "0x15D2214", Offset = "0x15D2214", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<receiptCreationDate>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return receiptCreationDate;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000059")]
			[Address(RVA = "0x15D221C", Offset = "0x15D221C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<receiptCreationDate>k__BackingField = value;\n\treturn;\n")]
			internal set
			{
				_003CreceiptCreationDate_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x600005A")]
		[Address(RVA = "0x15D2224", Offset = "0x15D2224", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AppleReceipt()
		{
		}
	}
}
