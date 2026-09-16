using System;
using Cpp2ILInjected;
using GoogleMobileAds.Api;

namespace GoogleMobileAds.Common
{
	[Token(Token = "0x2000029")]
	public interface IMobileAdsClient
	{
		[Token(Token = "0x60001E2")]
		void Initialize(string appId);

		[Token(Token = "0x60001E3")]
		void Initialize(Action<IInitializationStatusClient> initCompleteAction);

		[Token(Token = "0x60001E4")]
		void DisableMediationInitialization();

		[Token(Token = "0x60001E5")]
		void SetApplicationVolume(float volume);

		[Token(Token = "0x60001E6")]
		void SetApplicationMuted(bool muted);

		[Token(Token = "0x60001E7")]
		void SetiOSAppPauseOnBackground(bool pause);

		[Token(Token = "0x60001E8")]
		float GetDeviceScale();

		[Token(Token = "0x60001E9")]
		int GetDeviceSafeWidth();

		[Token(Token = "0x60001EA")]
		void SetRequestConfiguration(RequestConfiguration requestConfiguration);

		[Token(Token = "0x60001EB")]
		RequestConfiguration GetRequestConfiguration();
	}
}
