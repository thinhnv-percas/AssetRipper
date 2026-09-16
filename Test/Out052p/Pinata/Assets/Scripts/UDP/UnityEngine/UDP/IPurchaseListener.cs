using Cpp2ILInjected;

namespace UnityEngine.UDP
{
	[Token(Token = "0x200000C")]
	public interface IPurchaseListener
	{
		[Token(Token = "0x6000031")]
		void OnPurchase(PurchaseInfo purchaseInfo);

		[Token(Token = "0x6000032")]
		void OnPurchaseFailed(string message, PurchaseInfo purchaseInfo);

		[Token(Token = "0x6000033")]
		void OnPurchaseConsume(PurchaseInfo purchaseInfo);

		[Token(Token = "0x6000034")]
		void OnPurchaseConsumeFailed(string message, PurchaseInfo purchaseInfo);

		[Token(Token = "0x6000035")]
		void OnQueryInventory(Inventory inventory);

		[Token(Token = "0x6000036")]
		void OnQueryInventoryFailed(string message);
	}
}
