using Cpp2ILInjected;

namespace UnityEngine.Purchasing.Security
{
	[Token(Token = "0x200001D")]
	public enum GooglePurchaseState
	{
		[Token(Token = "0x4000037")]
		Purchased = 0,
		[Token(Token = "0x4000038")]
		Cancelled = 1,
		[Token(Token = "0x4000039")]
		Refunded = 2
	}
}
