using System.Collections.Generic;
using Cpp2ILInjected;

namespace Facebook.Unity.Gameroom
{
	[Token(Token = "0x2000053")]
	internal interface IGameroomWrapper
	{
		[Token(Token = "0x1700006D")]
		IDictionary<string, object> PipeResponse
		{
			[Token(Token = "0x60001DB")]
			get;
			[Token(Token = "0x60001DC")]
			set;
		}

		[Token(Token = "0x60001DD")]
		void Init(GameroomFacebook.OnComplete completeDelegate);

		[Token(Token = "0x60001DE")]
		void DoLoginRequest(string appID, string permissions, string callbackID, GameroomFacebook.OnComplete completeDelegate);

		[Token(Token = "0x60001DF")]
		void DoPayRequest(string appId, string method, string action, string product, string productId, string quantity, string quantityMin, string quantityMax, string requestId, string pricepointId, string testCurrency, string developerPayload, string callbackID, GameroomFacebook.OnComplete completeDelegate);

		[Token(Token = "0x60001E0")]
		void DoFeedShareRequest(string appId, string toId, string link, string linkName, string linkCaption, string linkDescription, string pictureLink, string mediaSource, string callbackID, GameroomFacebook.OnComplete completeDelegate);

		[Token(Token = "0x60001E1")]
		void DoAppRequestRequest(string appId, string message, string actionType, string objectId, string to, string filters, string excludeIDs, string maxRecipients, string data, string title, string callbackID, GameroomFacebook.OnComplete completeDelegate);
	}
}
