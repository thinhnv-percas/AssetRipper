using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000014")]
	public enum PurchaseFailureReason
	{
		[Token(Token = "0x4000034")]
		PurchasingUnavailable = 0,
		[Token(Token = "0x4000035")]
		ExistingPurchasePending = 1,
		[Token(Token = "0x4000036")]
		ProductUnavailable = 2,
		[Token(Token = "0x4000037")]
		SignatureInvalid = 3,
		[Token(Token = "0x4000038")]
		UserCancelled = 4,
		[Token(Token = "0x4000039")]
		PaymentDeclined = 5,
		[Token(Token = "0x400003A")]
		DuplicateTransaction = 6,
		[Token(Token = "0x400003B")]
		Unknown = 7
	}
}
