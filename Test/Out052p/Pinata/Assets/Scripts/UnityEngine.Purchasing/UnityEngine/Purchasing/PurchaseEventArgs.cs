using System.Diagnostics;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000012")]
	public class PurchaseEventArgs
	{
		[Token(Token = "0x1700001B")]
		[field: Attribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x726788", Offset = "0x726788")]
		[field: Token(Token = "0x400002F")]
		[field: FieldOffset(Offset = "0x10")]
		public Product purchasedProduct
		{
			[Token(Token = "0x600005B")]
			[Address(RVA = "0x160F098", Offset = "0x160F098", Length = "0x8")]
			get;
			[Token(Token = "0x600005C")]
			[Address(RVA = "0x160F0A0", Offset = "0x160F0A0", Length = "0x8")]
			private set;
		}

		[Token(Token = "0x600005A")]
		[Address(RVA = "0x160F06C", Offset = "0x160F06C", Length = "0x2C")]
		internal PurchaseEventArgs(Product purchasedProduct)
		{
		}
	}
}
