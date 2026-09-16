using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000045")]
	public interface IAppleExtensions : IStoreExtension
	{
		[Token(Token = "0x17000025")]
		bool simulateAskToBuy
		{
			[Token(Token = "0x6000105")]
			set;
		}

		[Token(Token = "0x6000102")]
		void RefreshAppReceipt(Action<string> successCallback, Action errorCallback);

		[Token(Token = "0x6000103")]
		void RestoreTransactions(Action<bool> callback);

		[Token(Token = "0x6000104")]
		void RegisterPurchaseDeferredListener(Action<Product> callback);

		[Token(Token = "0x6000106")]
		void SetStorePromotionOrder(List<Product> products);

		[Token(Token = "0x6000107")]
		void SetStorePromotionVisibility(Product product, AppleStorePromotionVisibility visible);

		[Token(Token = "0x6000108")]
		void ContinuePromotionalPurchases();

		[Token(Token = "0x6000109")]
		Dictionary<string, string> GetIntroductoryPriceDictionary();
	}
}
