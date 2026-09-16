using Cpp2ILInjected;

namespace Facebook.Unity.Mobile.IOS
{
	[Token(Token = "0x2000063")]
	internal interface IIOSWrapper
	{
		[Token(Token = "0x600024E")]
		void Init(string appId, bool frictionlessRequests, string urlSuffix, string unityUserAgentSuffix);

		[Token(Token = "0x600024F")]
		void LogInWithReadPermissions(int requestId, string scope);

		[Token(Token = "0x6000250")]
		void LogInWithPublishPermissions(int requestId, string scope);

		[Token(Token = "0x6000251")]
		void LogOut();

		[Token(Token = "0x6000252")]
		void SetShareDialogMode(int mode);

		[Token(Token = "0x6000253")]
		void ShareLink(int requestId, string contentURL, string contentTitle, string contentDescription, string photoURL);

		[Token(Token = "0x6000254")]
		void FeedShare(int requestId, string toId, string link, string linkName, string linkCaption, string linkDescription, string picture, string mediaSource);

		[Token(Token = "0x6000255")]
		void AppRequest(int requestId, string message, string actionType, string objectId, string[] to = null, int toLength = 0, string filters = "", string[] excludeIds = null, int excludeIdsLength = 0, bool hasMaxRecipients = false, int maxRecipients = 0, string data = "", string title = "");

		[Token(Token = "0x6000256")]
		void FBAppEventsActivateApp();

		[Token(Token = "0x6000257")]
		void LogAppEvent(string logEvent, double valueToSum, int numParams, string[] paramKeys, string[] paramVals);

		[Token(Token = "0x6000258")]
		void LogPurchaseAppEvent(double logPurchase, string currency, int numParams, string[] paramKeys, string[] paramVals);

		[Token(Token = "0x6000259")]
		void FBAppEventsSetLimitEventUsage(bool limitEventUsage);

		[Token(Token = "0x600025A")]
		void GetAppLink(int requestId);

		[Token(Token = "0x600025B")]
		void RefreshCurrentAccessToken(int requestId);

		[Token(Token = "0x600025C")]
		string FBSdkVersion();

		[Token(Token = "0x600025D")]
		string FBGetUserID();

		[Token(Token = "0x600025E")]
		void FetchDeferredAppLink(int requestId);
	}
}
