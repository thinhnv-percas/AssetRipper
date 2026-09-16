using Cpp2ILInjected;

namespace Facebook.Unity
{
	[Token(Token = "0x200001C")]
	internal interface IFacebookResultHandler
	{
		[Token(Token = "0x60000C7")]
		void OnInitComplete(ResultContainer resultContainer);

		[Token(Token = "0x60000C8")]
		void OnLoginComplete(ResultContainer resultContainer);

		[Token(Token = "0x60000C9")]
		void OnLogoutComplete(ResultContainer resultContainer);

		[Token(Token = "0x60000CA")]
		void OnGetAppLinkComplete(ResultContainer resultContainer);

		[Token(Token = "0x60000CB")]
		void OnAppRequestsComplete(ResultContainer resultContainer);

		[Token(Token = "0x60000CC")]
		void OnShareLinkComplete(ResultContainer resultContainer);
	}
}
