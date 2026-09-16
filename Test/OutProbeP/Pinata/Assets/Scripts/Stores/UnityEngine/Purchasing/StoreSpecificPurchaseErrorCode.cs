using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000073")]
	public enum StoreSpecificPurchaseErrorCode
	{
		[Token(Token = "0x40001A2")]
		SKErrorUnknown = 0,
		[Token(Token = "0x40001A3")]
		SKErrorClientInvalid = 1,
		[Token(Token = "0x40001A4")]
		SKErrorPaymentCancelled = 2,
		[Token(Token = "0x40001A5")]
		SKErrorPaymentInvalid = 3,
		[Token(Token = "0x40001A6")]
		SKErrorPaymentNotAllowed = 4,
		[Token(Token = "0x40001A7")]
		SKErrorStoreProductNotAvailable = 5,
		[Token(Token = "0x40001A8")]
		SKErrorCloudServicePermissionDenied = 6,
		[Token(Token = "0x40001A9")]
		SKErrorCloudServiceNetworkConnectionFailed = 7,
		[Token(Token = "0x40001AA")]
		SKErrorCloudServiceRevoked = 8,
		[Token(Token = "0x40001AB")]
		BILLING_RESPONSE_RESULT_OK = 9,
		[Token(Token = "0x40001AC")]
		BILLING_RESPONSE_RESULT_USER_CANCELED = 10,
		[Token(Token = "0x40001AD")]
		BILLING_RESPONSE_RESULT_SERVICE_UNAVAILABLE = 11,
		[Token(Token = "0x40001AE")]
		BILLING_RESPONSE_RESULT_BILLING_UNAVAILABLE = 12,
		[Token(Token = "0x40001AF")]
		BILLING_RESPONSE_RESULT_ITEM_UNAVAILABLE = 13,
		[Token(Token = "0x40001B0")]
		BILLING_RESPONSE_RESULT_DEVELOPER_ERROR = 14,
		[Token(Token = "0x40001B1")]
		BILLING_RESPONSE_RESULT_ERROR = 15,
		[Token(Token = "0x40001B2")]
		BILLING_RESPONSE_RESULT_ITEM_ALREADY_OWNED = 16,
		[Token(Token = "0x40001B3")]
		BILLING_RESPONSE_RESULT_ITEM_NOT_OWNED = 17,
		[Token(Token = "0x40001B4")]
		IABHELPER_ERROR_BASE = 18,
		[Token(Token = "0x40001B5")]
		IABHELPER_REMOTE_EXCEPTION = 19,
		[Token(Token = "0x40001B6")]
		IABHELPER_BAD_RESPONSE = 20,
		[Token(Token = "0x40001B7")]
		IABHELPER_VERIFICATION_FAILED = 21,
		[Token(Token = "0x40001B8")]
		IABHELPER_SEND_INTENT_FAILED = 22,
		[Token(Token = "0x40001B9")]
		IABHELPER_USER_CANCELLED = 23,
		[Token(Token = "0x40001BA")]
		IABHELPER_UNKNOWN_PURCHASE_RESPONSE = 24,
		[Token(Token = "0x40001BB")]
		IABHELPER_MISSING_TOKEN = 25,
		[Token(Token = "0x40001BC")]
		IABHELPER_UNKNOWN_ERROR = 26,
		[Token(Token = "0x40001BD")]
		IABHELPER_SUBSCRIPTIONS_NOT_AVAILABLE = 27,
		[Token(Token = "0x40001BE")]
		IABHELPER_INVALID_CONSUMPTION = 28,
		[Token(Token = "0x40001BF")]
		Amazon_ALREADY_PURCHASED = 29,
		[Token(Token = "0x40001C0")]
		Amazon_FAILED = 30,
		[Token(Token = "0x40001C1")]
		Amazon_INVALID_SKU = 31,
		[Token(Token = "0x40001C2")]
		Amazon_NOT_SUPPORTED = 32,
		[Token(Token = "0x40001C3")]
		Unknown = 33
	}
}
