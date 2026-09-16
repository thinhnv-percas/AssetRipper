using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000006")]
	internal interface IInternalStoreListener
	{
		[Token(Token = "0x6000013")]
		void OnInitializeFailed(InitializationFailureReason error);

		[Token(Token = "0x6000014")]
		PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e);

		[Token(Token = "0x6000015")]
		void OnPurchaseFailed(Product i, PurchaseFailureReason p);

		[Token(Token = "0x6000016")]
		void OnInitialized(IStoreController controller);
	}
}
