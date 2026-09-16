using Cpp2ILInjected;

namespace Facebook.Unity.Mobile
{
	[Token(Token = "0x200005E")]
	internal interface IMobileFacebook : IFacebook
	{
		[Token(Token = "0x1700007C")]
		ShareDialogMode ShareDialogMode
		{
			[Token(Token = "0x6000238")]
			set;
		}

		[Token(Token = "0x6000239")]
		void FetchDeferredAppLink(FacebookDelegate<IAppLinkResult> callback);

		[Token(Token = "0x600023A")]
		void RefreshCurrentAccessToken(FacebookDelegate<IAccessTokenRefreshResult> callback);

		[Token(Token = "0x600023B")]
		bool IsImplicitPurchaseLoggingEnabled();
	}
}
