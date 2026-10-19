using System.Collections.Generic;
using Cpp2ILInjected;
using Facebook.Unity;

namespace ElephantSDK
{
	[Token(Token = "0x2000948")]
	public class ElephantFacebookManager : IFacebookElephantAdapter, IElephantAdapter
	{
		[Token(Token = "0x600279D")]
		[Address(RVA = "0x3E43588", Offset = "0x3E43588", Length = "0x1D4")]
		public void ActivateFacebook(string facebookAppId, string clientId)
		{
			ElephantLog.Log("FACEBOOK-ELEPHANT", "ActivateFacebook is Called");
			if (FB.IsInitialized)
			{
				FB.ActivateApp();
				FB.Mobile.SetAdvertiserIDCollectionEnabled(advertiserIDCollectionEnabled: false);
				bool flag = FB.Mobile.SetAdvertiserTrackingEnabled(advertiserTrackingEnabled: false);
			}
			else
			{
				InitDelegate onInitComplete = OnFbInitComplete;
				FB.Init(ElephantThirdPartyIds.FacebookAppId, ElephantThirdPartyIds.FacebookClientToken, cookie: true, logging: true, status: true, xfbml: false, frictionlessRequests: true, null, "en_US", null, onInitComplete);
			}
		}

		[Token(Token = "0x600279E")]
		[Address(RVA = "0x3E4375C", Offset = "0x3E4375C", Length = "0xE0")]
		private void OnFbInitComplete()
		{
			if (FB.IsInitialized)
			{
				FB.ActivateApp();
				FB.Mobile.SetAdvertiserIDCollectionEnabled(advertiserIDCollectionEnabled: false);
				bool flag = FB.Mobile.SetAdvertiserTrackingEnabled(advertiserTrackingEnabled: false);
			}
			else
			{
				ElephantLog.Log("ELEPHANT INIT", "Failed to Initialize the Facebook SDK");
			}
		}

		[Token(Token = "0x600279F")]
		[Address(RVA = "0x3E4383C", Offset = "0x3E4383C", Length = "0xCC")]
		public void AllowDataTracking()
		{
			ElephantLog.Log("FACEBOOK-ELEPHANT", "AllowDataTracking is Called");
			if (FB.IsInitialized)
			{
				FB.Mobile.SetAdvertiserIDCollectionEnabled(advertiserIDCollectionEnabled: true);
				bool flag = FB.Mobile.SetAdvertiserTrackingEnabled(advertiserTrackingEnabled: true);
			}
		}

		[Token(Token = "0x60027A0")]
		[Address(RVA = "0x3E43908", Offset = "0x3E43908", Length = "0x7C")]
		public void LogAppEvent(string eventName, float? valueToSum, Dictionary<string, object> parameters)
		{
			FB.LogAppEvent(eventName, valueToSum, parameters);
		}

		[Token(Token = "0x60027A1")]
		[Address(RVA = "0x3E43578", Offset = "0x3E43578", Length = "0x8")]
		public ElephantFacebookManager()
		{
		}
	}
}
