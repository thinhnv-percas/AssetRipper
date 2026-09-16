using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000008")]
	public interface IStoreListener
	{
		[Token(Token = "0x600001B")]
		void OnInitializeFailed(InitializationFailureReason error);

		[Token(Token = "0x600001C")]
		PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e);

		[Token(Token = "0x600001D")]
		void OnPurchaseFailed(Product i, PurchaseFailureReason p);

		[Token(Token = "0x600001E")]
		void OnInitialized(IStoreController controller, IExtensionProvider extensions);
	}
}
