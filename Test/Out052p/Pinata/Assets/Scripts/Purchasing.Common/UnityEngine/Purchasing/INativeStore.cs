using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000003")]
	public interface INativeStore
	{
		[Token(Token = "0x6000003")]
		void RetrieveProducts(string json);

		[Token(Token = "0x6000004")]
		void Purchase(string productJSON, string developerPayload);

		[Token(Token = "0x6000005")]
		void FinishTransaction(string productJSON, string transactionID);
	}
}
