using System;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing.Security
{
	[Token(Token = "0x200001C")]
	public interface IPurchaseReceipt
	{
		[Token(Token = "0x17000028")]
		string transactionID
		{
			[Token(Token = "0x600007D")]
			get;
		}

		[Token(Token = "0x17000029")]
		string productID
		{
			[Token(Token = "0x600007E")]
			get;
		}

		[Token(Token = "0x1700002A")]
		DateTime purchaseDate
		{
			[Token(Token = "0x600007F")]
			get;
		}
	}
}
