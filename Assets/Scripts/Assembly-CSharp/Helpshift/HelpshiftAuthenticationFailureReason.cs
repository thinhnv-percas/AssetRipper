using Cpp2ILInjected;

namespace Helpshift
{
	[Token(Token = "0x20007FC")]
	public enum HelpshiftAuthenticationFailureReason
	{
		[Token(Token = "0x4001A97")]
		AUTH_TOKEN_NOT_PROVIDED = 0,
		[Token(Token = "0x4001A98")]
		INVALID_AUTH_TOKEN = 1,
		[Token(Token = "0x4001A99")]
		UNKNOWN = 2
	}
}
