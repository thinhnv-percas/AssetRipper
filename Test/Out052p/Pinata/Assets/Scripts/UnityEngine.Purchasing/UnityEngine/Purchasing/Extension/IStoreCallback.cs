using System.Collections.Generic;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing.Extension
{
	[Token(Token = "0x2000026")]
	public interface IStoreCallback
	{
		[Token(Token = "0x17000023")]
		ProductCollection products
		{
			[Token(Token = "0x60000B1")]
			get;
		}

		[Token(Token = "0x60000B2")]
		void OnSetupFailed(InitializationFailureReason reason);

		[Token(Token = "0x60000B3")]
		void OnProductsRetrieved(List<ProductDescription> products);

		[Token(Token = "0x60000B4")]
		void OnPurchaseSucceeded(string storeSpecificId, string receipt, string transactionIdentifier);

		[Token(Token = "0x60000B5")]
		void OnPurchaseFailed(PurchaseFailureDescription desc);
	}
}
