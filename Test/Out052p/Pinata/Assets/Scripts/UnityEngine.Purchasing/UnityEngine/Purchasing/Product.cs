using System.Diagnostics;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x200000D")]
	public class Product
	{
		[Token(Token = "0x17000009")]
		[field: Attribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x726420", Offset = "0x726420")]
		[field: Token(Token = "0x4000016")]
		[field: FieldOffset(Offset = "0x10")]
		public ProductDefinition definition
		{
			[Token(Token = "0x6000029")]
			[Address(RVA = "0x160E908", Offset = "0x160E908", Length = "0x8")]
			get;
			[Token(Token = "0x600002A")]
			[Address(RVA = "0x160E910", Offset = "0x160E910", Length = "0x8")]
			private set;
		}

		[Token(Token = "0x1700000A")]
		[field: Attribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72645C", Offset = "0x72645C")]
		[field: Token(Token = "0x4000017")]
		[field: FieldOffset(Offset = "0x18")]
		public ProductMetadata metadata
		{
			[Token(Token = "0x600002B")]
			[Address(RVA = "0x160E918", Offset = "0x160E918", Length = "0x8")]
			get;
			[Token(Token = "0x600002C")]
			[Address(RVA = "0x160E920", Offset = "0x160E920", Length = "0x8")]
			internal set;
		}

		[Token(Token = "0x1700000B")]
		[field: Attribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x726498", Offset = "0x726498")]
		[field: Token(Token = "0x4000018")]
		[field: FieldOffset(Offset = "0x20")]
		public bool availableToPurchase
		{
			[Token(Token = "0x600002D")]
			[Address(RVA = "0x160E928", Offset = "0x160E928", Length = "0x8")]
			get;
			[Token(Token = "0x600002E")]
			[Address(RVA = "0x160E930", Offset = "0x160E930", Length = "0xC")]
			internal set;
		}

		[Token(Token = "0x1700000C")]
		[field: Attribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x7264D4", Offset = "0x7264D4")]
		[field: Token(Token = "0x4000019")]
		[field: FieldOffset(Offset = "0x28")]
		public string transactionID
		{
			[Token(Token = "0x600002F")]
			[Address(RVA = "0x160E93C", Offset = "0x160E93C", Length = "0x8")]
			get;
			[Token(Token = "0x6000030")]
			[Address(RVA = "0x160E944", Offset = "0x160E944", Length = "0x8")]
			internal set;
		}

		[Token(Token = "0x1700000D")]
		public bool hasReceipt
		{
			[Token(Token = "0x6000031")]
			[Address(RVA = "0x160E94C", Offset = "0x160E94C", Length = "0x24")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x1700000E")]
		[field: Attribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x726510", Offset = "0x726510")]
		[field: Token(Token = "0x400001A")]
		[field: FieldOffset(Offset = "0x30")]
		public string receipt
		{
			[Token(Token = "0x6000032")]
			[Address(RVA = "0x160E970", Offset = "0x160E970", Length = "0x8")]
			get;
			[Token(Token = "0x6000033")]
			[Address(RVA = "0x160E978", Offset = "0x160E978", Length = "0x8")]
			internal set;
		}

		[Token(Token = "0x6000027")]
		[Address(RVA = "0x160E88C", Offset = "0x160E88C", Length = "0x40")]
		internal Product(ProductDefinition definition, ProductMetadata metadata, string receipt)
		{
		}

		[Token(Token = "0x6000028")]
		[Address(RVA = "0x160E8CC", Offset = "0x160E8CC", Length = "0x3C")]
		internal Product(ProductDefinition definition, ProductMetadata metadata)
		{
		}

		[Token(Token = "0x6000034")]
		[Address(RVA = "0x160E980", Offset = "0x160E980", Length = "0xBC")]
		public override bool Equals(object obj)
		{
			return false;
		}

		[Token(Token = "0x6000035")]
		[Address(RVA = "0x160EA3C", Offset = "0x160EA3C", Length = "0x20")]
		public override int GetHashCode()
		{
			return 0;
		}
	}
}
