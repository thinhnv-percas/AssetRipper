using System;
using Cpp2ILInjected;
using GoogleMobileAds.Api;

namespace GoogleMobileAds.Common
{
	[Token(Token = "0x200002D")]
	public interface IRewardedInterstitialAdClient
	{
		[Token(Token = "0x14000068")]
		event EventHandler<EventArgs> OnAdLoaded;

		[Token(Token = "0x14000069")]
		event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

		[Token(Token = "0x1400006A")]
		event EventHandler<AdValueEventArgs> OnPaidEvent;

		[Token(Token = "0x1400006B")]
		event EventHandler<Reward> OnUserEarnedReward;

		[Token(Token = "0x1400006C")]
		event EventHandler<AdErrorEventArgs> OnAdFailedToPresentFullScreenContent;

		[Token(Token = "0x1400006D")]
		event EventHandler<EventArgs> OnAdDidPresentFullScreenContent;

		[Token(Token = "0x1400006E")]
		event EventHandler<EventArgs> OnAdDidDismissFullScreenContent;

		[Token(Token = "0x6000228")]
		void CreateRewardedInterstitialAd();

		[Token(Token = "0x6000229")]
		void LoadAd(string adUnitID, AdRequest request);

		[Token(Token = "0x600022A")]
		Reward GetRewardItem();

		[Token(Token = "0x600022B")]
		void Show();

		[Token(Token = "0x600022C")]
		void SetServerSideVerificationOptions(ServerSideVerificationOptions serverSideVerificationOptions);

		[Token(Token = "0x600022D")]
		IResponseInfoClient GetResponseInfoClient();
	}
}
