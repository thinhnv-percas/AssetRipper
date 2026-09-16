using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000006")]
	internal interface IUnityCallback
	{
		[Token(Token = "0x6000018")]
		void OnSetupFailed(string json);

		[Token(Token = "0x6000019")]
		void OnProductsRetrieved(string json);

		[Token(Token = "0x600001A")]
		void OnPurchaseSucceeded(string id, string receipt, string transactionID);

		[Token(Token = "0x600001B")]
		void OnPurchaseFailed(string json);
	}
}
