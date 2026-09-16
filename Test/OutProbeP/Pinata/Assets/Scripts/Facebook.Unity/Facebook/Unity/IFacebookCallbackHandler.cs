using Cpp2ILInjected;

namespace Facebook.Unity
{
	[Token(Token = "0x200001A")]
	internal interface IFacebookCallbackHandler
	{
		[Token(Token = "0x60000C3")]
		void OnInitComplete(string message);

		[Token(Token = "0x60000C4")]
		void OnLoginComplete(string message);

		[Token(Token = "0x60000C5")]
		void OnAppRequestsComplete(string message);

		[Token(Token = "0x60000C6")]
		void OnShareLinkComplete(string message);
	}
}
