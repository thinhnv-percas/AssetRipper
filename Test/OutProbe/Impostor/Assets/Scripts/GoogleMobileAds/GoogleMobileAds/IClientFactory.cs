using Cpp2ILInjected;
using GoogleMobileAds.Common;

namespace GoogleMobileAds
{
	[Token(Token = "0x2000008")]
	public interface IClientFactory
	{
		[Token(Token = "0x6000015")]
		IBannerClient BuildBannerClient();

		[Token(Token = "0x6000016")]
		IInterstitialClient BuildInterstitialClient();

		[Token(Token = "0x6000017")]
		IRewardBasedVideoAdClient BuildRewardBasedVideoAdClient();

		[Token(Token = "0x6000018")]
		IRewardedAdClient BuildRewardedAdClient();

		[Token(Token = "0x6000019")]
		IRewardedInterstitialAdClient BuildRewardedInterstitialAdClient();

		[Token(Token = "0x600001A")]
		IAdLoaderClient BuildAdLoaderClient(AdLoaderClientArgs args);

		[Token(Token = "0x600001B")]
		IMobileAdsClient MobileAdsInstance();
	}
}
