using Cpp2ILInjected;

namespace ElephantSDK
{
	[Token(Token = "0x2000963")]
	public enum ElephantPaymentErrorType
	{
		[Token(Token = "0x4001FB1")]
		Unknown = 0,
		[Token(Token = "0x4001FB2")]
		ProductsFetchFailed = 1,
		[Token(Token = "0x4001FB3")]
		StartCheckoutFailed = 2,
		[Token(Token = "0x4001FB4")]
		NoEscrowCode = 3,
		[Token(Token = "0x4001FB5")]
		PendingCheckFailed = 4,
		[Token(Token = "0x4001FB6")]
		ConfirmPurchaseInvalidTransaction = 5,
		[Token(Token = "0x4001FB7")]
		ConfirmPurchaseBackendFailed = 6
	}
}
