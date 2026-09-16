using Cpp2ILInjected;
using UnityEngine.Purchasing.Extension;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000081")]
	public interface ITransactionHistoryExtensions : IStoreExtension
	{
		[Token(Token = "0x600021D")]
		PurchaseFailureDescription GetLastPurchaseFailureDescription();

		[Token(Token = "0x600021E")]
		StoreSpecificPurchaseErrorCode GetLastStoreSpecificPurchaseErrorCode();
	}
}
