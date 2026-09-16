using System;
using System.Collections.ObjectModel;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000036")]
	internal interface INativeUDPStore : INativeStore
	{
		[Token(Token = "0x60000B2")]
		void Initialize(Action<bool, string> callback);

		[Token(Token = "0x60000B3")]
		void Purchase(string productId, Action<bool, string> callback, string developerPayload = null);

		[Token(Token = "0x60000B4")]
		void RetrieveProducts(ReadOnlyCollection<ProductDefinition> products, Action<bool, string> callback);

		[Token(Token = "0x60000B5")]
		void FinishTransaction(ProductDefinition productDefinition, string transactionID);
	}
}
