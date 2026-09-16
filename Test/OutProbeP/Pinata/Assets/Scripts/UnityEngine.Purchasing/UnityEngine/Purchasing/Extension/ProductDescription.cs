using System.Diagnostics;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing.Extension
{
	[Token(Token = "0x2000029")]
	public class ProductDescription
	{
		[Token(Token = "0x400005E")]
		[FieldOffset(Offset = "0x18")]
		public ProductType type;

		[Token(Token = "0x17000024")]
		[field: Attribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72693C", Offset = "0x72693C")]
		[field: Token(Token = "0x400005D")]
		[field: FieldOffset(Offset = "0x10")]
		public string storeSpecificId
		{
			[Token(Token = "0x60000B9")]
			[Address(RVA = "0x160E184", Offset = "0x160E184", Length = "0x8")]
			get;
			[Token(Token = "0x60000BA")]
			[Address(RVA = "0x160E18C", Offset = "0x160E18C", Length = "0x8")]
			private set;
		}

		[Token(Token = "0x17000025")]
		[field: Attribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x726978", Offset = "0x726978")]
		[field: Token(Token = "0x400005F")]
		[field: FieldOffset(Offset = "0x20")]
		public ProductMetadata metadata
		{
			[Token(Token = "0x60000BB")]
			[Address(RVA = "0x160E194", Offset = "0x160E194", Length = "0x8")]
			get;
			[Token(Token = "0x60000BC")]
			[Address(RVA = "0x160E19C", Offset = "0x160E19C", Length = "0x8")]
			private set;
		}

		[Token(Token = "0x17000026")]
		[field: Attribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x7269B4", Offset = "0x7269B4")]
		[field: Token(Token = "0x4000060")]
		[field: FieldOffset(Offset = "0x28")]
		public string receipt
		{
			[Token(Token = "0x60000BD")]
			[Address(RVA = "0x160E1A4", Offset = "0x160E1A4", Length = "0x8")]
			get;
			[Token(Token = "0x60000BE")]
			[Address(RVA = "0x160E1AC", Offset = "0x160E1AC", Length = "0x8")]
			private set;
		}

		[Token(Token = "0x17000027")]
		[field: Attribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x7269F0", Offset = "0x7269F0")]
		[field: Token(Token = "0x4000061")]
		[field: FieldOffset(Offset = "0x30")]
		public string transactionId
		{
			[Token(Token = "0x60000BF")]
			[Address(RVA = "0x160E1B4", Offset = "0x160E1B4", Length = "0x8")]
			get;
			[Token(Token = "0x60000C0")]
			[Address(RVA = "0x160E1BC", Offset = "0x160E1BC", Length = "0x8")]
			set;
		}

		[Token(Token = "0x60000B6")]
		[Address(RVA = "0x160E09C", Offset = "0x160E09C", Length = "0x50")]
		public ProductDescription(string id, ProductMetadata metadata, string receipt, string transactionId)
		{
		}

		[Token(Token = "0x60000B7")]
		[Address(RVA = "0x160E0EC", Offset = "0x160E0EC", Length = "0x58")]
		public ProductDescription(string id, ProductMetadata metadata, string receipt, string transactionId, ProductType type)
		{
		}

		[Token(Token = "0x60000B8")]
		[Address(RVA = "0x160E144", Offset = "0x160E144", Length = "0x40")]
		public ProductDescription(string id, ProductMetadata metadata)
		{
		}
	}
}
