using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000002")]
	public interface INativeAppleStore : INativeStore
	{
		[Token(Token = "0x17000001")]
		string appReceipt
		{
			[Token(Token = "0x6000005")]
			get;
		}

		[Token(Token = "0x17000002")]
		bool simulateAskToBuy
		{
			[Token(Token = "0x6000006")]
			set;
		}

		[Token(Token = "0x6000001")]
		void SetUnityPurchasingCallback(UnityPurchasingCallback AsyncCallback);

		[Token(Token = "0x6000002")]
		void RestoreTransactions();

		[Token(Token = "0x6000003")]
		void RefreshAppReceipt();

		[Token(Token = "0x6000004")]
		void AddTransactionObserver();

		[Token(Token = "0x6000007")]
		void SetStorePromotionOrder(string json);

		[Token(Token = "0x6000008")]
		void SetStorePromotionVisibility(string productId, string visibility);

		[Token(Token = "0x6000009")]
		void InterceptPromotionalPurchases();

		[Token(Token = "0x600000A")]
		void ContinuePromotionalPurchases();
	}
}
