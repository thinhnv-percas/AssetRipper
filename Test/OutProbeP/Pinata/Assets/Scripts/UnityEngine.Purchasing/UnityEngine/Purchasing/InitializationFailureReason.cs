using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x200000A")]
	public enum InitializationFailureReason
	{
		[Token(Token = "0x4000008")]
		PurchasingUnavailable = 0,
		[Token(Token = "0x4000009")]
		NoProductsAvailable = 1,
		[Token(Token = "0x400000A")]
		AppNotKnown = 2
	}
}
