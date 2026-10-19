using Cpp2ILInjected;

namespace Helpshift
{
	[Token(Token = "0x2000804")]
	internal static class HelpshiftEventConstants
	{
		[Token(Token = "0x4001AE3")]
		public const string HandleHelpshiftEvent = "handleHelpshiftEvent";

		[Token(Token = "0x4001AE4")]
		public const string AuthenticationFailed = "authenticationFailedForUserWithReason";

		[Token(Token = "0x4001AE5")]
		public const string LoginWithIdentitySuccess = "loginWithIdentitySuccess";

		[Token(Token = "0x4001AE6")]
		public const string LoginWithIdentityFailed = "loginWithIdentityFailed";
	}
}
