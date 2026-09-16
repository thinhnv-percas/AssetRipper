using Cpp2ILInjected;

namespace Facebook.Unity.Mobile
{
	[Token(Token = "0x2000060")]
	internal interface IMobileFacebookResultHandler : IFacebookResultHandler
	{
		[Token(Token = "0x600023C")]
		void OnFetchDeferredAppLinkComplete(ResultContainer resultContainer);

		[Token(Token = "0x600023D")]
		void OnRefreshCurrentAccessTokenComplete(ResultContainer resultContainer);
	}
}
