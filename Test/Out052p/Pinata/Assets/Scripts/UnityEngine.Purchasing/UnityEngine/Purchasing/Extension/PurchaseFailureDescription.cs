using System.Diagnostics;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing.Extension
{
	[Token(Token = "0x2000013")]
	public class PurchaseFailureDescription
	{
		[Token(Token = "0x1700001C")]
		[field: Attribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x7267C4", Offset = "0x7267C4")]
		[field: Token(Token = "0x4000030")]
		[field: FieldOffset(Offset = "0x10")]
		public string productId
		{
			[Token(Token = "0x600005E")]
			[Address(RVA = "0x160E208", Offset = "0x160E208", Length = "0x8")]
			get;
			[Token(Token = "0x600005F")]
			[Address(RVA = "0x160E210", Offset = "0x160E210", Length = "0x8")]
			private set;
		}

		[Token(Token = "0x1700001D")]
		[field: Attribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x726800", Offset = "0x726800")]
		[field: Token(Token = "0x4000031")]
		[field: FieldOffset(Offset = "0x18")]
		public PurchaseFailureReason reason
		{
			[Token(Token = "0x6000060")]
			[Address(RVA = "0x160E218", Offset = "0x160E218", Length = "0x8")]
			get;
			[Token(Token = "0x6000061")]
			[Address(RVA = "0x160E220", Offset = "0x160E220", Length = "0x8")]
			private set;
		}

		[Token(Token = "0x1700001E")]
		[field: Attribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72683C", Offset = "0x72683C")]
		[field: Token(Token = "0x4000032")]
		[field: FieldOffset(Offset = "0x20")]
		public string message
		{
			[Token(Token = "0x6000062")]
			[Address(RVA = "0x160E228", Offset = "0x160E228", Length = "0x8")]
			get;
			[Token(Token = "0x6000063")]
			[Address(RVA = "0x160E230", Offset = "0x160E230", Length = "0x8")]
			private set;
		}

		[Token(Token = "0x600005D")]
		[Address(RVA = "0x160E1C4", Offset = "0x160E1C4", Length = "0x44")]
		public PurchaseFailureDescription(string productId, PurchaseFailureReason reason, string message)
		{
		}
	}
}
