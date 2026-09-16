using Cpp2ILInjected;

namespace UnityEngine.UDP
{
	[Token(Token = "0x2000007")]
	public enum LicensingErrorCode
	{
		[Token(Token = "0x400001E")]
		ERROR_INVALID_PACKAGE_NAME = 0,
		[Token(Token = "0x400001F")]
		ERROR_NON_MATCHING_UID = 1,
		[Token(Token = "0x4000020")]
		ERROR_NOT_MARKET_MANAGED = 2,
		[Token(Token = "0x4000021")]
		ERROR_CHECK_IN_PROGRESS = 3,
		[Token(Token = "0x4000022")]
		ERROR_INVALID_PUBLIC_KEY = 4,
		[Token(Token = "0x4000023")]
		ERROR_MISSING_PERMISSION = 5
	}
}
