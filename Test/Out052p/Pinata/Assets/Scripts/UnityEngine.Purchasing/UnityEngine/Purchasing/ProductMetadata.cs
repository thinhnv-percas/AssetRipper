using System.Diagnostics;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000010")]
	public class ProductMetadata
	{
		[Token(Token = "0x17000016")]
		[field: Attribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72665C", Offset = "0x72665C")]
		[field: Token(Token = "0x4000026")]
		[field: FieldOffset(Offset = "0x10")]
		public string localizedPriceString
		{
			[Token(Token = "0x6000050")]
			[Address(RVA = "0x160F018", Offset = "0x160F018", Length = "0x8")]
			get;
			[Token(Token = "0x6000051")]
			[Address(RVA = "0x160F020", Offset = "0x160F020", Length = "0x8")]
			internal set;
		}

		[Token(Token = "0x17000017")]
		[field: Attribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x726698", Offset = "0x726698")]
		[field: Token(Token = "0x4000027")]
		[field: FieldOffset(Offset = "0x18")]
		public string localizedTitle
		{
			[Token(Token = "0x6000052")]
			[Address(RVA = "0x160F028", Offset = "0x160F028", Length = "0x8")]
			get;
			[Token(Token = "0x6000053")]
			[Address(RVA = "0x160F030", Offset = "0x160F030", Length = "0x8")]
			internal set;
		}

		[Token(Token = "0x17000018")]
		[field: Attribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x7266D4", Offset = "0x7266D4")]
		[field: Token(Token = "0x4000028")]
		[field: FieldOffset(Offset = "0x20")]
		public string localizedDescription
		{
			[Token(Token = "0x6000054")]
			[Address(RVA = "0x160F038", Offset = "0x160F038", Length = "0x8")]
			get;
			[Token(Token = "0x6000055")]
			[Address(RVA = "0x160F040", Offset = "0x160F040", Length = "0x8")]
			internal set;
		}

		[Token(Token = "0x17000019")]
		[field: Attribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x726710", Offset = "0x726710")]
		[field: Token(Token = "0x4000029")]
		[field: FieldOffset(Offset = "0x28")]
		public string isoCurrencyCode
		{
			[Token(Token = "0x6000056")]
			[Address(RVA = "0x160F048", Offset = "0x160F048", Length = "0x8")]
			get;
			[Token(Token = "0x6000057")]
			[Address(RVA = "0x160F050", Offset = "0x160F050", Length = "0x8")]
			internal set;
		}

		[Token(Token = "0x1700001A")]
		[field: Attribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72674C", Offset = "0x72674C")]
		[field: Token(Token = "0x400002A")]
		[field: FieldOffset(Offset = "0x30")]
		public decimal localizedPrice
		{
			[Token(Token = "0x6000058")]
			[Address(RVA = "0x160F058", Offset = "0x160F058", Length = "0xC")]
			get;
			[Token(Token = "0x6000059")]
			[Address(RVA = "0x160F064", Offset = "0x160F064", Length = "0x8")]
			internal set;
		}

		[Token(Token = "0x600004E")]
		[Address(RVA = "0x160EFB0", Offset = "0x160EFB0", Length = "0x60")]
		public ProductMetadata(string priceString, string title, string description, string currencyCode, decimal localizedPrice)
		{
		}

		[Token(Token = "0x600004F")]
		[Address(RVA = "0x160F010", Offset = "0x160F010", Length = "0x8")]
		public ProductMetadata()
		{
		}
	}
}
