using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace Facebook.Unity
{
	[Token(Token = "0x2000019")]
	internal interface IFacebook
	{
		[Token(Token = "0x1700002C")]
		bool LoggedIn
		{
			[Token(Token = "0x60000B2")]
			get;
		}

		[Token(Token = "0x1700002D")]
		bool LimitEventUsage
		{
			[Token(Token = "0x60000B3")]
			get;
			[Token(Token = "0x60000B4")]
			set;
		}

		[Token(Token = "0x1700002E")]
		string SDKUserAgent
		{
			[Token(Token = "0x60000B5")]
			get;
		}

		[Token(Token = "0x1700002F")]
		bool Initialized
		{
			[Token(Token = "0x60000B6")]
			get;
		}

		[Token(Token = "0x60000B7")]
		void LogInWithPublishPermissions(IEnumerable<string> permissions, FacebookDelegate<ILoginResult> callback);

		[Token(Token = "0x60000B8")]
		void LogInWithReadPermissions(IEnumerable<string> permissions, FacebookDelegate<ILoginResult> callback);

		[Token(Token = "0x60000B9")]
		void LogOut();

		[Token(Token = "0x60000BA")]
		void AppRequest(string message, OGActionType? actionType, string objectId, IEnumerable<string> to, IEnumerable<object> filters, IEnumerable<string> excludeIds, int? maxRecipients, string data, string title, FacebookDelegate<IAppRequestResult> callback);

		[Token(Token = "0x60000BB")]
		void ShareLink(Uri contentURL, string contentTitle, string contentDescription, Uri photoURL, FacebookDelegate<IShareResult> callback);

		[Token(Token = "0x60000BC")]
		void FeedShare(string toId, Uri link, string linkName, string linkCaption, string linkDescription, Uri picture, string mediaSource, FacebookDelegate<IShareResult> callback);

		[Token(Token = "0x60000BD")]
		void API(string query, HttpMethod method, IDictionary<string, string> formData, FacebookDelegate<IGraphResult> callback);

		[Token(Token = "0x60000BE")]
		void API(string query, HttpMethod method, WWWForm formData, FacebookDelegate<IGraphResult> callback);

		[Token(Token = "0x60000BF")]
		void ActivateApp(string appId = null);

		[Token(Token = "0x60000C0")]
		void GetAppLink(FacebookDelegate<IAppLinkResult> callback);

		[Token(Token = "0x60000C1")]
		void AppEventsLogEvent(string logEvent, float? valueToSum, Dictionary<string, object> parameters);

		[Token(Token = "0x60000C2")]
		void AppEventsLogPurchase(float logPurchase, string currency, Dictionary<string, object> parameters);
	}
}
