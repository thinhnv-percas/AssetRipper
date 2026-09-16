using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000004")]
	public delegate void UnityPurchasingCallback(string subject, string payload, string receipt, string transactionId);
}
